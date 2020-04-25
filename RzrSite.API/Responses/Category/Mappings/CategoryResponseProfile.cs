using AutoMapper;
using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.API.Responses.Category.Mappings
{
  public class CategoryResponseProfile: Profile
  {
    public CategoryResponseProfile()
    {
      CreateMap<ICategory, FullCategory>();
      CreateMap<ICategory, StrippedCategory>();
    }
  }
}
