using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class InternationalPassportInfoVisaInfo
    {
        public int InternationalPassportId { get; set; }
        public InternationalPassportInfo InternationalPassportInfo { get; set; } 
        public int VisaInfoId { get; set; }
        public VisaInfo VisaInfo { get; set; }

    }
}
