namespace RzrSite.Models.Responses.FeatureType
{
  public class AddedFeatureType
  {
    public string Path { get; set; }

    public AddedFeatureType(int id)
    {
      Path = $"api/FeatureType/{id}";
    }
  }
}
