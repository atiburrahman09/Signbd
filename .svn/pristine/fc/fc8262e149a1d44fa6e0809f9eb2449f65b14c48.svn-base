<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="RetailSalesList.aspx.cs" Inherits="lmxIpos.UI.Sales.RetailSalesList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function ExportReportForm() {
            window.open("/ReportExport.aspx", "_blank");
        }
        function ViewReportForm() {
            window.open("/ReportView.aspx", "_blank");
        }
        function ViewApprovedSalesDetail() {
            window.open("/UI/Sales/ApprovedRetailSales.aspx");
        }
        function ViewApproveSalesDetail() {
            window.open("/UI/Sales/ApproveRetailSales.aspx");
        }
    </script>
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
           
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Sales Record List<span>Sales Record List</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Sales Center Sales Record List of System</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <%--    <div class="widget-separator no-border grid-2">
                                <h5 class="typo">Check at
                                </h5>
                                <asp:DropDownList ID="chkatDropdownList" runat="server" CssClass="form form-full" OnSelectedIndexChanged="chkatDropdownList_SelectedIndexChanged" AutoPostBack="true"
                                    required="required">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Warehouse" Value="WH"></asp:ListItem>
                                    <asp:ListItem Text="Sales Center" Value="SC"></asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">
                                    <asp:Label ID="wareHouseorSCLabel" runat="server" Text="Business"></asp:Label>
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>

                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sales Center Name
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">Date From</h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="fromDateTextBox" CssClass="date-textbox form form-full" data-date-format="dd/mm/yyyy"
                                            runat="server" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">Date To</h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" runat="server"
                                            data-date-format="dd/mm/yyyy" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">Status
                                </h5>
                                <asp:DropDownList ID="statusDropDownList" CssClass="form form-full" runat="server">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="A">Approved</asp:ListItem>
                                    <asp:ListItem Value="P">Pending</asp:ListItem>
                                    <asp:ListItem Value="R">Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">&nbsp;
                                </h5>
                                <asp:Button ID="recordListButton" runat="server" Text="Get Sales Record List" CssClass="btn btn-info"
                                    OnClick="recordListButton_Click" />
                            </div>

                        </div>

                        <div class=" widget-separator no-border grid-12">
                            <div id="salesRecordListGridContainer">
                                <asp:GridView ID="salesRecordListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover dataTable gridView">
                                    <Columns>
                                        <asp:BoundField DataField="SalesRecordId" HeaderText="SR ID" />
                                        <asp:BoundField DataField="RecordDate" HeaderText="Record Date" />
                                        <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                        <asp:BoundField DataField="TotalReceivable" HeaderText="Amount" />
                                        <asp:BoundField DataField="TotalVATAmount" HeaderText="VAT" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info" Text='<%# Eval("ViewButton") %>'
                                                    OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="editLinkButton" runat="server" CssClass="btn btn-mini btn-warning"
                                                    OnClick="editLinkButton_OnClick">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="printInvoiceButton" runat="server" CssClass="btn btn-mini btn-success" Text="Print Invoice"
                                                    OnClick="printInvoiceButton_OnClick"></asp:LinkButton>
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
            <asp:AsyncPostBackTrigger ControlID="recordListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="salesRecordListGridView" EventName="RowDataBound" />
            <%--<asp:AsyncPostBackTrigger ControlID="printInvoiceButton" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(".date-textbox").datepicker();


            $("#salesRecordListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": true,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6, 7, 8, 9] }],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": true,
                "bInfo": false,
                "bState": true
            });
        }
    </script>
</asp:Content>
