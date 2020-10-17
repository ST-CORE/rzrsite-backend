namespace RzrSite.Models.Responses.DbFile
{
  public class AddedDbFile
  {
    public string Path { get; set; }

    public AddedDbFile(int id)
    {
      Path = $"api/DbFile/{id}";
    }
  }
}
