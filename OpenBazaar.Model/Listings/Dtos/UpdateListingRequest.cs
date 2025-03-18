using Microsoft.AspNetCore.Http;

namespace OpenBazaar.Model.Listings.Dtos;

public sealed record UpdateListingRequest(Guid Id,string Title, string Description, decimal Price, List<IFormFile>? ImageUrls, int CategoryId,string UserId);