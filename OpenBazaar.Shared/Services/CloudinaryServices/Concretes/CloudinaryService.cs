using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OpenBazaar.Shared.Services.CloudinaryServices.Abstracts;
using System.Net;
using OpenBazaar.Shared.Responses;

namespace OpenBazaar.Shared.Services.CloudinaryServices.Concretes;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;
    private readonly Account _account;
    private readonly CloudinarySettings _cloudinarySettings;

    public CloudinaryService(IOptions<CloudinarySettings> cloudOptions)
    {
        _cloudinarySettings = cloudOptions.Value;
        _account = new Account(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);
        _cloudinary = new Cloudinary(_account);
    }

    public async Task<ServiceResult<List<string>>> UploadImages(IEnumerable<IFormFile> files, string folder)
    {
        var imageUrls = new List<string>();

        foreach (var file in files)
        {
            var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream),
                Folder = folder,
                UseFilename = true,
                UniqueFilename = false
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == HttpStatusCode.OK)
            {
                imageUrls.Add(uploadResult.SecureUrl.ToString());
            }
            else
            {
                return ServiceResult<List<string>>.Fail(
                    new List<string> { "Image upload failed." }, HttpStatusCode.InternalServerError);
            }
        }

        return ServiceResult<List<string>>.Success(imageUrls, HttpStatusCode.OK);
    }
}