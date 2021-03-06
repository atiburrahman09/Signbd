﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.SMS
{
    public partial class SMSSend : System.Web.UI.Page
    {
        //http://service.aaqa.co/sms.asmx/AaqaSMSApi?username=lumextech&pass=dkVBwKnE&MobNo=8801xxxxxxxxx&Sender=xxxxxxxxxxx&msg=xxxxxx
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;
                if (!IsPostBack)
                {
                    CustomerBLL customerBll = new CustomerBLL();
                    DataTable dt = new DataTable();
                    dt = customerBll.GetActiveCustomerList();
                    customerListGridView.Visible = true;
                    customerListGridView.DataSource = dt;
                    customerListGridView.DataBind();

                }
                if (customerListGridView.Rows.Count > 0)
                {
                    customerListGridView.UseAccessibleHeader = true;
                    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        protected void sendButton_OnClick(object sender, EventArgs e)
        {
            SMSBLL smsbll = new SMSBLL();
            int j = 0;
            int k = 0;
            string[] numberArray = new string[50];
            string[] tempArray = new string[50];
            try
            {
                if (senderTextBox.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Sender Name field is required.";
                }

                else if (bodyText.Text == "" || bodyText.Text.Length > 160)
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Message field Required / Messege excced 160 Charecters .";
                }
                else
                {
                    if (selectDropDownList.SelectedValue == "CUS")
                    {
                        if (numberTextBox.Text == "")
                        {
                            msgbox.Visible = true;
                            msgTitleLabel.Text = "Validation!!!";
                            msgDetailLabel.Text = "Sender Name field is required.";
                        }
                        else
                        {
                            smsbll.senderName = senderTextBox.Text.Trim();
                            smsbll.number = numberTextBox.Text.Trim();
                            smsbll.bodyMsg = bodyText.Text.Trim();

                            string ContactNumber = "";
                            for (int l = 0; l < smsbll.number.Length; l++)
                            {
                                if (smsbll.number[l] == ';')
                                {
                                    ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                                    k = 0;
                                //http://service.aaqa.co/sms.asmx/AaqaSMSApi?username=lumextech&pass=dkVBwKnE&MobNo=88ContactNumber&Sender=smsbll.SenderName&msg=smsbll.bodyMsg
                                    SendSms(smsbll, ContactNumber);
                                    //API Call From Here

                                }
                                else
                                {
                                    tempArray[k] = smsbll.number[l].ToString();
                                    k++;
                                }
                            }
                            if (k > 0)
                            {
                                ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                               //API Call From Here
                                SendSms(smsbll, ContactNumber);
                                string message = "SMS Successfully Send !!!!!";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SMS/SMSSend.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }
                            else
                            {
                                //
                            }
                        }


                    }

                    else
                    {
                        string msg = string.Empty;
                        List<SMSBLL> SMSInfo = new List<SMSBLL>();

                        CheckBox selectCheckBox;

                        int i = 0;
                        int count = 0;

                        if (selectDropDownList.SelectedValue == "CST")
                        {
                            for (i = 0; i < customerListGridView.Rows.Count; i++)
                            {

                                selectCheckBox =
                                    (CheckBox)customerListGridView.Rows[i].Cells[3].FindControl("selectCheckBox");
                                if (selectCheckBox.Checked)
                                {
                                    count++;
                                    smsbll = new SMSBLL();
                                    smsbll.number = customerListGridView.Rows[i].Cells[2].Text.ToString();
                                    smsbll.senderName = senderTextBox.Text.Trim();
                                    smsbll.bodyMsg = bodyText.Text.Trim();
                                    SMSInfo.Add(smsbll);

                                    for (int m = 0; m < SMSInfo.Count; m++)
                                    {
                                        string ContactNumber = "";
                                        for (int l = 0; l < SMSInfo[m].number.Length; l++)
                                        {
                                            if (SMSInfo[m].number[l] == ',')
                                            {
                                                ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                                                k = 0;
                                                SendSms(smsbll, ContactNumber);
                                                //API Call From Here

                                            }
                                            else
                                            {
                                                tempArray[k] = smsbll.number[l].ToString();
                                                k++;
                                            }
                                        }
                                        if (k > 0)
                                        {
                                            ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                                            //API Call From Here
                                            SendSms(smsbll, ContactNumber);
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }


                            }
                            if (count > 0)
                            {
                                string message ="SMS Successfully Send !!!!!";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SMS/SMSSend.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }
                            else
                            {
                                string message = "Please Select Customer from Customer List.";
                                MyAlertBox(
                                   "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SMS/SMSSend.aspx\"; }; SuccessAlert(\"" +
                                   "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }

                        }
                        else if (selectDropDownList.SelectedValue == "VND")
                        {
                            for (i = 0; i < vendorGridView.Rows.Count; i++)
                            {

                                selectCheckBox =
                                    (CheckBox)vendorGridView.Rows[i].Cells[3].FindControl("selectCheckBox");
                                if (selectCheckBox.Checked)
                                {
                                    count++;
                                    smsbll = new SMSBLL();
                                    smsbll.number = vendorGridView.Rows[i].Cells[2].Text.ToString();
                                    smsbll.senderName = senderTextBox.Text.Trim();
                                    smsbll.bodyMsg = bodyText.Text.Trim();
                                    SMSInfo.Add(smsbll);

                                    for (int m = 0; m < SMSInfo.Count; m++)
                                    {
                                        string ContactNumber = "";
                                        for (int l = 0; l < SMSInfo[m].number.Length; l++)
                                        {
                                            if (SMSInfo[m].number[l] == ',')
                                            {
                                                ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                                                k = 0;
                                                SendSms(smsbll, ContactNumber);
                                                //API Call From Here

                                            }
                                            else
                                            {
                                                tempArray[k] = smsbll.number[l].ToString();
                                                k++;
                                            }
                                        }
                                        if (k > 0)
                                        {
                                            ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                                            //API Call From Here
                                            SendSms(smsbll, ContactNumber);
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }


                            }
                            if (count > 0)
                            {
                                string message = "SMS Successfully Send !!!!!";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SMS/SMSSend.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }
                            else
                            {
                                string message = "Please Select Vendor from Vendor List.";
                                MyAlertBox(
                                     "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SMS/SMSSend.aspx\"; }; SuccessAlert(\"" +
                                     "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }

                        }
                        else
                        {
                            for (i = 0; i < companyGridView.Rows.Count; i++)
                            {

                                selectCheckBox =
                                    (CheckBox)companyGridView.Rows[i].Cells[3].FindControl("selectCheckBox");
                                if (selectCheckBox.Checked)
                                {
                                    count++;
                                    smsbll = new SMSBLL();
                                    smsbll.number = companyGridView.Rows[i].Cells[2].Text.ToString();
                                    smsbll.senderName = senderTextBox.Text.Trim();
                                    smsbll.bodyMsg = bodyText.Text.Trim();
                                    SMSInfo.Add(smsbll);

                                    for (int m = 0; m < SMSInfo.Count; m++)
                                    {
                                        string ContactNumber = "";
                                        for (int l = 0; l < SMSInfo[m].number.Length; l++)
                                        {
                                            if (SMSInfo[m].number[l] == ',')
                                            {
                                                ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                                                k = 0;
                                                SendSms(smsbll, ContactNumber);
                                                //API Call From Here

                                            }
                                            else
                                            {
                                                tempArray[k] = smsbll.number[l].ToString();
                                                k++;
                                            }
                                        }
                                        if (k > 0)
                                        {
                                            ContactNumber = ConvertStringArrayToStringJoin(tempArray);
                                            SendSms(smsbll, ContactNumber);
                                            //API Call From Here
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }


                            }
                            if (count > 0)
                            {
                                string message = "SMS Successfully Send.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SMS/SMSSend.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }
                            else
                            {
                                string message = "Please Select Company from Company List.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SMS/SMSSend.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }
                        }


                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SendSms(SMSBLL smsbll, string ContactNumber)
        {
            try
            {
                string MobileNumber = "";
                if (ContactNumber.Length == 11)
                {
                    MobileNumber = "88" + ContactNumber;
                }
                else if (ContactNumber.Length == 14)
                {


                    ContactNumber.Remove(0);
                    ContactNumber.Remove(1);
                    ContactNumber.Remove(2);
                    MobileNumber = "88" + ContactNumber;

                }
                else if (ContactNumber.Length == 13)
                {


                    ContactNumber.Remove(0);
                    ContactNumber.Remove(1);
                    MobileNumber = "88" + ContactNumber;

                }

               
                string SMSURL =
                    "http://service.aaqa.co/sms.asmx/AaqaSMSApi?username=lumextech&pass=dkVBwKnE&MobNo=" + MobileNumber + "&Sender=" + smsbll.senderName + "&msg=" + smsbll.bodyMsg;
               //     string SMSURL = "http://service.aaqa.co/sms.asmx/AaqaSMSApi?username=lumextech&pass=dkVBwKnE&MobNo=" + MobileNumber +
               //"&Sender=GlobalFX&msg=" + SMSBody;
                    CallSMSUrl(SMSURL);
                


            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void CallSMSUrl(string SMSURL)
        {
            WebRequest request = HttpWebRequest.Create(SMSURL);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd();
        }

        static string ConvertStringArrayToStringJoin(string[] array)
        {
            //
            // Use string Join to concatenate the string elements.
            //
            string result = string.Join("", array);
            return result;
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void selectDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectDropDownList.SelectedValue == "CST")
            {
                CustomerBLL customerBll = new CustomerBLL();
                DataTable dt = new DataTable();
                dt = customerBll.GetActiveCustomerList();
                customerListGridView.Visible = true;
                vendorGridView.Visible = false;
                companyGridView.Visible = false;
                NumberDiv.Visible = false;
                customerListGridView.DataSource = dt;
                customerListGridView.DataBind();
                if (customerListGridView.Rows.Count > 0)
                {
                    customerListGridView.UseAccessibleHeader = true;
                    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            else if (selectDropDownList.SelectedValue == "VND")
            {
                VendorBLL vendorBll = new VendorBLL();
                DataTable dt = new DataTable();
                dt = vendorBll.GetVendorList();
                vendorGridView.Visible = true;
                customerListGridView.Visible = false;
                companyGridView.Visible = false;
                NumberDiv.Visible = false;
                vendorGridView.DataSource = dt;
                vendorGridView.DataBind();

                if (vendorGridView.Rows.Count > 0)
                {
                    vendorGridView.UseAccessibleHeader = true;
                    vendorGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            else if (selectDropDownList.SelectedValue == "COM")
            {
                CompanyBLL companyBll = new CompanyBLL();
                DataTable dt = new DataTable();
                dt = companyBll.GetActiveCompany();
                companyGridView.Visible = true;
                customerListGridView.Visible = false;
                vendorGridView.Visible = false;
                NumberDiv.Visible = false;
                companyGridView.DataSource = dt;
                companyGridView.DataBind();

                if (companyGridView.Rows.Count > 0)
                {
                    companyGridView.UseAccessibleHeader = true;
                    companyGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            else
            {
                customerListGridView.Visible = false;
                vendorGridView.Visible = false;
                companyGridView.Visible = false;
                NumberDiv.Visible = true;
            }
        }
    }
}