using OpenBazaar.Model.Categories.Entities;
using OpenBazaar.Repository.Categories.Abstracts;
using OpenBazaar.Repository.Context;
using OpenBazaar.Shared.Repositories.Concretes;

namespace OpenBazaar.Repository.Categories.Concretes;

public class CategoryRepository(AppDbContext context) : EfBaseRepository<AppDbContext,Category,int>(context),ICategoryRepository;
