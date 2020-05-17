using AutoMapper;
using RzrSite.Models.Responses.Category;
using RzrSite.Models.Responses.ProductLine;

namespace RzrSite.Admin.Mappings
{
  public class StrippingProfile : Profile
  {
    public StrippingProfile()
    {
      CreateMap<FullProductLine, StrippedProductLine>();
      CreateMap<FullCategory, StrippedCategory>();
    }
  }
}
