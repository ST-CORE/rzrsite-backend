using AutoMapper;
using RzrSite.Models.Resources.DbFile;

namespace RzrSite.Admin.Profiles
{
  public class DbFileProfile: Profile
  {
    public DbFileProfile()
    {
      CreateMap<StrippedDbFile, PutDbFile>();
    }
  }
}
