<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="WebApp_ADO_oct_16_4_25.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Roll Number</td><td>
                    <asp:TextBox ID="txtRoll" runat="server" Width="434px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
    <td>Name</td><td>
    <asp:TextBox ID="txtName" runat="server" Width="438px"></asp:TextBox>
    </td>
</tr>
                <tr>
    <td>Total Marks</td><td>
    <asp:TextBox ID="txtTotalMarks" runat="server" Width="437px"></asp:TextBox>
    </td>
</tr>
                <tr>
    <td colspan="2">
        <asp:Button ID="tbnInsert" runat="server" Text="Add Student" OnClick="tbnInsert_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search Student" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Enabled="False" OnClick="btnDelete_Click" Text="Delete Record" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnupdate" runat="server" Enabled="False" OnClick="btnupdate_Click" style="height: 26px" Text="Update Record" />
                    </td>
</tr>
            </table>
        </div>
    </form>
</body>
</html>
