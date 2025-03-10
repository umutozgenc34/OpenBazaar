using OpenBazaar.Repository.Context;
using OpenBazaar.Repository.UnitOfWorks.Abstracts;

namespace OpenBazaar.Repository.UnitOfWorks.Concretes;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}