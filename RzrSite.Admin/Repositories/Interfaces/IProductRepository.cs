using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Product;
using RzrSite.Models.Responses.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
  public interface IProductRepository
  {
    Task<bool?> AddProduct(int categoryId, int productLineId, PostProduct model);
    Task<IList<Product>> GetProducts(int categoryId, int productLineId);
    Task<Product> GetProduct(int categoryId, int productLineId, int id);
    Task<Product> UpdateProduct(int categoryId, int productLineid, int id, PutProduct product);
    Task<bool> RemoveProduct(int categoryId, int productLineId, int id);
  }
}
