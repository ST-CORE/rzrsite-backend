using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Product.Interface;

namespace RzrSite.DAL.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<IPutProduct, Product>()
              .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<IPostProduct, Product>();
            CreateMap<IProduct, Product>();
        }
    }
}
