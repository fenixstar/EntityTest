using System.ComponentModel.DataAnnotations.Schema;

namespace EntityTest
{
    public class InternationalPassportInfo
    {
        public int InternationalPassportId { get; set; }
        public string InternationalPassportFirstName { get; set; } = null!;
        public string InternationalPassportLastName { get; set; } = null!;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

    }
}
