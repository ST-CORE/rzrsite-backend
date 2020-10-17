using RzrSite.Admin.Repositories.Interfaces;

namespace RzrSite.Admin.Controllers
{
  public class FeatureController
  {
    private IFeatureRepository _repo { get; }

    public FeatureController(IFeatureRepository repo)
    {
      _repo = repo;
    }


  }
}
