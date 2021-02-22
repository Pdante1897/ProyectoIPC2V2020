<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 1292px; height: 610px">
        <div style="width: 247px; height: 267px; top: 31%; left: 40%; position: absolute;">
            <asp:Label ID="Label1" runat="server" Text="User" style="top: 20%; left: 5%; position: absolute;" ></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="16px"  style="top: 20%; left: 40%; position: absolute;"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Password" style="top: 30%; left: 5%; position: absolute;"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Height="16px"  style="top: 30%; left: 40%; position: absolute;"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Iniciar" style="top: 40%; left: 50%; position: absolute;" OnClick="Button1_Click"  />
            <asp:Label ID="Label3" runat="server" Text="Login" style="top: 4%; left: 50%; position: absolute;" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" ></asp:Label>
        </div>
    </div>
</asp:Content>
