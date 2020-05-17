using RzrSite.Models.Resources.Category;
using RzrSite.Models.Responses.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface ICategoryRepository
  {
    Task<IList<StrippedCategory>> GetCategories();
    Task<FullCategory> GetCategory(int categoryId);
    Task<bool> RemoveCategory(int categoryId);
    Task<AddedCategory> AddCategory(PostCategory postCategory);
    Task<StrippedCategory> UpdateCategory(int categoryId, PutCategory putProductLine);
  }
}
