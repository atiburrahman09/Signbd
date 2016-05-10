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
    public partial class ProductWiseSalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadProduct();
                }
                fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void LoadProduct()
        {
            try
            {
                ProductBLL productBll=new ProductBLL();
                DataTable dt = productBll.GetActiveProductList();
                drpdwnProduct.DataSource = dt;
                drpdwnProduct.DataTextField = "ProductName";
                drpdwnProduct.DataValueField = "ProductId";
                drpdwnProduct.DataBind();
                drpdwnProduct.Items.Insert(0, "");
                //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;
                //drpdwnProduct.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();
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
        protected void generateButton_OnClick(object sender, EventArgs e)
        {
            try
            {

                IPOSReportBLL iposReport = new IPOSReportBLL();
                iposReport.GetProductSalesRecordListByProductId(drpdwnProduct.SelectedValue, toDateTextBox.Text, fromDateTextBox.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                //}
                //else if (drpdwnReportOnStock.SelectedValue == "2")
                //{
                //    IPOSReportBLL iposReport = new IPOSReportBLL();
                //    iposReport.GetAvailableProductBySaclesCenterIdPRWise(SalesCenterIdDropDownList.SelectedValue);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                //}
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
    }
}