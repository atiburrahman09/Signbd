﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesOrder
{
    public partial class SalesOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
               // LoadSalesCenters();
                LoadWarehouse();
                fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
            }

            if (salesOrderListGridView.Rows.Count > 0)
            {
                salesOrderListGridView.UseAccessibleHeader = true;
                salesOrderListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
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
                salesCenterDropDownList.SelectedIndex = 0;

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
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
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
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text ="Something goes Wrong"+ex.Message;
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

                LumexSessionManager.Add("SalesOrderIdForView", salesOrderListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/SalesOrder/SalesOrderDetail.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text ="Something goes Wrong in view Button"+ ex.Message;
            }
        }

        protected void orderListButton_Click(object sender, EventArgs e)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                if (salesCenterDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Sales Center Name field is required.";
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

                    DataTable dt = salesOrder.GetSalesOrdersListBySalesCenterDateRangeAndStatus(salesCenterId, fromDate, toDate, status);

                    salesOrderListGridView.DataSource = dt;
                    salesOrderListGridView.DataBind();

                    if (salesOrderListGridView.Rows.Count > 0)
                    {
                        salesOrderListGridView.UseAccessibleHeader = true;
                        salesOrderListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text ="Somethings goes wrong in Order List"+ ex.Message;
            }
            finally
            {
                salesOrder = null;
            }
        }
    }
}