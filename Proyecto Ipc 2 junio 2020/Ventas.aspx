<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Proyecto1.WebForm2" %>
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
        <div style="position:absolute; height: 366px; width: 392px; top: 138px; left: 34px;" >
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 50px; left: 165px;"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" style="position:absolute; top: 212px; left: 162px; "></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" style="position:absolute; top: 242px; left: 162px; "></asp:TextBox>
           
            <asp:Label style="position:absolute; top: 245px; left: 33px; height: 20px;" ID="Label1" runat="server" Text="Cantidad"></asp:Label>
            <asp:Label style="position:absolute; top: 47px; left: 29px; height: 20px;" ID="Label5" runat="server" Text="Nit Cliente"></asp:Label>
            <asp:Label style="position:absolute; top: 214px; left: 31px;" ID="Label4" runat="server" Text="Codigo Producto"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Agregar" style="position:absolute; top: 292px; left: 272px;" OnClick="Button1_Click" />
            <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="Datos Orden" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Seleccionar" style="position:absolute; top: 84px; left: 246px;" OnClick="Button1_Click1" />
            <asp:TextBox ID="TextBox6" runat="server" style="position:absolute; top: 126px; left: 163px;"></asp:TextBox>
            <asp:Label style="position:absolute; top: 128px; left: 30px; height: 20px;" ID="Label18" runat="server" Text="Lista de precios"></asp:Label>
            <asp:Button ID="Button7" runat="server" Text="Seleccionar" style="position:absolute; top: 160px; left: 246px;" OnClick="Button7_Click"  />
        </div>
        <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text="Ventas" style="position:absolute; top: 127px; left: 540px;"></asp:Label>
        <asp:Label ID="Label17" runat="server" Text="Label" style="position:absolute; top: 138px; left: 864px;"></asp:Label>
        <asp:GridView ID="GridView3" runat="server" style="position:absolute; top: 531px; left: 77px;" CellPadding="4" ForeColor="#333333" >
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
            <asp:Button ID="Button6" runat="server" Text="Cerrar orden" style="position:absolute; top: 135px; right: 128px; width: 99px;" OnClick="Button6_Click" />
    </div>
</asp:Content>
