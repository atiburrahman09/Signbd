﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="AvailablePrdLstBySC.aspx.cs" Inherits="lmxIpos.ReportUI.AvailablePrdLstBySC" %>

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
                <h1 class="grid-6">
                    <i>&#xf132;</i>Sales Center Stock<span>Viewing Sales Center Stock Report</span></h1>
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
                            Available Stock Report</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                          <%--  <div class="widget-separator no-border grid-2">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        Report On</h5>
                                </div>
                                <div class="grid-12">
                                    <asp:DropDownList ID="drpdwnReportOn" runat="server" CssClass="form form-full" OnSelectedIndexChanged="drpdwnReportOn_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem>Sales Center</asp:ListItem>
                                    <asp:ListItem>Warehouse</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        <asp:Label runat="server" Text="Business" id="titleSalesCenterOrWarehouse"></asp:Label>    
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnSalesCenterOrWarehouse" runat="server" CssClass="form form-full">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        Report On</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnReportOnStock" runat="server" CssClass="form form-full">
                                        <asp:ListItem Value="1">Product wise</asp:ListItem>
                                        <asp:ListItem Value="2">Purchase wise</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-4">
                                <h5 class="typo">
                                    &nbsp;
                                </h5>
                                <asp:Button ID="generateButton" runat="server" Text="Generate Report" CssClass="btn btn-info"
                                    OnClick="generateButton_Click" />
                                <asp:Button ID="exportButton" runat="server" Text="Export Report" CssClass="btn btn-info"
                                    OnClick="exportButton_Click" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
          <%--  <asp:AsyncPostBackTrigger ControlID="drpdwnReportOn" EventName="SelectedIndexChanged" />--%>
            <asp:AsyncPostBackTrigger ControlID="generateButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="exportButton" EventName="Click" />
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
        }
    </script>
</asp:Content>
