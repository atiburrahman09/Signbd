using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.BankBranch
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
                    GetBankBranchList();
                }

                if (bankBranchListGridView.Rows.Count > 0)
                {
                    bankBranchListGridView.UseAccessibleHeader = true;
                    bankBranchListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                string message = "Somethings goes wrong in Page Load";
                if (ex.InnerException != null) { message += " --> Somethings goes wrong in Page Load"; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetBankBranchList()
        {
            BankBranchBLL bankBranch = new BankBranchBLL();

            try
            {
                DataTable dt = bankBranch.GetBankBranchList();
                bankBranchListGridView.DataSource = dt;
                bankBranchListGridView.DataBind();

                if (bankBranchListGridView.Rows.Count > 0)
                {
                    bankBranchListGridView.UseAccessibleHeader = true;
                    bankBranchListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Branch List Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }
            }
            catch (Exception ex)
            {
                string message = "Somethings goes wrong in get Brach List";
                if (ex.InnerException != null) { message += " --> Somethings goes wrong in get Branch List"; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                bankBranch = null;
            }
        }

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("BankBranchIdForUpdate", bankBranchListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/AccUI/BankBranch/Update.aspx", false);
            }
            catch (Exception ex)
            {
                string message = "Somethings goes wrong in Edit";
                if (ex.InnerException != null) { message += " --> Somethings goes wrong in Edit "; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                BankBranchBLL bankBranch = new BankBranchBLL();
                bankBranch.UpdateBankBranchActivation(bankBranchListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                bankBranchListGridView.Rows[row.RowIndex].Cells[4].Text = "True";
                string message = "Bank Branch <span class='actionTopic'>Activated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = "Somethings goes wrong in Activate";
                if (ex.InnerException != null) { message += " --> Somethings goes wrong in Activate "; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deactivateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                BankBranchBLL bankBranch = new BankBranchBLL();
                bankBranch.UpdateBankBranchActivation(bankBranchListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                bankBranchListGridView.Rows[row.RowIndex].Cells[4].Text = "False";
                string message = "Bank Branch <span class='actionTopic'>Deactivated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = "Somethings goes wrong in Deactivate";
                if (ex.InnerException != null) { message += " --> Somethings goes wrong in Deactivate"; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                BankBranchBLL bankBranch = new BankBranchBLL();
                bankBranch.DeleteBankBranch(bankBranchListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());

                GetBankBranchList();
                string message = "Bank Branch <span class='actionTopic'>Deleted</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = "Somethings goes wrong in Delete";
                if (ex.InnerException != null) { message += " -->Somethings goes wrong in Delete "; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
    }
}