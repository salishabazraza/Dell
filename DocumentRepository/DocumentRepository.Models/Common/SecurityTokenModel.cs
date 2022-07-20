
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Common
{
    public class SecurityTokenModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string roleName { get; set; }
        public int roleId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
    }
    
}
