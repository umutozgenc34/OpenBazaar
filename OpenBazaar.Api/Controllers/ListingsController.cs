using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenBazaar.Model.Listings.Dtos;
using OpenBazaar.Service.Listings.Abstracts;

namespace OpenBazaar.Api.Controllers;

public class ListingsController(IListingService listingService) : CustomBaseController
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllListings() => CreateActionResult(await listingService.GetAllAsync());
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetListingById([FromRoute] Guid id) => CreateActionResult(await listingService.GetByIdAsync(id));
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateListing([FromForm] CreateListingRequest request) => CreateActionResult(await listingService.CreateAsync(request));
    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateListing([FromRoute] Guid id, [FromForm] UpdateListingRequest request) => CreateActionResult(await listingService.UpdateAsync(request));
    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteListing([FromRoute] Guid id) => CreateActionResult(await listingService.DeleteAsync(id));
}