using System.Collections.Generic;

namespace WebFront.Core.Helper
{
    public class KeywordCreateandUpdateModel
    {
            public int keywordId { get; set; }
            public string title { get; set; }
        
    }

    public class KeywordDocumentModel
    {
        public int keywordId { get; set; }
        public string title { get; set; }
        public int documentKeywordId { get; set; }
    }

    public class KeywordDocumentAPIModel
    {
        public int documentId { get; set; }
        public string documentName { get; set; }
        public List<KeywordDocumentModel> keywordDocumentModel { get; set; }
    }
}
