﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MainProductOfSubProduct.aspx.cs" Inherits="lmxIpos.UI.Product.MainProductOfSubProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-6">
            <i>&#xf132;</i>Main Product List<span>Created Main Product List</span></h1>
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
                <h3 id="Header3" runat="server" class="widget-header-title">Main Product List</h3>
            </header>
            <div class="clearfix"></div>
            <div class="widget-separator no-border grid-3">
                <h5 class="typo">Business</h5>
                <asp:DropDownList ID="warehouseDropDownList" required="required" runat="server" OnSelectedIndexChanged="wareHouseDropDownList_Click" AutoPostBack="True" CssClass="form form-full">
                </asp:DropDownList>
            </div>
            <div class="widget-separator no-border grid-3">
                <h5 class="typo">Sub Product </h5>
                <asp:DropDownList ID="subProductDropDownList" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="subProductDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="widget-body no-padding">
                <div class="grid-12">
                    <div id="productGroupListGridContainer">
                        <asp:GridView ID="mainProductListGridView" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover gridView dataTable">
                            <Columns>
                                <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                <asp:BoundField DataField="ProductGroupName" HeaderText="Product Group Name" />
                                <asp:BoundField DataField="ProductDescription" HeaderText="Description" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteLinkButton" runat="server" CssClass="clickProcessing"
                                            OnClick="deleteLinkButton_Click"><span class="icon icon-2x icon-trash text-error"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#mainProductListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5, 6, 7] }]
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
           
            $(".clickProcessing").live("click", function (e) {
                if (haveOverlay == 0) {

                    var col = $(this).parent().children().parent().index();
                    var row = $(this).parent().parent().index();
                    productId = $("#mainProductListGridView").find("tr td:nth-child(1)").eq(row).text();
                    //isActive = $("#mainProductListGridView").find("tr td:nth-child(5)").eq(row).text();

                    var id = $(this).attr("id");
                    var str = $(this).attr("href");
                    var arr = str.split("'");
                    var msg = "";

                      if (id == "deleteLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>delete</span> this Product?";
                        }

                        ConfirmProcess(msg, function () {
                            MyOverlayStart();
                            __doPostBack(arr[1], '');
                        }, function () {

                        });
                    }

                    e.preventDefault();
                
            });
        });
    </script>
</asp:Content>
