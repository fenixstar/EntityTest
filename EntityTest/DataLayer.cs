using Library;
using Microsoft.EntityFrameworkCore;

namespace EntityTest
{
    public static class DataLayer
    {
        public static void EmulateData(ApplicationContext ctx)
        {
            NationalityInfo nationality = new NationalityInfo
            {
                County = "Russia",
                DateEnd = Convert.ToDateTime("20/02/2023").SetKindUtc(),
                DateStart = Convert.ToDateTime("23/07/1995").SetKindUtc(),
                Name = "Russian"
            };
            //-------anton
            PassportInfo anton = new PassportInfo
            {
                FirstName = "Anton",
                SecondName = "Gavrikov",
                NationalityInfos = nationality
            };
            InternationalPassportInfo aip = new InternationalPassportInfo
            {
                DateEnd = Convert.ToDateTime("22/02/2028").SetKindUtc(),
                DateStart = Convert.ToDateTime("22/02/2018").SetKindUtc(),
                InternationalPassportFirstName = "Anton",
                InternationalPassportLastName = "Gavrikov",
                PassportInfo = anton
            };
            VisaInfo avisa = new VisaInfo
            {
                VisaEnd = Convert.ToDateTime("22/02/2020").SetKindUtc(),
                VisaStart = Convert.ToDateTime("22/02/2019").SetKindUtc()
            };
            //--------elsa
            PassportInfo elsa = new PassportInfo
            {
                FirstName = "Elsa",
                SecondName = "Gavrikova",
                NationalityInfos = nationality
            };
            InternationalPassportInfo eip = new InternationalPassportInfo
            {
                DateEnd = Convert.ToDateTime("22/02/2023").SetKindUtc(),
                DateStart = Convert.ToDateTime("22/02/2018").SetKindUtc(),
                InternationalPassportFirstName = "Elsa",
                InternationalPassportLastName = "Gavrikova",
                PassportInfo = elsa
            };
            VisaInfo evisa = new VisaInfo
            {
                VisaEnd = Convert.ToDateTime("22/02/2021").SetKindUtc(),
                VisaStart = Convert.ToDateTime("22/02/2016").SetKindUtc()
            };
            //----------reference
            aip.InternationalPassportInfoVisaInfos.Add(new InternationalPassportInfoVisaInfo { InternationalPassportInfo = aip, VisaInfo = avisa });
            eip.InternationalPassportInfoVisaInfos.Add(new InternationalPassportInfoVisaInfo { InternationalPassportInfo = eip, VisaInfo = evisa });


            ctx.NationalityInfos.Add(nationality);
            ctx.Passports.AddRange(anton, elsa);
            ctx.InternationalPassportInfos.AddRange(aip, eip);
            ctx.VisaInfos.AddRange(avisa, evisa);
            ctx.SaveChanges();
        }

        public static IQueryable<PassportInfo> GetAllInternationalPassports(ApplicationContext ctx)
        {
            var Passports = ctx.Passports.Where(p => p.InternationalPassportInfo.InternationalPassportFirstName == "Anton");
            return Passports;
        }

        public static ICollection<InternationalPassportInfo> GetPassportsWithInterPasspotData(ApplicationContext ctx)
        {
            var data = ctx.InternationalPassportInfos
                .Include(p => p.InternationalPassportInfoVisaInfos)
                    .ThenInclude(ipv => ipv.VisaInfo)
               .ToList();
            return data;
        }
    }
}