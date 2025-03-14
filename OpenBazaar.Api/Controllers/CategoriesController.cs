using Microsoft.AspNetCore.Mvc;
using OpenBazaar.Model.Categories.Dtos;
using OpenBazaar.Service.Categories.Abstracts;

namespace OpenBazaar.Api.Controllers;

public class CategoriesController(ICategoryService categoryService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories() => CreateActionResult(await categoryService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id) => CreateActionResult(await categoryService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request) => CreateActionResult(await categoryService.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id) => CreateActionResult(await categoryService.DeleteAsync(id));

    [HttpGet("{id:int}/listings")]
    public async Task<IActionResult> GetCategoryWithListings([FromRoute] int id) => CreateActionResult(await categoryService
        .GetCategoryWithListingsAsync(id));

    [HttpGet("listings")]
    public async Task<IActionResult> GetCategoryWithListings() => CreateActionResult(await categoryService
        .GetCategoryWithListingsAsync());
}
