﻿using System;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Lumex.Tech;
using CrystalDecisions.Web;

namespace lmxIpos
{
    public partial class ReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string reportName = (string)LumexSessionManager.Get("rptName");

                ReportDocument reportDocument = (ReportDocument)LumexSessionManager.Get("ReportData");
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, reportName);
                //reportDocument.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, Page.Title);

                //// Apply the page margins.
                //reportDocument.PrintOptions.ApplyPageMargins(margins);

                //// Select the printer.
                //reportDocument.PrintOptions.PrinterName = ;

                //// Print the report. Set the startPageN and endPageN
                //// parameters to 0 to print all pages.
                //reportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                //reportDocument.PrintOptions.PaperSize = PaperSize.PaperA5;
                //reportDocument.PrintToPrinter(1, false, 0, 1);
            
            }
            catch (Exception ex)
            {
               //throw
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}