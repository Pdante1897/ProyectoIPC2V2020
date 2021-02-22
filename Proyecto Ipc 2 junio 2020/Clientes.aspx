<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Proyecto1.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 838px">
        
        <asp:GridView ID="GridView2" runat="server" style="position:absolute; top: 186px; left: 442px; height: 120px;" CellPadding="4" ForeColor="#333333" HorizontalAlign="Center" >
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
        
        <div style="position:absolute; height: 511px; width: 392px; top: 138px; left: 34px;" >
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 50px; left: 210px;"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" style="position:absolute; top: 80px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" style="position:absolute; top: 110px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" style="position:absolute; top: 140px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" style="position:absolute; top: 170px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server" style="position:absolute; top: 200px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server" style="position:absolute; top: 230px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" style="position:absolute; top: 260px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox9" runat="server" style="position:absolute; top: 290px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox10" runat="server" style="position:absolute; top: 320px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox11" runat="server" style="position:absolute; top: 350px; left: 210px; "></asp:TextBox>
            <asp:TextBox ID="TextBox12" runat="server" style="position: absolute; top: 380px; left: 210px;"></asp:TextBox>

            <asp:Label style="position:absolute; top: 170px; left: 70px; height: 20px;" ID="Label1" runat="server" Text="Direccion"></asp:Label>
            <asp:Label style="position:absolute; top: 80px; left: 70px;" ID="Label2" runat="server" Text="Nombres"></asp:Label>
            <asp:Label style="position:absolute; top: 290px; left: 70px; height: 20px;" ID="Label3" runat="server" Text="Ciudad"></asp:Label>
            <asp:Label style="position:absolute; top: 50px; left: 70px; height: 20px;" ID="Label5" runat="server" Text="Nit"></asp:Label>
            <asp:Label style="position:absolute; top: 200px; left: 70px;;" ID="Label6" runat="server" Text="Telefono"></asp:Label>
            <asp:Label style="position:absolute; top: 110px; left: 70px;; height: 20px;" ID="Label7" runat="server" Text="Apellidos"></asp:Label>
            <asp:Label style="position:absolute; top: 140px; left: 70px;" ID="Label4" runat="server" Text="Fecha nacimiento"></asp:Label>
            <asp:Label style="position:absolute; top: 230px; left: 70px; height: 20px;" ID="Label8" runat="server" Text="Celular"></asp:Label>
            <asp:Label style="position:absolute; top: 320px; left: 70px; height: 20px;" ID="Label9" runat="server" Text="Departamento"></asp:Label>
            <asp:Label style="position:absolute; top: 260px; left: 70px; height: 20px;" ID="Label10" runat="server" Text="E-mail"></asp:Label>
            <asp:Label style="position:absolute; top: 350px; left: 70px; height: 20px;" ID="Label11" runat="server" Text="Limite de Credito"></asp:Label>
            <asp:Label style="position:absolute; top: 380px; left: 70px; height: 20px;" ID="Label12" runat="server" Text="Dias de credito"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Registrar" style="position:absolute; top: 449px; left: 156px; height: 26px;" OnClick="Button1_Click" />
        
            <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="REGISTRAR" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
        </div>

        <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text="CLIENTES" style="position:absolute; top: 127px; left: 540px;"></asp:Label>
        
    </div>
</asp:Content>
