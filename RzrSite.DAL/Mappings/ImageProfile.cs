using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Image.Interface;
using RzrSite.Models.Responses.Image;

namespace RzrSite.DAL.Mappings
{
  public class ImageProfile: Profile
  {
    public ImageProfile()
    {
      CreateMap<IPutImage, Image>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<IPostImage, Image>();

      CreateMap<Image, FullImage>();
    }
  }
}
