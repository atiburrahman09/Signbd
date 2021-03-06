﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Report.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Sales
{
    public partial class UpdateRetailSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = salesRecordIdForViewHiddenField.Value = LumexSessionManager.Get("SalesRecordIdForUpdate").ToString().Trim();
                    GetSalesRecordById(salesRecordIdForViewHiddenField.Value.Trim());
                    GetSalesRecordProductListById(salesRecordIdForViewHiddenField.Value.Trim());
                    GetOverallVATPercentage();
                    //GetSalesRecordMainProductListById(salesRecordIdForViewHiddenField.Value);
                    //GetAvailableProductListBySalesCenter();
                }

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
        protected void GetOverallVATPercentage()
        {
            ProductPriceBLL productPrice = new ProductPriceBLL();

            try
            {
                DataTable dt = productPrice.GetOverallProductVAT();

                vatTextBox.Text = dt.Rows[0][0].ToString();
                vatTextBox.ReadOnly = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                productPrice = null;
                MyAlertBox("MyOverlayStop();");
            }
        }
        protected void GetSalesRecordById(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordById(salesRecordId);
                decimal changeAmount = 0;


                if (dt.Rows.Count > 0 && dt.Rows[0]["Status"].ToString() == "Pending")
                {
                    journalVoucharLavel.Text = dt.Rows[0]["JournalNumber"].ToString();
                    paymentMethodLavel.Text = dt.Rows[0]["PaymentMode"].ToString();
                    banklabel.Text = dt.Rows[0]["Bank"].ToString();
                    bankBranchlabel.Text = dt.Rows[0]["BankBranch"].ToString();
                    ChequeNumberLavel.Text = dt.Rows[0]["ChequeNumber"].ToString();
                    ChequeDateLavel.Text = dt.Rows[0]["ChequeDate"].ToString();
                    salesRecordIdlavel.Text = dt.Rows[0]["SalesRecordId"].ToString();
                    recordDateLabel.Text = dt.Rows[0]["RecordDate"].ToString();
                    lblSalesPerson.Text = dt.Rows[0]["SalesPerson"].ToString();
                    //statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    customerIdLabel.Text = dt.Rows[0]["CustomerId"].ToString();
                    customerNameLabel.Text = dt.Rows[0]["CustomerName"].ToString();
                    customerContactLabel.Text = dt.Rows[0]["CustomerContactNumber"].ToString();
                    customerAddressLabel.Text = dt.Rows[0]["CustomerAddress"].ToString();
                    totalAmountTextBox.Text = dt.Rows[0]["TotalAmount"].ToString();
                    //vatTextBox.Text = dt.Rows[0]["TotalVATAmount"].ToString();
                    receivedAmountTextBox.Text = dt.Rows[0]["ReceivedAmount"].ToString();
                    discountTextBox.Text = dt.Rows[0]["DiscountAmount"].ToString();
                    vatTextBox.Text = dt.Rows[0]["VATPercentage"].ToString();
                    receivableAmountTextBox.Text = dt.Rows[0]["TotalReceivable"].ToString();
                    txtbxNarration.Text = dt.Rows[0]["Narration"].ToString();
                    txtbxDescription.Text = dt.Rows[0]["OthersDes"].ToString();
                    txtbxOthersAmount.Text = dt.Rows[0]["OthersAmount"].ToString();
                    changeAmountTextBox.Text =
                        (Convert.ToDecimal(dt.Rows[0]["ReceivedAmount"].ToString()) -
                         Convert.ToDecimal(dt.Rows[0]["TotalReceivable"].ToString())).ToString();
                    accountIdLabel.Text = dt.Rows[0]["AccountId"].ToString();



                }
                else
                {
                    LumexSessionManager.Remove("SalesRecordIdForUpdate");
                    Response.Redirect(Request.UrlReferrer.ToString());
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesOrder = null;
            }
        }

        protected void GetSalesRecordProductListById(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordProductListById(salesRecordId);

                if (dt.Rows.Count > 0)
                {
                    selectedProductListGridView.DataSource = dt;
                    selectedProductListGridView.DataBind();
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesOrder = null;
            }
        }
        //private void GetSalesRecordMainProductListById(string salesRecordId)
        //{
        //    try
        //    {
        //        SalesOrderBLL salesOrder = new SalesOrderBLL();

        //        try
        //        {
        //            DataTable dt = salesOrder.GetSalesRecordMainProductListById(salesRecordId);

        //            if (dt.Rows.Count > 0)
        //            {
        //                selectedProductListGridView.DataSource = dt;
        //                selectedProductListGridView.DataBind();

        //                if (selectedProductListGridView.Rows.Count > 0)
        //                {
        //                    selectedProductListGridView.UseAccessibleHeader = true;
        //                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //                }
        //            }
        //            else
        //            {
        //                // msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //        }
        //        finally
        //        {
        //            salesOrder = null;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        //throw;
        //    }
        //}
        //protected void GetAvailableProductListBySalesCenter()
        //{
        //    ProductBLL product = new ProductBLL();

        //    try
        //    {

        //        DataTable dt = new DataTable();
        //        product.WareHouseId = salesCenterIdLabel.Text;

        //        dt = product.GetMainProductsByWareHouseForSales();


        //        if (dt.Rows.Count > 0)
        //        {
        //            productListGridView.DataSource = dt;
        //            productListGridView.DataBind();
        //        }
        //        else
        //        {
        //            productListGridView.DataSource = dt;
        //            productListGridView.DataBind();

        //        }
        //        if (productListGridView.Rows.Count > 0)
        //        {
        //            productListGridView.UseAccessibleHeader = true;
        //            productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }


        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Products are not available for the selected Sales Center!!!"; msgDetailLabel.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        product = null;
        //    }
        //}
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            string msg = string.Empty;

            SalesOrderBLL salesOrder = new SalesOrderBLL();
            DataTable dtPrdList = new DataTable();
            DataRow dr = null;
            decimal quantity = 0;
            double rate = 0;
            double amount = 0;
            TextBox orderQuantityTextBox;
            TextBox ratePerUnitTextBox;
            TextBox amountTextBox;
            TextBox heighTextBox;
            TextBox widthTextBox;
            TextBox UnitTextBox;
            TextBox totalUnitTextBox;
            Label vatLabel;
            Label SerialLabel;
            int i = 0;

            dtPrdList.Columns.Add(new DataColumn("ProductId"));
            dtPrdList.Columns.Add(new DataColumn("Height"));
            dtPrdList.Columns.Add(new DataColumn("Width"));
            dtPrdList.Columns.Add(new DataColumn("OrderUnit"));
            dtPrdList.Columns.Add(new DataColumn("TotalUnit"));
            dtPrdList.Columns.Add(new DataColumn("OrderQuantity"));
            dtPrdList.Columns.Add(new DataColumn("Quantity"));
            dtPrdList.Columns.Add(new DataColumn("RatePerUnit"));
            dtPrdList.Columns.Add(new DataColumn("VATPercentage"));
            dtPrdList.Columns.Add(new DataColumn("Amount"));
            dtPrdList.Columns.Add(new DataColumn("Serial"));



            try
            {
                for (i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    //double availAbleQuantity = Convert.ToDouble(selectedProductListGridView.Rows[i].Cells[3].Text.ToString());
                    heighTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("heightTextBox");
                    widthTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("WidthTextBox");
                    UnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("UnitTextBox");
                    totalUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                    orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    vatLabel = (Label)selectedProductListGridView.Rows[i].FindControl("lblVatparcentage");
                    SerialLabel = (Label)selectedProductListGridView.Rows[i].FindControl("SerialLabel");
                    if (string.IsNullOrEmpty(orderQuantityTextBox.Text.Trim()) || !decimal.TryParse(orderQuantityTextBox.Text.Trim(), out quantity))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid quantity.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (string.IsNullOrEmpty(ratePerUnitTextBox.Text.Trim()) || !double.TryParse(ratePerUnitTextBox.Text.Trim(), out rate))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid rate.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (string.IsNullOrEmpty(amountTextBox.Text.Trim()) || !double.TryParse(amountTextBox.Text.Trim(), out amount))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid amount.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    //else if (Convert.ToDouble(orderQuantityTextBox.Text) > availAbleQuantity)
                    //{
                    //    msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Availability.";
                    //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                    //    return;
                    //}
                    else
                    {
                        dr = dtPrdList.NewRow();

                        dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                        // dr["Available"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                        dr["Height"] = heighTextBox.Text;
                        dr["Width"] = widthTextBox.Text;
                        dr["OrderUnit"] = UnitTextBox.Text;
                        dr["TotalUnit"] = totalUnitTextBox.Text;
                        dr["Quantity"] = quantity.ToString();
                        dr["RatePerUnit"] = rate.ToString();
                        dr["VATPercentage"] = vatLabel.Text; //selectedProductListGridView.Rows[i].Cells[8].Text.ToString();
                        dr["Amount"] = amount.ToString();
                        dr["Serial"] = SerialLabel.Text;

                        dtPrdList.Rows.Add(dr);
                    }
                }

                salesOrder.SalesRecordId = idLabel.Text.Trim();
                salesOrder.JournalNumber = journalVoucharLavel.Text;
                salesOrder.SalesCenterId = salesCenterIdLabel.Text.Trim();
               // salesOrder.CustomerId = customerIdLabel.Text.Trim();
               // salesOrder.CustomerName = customerNameLabel.Text.Trim();
               // salesOrder.CustomerContactNumber = customerContactLabel.Text.Trim();
                //salesOrder.CustomerAddress = customerAddressLabel.Text.Trim();
                salesOrder.TotalAmount = totalAmountTextBox.Text.Trim();
                salesOrder.DiscountAmount = discountTextBox.Text.Trim();
                salesOrder.VAT = vatTextBox.Text.Trim();
                salesOrder.TotalReceivable = receivableAmountTextBox.Text.Trim();
              //  salesOrder.Due = "0";//DuesAmoutPayTextBox.Text;
                //salesOrder.SalesOrderId = "";
                salesOrder.ReceivedAmount = receivedAmountTextBox.Text.Trim();
                salesOrder.ChangeAmount = (Convert.ToDecimal(salesOrder.ReceivedAmount) - Convert.ToDecimal(salesOrder.TotalReceivable)).ToString();
                // salesOrder.TotalVATAmount = ;

               // salesOrder.AccountId = accountIdLabel.Text;
                //salesOrder.CustomerId = customerIdDropDownList.SelectedValue.Trim();
               // salesOrder.PaymentMode = paymentMethodLavel.Text.Trim();
                // receivePayment.Amount = receivedAmountTextBox.Text.Trim();
               // salesOrder.Bank = banklabel.Text.Trim();
               // salesOrder.BankBranch = bankBranchlabel.Text.Trim();
              //  salesOrder.ChequeNumber = ChequeNumberLavel.Text.Trim();
              //  salesOrder.ChequeDate = LumexLibraryManager.ParseAppDate(ChequeDateLavel.Text);
                salesOrder.OthersDes = txtbxDescription.Text;
                salesOrder.OthersAmount = txtbxOthersAmount.Text.Trim();
                salesOrder.Narration = txtbxNarration.Text;
                

                if (dtPrdList.Rows.Count == selectedProductListGridView.Rows.Count)
                {
                    string salesRecordId = salesOrder.UpdateRetailSales(dtPrdList);
                    if (salesRecordId != "")
                    {
                        //IPOSReportBLL iposReport = new IPOSReportBLL();
                        //iposReport.GetSalesInvoiceBySalesRecord(salesRecordId, salesOrder.SalesCenterId);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                        string message = "Product's <span class='actionTopic'>Sales</span> Successfully Updated in Sale ID: <span class='actionTopic'>" +
                        salesRecordId + "</span>.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSalesList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }

                    else
                    {
                        string message = "Product's <span class='actionTopic'>Sales</span>Update Falied" +
                        salesRecordId + "</span>.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSalesList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }

        protected void btnReject_OnClick(object sender, EventArgs e)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();
            try
            {
                
                bool status = false;
                salesOrder.SalesRecordId = idLabel.Text.Trim();
                salesOrder.SalesCenterId = salesCenterIdLabel.Text.Trim();

                status = salesOrder.RejectRetailSales();
                if (status)
                {
                    string message = "Product's <span class='actionTopic'>Sales</span> Successfully Rejected By ID: <span class='actionTopic'>" +
                        salesOrder.SalesRecordId + "</span>.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSalesList.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                }
                else
                {
                    string message = "Product's <span class='actionTopic'>Sales</span>Rejection Falied" +
                    salesOrder.SalesRecordId + "</span>.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSalesList.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
            finally
            {
                salesOrder = null;
                
            }
        }
    }
}