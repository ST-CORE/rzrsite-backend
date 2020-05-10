using System.Runtime.Serialization;

namespace RzrSite.Models.Enums
{
  [DataContract]
  public enum FileFormat
  {
    [EnumMember(Value = "0")]
    Error = 0,
    [EnumMember(Value = "1")]
    Png = 1,
    [EnumMember(Value = "2")]
    Jpg = 2,
    [EnumMember(Value = "3")]
    Pdf = 3
  }
}
