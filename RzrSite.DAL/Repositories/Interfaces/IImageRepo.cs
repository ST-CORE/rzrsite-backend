using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Image.Interface;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IImageRepo
  {
    /// <summary>
    /// Retrieves images
    /// </summary>
    /// <param name="productLineId">Id of productLine</param>
    /// <returns>List of <see cref="IImage"/> for one <see cref="IProduct"/> </returns>
    IEnumerable<IImage> GetAll(int productId);
    /// <summary>
    /// Retrieves single image
    /// </summary>
    /// <param name="id">Id of image</param>
    /// <returns><see cref="IImage"/>; Null if not found;</returns>
    IImage Get(int id);
    /// <summary>
    /// Adds new image by POST resource representation
    /// </summary>
    /// <param name="productId">Id of product to add to</param>
    /// <param name="image">POST resource representation</param>
    /// <returns>Id of added image</returns>
    int? Add(int productId, IPostImage image);
    /// <summary>
    /// Updates existing image by PUT resource representation
    /// </summary>
    /// <param name="productId">Id of parent product</param>
    /// <param name="id">Id of image to be updated</param>
    /// <param name="image">PUT resource representation</param>
    /// <returns>Updated product line; Null - if not found</returns>
    IImage Update(int productId, int id, IPutImage image);
    /// <summary>
    /// Removes product line without products by Id
    /// </summary>
    /// <param name="imageId">Id of parent category</param>
    /// <param name="id">Id of product line to remove</param>
    /// <returns>True if prouct line was removed or not found; False - if not empty;</returns>
    bool Delete(int imageId, int id);
  }
}
