﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.AccUI.Bank.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
          <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Bank<span>Updating System Bank</span></h1>
                <div class="sitemap grid-6">
                    <ul>
                        <li><span>IPOS</span><i>/</i></li>
                        <li><a href="/Default.aspx">Dashboard</a></li>
                    </ul>
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
                            Bank Update Form of [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Bank Name</h5>
                                <asp:TextBox ID="bankNameTextBox" required="required" placeholder="Group Name" runat="server"
                                    CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-9">
                                <h5 class="typo">
                                    Description</h5>
                                <asp:TextBox ID="descriptionTextBox" required="required" placeholder="Description"
                                    runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
                        
            <asp:HiddenField ID="bankIdForUpdateHiddenField" runat="server" />
            <asp:HiddenField ID="bankNameForUpdateHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#updateButton").click(function (e) {
                if (Page_ClientValidate("")) {
                    if (haveOverlay == 0) {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
</asp:Content>
