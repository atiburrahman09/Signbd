﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using Lumex.Project.BLL;
using Lumex.Report.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Sales
{
    public partial class RetailSalesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouse();
                fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.AddHours(14).ToString());
                toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.AddHours(14).ToString());
                salesCenterDropDownList.Focus();
            }

            if (salesRecordListGridView.Rows.Count > 0)
            {
                salesRecordListGridView.UseAccessibleHeader = true;
                salesRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        //protected void chkatDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkatDropdownList.SelectedValue == "WH")
        //        {
        //            LoadWarehouse();
        //            wareHouseorSCLabel.Text = "Warehouse";
        //        }
        //        else
        //        {
        //            LoadSalesCenters();
        //            wareHouseorSCLabel.Text = "Sales Center";
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

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataTextField = "WarehouseName";
                salesCenterDropDownList.DataValueField = "WarehouseId";
                salesCenterDropDownList.DataBind();
                salesCenterDropDownList.Items.Insert(0, "");
                // salesCenterDropDownList.SelectedIndex = 0;

                salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserWarehouseId").ToString();
                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Warehouse  Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void LoadSalesCenters()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataValueField = "SalesCenterId";
                salesCenterDropDownList.DataTextField = "SalesCenterName";
                salesCenterDropDownList.DataBind();
                salesCenterDropDownList.Items.Insert(0, "");
                salesCenterDropDownList.SelectedIndex = 0;
                salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Business Data Not Found!!!"; msgDetailLabel.Text = "";
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
                salesCenter = null;
            }
        }

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                if (lnkBtn.Text == "View")
                {
                    LumexSessionManager.Add("SalesRecordIdForView",
                        salesRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                    //Response.Redirect("~/UI/Sales/ApprovedRetailSales.aspx");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewApprovedSalesDetail();", true);
                }
                else
                {
                    LumexSessionManager.Add("SalesRecordIdForView",
                       salesRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                    //Response.Redirect("~/UI/Sales/ApproveRetailSales.aspx");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewApproveSalesDetail();", true);
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void recordListButton_Click(object sender, EventArgs e)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                if (salesCenterDropDownList.SelectedValue == "")
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
                    string salesCenterId = salesCenterDropDownList.SelectedValue.Trim();
                    string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    string status = statusDropDownList.SelectedValue.Trim();

                    DataTable dt = salesOrder.GetSalesRecordsListBySalesCenterDateRangeAndStatus(salesCenterId, fromDate, toDate, status);

                    salesRecordListGridView.DataSource = dt;
                    salesRecordListGridView.DataBind();

                    if (salesRecordListGridView.Rows.Count > 0)
                    {
                        salesRecordListGridView.UseAccessibleHeader = true;
                        salesRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                salesOrder = null;
            }
        }

        protected void printInvoiceButton_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

            string salesRecordId = salesRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();
            string salesCencerId = salesCenterDropDownList.SelectedValue;

            IPOSReportBLL iposReport = new IPOSReportBLL();
            iposReport.GetSalesInvoiceBySalesRecord(salesRecordId, salesCencerId);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

        }

        protected void editLinkButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                if (lnkBtn.Text == "Edit" && salesRecordListGridView.Rows[row.RowIndex].Cells[6].Text.ToString() == "Pending")
                {
                    LumexSessionManager.Add("SalesRecordIdForUpdate",
                        salesRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                    Response.Redirect("~/UI/Sales/UpdateRetailSales.aspx");
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Warning!!!"; msgDetailLabel.Text = "Sorry !! You can not Edit Approved record.";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}