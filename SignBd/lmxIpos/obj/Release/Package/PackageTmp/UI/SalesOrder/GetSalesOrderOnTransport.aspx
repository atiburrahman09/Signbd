﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="GetSalesOrderOnTransport.aspx.cs" Inherits="lmxIpos.UI.SalesOrder.GetSalesOrderOnTransport" EnableEventValidation="false" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/GetSalesOrderOnTransport.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-7">
                    <i>&#xf132;</i>Get Sales Order On Transport<span>Get Sales Order On Transport List</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">System of Get Sales Order On Transport</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sales Center Name</h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-4" style="margin-top: 29px;">
                                <asp:Button ID="pendingOrderListButton" runat="server" Text="Get Pending Order List"
                                    CssClass="btn btn-info" OnClick="pendingOrderListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <div id="pendingSalesOrderListGridContainer">
                                <asp:GridView ID="pendingSalesOrderListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="SalesOrderId" HeaderText="SO ID" />
                                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                        <asp:BoundField DataField="CustomerId" HeaderText="Cst. ID" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Cst. Name" />
                                        <asp:BoundField DataField="SalesPersonId" HeaderText="SP ID" />
                                        <asp:BoundField DataField="SalesPersonName" HeaderText="SP Name" />
                                        <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info"
                                                    Width="105" OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                                <asp:LinkButton ID="setOnTransportLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                                    Width="105" OnClientClick="return confirm('Do you want to set this Sales Order on transport?');"
                                                    OnClick="setOnTransportLinkButton_Click">Set On Transport</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="pendingOrderListButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#pendingSalesOrderListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [7] }]
            });
        });
    </script>
</asp:Content>
