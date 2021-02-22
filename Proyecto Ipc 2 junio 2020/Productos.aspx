<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Proyecto1.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 709px">
        <asp:Button ID="Button1" runat="server" Text="Cargar" style="position:absolute; top: 171px; left: 120px;" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Categorias" style="position:absolute; top: 172px; left: 46px;"></asp:Label>
        <asp:FileUpload ID="FileUpload2" runat="server" style="position:absolute; top: 174px; left: 229px;"/>
        <asp:Button ID="Button2" runat="server" Text="Cargar" style="position:absolute; top: 229px; left: 118px;" OnClick="Button2_Click" />
        <asp:FileUpload ID="FileUpload3" runat="server" style="position:absolute; top: 230px; left: 231px;"/>
        <asp:Button ID="Button3" runat="server" Text="Cargar" style="position:absolute; top: 292px; left: 119px;" OnClick="Button3_Click" />
        <asp:FileUpload ID="FileUpload4" runat="server" style="position:absolute; top: 295px; left: 230px;"/>
        <asp:Label ID="Label2" runat="server" Text="Productos" style="position:absolute; top: 232px; left: 47px;"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Precios" style="position:absolute; top: 292px; left: 48px;"></asp:Label>
        
        <asp:GridView ID="GridView2" runat="server" style="position:absolute; top: 186px; left: 570px; height: 120px;" CellPadding="4" ForeColor="#333333" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
        
        <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text="Productos" style="position:absolute; top: 127px; left: 622px;"></asp:Label>
        
        <asp:GridView ID="GridView3" runat="server" style="position:absolute; top: 188px; left: 1000px; height: 120px;" CellPadding="4" ForeColor="#333333" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
        
        <asp:Button ID="Button4" runat="server" Text="Cargar" style="position:absolute; top: 346px; left: 119px;" OnClick="Button4_Click"  />
        <asp:FileUpload ID="FileUpload5" runat="server" style="position:absolute; top: 345px; left: 230px;"/>
        <asp:Label ID="Label15" runat="server" Text="Monedas" style="position:absolute; top: 345px; left: 49px;"></asp:Label>
        
    </div>
</asp:Content>
