using AutoMapper;
using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.API.Responses.ProductLine.Mappings
{
  public class ProductLineResponseProfile: Profile
  {
    public ProductLineResponseProfile()
    {
      CreateMap<IProductLine, FullProductLine>();
      CreateMap<IProductLine, StrippedProductLine>();
    }
  }
}
