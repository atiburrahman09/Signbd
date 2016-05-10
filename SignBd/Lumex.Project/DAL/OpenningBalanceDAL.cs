using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class OpenningBalanceDAL
    {
        internal System.Data.DataTable SaveOpenningBalance(BLL.OpenningBalanceBLL openningBalanceBLL, Tech.LumexDBPlayer db)
        {
            try
            {
                DataTable dt=new DataTable();
                if (openningBalanceBLL.PayToFromType == "ven")
                {
                    db.AddParameters("@WarehouseId", openningBalanceBLL.OfficeBranchId.Trim());
                    db.AddParameters("@PurchaseRequisitionId", "");
                    db.AddParameters("@PurchaseOrderId", "");
                    db.AddParameters("@VendorId", openningBalanceBLL.PayToFromCompany);
                    db.AddParameters("@VendorOrderDate", openningBalanceBLL.TransectionDate);
                    db.AddParameters("@VendorOrderNumber", "");
                    db.AddParameters("@VendorInvoiceNumber","");
                    db.AddParameters("@ReceivedDate", "");
                    db.AddParameters("@TotalAmount", openningBalanceBLL.Amount);
                    //db.AddParameters("@VAT", purchaseRecord.VAT.Trim());
                    db.AddParameters("@DiscountAmount", "0.00");

                  

                    if (openningBalanceBLL.Type == "Rec")
                    {
                        db.AddParameters("@TotalPayable", "0.00");
                        db.AddParameters("@PaidAmount", openningBalanceBLL.Amount);
                        db.AddParameters("@Narration", "Purchase Entry for Opening Balance Receivable Amount. "+openningBalanceBLL.Naretion);
                    }
                    else
                    {

                        db.AddParameters("@TotalPayable", openningBalanceBLL.Amount);
                        db.AddParameters("@PaidAmount", "0.00");
                        db.AddParameters("@Narration", "Purchase Entry for Opening Balance Payable Amount. "+ openningBalanceBLL.Naretion);
             
                    }


                    db.AddParameters("@TransportCost", "0.00");
                  
                    db.AddParameters("@LCNumber", "");
                    db.AddParameters("@TransportType", "");
                    db.AddParameters("@ShippingAddress", "");
                    db.AddParameters("@BillingAddress","");
                    db.AddParameters("@PaymentMode", "");
                    db.AddParameters("@AccountId", "A45");
                    db.AddParameters("@Bank", "");
                    db.AddParameters("@BankBranch", "");
                    db.AddParameters("@ChequeNumber", "");
                    db.AddParameters("@ChequeDate","");
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    dt = db.ExecuteDataTable("INSERT_WAREHOUSE_PURCHASE_RECORD_FOR_OPENING", true);

                }
                else if (openningBalanceBLL.PayToFromType == "cus")
                {

                    db.AddParameters("@CustomerId", openningBalanceBLL.PayToFromCompany.Trim());
                    db.AddParameters("@CustomerName", openningBalanceBLL.PayToFromCompanyName);
                    db.AddParameters("@CustomerContactNumber", "");
                    db.AddParameters("@CustomerAddress", "");
                    db.AddParameters("@SalesCenterId", openningBalanceBLL.OfficeBranchId);
                    db.AddParameters("@TotalAmount", openningBalanceBLL.Amount);
                    db.AddParameters("@DiscountAmount", "0.00");
                    db.AddParameters("@VAT", "0.00");
                    if (openningBalanceBLL.Type == "Rec")
                    {
                        db.AddParameters("@TotalReceivable", openningBalanceBLL.Amount);
                        db.AddParameters("@ReceivedAmount", "0.00");
                        db.AddParameters("@Narration", "Sales Entry for Opening Balance Receivable Amount. "+openningBalanceBLL.Naretion);
                    }
                    else
                    {

                        db.AddParameters("@TotalReceivable", "0.00");
                        db.AddParameters("@ReceivedAmount", openningBalanceBLL.Amount);
                        db.AddParameters("@Narration", "Sales Entry for Opening Balance Payable Amount. "+openningBalanceBLL.Naretion);
                    }


                    db.AddParameters("@ChangeAmount", "0.00");
                    db.AddParameters("@TotalVATAmount", "0.00");
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                    db.AddParameters("@SalesOrderId", "");

                    //New Add

                    db.AddParameters("@PaymentMode", "");
                    db.AddParameters("@AccountId", "A45");
                    db.AddParameters("@Bank", "");
                    db.AddParameters("@BankBranch", "");
                    db.AddParameters("@ChequeNumber", "");
                    db.AddParameters("@ChequeDate", "");
                    db.AddParameters("@OthersDes", "");
                    db.AddParameters("@OthersAmount", "0.00");

                    //
                    dt = db.ExecuteDataTable("[INSERT_RETAIL_SALES_RECORD_FOR_OPENING]", true);

                }
                //db.AddParameters("@AccountId",openningBalanceBLL.AccountId);
                //db.AddParameters("@Amount",openningBalanceBLL.Amount);
                //db.AddParameters("@OfficeBranchId", openningBalanceBLL.OfficeBranchId);
                //db.AddParameters("@DebitCredit",openningBalanceBLL.DebitOrCredit);
                //db.AddParameters("@PayToFromCompany",openningBalanceBLL.PayToFromCompany);
                //db.AddParameters("@Narration",openningBalanceBLL.Naretion);
                //db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                //db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                //db.AddParameters("@TransectionDate",openningBalanceBLL.TransectionDate);
                //db.AddParameters("@IsRecPay",openningBalanceBLL.Type);
                //DataTable dt = db.ExecuteDataTable("INSERT_OPANING_BALANCE_LEDGER_WISE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                openningBalanceBLL = null;
            }
        }
    }
}
