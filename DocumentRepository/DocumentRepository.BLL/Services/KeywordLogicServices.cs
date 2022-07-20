using DocumentRepository.DAL.Services;
using DocumentRepository.Models;
using DocumentRepository.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.BLL.Services
{
    public class KeywordLogicServices
    {
        #region Singleton
        private static KeywordLogicServices _instance;
        public static KeywordLogicServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new KeywordLogicServices();
                }
                return _instance;
            }
        }

        private KeywordLogicServices()
        {

        }
        #endregion
        public async Task<APIResultModel> GetKeywords(int? keywordId,int pageNo=1,List<int> keywordIds=null)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    object keyword = null;
                    if (keywordId.HasValue && keywordId > 0)
                    {
                        keyword = KeywordDataServices.Instance.GetKeyword(keywordId.Value,true);
                    }
                    else
                    {
                        keyword = KeywordDataServices.Instance.GetKeywords(true, pageNo,keywordIds);
                    }

                    if (keyword != null)
                    {
                        return new APIResultModel
                        {
                            data = keyword,
                            code = (int)HttpStatusCode.OK,
                            description = "API success."
                        };
                    }
                    else
                    {
                        return new APIResultModel
                        {
                            code = (int)HttpStatusCode.NoContent,
                            description = "No record."
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new APIResultModel
                    {
                        code = (int)HttpStatusCode.InternalServerError,
                        description = "API failed. Please contact administrator to resolve the issue."
                    };
                }
            });
            return result;
        }
        public async Task<APIResultModel> AddorUpdateKeywords(List<KeywordPostModel> model, int userId)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (model != null && model.Count > 0)
                    {
                        foreach (var key in model)
                        {
                            if (key.KeywordId > 0)
                            {
                                var keyword = KeywordDataServices.Instance.GetKeyword(key.KeywordId);
                                if (!string.IsNullOrEmpty(key.Title) && keyword != null && keyword.Keyword != null && !String.Equals(key.Title, keyword.Keyword.Title))
                                {
                                    keyword.Keyword.Title = key.Title;
                                    KeywordDataServices.Instance.UpdateOrAddKeywords(keyword.Keyword, userId,null);
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(key.Title))
                                {
                                    KeywordDataServices.Instance.UpdateOrAddKeywords(null, userId, key.Title);
                                }
                            }
                        }
                        return new APIResultModel
                        {
                            code = (int)HttpStatusCode.OK,
                            description = "API success."
                        };
                    }
                    else
                    {
                        return new APIResultModel
                        {
                            code = (int)HttpStatusCode.NoContent,
                            description = "No record."
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new APIResultModel
                    {
                        code = (int)HttpStatusCode.InternalServerError,
                        description = "API failed. Please contact administrator to resolve the issue."
                    };
                }
            });
            return result;
        }
        public async Task<APIResultModel> AddorUpdateKeywordWithDocument(KeywordDocumentPostModel model, int userId)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (model != null && model.DocumentId > 0)
                    {
                        var dbDocumentKeywords = DocumentDataServices.Instance.GetKeywordsByDocumentId(model.DocumentId);
                        if (dbDocumentKeywords != null && dbDocumentKeywords.Count > 0)
                        {
                            var dbIds = dbDocumentKeywords.Select(c => c.DocumentKeywordId).Distinct().ToList();
                            if ((dbIds != null && dbIds.Count > 0) && (model.KeywordDocumentModel == null || (model.KeywordDocumentModel != null && model.KeywordDocumentModel.Count == 0)))
                            {
                                KeywordDataServices.Instance.RemoveDocumentKeywords(dbIds);
                            }
                            else
                            {
                                if (dbIds != null && dbIds.Count > 0 && model.KeywordDocumentModel != null && model.KeywordDocumentModel.Count > 0)
                                {
                                    var postIds = model.KeywordDocumentModel.Select(c => c.DocumentKeywordId).Distinct().ToList();
                                    var idsToDelete = dbIds.Except(postIds).ToList();
                                    if (idsToDelete != null && idsToDelete.Count > 0)
                                    {
                                        KeywordDataServices.Instance.RemoveDocumentKeywords(idsToDelete);
                                    }
                                }
                            }
                        }
                        if (model.KeywordDocumentModel != null && model.KeywordDocumentModel.Count > 0)
                        {
                            var newRecs = model.KeywordDocumentModel.Where(c => c.DocumentKeywordId == 0).ToList();
                            if (newRecs != null && newRecs.Count > 0)
                            {
                                var dbKeywordIds = newRecs.Select(c => c.KeywordId).Distinct().ToList();
                                var keyWordModel=KeywordDataServices.Instance.GetKeywords(true, 0, dbKeywordIds);
                                if (keyWordModel != null && keyWordModel.Count > 0)
                                {
                                    foreach (var record in keyWordModel)
                                    {
                                        if (record.Keyword!=null)
                                        {
                                            KeywordDataServices.Instance.AddDocumentKeyword(record.Keyword.KeywordId, model.DocumentId, userId);
                                        }
                                    }
                                }
                            }
                        }
                        return new APIResultModel
                        {
                            code = (int)HttpStatusCode.OK,
                            description = "API success."
                        };
                    }
                    else
                    {
                        return new APIResultModel
                        {
                            code = (int)HttpStatusCode.NoContent,
                            description = "No record."
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new APIResultModel
                    {
                        code = (int)HttpStatusCode.InternalServerError,
                        description = "API failed. Please contact administrator to resolve the issue."
                    };
                }
            });
            return result;
        }
        public async Task<APIResultModel> SearchDocumentByKeywords(List<int> keywordIds,int pageNo=1)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (keywordIds != null && keywordIds.Count > 0)
                    {
                        var dbDocumentKeywords = DocumentDataServices.Instance.GetDocumentsByKeywords(keywordIds, pageNo);
                        if (dbDocumentKeywords != null && dbDocumentKeywords.Count > 0)
                        {
                            return new APIResultModel
                            {
                                data=dbDocumentKeywords,
                                code = (int)HttpStatusCode.OK,
                                description = "API success."
                            };
                        }
                        else
                        {
                            return new APIResultModel
                            {
                                code = (int)HttpStatusCode.NoContent,
                                description = "No record."
                            };
                        }
                    }
                    else
                    {
                        return new APIResultModel
                        {
                            code = (int)HttpStatusCode.NoContent,
                            description = "No record."
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new APIResultModel
                    {
                        code = (int)HttpStatusCode.InternalServerError,
                        description = "API failed. Please contact administrator to resolve the issue."
                    };
                }
            });
            return result;
        }

        public async Task<APIResultModel> DeletedKeywords(int keywordId)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                      //  var dbDocumentKeywords = DocumentDataServices.Instance.GetDocumentsByKeyword(keywordId, 0);
                        if (keywordId !=  0)
                        {
                        //var dbIds = dbDocumentKeywords.Select(c => c.DocumentId).Distinct().ToList();
                        KeywordDataServices.Instance.RemoveDocumentKeywordLinks(keywordId);
                        KeywordDataServices.Instance.RemoveKeyword(keywordId);
                        return new APIResultModel
                            {
                                code = (int)HttpStatusCode.OK,
                                description = "API success."
                            };
                        }
                        else
                        {
                            return new APIResultModel
                            {
                                code = (int)HttpStatusCode.NoContent,
                                description = "No record."
                            };
                        }
                    
                }
                catch (Exception ex)
                {
                    return new APIResultModel
                    {
                        code = (int)HttpStatusCode.InternalServerError,
                        description = "API failed. Please contact administrator to resolve the issue."
                    };
                }
            });
            return result;
        }

    }
}
