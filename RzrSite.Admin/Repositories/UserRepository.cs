using RzrSite.Admin.Data;
using RzrSite.Admin.Helper;
using RzrSite.Admin.Models.User;
using System;
using System.Linq;

namespace RzrSite.Admin.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly AdminDbContext _dbContext;

    public UserRepository(AdminDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public UserResponse Create(string login, string password)
    {
      if (_dbContext.Users.Any(u => login.ToLowerInvariant() == u.Login))
      {
        return new UserResponse
        {
          IsSuccess = false,
          Message = "User already exists"
        };
      }

      var salt = Guid.NewGuid().ToByteArray();
      var passwordHash = HashHelper.Hash(password.Select(w => (byte)w).ToArray(), salt);

      var newUser = new UserModel
      {
        Login = login,
        PasswordHash = passwordHash,
        PasswordSalt = salt
      };

      _dbContext.Users.Add(newUser);
      _dbContext.SaveChanges();
      return new UserResponse { IsSuccess = true, Message = "User created" };
    }

    public UserResponse Validate(string login, string password)
    {
      // TODO: Remove this once we get proper way of auth
      if (_dbContext.Users.Count() == 0)
      {
        var createResponse = Create(login, password);
        if (!createResponse.IsSuccess)
        {
          return createResponse;
        }
      }

      var user = _dbContext.Users.FirstOrDefault(p => p.Login == login);

      if (user == null)
      {
        return new UserResponse
        {
          IsSuccess = false,
          Message = "User not found"
        };
      }

      var hashesMatched = HashHelper.CompareWithHash(password, user.PasswordHash, user.PasswordSalt);

      if (hashesMatched)
      {
        return new UserResponse
        {
          IsSuccess = true,
          Message = "User is valid"
        };
      }
      else
      {
        return new UserResponse
        {
          IsSuccess = false,
          Message = "Wrong password"
        };
      }
    }
  }
}
