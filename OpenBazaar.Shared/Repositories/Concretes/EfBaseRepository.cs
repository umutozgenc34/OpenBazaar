﻿using Microsoft.EntityFrameworkCore;
using OpenBazaar.Shared.Entities;
using OpenBazaar.Shared.Repositories.Abstracts;
using System.Linq.Expressions;

namespace OpenBazaar.Shared.Repositories.Concretes;

public class EfBaseRepository<TDbContext, TEntity, TId>(TDbContext context) : IEfBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>, new()
    where TDbContext : DbContext
{
    protected TDbContext Context { get; } = context;
    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);
    public void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);
    public async Task<List<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();
    public async Task<TEntity?> GetByIdAsync(TId id) => await Context.Set<TEntity>().FindAsync(id);
    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return predicate is null
            ? Context.Set<TEntity>()
            : Context.Set<TEntity>().Where(predicate);
    }
}