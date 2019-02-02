    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
    EnableEventValidation="false"  
    Inherits="IncidentManagement._Default" %>

<script runat="server">

    protected void ExcelBtn_Click(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="margin-top: 20px">
            
        <table><tr><td>
                <asp:Label ID="lblErr" Visible="false" runat="server" ForeColor="Red"></asp:Label>
                </td></tr>
        <tr><td>
        <asp:GridView CssClass="table table-striped table-bordered table-condensed" ID="grvActMonitor" runat="server" 
            AllowSorting="true" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="CAR_Number"  Width="100%" OnPreRender="grvActMonitor_OnPreRender"
            OnRowEditing="grvActMonitor_RowEditing" OnRowDataBound="grvActMonitor_RowDataBound" OnRowCommand="grvActMonitor_RowCommand" OnRowDeleting ="grvActMonitor_RowDeleting"
            OnSorting="grdMilestones_Sorting" OnPageIndexChanging="grvActMonitor_PageIndexChanging"  PageSize="15">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="CAR_Number" HeaderText="CAR Number" SortExpression="CAR_Number" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Incident" HeaderText="Incident" SortExpression="Incident" />
                <asp:BoundField DataField="Classification" HeaderText="Classification" SortExpression="Classification" />
                <asp:BoundField DataField="Type_Of_Activity" HeaderText="Planned/Emergency" SortExpression="Type_Of_Activity" />
                <asp:BoundField DataField="NetworkGrid_BA" HeaderText="Network Grid" SortExpression="NetworkGrid_BA" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
                <%--<asp:BoundField DataField="[Actual Date and Time of Start]" HeaderText="Start" SortExpression="Color" />
                <asp:BoundField DataField="[Actual Date and Time of Completion]" HeaderText="End" SortExpression="Color" />--%>
                <asp:ButtonField ButtonType="Link" CommandName="UpdateDetails" Text="Update Details" />
                
            </Columns>
        </asp:GridView></td></tr>
            <tr><td>
                <asp:Button ID="ExcelBtn" runat="server" Text="Export in Excel" CssClass="btn btn-primary" CausesValidation="False" OnClick="ExcelBtn_Click" />
        <asp:Button ID="btnAddCar" runat="server" Text="Add New Incident" CssClass="btn btn-primary" OnClick="btnAddCar_Click" />
                </td></tr><//table>
        
    </div>

</asp:Content>
