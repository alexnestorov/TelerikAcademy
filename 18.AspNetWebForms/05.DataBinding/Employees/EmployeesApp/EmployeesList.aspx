<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeesList.aspx.cs" Inherits="EmployeesApp.EmployeesList" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
        <h1>EMPLOYEES LIST</h1>
        <asp:ListView ID="ListViewEmployees" runat="server">

            <ItemTemplate>
                <ul>
                    <li>
                        <strong>ID: </strong><%#: Eval("EmployeeID") %>
                        </li>
                    <li>
                        <strong>Last name: </strong><%#: Eval("LastName") %>
                        </li>
                    <li>
                        <strong>First name: </strong><%#: Eval("FirstName") %>
                        </li>
                    <li>
                        <strong>Title: </strong><%#: Eval("Title") %>
                        </li>
                    <li>
                        <strong>Title of courtesy: </strong><%#: Eval("TitleOfCourtesy") %>
                        </li>
                    <li>
                        <strong>Birth date: </strong><%#: Eval("BirthDate") %>
                        </li>
                    <li>
                        <strong>Hire date: </strong><%#: Eval("HireDate") %>
                        </li>
                    <li>
                        <strong>Address: </strong><%#: Eval("Address") %>
                        </li>
                    <li>
                        <strong>City: </strong><%#: Eval("City") %>
                        </li>
                    <li>
                        <strong>Region: </strong><%#: Eval("Region") %>
                        </li>
                    <li>
                        <strong>Postal code: </strong><%#: Eval("PostalCode") %>
                        </li>
                    <li>
                        <strong>Country: </strong><%#: Eval("Country") %>
                        </li>
                    <li>
                        <strong>Home phone: </strong><%#: Eval("HomePhone") %>
                        </li>
                    <li>
                        <strong>Extension: </strong><%#: Eval("Extension") %>
                        </li>
                    <li>
                        <strong>Notes: </strong><%#: Eval("Notes") %>
                        </li>
                    <li>
                        <strong>Photo path: </strong><%#: Eval("PhotoPath") %>
                        </li>
                </ul>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
