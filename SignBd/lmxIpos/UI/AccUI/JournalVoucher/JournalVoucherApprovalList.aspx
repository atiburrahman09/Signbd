﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="JournalVoucherApprovalList.aspx.cs" Inherits="lmxIpos.UI.AccUI.JournalVoucher.JournalVoucherApprovalList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-7">
                    <i>&#xf132;</i>Journal Voucher Approval List<span>Approval Journal Voucher List</span></h1>
                <div class="sitemap grid-6">
                    <%--  <ul>
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
                            </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                            System Journal Voucher Approval List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        Account On</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnAccountOn" runat="server" OnSelectedIndexChanged="drpdwnAccountOn_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <%--<asp:ListItem>Sales Center</asp:ListItem>--%>
                                        <asp:ListItem>Business</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        <asp:Label runat="server" Text="Business Center Name" ID="titleSalesCenterOrWarehouse"></asp:Label>
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnSalesCenterOrWarehouse" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-4" style="margin-top: 27px;">
                                <asp:Button ID="GetListButton" runat="server" Text="Get Jurnal Voucher List" CssClass="btn btn-info"
                                    OnClick="GetListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="voucherListGridContainer">
                                <asp:GridView ID="voucherListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="JournalNumber" HeaderText="Journal" />
                                        <asp:BoundField DataField="TransactionDate" HeaderText="Date" />
                                        <asp:BoundField DataField="AccountHead" HeaderText="Account Head" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="CounterAccountHead" HeaderText="Counter Head" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allCheckBox" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="selectCheckBox" runat="server" CssClass="clickCheckBox" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-success clickProcessing"
                                                    OnClick="viewLinkButton_Click">View to...</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="approveButton" runat="server" Text="Approve Voucher(s)" CssClass="btn btn-success"
                                Enabled="false" OnClick="approveButton_Click" />
                            <asp:Button ID="rejectButton" runat="server" Text="Reject Voucher(s)" CssClass="btn btn-danger"
                                Enabled="false" OnClick="rejectButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GetListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="approveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="rejectButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            var checkedRowCount = 0;
            $(":checkbox").prop("autocomplete", "off");

            $("#voucherListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#voucherListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#allCheckBox").click(function () {
                if ($(this).is(":checked")) {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', true);
                    checkedRowCount = $(".clickCheckBox").length;
                } else {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', false);
                    checkedRowCount = 0;
                }
            });

            $(".clickCheckBox").click(function () {
                if ($(this).find("#selectCheckBox").is(":checked")) {
                    checkedRowCount++;
                    if (checkedRowCount == $(".clickCheckBox").length) {
                        $("#allCheckBox").prop('checked', true);
                    }
                } else {
                    checkedRowCount--;
                    $("#allCheckBox").prop('checked', false);

                    if (checkedRowCount < 1) {
                        checkedRowCount = 0;
                    }
                }
            });

            $("#approveButton, #rejectButton").click(function (e) {
                if (checkedRowCount < 1) {
                    WarningAlert("Data Selection", "Select Voucher(s) to Approve or Reject.", "");
                    e.preventDefault();
                } else {
                    if (haveOverlay == 0) {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        });
    </script>
</asp:Content>
