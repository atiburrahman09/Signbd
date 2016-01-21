﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="CreatePurchase.aspx.cs" Inherits="lmxIpos.UI.PurchaseToWH.CreatePurchase" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Business Purchase Record Form<span>Creating Business Purchase Record</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Business Purchase Record Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Business Name
                                </h5>
                                <asp:DropDownList ID="warehouseDropDownList" required="required" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="warehouseDropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product By [Barcode, ID, Name]
                                </h5>
                                <asp:TextBox ID="productTextBox" runat="server" CssClass="form form-full" placeholder="Product By [Barcode, ID, Name]"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 28px;">
                                <asp:Button ID="addProductButton" CssClass="btn btn-info" runat="server" Text="Add Product"
                                    OnClick="addProductButton_Click" />
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                        </div>
                        <div class="widget-separator">
                            <h4>Purchase Information</h4>
                        </div>
                        <div class="grid-12">
                            <div id="purchaseProductListGridContainer">
                                <asp:GridView ID="purchaseProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Barcode" HeaderText="Barcode" />--%>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="quantityTextBox" Width="80" runat="server" CssClass="pQty-rpu-amt-cal"
                                                    Text="1"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate Per Unit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="ratePerUnitTextBox" Width="80" CssClass="pQty-rpu-amt-cal" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="amountTextBox" Width="80" CssClass="amt-cal" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Price">
                                            <ItemTemplate>
                                                <asp:TextBox ID="unitPriceTextBox" Width="80" CssClass="read-only" runat="server"></asp:TextBox>
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
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Total Amount
                                </h5>
                                <asp:TextBox ID="totalAmountTextBox" CssClass="read-only form form-full" runat="server"
                                    placeholder="Total Amount"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Discount
                                </h5>
                                <asp:TextBox ID="discountTextBox" runat="server" CssClass="form form-full" AutoPostBack="true"
                                    OnTextChanged="discountTextBox_TextChanged" placeholder="Discount" Text="0.00"
                                    onfocus="this.select()"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Total Payable
                                </h5>
                                <asp:TextBox ID="totalPayableTextBox" runat="server" CssClass="read-only text-error form form-full"
                                    placeholder=""></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Transport Cost
                                </h5>
                                <asp:TextBox ID="transportCostTextBox" runat="server" AutoPostBack="true" OnTextChanged="transportCostTextBox_TextChanged"
                                    CssClass="form form-full" placeholder="Transport Cost" Text="0.00" onfocus="this.select()"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Paid Amount
                                </h5>
                                <asp:TextBox ID="paidAmountTextBox" onfocus="this.select()" runat="server" CssClass="form form-full"
                                    placeholder="Paid Amount" Text="0.00"></asp:TextBox>
                            </div>
                        
                        
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Vendor Name
                                </h5>
                                <asp:DropDownList ID="vendorDropDownList" runat="server" required="required" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Vendor Order Date</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="vendorOrderDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Vendor Order Number
                                </h5>
                                <asp:TextBox ID="vendorOrderNumberTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Vendor Order Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Vendor Invoice Number
                                </h5>
                                <asp:TextBox ID="vendorInvoiceNumberTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Vendor Invoice Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Received Date
                                </h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="receivedDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Transport Type
                                </h5>
                                <asp:DropDownList ID="transportTypeDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Air</asp:ListItem>
                                    <asp:ListItem>Road</asp:ListItem>
                                    <asp:ListItem>Ship</asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Shipping Address
                                </h5>
                                <asp:TextBox ID="shippingAddressTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Shipping Address">
                                </asp:TextBox>
                            </div>--%>
                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">Billing Address
                                </h5>
                                <asp:TextBox ID="billingAddressTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Billing Address"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Payment Mode
                                </h5>
                                <asp:DropDownList ID="paymentModeDropDownList" runat="server" AutoPostBack="True" CssClass="form form-full" OnSelectedIndexChanged="paymentModeDropDownList_SelectedIndexChanged">

                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>Cheque</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Account Head
                                </h5>
                                <asp:DropDownList ID="accountHeadDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Cheque Number
                                </h5>
                                <asp:TextBox ID="chequeNumberTextBox" runat="server" CssClass="cash-cheque form form-full"
                                    placeholder="Cheque Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Cheque Date
                                </h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="chequeDateTextBox" CssClass="date-textbox cash-cheque form form-full"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Bank
                                </h5>
                                <asp:TextBox ID="bankDropDownList" runat="server" CssClass="cash-cheque form form-full">
                                </asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Bank Branch
                                </h5>
                                <asp:TextBox ID="bankBranchTextBox" runat="server" CssClass="cash-cheque form form-full"
                                    placeholder="Bank Branch"></asp:TextBox>
                            </div>
                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">LC Number
                                </h5>
                                <asp:TextBox ID="lcNumberTextBox" runat="server" CssClass="form form-full" placeholder="LC Number"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-6">
                                <h5 class="typo">Description
                                </h5>
                                <asp:TextBox ID="narrationTextBox" runat="server" CssClass="form form-full" placeholder="Description"></asp:TextBox>
                            </div>
                       </div>
                        <div class="widget-separator text-center no-border grid-12">
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-large btn-3d" Enabled="false" runat="server"
                                Text="Save Purchase" OnClick="saveButton_Click" />
                        </div>
                        <div id="productListModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                            aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Product List
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="productListGridContainer">
                                    <asp:GridView ID="productListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover">
                                        <Columns>
                                            <%--<asp:BoundField DataField="Barcode" HeaderText="ACode" />--%>
                                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                            <asp:BoundField DataField="ProductGroupName" HeaderText="Product Group" />
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="warehouseDropDownList" EventName="SelectedIndexChanged" />
            <%-- <asp:AsyncPostBackTrigger ControlID="transportTypeDropDownList" EventName="SelectedIndexChanged" />--%>
            <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="purchaseProductListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $('.modal-backdrop').remove();
            var checkedRowCount = $("#checkedRowCountHiddenField").val();

            $("#addSelectedProductButton").click(function () {
                $("#checkedRowCountHiddenField").val(checkedRowCount);
                //$('#productListModal').modal({ show: false });
                if (haveOverlay == 1) {
                    MyOverlayStop();
                }
            });

            $("#addProductButton").click(function () {

            });

            if ($("#paymentModeDropDownList option:selected").text() == "Cash") {
                $(".cash-cheque").attr("disabled", true);
            }

            $(".read-only").attr("ReadOnly", true);

            $("#paymentModeDropDownList").on("change", function () {
                if ($("#paymentModeDropDownList option:selected").text() == "Cash") {
                    $(".cash-cheque").attr("disabled", true);
                    //$(".cash-cheque").val("");
                } else {
                    $(".cash-cheque").removeAttr("disabled");
                }
            });

            $(".pQty-rpu-amt-cal").on("change keyup", function () {
                var qty = +$(this).closest('tr').find("[id*=quantityTextBox]").val();
                var rate = +$(this).closest('tr').find("[id*=ratePerUnitTextBox]").val();
                var amt = qty * rate;

                $(this).parent().parent().find("[id*=amountTextBox]").val(amt);
                TotalAmountCalculation();
                CalculateUnitPrice();

                //                if (!isNaN(+$("#totalAmountTextBox").val()) && !isNaN($("#vatTextBox").val())) {
                //                    $("#totalPayableTextBox").val(($("#totalAmountTextBox").val() * ($("#vatTextBox").val() / 100)) + +$("#totalAmountTextBox").val());
                //                }
            });

            $(".amt-cal").on("change keyup", function () {
                var qty = +$(this).closest('tr').find("[id*=quantityTextBox]").val();
                var amt = +$(this).closest('tr').find("[id*=amountTextBox]").val();
                var rpu = amt / qty;

                $(this).parent().parent().find("[id*=ratePerUnitTextBox]").val(rpu);
                TotalAmountCalculation();
                CalculateUnitPrice();

                //                if (!isNaN(amt)) {
                //                    $("#totalAmountTextBox").val(tAmt + amt);
                //                }
            });

            //            $("#vatTextBox").on("change keyup", function () {
            //                if (!isNaN(+$("#totalAmountTextBox").val())) {
            //                    $("#totalPayableTextBox").val(($("#totalAmountTextBox").val() * ($("#vatTextBox").val() / 100)) + +$("#totalAmountTextBox").val());
            //                }
            //            });

            $("#discountTextBox").on("change keyup", function () {
                if (!isNaN(+$("#totalAmountTextBox").val())) {
                    $("#totalPayableTextBox").val($("#totalAmountTextBox").val() - +$("#discountTextBox").val());
                }
                //$("#transportCostTextBox").val("");
            });

            function TotalAmountCalculation() {
                var tAmt = 0;
                $("#purchaseProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val())) {
                        tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    }
                    //tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    //alert($(this).find("[id*=amountTextBox]").val());
                });
                $("#totalAmountTextBox").val(tAmt);

                //Total Payble Calculation
                $("#totalPayableTextBox").val(tAmt);
                if (!isNaN(+$("#totalAmountTextBox").val())) {
                    $("#totalPayableTextBox").val($("#totalAmountTextBox").val() - +$("#discountTextBox").val());
                }
            }

            function CalculateUnitPrice() {
                if ($("#discountTextBox").val() == "") {
                    $("#discountTextBox").val("0");
                }

                if ($("#transportCostTextBox").val() == "") {
                    $("#transportCostTextBox").val("0");
                }

                var ratePerTaka = (+$("#transportCostTextBox").val() - +$("#discountTextBox").val()) / (+$("#totalAmountTextBox").val());

                $("#purchaseProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val()) && !isNaN(+$(this).find("[id*=quantityTextBox]").val())) {
                        var untp = ((ratePerTaka * +$(this).find("[id*=amountTextBox]").val()) + +$(this).find("[id*=amountTextBox]").val()) / (+$(this).find("[id*=quantityTextBox]").val());
                        $(this).find("[id*=unitPriceTextBox]").val(untp);
                    }
                });
            }

            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductSearchByWH.ashx?id=" + $('#warehouseDropDownList').val(),
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productTextBox').typeahead({ source: array });
                    //                    $('#txtbxfineBy').typeahead({ source: array });
                }
            });

            $("#purchaseProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, -1], [10, 15, 20, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#purchaseProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#addFromListButton").click(function () {
                $('#productListModal').modal();
            });

            $("#productListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[-1], ["All"]],
                "iDisplayLength": -1,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4] }],
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
        }
    </script>
</asp:Content>
