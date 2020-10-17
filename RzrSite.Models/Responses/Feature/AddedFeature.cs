namespace RzrSite.Models.Responses.Feature
{
  public class AddedFeature
  {
    public string Path { get; set; }

    public AddedFeature(int productId, int id)
    {
      Path = $"api/Product/{productId}/Feature/{id}";
    }
  }
}
