namespace RzrSite.API.Responses.ProductLine
{
  public class AddedProductLine
  {
    public string Path { get; set; }

    public AddedProductLine(int categoryId, int id)
    {
      Path = $"api/Category/{categoryId}/ProductLine/{id}";
    }
  }
}
