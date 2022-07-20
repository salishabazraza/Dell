using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Common
{
    public class APIResultModel
    {
        public object data { get; set; }
        public int code { get; set; }
        public string description { get; set; }
    }
}
