using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class OpenningBalanceBLL
    {
        public decimal Amount { get; set; }
       
        public string AccountId { get; set; }
        public string Naretion { get; set; }
        public string PayToFromType { get; set; }

        public string PayToFromCompany { get; set; }
        public decimal TotalTransiction { get; set; }
        public string DebitOrCredit { get; set; }
        public string Type { get; set; }

        public System.Data.DataTable SaveOpenningBalance()
        {
            OpenningBalanceDAL openningBalanceDal=new OpenningBalanceDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = openningBalanceDal.SaveOpenningBalance(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                openningBalanceDal = null;
            }
        }

        public string OfficeBranchId { get; set; }

        public string TransectionDate { get; set; }

        public string PayToFromCompanyName { get; set; }
    }
}
