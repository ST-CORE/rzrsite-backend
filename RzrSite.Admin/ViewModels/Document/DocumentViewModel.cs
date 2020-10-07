using RzrSite.Models.Resources.DbFile;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RzrSite.Admin.ViewModels.Document
{
    public class DocumentViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, выберите категорию")]
        public int CategoryId { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, выберите линию")]
        public int ProductLineId { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, выберите документ")]
        public int FileId { get; set; }
        public List<StrippedDbFile> Files { get; set; }

        [Required]
        public string Description { get; set; }

        public int Weight { get; set; } = 0;

        public DocumentViewModel()
        {
            
        }

        public DocumentViewModel(IEnumerable<StrippedDbFile> files, int categoryId, int productLineId)
        {
            Files = files.ToList();
            ProductLineId = productLineId;
            CategoryId = categoryId;
        }
    }
}
