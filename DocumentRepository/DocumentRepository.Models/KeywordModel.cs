using DocumentRepository.Shared.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.Models
{
    public class KeywordModel
    {
        public Keyword Keyword { get; set; }
        public List<Document> Documents { get; set; }
    }
    public class KeywordDocumentCountModel
    {
        public int KeywordId { get; set; }
        public int Count { get; set; }
    }
    public class KeywordPostModel
    {
        public int KeywordId { get; set; }
        public string Title { get; set; }
    }
    public class KeywordDocumentModel: KeywordPostModel
    {
        public int DocumentKeywordId { get; set; }
    }
    public class KeywordDocumentPostModel
    {
        public int DocumentId { get; set; }
        public List<KeywordDocumentModel> KeywordDocumentModel { get; set; }

    }
}
