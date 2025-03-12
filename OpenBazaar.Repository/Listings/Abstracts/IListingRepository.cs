using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Shared.Repositories.Abstracts;

namespace OpenBazaar.Repository.Listings.Abstracts;

public interface IListingRepository  :IEfBaseRepository<Listing,Guid>;
