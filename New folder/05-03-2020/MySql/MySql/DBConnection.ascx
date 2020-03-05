<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DBConnection.ascx.cs" Inherits="MySql.DBConnection" %>
<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem Value="select">select</asp:ListItem>
    <asp:ListItem Value="mysql">MySql</asp:ListItem>
    <asp:ListItem Value="mssql">MS Sql</asp:ListItem>
</asp:DropDownList>
