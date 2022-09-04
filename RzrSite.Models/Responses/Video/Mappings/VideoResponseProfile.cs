using AutoMapper;
using RzrSite.Models.Entities.Interfaces;

namespace RzrSite.Models.Responses.Video.Mappings
{
	public class VideoResponseProfile : Profile
	{
		public VideoResponseProfile()
		{
			CreateMap<IVideo, FullVideo>()
			.ForMember(m => m.Url, opts => opts.MapFrom((src, dest) =>
				{
					if (src.Url != null)
					{
						return src.Url;
					}
					else
					{
						return "";
					};
				}));
		}
	}
}
