using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.ProductLine.Interfaces;

namespace RzrSite.DAL.Mappings
{
  public class ProductLineProfile: Profile
  {
    public ProductLineProfile()
    {
      CreateMap<IPutProductLine, ProductLine>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<IPostProductLine, ProductLine>();
    }
  }
}
