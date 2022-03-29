namespace EntityTest
{
    public class PassportInfo
    {
        public int PassportId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public InternationalPassportInfo internationalPassportInfo { get; set; }
        public NationalityInfo nationalityInfo { get; set; }
    }
}
