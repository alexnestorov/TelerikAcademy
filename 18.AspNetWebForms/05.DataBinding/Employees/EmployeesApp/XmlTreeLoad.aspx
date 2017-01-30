<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="XmlTreeLoad.aspx.cs" Inherits="EmployeesApp.XmlTreeLoad" %>

  <asp:Content runat="server" ContentPlaceHolderID="MainContent">
        <div>

            <asp:FileUpload ID="FileUpload" runat="server" />
            <asp:Button ID="ButtonLoad" runat="server" OnClick="ButtonLoad_Click" Text="Load" />
            <br />

            <asp:TreeView ID="TreeViewFromXml" runat="server" CollapseImageUrl="~/input/collapse.gif" ExpandImageUrl="~/input/exp.gif" NoExpandImageUrl="~/input/dropdown.gif">
            </asp:TreeView>

        </div>
    </asp:Content>
