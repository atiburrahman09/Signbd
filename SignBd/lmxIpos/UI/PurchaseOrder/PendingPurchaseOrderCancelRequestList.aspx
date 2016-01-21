<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="PendingPurchaseOrderCancelRequestList.aspx.cs" Inherits="lmxIpos.UI.PurchaseOrder.PendingPurchaseOrderCancelRequestList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/PendingPurchaseOrderCancelRequestList.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Pending Purchase Order Cancel Request List</h1>
            </div>

            <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <h4>
                    <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                </h4>
                <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
            </div>
           
            <div class="widget">
                <div class="widget-body no-padding">
                    <div class="widget-separator no-padding grid-12">

                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">Business Name</h5>
                            <asp:DropDownList ID="warehouseDropDownList" runat="server" CssClass="form form-full"
                                required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">&nbsp;</h5>
                            <asp:Button ID="cancelRequestListButton" runat="server" Text="Get Cancel Request List"
                                CssClass="btn btn-info" OnClick="cancelRequestListButton_Click" />
                        </div>



                        <hr />
                        <div id="purchaseOrderCancelRequestListGridContainer">
                            <asp:GridView ID="purchaseOrderCancelRequestListGridView" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-hover gridView">
                                <Columns>
                                    <asp:BoundField DataField="PurchaseOrderId" HeaderText="PO ID" />
                                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                    <asp:BoundField DataField="PurchaseRequisitionId" HeaderText="PR ID" />
                                    <asp:BoundField DataField="PurchaseRequisitionDate" HeaderText="PR Date" />
                                    <asp:BoundField DataField="WarehouseName" HeaderText="Business Name" />
                                    <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                    <%--<asp:BoundField DataField="Narration" HeaderText="Requisition Narration" />--%>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info"
                                                OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="acceptLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                                OnClick="acceptLinkButton_Click" OnClientClick="return confirm('Are you sure you want to cancel this Order?');">Accept</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="rejectLinkButton" runat="server" CssClass="btn btn-mini btn-danger"
                                                OnClick="rejectLinkButton_Click" OnClientClick="return confirm('Are you sure you want to reject this cancel request?');">Reject</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
            $("#purchaseOrderCancelRequestListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8] }]
            });
        });
    </script>
</asp:Content>
