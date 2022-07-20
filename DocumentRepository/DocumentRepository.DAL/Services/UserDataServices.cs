using DocumentRepository.Shared.DataServices;
using DocumentRepository.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.DAL.Services
{
    public class UserDataServices
    {
        #region Singleton
        private static UserDataServices _instance;
        public static UserDataServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new UserDataServices();
                }
                return _instance;
            }
        }

        private UserDataServices()
        {

        }
        #endregion

        public User LoginUser(string email, string password)
        {
            using (var context = DataContextHelper.GetPOSPortalContext()){
                var psql = PetaPoco.Sql.Builder.Select("*")
                           .From("Users")
                           .Where("email=@0 and password=@1", email, password.Encrypt());
                return context.Fetch<User>(psql).FirstOrDefault();
            }
        }
    }
}
