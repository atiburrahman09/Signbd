using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class CompanyBLL
    {
        public System.Data.DataTable GetActiveCompany()
        {
           CompanyDAL companyDal=new CompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = companyDal.GetActiveCompany(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                companyDal = null;
            }
        }
    }
}
