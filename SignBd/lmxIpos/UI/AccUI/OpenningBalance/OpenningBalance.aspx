﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="OpenningBalance.aspx.cs" Inherits="lmxIpos.UI.AccUI.OpenningBalance.OpenningBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Openning Balance<span>Creating Opening Balance</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Opening Balance Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Business</h5>
                                <asp:DropDownList ID="warehouseDropDownList" required="required" runat="server" AutoPostBack="True" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <%--  <div class="widget-separator grid-3">
                                <h5 class="typo">Account Head
                                </h5>
                                <asp:DropDownList ID="accountHeadDropDownList" required="required" runat="server"
                                    CssClass="form form-full chosen-select">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Pay To/From
                                </h5>
                                <asp:DropDownList ID="payToFromTypeDropDownList" AutoPostBack="True" runat="server" CssClass="form form-full "
                                    required="required" OnSelectedIndexChanged="payToFromTypeDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select Please</asp:ListItem>
                                    <%-- <asp:ListItem Value="com">Company</asp:ListItem>--%>
                                    <asp:ListItem Value="ven">Vendor</asp:ListItem>
                                    <asp:ListItem Value="cus">Customer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    <asp:Label ID="lblPaytoFromType" runat="server" Text=""></asp:Label>
                                    &nbsp;
                                </h5>
                                <asp:DropDownList ID="payToFromCompanyDropDownList" runat="server" CssClass="form form-full chosen-select"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Amount</h5>
                                <asp:TextBox ID="txtbxAmount" runat="server" CssClass="form form-full" onfocus="this.select()" Text="0.00" placeholder="Amount"></asp:TextBox>
                                <asp:CompareValidator ID="cmpVldCurrency" runat="server" ErrorMessage="*" ControlToValidate="txtbxAmount"
                                    ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                    Visible="false"> </asp:CompareValidator>
                            </div>

                            <%--   <div class="widget-separator grid-3">
                                <h5 class="typo">Debit/Credit
                                </h5>
                                <asp:DropDownList ID="debitCreditDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="Dr">Debit</asp:ListItem>
                                    <asp:ListItem Value="Cr">Credit</asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Debit/Credit
                                </h5>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form form-full">
                                    <asp:ListItem Value="No">None</asp:ListItem>
                                    <asp:ListItem Value="Rec">Receivable</asp:ListItem>
                                    <asp:ListItem Value="Pay">Payable</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="widget-separator grid-3">
                                <h5 class="typo">Naration</h5>
                                <asp:TextBox ID="txtbxNaration" runat="server" CssClass="form form-full" placeholder="Naration"></asp:TextBox>
                            </div>
                            
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Transection Date</h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" runat="server"
                                            data-date-format="dd/mm/yyyy" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-12">
                                <div class="grid-6">
                                    <asp:Button ID="saveButton" runat="server" TabIndex="0" Text="Save" CssClass="btn btn-submit btn-3d"
                                        OnClick="saveButton_OnClick" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
        <Triggers>
            <%--      <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />--%>
            <asp:PostBackTrigger ControlID="saveButton" />
            <%-- <asp:PostBackTrigger ControlID="btnimport" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".date-textbox").datepicker();
            $("#saveButton").click(function (e) {
                $("#accountHeadDropDownList").rules("add", {
                    required: true
                });

                $("#txtbxAmount").rules("add", {
                    required: true,
                    number: true
                });


                $("#payToFromCompanyDropDownList").rules("add", {
                    required: true
                });

                $("#txtbxNaration").rules("add", {
                    required: true
                });
                $("#txtbxTotalTransiction").rules("add", {
                    required: true
                });


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
