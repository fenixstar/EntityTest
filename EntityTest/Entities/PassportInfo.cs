namespace EntityTest
{
    public class PassportInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public InternationalPassportInfo? InternationalPassportInfo { get; set; }
        public NationalityInfo NationalityInfos { get; set; }
    }
}
