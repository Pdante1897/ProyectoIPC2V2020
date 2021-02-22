<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Proyecto1.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 838px">
        <div style="position:absolute; height: 366px; width: 392px; top: 138px; left: 34px;" >
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 50px; left: 165px;"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" style="position:absolute; top: 95px; left: 162px; "></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" style="position:absolute; top: 147px; left: 161px; "></asp:TextBox>
            <asp:Label style="position:absolute; top: 47px; left: 29px; height: 20px;" ID="Label5" runat="server" Text="Nit Cliente"></asp:Label>
            <asp:Label style="position:absolute; top: 147px; left: 24px;" ID="Label4" runat="server" Text="Fecha fin"></asp:Label>
            <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="Datos Orden" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Seleccionar" style="position:absolute; top: 240px; left: 211px;" OnClick="Button1_Click1" />
            <asp:Label style="position:absolute; top: 94px; left: 28px; height: 20px;" ID="Label18" runat="server" Text="Fecha inicio"></asp:Label>
        </div>
        <div style="position:absolute; height: 366px; width: 392px; top: 141px; left: 518px;" >
            <asp:TextBox ID="TextBox6" runat="server" style="position:absolute; top: 50px; left: 165px;"></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server" style="position:absolute; top: 95px; left: 162px; "></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" style="position:absolute; top: 147px; left: 161px; "></asp:TextBox>
            <asp:Label style="position:absolute; top: 47px; left: 29px; height: 20px;" ID="Label19" runat="server" Text="Nit Cliente"></asp:Label>
            <asp:Label style="position:absolute; top: 147px; left: 24px;" ID="Label20" runat="server" Text="Fecha fin"></asp:Label>
            <asp:Label ID="Label21" runat="server" Font-Size="X-Large" Text="Datos Orden" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
            <asp:Button ID="Button6" runat="server" Text="Seleccionar" style="position:absolute; top: 240px; left: 211px;" OnClick="Button1_Click1" />
            <asp:Label style="position:absolute; top: 94px; left: 28px; height: 20px;" ID="Label22" runat="server" Text="Fecha inicio"></asp:Label>
        </div>
    </div>
</asp:Content>
