﻿using System;
using System.Activities.Statements;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Report.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Sales
{
    public partial class RetailSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;
                productTextBox.Attributes.Add("autocomplete", "off");

                if (!IsPostBack)
                {
                    checkedRowCountHiddenField.Value = "0";
                    LoadWarehouses();
                    GetAvailableProductListBySalesCenter();
                    LoadActiveCustomerList();
                    GetOverallVATPercentage();

                    // getSalesCenterName((string)LumexSessionManager.Get("UserSalesCenterId"));
                    // getCustomerList();

                    productTextBox.Focus();

                }

                if (customerListGridView.Rows.Count > 0)
                {
                    customerListGridView.UseAccessibleHeader = true;
                    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    saveButton.Enabled = true;
                }

                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                    totalAmountTextBox.Text = "0.00";
                    //totalReceivableTextBox.Text = "";
                    receivedAmountTextBox.Text = "0.00";
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

                ddlSelectWareHouseOrSalesCenter.DataSource = dt;
                ddlSelectWareHouseOrSalesCenter.DataValueField = "WarehouseId";
                ddlSelectWareHouseOrSalesCenter.DataTextField = "WarehouseName";
                ddlSelectWareHouseOrSalesCenter.DataBind();
                ddlSelectWareHouseOrSalesCenter.Items.Insert(0, "Select Please");
                ddlSelectWareHouseOrSalesCenter.SelectedIndex = 0;
                ddlSelectWareHouseOrSalesCenter.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();
                GetAvailableProductListBySalesCenter();



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
        protected void loadCashorChequeAccountHead()
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
        protected void paymentModeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadCashorChequeAccountHead();
                if (paymentModeDropDownList.SelectedValue.ToString() == "Cheque")
                {
                    bankDropDownList.Enabled = true;
                    bankBranchTextBox.Enabled = true;
                    chequeNumberTextBox.Enabled = true;
                    chequeDateTextBox.Enabled = true;
                }
                if (paymentModeDropDownList.SelectedValue.ToString() == "Cash")
                {
                    bankDropDownList.Enabled = false;
                    bankBranchTextBox.Enabled = false;
                    chequeNumberTextBox.Enabled = false;
                    chequeDateTextBox.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

        }
        private void getSalesCenterName(string salesCenterId)
        {
            try
            {
                SalesCenterBLL salesCenter = new SalesCenterBLL();
                DataTable dt = salesCenter.GetSalesCenterById(salesCenterId);
                // lblSalesCenterName.Text = dt.Rows[0][2].ToString();
            }
            catch (Exception)
            {


            }
        }


        private void getCustomerList()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                //DataTable dt = customer.GetCustomerById((string)LumexSessionManager.Get("ActiveUserId"));
                DataTable dt = customer.GetCustomerList();
                customerListGridView.DataSource = dt;
                customerListGridView.DataBind();

                if (customerListGridView.Rows.Count > 0)
                {
                    customerListGridView.UseAccessibleHeader = true;
                    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Customer are not available !!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void gotoRecievepayment(object sender, EventArgs e)
        {
            LumexSessionManager.Add("forClientReceive", customerIdDropDownList.SelectedValue);
        }
        protected void customerIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getCustomerByCustomerId();
                getCustomerTotalReceivableByCustomerId();
                customerIdDropDownList.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void selectCustomerLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;

                customerIdDropDownList.SelectedValue = customerListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();

                getCustomerByCustomerId();
                getCustomerTotalReceivableByCustomerId();

                customerIdDropDownList.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        private void getCustomerTotalReceivableByCustomerId()
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();

            try
            {
                DataTable dt = receivePayment.GetCustomerTotalReceivable(customerIdDropDownList.SelectedValue, ddlSelectWareHouseOrSalesCenter.SelectedValue);

                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["TotalDue"].ToString()))
                    {
                        previousDueTextBox.Text = dt.Rows[0]["TotalDue"].ToString();
                        previousDueDiv.Visible = true;
                        // DuesAmoutPayTextBox.ReadOnly = false;
                    }
                    else
                    {
                        previousDueTextBox.Text = "0.00";
                        previousDueDiv.Visible = false;
                        // DuesAmoutPayTextBox.ReadOnly = true;
                    }
                }
                else
                {
                    //string message = "Customer <span class='actionTopic'>Due</span> Data not found.";
                    //MyAlertBox("WarningAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");

                    previousDueTextBox.Text = "0.00";
                    previousDueDiv.Visible = false;
                    // DuesAmoutPayTextBox.ReadOnly = true;
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
            }
        }

        private void getCustomerByCustomerId()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {

                if (!string.IsNullOrEmpty(customerIdDropDownList.SelectedValue))
                {
                    //for (int i = 0; i < customerListGridView.Rows.Count; i++)
                    //{
                    //    if (customerListGridView.Rows[i].Cells[0].Text.Equals(customerIdDropDownList.SelectedValue))
                    //    {
                    //        customerNameTextBox.Text = customerListGridView.Rows[i].Cells[1].Text;
                    //        customerContactNumberTextBox.Text = customerListGridView.Rows[i].Cells[2].Text;
                    //        customerAddressTextBox.Text = customerListGridView.Rows[i].Cells[3].Text;
                    //        break;
                    //    }
                    //}
                    DataTable dt = customer.GetCustomerById(customerIdDropDownList.SelectedValue);
                    if (dt.Rows.Count > 0)
                    {
                        customerNameTextBox.Text = dt.Rows[0]["CustomerName"].ToString();
                        customerContactNumberTextBox.Text = dt.Rows[0]["ContactNumber"].ToString();
                        customerAddressTextBox.Text = dt.Rows[0]["Address"].ToString();
                    }
                }
                else
                {
                    customerNameTextBox.Text = "";
                    customerContactNumberTextBox.Text = "";
                    customerAddressTextBox.Text = "";
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
                customer = null;
            }
        }

        protected void GetOverallVATPercentage()
        {
            ProductPriceBLL productPrice = new ProductPriceBLL();

            try
            {
                DataTable dt = productPrice.GetOverallProductVAT();

                vatTextBox.Text = dt.Rows[0][0].ToString();
                vatTextBox.ReadOnly = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                productPrice = null;
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadActiveCustomerList()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                customer.WarehouseId = ddlSelectWareHouseOrSalesCenter.SelectedValue;
                DataTable dt = customer.GetActiveCustomerListByWHId();

                customerIdDropDownList.DataSource = dt;
                customerIdDropDownList.DataValueField = "CustomerId";
                customerIdDropDownList.DataTextField = "CustomerIdName";
                customerIdDropDownList.DataBind();
                customerIdDropDownList.Items.Insert(0, "Retail");
                customerIdDropDownList.SelectedIndex = 0;
                customerIdDropDownList.Items[0].Value = "Retail";
                //Customer Gridview Load
                //customerListGridView.DataSource = dt;
                //customerListGridView.DataBind();

                //if (customerListGridView.Rows.Count > 0)
                //{
                //    customerListGridView.UseAccessibleHeader = true;
                //    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                //}

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Customer are not available !!!"; msgDetailLabel.Text = "";
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
                customer = null;
            }
        }

        protected void GetAvailableProductListBySalesCenter()
        {
            ProductBLL product = new ProductBLL();

            try
            {

                DataTable dt = new DataTable();
                product.WareHouseId = ddlSelectWareHouseOrSalesCenter.SelectedValue;
                if (ddlSelectWareHouseOrSalesCenter.SelectedValue == "WH-002")
                {
                    dt = product.GetMainProductsByWareHouseForSales();
                    saveButton.Text = "CREATE NEW SALES";
                }
                else
                {
                    dt = product.GetAllProductsBySalesCenter(ddlSelectWareHouseOrSalesCenter.SelectedValue);
                    saveButton.Text = "CREATE NEW SALES";
                }
                if (dt.Rows.Count > 0)
                {
                    productListGridView.DataSource = dt;
                    productListGridView.DataBind();
                }
                else
                {
                    productListGridView.DataSource = dt;
                    productListGridView.DataBind();

                }
                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }


                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Products are not available for the selected Sales Center!!!"; msgDetailLabel.Text = "";
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
                product = null;
            }
        }

        protected void addSelectedProductButton_Click(object sender, EventArgs e)
        {
            AddNewProductInList();
            productTextBox.Focus();
            productTextBox.Text = "";
        }

        protected void AddNewProductInList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            try
            {
                //dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("ProductId"));
                dt.Columns.Add(new DataColumn("ProductName"));
                // dt.Columns.Add(new DataColumn("FreeQuantity"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("Height"));
                dt.Columns.Add(new DataColumn("Width"));
                dt.Columns.Add(new DataColumn("OrderUnit"));
                dt.Columns.Add(new DataColumn("TotalUnit"));
                dt.Columns.Add(new DataColumn("OrderQuantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("VATPercentage"));
                dt.Columns.Add(new DataColumn("Amount"));




                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    //dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    //here 
                    // dr["FreeQuantity"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    TextBox heightTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("heightTextBox");
                    dr["Height"] = heightTextBox.Text.Trim();
                    TextBox WidthTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("WidthTextBox");
                    dr["Width"] = WidthTextBox.Text.Trim();
                    TextBox UnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("UnitTextBox");
                    dr["OrderUnit"] = UnitTextBox.Text.Trim();
                    TextBox totalUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                    dr["TotalUnit"] = totalUnitTextBox.Text.Trim();
                    //selectedProductListGridView.Rows[i].Cells[10].Text.ToString();
                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    dr["OrderQuantity"] = orderQuantityTextBox.Text.Trim();


                    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();
                    Label vat = (Label)selectedProductListGridView.Rows[i].FindControl("lblVatparcentage");
                    dr["VATPercentage"] = vat.Text;
                    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    dr["Amount"] = amountTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                //int previousRowcount = dt.Rows.Count;

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");

                    if (chkbx.Checked && !CheckAddedProduct(productListGridView.Rows[i].Cells[0].Text.ToString()))
                    {
                        dr = dt.NewRow();

                        // dr["Barcode"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ProductId"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ProductName"] = productListGridView.Rows[i].Cells[1].Text.ToString();
                        // dr["FreeQuantity"] = productListGridView.Rows[i].Cells[4].Text.ToString();
                        dr["Unit"] = productListGridView.Rows[i].Cells[2].Text.ToString();
                        dr["RatePerUnit"] = productListGridView.Rows[i].Cells[5].Text.ToString();
                        dr["OrderUnit"] = "1";
                        dr["TotalUnit"] = "1";
                        dr["OrderQuantity"] = "0";
                        dr["VATPercentage"] = productListGridView.Rows[i].Cells[6].Text.ToString();
                        //need to work
                        dr["Amount"] = "0.00"; // (decimal.Parse(productListGridView.Rows[i].Cells[5].Text.ToString()) + (decimal.Parse(productListGridView.Rows[i].Cells[5].Text.ToString()) * decimal.Parse(productListGridView.Rows[i].Cells[6].Text.ToString())) / 100).ToString("0.00");

                        dt.Rows.Add(dr);
                    }
                }

                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();

                //for (int i = 0; i < selectedProductListGridView.Rows.Count; i++) //for (int i = 0; i < previousRowcount; i++)
                //{
                //    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                //    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                //    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                //    orderQuantityTextBox.Text = dt.Rows[i]["OrderQuantity"].ToString();

                //    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                //    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                //    TextBox totalUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                //    dr["TotalUnit"] = totalUnitTextBox.Text.Trim();
                //}

                CalculateTotalAmount();
                CalculateOthersAmount();

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    otherInformation.Visible = true;
                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                    otherInformation.Visible = false;
                    totalAmountTextBox.Text = "";
                    //totalReceivableTextBox.Text = "";
                    receivedAmountTextBox.Text = "";
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
                dt.Dispose();
                dr = null;
            }
        }

        protected bool CheckAddedProduct(string productBarcodeIdName)
        {
            bool status = false;

            try
            {
                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    if (selectedProductListGridView.Rows[i].Cells[0].Text.ToString() == productBarcodeIdName || selectedProductListGridView.Rows[i].Cells[1].Text.ToString() == productBarcodeIdName)
                    {
                        //TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");

                        //TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                        //orderQuantityTextBox.Text = (int.Parse(orderQuantityTextBox.Text)).ToString();

                        //TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                        //amountTextBox.Text = (int.Parse(orderQuantityTextBox.Text) * decimal.Parse(ratePerUnitTextBox.Text)).ToString("0.00");
                        //Label vat = (Label)selectedProductListGridView.Rows[i].FindControl("lblVatparcentage");

                        //amountTextBox.Text = (decimal.Parse(amountTextBox.Text) + (decimal.Parse(amountTextBox.Text) * decimal.Parse(vat.Text)) / 100).ToString("0.00");

                        //Old
                        //TextBox stockTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("stockTextBox");

                        //TextBox totalUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                        //totalUnitTextBox.Text = (decimal.Parse(orderQuantityTextBox.Text)) * (decimal.Parse(selectedProductListGridView.Rows[i].FindControl("Unit").ToString(; ;
                        //totalUnitTextBox.Text = (decimal.Parse(orderQuantityTextBox.Text) * decimal.Parse(selectedProductListGridView.Rows[i].FindControl("Unit").ToString())).ToString("0.00");

                        status = false; // to add duplicate product
                        break;
                    }
                }

                //CalculateTotalAmount();
                //  CalculateOthersAmount();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

            return status;
        }

        protected void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                string productBarcodeIdName = "";
                string[] pid = productTextBox.Text.Trim().Split('[');
                if (pid.Length > 1)
                {
                    productBarcodeIdName = pid[0];
                }
                else
                {
                    productBarcodeIdName = productTextBox.Text.Trim();
                }

                if (string.IsNullOrEmpty(productBarcodeIdName))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Write Product Barcode or ID or Name to search.";
                }
                else
                {
                    if (CheckAddedProduct(productBarcodeIdName))
                    {
                        //CalculateTotalAmount();
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "This product already added in the selected product list.";
                    }
                    else
                    {
                        for (int j = 0; j < productListGridView.Rows.Count; j++)
                        {
                            if (productListGridView.Rows[j].Cells[0].Text.ToString() == productBarcodeIdName || productListGridView.Rows[j].Cells[1].Text.ToString() == productBarcodeIdName)
                            {
                                DataTable dt = new DataTable();
                                DataRow dr = null;

                                dt.Columns.Add(new DataColumn("ProductId"));
                                dt.Columns.Add(new DataColumn("ProductName"));
                                // dt.Columns.Add(new DataColumn("FreeQuantity"));
                                dt.Columns.Add(new DataColumn("Unit"));
                                dt.Columns.Add(new DataColumn("Height"));
                                dt.Columns.Add(new DataColumn("Width"));
                                dt.Columns.Add(new DataColumn("OrderUnit"));
                                dt.Columns.Add(new DataColumn("TotalUnit"));
                                dt.Columns.Add(new DataColumn("OrderQuantity"));
                                dt.Columns.Add(new DataColumn("RatePerUnit"));
                                dt.Columns.Add(new DataColumn("VATPercentage"));
                                dt.Columns.Add(new DataColumn("Amount"));




                                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                                {
                                    dr = dt.NewRow();

                                    //dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                                    //here 
                                    // dr["FreeQuantity"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                                    TextBox heightTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("heightTextBox");
                                    dr["Height"] = heightTextBox.Text.Trim();
                                    TextBox WidthTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("WidthTextBox");
                                    dr["Width"] = WidthTextBox.Text.Trim();
                                    TextBox UnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("UnitTextBox");
                                    dr["OrderUnit"] = UnitTextBox.Text.Trim();
                                    TextBox totalUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                                    dr["TotalUnit"] = totalUnitTextBox.Text.Trim();
                                    //selectedProductListGridView.Rows[i].Cells[10].Text.ToString();
                                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                                    dr["OrderQuantity"] = orderQuantityTextBox.Text.Trim();


                                    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();
                                    Label vat = (Label)selectedProductListGridView.Rows[i].FindControl("lblVatparcentage");
                                    dr["VATPercentage"] = vat.Text;
                                    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                                    dr["Amount"] = amountTextBox.Text.Trim();

                                    dt.Rows.Add(dr);
                                }

                                //int previousRowcount = dt.Rows.Count;

                                dr = dt.NewRow();
                                dr["ProductId"] = productListGridView.Rows[j].Cells[0].Text.ToString();
                                dr["ProductName"] = productListGridView.Rows[j].Cells[1].Text.ToString();
                                // dr["FreeQuantity"] = productListGridView.Rows[i].Cells[4].Text.ToString();
                                dr["Unit"] = productListGridView.Rows[j].Cells[2].Text.ToString();
                                dr["RatePerUnit"] = productListGridView.Rows[j].Cells[5].Text.ToString();
                                dr["OrderUnit"] = "1";
                                dr["TotalUnit"] = "1";
                                dr["OrderQuantity"] = "0";
                                dr["VATPercentage"] = productListGridView.Rows[j].Cells[6].Text.ToString();

                                dr["Amount"] = "0.00";//(decimal.Parse(productListGridView.Rows[j].Cells[5].Text.ToString()) + (decimal.Parse(productListGridView.Rows[j].Cells[5].Text.ToString()) * decimal.Parse(productListGridView.Rows[j].Cells[6].Text.ToString())) / 100).ToString("0.00");
                                dt.Rows.Add(dr);

                                selectedProductListGridView.DataSource = dt;
                                selectedProductListGridView.DataBind();

                                //for (int i = 0; i < selectedProductListGridView.Rows.Count; i++) //for (int i = 0; i < previousRowcount; i++)
                                //{
                                //    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                                //    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                                //    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                                //    orderQuantityTextBox.Text = dt.Rows[i]["OrderQuantity"].ToString();

                                //    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                                //    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();
                                //}

                                if (selectedProductListGridView.Rows.Count > 0)
                                {
                                    selectedProductListGridView.UseAccessibleHeader = true;
                                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                                    saveButton.Enabled = true;
                                    otherInformation.Visible = true;
                                }
                                else
                                {
                                    saveButton.Enabled = false;
                                    otherInformation.Visible = false;
                                }

                                CheckBox chkbx = (CheckBox)productListGridView.Rows[j].FindControl("selectCheckBox");
                                chkbx.Checked = true;
                                checkedRowCountHiddenField.Value = (int.Parse(checkedRowCountHiddenField.Value) + 1).ToString();

                                productBarcodeIdName = "added";
                                break;
                            }
                        }

                        if (productBarcodeIdName != "added")
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product not found.";
                        }

                        CalculateTotalAmount();
                        CalculateOthersAmount();
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
                productTextBox.Focus();
                productTextBox.Text = "";
            }
        }

        protected void CalculateTotalAmount()
        {
            decimal amt = 0;
            decimal recAmt = 0;
            decimal Discount = 0;
            // decimal otherAmount = decimal.Parse(txtbxAmount.Text.Trim());

            for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
            {
                TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                amt += decimal.Parse(amountTextBox.Text.Trim());

                TextBox rateUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");

                TextBox UnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");

                //For Discout Count From Product Add
                // Discount += (decimal.Parse(amountTextBox.Text.Trim()) - (decimal.Parse(rateUnitTextBox.Text.Trim()) * decimal.Parse(UnitTextBox.Text.Trim())));
                totalAmountTextBox.Text = amt.ToString("0.00");

                //TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                //orderQuantityTextBox.Text = (int.Parse(orderQuantityTextBox.Text)).ToString();

                //TextBox totalUnit = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                //totalUnit.Text = (decimal.Parse(orderQuantityTextBox.Text) * decimal.Parse(selectedProductListGridView.Rows[i].FindControl("Unit").ToString())).ToString("0.00");


                //  discountTextBox.Text = Discount.ToString();
                //totalReceivableTextBox.Text = amt.ToString();
            }

            if (!string.IsNullOrEmpty(receivedAmountTextBox.Text.Trim()))
            {
                recAmt = decimal.Parse(receivedAmountTextBox.Text.Trim());
            }
        }

        protected void CalculateOthersAmount()
        {
            totalVATAmountHiddenField.Value = "0";
            decimal netAmt = 0;
            decimal totalAmt = 0;
            decimal discount = 0;
            decimal vat = 0;
            decimal receivable = 0;
            decimal received = 0;

            decimal.TryParse(totalAmountTextBox.Text, out totalAmt);
            decimal.TryParse(discountTextBox.Text, out discount);
            decimal.TryParse(vatTextBox.Text, out vat);
            decimal.TryParse(receivableAmountTextBox.Text, out receivable);
            decimal.TryParse(receivedAmountTextBox.Text, out received);

            netAmt = totalAmt - discount; //Change for Apply Vat
            receivable = netAmt + (netAmt * vat / 100);
            decimal.Round(receivable, 2, MidpointRounding.AwayFromZero);
            totalVATAmountHiddenField.Value = (netAmt * vat / 100).ToString("0.00");

            receivableAmountTextBox.Text = receivable.ToString("0.00");
            changeAmountTextBox.Text = (received - receivable).ToString("0.00");
            vatTextBox.Text = vat.ToString("0.00");
            discountTextBox.Text = discount.ToString("0.00");
        }

        protected decimal CalculateTotalVATAmount()
        {
            decimal qty = 0;
            decimal rate = 0;
            decimal amt = 0;
            decimal vatRate = 0;
            decimal vatAmt = 0;

            for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
            {
                TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                qty = decimal.Parse(orderQuantityTextBox.Text.Trim());

                TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                rate = decimal.Parse(ratePerUnitTextBox.Text.Trim());
                Label vat = (Label)selectedProductListGridView.Rows[i].FindControl("lblVatparcentage");
                vatRate = decimal.Parse(vat.Text);

                amt = qty * rate;

                vatAmt += amt * (vatRate / 100);
            }

            return vatAmt;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            SalesOrderBLL salesOrder = new SalesOrderBLL();
            DataTable dtPrdList = new DataTable();
            DataRow dr = null;
            decimal quantity = 0;
            double rate = 0;
            double amount = 0;
            TextBox orderQuantityTextBox;
            TextBox ratePerUnitTextBox;
            TextBox amountTextBox;
            TextBox heighTextBox;
            TextBox widthTextBox;
            TextBox UnitTextBox;
            TextBox totalUnitTextBox;
            Label vatLabel;
            int i = 0;

            dtPrdList.Columns.Add(new DataColumn("ProductId"));
            dtPrdList.Columns.Add(new DataColumn("Height"));
            dtPrdList.Columns.Add(new DataColumn("Width"));
            dtPrdList.Columns.Add(new DataColumn("OrderUnit"));
            dtPrdList.Columns.Add(new DataColumn("TotalUnit"));
            dtPrdList.Columns.Add(new DataColumn("OrderQuantity"));
            dtPrdList.Columns.Add(new DataColumn("Quantity"));
            dtPrdList.Columns.Add(new DataColumn("RatePerUnit"));
            dtPrdList.Columns.Add(new DataColumn("VATPercentage"));
            dtPrdList.Columns.Add(new DataColumn("Amount"));


            try
            {
                for (i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    //double availAbleQuantity = Convert.ToDouble(selectedProductListGridView.Rows[i].Cells[3].Text.ToString());
                    heighTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("heightTextBox");
                    widthTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("WidthTextBox");
                    UnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("UnitTextBox");
                    totalUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                    orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    vatLabel = (Label)selectedProductListGridView.Rows[i].FindControl("lblVatparcentage");
                    if (string.IsNullOrEmpty(orderQuantityTextBox.Text.Trim()) || !decimal.TryParse(orderQuantityTextBox.Text.Trim(), out quantity))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid quantity.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (string.IsNullOrEmpty(ratePerUnitTextBox.Text.Trim()) || !double.TryParse(ratePerUnitTextBox.Text.Trim(), out rate))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid rate.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (string.IsNullOrEmpty(amountTextBox.Text.Trim()) || !double.TryParse(amountTextBox.Text.Trim(), out amount))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid amount.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    //else if (Convert.ToDouble(orderQuantityTextBox.Text) > availAbleQuantity)
                    //{
                    //    msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Availability.";
                    //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                    //    return;
                    //}
                    else
                    {
                        dr = dtPrdList.NewRow();

                        dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                        // dr["Available"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                        dr["Height"] = heighTextBox.Text;
                        dr["Width"] = widthTextBox.Text;
                        dr["OrderUnit"] = UnitTextBox.Text;
                        dr["TotalUnit"] = totalUnitTextBox.Text;
                        dr["Quantity"] = quantity.ToString();
                        dr["RatePerUnit"] = rate.ToString();
                        dr["VATPercentage"] = vatLabel.Text; //selectedProductListGridView.Rows[i].Cells[8].Text.ToString();
                        dr["Amount"] = amount.ToString();

                        dtPrdList.Rows.Add(dr);
                    }
                }

                if (accountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Select Any Account Head";
                    return;
                }

                else if (totalAmountTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Total Amount field is required.";
                    return;
                }
                else if (receivedAmountTextBox.Text.Trim() == "" && customerIdDropDownList.SelectedIndex == 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Received Amount field is required.";
                    return;
                }
                else if (changeAmountTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Change Amount field is required.";
                    return;
                }
                else if (customerIdDropDownList.SelectedItem.Text.Trim() == "Retail" && Convert.ToDecimal(receivableAmountTextBox.Text) > Convert.ToDecimal(receivedAmountTextBox.Text) && customerNameTextBox.Text == "" && customerContactNumberTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Warning!!!"; msgDetailLabel.Text = "Can not sale Retail on Due please select Customer.";
                    return;
                }
                else if ((paymentModeDropDownList.SelectedValue == "Cheque" && chequeNumberTextBox.Text == "") || (paymentModeDropDownList.SelectedValue == "Cheque" && chequeDateTextBox.Text == ""))
                {
                    //if (chequeNumberTextBox.Text == "" || chequeDateTextBox.Text == "")
                    //{
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Cheque Number Or Cheque Date field is Required.";
                    return;
                    // }

                }
                //if (string.IsNullOrEmpty(DuesAmoutPayTextBox.Text))
                //{
                //    DuesAmoutPayTextBox.Text = "0";
                //}
                else
                {

                    if (receivedAmountTextBox.Text == "")
                    {
                        receivedAmountTextBox.Text = "0";
                    }
                    salesOrder.SalesCenterId = ddlSelectWareHouseOrSalesCenter.SelectedValue.Trim();
                    salesOrder.CustomerId = customerIdDropDownList.SelectedValue.Trim();
                    salesOrder.CustomerName = customerNameTextBox.Text.Trim();
                    salesOrder.CustomerContactNumber = customerContactNumberTextBox.Text.Trim();
                    salesOrder.CustomerAddress = customerAddressTextBox.Text.Trim();
                    salesOrder.TotalAmount = totalAmountTextBox.Text.Trim();
                    salesOrder.DiscountAmount = discountTextBox.Text.Trim();
                    salesOrder.VAT = vatTextBox.Text.Trim();
                    salesOrder.TotalReceivable = receivableAmountTextBox.Text.Trim();
                    salesOrder.Due = "0";//DuesAmoutPayTextBox.Text;
                    salesOrder.SalesOrderId = "";
                    salesOrder.ReceivedAmount = receivedAmountTextBox.Text.Trim();
                    salesOrder.ChangeAmount = (Convert.ToDecimal(salesOrder.ReceivedAmount) - Convert.ToDecimal(salesOrder.TotalReceivable)).ToString();
                    salesOrder.TotalVATAmount = totalVATAmountHiddenField.Value;

                    salesOrder.AccountId = accountHeadDropDownList.SelectedValue;
                    salesOrder.CustomerId = customerIdDropDownList.SelectedValue.Trim();
                    salesOrder.PaymentMode = paymentModeDropDownList.SelectedValue;
                    // receivePayment.Amount = receivedAmountTextBox.Text.Trim();
                    salesOrder.Bank = bankDropDownList.Text;
                    salesOrder.BankBranch = bankBranchTextBox.Text;
                    salesOrder.ChequeNumber = chequeNumberTextBox.Text;
                    salesOrder.ChequeDate = LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text);
                    salesOrder.OthersDes = txtbxDescription.Text;
                    salesOrder.OthersAmount = txtbxOthersAmount.Text;
                    salesOrder.Narration = txtbxNarration.Text;

                    if (dtPrdList.Rows.Count == selectedProductListGridView.Rows.Count)
                    {
                        string salesRecordId = salesOrder.SaveRetailSales(dtPrdList);
                        if (salesRecordId != "")
                        {
                            IPOSReportBLL iposReport = new IPOSReportBLL();
                            iposReport.GetSalesInvoiceBySalesRecord(salesRecordId, salesOrder.SalesCenterId);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);


                            string message = "Product's <span class='actionTopic'>Sales</span> Successfully with Sale ID: <span class='actionTopic'>" +
                            salesRecordId + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSales.aspx\"; }; SuccessAlert(\"" +
                                "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }

                        else
                        {
                            string message = "Product's <span class='actionTopic'>Sales</span> Falied" +
                            salesRecordId + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSales.aspx\"; }; SuccessAlert(\"" +
                                "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }

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
                salesOrder = null;
                dtPrdList = null;
            }
        }


        protected void removeLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
                int index = gvRow.RowIndex;

                string productId = selectedProductListGridView.Rows[index].Cells[0].Text.ToString();

                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("ProductId"));
                dt.Columns.Add(new DataColumn("ProductName"));
                // dt.Columns.Add(new DataColumn("FreeQuantity"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("Height"));
                dt.Columns.Add(new DataColumn("Width"));
                dt.Columns.Add(new DataColumn("OrderUnit"));
                dt.Columns.Add(new DataColumn("TotalUnit"));
                dt.Columns.Add(new DataColumn("OrderQuantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("VATPercentage"));
                dt.Columns.Add(new DataColumn("Amount"));




                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    //dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    //here 
                    // dr["FreeQuantity"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    TextBox heightTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("heightTextBox");
                    dr["Height"] = heightTextBox.Text.Trim();
                    TextBox WidthTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("WidthTextBox");
                    dr["Width"] = WidthTextBox.Text.Trim();
                    TextBox UnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("UnitTextBox");
                    dr["OrderUnit"] = UnitTextBox.Text.Trim();
                    TextBox totalUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("totalUnitTextBox");
                    dr["TotalUnit"] = totalUnitTextBox.Text.Trim();
                    //selectedProductListGridView.Rows[i].Cells[10].Text.ToString();
                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    dr["OrderQuantity"] = orderQuantityTextBox.Text.Trim();


                    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();
                    Label vat = (Label)selectedProductListGridView.Rows[i].FindControl("lblVatparcentage");
                    dr["VATPercentage"] = vat.Text;
                    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    dr["Amount"] = amountTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    if (productListGridView.Rows[i].Cells[0].Text.ToString() == productId)
                    {
                        CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");
                        chkbx.Checked = false;

                        CheckBox allchkbx = (CheckBox)productListGridView.HeaderRow.FindControl("allCheckBox");
                        allchkbx.Checked = false;
                        checkedRowCountHiddenField.Value = (int.Parse(checkedRowCountHiddenField.Value) - 1).ToString();

                        break;
                    }
                }

                dt.Rows.RemoveAt(index);
                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();

                double amount = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    //ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                    //TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    //orderQuantityTextBox.Text = dt.Rows[i]["OrderQuantity"].ToString();

                    //TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    //amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[i]["Amount"].ToString()))
                    {
                        amount += double.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                }

                totalAmountTextBox.Text = amount.ToString("0.00");
                //totalReceivableTextBox.Text = amount.ToString();
                CalculateTotalAmount();
                CalculateOthersAmount();

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                    totalAmountTextBox.Text = "";
                    //totalReceivableTextBox.Text = "";
                    receivedAmountTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void ddlSelectWareHouseOrSalesCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                RefreshSelectedPrductGridView();
                GetAvailableProductListBySalesCenter();
                LoadActiveCustomerList();
                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }


        protected void RefreshSelectedPrductGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();

            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}