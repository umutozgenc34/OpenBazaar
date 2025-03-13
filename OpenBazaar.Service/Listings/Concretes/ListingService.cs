using AutoMapper;
using OpenBazaar.Model.Listings.Dtos;
using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Repository.Listings.Abstracts;
using OpenBazaar.Repository.UnitOfWorks.Abstracts;
using OpenBazaar.Service.Listings.Abstracts;
using OpenBazaar.Shared.Responses;
using OpenBazaar.Shared.Services.CloudinaryServices.Abstracts;
using System.Net;

namespace OpenBazaar.Service.Listings.Concretes;

public class ListingService(IListingRepository listingRepository, IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinaryService) : IListingService
{
    public async Task<ServiceResult<List<ListingDto>>> GetAllAsync()
    {
        var listings = await listingRepository.GetAllAsync();
        var listingDtos = mapper.Map<List<ListingDto>>(listings);
        return ServiceResult<List<ListingDto>>.Success(listingDtos);
    }

    public async Task<ServiceResult<ListingDto>> GetByIdAsync(Guid id)
    {
        var listing = await listingRepository.GetByIdAsync(id);
        if (listing is null)
        {
            return ServiceResult<ListingDto>.Fail("Listing not found.", HttpStatusCode.NotFound);
        }

        var listingDto = mapper.Map<ListingDto>(listing);
        return ServiceResult<ListingDto>.Success(listingDto);
    }

    public async Task<ServiceResult<ListingDto>> CreateAsync(CreateListingRequest request)
    {
        var listing = mapper.Map<Listing>(request);


        if (request.ImageUrls is not null && request.ImageUrls.Any())
        {
            var uploadResult = await cloudinaryService.UploadImages(request.ImageUrls, "listings");
            if (!uploadResult.IsSuccess)
            {
                return ServiceResult<ListingDto>.Fail(uploadResult.ErrorMessage, HttpStatusCode.InternalServerError);
            }
            listing.ImageUrls = uploadResult.Data;
        }

        await listingRepository.AddAsync(listing);
        await unitOfWork.SaveChangesAsync();

        var listingDto = mapper.Map<ListingDto>(listing);
        return ServiceResult<ListingDto>.SuccessAsCreated(listingDto, $"listings/{listing.Id}");
    }

    public async Task<ServiceResult> UpdateAsync(UpdateListingRequest request)
    {
        var listing = await listingRepository.GetByIdAsync(request.Id);
        if (listing is null)
        {
            return ServiceResult.Fail("Listing not found.", HttpStatusCode.NotFound);
        }

        mapper.Map(request, listing);

        if (request.ImageUrls is not null && request.ImageUrls.Any())
        {
            var uploadResult = await cloudinaryService.UploadImages(request.ImageUrls, "listings");
            if (!uploadResult.IsSuccess)
            {
                return ServiceResult.Fail(uploadResult.ErrorMessage, HttpStatusCode.InternalServerError);
            }
            listing.ImageUrls = uploadResult.Data;
        }

        listingRepository.Update(listing);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Listing updated successfully.", HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(Guid id)
    {
        var listing = await listingRepository.GetByIdAsync(id);
        if (listing is null)
        {
            return ServiceResult.Fail("Listing not found.", HttpStatusCode.NotFound);
        }

        listingRepository.Delete(listing);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success("Listing deleted successfully.", HttpStatusCode.NoContent);
    }
}