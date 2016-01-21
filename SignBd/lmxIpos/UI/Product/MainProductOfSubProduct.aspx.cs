﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Product
{
    public partial class MainProductOfSubProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWarehouses();
                //LoadSubProductList(LumexSessionManager.Get("UserWareHouseId").ToString());
            }
          //  LoadSubProductList();
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
                // warehouseDropDownList.SelectedIndex = 0;
                // warehouseDropDownList.Items[0].Value = "A";
                warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();
                LoadSubProductList(warehouseDropDownList.SelectedValue);
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
        private void LoadSubProductList(string wareHouseId)
        {
            DataTable dt = new DataTable();
            ProductBLL productBll = new ProductBLL();

            dt = productBll.GetMainProductListWHID(wareHouseId);
            subProductDropDownList.DataSource = dt;

            subProductDropDownList.DataValueField = "ProductId";
            subProductDropDownList.DataTextField = "ProductName";
            subProductDropDownList.DataBind();
            subProductDropDownList.Items.Insert(0, "Please Select");
            subProductDropDownList.SelectedIndex = 0;
            subProductDropDownList.Items[0].Value = "";
            subProductDropDownList.Focus();

        }

   
        protected void subProductDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //mainProductListGridView.Rows.clear();
            DataTable dt = new DataTable();
            ProductBLL productBll = new ProductBLL();
            productBll.SubProductId =subProductDropDownList.SelectedValue.ToString();
            dt = productBll.GetMainProductListBySubProductId();
            mainProductListGridView.DataSource = dt;
            mainProductListGridView.DataBind();

            if (mainProductListGridView.Rows.Count > 0)
            {
                mainProductListGridView.UseAccessibleHeader = true;
                mainProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Product List Data Not Found!!!"; msgDetailLabel.Text = "";
                msgbox.Attributes.Add("class", "alert alert-warning");
            }
        }

        protected void wareHouseDropDownList_Click(object sender, EventArgs e)
        {
            mainProductListGridView.DataSource = null;
            mainProductListGridView.DataBind();
            LoadSubProductList(LumexSessionManager.Get("UserWareHouseId").ToString());
        }
        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
                ProductBLL productBll = new ProductBLL();

                productBll.DeleteProductById(mainProductListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());

                subProductDropDownList_SelectedIndexChanged(this, EventArgs.Empty);
                string message = "Product <span class='actionTopic'>Deleted</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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