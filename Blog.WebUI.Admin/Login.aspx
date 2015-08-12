<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Blog.WebUI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Label ID="lbl_wrongLogin" runat="server" Text="Wrong login or password. Please, try again"></asp:Label>
    </asp:Panel>
    <asp:Login ID="Login1" runat="server" OnLoggingIn="Login1_LoggingIn" OnAuthenticate="Login1_Authenticate"></asp:Login>
    
</asp:Content>
