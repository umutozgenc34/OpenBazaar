using Microsoft.AspNetCore.Mvc;
using OpenBazaar.Model.Listings.Dtos;
using OpenBazaar.Service.Listings.Abstracts;

namespace OpenBazaar.Api.Controllers;

public class ListingsController(IListingService listingService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllListings() => CreateActionResult(await listingService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetListingById([FromRoute] Guid id) => CreateActionResult(await listingService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateListing([FromForm] CreateListingRequest request) => CreateActionResult(await listingService.CreateAsync(request));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateListing([FromRoute] Guid id, [FromForm] UpdateListingRequest request) => CreateActionResult(await listingService.UpdateAsync(request));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteListing([FromRoute] Guid id) => CreateActionResult(await listingService.DeleteAsync(id));
}