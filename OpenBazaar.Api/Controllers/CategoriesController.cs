using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenBazaar.Model.Categories.Dtos;
using OpenBazaar.Service.Categories.Abstracts;

namespace OpenBazaar.Api.Controllers;

public class CategoriesController(ICategoryService categoryService) : CustomBaseController
{
    [Authorize(Roles = "Admin,User")]
    [HttpGet]
    public async Task<IActionResult> GetAllCategories() => CreateActionResult(await categoryService.GetAllAsync());
    [Authorize(Roles = "Admin,User")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id) => CreateActionResult(await categoryService.GetByIdAsync(id));
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request) => CreateActionResult(await categoryService.CreateAsync(request));
    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(id, request));
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id) => CreateActionResult(await categoryService.DeleteAsync(id));
    [Authorize(Roles = "Admin,User")]
    [HttpGet("{id:int}/listings")]
    public async Task<IActionResult> GetCategoryWithListings([FromRoute] int id) => CreateActionResult(await categoryService
        .GetCategoryWithListingsAsync(id));
    [Authorize(Roles = "Admin,User")]
    [HttpGet("listings")]
    public async Task<IActionResult> GetCategoryWithListings() => CreateActionResult(await categoryService
        .GetCategoryWithListingsAsync());
}
