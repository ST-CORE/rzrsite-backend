using System;
using System.Collections.Generic;
using System.Text;

namespace RzrSite.Models.Resources.Image.Interface
{
  public interface IPutImage
  {
    public string Title { get; set; }
    public int Weight { get; set; }
    public int? FullId { get; set; }
    public int? ThumbId { get; set; }
  }
}
