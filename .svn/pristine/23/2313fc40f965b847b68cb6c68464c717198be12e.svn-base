using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using Lumex.Tech;

namespace Lumex.Report.DAL
{
    public class IPOSReportDAL
    {
        string reportPath = HttpContext.Current.Server.MapPath("/RptFiles/");
        string imagePath = HttpContext.Current.Server.MapPath("/content/images/");

        public ReportDocument GetCustomerReceivableListById(string customerId, string SalesCenterId, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Customer_Receiable_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@CustomerId", customerId.Trim());
                db.AddParameters("@SalesCenterId", SalesCenterId);


                reportDocument.Load(reportPath + "REPORT_GET_CUSTOMER_RECEIVABLE_LIST_BY_ID.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_CUSTOMER_RECEIVABLE_LIST_BY_ID", true);
                reportDocument.SetDataSource(dt);


                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetAvailableProductBySaclesCenterId(string SalesCenterId, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Avaiable_Product_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@Rtype", "S");

                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetAvailableProductBySaclesCenterIdPRWise(string SalesCenterId, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Avaiable_Product_PR_wise_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@Rtype", "S");

                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetPurchaseRecordbySC_Date_RANGE_STATUS(string SalesCenterId, string ToDate, string FromDate, string PrStatus, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Purchase_Record_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                db.AddParameters("@Status", PrStatus.Trim());
                if (SalesCenterId.Substring(0, 1) == "S")
                {
                    db.AddParameters("Type", "S");
                }
                else
                {
                    db.AddParameters("Type", "W");
                }

                reportDocument.Load(reportPath + "REPORT_GET_PURCHASE_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_PURCHASE_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetSalesRecordbySC_Date_RANGE_STATUS(string SalesCenterId, string ToDate, string FromDate, string SRStatus, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Sales_Record_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                db.AddParameters("@Status", SRStatus.Trim());

                reportDocument.Load(reportPath + "REPORT_GET_SALES_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_SALES_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetBalance_Sheet_Report_by_Date(string ReportType, string SCWHId, string Date, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Balance_Sheet_Report");

                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@TransactionDate", LumexLibraryManager.ParseAppDate(Date.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_BALANCE_SHEET_BY_DATE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_BALANCE_SHEET_BY_DATE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetFinancial_Ladger_Report_by_Date_and_AccountId(string ReportType, string SCWHId, string accountId, string toDate, string FromDate, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Financial_Ledger_Report");

                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@AccountId", accountId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(toDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_FINANCIAL_LEDGER_BY_DATE_RANGE_AND_ACCOUNT.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_FINANCIAL_LEDGER_BY_DATE_RANGE_AND_ACCOUNT", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetGeneral_ledger_Sheet_Report_by_Date(string ReportType, string SCWHId, string toDate, string FromDate, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "General_Ledger_Report");

                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(toDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_GENERAL_LEDGER_BY_DATE_RANGE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_GENERAL_LEDGER_BY_DATE_RANGE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object Get_Income_Statement_by_Date(string ReportType, string SCWHId, string toDate, string fromDate, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Income_Statement_Report");

                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(fromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(toDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_INCOME_STATEMENT_BY_DATE_RANGE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_INCOME_STATEMENT_BY_DATE_RANGE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object Get_Trial_Balance_by_Date(string ReportType, string SCWHId, string FromDate, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Trile_Balance_Report");

                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                //db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_TRIAL_BALANCE_BY_DATE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_TRIAL_BALANCE_BY_DATE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetCustomerReceivePaymentList(string SalesCenter, string CustomerId, string FromDate, string ToDate, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Customer_wise_receive_payment_Report");

                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@SalesCenterId", SalesCenter);
                db.AddParameters("@CustomerId", CustomerId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_CUSTOMER_RECEIVE_PAYMENT.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_CUSTOMER_WISE_RECEIVE_PAYMENT_LIST", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal object GetAvailableProductByWarehouseId(string WarehouseId, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Avaiable_Product_SC_wise_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", WarehouseId.Trim());
                db.AddParameters("@Rtype", "W");
                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetAvailableProductByWarehouseIdPRWise(string WarehouseId, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Avaiable_Product_PR_wise_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", WarehouseId.Trim());
                db.AddParameters("@Rtype", "W");

                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetSalesCenterVendorReceivePaymentList(string SalesCenterId, string VendorId, string FromDate, string ToDate, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Vendor_Receive_Payment_Report");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@VendorId", VendorId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                //db.AddParameters("@Status", status);
                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                //db.AddParameters("@Rtype", "S");

                reportDocument.Load(reportPath + "Report_Vendor_Wise_Payment.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_VENDOR_WISE_RECEIVE_PAYMENT_LIST", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal object GetWarehouseVendorReceivePaymentList(string SalesCenterId, string VendorId, string FromDate, string ToDate, string status, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Vendor_wise_Payment_Report");
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@VendorId", VendorId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                db.AddParameters("@Status", status);
                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@Rtype", "W");

                reportDocument.Load(reportPath + "REPORT_GET_VENDOR_WISE_RECEIVE_PAYMENT_LIST.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_VENDOR_WISE_RECEIVE_PAYMENT_LIST", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal object GetSalesInvoiceBySalesRecord(string salesRecordId, string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Sales_Invoice_Report");
                ReportDocument reportDocument = new ReportDocument();
                DataTable dt = new DataTable();
                db.AddParameters("@SalesRecordId ", salesRecordId);
                db.AddParameters("@WHID", salesCenterId);
                //db.AddParameters("@TransactionDate", LumexLibraryManager.ParseAppDate(Date.Trim()));
                if (salesCenterId == "WH-003")
                {
                    reportDocument.Load(reportPath + "Report_Sales_Invoice.rpt");
                    //reportDocument.Load(reportPath + "Report_Sales_Invoice-SignCorp.rpt");
                    dt = db.ExecuteDataTable("REPORT_GET_SALES_INVOICE_BY_ID", true);
                    reportDocument.SetDataSource(dt);
                    reportDocument.DataDefinition.FormulaFields["Location"].Text = (imagePath + "noimage.png");
                }
                else if (salesCenterId == "WH-001")
                {
                    reportDocument.Load(reportPath + "Report_Sales_Invoice.rpt");
                    dt = db.ExecuteDataTable("REPORT_GET_SALES_INVOICE_BY_ID", true);
                    reportDocument.SetDataSource(dt);
                    reportDocument.DataDefinition.FormulaFields["Location"].Text = (imagePath + "SignMedia.jpg");
                }
                else
                {
                    reportDocument.Load(reportPath + "Report_Sales_Invoice.rpt");

                    // reportDocument.Load(reportPath + "Report_Sales_Invoice-SignTrade.rpt");
                    dt = db.ExecuteDataTable("REPORT_GET_SALES_INVOICE_BY_ID", true);
                    reportDocument.SetDataSource(dt);
                    string path = imagePath + "SignTrade.jpg";
                    reportDocument.DataDefinition.FormulaFields["Location"].Text = (path);

                }

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetReceivePaymentVaucharbyVendororCustomer(string JournalNo, string vendorId, string WHSCId, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "Money_Receipt");
                DataRow dr = null;
                DataTable dataTable = new DataTable();
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@VendorId", vendorId);
                db.AddParameters("@JounalNo ", JournalNo);
                db.AddParameters("@SalesCenterId", WHSCId);


                if (WHSCId == "WH-001")
                {
                    reportDocument.Load(reportPath + "Report_Money_Receipt_SignMedia.rpt");

                }
                else if (WHSCId == "WH-002")
                {
                    reportDocument.Load(reportPath + "Report_Money_Receipt_SignTrade.rpt");

                }
                else
                {
                    reportDocument.Load(reportPath + "Report_Money_Receipt_SignCorp.rpt");

                }

                DataTable dt = db.ExecuteDataTable("[REPORT_GETRECEIVE_PAYMENT_VAUCHAR_BY_JOURNAL]", true);

                reportDocument.SetDataSource(dt);
                //reportDocument.PrintOptions.PrinterName = "Default Printer Name";
                // reportDocument.PrintToPrinter(1, false, 0, 0); 




                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DisplayImages(DataRow row, string img, string ImagePath)
        {


            FileStream stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);

            byte[] ImgData = new byte[stream.Length];

            stream.Read(ImgData, 0, Convert.ToInt32(stream.Length));

            stream.Close();

            row[img] = ImgData;

        }


        internal object GetCreditOrDebitVoucherByVoucherId(string voucherId, string salesCenterId, string cmdarg, LumexDBPlayer db)
        {
            LumexSessionManager.Add("rptName", "Devit_Credit_Vouchar");
            DataRow dr = null;
            DataTable dataTable = new DataTable();
            ReportDocument reportDocument = new ReportDocument();

            db.AddParameters("@JounalNo", voucherId);
            db.AddParameters("@CallFrom", cmdarg);
            db.AddParameters("@SalesCenterId", salesCenterId);
            reportDocument.Load(reportPath + "Voucher.rpt");
            DataTable dt = db.ExecuteDataTable("[REPORT_GET_VAUCHAR_BY_JOURNAL]", true);
            reportDocument.SetDataSource(dt);

            return reportDocument;
        }

        internal object GetSalesCenterCustomerDueAmountList(string SalesCenterId, LumexDBPlayer db)
        {
            LumexSessionManager.Add("rptName", "Customer_Receivable_Amount");
            ReportDocument reportDocument = new ReportDocument();


            db.AddParameters("@SalesCenterId", SalesCenterId);
            reportDocument.Load(reportPath + "REPORT_GET_CUSTOMER_DUE_AMOUNT_LIST.rpt");
            DataTable dt = db.ExecuteDataTable("[REPORT_GET_Customer_Due_Amount]", true);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[i];
            //    if (Convert.ToDecimal(dt.Rows[i]["DueAmount"].ToString()) == 0)
            //        dr.Delete();
            //}



            reportDocument.SetDataSource(dt);

            return reportDocument;
        }

        internal object GetSalesCenterVendorDueAmountList(string SalesCenterId, LumexDBPlayer db)
        {
            LumexSessionManager.Add("rptName", "Vendor_Payable_List");
            ReportDocument reportDocument = new ReportDocument();


            db.AddParameters("@SalesCenterId", SalesCenterId);
            reportDocument.Load(reportPath + "REPORT_GET_VENDOR_DUE_AMOUNT_LIST.rpt");
            DataTable dt = db.ExecuteDataTable("[REPORT_GET_Vendor_Due_Amount]", true);
            reportDocument.SetDataSource(dt);

            return reportDocument;
        }

        internal object GetProductSalesRecordListByProductId(string ProductId, string FromDate,string ToDate, LumexDBPlayer db)
        {
            try
            {
                LumexSessionManager.Add("rptName", "PRODUCT_WISE_SALES_RECORD_LIST");

                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@ProductId", ProductId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));


                reportDocument.Load(reportPath + "PRODUCT_WISE_SALES_RECORD_LIST.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_PRODUCT_WISE_SALES_RECORD_LIST_BY_PRODUCT_ID", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
