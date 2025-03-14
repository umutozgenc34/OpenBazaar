using OpenBazaar.Model.Categories.Entities;
using OpenBazaar.Shared.Repositories.Abstracts;

namespace OpenBazaar.Repository.Categories.Abstracts;

public interface ICategoryRepository : IEfBaseRepository<Category, int>
{
    Task<Category?> GetCategoryWithListingsAsync(int id);
    IQueryable<Category?> GetCategoryWithListings();
}

