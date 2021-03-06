﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.AccUI.PayToFromCompany.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-7">
                    <i>&#xf132;</i>Update Pay To/From Company<span>Updating Pay To/From Company</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>IPOS</span><i>/</i></li>
                        <li><a href="/Default.aspx">Dashboard</a></li>
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
                            </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                            Update Pay To/From Company of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label> Form</h3>
                    </header>
                    <div class="clearfix"></div>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Company Name
                            </h5>
                            <asp:TextBox ID="companyNameTextBox" runat="server" CssClass="form form-full" placeholder="Company Name"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Company Address
                            </h5>
                            <asp:TextBox ID="companyAddressTextBox" runat="server" CssClass="form form-full" placeholder="Company Address"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Company Contact
                            </h5>
                            <asp:TextBox ID="companyContactTextBox" runat="server" CssClass="form form-full" placeholder="Company Contact"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Company Email
                            </h5>
                            <asp:TextBox ID="companyEmailTextBox" runat="server" CssClass="form form-full" placeholder="Company Email"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Company Website
                            </h5>
                            <asp:TextBox ID="companyWebsiteTextBox" runat="server" CssClass="form form-full" placeholder="Company Website"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-9">
                            <h5 class="typo">
                                Description
                            </h5>
                            <asp:TextBox ID="descriptionTextBox" runat="server" CssClass="form form-full" placeholder="Description"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="payToFromCompanyIdForUpdateHiddenField" runat="server" />
            <asp:HiddenField ID="payToFromCompanyNameForUpdateHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#updateButton").click(function (e) {
                $("#companyNameTextBox").rules("add", {
                    required: true
                });

                $("#descriptionTextBox").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
