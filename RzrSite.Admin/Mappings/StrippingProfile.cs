using AutoMapper;
using RzrSite.Models.Entities.Interfaces;
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

      CreateMap<IProductLine, StrippedProductLine>()
        .ForMember(d => d.FeaturesPDFPath, opt => opt.MapFrom(s => s.FeaturesPDF.Path));
    }
  }
}
