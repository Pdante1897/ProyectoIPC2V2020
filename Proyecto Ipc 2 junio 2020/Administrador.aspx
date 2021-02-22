<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Proyecto1.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 1460px; height: 776px">
        
        <asp:Label ID="Label1" runat="server" Text="Administrador" style="position: absolute; top: 120px; left: 80px;"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="BIENVENIDO" style="position: absolute; top: 120px; left: 45%;" Font-Size="XX-Large"></asp:Label>

        <div  style="position: absolute; top: 191px; left: 13%; width: 1149px; height: 563px;">
            <div style="height: 200px; position: absolute; top: 15%; left: 47px; width: 300px; margin-top: 0px;">
            <a href="/Usuarios" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">vehiculos</a></div>
            <div style="height: 200px; position: absolute; top: 15%; left: 418px; width: 300px; margin-top: 0px;">
            <a href="/Metas" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Metas</a></div>
            <div style="height: 200px; position: absolute; top: 57%; left: 790px; width: 300px; margin-top: 0px;">
            <a href="/Reportes" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Reportes</a></div>
            <div style="height: 200px; position: absolute; top: 57%; left: 47px; width: 300px; margin-top: 0px;">
            <a href="/ClientesA" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Clientes</a></div>
            <div style="height: 200px; position: absolute; top: 57%; left: 418px; width: 300px; margin-top: 0px;">
            <a href="/Empleados" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Empleados</a></div>
            <div style="height: 200px; position: absolute; top: 15%; left: 790px; width: 300px; margin-top: 0px;">
            <a href="/Productos" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Productos</a></div>
        </div>

        <asp:Label ID="Label4" runat="server" Text="Administrador" style="position: absolute; top: 149px; left: 81px;"></asp:Label>

        </div>
</asp:Content>
