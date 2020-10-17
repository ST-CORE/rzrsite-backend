using RzrSite.Admin.Models.User;

namespace RzrSite.Admin.Repository
{
  public interface IUserRepository
  {
    UserResponse Validate(string login, string password);
    UserResponse Create(string lofin, string password);
  }
}
