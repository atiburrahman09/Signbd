using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lumex.Project.DAL
{
    public class CompanyDAL
    {
        internal System.Data.DataTable GetActiveCompany(Tech.LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_COMPANY_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
