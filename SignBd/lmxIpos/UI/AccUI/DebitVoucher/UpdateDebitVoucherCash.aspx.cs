﻿using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.DebitVoucher
{
    public partial class UpdateDebitVoucherCash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadChartOfAccountsHeadList();
                    LoadChartOfAccountsCashHeadList();
                    RemoveCashHeadFromAccountsHead();
                    LoadPayToFromCompanyList();
                    accountHeadDropDownList.Focus();

                    numberLabel.Text = journalNumberForUpdateHiddenField.Value = LumexSessionManager.Get("DVCashJournalForUpdate").ToString().Trim();
                    GetDebitVoucherCashByJournal(journalNumberForUpdateHiddenField.Value.Trim());
                }
            }
            catch (Exception ex)
            {
                updateButton.Enabled = false;

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadChartOfAccountsHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsHeadList();

                accountHeadDropDownList.DataSource = dt;
                accountHeadDropDownList.DataValueField = "AccountId";
                accountHeadDropDownList.DataTextField = "AccountHead";
                accountHeadDropDownList.DataBind();
                accountHeadDropDownList.Items.Insert(0, "");
                accountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
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
                chartOfAccount = null;
            }
        }

        protected void LoadChartOfAccountsCashHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashHeadList();

                cashAccountHeadDropDownList.DataSource = dt;
                cashAccountHeadDropDownList.DataValueField = "AccountId";
                cashAccountHeadDropDownList.DataTextField = "AccountHead";
                cashAccountHeadDropDownList.DataBind();
                cashAccountHeadDropDownList.Items.Insert(0, "");
                cashAccountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Cash Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
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
                chartOfAccount = null;
            }
        }

        protected void RemoveCashHeadFromAccountsHead()
        {
            try
            {
                int count = accountHeadDropDownList.Items.Count;

                for (int i = 0; i < cashAccountHeadDropDownList.Items.Count; i++)
                {
                    for (int j = 0; j < accountHeadDropDownList.Items.Count; j++)
                    {
                        if (cashAccountHeadDropDownList.Items[i].Value == accountHeadDropDownList.Items[j].Value)
                        {
                            accountHeadDropDownList.Items.RemoveAt(j);
                            break;
                        }
                    }
                }

                if (count != accountHeadDropDownList.Items.Count)
                {
                    accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void LoadPayToFromCompanyList()
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();

            try
            {
                payToFromCompanyDropDownList.Items.Clear();
                DataTable dt = new DataTable();
                if (payToFromTypeDropDownList.SelectedValue == "com")
                {
                    dt = payToFromCompany.GetActivePayToFromCompanyList();
                    payToFromCompanyDropDownList.DataSource = dt;
                    payToFromCompanyDropDownList.DataValueField = "CompanyId";
                    payToFromCompanyDropDownList.DataTextField = "CompanyName";
                    payToFromCompanyDropDownList.DataBind();
                    lblPaytoFromType.Text = "Company";
                }
                else if (payToFromTypeDropDownList.SelectedValue == "ven")
                {
                    VendorBLL vendor = new VendorBLL();
                    dt = vendor.GetActiveVendors();
                    payToFromCompanyDropDownList.DataSource = dt;
                    payToFromCompanyDropDownList.DataValueField = "VendorId";
                    payToFromCompanyDropDownList.DataTextField = "VendorName";
                    payToFromCompanyDropDownList.DataBind();
                    lblPaytoFromType.Text = "Vendor";
                }
                else if (payToFromTypeDropDownList.SelectedValue == "cus")
                {
                    CustomerBLL customer = new CustomerBLL();
                    dt = customer.GetActiveCustomerList();
                    payToFromCompanyDropDownList.DataSource = dt;
                    payToFromCompanyDropDownList.DataValueField = "CustomerId";
                    payToFromCompanyDropDownList.DataTextField = "CustomerIdName";
                    payToFromCompanyDropDownList.DataBind();
                    lblPaytoFromType.Text = "Customer";

                }



                payToFromCompanyDropDownList.Items.Insert(0, "");
                payToFromCompanyDropDownList.Items.Insert(1, "N/A");
                payToFromCompanyDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Pay To/From Company Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
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
                payToFromCompany = null;
            }
        }

        protected void GetDebitVoucherCashByJournal(string journalNumber)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

            try
            {
                DataTable dt = debitCreditVoucher.GetDebitVoucherApprovalByJournal("Cash", journalNumber);

                if (dt.Rows.Count > 0)
                {
                    voucherNumberTextBox.Text = dt.Rows[0]["ManualVoucherNumber"].ToString();
                    accountHeadDropDownList.SelectedValue = dt.Rows[0]["AccountId"].ToString();
                    cashAccountHeadDropDownList.SelectedValue = dt.Rows[0]["CounterAccountId"].ToString();
                    amountTextBox.Text = dt.Rows[0]["Amount"].ToString();
                    payToFromCompanyDropDownList.SelectedValue = dt.Rows[0]["PayToFromCompany"].ToString();
                    narrationTextBox.Text = dt.Rows[0]["Narration"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Debit Voucher Cash Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
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
                debitCreditVoucher = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

            try
            {
                if (accountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Account Head field is required.";
                }
                else if (amountTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Amount field is required.";
                }
                else if (cashAccountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Account Head field is required.";
                }
                else if (voucherNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Voucher Number field is required.";
                }
                else if (payToFromCompanyDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Pay To/From Company field is required.";
                }
                else if (narrationTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Narration field is required.";
                }
                else
                {
                    debitCreditVoucher.JournalNumber = journalNumberForUpdateHiddenField.Value;
                    debitCreditVoucher.ManualVoucherNumber = voucherNumberTextBox.Text.Trim();
                    debitCreditVoucher.AccountId = accountHeadDropDownList.SelectedValue.Trim();
                    debitCreditVoucher.CounterAccountId = cashAccountHeadDropDownList.SelectedValue.Trim();
                    debitCreditVoucher.Amount = amountTextBox.Text.Trim();
                    debitCreditVoucher.PayToFromCompany = payToFromCompanyDropDownList.SelectedValue.Trim();
                    debitCreditVoucher.Narration = narrationTextBox.Text.Trim();

                    debitCreditVoucher.UpdateDebitVoucherCash();

                    string message = "Debit Voucher Cash <span class='actionTopic'>Updated</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/DebitVoucher/DebitVoucherCashList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
                debitCreditVoucher = null;
            }
        }
        protected void payToFromTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPayToFromCompanyList();
        }
    }
}