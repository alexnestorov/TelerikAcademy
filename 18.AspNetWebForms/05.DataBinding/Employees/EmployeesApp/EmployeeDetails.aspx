<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeDetails.aspx.cs" Inherits="EmployeesApp.EmployeeDetails" %>

<asp:content id="BodyContent" contentplaceholderid="MainContent" runat="server" cssclass="jumbotron">
    <h1>Employee Details</h1>
        <asp:DetailsView ID="DetailsViewEmployee" runat="server" DataMember="Employee" AutoGenerateRows="false">
            <Fields>
                <asp:BoundField DataField="FirstName" HeaderText="First name" />
                <asp:BoundField DataField="LastName" HeaderText="Last name" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="BirthDate" HeaderText="Birth date" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Region" HeaderText="Region" />
                <asp:BoundField DataField="PostalCode" HeaderText="Postal code" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="HomePhone" HeaderText="Home phone" />
                <asp:BoundField DataField="Extension" HeaderText="Extension" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" />
                <asp:BoundField DataField="PhotoPath" HeaderText="Photo URL" />
            </Fields>
        </asp:DetailsView>

        <asp:Button runat="server" ID="ButtonBack" Text="Back" OnClick="ButtonBack_Click" CssClass="btn btn-info"/>
</asp:content>
