﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="lmxIpos.UI.UserGroup.List" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/UserGroupList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>User Group List<span>Created User Group List of System</span></h1>
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
                            </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                            System User Group List</h3>
                    </header>
                    <div class="widget-body">
                        <div id="userGroupListGridContainer" >
                            <asp:GridView ID="userGroupListGridView" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-hover gridView">
                                <Columns>
                                    <asp:BoundField DataField="UserGroupId" HeaderText="User Group ID" />
                                    <asp:BoundField DataField="UserGroupName" HeaderText="User Group Name" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editLinkButton" runat="server" CssClass="btn btn-info btn-flat-3d"
                                                OnClick="editLinkButton_Click">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="btn btn-success btn-flat-3d clickProcessing"
                                                OnClick="activateLinkButton_Click">Activate</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="deactivateLinkButton" runat="server" CssClass="btn btn-warning btn-flat-3d clickProcessing"
                                                OnClick="deactivateLinkButton_Click">Deactivate</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="deleteLinkButton" runat="server" CssClass="btn btn-error btn-flat-3d clickProcessing"
                                                OnClick="deleteLinkButton_Click">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="userGroupListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#userGroupListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5, 6, 7]}]
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#editLinkButton").live("click", function (e) {
                MyOverlayStart();
            });

            $(".clickProcessing").live("click", function (e) {
                if (haveOverlay == 0) {

                    var col = $(this).parent().children().parent().index();
                    var row = $(this).parent().parent().index();
                    userGroupId = $("#userGroupListGridView").find("tr td:nth-child(1)").eq(row).text();
                    isActive = $("#userGroupListGridView").find("tr td:nth-child(4)").eq(row).text();

                    var id = $(this).attr("id");
                    var str = $(this).attr("href");
                    var arr = str.split("'");
                    var msg = "";

                    if (isActive == "True" && id == "activateLinkButton") {
                        WarningAlert("Process Redundant", "This User Group <span class='actionTopic'>already activated</span>.", "");
                    }
                    else if (isActive == "False" && id == "deactivateLinkButton") {
                        WarningAlert("Process Redundant", "This User Group <span class='actionTopic'>already deactivated</span>.", "");
                    }
                    else {
                        if (id == "activateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>activate</span> this User Group?";
                        }
                        else if (id == "deactivateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>deactivate</span> this User Group?";
                        }
                        else if (id == "deleteLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>delete</span> this User Group?";
                        }

                        ConfirmProcess(msg, function () {
                            MyOverlayStart();
                            __doPostBack(arr[1], '');
                        }, function () {

                        });
                    }

                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
