using System;
using System.Data;
using System.Text;

namespace DocumentRepository.Shared.DataServices
{
    public partial class DocumentDataRepository
    {
        public override void OnExecutingCommand(System.Data.IDbCommand cmd)
        {
            base.OnExecutingCommand(cmd);
        }

    }
}
