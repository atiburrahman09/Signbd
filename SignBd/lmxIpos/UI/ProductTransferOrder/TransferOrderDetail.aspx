﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="TransferOrderDetail.aspx.cs" Inherits="lmxIpos.UI.ProductTransferOrder.TransferOrderDetail" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Product Transfer Order<span>Product Transfer Order of System</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Product Transfer Order of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding no-border grid-12">
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Order Date:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="orderDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Transfer Type:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="transferTypeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-5">
                                    Transfer From ID & Name:
                                </div>
                                <div class="grid-7">
                                    <asp:Label ID="transferFromIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    <asp:Label ID="transferFromNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Transfer To ID & Name:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="transferToIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    <asp:Label ID="transferToNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Narration:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Status:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Requisition ID:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="requisitionIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Requisition Date:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="requisitionDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Transport Date:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="transportDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Description:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="descriptionLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="grid-12">
                            <div id="productTransferOrderProductListGridContainer">
                                <asp:GridView ID="productTransferOrderProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="RequisitionQuantityUnit" HeaderText="Reqi. Qty" />
                                        <asp:BoundField DataField="ApprovedQuantityUnit" HeaderText="Aprv. Qty" />
                                        <%--  <asp:BoundField DataField="FreeQuantityWasUnit" HeaderText="Free Quantity Was" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-6" style="margin-top: 29px;">
                            <asp:Button ID="orderReceivedButton" runat="server" Text="Order Received" CssClass="btn btn-3d btn-info"
                                OnClick="orderReceivedButton_Click" />
                            <%--  <asp:Button ID="orderRejectButton" runat="server" Text="Order Reject" CssClass="btn btn-3d btn-error" />--%>
                        </div>
                        <asp:HiddenField ID="transferRequisitionIdForViewHiddenField" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#productTransferOrderProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': []}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#productTransferOrderProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
