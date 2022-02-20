using AutoMapper;
using RzrSite.Models.Entities;
using RzrSite.Models.Resources.DbFile;
using RzrSite.Models.Resources.DbFile.Interfaces;

namespace RzrSite.DAL.Mappings
{
  public class DbFileProfile : Profile
  {
	public DbFileProfile()
	{
	  CreateMap<IPutDbFile, DbFile>()
		  .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	  CreateMap<IPostDbFile, DbFile>();
	  
	  CreateMap<DbFile, StrippedDbFile>()
		  .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
  }
}
