using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.Video.Interface;
using System.Collections.Generic;

namespace RzrSite.DAL.Repositories.Interfaces
{
  public interface IVideoRepo
  {
    /// <summary>
    /// Retrieves videos
    /// </summary>
    /// <param name="productLineId">Id of productLine</param>
    /// <returns>List of <see cref="IVideo"/> for one <see cref="IProduct"/> </returns>
    IEnumerable<IVideo> GetAll(int productId);
    /// <summary>
    /// Retrieves single video
    /// </summary>
    /// <param name="id">Id of video</param>
    /// <returns><see cref="IVideo"/>; Null if not found;</returns>
    IVideo Get(int id);
    /// <summary>
    /// Adds new video by POST resource representation
    /// </summary>
    /// <param name="productId">Id of product to add to</param>
    /// <param name="video">POST resource representation</param>
    /// <returns>Id of added video</returns>
    int? Add(int productId, IPostVideo video);
    /// <summary>
    /// Updates existing video by PUT resource representation
    /// </summary>
    /// <param name="productId">Id of parent product</param>
    /// <param name="id">Id of video to be updated</param>
    /// <param name="video">PUT resource representation</param>
    /// <returns>Updated product line; Null - if not found</returns>
    IVideo Update(int productId, int id, IPutVideo video);
    /// <summary>
    /// Removes product line without products by Id
    /// </summary>
    /// <param name="videoId">Id of parent category</param>
    /// <param name="id">Id of product line to remove</param>
    /// <returns>True if prouct line was removed or not found; False - if not empty;</returns>
    bool Delete(int videoId, int id);
  }
}
