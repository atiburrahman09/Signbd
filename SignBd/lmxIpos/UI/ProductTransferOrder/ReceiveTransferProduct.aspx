﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ReceiveTransferProduct.aspx.cs" Inherits="lmxIpos.UI.ProductTransferOrder.ReceiveTransferProduct" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-9">
                    <i>&#xf132;</i>Product Transfer Receive<span>Product Transfer Receive</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Product Transfer Receive</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Requisition Type</h5>
                                <asp:DropDownList ID="drpdwnRequisationTo" runat="server" required="required" OnSelectedIndexChanged="transferTypeDropDownList_SelectedIndexChanged" AutoPostBack="True"
                                    CssClass="form form-full">
                                    <asp:ListItem Value="">Select Please...</asp:ListItem>
                                    <asp:ListItem Value="WH-SC">Warehouse to Salse Center</asp:ListItem>
                                    <%--<asp:ListItem Value="SC-SC">Salse Center to Salse Center</asp:ListItem>--%>
                                    <asp:ListItem Value="SC-WH">Salse Center to Warehouse</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Requisation of (SC/WH)</h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="orderListButton" runat="server" Text="Get Transfer List" CssClass="btn btn-info"
                                    OnClick="orderListButton_Click" />
                            </div>
                        </div>
                        <div class="grid-12">
                            <div id="transferOrderListGridContainer">
                                <asp:GridView ID="transferOrderListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="TransferOrderId" HeaderText="Transfer Order ID" />
                                        <asp:BoundField DataField="OrderDate" HeaderText="Transfer Order Date" />
                                        <asp:BoundField DataField="RequisitionId" HeaderText="Requisition ID" />
                                        <asp:BoundField DataField="RequisitionDate" HeaderText="Requisition Date" />
                                        <asp:BoundField DataField="TransferType" HeaderText="Transfer Type" />
                                        <asp:BoundField DataField="TransferFromName" HeaderText="Transfer From (WH/SC)" />
                                        <asp:BoundField DataField="TransferToName" HeaderText="Transfer To (WH/SC)" />
                                        <asp:BoundField DataField="Status" HeaderText="Transfer Status" />
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
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="orderListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="transferOrderListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#transferOrderListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [8] }]
            });

            $("#orderListButton").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
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
