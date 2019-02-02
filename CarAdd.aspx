<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarAdd.aspx.cs" MasterPageFile="~/Site.Master"  Inherits="IncidentManagement.Car" %>

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
             try height: 23px;
         }
     </style>
     <table aria-readonly="True" style="width: 900px">
         <tr>
             <td colspan="4"><asp:Label ID="lblResult" runat="server"></asp:Label></td>
         </tr>
    <tr>
     <td>Network Grid/BA   </td>
        <td class="auto-style1"> <asp:DropDownList ID="ddlNetworkGrid" runat="server" DataSourceID="NetworkGrid" DataTextField="NetworkGrid_BA" DataValueField="ID" AutoPostBack="True">
         </asp:DropDownList>
         <asp:SqlDataSource ID="NetworkGrid" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [NetworkGrid_BA]"></asp:SqlDataSource>
     </td>
     <td class="auto-style2">Business Zone/Grid </td>
     <td> <asp:DropDownList ID="ddlBusinessZone" runat="server" DataSourceID="BusinessZone" DataTextField="BusinessZone_Grid" DataValueField="ID" AutoPostBack="True">
         </asp:DropDownList>
         <asp:SqlDataSource ID="BusinessZone" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [BusinessZone_Grid] WHERE ([NetworkGridID] = @NetworkGridID)">
             <SelectParameters>
                 <asp:ControlParameter ControlID="ddlNetworkGrid" Name="NetworkGridID" PropertyName="SelectedValue" Type="Int32" />
             </SelectParameters>
         </asp:SqlDataSource>
     </td>
     <td class="auto-style3">DMZ/Facility  
         <asp:DropDownList ID="ddlDMZ" runat="server" DataSourceID="DMZ" DataTextField="DMZ_Facility" DataValueField="ID" AutoPostBack="True">
         </asp:DropDownList>
         <asp:SqlDataSource ID="DMZ" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [DMZFacility] WHERE ([BusinessZoneID] = @BusinessZoneID)">
             <SelectParameters>
                 <asp:ControlParameter ControlID="ddlBusinessZone" Name="BusinessZoneID" PropertyName="SelectedValue" Type="Int32" />
             </SelectParameters>
         </asp:SqlDataSource>
     </td>
 </tr>
  <tr>
     <td>Classification:</td>
    <td class="auto-style1">
        <asp:DropDownList ID="ddlClassification" runat="server" Width="141px" AutoPostBack="True" DataSourceID="Classification" DataTextField="Classification" DataValueField="ID">
            <asp:ListItem>Planned</asp:ListItem>
            <asp:ListItem>Emergency</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="Classification" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Classification]"></asp:SqlDataSource>
    </td>
    <td class="auto-style2">Location: </td>
    <td colspan="2">
        <asp:TextBox ID="txtLocation" runat="server" Width="432px" AutoPostBack="True"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td>Incident/Event:</td>
    <td class="auto-style1">
        <asp:DropDownList ID="ddlEvent" runat="server" Height="18px" Width="141px" AutoPostBack="True" DataSourceID="Event" DataTextField="Incident_Event" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Event" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" OnSelecting="Event_Selecting1" 
            SelectCommand="SELECT * FROM [Incident_Event] WHERE ([CatergoryID] = @CatergoryID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlClassification" Name="CatergoryID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
      </td>
    <td class="auto-style2" >List of Affected Brgy.:</td>
    <td colspan="2">
        <asp:TextBox ID="txtBrgy" runat="server" Width="432px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td>Type of Activity: </td>
    <td class="auto-style1">
        <asp:DropDownList ID="ddlAct" runat="server" Height="19px" Width="141px" AutoPostBack="True" OnSelectedIndexChanged="ddlAct_SelectedIndexChanged" DataSourceID="Activity" DataTextField="ActivityType" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Activity" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [ActivityType] WHERE ([IncidentID] = @IncidentID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlEvent" Name="IncidentID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
      </td>
    <td class="auto-style2">List of Affected Municipality: </td>
    <td colspan="2">
        <asp:TextBox ID="txtMunicipality" runat="server" Width="432px"></asp:TextBox>
      </td>
  </tr>
  <tr>
      <td>Equipment/Appurtance:</td>
      <td class="auto-style1">
          <asp:DropDownList ID="ddlEquip" runat="server" Width="141px" AutoPostBack="True" DataSourceID="Equipment" DataTextField="Equipment/Appurtenance" DataValueField="ID">
          </asp:DropDownList>
          <asp:SqlDataSource ID="Equipment" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Equipment Appurtenance]"></asp:SqlDataSource>
      </td>
      <td class="auto-style2">List of Affected MRU </td>
      <td colspan="2">
        <asp:TextBox ID="txtMRU" runat="server" Width="432px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td>&nbsp;Type of Equipment:</td>
    <td class="auto-style1">
        <asp:DropDownList ID="ddlType" runat="server" Height="16px" Width="141px" AutoPostBack="True" DataSourceID="TypeOfEquipment" DataTextField="Type" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="TypeOfEquipment" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Type$]"></asp:SqlDataSource>
      </td>
    <td class="auto-style2">List of Affected DMA:</td>
    <td colspan="2">
        <asp:TextBox ID="txtDMA" runat="server" Width="432px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td>Size: </td>
    <td class="auto-style1">
        <asp:DropDownList ID="ddlSize" runat="server" Width="141px" AutoPostBack="True" DataSourceID="Size" DataTextField="Size" DataValueField="ID">                      
        </asp:DropDownList>                   
        <asp:SqlDataSource ID="Size" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Size]"></asp:SqlDataSource>
      </td>
    <td class="auto-style2">No. of Affected Household:</td>
    <td colspan="2">
        <asp:TextBox ID="txtHousehold" runat="server" Width="432px" AutoPostBack="True"></asp:TextBox>
      </td>
  </tr>
    <tr>
      <td>Affected Area: </td>
      <td class="auto-style1">
          <asp:DropDownList ID="ddlArea" runat="server" Width="141px" AutoPostBack="True" DataSourceID="AffectedArea" DataTextField="AffectedArea" DataValueField="ID">
          </asp:DropDownList>
          <asp:SqlDataSource ID="AffectedArea" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [AffectedArea]"></asp:SqlDataSource>
        </td>
      <td class="auto-style2"></td>
      <td></td>
  </tr>
    <tr>
      <td>Contractor:</td>
      <td class="auto-style1">
          <asp:DropDownList ID="ddlContractor" runat="server" Width="141px" AutoPostBack="True" DataSourceID="Contractor" DataTextField="Contractorractor" DataValueField="ID">
          </asp:DropDownList>
          <asp:SqlDataSource ID="Contractor" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" SelectCommand="SELECT * FROM [Contractor]"></asp:SqlDataSource>
        </td>
      <td colspan="3" colspan="2">
          <table>
              <tr>
                 <td colspan="3"></td> MEMBERS OF THE INCIDENT MANAGEMENT TEAM 
              </tr>
              <tr>
                  <td></td>
                  <td>Name</td>
                  <td>Contact Number</td>
                  <td>E-mail Address</td>
              </tr>
              <tr>
                  <td class="auto-style4">OIM</td>
                  <td class="auto-style4">
                      <asp:DropDownList ID="ddlOIM" Width="190px" AutoPostBack="True" OnSelectedIndexChanged="ddlOIM_SelectedIndexChanged"
                          runat="server"></asp:DropDownList>
                      <asp:SqlDataSource ID="sdsOIM" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" 
                          SelectCommand="Select Concat(tbUser.Id, '_' , Email ,'_' , PhoneNumber) AS IEM, UserName from AspNetUsers tbUser inner join AspNetUserRoles tbUserRole on tbUser.Id = tbUser.id
                                         inner join aspnetroles tbRole on tbRole.Id = tbUserRole.RoleId where tbUser.id = tbUserRole.UserId and tbRole.Name like '%oim%'"></asp:SqlDataSource>
                  </td>
                  <td class="auto-style4"><asp:TextBox ID="txtOIDnum" ReadOnly="true" runat="server"></asp:TextBox><asp:TextBox ID="txtOimID" Visible="false" runat="server"></asp:TextBox>
                  </td>
                  <td class="auto-style4"><asp:TextBox ID="txtOIDemail" ReadOnly="true" runat="server" Width="270px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>CIM</td>
                  <td><asp:DropDownList ID="ddlCIM" Width="190px" AutoPostBack="True" OnSelectedIndexChanged="ddlCIM_SelectedIndexChanged"  
                          runat="server"></asp:DropDownList>
                      <asp:SqlDataSource ID="sdsCIM" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" 
                          SelectCommand="Select Concat(tbUser.Id, '_' , Email ,'_' , PhoneNumber) AS IEM, UserName from AspNetUsers tbUser inner join AspNetUserRoles tbUserRole on tbUser.Id = tbUser.id
                                         inner join aspnetroles tbRole on tbRole.Id = tbUserRole.RoleId where tbUser.id = tbUserRole.UserId and tbRole.Name like '%cim%'"></asp:SqlDataSource>
                  </td>
                  <td><asp:TextBox ID="txtCIMnum" ReadOnly="true" runat="server"></asp:TextBox><asp:TextBox ID="txtCimID" Visible="false" runat="server"></asp:TextBox>
                  </td>
                  <td><asp:TextBox ID="txtCIMemail" ReadOnly="true" runat="server" Width="270px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>SIM</td>
                  <td><asp:DropDownList ID="ddlSIM" Width="190px" AutoPostBack="True"  OnSelectedIndexChanged="ddlSIM_SelectedIndexChanged"  
                          runat="server"></asp:DropDownList>
                      <asp:SqlDataSource ID="sdsSIM" runat="server" ConnectionString="<%$ ConnectionStrings:DbContext %>" 
                         SelectCommand="Select Concat(tbUser.Id, '_' , Email ,'_' , PhoneNumber) AS IEM, UserName from AspNetUsers tbUser inner join AspNetUserRoles tbUserRole on tbUser.Id = tbUser.id
                                         inner join aspnetroles tbRole on tbRole.Id = tbUserRole.RoleId where tbUser.id = tbUserRole.UserId and tbRole.Name like '%sim%'"></asp:SqlDataSource>
                  </td>
                  <td><asp:TextBox ID="txtSIMnum" ReadOnly="true" runat="server"></asp:TextBox><asp:TextBox ID="txtSimID" Visible="false" runat="server"></asp:TextBox>
                  </td>
                  <td><asp:TextBox ID="txtSIMemail" ReadOnly="true" runat="server" Width="270px"></asp:TextBox>
                  </td>
              </tr>
          </table>
      </td>
      <td class="auto-style3"></td>
  </tr>
    <tr>
      <td>Means of Notification</td>
      <td class="auto-style1">
          <asp:DropDownList ID="ddlMeans" runat="server" Width="141px" AutoPostBack="True">
              <asp:ListItem>Flyers/Notice</asp:ListItem>
              <asp:ListItem>Barangay</asp:ListItem>
          </asp:DropDownList>
        </td>
      <td class="auto-style3"></td>
      <td></td>
  </tr>
         
  <tr>
        <td>
             Remarks:
        </td> 
      <td colspan="3">
     <asp:TextBox ID="txtRemarks" runat="server" Height="63px" TextMode="MultiLine" Width="770px"></asp:TextBox>
      </td>
  </tr>
  <tr>
      <td>
          <asp:Button ID="emailBtnTry" runat="server" OnClick="emailBtnTry_Click" Text="Try Email" />
      </td>
      <td class="auto-style1">
          <asp:Button ID="btnSmsSend" runat="server" Height="26px" OnClick="btnSmsSend_Click1" Text="Send SMS" />
          <asp:Label ID="lblText" runat="server"></asp:Label>
      </td>
      <td class="auto-style2" colspan="2"><asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="113px" OnClick="btnSubmit_Click" /></td>
      
  </tr>
         
<tr>
    <td>
        Message:
    </td>
    <td colspan="3">
     <asp:TextBox ID="txtMessage" runat="server" Height="63px" TextMode="MultiLine" Width="770px" OnTextChanged="Page_Load"></asp:TextBox>
    </td>
</tr>

<tr>
    <td></td>
    <td colspan="3">
        
        &nbsp;</td>
</tr>
         </table> 

     

</asp:Content>

