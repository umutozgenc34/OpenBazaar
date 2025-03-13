using AutoMapper;
using OpenBazaar.Model.Listings.Dtos;
using OpenBazaar.Model.Listings.Entities;

namespace OpenBazaar.Service.Listings.Profiles;

public class ListingMappingProfile : Profile
{
    public ListingMappingProfile()
    {
        CreateMap<CreateListingRequest, Listing>();
        CreateMap<UpdateListingRequest, Listing>();
        CreateMap<Listing, ListingDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();
    }
}
