using Library;
using Microsoft.EntityFrameworkCore;

namespace EntityTest
{
    public class BuisnessLogicLayer
    {
        public bool CreatePassport(string fn, string sn, int nation, ApplicationContext ctx)
        {
            var result = false;
            try
            {   
                PassportInfo info = new PassportInfo();
                info.FirstName = fn;
                info.SecondName = sn;
                info.NationalityInfos = ctx.NationalityInfos.Find(nation);
                ctx.Passports.Add(info);
                ctx.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool ChangeNameInPassport(string n,int ind, ApplicationContext ctx)
        {
            var result = false;
            try
            {
                PassportInfo info = ctx.Passports.Find(ind);
                info.FirstName = n;
                ctx.Passports.Update(info);
                ctx.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
