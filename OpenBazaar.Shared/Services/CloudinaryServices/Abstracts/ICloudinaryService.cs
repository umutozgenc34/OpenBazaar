using Microsoft.AspNetCore.Http;
using OpenBazaar.Shared.Responses;

namespace OpenBazaar.Shared.Services.CloudinaryServices.Abstracts;

public interface ICloudinaryService
{
    Task<ServiceResult<List<string>>> UploadImages(IEnumerable<IFormFile> files, string folder);
}