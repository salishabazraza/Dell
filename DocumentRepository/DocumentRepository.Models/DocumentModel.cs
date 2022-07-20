using DocumentRepository.Shared.DataServices;
using DocumentRepository.Shared.DataServices.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.Models
{
    public class DocumentModel
    {
        public Document Document { get; set; }
        public List<KeywordEntity> Keywords { get; set; }
    }
    public class DocumentKeywordCountModel
    {
        public int DocumentId { get; set; }
        public int Count { get; set; }
    }
}
