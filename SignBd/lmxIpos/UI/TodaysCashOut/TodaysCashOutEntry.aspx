﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="TodaysCashOutEntry.aspx.cs" Inherits="lmxIpos.UI.TodaysCashOut.TodaysCashOutEntry" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Todays Cash Out<span>Todays Cash Out Entry</span></h1>
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
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Todays Cash Out Entry Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Entry Date</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="entryDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Amount</h5>
                                <asp:TextBox ID="amountTextBox" required="required" pattern='^[1-9]\d*(((,\d{3}){1})?(\.\d{0,2})?)$' placeholder="0.00" runat="server"
                                    CssClass="form form-full"></asp:TextBox>

                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Account Head</h5>
                                <asp:DropDownList ID="accountHeadDropDownList" runat="server" CssClass="form form-full chosen-select"
                                    required="required">
                                    <asp:ListItem Text="Select an option" Value=""></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Narration</h5>
                                <asp:TextBox ID="narrationTextBox" required="required" placeholder="Narration" runat="server"
                                    CssClass="form form-full"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        <asp:Label runat="server" Text="Business Name" ID="titleSalesCenterOrWarehouse"></asp:Label>
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnSalesCenterOrWarehouse" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });
            //$("#accountHeadDropDownList").rules("add", {
            //    required: true
            //});

            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 20 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "96%" }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
            $("#saveButton").click(function (e) {
                if (Page_ClientValidate()) {
                    if (haveOverlay == 0) {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
</asp:Content>
