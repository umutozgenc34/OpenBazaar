﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OpenBazaar.Shared.Entities;

namespace OpenBazaar.Repository.Interceptors;

public class AuditDbContextInterceptor : SaveChangesInterceptor
{
    private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviors = new()
    {
        { EntityState.Added, AddBehavior },
        { EntityState.Modified, ModifiedBehavior }
    };

    private static void AddBehavior(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.CreatedTime = DateTime.UtcNow;
        context.Entry(auditEntity).Property(x => x.UpdatedTime).IsModified = false;
    }

    private static void ModifiedBehavior(DbContext context, IAuditEntity auditEntity)
    {
        context.Entry(auditEntity).Property(x => x.CreatedTime).IsModified = false;
        auditEntity.UpdatedTime = DateTime.UtcNow;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
        {
            if (entityEntry.Entity is not IAuditEntity auditEntity) continue;


            if (entityEntry.State is not (EntityState.Added or EntityState.Modified)) continue;


            Behaviors[entityEntry.State](eventData.Context, auditEntity);


        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}