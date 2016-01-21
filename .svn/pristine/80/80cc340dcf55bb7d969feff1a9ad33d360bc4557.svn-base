<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="checkInventory.aspx.cs" Inherits="lmxIpos.UI.checqueInventory.checkInventory" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>cheque Inventory<span>cheque Inventory Details</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">cheque Inventory</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Check at
                                </h5>
                                <asp:DropDownList ID="purchaseReturnFormDropdownList" runat="server" CssClass="form form-full"  AutoPostBack="true"
                                    required="required">
                                    <%--<asp:ListItem Text="--select--" Value="0"></asp:ListItem>--%>
                                    <asp:ListItem Text="Business" Value="WH"></asp:ListItem>
                                    <%--<asp:ListItem Text="Sales Center" Value="SC"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    <asp:Label ID="wareHouseorSCLabel" runat="server" Text="Business"></asp:Label>
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Status
                                </h5>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form form-full" required="required">
                                    <asp:ListItem Text="--Select Status--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                                    <asp:ListItem Text="Approve" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="Approve By cash" Value="AC"></asp:ListItem>
                                    <%--<asp:ListItem Text="Partial Approve by Cash" Value="PA"></asp:ListItem>--%>
                                    <asp:ListItem Text="Reject" Value="R"></asp:ListItem>
                                    <%-- <asp:ListItem Text="Relise" Value="RL"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Type</h5>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form form-full">
                                    <asp:ListItem Text="--Select type--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="In Flow" Value="Y"></asp:ListItem>
                                    <asp:ListItem Text="Out Flow" Value="N"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" style="padding-top: 42px;">
                                <asp:Button ID="btnCheck" runat="server" Text="Check" CssClass="btn btn-info grid-3 btn-3d" OnClick="btnCheck_Click" />
                            </div>
                            <div class="widget-separator no-padding grid-12">
                                <div class="grid-12">
                                    <asp:GridView ID="gridChequeInventory" runat="server" AutoGenerateColumns="false" CssClass="table table-hover dataTable">
                                        <Columns>
                                            <asp:BoundField DataField="Serial" HeaderText="#" />
                                            <asp:BoundField DataField="JournalNumber" HeaderText="Jrn. No." />
                                            <asp:BoundField DataField="toFromName" HeaderText="To/From" />
                                            <asp:BoundField DataField="ChequeNo" HeaderText="Chq No" />
                                            <asp:BoundField DataField="ChequeDate" HeaderText="Chq Date"  dataformatstring="{0:d MMMM, yyyy}" htmlencode="false" />
                                            <asp:BoundField DataField="BankName" HeaderText="Bank" />
                                            <asp:BoundField DataField="BankBranch" HeaderText="Branch" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:TemplateField HeaderText="Final Date">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtFinalDate" runat="server" Text='<%# Eval("FinalDate") %>' CssClass="form form-full datepicker"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Naration">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtchqNaration" runat="server" CssClass="form form-full"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlStatusInGrid" runat="server" CssClass="form form-full" OnSelectedIndexChanged="ddlStatusInGrid_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Text="--Select Status--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Approve" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="Approve By cash" Value="AC"></asp:ListItem>
                                                        <%--<asp:ListItem Text="Partial Approve by Cash" Value="PA"></asp:ListItem>--%>
                                                        <asp:ListItem Text="Reject" Value="R"></asp:ListItem>
                                                        <%-- <asp:ListItem Text="Relise" Value="RL"></asp:ListItem>--%>
                                                    </asp:DropDownList>
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
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCheck" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gridChequeInventory" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $('.datepicker').datepicker({ autoclose: true, format: dateFormat });
            $('#gridChequeInventory').dataTable();
        }
    </script>
</asp:Content>
