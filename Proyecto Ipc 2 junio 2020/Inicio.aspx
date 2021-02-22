<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Proyecto1.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 1479px; height: 724px">
        
        <asp:Label ID="Label1" runat="server" Text="Nombre del Empleado" style="position: absolute; top: 120px; left: 80px;"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Meta: $" style="position: absolute; top: 172px; left: 80px;"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="BIENVENIDO" style="position: absolute; top: 120px; left: 45%;" Font-Size="XX-Large"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Nit: " style="position: absolute; top: 146px; left: 80px; height: 27px;"></asp:Label>
        <div  style="position: absolute; top: 191px; left: 13%; width: 1149px; height: 563px;">
            <div style="height: 198px; position: absolute; top: 15%; left: 47px; width: 292px; margin-top: 0px;">
            <a href="/Ventas" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Ventas</a></div>
            <div style="height: 199px; position: absolute; top: 15%; left: 418px; width: 297px; margin-top: 0px;">
            <a href="/Ordenes" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Ordenes</a></div>
            <div style="height: 199px; position: absolute; top: 57%; left: 790px; width: 297px; margin-top: 0px;">
            <a href="/Facturas" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Facturas</a></div>
            <div style="height: 200px; position: absolute; top: 57%; left: 47px; width: 297px; margin-top: 0px;">
            <a href="/Clientes" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Clientes</a></div>
            <div style="height: 199px; position: absolute; top: 57%; left: 418px; width: 297px; margin-top: 0px;">
            <a href="/Recibos" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Recibos</a></div>
            <div style="height: 199px; position: absolute; top: 15%; left: 790px; width: 297px; margin-top: 0px;">
            <a href="/Pagos" class="btn btn-primary btn-lg" style="position: absolute; top: 40%; right: 85px; height: 45px; width: 115px;">Pagos</a></div>
        </div>
            <asp:Label ID="Label5" runat="server" Text="Ventas: $" style="position: absolute; top: 202px; left: 80px;"></asp:Label>
        </div>
</asp:Content>
