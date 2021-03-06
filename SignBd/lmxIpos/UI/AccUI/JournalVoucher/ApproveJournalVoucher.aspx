﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ApproveJournalVoucher.aspx.cs" Inherits="lmxIpos.UI.AccUI.JournalVoucher.ApproveJournalVoucher" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ViewJournalVoucher.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Approve Journal Voucher<span>Approving Journal Voucher</span></h1>
                <div class="sitemap grid-6">
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Approve Journal Voucher of
                            <asp:Label ID="numberLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Transaction Date:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="transactionDateLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Auto Voucher Number:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="autoVoucherNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Total Amount:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="totalAmountLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-4">
                                    Total Entry:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="totalEntryLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-4">
                                    Status:
                                </div>
                                <div class="grid-8">
                                    <asp:Label ID="voucherStatusLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="journalEntryListGridContainer">
                                <asp:GridView ID="journalEntryListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="TransactionNumber" HeaderText="SN" />
                                        <asp:BoundField DataField="AccountHead" HeaderText="Account Head" />
                                        <asp:BoundField DataField="DebitCredit" HeaderText="Dr/Cr" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="PayToFromCompanyName" HeaderText="Company" />
                                        <asp:BoundField DataField="ChequeNumber" HeaderText="Cheque-No." />
                                        <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" class="btn btn-mini btn-info viewLinkButton"
                                                    OnClientClick="return false;">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="drcrAmt">
                                <div id="drAmt">
                                    Total Debit Amount&nbsp;&nbsp;:&nbsp;&nbsp; [
                                    <asp:Label ID="drAmtLabel" runat="server" Text=""></asp:Label>
                                    ] &nbsp;&nbsp;
                                    <asp:Label ID="drAmtWordLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                                <div id="crAmt">
                                    Total Credit Amount&nbsp;:&nbsp;&nbsp; [
                                    <asp:Label ID="crAmtLabel" runat="server" Text=""></asp:Label>
                                    ] &nbsp;&nbsp;
                                    <asp:Label ID="crAmtWordLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="approveButton" runat="server" Text="Approve" CssClass="btn btn-success"
                                OnClick="approveButton_Click" />
                            <asp:Button ID="rejectButton" runat="server" Text="Reject" CssClass="btn btn-danger"
                                OnClick="rejectButton_Click" />
                        </div>
                        <div id="viewDetailsModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                            aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Journal Entry - Details
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="loadingDiv">
                                </div>
                                <div id="contentContainer">
                                    <div class="widget-separator no-padding grid-12">
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                SN:
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="snLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Account Head
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="accountHeadLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Amount
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="amountLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Debit/Credit
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="debitCreditLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Voucher Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="voucherNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Cheque Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="chequeNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Cheque Date
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="chequeDateLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Bank
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="bankLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Bank Branch
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="bankBranchLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Pay To/From Company
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="payToFromCompanyLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Status
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Narration
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="narrationLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-inverse" data-dismiss="modal" aria-hidden="true">
                                    Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="journalNumberForViewHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#journalEntryListGridView").dataTable({
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

            $("#journalEntryListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            if ($("#drAmtLabel").text() == $("#crAmtLabel").text()) {
                $("#drAmt, #crAmt").css("background", "none repeat scroll 0 0 rgb(185, 242, 184)"); //green
            }
            else if ($("#drAmtLabel").text() < $("#crAmtLabel").text()) {
                $("#drAmt").css("background", "none repeat scroll 0 0 rgb(245, 182, 182)"); //red
                $("#crAmt").css("background", "none repeat scroll 0 0 rgb(185, 242, 184)"); //green
            }
            else if ($("#drAmtLabel").text() > $("#crAmtLabel").text()) {
                $("#drAmt").css("background", "none repeat scroll 0 0 rgb(185, 242, 184)"); //green
                $("#crAmt").css("background", "none repeat scroll 0 0 rgb(245, 182, 182)"); //red
            }
            else {
                $("#drAmt, #crAmt").css("background", "none repeat scroll 0 0 rgb(245, 182, 182)"); //red
            }

            var SN, journalNumber;
            $(".viewLinkButton").click(function () {
                var row = $(this).parent().parent().index();
                var col = $(this).parent().index();
                SN = $("#journalEntryListGridView").find("tr td:first-child").eq(row).text();
                journalNumber = $("#journalNumberForViewHiddenField").val();

                $('#viewDetailsModal').modal();
                $("#contentContainer").hide();
                $("#loadingDiv").show();
            });

            $("#viewDetailsModal").on("shown", function () {
                $.ajax({
                    type: "POST",
                    url: "/UI/AccUI/JournalVoucher/ViewJournalVoucher.aspx/GetJournalEntryViewByJournalAndTransactionNumber",
                    data: "{'SN':'" + SN + "','journalNumber':'" + journalNumber + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var obj = (new Function('return ' + data.d))();

                        $("#snLabel").text(obj.TransactionNumber);
                        $("#accountHeadLabel").text(obj.AccountHead);
                        $("#amountLabel").text(obj.Amount);
                        $("#debitCreditLabel").text(obj.DebitCredit);
                        $("#voucherNumberLabel").text(obj.ManualVoucherNumber);

                        if (obj.BankName == null) {
                            $("#bankLabel").text("N/A");
                        }
                        else {
                            $("#bankLabel").text(obj.BankName);
                        }

                        if (obj.BankBranch == "") {
                            $("#bankBranchLabel").text("N/A");
                        }
                        else {
                            $("#bankBranchLabel").text(obj.BankBranch);
                        }

                        if (obj.ChequeNumber == "") {
                            $("#chequeNumberLabel").text("N/A");
                        }
                        else {
                            $("#chequeNumberLabel").text(obj.ChequeNumber);
                        }

                        if (obj.ChequeDate == "01 Jan 1900") {
                            $("#chequeDateLabel").text("N/A");
                        }
                        else {
                            $("#chequeDateLabel").text(obj.ChequeDate);
                        }

                        if (obj.PayToFromCompanyName == null) {
                            $("#payToFromCompanyLabel").text("N/A");
                        }
                        else {
                            $("#payToFromCompanyLabel").text(obj.PayToFromCompanyName);
                        }

                        $("#narrationLabel").text(obj.Narration);
                        $("#statusLabel").text(obj.Status);

                        $("#loadingDiv").hide();
                        $("#contentContainer").show();
                    }
                });
            });

            $("#approveButton, #rejectButton").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
