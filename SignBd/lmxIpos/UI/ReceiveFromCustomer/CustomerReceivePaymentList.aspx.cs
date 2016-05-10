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

namespace lmxIpos.UI.ReceiveFromCustomer
{
    public partial class CustomerReceivePaymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomer();

            }
            if (customerPaymentListGridView.Rows.Count > 0)
            {
                customerPaymentListGridView.UseAccessibleHeader = true;
                customerPaymentListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void LoadCustomer()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                customer.WarehouseId = LumexSessionManager.Get("UserWareHouseId").ToString();
               // DataTable dt = customer.GetActiveCustomerListByWHId();
                DataTable dt = customer.GetActiveCustomerList();
                customerDropDownList.DataSource = dt;
                customerDropDownList.DataValueField = "CustomerId";
                customerDropDownList.DataTextField = "CustomerIdName";
                customerDropDownList.DataBind();
                customerDropDownList.Items.Insert(0, "Select..");
                customerDropDownList.SelectedIndex = 0;


                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Customer are not available !!!";
                    msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
        protected void btnCustomerPaymentList_OnClick(object sender, EventArgs e)
        {
            CustomerBLL customerBll=new CustomerBLL();

            try
            {
                if (customerDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Business Name field is required.";
                }
                else if (fromDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date From field is required.";
                }
                else if (toDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date To field is required.";
                }
                else
                {
                    string customerId = customerDropDownList.SelectedValue.Trim();
                    string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    string status = statusDropDownList.SelectedValue;

                    DataTable dt = customerBll.GetCustomerWisePaymentList(customerId, fromDate, toDate, status);
                    customerPaymentListGridView.DataSource = dt;
                    customerPaymentListGridView.DataBind();

                    if (customerPaymentListGridView.Rows.Count > 0)
                    {
                        customerPaymentListGridView.UseAccessibleHeader = true;
                        customerPaymentListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                customerBll = null;
            }
        }

        protected void printInvoiceButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                string JournalNo = customerPaymentListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();
                string customerId = customerDropDownList.SelectedValue;
                string WHSCId = LumexSessionManager.Get("UserWareHouseId").ToString();

                IPOSReportBLL iposReport = new IPOSReportBLL();
                iposReport.GetReceivePaymentVaucharbyVendororCustomer(JournalNo, customerId, WHSCId);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);


            }
            catch (Exception ex)
            {

                //
            }
        }
    }
}