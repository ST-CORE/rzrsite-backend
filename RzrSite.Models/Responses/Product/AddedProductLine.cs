namespace RzrSite.Models.Responses.Product
{
  public class AddedProduct
  {
    public string Path { get; set; }

    public AddedProduct(int productLineId, int id)
    {
      Path = $"api/ProductLine/{productLineId}/Product/{id}";
    }
  }
}
