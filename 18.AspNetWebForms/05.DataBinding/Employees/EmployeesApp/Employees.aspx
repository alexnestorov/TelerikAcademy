<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Employees.aspx.cs" Inherits="EmployeesApp.Employees" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" CssClass="jumbotron">
    <h1>Employees</h1>

    <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" >
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperlinkDetails" runat="server" NavigateUrl='<%# "EmployeeDetails.aspx?id=" + Eval("EmployeeID") %>'>
                        <asp:Label ID="Name" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
