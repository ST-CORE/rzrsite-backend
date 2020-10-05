﻿using RzrSite.Models.Resources.ProductLine;
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
  }
}
