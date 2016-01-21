﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Sales
{
    public partial class ApproveRetailSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = salesRecordIdForViewHiddenField.Value = LumexSessionManager.Get("SalesRecordIdForView").ToString().Trim();
                    GetSalesRecordById(salesRecordIdForViewHiddenField.Value.Trim());
                    GetSalesRecordProductListById(salesRecordIdForViewHiddenField.Value.Trim());
                    GetSalesRecordMainProductListById(salesRecordIdForViewHiddenField.Value);
                    GetAvailableProductListBySalesCenter();
                }

                if (salesRecordProductListGridView.Rows.Count > 0)
                {
                    salesRecordProductListGridView.UseAccessibleHeader = true;
                    salesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        private void GetSalesRecordMainProductListById(string salesRecordId)
        {
            try
            {
                SalesOrderBLL salesOrder = new SalesOrderBLL();

                try
                {
                    DataTable dt = salesOrder.GetSalesRecordMainProductListById(salesRecordId);

                    if (dt.Rows.Count > 0)
                    {
                        selectedProductListGridView.DataSource = dt;
                        selectedProductListGridView.DataBind();

                        if (selectedProductListGridView.Rows.Count > 0)
                        {
                            selectedProductListGridView.UseAccessibleHeader = true;
                            selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                    }
                    else
                    {
                       // msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
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
            catch (Exception)
            {

                //throw;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void removeLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
                int index = gvRow.RowIndex;

                string productId = selectedProductListGridView.Rows[index].Cells[0].Text.ToString();

                DataTable dt = new DataTable();
                DataRow dr = null;

                //dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("MainProductId"));
                dt.Columns.Add(new DataColumn("MainProductName"));
                dt.Columns.Add(new DataColumn("MainPUnit"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));


                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    //dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["MainProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["MainProductName"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["MainPUnit"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["RatePerUnit"] = selectedProductListGridView.Rows[i].Cells[5].Text.ToString();

                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    dr["Quantity"] = orderQuantityTextBox.Text.Trim();



                    dt.Rows.Add(dr);
                }

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    if (productListGridView.Rows[i].Cells[0].Text.ToString() == productId)
                    {
                        CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");
                        chkbx.Checked = false;

                        CheckBox allchkbx = (CheckBox)productListGridView.HeaderRow.FindControl("allCheckBox");
                        allchkbx.Checked = false;
                        if (checkedRowCountHiddenField.Value != "")
                        {
                            checkedRowCountHiddenField.Value =
                                (int.Parse(checkedRowCountHiddenField.Value) - 1).ToString();
                        }
                        break;
                    }
                }

                dt.Rows.RemoveAt(index);
                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();



                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;


                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void AddNewProductInList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            try
            {
                //dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("MainProductId"));
                dt.Columns.Add(new DataColumn("MainProductName"));
                dt.Columns.Add(new DataColumn("MainPUnit"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));


                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    //dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["MainProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["MainProductName"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["MainPUnit"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["RatePerUnit"] = selectedProductListGridView.Rows[i].Cells[5].Text.ToString();

                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    dr["Quantity"] = orderQuantityTextBox.Text.Trim();



                    dt.Rows.Add(dr);
                }

                //int previousRowcount = dt.Rows.Count;

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");

                    if (chkbx.Checked && !CheckAddedProduct(productListGridView.Rows[i].Cells[0].Text.ToString()))
                    {
                        dr = dt.NewRow();

                        //dr["Barcode"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["MainProductId"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["MainProductName"] = productListGridView.Rows[i].Cells[1].Text.ToString();
                        dr["MainPUnit"] = productListGridView.Rows[i].Cells[2].Text.ToString();
                        dr["RatePerUnit"] = productListGridView.Rows[i].Cells[5].Text.ToString();
                        dr["Quantity"] = "0";
                        dr["ProductName"] = "Others New Add";

                        dt.Rows.Add(dr);
                    }
                }

                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();


                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    // saveButton.Enabled = true;
                }
                else
                {
                    // saveButton.Enabled = false;
                    //  totalAmountTextBox.Text = "";
                    //totalReceivableTextBox.Text = "";
                    //  receivedAmountTextBox.Text = "";
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
                dt.Dispose();
                dr = null;
            }
        }
        protected bool CheckAddedProduct(string productBarcodeIdName)
        {
            bool status = false;

            try
            {
                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    if (selectedProductListGridView.Rows[i].Cells[0].Text.ToString() == productBarcodeIdName || selectedProductListGridView.Rows[i].Cells[1].Text.ToString() == productBarcodeIdName)
                    {
                        //TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");

                        //TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                        //orderQuantityTextBox.Text = (int.Parse(orderQuantityTextBox.Text) + 1).ToString();

                        //TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                        //amountTextBox.Text = (int.Parse(orderQuantityTextBox.Text) * decimal.Parse(ratePerUnitTextBox.Text)).ToString();

                        //amountTextBox.Text = (decimal.Parse(amountTextBox.Text) + (decimal.Parse(amountTextBox.Text) * decimal.Parse(selectedProductListGridView.Rows[i].Cells[6].Text.ToString())) / 100).ToString("0.00");

                        status = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

            return status;
        }
        protected void addSelectedProductButton_Click(object sender, EventArgs e)
        {
            AddNewProductInList();

        }
        protected void GetAvailableProductListBySalesCenter()
        {
            ProductBLL product = new ProductBLL();

            try
            {

                DataTable dt = new DataTable();
                product.WareHouseId = salesCenterIdLabel.Text;
               
                dt = product.GetMainProductsByWareHouseForSales();
                
                
                if (dt.Rows.Count > 0)
                {
                    productListGridView.DataSource = dt;
                    productListGridView.DataBind();
                }
                else
                {
                    productListGridView.DataSource = dt;
                    productListGridView.DataBind();

                }
                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }


                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Products are not available for the selected Sales Center!!!"; msgDetailLabel.Text = "";
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
                product = null;
            }
        }

        protected void GetSalesRecordById(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordById(salesRecordId);

                if (dt.Rows.Count > 0)
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
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    customerIdLabel.Text = dt.Rows[0]["CustomerId"].ToString();
                    customerNameLabel.Text = dt.Rows[0]["CustomerName"].ToString();
                    customerContactLabel.Text = dt.Rows[0]["CustomerContactNumber"].ToString();
                    customerAddressLabel.Text = dt.Rows[0]["CustomerAddress"].ToString();
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                    totalVATAmountLabel.Text = dt.Rows[0]["TotalVATAmount"].ToString();
                    receivedAmountLabel.Text = dt.Rows[0]["ReceivedAmount"].ToString();
                    discountAmountLabel.Text = dt.Rows[0]["DiscountAmount"].ToString();
                    vatPercentageLabel.Text = dt.Rows[0]["VATPercentage"].ToString();
                    totalReceivableLabel.Text = dt.Rows[0]["TotalReceivable"].ToString();
                    if (statusLabel.Text != "Pending")
                    {
                        btnAccept.Enabled = false;
                    }
                   
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

        protected void GetSalesRecordProductListById(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordProductListById(salesRecordId);

                if (dt.Rows.Count > 0)
                {
                    salesRecordProductListGridView.DataSource = dt;
                    salesRecordProductListGridView.DataBind();

                    if (salesRecordProductListGridView.Rows.Count > 0)
                    {
                        salesRecordProductListGridView.UseAccessibleHeader = true;
                        salesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
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

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {


                string msg = string.Empty;

                SalesOrderBLL salesOrder = new SalesOrderBLL();

                DataTable dt = new DataTable();
                DataRow dr = null;

                //dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("MainProductId"));
                dt.Columns.Add(new DataColumn("MainProductName"));
                dt.Columns.Add(new DataColumn("MainPUnit"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));


                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    //dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["MainProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["MainProductName"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["MainPUnit"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["RatePerUnit"] = selectedProductListGridView.Rows[i].Cells[5].Text.ToString();

                    TextBox orderQuantityTextBox =
                        (TextBox) selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    dr["Quantity"] = orderQuantityTextBox.Text.Trim();



                    dt.Rows.Add(dr);
                }

                if (totalAmountLabel.Text.Trim() == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Warning!!!";
                    msgDetailLabel.Text = "Total Amount field is required.";
                    return;
                }
                    //else if (vatLabel.Text.Trim() == "")
                    //{
                    //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "VAT field is required.";
                    //    return;
                    //}
                else if (totalReceivableLabel.Text.Trim() == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Warning!!!";
                    msgDetailLabel.Text = "Total Receivable field is required.";
                    return;
                }
                //if (string.IsNullOrEmpty(vatLabel.Text))
                //{
                //    vatLabel.Text = "0";
                //}

                salesOrder.SalesRecordId = salesRecordIdlavel.Text;
                salesOrder.RecordDate = recordDateLabel.Text;
                salesOrder.JournalNumber = journalVoucharLavel.Text;
               salesOrder.SalesCenterId = salesCenterIdLabel.Text;
               
             


                //if (dt.Rows.Count == selectedProductListGridView.Rows.Count)
                //{
                  
                    string salesRecordId = salesOrder.ApproveSalesRecordRetailSubproducs(dt);
                   // salesOrder.UpdateSalesOrderOnApproved(salesRecordId, salesOrder.SalesOrderId);

                    if (!string.IsNullOrEmpty(salesRecordId))
                    {

                        string message =
                            "Product's <span class='actionTopic'>Sales Recorded</span> Successfully with Sale ID: <span class='actionTopic'>" +
                            salesRecordId + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSalesList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                     
                    }
                    else
                    {
                        string message =
                            "Product's <span class='actionTopic'>Sales Recorded</span> Update Failed" +
                            salesRecordId + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSalesList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                //}
            }

            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += " --> " + ex.InnerException.Message;
                }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                //salesOrder = null;
                //dtPrdList = null;
            }
        }

        protected void ParentLevelMenuRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }

    }
}