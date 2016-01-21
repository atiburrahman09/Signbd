﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="SalesOrderList.aspx.cs" Inherits="lmxIpos.UI.SalesOrder.SalesOrderList" EnableEventValidation="false" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/SalesOrderList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Sales order List<span>Sales Order List</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Sales Order List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">

                            <%--  <div class="widget-separator no-border grid-2">
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
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">Date Form</h5>

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
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" data-date-format="dd/mm/yyyy"
                                            runat="server" required="required"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">Status </h5>
                                <asp:DropDownList ID="statusDropDownList" CssClass="form form-full" runat="server">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="A">Approved</asp:ListItem>
                                    <asp:ListItem Value="R">Canceled</asp:ListItem>
                                    <%--<asp:ListItem Value="CP">Cancel Pending</asp:ListItem>--%>
                                    <%--  <asp:ListItem Value="OT">On Transport</asp:ListItem>--%>
                                    <%-- <asp:ListItem Value="PD">Partially Done</asp:ListItem>--%>
                                    <asp:ListItem Value="P">Pending</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">&nbsp; </h5>
                                <asp:Button ID="orderListButton" runat="server" Text="Get Order List" CssClass="btn btn-info"
                                    OnClick="orderListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div class="grid-12" style="padding: 15px;">
                                <div id="salesOrderListGridContainer">
                                    <asp:GridView ID="salesOrderListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-striped table-hover dataTable">
                                        <Columns>
                                            <asp:BoundField DataField="SalesOrderId" HeaderText="SO ID" />
                                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                            <asp:BoundField DataField="CustomerId" HeaderText="Cst. ID" />
                                            <asp:BoundField DataField="CustomerName" HeaderText="Cst. Name" />
                                            <asp:BoundField DataField="SalesPersonId" HeaderText="SP ID" />
                                            <asp:BoundField DataField="SalesPersonName" HeaderText="SP Name" />
                                            <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info"
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(function () {
                var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
                $(".date-textbox").datepicker({ format: dateFormat, autoclose: true });
                $(".date-textbox, .icon-calendar").click(function () {
                    $(this).parent().find(".date-textbox").focus();
                });


                $("#salesOrderListGridView").dataTable({
                    //"bProcessing": true,
                    //"sPaginationType": "full_numbers",
                    //"aLengthMenu": [[-1], ["All"]],
                    //"iDisplayLength": -1,
                    //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6, 7] }],
                    //"bFilter": true,
                    //"bLengthChange": true,
                    //"bPaginate": false,
                    //"bInfo": true
                });
            });
        }
    </script>
</asp:Content>
