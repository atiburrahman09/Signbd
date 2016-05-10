using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Report.BLL;
using Lumex.Tech;

namespace lmxIpos.ReportUI
{
    public partial class VendorDueAmount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadWarehouse();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void LoadWarehouse()
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
                //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;
                // salesCenterDropDownList.SelectedIndex = 0;

                salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Warehouse Data Not Found!!!"; msgDetailLabel.Text = "";
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
        protected void generateButton_Click(object sender, EventArgs e)
        {
            try
            {

                IPOSReportBLL iposReport = new IPOSReportBLL();
                iposReport.GetSalesCenterVendorDueAmountList(salesCenterDropDownList.SelectedValue);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}