using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lumex.Tech;
using Lumex.Project.DAL;

namespace Lumex.Project.BLL
{
    public class chequeInventoryBLL
    {
        public string folowType { get; set; }
        public string status { get; set; }
        public string branchId { get; set; }
        public string chequeSerial { get; set; }

        public DataTable getChequeInventory()
        {
            DataTable dt = new DataTable();
            chequeInventoryDAL chequeInventoryDal = new chequeInventoryDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt = chequeInventoryDal.getChequeInventoryList(db, this);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                chequeInventoryDal = null;
            }
        }

        public bool ChangeChequeStatus(string statusType)
        {
            bool status = false;
            chequeInventoryDAL chequeInventorydal = new chequeInventoryDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                status = chequeInventorydal.ChangeChequeStatus(db, this, statusType);
                db.Stop();
            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public bool ChangeChequeStatusForOutFlow(string statusType)
        {
            bool status = false;
            chequeInventoryDAL chequeInventorydal = new chequeInventoryDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                status = chequeInventorydal.ChangeChequeStatusForOutFlow(db, this, statusType);
                db.Stop();
            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public string Finaldate { get; set; }

        public string naration { get; set; }
    }
}
