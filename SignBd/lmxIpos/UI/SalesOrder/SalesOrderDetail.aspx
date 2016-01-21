﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="SalesOrderDetail.aspx.cs" Inherits="lmxIpos.UI.SalesOrder.SalesOrderDetail" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;Sales Order [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]</h1>
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
            </div>
            <div class="widget">
                <header class="widget-header">
                    <div class="widget-header-icon">
                        
                    </div>
                    <h3 id="Header3" runat="server" class="widget-header-title">Sales Order Details</h3>
                </header>
                <div class="widget-body no-padding">
                    <div class="widget-separator grid-12">
                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Order ID :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="orderIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo bolder">Order Date :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="orderDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Sales Center ID & Name :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <div class="grid-12">
                                            <div class="grid-6">
                                                <asp:Label ID="salesCenterIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            </div>
                                            <div class="grid-6">
                                                <asp:Label ID="salesCenterNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Narration :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Status :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Customer ID :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="customerIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Customer Name :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="customerNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Customer Contact Number :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="customerContactNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Customer Address :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="customerAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Transport Type :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="transportTypeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Shipping Address :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="shippingAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Billing Address :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="billingAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Payment Mode :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="paymentModeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Cheque Number :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="chequeNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Cheque Date :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="chequeDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Bank :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="bankLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Bank Branch :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="bankBranchLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Delivery Date :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="deliveryDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">LC Number :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="lcNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Transport Date :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="transportDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="widget-separator no-padding grid-12">
                        <div class="grid-12">
                            <div id="salesOrderProductListGridContainer">
                                <asp:GridView ID="salesOrderProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover dataTable gridView">
                                    <Columns>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="FreeQuantityWasUnit" HeaderText="Free Quantity Was" />
                                        <asp:BoundField DataField="QuantityUnit" HeaderText="Order Qnt." />
                                        <asp:BoundField DataField="FreeQuantity" HeaderText="Available" />
                                        <asp:TemplateField HeaderText="Aprv. Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="orderQuantityTextBox" Text='<%# Eval("QuantityUnit") %>' CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff" runat="server" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="ratePerUnitTextBox" runat="server" Text='<%# Eval("RatePerUnit") %>' Width="50" CssClass="oQty-rpu-amt-cal autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="VATPercentage" HeaderText="VAT(%)" />
                                        <asp:TemplateField HeaderText="Amount+VAT">
                                            <ItemTemplate>
                                                <asp:TextBox ID="amountTextBox" Text='<%# Eval("Amount") %>' runat="server" Width="80" CssClass="read-only autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ApproveQuantity" HeaderText="Apr. Qnt." Visible="False" />
                                        <asp:BoundField DataField="RatePerUnit" HeaderText="Rate Per Unit" Visible="False" />
                                        <asp:BoundField DataField="VATPercentage" HeaderText="VAT(%)" Visible="False" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" Visible="False" />

                                        <%--<asp:BoundField DataField="RatePerUnit" HeaderText="Rate Per Unit" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="widget-separator grid-12">
                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Total Amount :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:TextBox ID="totalAmountLabel" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">VAT (%) :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:TextBox ID="vatLabel" runat="server"></asp:TextBox>


                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Total Receivable :
                                        </h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:TextBox ID="totalReceivableLabel" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Received Amount(Cash or Cheque) :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:TextBox ID="receivedAmountLabel" Text="0.00" onfocus="this.select();" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Dsicount Amount :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:TextBox ID="discountAmntLabel" Text="0.00" onfocus="this.select();" runat="server"></asp:TextBox>


                                    </div>
                                </div>
                            </div>
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">VAT Amount :</h5>
                                    </div>
                                    <div class="grid-6">
                                           <asp:TextBox ID="VATamntLabel" Text="0.00" onfocus="this.select();" runat="server"></asp:TextBox>

                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdnfildChangeAmount" Value="0.00" runat="server" />
                        <%--<div class="grid-12">
                            <div class="grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                                        <h5 class="typo">Change Amount :</h5>
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="changeAmntLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                    <div class="widget-separator grid-12">
                        <div class="grid-12">
                            <div class="grid-6">
                                <asp:Button ID="btnAccept" runat="server" Text="Approve to confirm Sales Order" CssClass="pull-right grid-3 btn btn-submit btn-3d" Style="margin-right: 10px;" OnClick="btnAccept_Click" />
                            </div>
                            <div class="grid-6">
                                <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="pull-left grid-3 btn btn-error btn-3d" Style="margin-left: 10px;" OnClick="btnReject_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="accountIDhiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="salesOrderIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        // $('#salesOrderProductListGridView').dataTable();
        //    $("#productRequisitionProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        function pageLoad(sender, args) {
            $(function () {
                $("#salesOrderProductListGridView").dataTable({
                    "bProcessing": true,
                    "sPaginationType": "full_numbers",
                    "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                    "iDisplayLength": -1,
                    "bSort": false,
                    //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5, 6, 7]}],
                    "bFilter": false,
                    "bLengthChange": true,
                    "bPaginate": false,
                    "bInfo": true,
                    "bRetrieve":true
                });

                $("#salesOrderProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
            });

            function TotalAmountCalculation() {
                var tAmt = 0;
                $("#salesOrderProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val())) {
                        tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    }
                });
                $("#totalAmountLabel").val(tAmt);
            }

            function OthersCalculation() {
                var netAmt = 0;
                var totalAmt = 0;
                var discount = 0;
                var vat = 0;
                var receivable = 0;
                var received = 0;
                var vatAmount = 0;
                // var due = 0;
                // var change = 0;

                if (!isNaN(+$("#totalAmountLabel").val())) {
                    totalAmt = $("#totalAmountLabel").val();
                }

                if (!isNaN(+$("#discountAmntLabel").val())) {
                    discount = $("#discountAmntLabel").val();
                }

                if (!isNaN(+$("#vatLabel").val())) {
                    vat = $("#vatLabel").val();
                }
                if (!isNaN(+$("#VATamntLabel").val())) {
                    vatAmount = $("#VATamntLabel").val();
                }


                if (!isNaN(+$("#totalReceivableLabel").val())) {
                    receivable = $("#totalReceivableLabel").val();
                }

                if (!isNaN(+$("#receivedAmountTextBox").val())) {
                    received = $("#receivedAmountTextBox").val();
                }

                //if (!isNaN(+$("#DuesAmoutPayTextBox").val())) {
                //    due = $("#DuesAmoutPayTextBox").val();
                //}

                //if (!isNaN(+$("#changeAmountTextBox").val())) {
                //    change = $("#changeAmountTextBox").val();
                // }

                netAmt = totalAmt - discount;
                receivable = netAmt + (netAmt * vat / 100);
                vatAmount = netAmt * vat / 100;

                $("#totalVATAmountHiddenField").val(netAmt * vat / 100);
                $("#totalReceivableLabel").val(receivable);

                //$("#changeAmountTextBox").val(received - receivable);

                //if (due > 0 && due <= change) {
                //   $("#changeAmountTextBox").val((received - receivable) - due);
                //}
                //$("#changeAmountTextBox").val(received - inTotal);
                $("#VATamntLabel").val(vatAmount);
                //  $("#VATamntLabel").val(vat);
                $("#discountAmntLabel").val(discount);
            }


            $(".oQty-rpu-amt-cal").on("change keyup", function () {
                var qty = +$(this).closest('tr').find("[id*=orderQuantityTextBox]").val();
                var rate = +$(this).closest('tr').find("[id*=ratePerUnitTextBox]").val();
                var vat = $(this).parents().closest('tr').find('td:nth-child(8)').html();
                var amt = qty * rate;
                var amt = amt + (amt * vat / 100);

                $(this).parent().parent().find("[id*=amountTextBox]").val(amt);
                TotalAmountCalculation();
                OthersCalculation();
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
        }
    </script>
</asp:Content>
