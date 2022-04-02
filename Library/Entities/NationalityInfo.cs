using System.ComponentModel.DataAnnotations.Schema;
namespace Library
{
    public class NationalityInfo
    {
        public int Id { get; set; }
        public string County { get; set; }
        public string Name { get;set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ICollection<PassportInfo> Passport { get; set; }
        public NationalityInfo() 
        { 
            Passport = new HashSet<PassportInfo>(); 
        }

    }
}
