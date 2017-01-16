<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NewsFeedApp.Home" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h1>NEWS FEED</h1>
    <h2>TOP ARTICLES</h2>
    <asp:Repeater runat="server" ID="repeaterArticle" ItemType="NewsFeedApp.Data.Models.Article" SelectMethod="repeaterArticle_GetData">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-6">
                    <h3>
                        <a href="ViewArticle.aspx?id=<%# Item.Id %>"><%#: Item.Title %></a>
                        <small><%#: Item.Category.Name %></small>
                    </h3>
                    <p>
                        <%#: Item.Content %>
                    </p>
                    <p>
                        Likes: <%# Item.Likes.Count() %>
                    </p>
                    <i>by <%#: Item.Author.UserName %> created on: <%# Item.DateCreated %>
                    </i>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
