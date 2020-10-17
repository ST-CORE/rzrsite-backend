using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Advantage.Interfaces;

namespace RzrSite.DAL.Mappings
{
  public class AdvantageProfile: Profile
  {
    public AdvantageProfile()
    {
      CreateMap<IPutAdvantage, Advantage>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<IPostAdvantage, Advantage>();
    }
  }
}
