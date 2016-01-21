﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesReturn
{
    public partial class CreateSalesReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    salesRecordIdTextBox.Focus();
                }

                if (salesRecordProductListGridView.Rows.Count > 0)
                {
                    salesRecordProductListGridView.UseAccessibleHeader = true;
                    salesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                string message = "Some things goes wrong on create Sales Return";
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(  \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetSalesRecordById(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordById(salesRecordId);

                if (dt.Rows.Count > 0)
                {
                    recordDateLabel.Text = dt.Rows[0]["RecordDate"].ToString();
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

                    salesDueAmountTextBox.Text = (decimal.Parse(totalReceivableLabel.Text) - decimal.Parse(receivedAmountLabel.Text)).ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = "Some things goes wrong on create Sales Return";
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(  \"" + message + "\", \"\");");
            }
            finally
            {
                salesOrder = null;
            }
        }

        protected void GetSalesRecordProductListByIdForReturn(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordProductListByIdForReturn(salesRecordId);

                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("ReturnQuantity");
                    dt.Columns.Add("ReturnAmount");
                    dt.AcceptChanges();

                    salesRecordProductListGridView.DataSource = dt;
                    salesRecordProductListGridView.DataBind();

                    LumexSessionManager.Add("RPLdt", dt);

                    for (int i = 0; i < salesRecordProductListGridView.Rows.Count; i++)
                    {
                        if (salesRecordProductListGridView.Rows[i].Cells[2].Text.Trim() == salesRecordProductListGridView.Rows[i].Cells[6].Text.Trim())
                        {
                            TextBox returnQuantityTextBox = (TextBox)salesRecordProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
                            returnQuantityTextBox.Enabled = false;
                        }
                    }

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
                string message = "Some things goes wrong on create Sales Return";
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(  \"" + message + "\", \"\");");
            }
            finally
            {
                salesOrder = null;
            }
        }

        protected void getSalesDetailsButton_Click(object sender, EventArgs e)
        {
            recordDateLabel.Text = "";
            statusLabel.Text = "";
            salesCenterIdLabel.Text = "";
            salesCenterNameLabel.Text = "";
            customerIdLabel.Text = "";
            customerNameLabel.Text = "";
            customerContactLabel.Text = "";
            customerAddressLabel.Text = "";
            totalAmountLabel.Text = "";
            totalVATAmountLabel.Text = "";
            receivedAmountLabel.Text = "";
            discountAmountLabel.Text = "";
            vatPercentageLabel.Text = "";
            totalReceivableLabel.Text = "";

            salesDueAmountTextBox.Text = "0";
            totalReturnAmountTextBox.Text = "0";
            totalReturnVATAmountTextBox.Text = "0";

            salesRecordProductListGridView.DataSource = null;
            salesRecordProductListGridView.DataBind();

            idLabel.Text = salesRecordIdForViewHiddenField.Value = salesRecordIdTextBox.Text.Trim();
            GetSalesRecordById(salesRecordIdForViewHiddenField.Value.Trim());
            GetSalesRecordProductListByIdForReturn(salesRecordIdForViewHiddenField.Value.Trim());
        }

        protected void addProductButton_Click(object sender, EventArgs e)
        {
            if (salesRecordProductListGridView.Rows.Count > 0)
            {
                decimal amount = 0;
                string productBarcodeIdName = productTextBox.Text.Trim();
                DataTable dt = (DataTable)LumexSessionManager.Get("RPLdt");

                for (int i = 0; i < salesRecordProductListGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (salesRecordProductListGridView.Rows[i].Cells[0].Text.Trim() == dt.Rows[j]["ProductId"].ToString())
                        {
                            TextBox returnQuantityTextBox = (TextBox)salesRecordProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
                            dt.Rows[j]["ReturnQuantity"] = returnQuantityTextBox.Text;

                            TextBox returnAmountTextBox = (TextBox)salesRecordProductListGridView.Rows[i].FindControl("returnAmountTextBox");
                            dt.Rows[j]["ReturnAmount"] = returnAmountTextBox.Text;
                        }
                    }
                }
                dt.AcceptChanges();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["Barcode"].ToString() == productBarcodeIdName ||
                        dt.Rows[j]["ProductId"].ToString() == productBarcodeIdName ||
                        dt.Rows[j]["ProductName"].ToString() == productBarcodeIdName)
                    {
                        decimal qty = decimal.Parse(dt.Rows[j]["Quantity"].ToString());
                        decimal rate = decimal.Parse(dt.Rows[j]["RatePerUnit"].ToString());
                        decimal rqty = decimal.Parse(dt.Rows[j]["ReturnQuantity"].ToString()) + 1;
                        decimal vat = decimal.Parse(dt.Rows[j]["VATPercentage"].ToString());
                        decimal amt = rqty * rate;
                        amt = amt + ((amt * vat) / 100);

                        if (rqty > qty)
                        {
                            return;
                        }

                        dt.Rows[j]["ReturnQuantity"] = rqty.ToString();
                        dt.Rows[j]["ReturnAmount"] = amt.ToString();
                    }
                }

                salesRecordProductListGridView.DataSource = dt;
                salesRecordProductListGridView.DataBind();

                if (salesRecordProductListGridView.Rows.Count > 0)
                {
                    salesRecordProductListGridView.UseAccessibleHeader = true;
                    salesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                for (int i = 0; i < salesRecordProductListGridView.Rows.Count; i++)
                {
                    TextBox returnQuantityTextBox =
                        (TextBox)salesRecordProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
                    returnQuantityTextBox.Text = dt.Rows[i]["ReturnQuantity"].ToString();

                    TextBox returnAmountTextBox =
                        (TextBox)salesRecordProductListGridView.Rows[i].FindControl("returnAmountTextBox");
                    returnAmountTextBox.Text = dt.Rows[i]["ReturnAmount"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[i]["ReturnAmount"].ToString()))
                    {
                        amount += decimal.Parse(dt.Rows[i]["ReturnAmount"].ToString());
                    }
                }

                decimal perUnitDiscount = decimal.Parse(discountAmountLabel.Text) / decimal.Parse(totalAmountLabel.Text);
                decimal tAmt = amount - amount * perUnitDiscount;
                decimal totalVAT = (tAmt * decimal.Parse(vatPercentageLabel.Text)) / 100;
                tAmt = tAmt + totalVAT;

                totalReturnVATAmountTextBox.Text = totalVAT.ToString();
                totalReturnAmountTextBox.Text = tAmt.ToString();
                dt.AcceptChanges();
                LumexSessionManager.Add("RPLdt", dt);

                productTextBox.Text = "";
            }
        }

        protected void receiveSalesReturnButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            SaveSalesReturn(btn.CommandArgument.ToString());
        }

        protected void SaveSalesReturn(string isDuesAdjust)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                if (Convert.ToDecimal(totalReturnAmountTextBox.Text) > 0)
                {
                    DataTable dtPrdList = (DataTable) LumexSessionManager.Get("RPLdt");

                    for (int i = 0; i < salesRecordProductListGridView.Rows.Count; i++)
                    {
                        TextBox returnQuantityTextBox =
                            (TextBox) salesRecordProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
                        dtPrdList.Rows[i]["ReturnQuantity"] = returnQuantityTextBox.Text.Trim();

                        TextBox returnAmountTextBox =
                            (TextBox) salesRecordProductListGridView.Rows[i].FindControl("returnAmountTextBox");
                        dtPrdList.Rows[i]["ReturnAmount"] = returnAmountTextBox.Text.Trim();
                    }
                    dtPrdList.AcceptChanges();
                    for (int i = 0; i < dtPrdList.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dtPrdList.Rows[i]["ReturnQuantity"].ToString()) ||
                            dtPrdList.Rows[i]["ReturnQuantity"].ToString() == "0")
                        {
                            dtPrdList.Rows.RemoveAt(i);
                            i--;
                        }
                    }

                    salesOrder.SalesRecordId = salesRecordIdTextBox.Text.Trim();
                    salesOrder.SalesCenterId = salesCenterIdLabel.Text.Trim();
                    salesOrder.ReturnAmount = totalReturnAmountTextBox.Text.Trim();
                    salesOrder.ReturnVATAmount = totalReturnVATAmountTextBox.Text.Trim();
                    salesOrder.SalesDueAmount = salesDueAmountTextBox.Text.Trim();
                    salesOrder.CustomerId = customerIdLabel.Text.Trim();
                    salesOrder.IsDuesAdjustforSalesReturn = isDuesAdjust;

                    DataTable dt = salesOrder.SaveSalesReturn(dtPrdList);

                    if (isDuesAdjust == "Y")
                    {

                        LumexSessionManager.Add("ReturnableAmount", dt.Rows[0]["ReturnAmount"]);
                        string message =
                            "Sales <span class='actionTopic'>Return</span> Successfully with Adjust Dues of Return ID: <span class='actionTopic'>" +
                            dt.Rows[0]["SalesReturnId"] + " And Money Back Amount:" + dt.Rows[0]["ReturnAmount"] +
                            "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");

                    }
                    else
                    {
                        string message =
                            "Sales <span class='actionTopic'>Return</span> Successfully with Money Back Only of Return ID: <span class='actionTopic'>" +
                            dt.Rows[0]["SalesReturnId"] + " And Money Back Amount:" + dt.Rows[0]["ReturnAmount"] +
                            "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");

                    }
                    receiveSalesReturnforAdjustButton.Enabled = false;
                    receiveSalesReturnForMoneyBackButton.Enabled = false;
                }
                else
                {
                    string message = "Sales Return Amount must be greater than 0.00";
                  
                    MyAlertBox("WarningAlert(  \"" + message + "\", \"\");");
                }
            }
            catch (Exception ex)
            {
                string message = "Some things goes wrong on create Sales Return";
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(  \"" + message + "\", \"\");");
            }
            finally
            {
                salesOrder = null;
            }
        }
    }
}