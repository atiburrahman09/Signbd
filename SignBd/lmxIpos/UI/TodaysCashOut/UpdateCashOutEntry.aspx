﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="UpdateCashOutEntry.aspx.cs" Inherits="lmxIpos.UI.TodaysCashOut.UpdateCashOutEntry" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update Cash Out Entry<span>Updating Cash Out Entry</span></h1>
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
                            Update Cash Out Entry of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label>
                        </h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                             
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        Cash Out Date</h5>
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
                                <h5 class="typo">
                                    Amount</h5>
                                <asp:TextBox ID="amountTextBox" required="required" placeholder="Amount" runat="server"
                                    CssClass="form form-full"></asp:TextBox>
                                <asp:CompareValidator ID="cmpVldCurrency" runat="server" ErrorMessage="*" ControlToValidate="amountTextBox"
                                    ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                    Visible="false"> </asp:CompareValidator>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Account Head</h5>
                                <asp:DropDownList ID="accountHeadDropDownList" runat="server" CssClass="form form-full chosen-select"
                                    required="required">
                                    <asp:ListItem Text="Select an option" Value=""></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Account Id</h5>
                                <asp:TextBox ID="txtbxAccountId" required="required" placeholder="Narration" runat="server"
                                    CssClass="form form-full"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Description</h5>
                                <asp:TextBox ID="txtbxDescription" required="required" placeholder="Narration" runat="server"
                                    CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Narration</h5>
                                <asp:TextBox ID="narrationTextBox" required="required" placeholder="Narration" runat="server"
                                    CssClass="form form-full"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="cashOutEntrySerialForUpdateHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />
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

            $("#updateButton").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
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
        $(function () {

        });
    </script>
</asp:Content>
