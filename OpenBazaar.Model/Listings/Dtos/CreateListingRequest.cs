using Microsoft.AspNetCore.Http;

namespace OpenBazaar.Model.Listings.Dtos;

public sealed record CreateListingRequest(string Title,string Description,decimal Price, List<IFormFile>? ImageUrls,int CategoryId,string UserId);

