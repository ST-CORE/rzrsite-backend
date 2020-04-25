namespace RzrSite.API.Responses.Category
{
  public class AddedCategory
  {
    public string Path { get; set; }

    public AddedCategory(int id)
    {
      Path = $"api/Category/{id}";
    }
  }
}
