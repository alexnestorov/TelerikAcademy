<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWebForms.aspx.cs" Inherits="HelloAspNet.HelloWebForms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Hello" runat="server">
        <div>
            <asp:Label ID="LabelText" runat="server">Text</asp:Label>
            <asp:TextBox ID="Text" runat="server"></asp:TextBox>
            <asp:Button ID="Button" OnClick="DisplayText_Click" runat="server" Text="Enter" />
            <asp:TextBox ID="ResultText" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
