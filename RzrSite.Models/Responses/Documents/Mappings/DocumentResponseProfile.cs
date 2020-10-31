using AutoMapper;
using RzrSite.Models.Responses.ProductLine;

namespace RzrSite.Models.Responses.Documents.Mappings
{
    public class DocumentResponseProfile : Profile
    {
        public DocumentResponseProfile()
        {
            CreateMap<ProductLineDocument, ProductLineDocumentResponse>();
        }
    }
}
