using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RzrSite.Admin.Helper
{
  public static class HashHelper
  {
    public static byte[] Hash(byte[] plainText, byte[] salt)
    {
      var algorithm = new SHA256Managed();

      var plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

      for (int i = 0; i < plainText.Length; i++)
      {
        plainTextWithSaltBytes[i] = plainText[i];
      }
      for (int i = 0; i < salt.Length; i++)
      {
        plainTextWithSaltBytes[plainText.Length + i] = salt[i];
      }

      return algorithm.ComputeHash(plainTextWithSaltBytes);
    }

    public static bool CompareWithHash(string plainText, byte[] hash, byte[] salt)
    {
      var inputText = Encoding.ASCII.GetBytes(plainText);
      var resultHash = Hash(inputText, salt);

      return resultHash.SequenceEqual(hash);
    }
  }
}
