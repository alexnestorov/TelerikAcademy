<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="WebFormsControlsApp.Homework.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="random_generator" runat="server">
    <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
            <div>
            Min:
        <asp:TextBox ID="Min number:" runat="server"></asp:TextBox>
            <br />
            Max:
        <asp:TextBox ID="Max number:" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Btn_Generate_Random" runat="server" OnClick="Btn_Generate_Random_Click" Text="Generate Random Number" CssClass="btn btn-success"/>
            <asp:Label ID="randomNumber" runat="server" Text="Result: "></asp:Label>
        </div>
    </form>
</body>
</html>
