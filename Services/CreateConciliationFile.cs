using CardExtractTreatment.Entities;
using System.Collections.Generic;

namespace CardExtractTreatment.Services
{
    class CreateConciliationFile
    {
        public List<ConciliationEx> ConciliationFileEx { get; set; }

        public CreateConciliationFile(List<ConciliationEx> conciliationFileEx)
        {
            ConciliationFileEx = conciliationFileEx;
        }
    }
}
