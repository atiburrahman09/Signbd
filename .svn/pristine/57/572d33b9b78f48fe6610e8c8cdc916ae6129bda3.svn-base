using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;
using System.Data;

namespace lmxIpos.UI.checqueInventory
{
    public partial class checkInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;
                if (!IsPostBack)
                {
                    LoadWarehouse();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            if (gridChequeInventory.Rows.Count > 0)
            {
                gridChequeInventory.UseAccessibleHeader = true;
                gridChequeInventory.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void getChequeInventoryDetails()
        {
            chequeInventoryBLL chekQueInventoryBll = new chequeInventoryBLL();
            DataTable dt = new DataTable();
            try
            {
                if (ddlStatus.SelectedValue != "P")
                {
                    gridChequeInventory.Columns[8].Visible = false;
                    gridChequeInventory.Columns[10].Visible = false;

                }
                else
                {
                    gridChequeInventory.Columns[8].Visible = true;
                }

                chekQueInventoryBll.folowType = ddlType.SelectedValue.ToString().Trim();
                chekQueInventoryBll.status = ddlStatus.SelectedValue.ToString().Trim();
                chekQueInventoryBll.branchId = salesCenterDropDownList.SelectedValue.ToString().Trim();

                dt = chekQueInventoryBll.getChequeInventory();

                gridChequeInventory.DataSource = dt;
                gridChequeInventory.DataBind();


                if (gridChequeInventory.Rows.Count > 0)
                {
                    gridChequeInventory.UseAccessibleHeader = true;
                    gridChequeInventory.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgTitleLabel.Text = "Warning !!!";
                    msgDetailLabel.Text = "No data Found On the cheque Inventory";
                    msgbox.Visible = true;
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

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue.ToString() != "0" && ddlType.SelectedValue.ToString() != "0")
                {
                    getChequeInventoryDetails();
                }
                else
                {
                    msgTitleLabel.Text = "Warning !!!";
                    msgDetailLabel.Text = "Please Select Status and Type";
                    msgbox.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        //protected void purchaseReturnFormDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (purchaseReturnFormDropdownList.SelectedValue == "WH")
        //        {
        //            LoadWarehouse();
        //            wareHouseorSCLabel.Text = "Warehouse";
        //        }
        //        //else
        //        //{
        //        //    LoadSalesCenters();
        //        //    wareHouseorSCLabel.Text = "Sales Center";
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //}
        //protected void LoadSalesCenters()
        //{
        //    SalesCenterBLL salesCenter = new SalesCenterBLL();

        //    try
        //    {
        //        DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

        //        salesCenterDropDownList.DataSource = dt;
        //        salesCenterDropDownList.DataValueField = "SalesCenterId";
        //        salesCenterDropDownList.DataTextField = "SalesCenterName";
        //        salesCenterDropDownList.DataBind();
        //        salesCenterDropDownList.Items.Insert(0, "");
        //        salesCenterDropDownList.SelectedIndex = 0;
        //        salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();
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
                //salesCenterDropDownList.Items.Insert(0, "");
                //salesCenterDropDownList.SelectedIndex = 0;

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

        protected void ddlStatusInGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                bool status = false;
                DropDownList drpDownList = (DropDownList)sender;
                GridViewRow gridRow = (GridViewRow)drpDownList.NamingContainer;

                chequeInventoryBLL chqInventoryBll = new chequeInventoryBLL();
                chqInventoryBll.chequeSerial = gridChequeInventory.Rows[gridRow.RowIndex].Cells[0].Text.ToString();
                TextBox txtbxNaration= (TextBox)gridChequeInventory.Rows[gridRow.RowIndex].FindControl("txtchqNaration");
                chqInventoryBll.naration = txtbxNaration.Text;
                TextBox txtbxFinalDate = (TextBox)gridChequeInventory.Rows[gridRow.RowIndex].FindControl("txtFinalDate");
                string finalDate = txtbxFinalDate.Text.Trim();
                if(!string.IsNullOrEmpty(finalDate))
                {
                    chqInventoryBll.Finaldate =LumexLibraryManager.ParseAppDate(txtbxFinalDate.Text);
                }
                DropDownList ddlStatusInGrid = (DropDownList)gridChequeInventory.Rows[gridRow.RowIndex].FindControl("ddlStatusInGrid");
                string statusType = ddlStatusInGrid.SelectedValue.ToString();

                if (!string.IsNullOrEmpty(txtbxFinalDate.Text)&&statusType!="0")
                {
                    if (ddlType.SelectedValue == "Y")
                    {
                        status = chqInventoryBll.ChangeChequeStatus(statusType);
                        getChequeInventoryDetails();
                        if (statusType == "R")
                        {


                            if (status)
                            {
                                string message =
                                    "Sales <span class='actionTopic'>Cheque</span> Successfully Rejected</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");

                            }
                            else
                            {
                                string message =
                                    "Sales <span class='actionTopic'>Cheque</span> does not Rejected</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; WarningAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");

                            }

                        }
                        if (ddlStatusInGrid.SelectedValue == "A")
                        {
                            // status = chekInventoryBll.ChangeChequeStatus(statusType);
                            if (status)
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> Successfully Approved</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                //  getChequeInventoryDetails();
                            }
                            else
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> Does Not Approved</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; WarningAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                //  getChequeInventoryDetails();
                            }
                        }

                        if (ddlStatusInGrid.SelectedValue == "AC")
                        {
                            //  status = chekInventoryBll.ChangeChequeStatus(statusType);
                            if (status)
                            {
                                string message =
                                    "<span class='actionTopic'>Cheque</span> Successfully Approved by Cash</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                //  getChequeInventoryDetails();
                            }
                            else
                            {
                                string message =
                                    "<span class='actionTopic'>Cheque</span> Does Not Approved by Cash</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; WarningAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                // getChequeInventoryDetails();
                            }
                        }
                    }
                    else
                    {
                        status = chqInventoryBll.ChangeChequeStatusForOutFlow(statusType);
                        getChequeInventoryDetails();
                        if (statusType == "R")
                        {


                            if (status)
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> Successfully Rejected</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");

                            }
                            else
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> doesw not Rejected</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; WarningAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");

                            }

                        }
                        if (ddlStatusInGrid.SelectedValue == "A")
                        {
                            // status = chekInventoryBll.ChangeChequeStatus(statusType);
                            if (status)
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> Successfully Approved</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                //  getChequeInventoryDetails();
                            }
                            else
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> Does Not Approved</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; WarningAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                //  getChequeInventoryDetails();
                            }
                        }

                        if (ddlStatusInGrid.SelectedValue == "AC")
                        {
                            //  status = chekInventoryBll.ChangeChequeStatus(statusType);
                            if (status)
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> Successfully Approved by Cash</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                //  getChequeInventoryDetails();
                            }
                            else
                            {
                                string message =
                                    " <span class='actionTopic'>Cheque</span> Does Not Approved by cash</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; WarningAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                // getChequeInventoryDetails();
                            }
                        }

                    }
                }
                else
                {
                    string message = "Please  <span class='actionTopic'>Select</span> The Final Date. or select correct Action</span>.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; WarningAlert(\"" +"Warning" + "\", \"" + message + "\", \"\");");
                    ddlStatusInGrid.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
    }
}