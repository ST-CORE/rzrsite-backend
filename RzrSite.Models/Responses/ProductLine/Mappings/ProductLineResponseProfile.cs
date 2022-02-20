using AutoMapper;
using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.Models.Responses.ProductLine.Mappings
{
  public class ProductLineResponseProfile: Profile
  {
    public ProductLineResponseProfile()
    {
      CreateMap<IProductLine, FullProductLine>();
      CreateMap<IProductLine, StrippedProductLine>()
        .ForMember(d => d.FeaturesPDFPath, d => d.MapFrom(s => s.FeaturesPDF.Path));
      CreateMap<FullProductLine, StrippedProductLine>()
        .ForMember(d => d.FeaturesPDFPath, d => d.MapFrom(s => s.FeaturesPDF.Path));
    }
  }
}
