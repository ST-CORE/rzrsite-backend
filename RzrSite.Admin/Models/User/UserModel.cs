using System.ComponentModel.DataAnnotations;

namespace RzrSite.Admin.Models.User
{
  public class UserModel
  {
    [Key]
    public int Id { get; set; }
    public string Login { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
  }
}
