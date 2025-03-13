using OpenBazaar.Model.Listings.Dtos;
using OpenBazaar.Shared.Responses;

namespace OpenBazaar.Service.Listings.Abstracts;

public interface IListingService
{
    Task<ServiceResult<List<ListingDto>>> GetAllAsync();
    Task<ServiceResult<ListingDto>> GetByIdAsync(Guid id);
    Task<ServiceResult<ListingDto>> CreateAsync(CreateListingRequest request);
    Task<ServiceResult> UpdateAsync(UpdateListingRequest request);
    Task<ServiceResult> DeleteAsync(Guid id);
}
