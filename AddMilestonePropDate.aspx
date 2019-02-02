<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMilestonePropDate.aspx.cs" Inherits="IncidentManagement.AddMilestonePropDate" %>

<!DOCTYPE html>

<html>
<head>
    <title>Incidents Report Management System</title>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet">
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                alert("Milestone has saved successfully!");
                //window.opener.location.reload();
                window.opener.document.getElementById('MainContent_btnRefresh').click();
                window.close();
            }
        }
        function CloseMe() {
            //if (window.opener != null && !window.opener.closed) {
            //window.opener.location.reload();
            //window.opener.document.getElementById('MainContent_btnRefresh').click();
            window.close();
            //}
        }
    </script>
</head>
<body>
    <h2>Set Proposed Date for Milestone</h2>
    <div>
        <form id="formMethod" runat="server" class="form-group">
            <table style="width: 500px" class="table table-striped table-bordered table-condensed">
                <tr>
                    <td style="width: 10%">Proposed Date</td>
                    <td>
                        <asp:TextBox ID="txtPropDate"
                            Width="90%" runat="server"></asp:TextBox>
                        &nbsp;<asp:Calendar ID="calPropDate" SelectionMode="DayWeekMonth" OnSelectionChanged="calPropDate_SelectionChanged" runat="server"></asp:Calendar>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Set Proposed Date" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnClose" runat="server" CssClass="btn btn-primary" Text="Close" OnClick="btnClose_Click" />
                    </td>
                </tr>
            </table>



        </form>
    </div>
</body>
</html>
