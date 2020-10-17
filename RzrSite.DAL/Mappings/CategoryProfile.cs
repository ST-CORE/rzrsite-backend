using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Category.Interfaces;

namespace RzrSite.DAL.Mappings
{
  public class CategoryProfile: Profile
  {
    public CategoryProfile()
    {
      CreateMap<IPutCategory, Category>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<IPostCategory, Category>();
    }
  }
}
