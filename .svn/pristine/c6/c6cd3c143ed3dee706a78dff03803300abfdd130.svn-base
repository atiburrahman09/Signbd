using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductGroup
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadWarehouses();
                    GetProductGroupListByWHId(LumexSessionManager.Get("UserWareHouseId").ToString());
                }

                if (productGroupListGridView.Rows.Count > 0)
                {
                    productGroupListGridView.UseAccessibleHeader = true;
                    productGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void LoadWarehouses()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                warehouseDropDownList.DataSource = dt;
                warehouseDropDownList.DataValueField = "WarehouseId";
                warehouseDropDownList.DataTextField = "WarehouseName";
                warehouseDropDownList.DataBind();
                warehouseDropDownList.Items.Insert(0, "");
                //warehouseDropDownList.SelectedIndex = 0;
                //warehouseDropDownList.Items[0].Value = "A";
                warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                warehouse = null;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetProductGroupListByWHId(string WhId)
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();

            try
            {
                DataTable dt = productGroup.GetProductGroupListByWHId(WhId);
                productGroupListGridView.DataSource = dt;
                productGroupListGridView.DataBind();

                if (productGroupListGridView.Rows.Count > 0)
                {
                    productGroupListGridView.UseAccessibleHeader = true;
                    productGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product Group List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                productGroup = null;
            }
        }

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ProductGroupIdForUpdate", productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/ProductGroup/Update.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                ProductGroupBLL productGroup = new ProductGroupBLL();
                productGroup.UpdateProductGroupActivation(productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                productGroupListGridView.Rows[row.RowIndex].Cells[3].Text = "True";
                string message = "Product Group <span class='actionTopic'>Activated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deactivateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                ProductGroupBLL productGroup = new ProductGroupBLL();
                productGroup.UpdateProductGroupActivation(productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                productGroupListGridView.Rows[row.RowIndex].Cells[3].Text = "False";
                string message = "Product Group <span class='actionTopic'>Deactivated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
                string WareHouseID = warehouseDropDownList.SelectedValue;
                ProductGroupBLL productGroup = new ProductGroupBLL();
                string status = productGroup.DeleteProductGroup(productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                if (status == "Deleted")
                {
                    GetProductGroupListByWHId(WareHouseID);
                    string message = "Product Group <span class='actionTopic'>Deleted</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    GetProductGroupListByWHId(WareHouseID);
                    string message = "This Product Group contains " + status + " product(s). You can't delete this Product Group. You must move the product(s) first to another product group.";
                    MyAlertBox("WarningAlert(\"" + "Data Dependency" + "\", \"" + message + "\", \"\");");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void warehouseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string whId = warehouseDropDownList.SelectedValue;
            GetProductGroupListByWHId(whId);
        }

        
    }
}