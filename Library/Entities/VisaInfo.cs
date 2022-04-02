namespace Library
{
    public  class VisaInfo
    {
        public int Id { get; set; }        

        public DateTime VisaStart { get; set; }

        public DateTime VisaEnd { get; set; }

        //public ICollection<InternationalPassportInfo> InternationalPassportInfo { get; set; }
        public ICollection<InternationalPassportInfoVisaInfo> InternationalPassportInfoVisaInfos { get; set; }

        public VisaInfo()
        {
            //InternationalPassportInfo = new HashSet<InternationalPassportInfo>();
            InternationalPassportInfoVisaInfos = new HashSet<InternationalPassportInfoVisaInfo>();
        }

    }
}
