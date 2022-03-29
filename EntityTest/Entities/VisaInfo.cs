using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public  class VisaInfo
    {
        public int VisaID { get; set; }
        public InternationalPassportInfo InternationalPassportInfo { get; set; }
        public DateTime VisaStart { get; set; }
        public DateTime VisaEnd { get; set; }

    }
}
