﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseToWH
{
    public partial class CreatePurchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;
            productTextBox.Attributes.Add("autocomplete", "off");
            if (!IsPostBack)
            {
                checkedRowCountHiddenField.Value = "0";
                // transportTypeDropDownList.SelectedIndex = 2;
                LoadWarehouses();
                LoadVendors();
                loadCashorChequeAccountHead();
                GetActiveProducts(warehouseDropDownList.SelectedValue);
                //LoadChartOfAccountsCashAndBankHeadList();
                productTextBox.Focus();
            }

            if (productListGridView.Rows.Count > 0)
            {
                productListGridView.UseAccessibleHeader = true;
                productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (purchaseProductListGridView.Rows.Count > 0)
            {
                purchaseProductListGridView.UseAccessibleHeader = true;
                purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadChartOfAccountsCashAndBankHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashAndBankHeadList();

                accountHeadDropDownList.DataSource = dt;
                accountHeadDropDownList.DataValueField = "AccountId";
                accountHeadDropDownList.DataTextField = "AccountHead";
                accountHeadDropDownList.DataBind();
                accountHeadDropDownList.Items.Insert(0, "");
                accountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Cash & Bank Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
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
                //warehouseDropDownList.Items.Insert(0, "");
                //warehouseDropDownList.SelectedIndex = 0;
                warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

                warehouseDropDownList_SelectedIndexChanged(this, new EventArgs());

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

        protected void LoadVendors()
        {
            VendorBLL vendor = new VendorBLL();

            try
            {
                vendor.WarehouseId = warehouseDropDownList.SelectedValue;
                DataTable dt = vendor.GetActiveVendorsByWHId();//vendor.GetVendorListByActivationStatus("True");

                vendorDropDownList.DataSource = dt;
                vendorDropDownList.DataValueField = "VendorId";
                vendorDropDownList.DataTextField = "VendorName";
                vendorDropDownList.DataBind();
                vendorDropDownList.Items.Insert(0, "");
                vendorDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

            finally
            {
                vendor = null;
            }
        }

        protected void GetActiveProducts(string id)
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetActiveProductsByWareHouseorSalesCenter(id);
                productListGridView.DataSource = dt;
                productListGridView.DataBind();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    productListGridView.DataSource = "";
                    productListGridView.DataBind();
                }
                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("Amount"));
                dt.Columns.Add(new DataColumn("UnitPrice"));

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                   // dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();

                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                    dr["Quantity"] = quantityTextBox.Text.Trim();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                    dr["Amount"] = amountTextBox.Text.Trim();

                    TextBox unitPriceTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");
                    dr["UnitPrice"] = unitPriceTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                int previousRowcount = dt.Rows.Count;

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");

                    if (chkbx.Checked && !CheckAddedProduct(productListGridView.Rows[i].Cells[1].Text.ToString()))
                    {
                        dr = dt.NewRow();

                        //dr["Barcode"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ProductId"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ProductName"] = productListGridView.Rows[i].Cells[1].Text.ToString();
                        dr["Unit"] = productListGridView.Rows[i].Cells[2].Text.ToString();
                        dr["Quantity"] = string.Empty;
                        dr["RatePerUnit"] = string.Empty;
                        dr["Amount"] = string.Empty;
                        dr["UnitPrice"] = string.Empty;

                        dt.Rows.Add(dr);
                    }
                }

                purchaseProductListGridView.DataSource = dt;
                purchaseProductListGridView.DataBind();

                for (int i = 0; i < previousRowcount; i++)
                {
                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                    quantityTextBox.Text = dt.Rows[i]["Quantity"].ToString();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                    TextBox unitPriceTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");
                    unitPriceTextBox.Text = dt.Rows[i]["UnitPrice"].ToString();
                }

                if (purchaseProductListGridView.Rows.Count > 0)
                {
                    purchaseProductListGridView.UseAccessibleHeader = true;
                    purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                }
                InitialProuctAddTextbox();
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected bool CheckAddedProduct(string productBarcodeIdName)
        {
            bool status = false;

            try
            {
                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    if (purchaseProductListGridView.Rows[i].Cells[0].Text.ToString() == productBarcodeIdName || purchaseProductListGridView.Rows[i].Cells[1].Text.ToString() == productBarcodeIdName || purchaseProductListGridView.Rows[i].Cells[2].Text.ToString() == productBarcodeIdName)
                    {
                        status = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }

            return status;
        }

        protected void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] id = productTextBox.Text.Split('#');
                string productBarcodeIdName = "";
                if (id.Length > 1)
                {
                    productBarcodeIdName = id[1];
                }
                else
                {
                    productBarcodeIdName = productTextBox.Text;
                }

                if (string.IsNullOrEmpty(productBarcodeIdName))
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Exception!!!";
                    msgDetailLabel.Text = "Write Product ID or Name to search.";
                }
                else
                {
                    if (CheckAddedProduct(productTextBox.Text.Trim()))
                    {
                        msgbox.Visible = true;
                        msgTitleLabel.Text = "Exception!!!";
                        msgDetailLabel.Text = "This product already added in the selected product list.";
                    }
                    else
                    {
                        for (int j = 0; j < productListGridView.Rows.Count; j++)
                        {
                            if (productListGridView.Rows[j].Cells[0].Text.ToString() == productBarcodeIdName ||
                                productListGridView.Rows[j].Cells[1].Text.ToString() == productBarcodeIdName)
                            {
                                DataTable dt = new DataTable();
                                DataRow dr = null;

                                //dt.Columns.Add(new DataColumn("Barcode"));
                                dt.Columns.Add(new DataColumn("ProductId"));
                                dt.Columns.Add(new DataColumn("ProductName"));
                                dt.Columns.Add(new DataColumn("Unit"));
                                dt.Columns.Add(new DataColumn("Quantity"));
                                dt.Columns.Add(new DataColumn("RatePerUnit"));
                                dt.Columns.Add(new DataColumn("Amount"));
                                dt.Columns.Add(new DataColumn("UnitPrice"));

                                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                                {
                                    dr = dt.NewRow();

                                    // dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                                    dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();

                                    TextBox quantityTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                                    dr["Quantity"] = quantityTextBox.Text.Trim();

                                    TextBox ratePerUnitTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                                    TextBox amountTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                                    dr["Amount"] = amountTextBox.Text.Trim();

                                    TextBox unitPriceTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");
                                    dr["UnitPrice"] = unitPriceTextBox.Text.Trim();

                                    dt.Rows.Add(dr);
                                }

                                int previousRowcount = dt.Rows.Count;

                                dr = dt.NewRow();
                                // dr["Barcode"] = productListGridView.Rows[j].Cells[0].Text.ToString();
                                dr["ProductId"] = productListGridView.Rows[j].Cells[0].Text.ToString();
                                dr["ProductName"] = productListGridView.Rows[j].Cells[1].Text.ToString();
                                dr["Unit"] = productListGridView.Rows[j].Cells[2].Text.ToString();
                                dr["Quantity"] = string.Empty;
                                dr["RatePerUnit"] = string.Empty;
                                dr["Amount"] = string.Empty;
                                dr["UnitPrice"] = string.Empty;
                                dt.Rows.Add(dr);

                                purchaseProductListGridView.DataSource = dt;
                                purchaseProductListGridView.DataBind();

                                for (int i = 0; i < previousRowcount; i++)
                                {
                                    TextBox quantityTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                                    quantityTextBox.Text = dt.Rows[i]["Quantity"].ToString();

                                    TextBox ratePerUnitTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                                    TextBox amountTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                                    TextBox unitPriceTextBox =
                                        (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");
                                    unitPriceTextBox.Text = dt.Rows[i]["UnitPrice"].ToString();
                                }

                                if (purchaseProductListGridView.Rows.Count > 0)
                                {
                                    purchaseProductListGridView.UseAccessibleHeader = true;
                                    purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                                    saveButton.Enabled = true;
                                }
                                else
                                {
                                    saveButton.Enabled = false;
                                }
                                InitialProuctAddTextbox();
                                CheckBox chkbx = (CheckBox)productListGridView.Rows[j].FindControl("selectCheckBox");
                                chkbx.Checked = true;
                                checkedRowCountHiddenField.Value =
                                    (int.Parse(checkedRowCountHiddenField.Value) + 1).ToString();

                                productBarcodeIdName = "added";
                                break;
                            }
                        }

                        if (productBarcodeIdName != "added")
                        {
                            msgbox.Visible = true;
                            msgTitleLabel.Text = "Exception!!!";
                            msgDetailLabel.Text = "Product not found.";
                        }

                    }

                }
               
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += " --> " + ex.InnerException.Message;
                }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }

        }

        protected void InitialProuctAddTextbox()
        {
            productTextBox.Text = "";
            productTextBox.Focus();
            //  MyAlertBox("MyOverlayStop();");
        }

        protected void removeLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
                int index = gvRow.RowIndex;

                string productId = purchaseProductListGridView.Rows[index].Cells[1].Text.ToString();

                DataTable dt = new DataTable();
                DataRow dr = null;

               // dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("ProductId"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("Amount"));
                dt.Columns.Add(new DataColumn("UnitPrice"));

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                  //  dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();

                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                    dr["Quantity"] = quantityTextBox.Text.Trim();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                    dr["Amount"] = amountTextBox.Text.Trim();

                    TextBox unitPriceTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");
                    dr["UnitPrice"] = unitPriceTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    if (productListGridView.Rows[i].Cells[1].Text.ToString() == productId)
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
                purchaseProductListGridView.DataSource = dt;
                purchaseProductListGridView.DataBind();

                double amount = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                    quantityTextBox.Text = dt.Rows[i]["Quantity"].ToString();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                    TextBox unitPriceTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");
                    unitPriceTextBox.Text = dt.Rows[i]["UnitPrice"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[i]["Amount"].ToString()))
                    {
                        amount += double.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                }

                totalAmountTextBox.Text = amount.ToString();
                totalPayableTextBox.Text = (decimal.Parse(totalAmountTextBox.Text.Trim()) - decimal.Parse(discountTextBox.Text.Trim())).ToString();
                //if (string.IsNullOrEmpty(vatTextBox.Text.Trim()))
                //{
                //    totalPayableTextBox.Text = amount.ToString();
                //}
                //else
                //{
                //    totalPayableTextBox.Text = ((amount * double.Parse(vatTextBox.Text.Trim()) / 100) + amount).ToString();
                //}

                if (purchaseProductListGridView.Rows.Count > 0)
                {
                    purchaseProductListGridView.UseAccessibleHeader = true;
                    purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                }
                InitialProuctAddTextbox();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            PurchaseToWHBLL purchaseRecord = new PurchaseToWHBLL();

            string msg = string.Empty;
            TextBox quantityTextBox;
            TextBox ratePerUnitTextBox;
            TextBox amountTextBox;
            TextBox unitPriceTextBox;
            float fnum;
            float uprice;
            double num;
            int pNDCount = 0;

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("ProductId");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");
            dt.Columns.Add("RatePerUnit");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("Status");
            dt.Columns.Add("Narration");

            try
            {
                //if (vendorOrderDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(vendorOrderDateTextBox.Text.Trim()) == "False")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Vendor Order Date field is required.";
                //    return;
                //}
                //else if (vendorOrderNumberTextBox.Text.Trim() == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Vendor Order Number field is required.";
                //    return;
                //}
                //else
                if (vendorInvoiceNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Vendor Invoice Number field is required.";
                    return;
                }
                //else if (receivedDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(receivedDateTextBox.Text.Trim()) == "False")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Received Date field is required.";
                //    return;
                //}
                //else if (transportTypeDropDownList.SelectedValue == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transport Type field is required.";
                //    return;
                //}

                if (paymentModeDropDownList.SelectedValue == "Cheque")
                {
                    if (chequeNumberTextBox.Text.Trim() == "")
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Cheque Number field is required.";
                        return;
                    }
                    else if (chequeDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim()) == "False")
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Cheque Date field is required.";
                        return;
                    }
                    else if (bankDropDownList.Text == "")
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Bank Name field is required.";
                        return;
                    }
                    //else if (bankBranchTextBox.Text.Trim() == "")
                    //{
                    //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Bank Branch Name field is required.";
                    //    return;
                    //}
                }

                UnitPriceCalculation();

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                    ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                    unitPriceTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");

                    if (!double.TryParse(quantityTextBox.Text.Trim(), out num))
                    {
                        msg = "Product ID [" + purchaseProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Quantity.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (!float.TryParse(ratePerUnitTextBox.Text.Trim(), out fnum))
                    {
                        msg = "Product ID [" + purchaseProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Rate Per Unit.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (!float.TryParse(amountTextBox.Text.Trim(), out fnum))
                    {
                        msg = "Product ID [" + purchaseProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Amount.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (!float.TryParse(unitPriceTextBox.Text.Trim(), out uprice))
                    {
                        msg = "Product ID [" + purchaseProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Unit Price.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else
                    {
                        dr = dt.NewRow();

                        dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["Quantity"] = quantityTextBox.Text.Trim();
                        dr["Amount"] = amountTextBox.Text.Trim();
                        dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();
                        dr["UnitPrice"] = unitPriceTextBox.Text.Trim();
                        dr["Status"] = "D";
                        dr["Narration"] = "";

                        //string[] oQty = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString().Split(' ');

                        //if (int.Parse(quantityTextBox.Text.Trim()) == 0)
                        //{
                        //    dr["Status"] = "ND"; pNDCount++;
                        //}
                        //else if (oQty[0].ToString().Trim() == quantityTextBox.Text.Trim())
                        //{
                        //    dr["Status"] = "D";
                        //}
                        //else
                        //{
                        //    dr["Status"] = "PD";
                        //}

                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count == purchaseProductListGridView.Rows.Count)
                {
                    purchaseRecord.AccountId = accountHeadDropDownList.SelectedValue.Trim();
                    purchaseRecord.WarehouseId = warehouseDropDownList.SelectedValue;
                    purchaseRecord.PurchaseRequisitionId = "";
                    purchaseRecord.PurchaseOrderId = "";
                    purchaseRecord.VendorId = vendorDropDownList.SelectedValue;
                    purchaseRecord.VendorOrderDate = LumexLibraryManager.ParseAppDate(vendorOrderDateTextBox.Text.Trim());
                    purchaseRecord.VendorOrderNumber = vendorOrderNumberTextBox.Text.Trim();
                    purchaseRecord.VendorInvoiceNumber = vendorInvoiceNumberTextBox.Text.Trim();
                    purchaseRecord.ReceivedDate = LumexLibraryManager.ParseAppDate(receivedDateTextBox.Text.Trim());
                    purchaseRecord.TotalAmount = totalAmountTextBox.Text.Trim();
                    //purchaseRecord.VAT = vatTextBox.Text.Trim();
                    purchaseRecord.DiscountAmount = discountTextBox.Text.Trim();
                    purchaseRecord.TotalPayable = totalPayableTextBox.Text.Trim();
                    purchaseRecord.PaidAmount = paidAmountTextBox.Text.Trim();
                    purchaseRecord.TransportCost = transportCostTextBox.Text.Trim();
                    purchaseRecord.Narration = narrationTextBox.Text.Trim();
                    purchaseRecord.LCNumber = "";//lcNumberTextBox.Text.Trim();
                    purchaseRecord.TransportType = "";//transportTypeDropDownList.SelectedValue.Trim();
                    purchaseRecord.ShippingAddress = "";//shippingAddressTextBox.Text.Trim();
                    purchaseRecord.BillingAddress = "";//billingAddressTextBox.Text.Trim();
                    purchaseRecord.PaymentMode = paymentModeDropDownList.SelectedValue.Trim();
                    purchaseRecord.Bank = bankDropDownList.Text;
                    purchaseRecord.BankBranch = bankBranchTextBox.Text.Trim();
                    purchaseRecord.ChequeNumber = chequeNumberTextBox.Text.Trim();
                    purchaseRecord.ChequeDate = LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim());

                    purchaseRecord.Status = "D";

                    //if (pNDCount > 0)
                    //{
                    //    purchaseRecord.Status = "PD";
                    //}
                    //else
                    //{
                    //    purchaseRecord.Status = "D";
                    //}

                    string id = purchaseRecord.SavePurchaseRecord(dt);

                    if (!string.IsNullOrEmpty(id))
                    {
                        string message = "Purchase Record <span class='actionTopic'>Created</span> Successfully with Purchase Record ID: <span class='actionTopic'>" + id + "</span>.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/PurchaseToWH/PurchaseList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                        // MyAlertBox("alert(\"Purchase Record Created Successfully with Purchase Record ID: " + id + " \"); window.location=\"/UI/PurchaseToWH/PurchaseList.aspx\"");
                    }
                    else
                    {
                        string message = "Purchase Record <span class='actionTopic'>Created</span> Is Faild </span>.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/PurchaseToWH/PurchaseList.aspx\"; }; ErrorAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                        //  msgbox.Visible = true; msgTitleLabel.Text = "Failed to Create Purchase Record!!!"; msgDetailLabel.Text = "";
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
                //  purchaseRecord = null;
            }
        }

        protected void discountTextBox_TextChanged(object sender, EventArgs e)
        {
            UnitPriceCalculation();
        }

        protected void transportCostTextBox_TextChanged(object sender, EventArgs e)
        {
            UnitPriceCalculation();
        }

        protected void UnitPriceCalculation()
        {
            try
            {
                if (discountTextBox.Text.Trim() == "")
                {
                    discountTextBox.Text = "0";
                }

                if (transportCostTextBox.Text.Trim() == "")
                {
                    transportCostTextBox.Text = "0";
                }

                decimal ratePerTaka = (decimal.Parse(transportCostTextBox.Text.Trim()) - decimal.Parse(discountTextBox.Text.Trim())) / decimal.Parse(totalAmountTextBox.Text.Trim());

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("quantityTextBox");
                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("amountTextBox");
                    TextBox unitPriceTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("unitPriceTextBox");

                    unitPriceTextBox.Text = (((ratePerTaka * decimal.Parse(amountTextBox.Text)) + decimal.Parse(amountTextBox.Text)) / decimal.Parse(quantityTextBox.Text)).ToString("0.00");
                }
            }
            catch
            {

            }
        }

        protected void warehouseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadVendors();
                GetActiveProducts(warehouseDropDownList.SelectedValue);
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
            }
            catch (Exception)
            {


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
    }
}