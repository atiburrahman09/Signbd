﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ListView.aspx.cs" Inherits="lmxIpos.UI.SalesPerson.ListView" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/SalesPersonList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Sales Person List View<span>Created Sales Person List View</span></h1>
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
                            </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                            Sales Person List View of System</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-border">
                            <div id="salesPersonListGridContainer" >
                                <asp:GridView ID="salesPersonListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="SalesPersonId" HeaderText="Sales Person ID" />
                                        <asp:BoundField DataField="SalesPersonName" HeaderText="Sales Person Name" />
                                        <asp:BoundField DataField="WorkingSalesCenterName" HeaderText="Working Sales Center" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info clickProcessing"
                                                    OnClick="viewLinkButton_Click">View</asp:LinkButton>
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
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#salesPersonListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5]}]
            });

            $(".clickProcessing").live("click", function () {
                MyOverlayStart();
            });
        });
    </script>
</asp:Content>
