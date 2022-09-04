using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Video.Interface;
using RzrSite.Models.Responses.Video;

namespace RzrSite.DAL.Mappings
{
  public class VideoProfile: Profile
  {
    public VideoProfile()
    {
      CreateMap<IPutVideo, Video>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<IPostVideo, Video>();

      CreateMap<Video, FullVideo>();
    }
  }
}
