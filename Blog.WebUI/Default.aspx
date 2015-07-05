<%@ Page Theme="Theme1" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Blog.WebUI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Список корстувачів</h1>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="Blog.Repository.EFUserRepository"
        SelectMethod="GetUsers"  OnUpdating="ObjectDataSource1_Updating" UpdateMethod="UpdateUser">
        <UpdateParameters> 
            <asp:Parameter Name="IsEnable" Type="Boolean" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" DataKeyNames="Id" Height="256px" Width="218px"
        AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="true" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" ReadOnly="true" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" ReadOnly="true" />
            <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login"  ReadOnly="true"/>
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" ReadOnly="true"/>
            <asp:CheckBoxField DataField="IsAdmin" HeaderText="IsAdmin" SortExpression="IsAdmin" ReadOnly="true" />
            <asp:CheckBoxField DataField="IsEnable" HeaderText="IsEnable" SortExpression="IsEnable" />
        </Columns>

        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />

    </asp:GridView>
    <br />
    <br />
</asp:Content>
