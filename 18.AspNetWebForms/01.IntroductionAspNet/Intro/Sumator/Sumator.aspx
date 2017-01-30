<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="Sumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sumator</title>
    <link rel="~/Content/bootstrap.css"/>
</head>
<body>
    <form id="formSumator" runat="server">
        <h1>Sumator</h1>
        <label>First Number:</label>
        <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        <br />        
        <label>Second Number:</label>
        <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonCalculateSum" runat="server"
            OnClick="ButtonCalculateSum_Click" Text="Calculate Sum" class="btn btn-success"/>
        <br />
        <label>Sum:</label>
        <asp:TextBox ID="TextBoxSum" runat="server"></asp:TextBox>
    </form>
</body>
</html>
