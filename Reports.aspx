<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" MasterPageFile="~/Site.Master" Inherits="IncidentManagement.Reports" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row align-center" style="margin-top:10px">
        <asp:DropDownList runat="server" OnSelectedIndexChanged="ddlFrequency_SelectedIndexChanged" AutoPostBack="true" ID="ddlFrequency">
            <asp:ListItem Text="Weekly" />
            <asp:ListItem Text="Monthly" />
            <asp:ListItem Text="Yearly" />
        </asp:DropDownList>
    </div>
    <div class="row">
        <div class="col-sm-5">
            <div class="row jumbotron">
                <asp:Chart ID="chartCompare" runat="server">
                    <Titles>
                        <asp:Title Text="Incidents Delayed vs On Time" Font="Verdana, 10 pt, style=Bold"></asp:Title>
                    </Titles>

                    <%-- <Series>
                        <asp:Series Name="seriesOnTime" ToolTip="On Time">
                            <Points>
                                <asp:DataPoint AxisLabel="On Time" />
                            </Points>
                        </asp:Series>
                        <asp:Series Name="seriesDelayed" ToolTip="Delayed">
                            <Points>
                                <asp:DataPoint AxisLabel="Delayed" />
                            </Points>
                        </asp:Series>
                    </Series>--%>
                    <ChartAreas>
                        <asp:ChartArea Name="chartArea">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div class="row jumbotron">
                <asp:Chart ID="chartIncidentByLocation" runat="server">
                    <Titles>
                        <asp:Title Text="Incidents By Location" Font="Verdana, 10 pt, style=Bold"></asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="seriesIncidentByLocation">
                        </asp:Series>

                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="areaLocation">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
        <div class="col-sm-1"></div>
        <div class="col-sm-5">
            <div class="row jumbotron">
                <asp:Chart ID="chartIncidentType" runat="server" Width="400px" Height="400px">
                    <Titles>
                        <asp:Title Text="Incidents By Type  " Font="Verdana, 10 pt, style=Bold"></asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="seriesIncidentType" ChartType="Pie">
                        </asp:Series>

                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="areaIncident">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </div>



</asp:Content>

