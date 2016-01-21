﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="RetailSales.aspx.cs" Inherits="lmxIpos.UI.Sales.RetailSales" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/content/css/pagecss/retailsales.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Retail Sales<span>Creating Sales Record</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Sales Record <%--Form
                            <asp:Label CssClass="text-success" ID="lblSalesCenterName" runat="server" Text="Label"></asp:Label>--%></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <%-- <div class="widget-separator no-border grid-3">
                                <asp:DropDownList ID="ddlWHorSC" runat="server" CssClass="form form-full" required="required" OnSelectedIndexChanged="ddlWHorSC_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Sales Center" Value="SC"></asp:ListItem>
                                    <asp:ListItem Text="WareHouse" Value="WH"></asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <asp:DropDownList ID="ddlSelectWareHouseOrSalesCenter" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectWareHouseOrSalesCenter_SelectedIndexChanged" runat="server" CssClass="form form-full" required="required">
                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <%--<h5 class="typo">
                                    Product By [Barcode, ID, Name]</h5>--%>
                                <asp:TextBox ID="productTextBox" runat="server" CssClass="form form-full" placeholder="Product By [Barcode, ID, Name]"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <asp:Button ID="addProductButton" CssClass="btn btn-info" runat="server" Text="Add Product"
                                    OnClick="addProductButton_Click" />
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="selectedProductListGridContainer" style="font-size: 12px;">
                                <asp:GridView ID="selectedProductListGridView" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-hover gridView responsive">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Barcode" HeaderText="Barcode" />--%>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />

                                        <%-- <asp:BoundField DataField="FreeQuantity" HeaderText="Available" HtmlEncode="False" HtmlEncodeFormatString="False" />--%>
                                        <asp:TemplateField HeaderText="Height">
                                            <ItemTemplate>
                                                <asp:TextBox ID="heightTextBox" runat="server" Width="40" Text='<%# Eval("Height") %>' CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Width">
                                            <ItemTemplate>
                                                <asp:TextBox ID="WidthTextBox" runat="server" Text='<%# Eval("Width") %>' Width="40" CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="UnitTextBox" runat="server" Text='<%# Eval("OrderUnit") %>' Width="40" CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Qty.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="totalUnitTextBox" runat="server" Text='<%# Eval("TotalUnit") %>' Width="40" CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Qty.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="orderQuantityTextBox" runat="server" Text='<%# Eval("OrderQuantity") %>' Width="40" CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="ratePerUnitTextBox" runat="server" Text='<%# Eval("RatePerUnit") %>' Width="40" CssClass="oQty-rpu-amt-cal autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VAT(%)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVatparcentage" runat="server" Text='<%# Eval("VATPercentage") %>' CssClass="form form-full"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Amount +VAT">
                                            <ItemTemplate>
                                                <asp:TextBox ID="amountTextBox" runat="server" Text='<%# Eval("Amount") %>' Width="50" CssClass="read-only autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="removeLinkButton" runat="server"
                                                    CssClass="btn btn-mini btn-inverse" OnClick="removeLinkButton_Click" Style="align: center;" ToolTip="Remove"><i class="icon icon-trash icon-2x" style="color:#f00;"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator no-padding grid-12">
                            <div class="grid-6" style="float: right;">
                                <div class="widget-separator grid-12">
                                    <h4 class="typo">Payment Information</h4>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="widget-separator no-border grid-6">
                                        <h5 class="typo">Payment Mode</h5>
                                        <asp:DropDownList ID="paymentModeDropDownList" runat="server" AutoPostBack="true" CssClass="form form-full" OnSelectedIndexChanged="paymentModeDropDownList_SelectedIndexChanged">
                                            <asp:ListItem Text="--select Payment Method--" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                            <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="widget-separator no-border grid-6">
                                        <h5 class="typo">Account Head
                                        </h5>
                                        <asp:DropDownList ID="accountHeadDropDownList" runat="server" CssClass="form form-full">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="widget-separator no-border grid-6">
                                        <h5 class="typo">Bank Name</h5>
                                        <asp:TextBox ID="bankDropDownList" runat="server" CssClass="cash-cheque form form-full" Enabled="false" placeholder="Bank Name">
                                        </asp:TextBox>
                                    </div>
                                    <div class="widget-separator no-border grid-6">
                                        <h5 class="typo">Bank Branch</h5>
                                        <asp:TextBox ID="bankBranchTextBox" runat="server" placeholder="Bank Branch" CssClass="form form-full autoCompeleteOff" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="widget-separator no-border grid-6">
                                        <h5 class="typo">Cheque Number</h5>
                                        <asp:TextBox ID="chequeNumberTextBox" runat="server" placeholder="Cheque Number" CssClass="form form-full autoCompeleteOff" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="widget-separator no-border grid-6">
                                        <h5 class="typo">Cheque Date</h5>
                                        <asp:TextBox ID="chequeDateTextBox" runat="server" placeholder="Cheque Date" CssClass="date-textbox form form-full autoCompeleteOff" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-7">
                                        <h5 class="typo" style="float: right;">Total&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-3">
                                        <asp:TextBox ID="totalAmountTextBox" CssClass="read-only form form-full" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-2">
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ControlToValidate="totalAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-7">
                                        <h5 class="typo" style="float: right;">Discount &nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-3">
                                        <asp:TextBox ID="discountTextBox" CssClass="form form-full autoCompeleteOff" PlaceHolder="0.00"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-2">
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToValidate="receivedAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-7">
                                        <h5 class="typo" style="float: right;">VAT (%)&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-3">
                                        <asp:TextBox ID="vatTextBox" CssClass="form form-full autoCompeleteOff" PlaceHolder="VAT (%)"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-2">
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" ControlToValidate="receivedAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" ControlToValidate="receivedAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-7">
                                        <h5 class="typo" style="float: right;">Receivable&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-3">
                                        <asp:TextBox ID="receivableAmountTextBox" CssClass="form form-full read-only autoCompeleteOff"
                                            PlaceHolder="0.00" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-2">
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="receivableAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red" Display="Dynamic"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-7">
                                        <h5 class="typo" style="float: right;">Received&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-3">
                                        <asp:TextBox ID="receivedAmountTextBox" CssClass="form form-full autoCompeleteOff"
                                            PlaceHolder="0.00" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-2">
                                        <asp:CompareValidator ID="cmpVldCurrency" runat="server" ErrorMessage="*" ControlToValidate="receivedAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <%--  <div class="widget-separator no-border grid-12">
                                    <div class="grid-7">
                                        <h5 class="typo" style="float: right;">Dues Pay&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-3">
                                        <asp:TextBox ID="DuesAmoutPayTextBox" ReadOnly="True" CssClass="form form-full autoCompeleteOff"
                                            PlaceHolder="0.00" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-2">
                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" ControlToValidate="DuesAmoutPayTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>--%>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-7">
                                        <h5 class="typo" style="float: right;">Change&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-3">
                                        <asp:TextBox ID="changeAmountTextBox" ForeColor="red" Font-Size="14px" CssClass="read-only form form-full text-error bold"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-2">
                                        &nbsp;
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6" style="float: left;">
                                <div class="widget-separator grid-12">
                                    <div class="grid-8">
                                        <h4 class="typo">Customer Information</h4>
                                    </div>
                                    <%-- <div class="grid-3">
                                        <asp:Button ID="addCustomerButton" CssClass="btn btn-info" runat="server" Text="Customer from List"
                                            OnClientClick="return false" />
                                    </div>--%>
                                </div>
                                <div class="grid-12" style="border-right: 1px solid #ECECEC;">
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer ID</h5>
                                        <asp:DropDownList ID="customerIdDropDownList" runat="server" CssClass="form form-full chosen-select"
                                            OnSelectedIndexChanged="customerIdDropDownList_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer Name</h5>
                                        <asp:TextBox ID="customerNameTextBox" runat="server" CssClass="customerInfo form form-full"
                                            placeholder="Customer Name"></asp:TextBox>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer Contact Number</h5>
                                        <asp:TextBox ID="customerContactNumberTextBox" runat="server" CssClass="customerInfo form form-full"
                                            placeholder="Customer Contact Number"></asp:TextBox>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer Address</h5>
                                        <asp:TextBox ID="customerAddressTextBox" runat="server" CssClass="customerInfo form form-full"
                                            placeholder="Customer Address"></asp:TextBox>
                                    </div>
                                    <div class="grid-12" id="previousDueDiv" runat="server" visible="false">
                                        <div class="widget-separator grid-6">
                                            <h5 class="typo">Previous Due</h5>
                                            <asp:TextBox ID="previousDueTextBox" runat="server" CssClass="form form-full text-error bold"
                                                placeholder="Previous Due" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="widget-separator grid-6" style="padding: 24px 50px;">

                                            <asp:Button ID="btnGOtoReceivePaymetn" OnClick="gotoRecievepayment" OnClientClick="window.open('/UI/ReceiveFromCustomer/PaymentByCustomer.aspx')" CssClass="btn btn-mini btn-info " runat="server" Text="Receive Due Amount" />
                                            <%--  <a href="/UI/ReceiveFromCustomer/PaymentByCustomer.aspx" target="_blank" class="label label-info text-center">Receive Payment </a>
                                            --%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="grid-12 text-center">
                            <%--<div class="grid-5">
                                &nbsp;
                            </div>--%>
                            <%--<div class="widget-separator no-border grid-2">--%>
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-3d btn-large" Enabled="false"
                                runat="server" Text="Confirm Sales Create" OnClick="saveButton_Click" ValidationGroup="2" />
                            <%--  </div>--%>
                            <%--<div class="grid-5">
                                &nbsp;
                            </div>--%>
                        </div>
                        <div id="productListModal" class="modal hide fade" style="width: 780px;" tabindex="-1"
                            role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Available Product List
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="productListGridContainer">
                                    <asp:GridView ID="productListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover">
                                        <Columns>
                                            <%--<asp:BoundField DataField="Barcode" HeaderText="Barcode" />--%>
                                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                            <asp:BoundField DataField="ProductGroupName" HeaderText="Product Group" />
                                            <asp:BoundField DataField="FreeQuantity" HeaderText="Free Qty" HtmlEncode="False" HtmlEncodeFormatString="False" />
                                            <asp:BoundField DataField="Price" HeaderText="Sale Rate" />
                                            <asp:BoundField DataField="VATPercentage" HeaderText="VAT(%)" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="allCheckBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="selectCheckBox" runat="server" CssClass="clickCheckBox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="addSelectedProductButton" runat="server" CssClass="btn btn-success"
                                    Text="Add Selected Product(s)" OnClick="addSelectedProductButton_Click" />
                            </div>
                        </div>
                        <div id="customerListModal" class="modal hide fade" style="width: 780px;" tabindex="-1"
                            role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Customer List
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="customerListGridContainer">
                                    <asp:GridView ID="customerListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" HtmlEncodeFormatString="True" />
                                            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" HtmlEncodeFormatString="True" />
                                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" HtmlEncodeFormatString="True" />
                                            <%--<asp:BoundField DataField="Email" HeaderText="Email" />--%>
                                            <asp:BoundField DataField="Address" HeaderText="Address" HtmlEncodeFormatString="True" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="selectCustomerLinkButton" runat="server" CssClass="btn btn-info btn-flat-3d"
                                                        OnClick="selectCustomerLinkButton_Click">Select</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="selectedProductListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="customerListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="customerIdDropDownList" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="totalVATAmountHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            var checkedRowCount = $("#checkedRowCountHiddenField").val();
            $('.modal-backdrop').remove();

            if ($("#customerIdDropDownList option:selected").text() != "Retail") {
                $(".customerInfo").attr("disabled", true);
            }

            $(".read-only").attr("ReadOnly", true);
            $(".autoCompeleteOff").attr('autocomplete', 'off');

            //$("#addSelectedProductButton").click(function () {
            //    $("#checkedRowCountHiddenField").val(checkedRowCount);
            //    $("#form1").validate().currentForm = "";
            //});

            $("#addProductButton").click(function () {
                $('input, select, textarea').each(function () {
                    $(this).rules('remove');
                });
            });

            $(".validQty").on("change keyup", function () {
                if ($(this).val() != "" && !isNaN($(this).val()) && ($(this).val() == parseFloat($(this).val())) && $(this).val() > 0) {
                    $(this).removeClass("validGridControl");
                } else {
                    $(this).addClass("validGridControl");
                }
            });

            $("#saveButton").click(function (e) {
                var countGridValid = 0;

                $("#productTextBox").rules("remove");

                $(".validQty").each(function () {
                    if ($(this).val() == "" || isNaN($(this).val()) || ($(this).val() != parseFloat($(this).val())) || $(this).val() < 1) {
                        $(this).addClass("validGridControl");
                        countGridValid++;
                    }
                });

                if (countGridValid > 0) {
                    //return false;
                    e.preventDefault();
                    $("#form1").valid();
                    alert('Some required field(s) are left blank or invalid inside the Product List table, please follow the field(s).');

                    $("html, body").animate({
                        scrollTop: $("#selectedProductListGridContainer").offset().top - 150
                    }, 500);
                }
            });

            $("#customerIdDropDownList").on("change", function () {
                if ($("#customerIdDropDownList option:selected").text() != "Retail") {
                    $(".customerInfo").attr("disabled", true);
                } else {
                    $(".customerInfo").removeAttr("disabled");
                }
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductSearchforSale.ashx?id=" + $('#ddlSelectWareHouseOrSalesCenter').val(),
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productTextBox').typeahead({ source: array });

                }
            });

            $("#selectedProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, -1], [10, 15, 20, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": false
            });

            $("#customerListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": true,
                "bInfo": false,
                "bState": true
            });

            $("#selectedProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#addFromListButton").click(function () {
                $('#productListModal').modal();
            });

            $("#addCustomerButton").click(function () {
                $('#customerListModal').modal();
            });

            $("#productListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[-1], ["All"]],
                "iDisplayLength": -1,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6, 7] }],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

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

            ////////////////////////// Calculation ////////////////////////////////

            function TotalAmountCalculation() {
                var tAmt = 0;
                $("#selectedProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val())) {
                        tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    }
                });
                $("#totalAmountTextBox").val(tAmt);
            }

            function OthersCalculation() {
                var netAmt = 0;
                var totalAmt = 0;
                var discount = 0;
                var vat = 0;
                var receivable = 0;
                var received = 0;
                var due = 0;
                var change = 0;
                var proheight = 0;
                var prowidth = 0;
                var OrderUnit = 0;
                var Totalunit = 0;

                if (!isNaN(+$("#totalAmountTextBox").val())) {
                    totalAmt = $("#totalAmountTextBox").val();
                }

                if (!isNaN(+$("#discountTextBox").val())) {
                    discount = $("#discountTextBox").val();
                }

                if (!isNaN(+$("#vatTextBox").val())) {
                    vat = $("#vatTextBox").val();
                }

                if (!isNaN(+$("#receivableAmountTextBox").val())) {
                    receivable = $("#receivableAmountTextBox").val();
                }

                if (!isNaN(+$("#receivedAmountTextBox").val())) {
                    received = $("#receivedAmountTextBox").val();
                }

                if (!isNaN(+$("#DuesAmoutPayTextBox").val())) {
                    due = $("#DuesAmoutPayTextBox").val();
                }

                if (!isNaN(+$("#changeAmountTextBox").val())) {
                    change = $("#changeAmountTextBox").val();
                }

                netAmt = totalAmt - discount;
                receivable = netAmt + (netAmt * vat / 100);


                $("#totalVATAmountHiddenField").val(netAmt * vat / 100);
                $("#receivableAmountTextBox").val(receivable);
                $("#changeAmountTextBox").val(received - receivable);

                //if (due > 0 && due <= change) {
                $("#changeAmountTextBox").val((received - receivable) - due);
                //}
                //$("#changeAmountTextBox").val(received - inTotal);

                $("#vatTextBox").val(vat);
                $("#discountTextBox").val(discount);
            }

            $("#discountTextBox").on("change keyup", function () {
                OthersCalculation();
            });

            $("#vatTextBox").on("change keyup", function () {
                OthersCalculation();
            });

            $("#receivableAmountTextBox").on("change keyup", function () {
                OthersCalculation();
            });

            $("#receivedAmountTextBox").on("change keyup", function () {
                OthersCalculation();
            });

            $("#DuesAmoutPayTextBox").on("change keyup", function () {
                OthersCalculation();
            });


            $(".oQty-rpu-amt-cal").on("change keyup", function () {

                var proheight = +$(this).closest('tr').find("[id*=heightTextBox]").val();
                var prowidth = +$(this).closest('tr').find("[id*=WidthTextBox]").val();
                var orderunit = +$(this).closest('tr').find("[id*=UnitTextBox]").val();
                var totalunit = 0;
                if (parseFloat(proheight) > 0 || parseFloat(prowidth) > 0) {
                    var totalunit = (proheight * prowidth) * orderunit;
                } else {
                    var totalunit = orderunit;
                }


                $(this).parent().parent().find("[id*=totalUnitTextBox]").val(totalunit);

                var qty = +$(this).closest('tr').find("[id*=orderQuantityTextBox]").val();
                // alert(proheight + ' ' + prowidth + ' ' + orderunit + ' ' + totalunit + ' ' + qty);
                //console.log(qty);
                //new code added for getting total Unit



                // console.log(totalUnit);


                // var avialableQty = $(this).parents().closest('tr').find('td:nth-child(3)').html();


                <%--if (qty > avialableQty) {
                    $('#<%=msgbox.ClientID%>').show();
                    $('#<%=msgbox.ClientID%>').addClass("alert alert-error");
                    $('#<%=msgTitleLabel.ClientID%>').html("Warning !!!");
                    $('#<%=msgTitleLabel.ClientID%>').html("Product Is Not much Avaialable");


                    $('#orderQuantityTextBox').val(avialableQty);
                } else {--%>
                var rate = +$(this).closest('tr').find("[id*=ratePerUnitTextBox]").val();

                // var vat = $(this).parents().closest('tr').find('td:nth-child(8)').html();
                var vat = +$(this).closest('tr').find("[id*=lblVatparcentage]").val();
                var amt = qty * rate;
                var amt = amt + (amt * vat / 100);
                $(this).parent().parent().find("[id*=amountTextBox]").val(amt);


                TotalAmountCalculation();
                OthersCalculation();
                // }

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

        };

    </script>
</asp:Content>
