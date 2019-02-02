<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarEdit.aspx.cs" MasterPageFile="~/Site.Master" Inherits="IncidentManagement.Car2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
<style type="text/css">
        .auto-style1 {
            width: 168px;
        }
        .auto-style2 {
            width: 47px;
        }
        .auto-style3 {
            width: 120px;
        }
        .auto-style4 {
            height: 23px;
        }
    </style>
    <script lang="javascript">

        function validateInt(key) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            //comparing pressed keycodes
            if ((keycode != 8) && (keycode < 48 || keycode > 57)) {
                alert('Please enter only numeric values');
                return false;
            }
            else {
                return true;
            }
}
    </script>
    <br />
    <table aria-readonly="True"   ="80" style="width: 900px">
        <tr>
            <td>
                <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="" Visible="false"></asp:Label></td>
        </tr>

    </table>
    <br />
        <div class="row col-md-4">
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Network Grid/BA</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlNetworkGrid" runat="server" 
                        OnSelectedIndexChanged="ddlNetworkGrid_OnSelectedIndexChanged"  AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="NetworkGrid" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [NetworkGrid_BA]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>BusinessZone/Grid</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlBusinessZone" runat="server" 
                        OnSelectedIndexChanged="ddlBusinessZone_OnSelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="BusinessZone" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [BusinessZone_Grid] WHERE ([NetworkGridID] = @NetworkGridID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlNetworkGrid" Name="NetworkGridID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span>
                        <b>DMZ/Facility</b>
                    </span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlDMZ" runat="server">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DMZ" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [DMZFacility] WHERE ([BusinessZoneID] = @BusinessZoneID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlBusinessZone" Name="BusinessZoneID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Equipment/Appurtance</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlEquip" runat="server" AutoPostBack="True" DataSourceID="Equipment" DataTextField="Equipment/Appurtenance" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Equipment" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Equipment Appurtenance]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Type Of Equipment</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="True" DataSourceID="TypeOfEquipment" DataTextField="Type" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="TypeOfEquipment" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Type$]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Size</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlSize" runat="server" AutoPostBack="True" DataSourceID="Size" DataTextField="Size" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Size" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Size]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin" style="margin-top: 25px">
                <span>
                    <b>Location:</b>
                </span>
            </div>
            <div class="row topmargin" style="margin-top: 25px">
                <span>
                    <b>List Of Affected Brgy.:</b>
                </span>
            </div>
            <div class="row topmargin" style="margin-top: 25px">
                <span>
                    <b>List Of Affected Municipality:</b>
                </span>
            </div>
            <div class="row topmargin" style="margin-top: 25px">
                <span>
                    <b>List Of Affected MRU:</b>
                </span>
            </div>
            <div class="row topmargin" style="margin-top: 25px">
                <span>
                    <b>List Of Affected DMA:</b>
                </span>
            </div>
            <div class="row topmargin" style="margin-top: 25px">
                <span>
                    <b>Number Of Afected Household:</b>
                </span>
            </div>

        </div>
        <div class="row col-md-4 leftmargin">
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Classification</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control col-md-6" ID="ddlClassification" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClassification_OnSelectedIndexChanged"><%-- DataSourceID="sdsClassification" DataTextField="Classification" DataValueField="ID">--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sdsClassification" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Classification]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Incident/Event</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control col-md-6" ID="ddlEvent" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEvent_OnSelectedIndexChanged"><%-- DataSourceID="sdsEvent" DataTextField="Incident_Event" DataValueField="ID">--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sdsEvent" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" OnSelecting="Event_Selecting1" 
                        SelectCommand="SELECT * FROM [Incident_Event] WHERE ([CatergoryID] = @CatergoryID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlClassification" Name="CatergoryID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Type Of Activity:</b>
                    </span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlAct" runat="server"><%-- AutoPostBack="True" OnSelectedIndexChanged="ddlAct_SelectedIndexChanged" DataSourceID="Activity"--%>
                        <%--DataTextField="ActivityType" DataValueField="ID">--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Activity" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [ActivityType] WHERE ([IncidentID] = @IncidentID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlEvent" Name="IncidentID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Affected Area</b>
                    </span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlArea" DataSourceID="Affected_Area" runat="server" AutoPostBack="True"
                        DataTextField="AffectedArea" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Affected_Area" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [AffectedArea]">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlEvent" Name="IncidentID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Contractor</b></span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlContractor" runat="server" AutoPostBack="True" DataSourceID="Contractor" DataTextField="Contractorractor" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Contractor" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Contractor]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row topmargin">
                <div class="col-md-6">
                    <span><b>Means of Notification</b>
                    </span>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList CssClass="form-control" ID="ddlMeans" runat="server" AutoPostBack="True">
                        <asp:ListItem>Flyers/Notice</asp:ListItem>
                        <asp:ListItem>Barangay</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row topmargin">
                <asp:TextBox CssClass="form-control" ID="txtLocation" runat="server"></asp:TextBox>
            </div>
            <div class="row topmargin">
                <asp:TextBox CssClass="form-control" ID="txtMunicipality" runat="server"></asp:TextBox>
            </div>
            <div class="row topmargin">
                <asp:TextBox CssClass="form-control" ID="txtBrgy" runat="server"></asp:TextBox>
            </div>
            <div class="row topmargin">
                <asp:TextBox CssClass="form-control" ID="txtMRU" runat="server"></asp:TextBox>
            </div>
            <div class="row topmargin">
                <asp:TextBox CssClass="form-control" ID="txtDMA" runat="server"></asp:TextBox>
            </div>
            <div class="row topmargin">
                <asp:TextBox CssClass="form-control" ID="txtHousehold" TextMode="Number" onkeypress="return validateInt(event)"   runat="server"></asp:TextBox>
            </div>
            <div class="row topmargin">
                <asp:Button CssClass="form-control btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
        <div class="row col-md-4 leftmargin">

            <div class="row topmargin">
                <span><b>Remarks:</b></span>
                <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>

            </div>
            <div class="row topmargin">
                <span><b>Message:</b></span>
                <asp:TextBox CssClass="form-control" ID="xtMessage" runat="server" TextMode="MultiLine"></asp:TextBox>

            </div>
        </div>
   
    </asp:Content>
