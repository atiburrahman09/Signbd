﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PaymentToVendor
{
    public partial class VendorPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadVendors();
                    LoadWarehouse();
                    // LoadChartOfAccountsCashAndBankHeadList();
                }

                if (payableListGridView.Rows.Count > 0)
                {
                    payableListGridView.UseAccessibleHeader = true;
                    payableListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void paymentModeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                accountHeadDropDownList.Items.Clear();
                ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();
                if (paymentModeDropDownList.SelectedItem.Text == "Cash")
                {
                    DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashHeadList();

                    accountHeadDropDownList.DataSource = dt;
                    accountHeadDropDownList.DataValueField = "AccountId";
                    accountHeadDropDownList.DataTextField = "AccountHead";
                    accountHeadDropDownList.DataBind();
                    accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 0;

                }
                else if (paymentModeDropDownList.SelectedItem.Text == "Cheque")
                {
                    DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsBankHeadList();
                    accountHeadDropDownList.DataSource = dt;
                    accountHeadDropDownList.DataValueField = "AccountId";
                    accountHeadDropDownList.DataTextField = "AccountHead";
                    accountHeadDropDownList.DataBind();
                    accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //protected void LoadSalesCenters()
        //{
        //    SalesCenterBLL salesCenter = new SalesCenterBLL();

        //    try
        //    {
        //        DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

        //        drpdwnSalesCenterOrWarehouse.DataSource = dt;
        //        drpdwnSalesCenterOrWarehouse.DataValueField = "SalesCenterId";
        //        drpdwnSalesCenterOrWarehouse.DataTextField = "SalesCenterName";
        //        drpdwnSalesCenterOrWarehouse.DataBind();
        //        //drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
        //        //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;

        //        drpdwnSalesCenterOrWarehouse.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Joining Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
        //            msgbox.Attributes.Add("class", "alert alert-warning");
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
        //        salesCenter = null;
        //    }
        //}

        //protected void drpdwnAccountOn_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        payableListGridView.DataSource = null;
        //        payableListGridView.DataBind();

        //        if (drpdwnAccountOn.SelectedIndex == 0)
        //        {
        //            drpdwnSalesCenterOrWarehouse.Items.Clear();
        //            LoadSalesCenters();
        //            titleSalesCenterOrWarehouse.Text = "Sales Center";
        //        }
        //        else if (drpdwnAccountOn.SelectedIndex == 1)
        //        {
        //            drpdwnSalesCenterOrWarehouse.Items.Clear();
        //            LoadWarehouse();
        //            titleSalesCenterOrWarehouse.Text = "Warehouse";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //}

        private void LoadWarehouse()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                drpdwnSalesCenterOrWarehouse.DataSource = dt;
                drpdwnSalesCenterOrWarehouse.DataTextField = "WarehouseName";
                drpdwnSalesCenterOrWarehouse.DataValueField = "WarehouseId";
                drpdwnSalesCenterOrWarehouse.DataBind();
                //drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
                //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;

                drpdwnSalesCenterOrWarehouse.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void LoadVendors()
        {
            VendorBLL vendor = new VendorBLL();

            try
            {
                DataTable dt = vendor.GetVendorListByActivationStatus("True");

                vendorDropDownList.DataSource = dt;
                vendorDropDownList.DataValueField = "VendorId";
                vendorDropDownList.DataTextField = "VendorName";
                vendorDropDownList.DataBind();
                vendorDropDownList.Items.Insert(0, "");
                vendorDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                vendor = null;
            }
        }

        protected void GetVendorPayableList()
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();

            try
            {
                if (vendorDropDownList.SelectedValue.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Vendor Name field is required.";
                }
                else
                {
                    DataTable dt = receivePayment.GetVendorPayableList(vendorDropDownList.SelectedValue, "Warehouse", drpdwnSalesCenterOrWarehouse.SelectedValue);

                    payableListGridView.DataSource = dt;
                    payableListGridView.DataBind();

                    if (payableListGridView.Rows.Count > 0)
                    {
                        payableListGridView.UseAccessibleHeader = true;
                        payableListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        decimal currentPayable = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            currentPayable += decimal.Parse(dt.Rows[i]["Due"].ToString());
                        }

                        currentPayableLabel.Text = currentPayable.ToString();
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Vendor Payable List Data Not Found!!!"; msgDetailLabel.Text = "";
                        msgbox.Attributes.Add("class", "alert alert-info");
                        currentPayableLabel.Text = "0.00";
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
                receivePayment = null;
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void payableListButton_Click(object sender, EventArgs e)
        {
            GetVendorPayableList();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();

            try
            {
                if (decimal.Parse(currentPayableLabel.Text) > 0)
                {
                    if (decimal.Parse(currentPayableLabel.Text) >= decimal.Parse(amountTextBox.Text.Trim()))
                    {
                        receivePayment.AccountId = accountHeadDropDownList.SelectedValue.Trim();
                        receivePayment.VendorId = vendorDropDownList.SelectedValue.Trim();
                        receivePayment.CashCheque = paymentModeDropDownList.SelectedValue.Trim();
                        receivePayment.CurrentPayable = currentPayableLabel.Text;
                        receivePayment.Amount = amountTextBox.Text.Trim();
                        receivePayment.ChequeNo = chequeNumberTextBox.Text;
                        receivePayment.ChequeDate = chequeDateTextBox.Text;
                        receivePayment.Bank = bankDropDownList.Text;
                        receivePayment.BankBrach = bankBranchTextBox.Text;

                        receivePayment.SaveVendorPayment("", drpdwnSalesCenterOrWarehouse.SelectedValue);//drpdwnAccountOn.SelectedValue, drpdwnSalesCenterOrWarehouse.SelectedValue);

                        //string message = "Vendor Payment <span class='actionTopic'>Saved</span> Successfully.";
                        //MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                        initializeFields();
                        string message = "Vendor Payment <span class='actionTopic'>" + receivePayment.Amount + " Saved</span> Successfully.";
                        MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");


                        GetVendorPayableList();
                        //MyAlertBox("alert(\"Saved Successfully.\");");
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Amount must be equal or less of Current Payable Amount.";
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "No Payable to Payment.";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void initializeFields()
        {
            amountTextBox.Text = "0";
            paymentModeDropDownList.SelectedIndex = 0;
            accountHeadDropDownList.SelectedIndex = 0;
            chequeDateTextBox.Text = "";
            chequeNumberTextBox.Text = "";
            bankDropDownList.Text = "";
            bankBranchTextBox.Text = "";
        }
    }
}