﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="CreateCreditVoucherCheque.aspx.cs" Inherits="lmxIpos.UI.AccUI.CreditVoucher.CreateCreditVoucherCheque" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function ExportReportForm() {
            window.open("/ReportExport.aspx", "_blank");
        }
        function ViewReportForm() {
            window.open("/ReportView.aspx", "_blank");
        }
    </script>
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create C.V. Cheque<span>Creating C.V. Cheque</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>IPOS</span><i>/</i></li>
                        <li><a href="/Default.aspx">Dashboard</a></li>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Credit Voucher Cheque Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="grid-12">
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Account Head
                                </h5>
                                <asp:DropDownList ID="accountHeadDropDownList" required="required" runat="server"
                                    CssClass="form form-full chosen-select">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Amount
                                </h5>
                                <asp:TextBox ID="amountTextBox" runat="server" required="required" CssClass="form form-full"></asp:TextBox>
                                <asp:CompareValidator ID="cmpVldCurrency" runat="server" ErrorMessage="*" ControlToValidate="amountTextBox"
                                    ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                    Visible="false"> </asp:CompareValidator>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Bank Account Head
                                </h5>
                                <asp:DropDownList ID="bankAccountHeadDropDownList" required="required" runat="server"
                                    CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Voucher Number
                                </h5>
                                <asp:TextBox ID="voucherNumberTextBox" runat="server" required="required" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Cheque Number
                                </h5>
                                <asp:TextBox ID="chequeNumberTextBox" runat="server" required="required" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Cheque Date
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="chequeDateTextBox" required="required" CssClass="date-textbox cash-cheque form form-full"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Bank
                                </h5>
                                <asp:DropDownList ID="bankDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Bank Branch
                                </h5>
                                <asp:TextBox ID="bankBranchTextBox" required="required" runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Pay To/From
                                </h5>
                                <asp:DropDownList ID="payToFromTypeDropDownList" AutoPostBack="True" runat="server" CssClass="form form-full"
                                    required="required" OnSelectedIndexChanged="payToFromTypeDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select Please</asp:ListItem>
                                    <asp:ListItem Value="com">Company</asp:ListItem>
                                    <asp:ListItem Value="ven">Vendor</asp:ListItem>
                                    <asp:ListItem Value="cus">Customer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    <asp:Label ID="lblPaytoFromType" runat="server" Text=""></asp:Label>
                                </h5>
                                <asp:DropDownList ID="payToFromCompanyDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Narration
                                </h5>
                                <asp:TextBox ID="narrationTextBox" runat="server" required="required" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <%--   <div class="widget-separator grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Account On</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnAccountOn" runat="server" OnSelectedIndexChanged="drpdwnAccountOn_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>Sales Center</asp:ListItem>
                                        <asp:ListItem>Warehouse</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="widget-separator grid-3">
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
                            <%--<div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Sales Center Name
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" required="required" runat="server"
                                    CssClass="form form-full">
                                </asp:DropDownList>
                            </div>--%>
                        </div>
                        <div class="widget-separator grid-12">
                            <div class="grid-2">
                                Amount in Word:
                            </div>
                            <div class="grid-10">
                                <asp:Label ID="Label1" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d" CommandArgument="1"
                                OnClick="saveButton_Click" />
                            <asp:Button ID="saveandprintButton" runat="server" Text="Save And Print" CssClass="btn btn-info btn-3d" CommandArgument="2"
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
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $("#saveButton").click(function (e) {
                $("#accountHeadDropDownList").rules("add", {
                    required: true
                });

                $("#amountTextBox").rules("add", {
                    required: true,
                    number: true
                });

                $("#bankAccountHeadDropDownList").rules("add", {
                    required: true
                });

                $("#voucherNumberTextBox").rules("add", {
                    required: true
                });

                $("#chequeNumberTextBox").rules("add", {
                    required: true
                });

                $("#chequeDateTextBox").rules("add", {
                    required: true
                });

                $("#bankDropDownList").rules("add", {
                    required: true
                });

                $("#bankBranchTextBox").rules("add", {
                    required: true
                });

                $("#payToFromCompanyDropDownList").rules("add", {
                    required: true
                });

                $("#narrationTextBox").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
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
        }
    </script>
</asp:Content>
