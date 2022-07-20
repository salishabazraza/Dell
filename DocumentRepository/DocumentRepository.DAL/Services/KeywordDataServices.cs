using DocumentRepository.Models;
using DocumentRepository.Shared.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.DAL.Services
{
    public class KeywordDataServices
    {
        #region Singleton
        private static KeywordDataServices _instance;
        public static KeywordDataServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new KeywordDataServices();
                }
                return _instance;
            }
        }

        private KeywordDataServices()
        {

        }
        #endregion
        public KeywordModel GetKeyword(int keywordId, bool withDocuments = false)
        {
            KeywordModel model = new KeywordModel();
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("*").From("Keywords").Where("KeywordId=@0", keywordId);
                model.Keyword = context.Fetch<Keyword>(psql).FirstOrDefault();
                if (withDocuments && model.Keyword != null)
                {
                    model.Documents = GetKeywordDocuments(keywordId);
                }
            }
            return model;
        }
        public List<KeywordModel> GetKeywords(bool withDocuments = false, int pageNo = 1,List<int> keywordIds=null)
        {
            List<KeywordModel> model = new List<KeywordModel>();
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("*").From("Keywords");
                if (keywordIds != null && keywordIds.Count > 0)
                {
                    psql = psql.Where("KeywordId in (@ids)", new { ids = keywordIds });
                }
                else
                {
                   // psql = psql.Paginate(pageNo, 50);
                }

                var keywords = context.Fetch<Keyword>(psql).ToList();

                if (withDocuments)
                {
                    if (keywords != null && keywords.Count > 0)
                    {
                        foreach (var word in keywords)
                        {
                            KeywordModel keyword = new KeywordModel();
                            keyword.Keyword = word;
                            keyword.Documents = GetKeywordDocuments(word.KeywordId);
                            model.Add(keyword);
                        }
                    }
                }
            }
            return model;
        }
        public List<Document> GetKeywordDocuments(int keywordId)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                var psql = PetaPoco.Sql.Builder.Select("d.*").From("Documents d").InnerJoin("DocumentKeywords dk").On("d.DocumentId=dk.DocumentId")
                    .Where("dk.KeywordId=@0", keywordId);
                return context.Fetch<Document>(psql).ToList();
            }
        }
        public void UpdateOrAddKeywords(Keyword keyword, int userId, string title = null)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                if (keyword != null && keyword.KeywordId > 0)
                {
                    context.Update(keyword);
                }
                else
                {
                    if (keyword == null)
                    {
                        keyword = new Keyword();
                        keyword.Title = title;
                        keyword.CreatedOn = DateTime.Now;
                        keyword.CreatedBy = userId;
                    }
                    if (keyword != null)
                    {
                        context.Insert(keyword);
                    }
                }
            }
        }
        public void RemoveDocumentKeywords(List<int> keywordIds)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                context.Delete<DocumentKeyword>(" where DocumentKeywordId in (@ids)", new { ids = keywordIds });
            }
        }

        public void RemoveDocumentKeywordLinks(int keywordIds)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                context.Delete<DocumentKeyword>(" where KeywordId in (@ids)", new { ids = keywordIds });
            }
        }
        public void RemoveKeyword(int keywordId)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                context.Delete<Keyword>(" where KeywordId in (@ids)", new { ids = keywordId });
            }
        }
        public void AddDocumentKeyword(int keywordId,int documentId, int userId)
        {
            using (var context = DataContextHelper.GetPOSPortalContext())
            {
                DocumentKeyword model = new DocumentKeyword();
                model.CreatedBy = userId;
                model.CreatedOn = DateTime.Now;
                model.KeywordId = keywordId;
                model.DocumentId = documentId;
                context.Insert(model);
            }
        }
    }
}
