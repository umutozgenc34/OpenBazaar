using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Repository.Context;
using OpenBazaar.Repository.Listings.Abstracts;
using OpenBazaar.Shared.Repositories.Concretes;

namespace OpenBazaar.Repository.Listings.Concretes;

public class ListingRepository(AppDbContext context) : EfBaseRepository<AppDbContext,Listing,Guid>(context),IListingRepository;
