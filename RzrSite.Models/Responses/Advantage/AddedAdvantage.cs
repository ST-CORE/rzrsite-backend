namespace RzrSite.Models.Responses.Advantage
{
  public class AddedAdvantage
  {
    public string Path { get; set; }

    public AddedAdvantage(int productLineId, int id)
    {
      Path = $"api/ProductLine/{productLineId}/Advantage/{id}";
    }
  }
}
