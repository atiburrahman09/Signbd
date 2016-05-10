<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="SMSSend.aspx.cs" Inherits="lmxIpos.UI.SMS.SMSSend" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Send SMS<span>Sending SMS</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Sending SMS</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        <asp:Label runat="server" Text="Select " ID="titleSelect"></asp:Label>
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="selectDropDownList" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="selectDropDownList_OnSelectedIndexChanged">
                                        <asp:ListItem Value="CST">Customer</asp:ListItem>
                                        <asp:ListItem Value="VND">Vendor</asp:ListItem>
                                        <asp:ListItem Value="COM">Company</asp:ListItem>
                                        <asp:ListItem Value="CUS">Custom</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sender</h5>
                                <asp:TextBox ID="senderTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Sender Name" required="required"></asp:TextBox>
                            </div>
                            
                            <div class="widget-separator no-border grid-3" runat="server" Visible="False" ID="NumberDiv">
                                <h5 class="typo">Number</h5>
                                <asp:TextBox ID="numberTextBox" runat="server" CssClass="form form-full" 
                                    placeholder="Put Semicolon (;) Between Numbers" required="required"></asp:TextBox>
                            </div>
                            
                            <div class="widget-separator no-border grid-6">
                                <h5 class="typo">Body</h5>
                                <asp:TextBox ID="bodyText" runat="server" CssClass="form form-full" TextMode="MultiLine"
                                    placeholder="Enter Your Sms" required="required"></asp:TextBox>
                            </div>

                            <div class="widget-separator no-border grid-4" style="margin-top: 29px;">
                                <asp:Button ID="sendButton" runat="server" Text="Send" CssClass="btn btn-success"
                                    OnClick="sendButton_OnClick" />
                            </div>
                            
                             <div id="customerListGridContainer">
                                <asp:GridView ID="customerListGridView" runat="server" AutoGenerateColumns="false" Visible="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
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
                             <div id="vendorListGridContainer">
                                <asp:GridView ID="vendorGridView" runat="server" AutoGenerateColumns="false" Visible="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="VendorId" HeaderText="Vendor ID" />
                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
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
                             <div id="companyListGridContainer">
                                <asp:GridView ID="companyGridView" runat="server" AutoGenerateColumns="false" Visible="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                         <asp:BoundField DataField="CompanyId" HeaderText="Company ID" />
                                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Contact Number" />
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="sendButton" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#customerListGridView").dataTable({
                    "bProcessing": true,
                    "bStateSave": true,
                    "sPaginationType": "full_numbers",
                    "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                    //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8, 9] }]
            });

            $("#vendorGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8, 9] }]
            });
            $("#companyGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8, 9] }]
            });

            var checkedRowCount = 0;
            $(":checkbox").prop("autocomplete", "off");
            $(".newPriceTextBox").prop("autocomplete", "off");

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
                }
            });
        }
    </script>
</asp:Content>
