<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ListView.aspx.cs" Inherits="lmxIpos.UI.AccUI.ChartOfAccount.ListView" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ChartOfAccountList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-7">
                    <i>&#xf132;</i>Chart Of Account List View<span>Created Chart Of Account List View</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">System Chart Of Account List View</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Account Type
                                </h5>
                                <asp:DropDownList ID="accountTypeDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="A">Asset</asp:ListItem>
                                    <asp:ListItem Value="L">Liability</asp:ListItem>
                                    <asp:ListItem Value="I">Income</asp:ListItem>
                                    <asp:ListItem Value="E">Expendituer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="accountListButton" runat="server" Text="Get Chart Of Account List"
                                    CssClass="btn btn-info" OnClick="accountListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <div id="chartOfAccountListGridContainer">
                                <asp:GridView ID="chartOfAccountListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="AccountId" HeaderText="ID" />
                                        <asp:BoundField DataField="AccountName" HeaderText="Account Name" />
                                        <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                                        <asp:BoundField DataField="TotallingAccountNumber" HeaderText="Totalling Acc." />
                                        <asp:BoundField DataField="IsPosted" HeaderText="Posted" />
                                        <asp:BoundField DataField="AccountLevel" HeaderText="Level" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info viewLinkButton"
                                                    OnClientClick="return false;">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <%------------------------Experiment-------------------------------%>
                        <div id="viewDetailsModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                            aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Create Chart Of Account
                                </h3>
                            </div>

                            <div class="modal-body">
                                <div id="loadingDiv">
                                </div>
                                <div id="contentContainer">

                                    <div class="widget-separator grid-12">

                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Account Id
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="AccountIdLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Account Name
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="AccountNameLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Account Type DropDownList
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="accountTypeDropDownListLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Account Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="AccountNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Totalling Account Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="TotallingAccountNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Account Level

                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="AccountLevelLabel" runat="server" Text=""></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#chartOfAccountListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [7] }]
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#accountListButton").live("click", function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });


            $(".clickProcessing").live("click", function () {
                MyOverlayStart();
            });
            <%-------------------------------Experiment-------------------------------%>
            var AccountId;
            $(".viewLinkButton").click(function () {
                var row = $(this).parent().parent().index();
                var col = $(this).parent().index();
                AccountId = $("#chartOfAccountListGridView").find("tr td:first-child").eq(row).text();
                $('#viewDetailsModal').modal();
                $("#contentContainer").hide();
                $("#loadingDiv").show();
            });

            $("#viewDetailsModal").on("shown", function () {
                $.ajax({
                    type: "POST",
                    url: "/UI/AccUI/ChartOfAccount/ListView.aspx/AccountListView",
                    data: "{'AccountId':'" + AccountId + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var obj = (new Function('return ' + data.d))();

                        $("#AccountIdLabel").text(obj.AccountId);
                        $("#AccountNameLabel").text(obj.AccountName);
                        $("#AccountNumberLabel").text(obj.AccountNumber);
                        $("#TotallingAccountNumberLabel").text(obj.TotallingAccountNumber);
                        //$("#accountHeadLabel").text(obj.AccountHead);
                        //$("#amountLabel").text(obj.Amount);
                        //$("#counterAccountHeadLabel").text(obj.CounterAccountHead);
                        $("#AccountLevelLabel").text(obj.AccountLevel);
                        $("#accountTypeDropDownListLabel").text(obj.AccountTypeName);
                        //$("#payToFromCompanyLabel").text(obj.PayToFromCompanyName);
                        $("#loadingDiv").hide();
                        $("#contentContainer").show();
                    }
                });
            });
        });
    </script>
</asp:Content>
