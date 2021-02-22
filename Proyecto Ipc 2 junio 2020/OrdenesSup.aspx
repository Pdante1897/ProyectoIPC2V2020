<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrdenesSup.aspx.cs" Inherits="Proyecto1.OrdenesSup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 838px">
        <asp:GridView ID="GridView2" runat="server" style="position:absolute; top: 186px; left: 451px;" CellPadding="4" ForeColor="#333333" >
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
        <div style="position:absolute; height: 295px; width: 392px; top: 138px; left: 34px;" >
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 50px; left: 210px;"></asp:TextBox>
            <asp:Label style="position:absolute; top: 50px; left: 70px; height: 20px;" ID="Label5" runat="server" Text="Codigo Orden"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Aprobar" style="position:absolute; top: 201px; left: 73px;" OnClick="Button1_Click"  />
            <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="Datos Orden" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Seleccionar" style="position:absolute; top: 88px; left: 154px;" OnClick="Button5_Click"  />
        <asp:Button ID="Button6" runat="server" Text="Anular" style="position:absolute; top: 201px; right: 58px; width: 99px;" OnClick="Button6_Click"  />
        </div>
        <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text="Ordenes" style="position:absolute; top: 127px; left: 540px;"></asp:Label>
    </div>
</asp:Content>
