using System;
using System.Collections.Generic;

namespace WebFront.Core.Helper
{
    public class DocumentAPIModel
    {
        public Document document { get; set; }
        public List<Keyword> keywords { get; set; }
    }

    public class KeywordsAPIModel
    {
        public Keywords keyword { get; set; }
        public List<Document> documents { get; set; }
    }

    public class Keywords
    {
        public int keywordId { get; set; }
        public string title { get; set; }
        public DateTime createdOn { get; set; }
        public int createdBy { get; set; }
    }

    public class Document
    {
        public int documentId { get; set; }
        public string title { get; set; }
        public string docURL { get; set; }
        public string extension { get; set; }
        public double size { get; set; }
        public bool isVisible { get; set; }
        public DateTime createdOn { get; set; }
        public int createdBy { get; set; }
        public DateTime? updatedOn { get; set; }
        public int? updatedBy { get; set; }
    }

    public class Keyword
    {
        public int documentKeywordId { get; set; }
        public int documentId { get; set; }
        public int keywordId { get; set; }
        public string title { get; set; }
        public DateTime createdOn { get; set; }
        public int createdBy { get; set; }
    }

}
