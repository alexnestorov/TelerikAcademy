<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscapingHTML.aspx.cs" Inherits="WebFormsControlsApp.Homework.EscapingHTML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="Escaping" runat="server">
    <div>
        <asp:TextBox ID="InputText" runat="server" Width="440px"></asp:TextBox>
        <br/>
        <asp:Button ID="BtnShowText" runat="server" OnClick="BtnShowText_Click" Text="Generate" />
        <br/>
        <asp:TextBox ID="OutputText" runat="server" Width="440px"></asp:TextBox>
        <br/>
        <asp:Label ID="LabelOutputText" runat="server" Width="440px" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
