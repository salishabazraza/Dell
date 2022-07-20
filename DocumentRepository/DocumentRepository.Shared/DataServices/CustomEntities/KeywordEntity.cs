using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRepository.Shared.DataServices.CustomEntities
{
    public class KeywordEntity:Keyword
    {
        [ResultColumn]
        public int DocumentKeywordId { get; set; }
        [ResultColumn]
        public int DocumentId { get; set; }
    }
}
