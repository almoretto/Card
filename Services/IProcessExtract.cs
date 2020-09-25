using System;
using System.Collections.Generic;
using System.Text;

namespace CardExtractTreatment.Services
{
    interface IProcessExtract<T>
    {
        List<T> ProcessExtract(List<T> lista);
        void WriteExConciliation(List<T> ex);
    }
}
