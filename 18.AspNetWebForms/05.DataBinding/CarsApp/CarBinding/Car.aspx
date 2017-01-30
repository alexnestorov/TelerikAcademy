<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Car.aspx.cs" Inherits="CarBinding.Car" %>

<asp:Content ID="Cars" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search for Car</h1>
    <div class="form-group jumbotron">
        <span id="producer">
            <asp:Label ID="Producer1" runat="server" Text="Producer: " CssClass="label color" />
            <asp:DropDownList ID="DropDownListProducer" runat="server" DataTextField="Name"
                DataValueField="Name" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged">
            </asp:DropDownList>
        </span>
        <span id="model">
            <asp:Label ID="Model" runat="server" Text="Model: " CssClass="label color" />
            <asp:DropDownList ID="DropDownListModel" runat="server">
            </asp:DropDownList>
        </span>
        <div>
            <asp:Label ID="TypeOfEngine" runat="server" Text="Type of engine: " CssClass="label color" />
            <asp:RadioButtonList ID="RadioButtonListTypeOfEngine" runat="server" RepeatDirection="Horizontal" />
        </div>
        <div>
            <asp:Label ID="Extras1" runat="server" Text="Extras: " CssClass="label color" />
            <asp:CheckBoxList runat="server" ID="CheckBoxListExtras" RepeatDirection="Vertical" DataTextField="Name" DataValueField="Id" />
        </div>
        <div>
            <asp:Button class="btn btn-warning col-xs-3" Text="Submit" runat="server" ID="ButtonSubmit" OnClick="ButtonSubmit_Click" />
        </div>
        <br />
        <div class="jumbotron background">
            <asp:Literal ID="LiteralResult" runat="server" />
        </div>
    </div>
</asp:Content>
