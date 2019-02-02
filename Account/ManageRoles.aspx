<%@ Page Title="Manage Roles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="IncidentManagement.Account.ManageRoles" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder ID="loginForm" runat="server">
                <div class="form-horizontal">
                    <h4>Manage Roles</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="RoleName" CssClass="col-md-2 control-label">RoleName</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="RoleName" CssClass="form-control" />
                            <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="RoleName"
                                CssClass="text-danger" ErrorMessage="The RoleName field is required." />--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="AddRole" Text="Add Role" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                <p class="text-info">
                    Role has been added successfully.
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <div class="form-horizontal">
                    <h4>Manage Users</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="PlaceHolder2" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="Literal1" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:GridView CssClass="table table-striped table-bordered table-condensed" ID="grdUsers" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="sdsUsers" Width="100%" 
                            OnRowDataBound="grdUsers_RowDataBound" OnRowEditing="grdUsers_RowEditing" OnRowUpdating="grdUsers_RowUpdating" OnRowDeleting="grdUsers_RowDeleting">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                <asp:BoundField DataField="UserID" SortExpression="CAR_Number" Visible="false" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="CAR_Number" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRole" Text='<%#Bind("Role") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlRole" AppendDataBoundItems="True" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                            SelectCommand="Select tbUser.Id as UserID, UserName, tbRoles.Name as Role, tbRoles.Id from AspNetUsers tbUser left outer join AspNetUserRoles tbUroles on tbUroles.UserId = tbUser.Id left outer join AspNetRoles tbRoles on tbRoles.Id = tbUroles.RoleId"
                            DeleteCommand="DELETE FROM [AspNetUsers] WHERE [id]=@id;">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="string" />
                            </DeleteParameters>
                            </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sdsRoles" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                            SelectCommand="Select * from  AspNetRoles"></asp:SqlDataSource>

                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="PlaceHolder3" Visible="false">
                <p class="text-info">
                    Role has been added successfully.
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
