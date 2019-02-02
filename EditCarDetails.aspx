<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarDetails.aspx.cs" Inherits="IncidentManagement.EditCarDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script lang="javascript">
        function OpenAddValve() {
            var varCarID = document.getElementById('MainContent_txtCarID').value;
            window.open("AddEditValveManipulation.aspx?CarID=" + varCarID, '_blank', 'width=500 ,height=400');
        }

        function OpenMilestonePDate(sUrl) {
            var sURI = 'AddMilestoneProp.aspx';
            window.open(sUrl, '_blank', 'width=500 ,height=350');
            return false;
        }

        function OpenMethodology() {
            var varCarID = document.getElementById('MainContent_txtCarID').value;
            window.open("AddMethodology.aspx?CarID=" + varCarID, '_blank', 'width=500 ,height=350');
            return false;
        }

        function OpenNewUpdate(){
            var varCarID = document.getElementById('MainContent_txtCarID').value;
            window.open("AddNewUpdate.aspx?CarID=" + varCarID, '_blank', 'width=500 ,height=350');
            return false;
        }

        //function LoadCarDetails() {

        //  //  $("#tab1default").load('/Car2.aspx');
        //}


        //$(document).ready(function () {
        //    LoadCarDetails();
       //);
    </script>

    <script type="text/javascript" lang="javascript">
    $(document).ready(function () {
        var tab = document.getElementById('<%= hidTAB.ClientID%>').value;
        $(this).tab('show');
        $(tab).addClass('active')
       // alert(tab);
    });
</script>


    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="panel with-nav-tabs panel-default">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            
                            <%--class="active"--%>
                            <li class="active"><a href="#tab0default" data-toggle="tab">Milestones</a></li>
                            <li><a href="#tab2default" data-toggle="tab">Valve Manipulation</a></li>
                            <li><a href="#tab3default" data-toggle="tab">Methodology</a></li>
                            <li><a href="#tab4default" data-toggle="tab">What Ifs</a></li>
                            <li><a href="#tab5default" data-toggle="tab">Material/Tools & Equipment</a></li>
                            <li><a href="#tab6default" data-toggle="tab">Manpower/Health & Safety</a></li>
                            <li><a href="#tab7default" data-toggle="tab">Updates</a></li>
                            <li style="display:none;"><a href="#tab8default" id="tabUpdate" data-toggle="tab" onclick="javascript:LoadCarDetails();">Update CAR</a></li>
                        </ul>
                    </div>
                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane" id="tab1default">Default 1</div>
                            <%--tab-pane fade in active--%>
                            <div class="tab-pane text-center" id="tab0default">
                                <%--row text-center col-md-offset-3--%>

                                <asp:GridView ID="grdMilestones" runat="server" CssClass="table table-striped table-bordered table-condensed"
                                    DataSourceID="sdsMilestoneSource" DataKeyNames="CarID" AutoGenerateColumns="false" OnPreRender="grdMilestones_OnPreRender"
                                    OnRowDataBound="grdMilestones_RowDataBound" EmptyDataText="No records has been added."
                                    OnRowCommand="grdMilestones_RowCommand" >
                                    <Columns>
                                        <asp:BoundField DataField="MilestoneNumber" ReadOnly="true" HeaderText="Milestone" />
                                        <asp:BoundField DataField="Propsed"  HeaderText="Proposed Date" />
                                        <asp:BoundField DataField="Actual" ReadOnly="true" HeaderText="Actual Date" />
                                        <asp:BoundField DataField="EndTime" ReadOnly="true" HeaderText="End Time" />
                                        <asp:BoundField HeaderText="Duration" ReadOnly="true" />
                                        <asp:BoundField HeaderText="Status" ReadOnly="true" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Start" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Cancel"  Text="Cancel" />
                                        <asp:CommandField  ShowEditButton="True" />
                                        <asp:BoundField DataField="CarNo" Visible="false" HeaderText="Milestone" />
                                    </Columns>

                                </asp:GridView>
                                <asp:SqlDataSource ID="sdsMilestoneSource" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                                    SelectCommand="SELECT * FROM [DETAILS_MILESTONES] WHERE CarNo = @CarNo"></asp:SqlDataSource>
                            </div>

                            <div class="tab-pane text-center" id="tab2default">
                                <asp:GridView ID="grdValve" runat="server" CssClass="table table-striped table-bordered table-condensed" DataSourceID="sdsValveManipulation" DataKeyNames="ID" AutoGenerateColumns="false" OnRowEditing="grdValve_RowEditing"
                                    OnRowDataBound="OnRowDataBound" EmptyDataText="No records exist!">
                                    <Columns>
                                        <asp:CommandField ButtonType="Link" ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="ValveNumber" HeaderText="No" ReadOnly="true" />
                                        <asp:BoundField DataField="Location" HeaderText="Location" />
                                        <asp:BoundField DataField="Size" HeaderText="Size" />
                                        <asp:BoundField DataField="PresentStatus" HeaderText="Present Status" />
                                        <asp:BoundField DataField="ProposedStatus" HeaderText="Proposed Status" />
                                        <asp:BoundField DataField="StatusAfterActivity" HeaderText="Status After Activity" />
                                    </Columns>

                                </asp:GridView>
                                <br />
                                <input type="button" id="btnNewValve" runat="server" class="btn btn-primary" value="Add New Valve Manipulation" onclick="OpenAddValve();" />
                                <asp:SqlDataSource ID="sdsValveManipulation" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                                    SelectCommand="SELECT ID, ValveNumber,Location, Size, PresentStatus, [Proposed Status] As ProposedStatus, [Status After the Activity] AS StatusAfterActivity from [Details_ValveManipulationTable] WHERE CarID = @CarID"
                                    InsertCommand="INSERT INTO Details_ValveManipulationTable VALUES (@ValveNumber, @Location,@Size,@PresentStatus,@ProposedStatus,@StatusAftertheActivity)"
                                    UpdateCommand="UPDATE Details_ValveManipulationTable SET Location = @Location, [Size] = @Size, [PresentStatus] = @PresentStatus, [Proposed Status] = @ProposedStatus, [Status After the Activity] = @StatusAfterActivity WHERE ID = @ID"
                                    DeleteCommand="DELETE FROM [Details_ValveManipulationTable] WHERE [ID] = @ID">

                                    <DeleteParameters>
                                        <asp:Parameter Name="ID" Type="Int32" />
                                    </DeleteParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ID" Type="Int32" />
                                        <asp:Parameter Name="Location" Type="String" />
                                        <asp:Parameter Name="Size" Type="String" />
                                        <asp:Parameter Name="PresentStatus" Type="String" />
                                        <asp:Parameter Name="ProposedStatus" Type="String" />
                                        <asp:Parameter Name="StatusAfterActivity" Type="String" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>

                            </div>
                            <div class="tab-pane" id="tab3default">
                                <asp:GridView ID="grdMethodology" runat="server" CssClass="table table-striped table-bordered table-condensed" 
                                    DataSourceID="sdsMethodology" DataKeyNames="ID"  AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="CarID" HeaderText="CarID" ReadOnly="true" Visible="false" />
                                        <asp:BoundField DataField="MethodologyNumber" HeaderText="No" ReadOnly="true" />
                                        <asp:BoundField DataField="Activity" HeaderText="Activity" />
                                        <asp:BoundField DataField="Start" HeaderText="Start" />
                                        <asp:BoundField DataField="End" HeaderText="End" />
                                        <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                    </Columns>

                                </asp:GridView>
                                <input type="button" ID="btnNewMehotdology" runat="server" class="btn btn-primary" value="Add New Methodology" onclick="OpenMethodology();" />
                                <asp:SqlDataSource ID="sdsMethodology" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                                    SelectCommand="Select * from [Details_Methodology] WHERE CarID = @CarID"></asp:SqlDataSource>
                            </div>
                            <div class="tab-pane" id="tab4default">
                                <asp:TextBox ID="txtWhatIfs" TextMode="MultiLine" Width="90%" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="btnSaveWhatIf" runat="server" CssClass="btn btn-primary" Text="Save WhatIf" OnClick="btnSaveWhatIf_Click" />
                            </div>
                            <div class="tab-pane" id="tab5default">
                                <asp:TextBox ID="txtMaterial" Visible="true" TextMode="MultiLine" Width="45%" runat="server"></asp:TextBox>&nbsp;
                                <asp:TextBox ID="txtToolsEquipment" TextMode="MultiLine" Visible="true" Width="45%" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="btnSaveMatToolsEquip" runat="server" CssClass="btn btn-primary" Text="Save Materials Tool & Equipments" OnClick="btnSaveMatToolsEquip_Click" />
                            </div>
                            <div class="tab-pane" id="tab6default">
                                <asp:TextBox ID="txtManPower" TextMode="MultiLine" Visible="true" Width="45%" runat="server"></asp:TextBox>&nbsp;
                                <asp:TextBox ID="txtHealthySafety" TextMode="MultiLine" Visible="true" Width="45%" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="btnSaveManPowerHealthSafety" runat="server" CssClass="btn btn-primary" Text="Save ManPower Health & Safety" OnClick="btnSaveManPowerHealthSafety_Click" />
                            </div>
                             <div class="tab-pane" id="tab7default">
                                 <table style="width:95%">
                                     <tr><td style="text-align:right">
                                         <input type="button" ID="btnNewUpdate" style="text-align:right" runat="server" class="btn btn-primary" value="Add New Update" onclick="OpenNewUpdate();" />
                                         </td></tr>
                                     <tr><td>&nbsp;</td></tr>
                                     <tr><td>
                                         <asp:GridView ID="grvUpdates" runat="server" CssClass="table table-striped table-bordered table-condensed" 
                                    DataSourceID="sdsUpdates" DataKeyNames="ID"  AutoGenerateColumns="false" EmptyDataText="No records exist!">
                                    <Columns>
                                        <asp:BoundField DataField="CarNumber" HeaderText="CarNumber" ReadOnly="true" Visible="false" />
                                        <asp:BoundField ItemStyle-Width="10%" DataField="Rank" HeaderText="Update No." ReadOnly="true" />
                                        <asp:BoundField ItemStyle-Width="70%" DataField="Details" HeaderText="Details" ReadOnly="true" />
                                        <asp:BoundField DataField="DateCreated" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date Created" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
                                    </Columns>

                                </asp:GridView>
                                
                                <asp:SqlDataSource ID="sdsUpdates" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>"
                                    SelectCommand="Select ID,Rank() OVER(PARTITION BY CarNumber  ORDER BY ID) Rank, CarNumber, Details, DateCreated, CreatedBy from [CarUpdates] 
                                    WHERE CarNumber = @CarID ORDER BY ID DESC"></asp:SqlDataSource></td></tr>
                                 </table>
                                
                            </div>
                            <div class="tab-pane" id="tab8default">Default 5</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="txtCarID" Style="display: none;" runat="server"></asp:TextBox>
    <asp:Button ID="btnRefresh" Style="visibility:hidden" runat="server" OnClick="btnRefresh_Click" Text="Refresh" />
    <asp:HiddenField ID="hidTAB" runat="server" Value="#tab0default" />
    <br />
</asp:Content>
