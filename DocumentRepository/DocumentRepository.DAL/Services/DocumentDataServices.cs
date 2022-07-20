using DocumentRepository.Models;
using DocumentRepository.Shared.DataServices;
using DocumentRepository.Shared.DataServices.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.DAL.Services
{
    public class DocumentDataServices
    {
        #region Singleton
        private static DocumentDataServices _instance;
        public static DocumentDataServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new DocumentDataServices();
                }
                return _instance;
            }
        }

        private DocumentDataServices()
        {

        }
        #endregion
        public DocumentModel GetDocument(int documentId, bool withKeywords = true)
        {
            DocumentModel model = new DocumentModel();
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("*").From("Documents").Where("DocumentId=@0", documentId);
                model.Document = context.Fetch<Document>(psql).FirstOrDefault();
                if (withKeywords && model.Document != null)
                {
                    model.Keywords = GetKeywordsByDocumentId(documentId);
                }
            }
            return model;
        }
        public List<KeywordEntity> GetKeywordsByDocumentId(int documentId)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("k.*,dk.DocumentKeywordId,dk.DocumentId").From("Keywords k").InnerJoin("DocumentKeywords dk").On("k.KeywordId=dk.KeywordId")
                    .Where("dk.DocumentId=@0", documentId);
                return context.Fetch<KeywordEntity>(psql).ToList();
            }
        }
        public List<DocumentModel> GetDocuments(bool withKeywords = false, int pageNo = 1)
        {
            List<DocumentModel> model = new List<DocumentModel>();
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("*").From("Documents").OrderBy("DocumentId desc").Paginate(pageNo, 50);
                var documents = context.Fetch<Document>(psql).ToList();
                if (documents != null && documents.Count > 0)
                {
                    foreach (var doc in documents)
                    {
                        DocumentModel document = new DocumentModel();
                        document.Document = doc;
                        if (withKeywords)
                        {
                            document.Keywords = GetKeywordsByDocumentId(doc.DocumentId);
                        }
                        model.Add(document);
                    }
                }
                else
                {
                    model = null;
                }
            }
            return model;
        }
        public Document AddOrUpdateDocument(Document document, int userId)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                if (document.DocumentId > 0)
                {
                    document.UpdatedBy = userId;
                    document.UpdatedOn = DateTime.Now;
                    context.Update(document);
                }
                else
                {
                    document.CreatedBy = userId;
                    document.CreatedOn = DateTime.Now;
                    context.Insert(document);
                }
                return document;
            }
        }
        public List<Document> GetDocumentsByKeywords(List<int> keywordIds, int pageNo = 1)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("d.*")
                    .From("DocumentKeywords dk").InnerJoin("Documents d").On("d.DocumentId=dk.DocumentId")
                    .Where("dk.KeywordId in (@ids)", new { ids = keywordIds });//.Paginate(pageNo, 50);
                return context.Fetch<Document>(psql).ToList();
            }
        }

        public List<Document> GetDocumentsByKeyword(int keywordId, int pageNo = 1)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("d.*")
                    .From("DocumentKeywords dk").InnerJoin("Documents d").On("d.DocumentId=dk.DocumentId")
                    .Where("dk.KeywordId in (@ids)", new { ids = keywordId });//.Paginate(pageNo, 50);
                return context.Fetch<Document>(psql).ToList();
            }
        }

    }
}
