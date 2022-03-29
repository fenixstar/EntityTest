using System.ComponentModel.DataAnnotations.Schema;
namespace EntityTest
{
    public class NationalityInfo
    {
        public int NationalityID { get; set; }
        public string County { get; set; }
        public string Name { get;set; }
        public DateTime DateStart { get; set; }

    }
}
