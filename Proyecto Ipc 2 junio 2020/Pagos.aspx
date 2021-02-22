<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="Proyecto1.Pagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 838px">
        <div style="position:absolute; height: 366px; width: 392px; top: 138px; left: 34px;" >
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 50px; left: 161px;"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" style="position:absolute; top: 157px; left: 162px; "></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" style="position:absolute; top: 242px; left: 162px; "></asp:TextBox>
            <asp:Label style="position:absolute; top: 245px; left: 33px; height: 20px;" ID="Label1" runat="server" Text="Monto a pagar"></asp:Label>
            <asp:Label style="position:absolute; top: 47px; left: 29px; height: 20px;" ID="Label5" runat="server" Text="Codigo Orden"></asp:Label>
            <asp:Label style="position:absolute; top: 159px; left: 33px;" ID="Label4" runat="server" Text="Tipo de pago"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Pagar" style="position:absolute; top: 277px; left: 287px;" OnClick="Button1_Click"  />
            <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="Datos Orden" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Seleccionar" style="position:absolute; top: 82px; left: 254px;" OnClick="Button5_Click"  />
            <asp:TextBox ID="TextBox6" runat="server" style="position:absolute; top: 126px; left: 163px;"></asp:TextBox>
            <asp:Label style="position:absolute; top: 128px; left: 30px; height: 20px;" ID="Label18" runat="server" Text="Moneda"></asp:Label>
            <asp:Button ID="Button7" runat="server" Text="Seleccionar" style="position:absolute; top: 188px; left: 251px;" OnClick="Button7_Click"  />
        </div>
        <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text="Pagos" style="position:absolute; top: 127px; left: 540px;"></asp:Label>
        <asp:Label ID="Label17" runat="server" Text="Monto Total:" style="position:absolute; top: 127px; left: 863px; "></asp:Label>
        <asp:GridView ID="GridView3" runat="server" style="position:absolute; top: 224px; left: 487px;" CellPadding="4" ForeColor="#333333" >
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
        <asp:Label ID="Label19" runat="server" Text="Monto Abonado:" style="position:absolute; top: 156px; left: 862px; right: 287px;"></asp:Label>
        <asp:Label ID="Label20" runat="server" Text="Monto Restante:" style="position:absolute; top: 183px; left: 862px; right: 282px; "></asp:Label>
    </div>
</asp:Content>
