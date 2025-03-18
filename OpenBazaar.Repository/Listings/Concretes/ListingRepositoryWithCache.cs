using Microsoft.Extensions.Caching.Distributed;
using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Repository.Listings.Abstracts;
using System.Linq.Expressions;
using System.Text.Json;

namespace OpenBazaar.Repository.Listings.Concretes;

public class ListingRepositoryWithCache : IListingRepository
{
    private readonly IListingRepository _innerRepository;
    private readonly IDistributedCache _distributedCache;
    private const string CacheKeyPrefix = "listing_";

    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        IgnoreReadOnlyProperties = true
    };

    public ListingRepositoryWithCache(IListingRepository innerRepository, IDistributedCache distributedCache)
    {
        _innerRepository = innerRepository;
        _distributedCache = distributedCache;
    }

    public async Task<List<Listing>> GetAllAsync()
    {
        var cacheKey = $"{CacheKeyPrefix}all_listings";

        var cachedData = await _distributedCache.GetStringAsync(cacheKey);
        if (cachedData != null)
        {
            var cachedListings = JsonSerializer.Deserialize<List<Listing>>(cachedData, _jsonSerializerOptions);
            return cachedListings!;
        }

        var listings = await _innerRepository.GetAllAsync();

        await _distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(listings, _jsonSerializerOptions), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
        });

        return listings;
    }

    public async Task<Listing?> GetByIdAsync(Guid id)
    {
        var cacheKey = $"{CacheKeyPrefix}{id}";

        var cachedData = await _distributedCache.GetStringAsync(cacheKey);
        if (cachedData != null)
        {
            return JsonSerializer.Deserialize<Listing>(cachedData, _jsonSerializerOptions);
        }

        var listing = await _innerRepository.GetByIdAsync(id);

        if (listing != null)
        {
            await _distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(listing, _jsonSerializerOptions), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }

        return listing;
    }

    public IQueryable<Listing> Where(Expression<Func<Listing, bool>>? predicate = null)
    {
        return _innerRepository.Where(predicate);
    }

    public async Task AddAsync(Listing entity)
    {
        await _innerRepository.AddAsync(entity);
        await _distributedCache.RemoveAsync($"{CacheKeyPrefix}{entity.Id}");
        await _distributedCache.RemoveAsync($"{CacheKeyPrefix}all_listings");
    }

    public void Update(Listing entity)
    {
        _innerRepository.Update(entity);
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}{entity.Id}");
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}all_listings");
    }

    public void Delete(Listing entity)
    {
        _innerRepository.Delete(entity);
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}{entity.Id}");
        _distributedCache.RemoveAsync($"{CacheKeyPrefix}all_listings"); 
    }
}