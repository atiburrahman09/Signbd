﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.Product.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update Product<span>Updating Product</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Update Product of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Business</h5>
                                <asp:DropDownList ID="warehouseDropDownList" required="required" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="warehouseDropDownList_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Name (Only)</h5>
                                <asp:TextBox ID="productNameOnlyTextBox" runat="server" CssClass="form form-full" placeholder="Product Name" required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Volume</h5>
                                <asp:TextBox ID="productVolumeTextBox" runat="server" CssClass="form form-full" placeholder="Product Volume" required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Per Unit Volume Quantity</h5>
                                <asp:TextBox ID="volumeQuantityTextBox" runat="server" CssClass="form form-full" placeholder="Per Unit Volume Quantity" required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Unit</h5>
                                <asp:TextBox ID="unitTextBox" runat="server" CssClass="form form-full" placeholder="Unit" required="required"></asp:TextBox>
                            </div>
                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">Secondary Unit <span class="text-error">*</span></h5>
                                <asp:TextBox ID="secondaryUnitTextBox" runat="server" CssClass="form form-full" placeholder="ex- Pcs,Kg,gm,Inch"
                                    required="required"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Group</h5>
                                <asp:DropDownList ID="productGroupDropDownList" runat="server" CssClass="form form-full" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Addition</h5>
                                <asp:TextBox ID="txtBxAddition" runat="server" CssClass="form form-full" placeholder="color/size/others"></asp:TextBox>
                            </div>


                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Description</h5>
                                <asp:TextBox ID="txtProductDesc" runat="server" CssClass="form form-full" placeholder="Product Description"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Type<span class="text-error">*</span></h5>
                                <asp:DropDownList ID="productTypeDropDownList" runat="server" required="required"
                                    CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="productTypeDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select....</asp:ListItem>
                                    <asp:ListItem Value="Yes">Main</asp:ListItem>
                                    <asp:ListItem Value="No">Sub</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sub Product Of<span class="text-error">*</span></h5>
                                <div class="input-append form form-full">
                                    <asp:DropDownList ID="subProductDropDownList" runat="server" CssClass="grid-9" required="required">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="Add" OnClick="btnAdd_OnClick" />
                                </div>

                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Main Product List</h5>

                                <asp:ListBox ID="mainProductListListBox" runat="server" CssClass="input-medium form form-full"></asp:ListBox>
                                <asp:Button ID="btnRemove" runat="server" CssClass=" btn btn-error" Text="Remove" OnClick="btnRemove_OnClick" />

                                <asp:Label ID="countProductLabel" runat="server" Text="Total: 0"></asp:Label>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Vendor <span class="text-error">*</span></h5>
                                <asp:DropDownList ID="vendorDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>

                            </div>
                            <div class="widget-separator grid-12">
                                <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                    OnClick="updateButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="productIdForUpdateHiddenField" runat="server" />
                <asp:HiddenField ID="productNameForUpdateHiddenField" runat="server" />
                <asp:HiddenField ID="barcodeForUpdateHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="updateButton" />
            <%--<asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />--%>
             <asp:AsyncPostBackTrigger ControlID="warehouseDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="productGroupDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="subProductDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductBarcodes",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#barcodeTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });

            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductNamesOnly",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#productNameOnlyTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });

            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductVolumes",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#productVolumeTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });

            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductUnits",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#unitTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });
        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $.ajax({
                type: "POST",
                url: "/Services/ProductNameOnly.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productNameOnlyTextBox').typeahead({ source: array });

                }
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductVolumes.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productVolumeTextBox').typeahead({ source: array });

                }
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductsUnits.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#unitTextBox').typeahead({ source: array });

                }
            });

            //$("#updateButton").click(function (e) {
            //    if (Page_ClientValidate("")) {
            //        if (haveOverlay == 0) {
            //            MyOverlayStart();
            //        }
            //    }
            //});
        }
    </script>
</asp:Content>
