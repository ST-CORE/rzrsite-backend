using AutoMapper;
using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.Models.Responses.Image.Mappings
{
  public class ImageResponseProfile: Profile
  {
    public ImageResponseProfile()
    {
      CreateMap<IImage, FullImage>()
        .ForMember(m => m.FullPath, opts => opts.MapFrom((src, dest) =>
        {
          if (src.Full != null)
          {
            return src.Full.Path;
          }
          else
          {
            return "";
          };
        }))
        .ForMember(m => m.ThumbPath, opts => opts.MapFrom((src, dest) =>
        {
          if (src.Thumb != null)
          {
            return src.Thumb.Path;
          }
          else
          {
            return "";
          };
        }));
    }
  }
}
