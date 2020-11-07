using RzrSite.Models.Entities;
using RzrSite.Models.Resources.Documents;
using RzrSite.Models.Resources.ProductLine;
using RzrSite.Models.Responses.ProductLine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RzrSite.Admin.Repositories.Interfaces
{
    public interface IProductLineRepository
    {
        Task<FullProductLine> GetProductLine(int categoryId, int productLineid);
        Task<IList<StrippedProductLine>> GetProductLines(int categoryId);
        Task<IList<ProductLineDocument>> GetProductLineDocuments(int categoryId, int productLineId);
        Task<bool> RemoveProductLine(int categoryId, int id);
        Task<AddedProductLine> AddProductLine(int categoryId, PostProductLine postProductLine);
        Task<StrippedProductLine> UpdateProductLine(int categoryId, int id, PutProductLine putProductLine);
        Task<Document> GetDocument(int id);
        Task<bool> AddDocument(PostDocument putProductLine);
        Task<bool> EditDocument(PutDocument model);
        Task<bool> DeleteDocument(int id);
        Task<bool> SetShowOnMain(int categoryId, int productLineId);
    }
}
