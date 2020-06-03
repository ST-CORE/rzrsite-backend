namespace RzrSite.Models.Responses.Image
{
  public class AddedImage
  {
    public string Path { get; set; }
    public AddedImage(int productId, int id)
    {
      Path = $"api/Product/{productId}/Image/{id}";
    }
  }
}
