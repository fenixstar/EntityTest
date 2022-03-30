using System.ComponentModel.DataAnnotations.Schema;

namespace EntityTest
{
    public class InternationalPassportInfo
    {
        public int Id { get; set; }
        public string InternationalPassportFirstName { get; set; } = null!;
        public string InternationalPassportLastName { get; set; } = null!;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int PassportInfoKey { get; set; }
        public PassportInfo PassportInfo { get; set; }
        //public ICollection<VisaInfo> Visas { get; set; }
        public ICollection<InternationalPassportInfoVisaInfo> InternationalPassportInfoVisaInfos { get; set; }
        public InternationalPassportInfo() 
        {
            //Visas = new HashSet<VisaInfo>();
            InternationalPassportInfoVisaInfos = new HashSet<InternationalPassportInfoVisaInfo>();
        }

    }
}
