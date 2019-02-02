<%@ Page Title="Manage Role Modules" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageRoleModules.aspx.cs" Inherits="IncidentManagement.Account.ManageRoleModules"
    Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder ID="loginForm" runat="server">
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlRoles" CssClass="col-md-2 control-label">Role Name</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlRoles"  AutoPostBack="true"
                               OnSelectedIndexChanged="ddlRoles_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                           <%-- <asp:SqlDataSource ID="sdsRoles" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                            SelectCommand="SELECT ID, Name from AspNetRoles">
                            </asp:SqlDataSource>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:CheckBoxList ID="cbxRoleModules" runat="server"></asp:CheckBoxList>
                           <%--<asp:SqlDataSource ID="sdsRoleModules" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                            SelectCommand="Select * FROM Module">
                            </asp:SqlDataSource>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="UpdateModule" Text="Update" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                <p class="text-info">
                    Modules has been successfully updated to selected role!
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
       
</asp:Content>
