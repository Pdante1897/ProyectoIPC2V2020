<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Proyecto1.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 838px">
        <asp:GridView ID="GridView1" style="position:absolute; top: 213px; left: 486px; height: 19px; width: 601px;" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Nit" />
                <asp:BoundField HeaderText="Nombres" />
                <asp:BoundField HeaderText="Apellidos" />
                <asp:BoundField HeaderText="Puesto" />
                <asp:BoundField HeaderText="E-mail" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <div style="position:absolute; height: 219px; width: 392px; top: 222px; left: 32px;" >
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 50px; left: 210px;"></asp:TextBox>
        <asp:Label style="position:absolute; top: 80px; left: 70px;" ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" style="position:absolute; top: 80px; left: 210px; "></asp:TextBox>
        <asp:Label style="position:absolute; top: 50px; left: 70px; height: 20px;" ID="Label5" runat="server" Text="Nit"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Registrar" style="position:absolute; top: 157px; left: 144px;" />
        
            <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="REGISTRAR" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
        
            
        </div>
        <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text="Vehiculos" style="position:absolute; top: 127px; left: 622px;"></asp:Label>
    </div>
</asp:Content>
