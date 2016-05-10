<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="CustomerDueAmount.aspx.cs" Inherits="lmxIpos.ReportUI.CustomerDueAmount"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function ExportReportForm() {
            window.open("/ReportExport.aspx", "_blank");
        }
        function ViewReportForm() {
            window.open("/ReportView.aspx", "_blank");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Customer Due Amount<span>Viewing Customer Due Amount Report</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>Acura</span><i>/</i></li>
                        <li><a href="Default.aspx">Dashboard</a></li>
                    </ul>--%>
                </div>
            </div>
            <div class="data">
                <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                    <button type="button" class="close" data-dismiss="alert">
                        &times;</button>
                    <h4>
                        <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                    </h4>
                    <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="widget">
                    <header class="widget-header">
                        <div class="widget-header-icon">
                            </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                            System Vendor Receive Payment Report</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                           <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        <asp:Label runat="server" Text="Business Center" ID="titleSalesCenterOrWarehouse"></asp:Label>
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            <div class="widget-separator no-border grid-4" style="margin-top: 29px;">
                                <asp:Button ID="generateButton" runat="server" Text="Generate Report" CssClass="btn btn-info"
                                    OnClick="generateButton_Click" />
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            
            <asp:AsyncPostBackTrigger ControlID="generateButton" EventName="Click" />
           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#generateButton, #exportButton").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 20 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "96%" }
            };
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
        }
    </script>
</asp:Content>
