﻿using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.ProductLine.Interfaces;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IProductLineRepo
  {
    /// <summary>
    /// Retrieves product lines
    /// </summary>
    /// <param name="categoryId">Id of parent category</param>
    /// <returns>List of <see cref="IProductLine"/> for one <see cref="ICategory"/> </returns>
    IEnumerable<IProductLine> GetAll(int categoryId);
    /// <summary>
    /// Retrieves single product line
    /// </summary>
    /// <param name="categoryId">Id of category to get from</param>
    /// <param name="id">Id of Product Line</param>
    /// <returns><see cref="IProductLine"/>; Null if not found;</returns>
    IProductLine Get(int id);
    /// <summary>
    /// Adds new product line by POST resource representation
    /// </summary>
    /// <param name="categoryId">Id of category to add to</param>
    /// <param name="productLine">POST resource representation</param>
    /// <returns>Id of added productLine</returns>
    int? Add(int categoryId, IPostProductLine productLine);
    /// <summary>
    /// Updates existing product line by PUT resource representation
    /// </summary>
    /// <param name="categoryId">Id of parent category</param>
    /// <param name="id">Id of product line to be updated</param>
    /// <param name="productLine">PUT resource representation</param>
    /// <returns>Updated product line; Null - if not found</returns>
    IProductLine Update(int categoryId, int id, IPutProductLine productLine);
    /// <summary>
    /// Removes product line without products by Id
    /// </summary>
    /// <param name="categoryId">Id of parent category</param>
    /// <param name="id">Id of product line to remove</param>
    /// <returns>True if prouct line was removed or not found; False - if not empty;</returns>
    bool Delete(int categoryId, int id);

  }
}