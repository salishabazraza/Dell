using DocumentRepository.DAL.Services;
using DocumentRepository.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.BLL.Services
{
    public class DocumentLogicServices
    {
        #region Singleton
        private static DocumentLogicServices _instance;
        public static DocumentLogicServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new DocumentLogicServices();
                }
                return _instance;
            }
        }

        private DocumentLogicServices()
        {

        }
        #endregion
        public async Task<APIResultModel> GetDocuments(int? documentId,int pageNo=1)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    object document = null;
                    if (documentId.HasValue && documentId > 0)
                    {
                        document = DocumentDataServices.Instance.GetDocument(documentId.Value);
                    }
                    else
                    {
                        document = DocumentDataServices.Instance.GetDocuments(false,pageNo);
                    }

                    if (document != null)
                    {
                        return new APIResultModel
                        {
                            data = document,
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
