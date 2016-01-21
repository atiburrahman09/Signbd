using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class chequeInventoryDAL
    {
        public DataTable getChequeInventoryList(LumexDBPlayer db, chequeInventoryBLL chequeInventoryBLL)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@IsInflow", chequeInventoryBLL.folowType.Trim());
                db.AddParameters("@ChequeStatus", chequeInventoryBLL.status.Trim());
                db.AddParameters("@BranchId", chequeInventoryBLL.branchId.Trim());

                dt = db.ExecuteDataTable("GET_CHEQUE_INVENTORY_BY_FLOWSTATUS_Cheque_Status", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool ChangeChequeStatus(LumexDBPlayer db, chequeInventoryBLL chequeInventoryBLL, string statusType)
        {
            bool status = false;
            try
            {
                db.AddParameters("@Serial",chequeInventoryBLL.chequeSerial.Trim());
                db.AddParameters("@CreatedBy",LumexSessionManager.Get("ActiveUserId").ToString().Trim());
                db.AddParameters("@CreatedFrom",LumexLibraryManager.GetTerminal());
                db.AddParameters("@Trandate",chequeInventoryBLL.Finaldate.Trim());
                db.AddParameters("@Naration", chequeInventoryBLL.naration.Trim());
                if (statusType == "R")
                {
                    status = Convert.ToBoolean(db.ExecuteNonQuery("UPDATE_CHEQUE_INVENTORY_WHEN_REJECT", true));
                }
                if (statusType == "A")
                {
                    status = Convert.ToBoolean(db.ExecuteNonQuery("UPDATE_CHEQUE_INVENTORY_WHEN_APPROVE", true));
                }
                if (statusType == "AC")
                {
                    status = Convert.ToBoolean(db.ExecuteNonQuery("UPDATE_CHEQUE_INVENTORY_WHEN_APPROVE_BY_CASH", true));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        internal bool ChangeChequeStatusForOutFlow(LumexDBPlayer db, chequeInventoryBLL chequeInventoryBLL, string statusType)
        {
            bool status = false;
            try
            {
                db.AddParameters("@Serial", chequeInventoryBLL.chequeSerial.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString().Trim());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@Trandate",chequeInventoryBLL.Finaldate.Trim());
                db.AddParameters("@Naration", chequeInventoryBLL.naration.Trim());
                if (statusType == "R")
                {
                    status = Convert.ToBoolean(db.ExecuteNonQuery("UPDATE_CHEQUE_INVENTORY_WHEN_REJECT", true));
                }
                if (statusType == "A")
                {
                    status = Convert.ToBoolean(db.ExecuteNonQuery("[UPDATE_CHEQUE_INVENTORY_FOR_OUT_WHEN_APPROVE]", true));
                }
                if (statusType == "AC")
                {
                    status = Convert.ToBoolean(db.ExecuteNonQuery("[UPDATE_CHEQUE_INVENTORY_FOR_OUT_WHEN_APPROVE_BY_CASH]", true));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
