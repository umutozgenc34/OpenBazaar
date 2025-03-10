﻿namespace OpenBazaar.Repository.UnitOfWorks.Abstracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
