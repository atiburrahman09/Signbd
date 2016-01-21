﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="CreateMenuGroup.aspx.cs" Inherits="lmxIpos.UI.AppMenu.CreateMenuGroup" EnableEventValidation="false" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Create Menu Group</legend>
            <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <h4>
                    <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                </h4>
                <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
            </div>
            <table class="inputControlContainer">
                <tr>
                    <td>
                        <label>
                            Menu For App.
                        </label>
                        <asp:DropDownList ID="menuForAppDropDownList" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="menuForAppDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Menu Type
                        </label>
                        <asp:DropDownList ID="menuTypeDropDownList" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Menu Target
                        </label>
                        <asp:DropDownList ID="menuTargetDropDownList" runat="server">
                            <asp:ListItem>_blank</asp:ListItem>
                            <asp:ListItem Selected="True">_parent</asp:ListItem>
                            <asp:ListItem>_search</asp:ListItem>
                            <asp:ListItem>_self</asp:ListItem>
                            <asp:ListItem>_top</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Menu Group Name
                        </label>
                        <asp:TextBox ID="menuGroupNameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <label>
                            Display Name
                        </label>
                        <asp:TextBox ID="displayNameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <label>
                            Description
                        </label>
                        <asp:TextBox ID="descriptionTextBox" runat="server" Width="448"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label>
                            Menu URL
                        </label>
                        <asp:TextBox ID="urlTextBox" runat="server" Width="448"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <label>
                            Image URL
                        </label>
                        <asp:TextBox ID="imageURLTextBox" runat="server" Width="448"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div>
                <label class="infoLabel">
                    *** URL Note: Use " javascript:void(0) " as blank URL instead of symbol ' # '
                </label>
            </div>
            <hr />
            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-primary"
                OnClick="saveButton_Click" />
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#menuForAppDropDownList").rules("add", {
                required: true
            });

            $("#menuTypeDropDownList").rules("add", {
                required: true
            });

            $("#menuGroupNameTextBox").rules("add", {
                required: true
            });

            $("#displayNameTextBox").rules("add", {
                required: true
            });

            $("#urlTextBox").rules("add", {
                required: true
            });
        });
    </script>
</asp:Content>
