namespace RzrSite.Models.Responses.Category
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
