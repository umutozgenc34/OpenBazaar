using Microsoft.EntityFrameworkCore;
using OpenBazaar.Model.Categories.Entities;
using OpenBazaar.Repository.Categories.Abstracts;
using OpenBazaar.Repository.Context;
using OpenBazaar.Shared.Repositories.Concretes;

namespace OpenBazaar.Repository.Categories.Concretes;

public class CategoryRepository(AppDbContext context) : EfBaseRepository<AppDbContext, Category, int>(context), ICategoryRepository
{
    public IQueryable<Category?> GetCategoryWithListings() => Context.Categories.Include(x => x.Listings).AsQueryable();


    public Task<Category?> GetCategoryWithListingsAsync(int id) => Context.Categories.Include(x => x.Listings).FirstOrDefaultAsync(x => x.Id == id);
}
