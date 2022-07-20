using Document.SecurityToken;
using DocumentRepository.BLL.Models;
using DocumentRepository.DAL.Services;
using DocumentRepository.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using DocumentRepository.BLL.CommonCode.Helpers;

namespace DocumentRepository.BLL.Services
{
    public class LoginLogicServices
    {
        #region Singleton
        private static LoginLogicServices _instance;
        public static LoginLogicServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new LoginLogicServices();
                }
                return _instance;
            }
        }

        private LoginLogicServices()
        {

        }
        #endregion

        public async Task<APIResultModel> LoginVerify(LoginLogicModel loginLogicModel)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(loginLogicModel.Email) && !string.IsNullOrEmpty(loginLogicModel.Password) && CommonHelper.IsValidEmail(loginLogicModel.Email))
                    {
                        var user = UserDataServices.Instance.LoginUser(loginLogicModel.Email, loginLogicModel.Password);
                        if (user != null && user.UserId > 0)
                        {
                            SecurityTokenModel token = new SecurityTokenModel
                            {
                                emailAddress = user.Email,
                                firstName = user.FirstName,
                                lastName = user.LastName,
                                UserId = user.UserId,
                            };
                            TokenGenerator tokenGenerator = new TokenGenerator();
                            token.Token = tokenGenerator.getToken(token);

                            return new APIResultModel
                            {
                                data = token,
                                code = (int)HttpStatusCode.OK,
                                description = "Login Successfully."
                            };
                        }
                        else
                        {
                            return new APIResultModel
                            {
                                code = (int)HttpStatusCode.Unauthorized,
                                description = "Login failed."
                            };
                        }
                    }
                    else
                    {
                        return new APIResultModel
                        {
                            code = (int)HttpStatusCode.BadRequest,
                            description = "Login failed. Please provide valid data for this request."
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new APIResultModel
                    {
                        code = (int)HttpStatusCode.Unauthorized,
                        description = "Login failed. Please contact administrator to resolve the issue."
                    };
                }
            });
            return result;
        }
    }
}
