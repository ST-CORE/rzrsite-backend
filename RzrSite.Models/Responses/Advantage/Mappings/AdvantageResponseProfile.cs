using AutoMapper;
using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.Models.Responses.Advantage.Mappings
{
  public class AdvantageResponseProfile : Profile
  {
    public AdvantageResponseProfile()
    {
      CreateMap<IAdvantage, FullAdvantage>()
        .ForMember(m => m.Icon, opts => opts.MapFrom((src, dest) =>
        {
          if (src.Icon != null)
          {
            return src.Icon.Path;
          }
          else
          {
            return "";
          };
        }));
    }
  }
}
