<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ClientesA.aspx.cs" Inherits="Proyecto1.ClientesA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 1089px">
        
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
        
        <div style="position:absolute; height: 511px; width: 392px; top: 138px; left: 34px;" >
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 50px; left: 210px;"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" style="position:absolute; top: 80px; left: 210px; bottom: 409px;"></asp:TextBox>
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
            <asp:Button ID="Button1" runat="server" Text="Registrar" style="position:absolute; top: 449px; left: 156px;" OnClick="Button1_Click1" />
        
            <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="REGISTRAR" style="position:absolute; top: 3px; left: 142px;"></asp:Label>
        </div>

        <asp:FileUpload ID="FileUpload1" runat="server" style="position:absolute; top: 109px; right: 50px;"/>
        
            <asp:Button ID="Button2" runat="server" Text="Cargar" style="position:absolute; top: 104px; right: 404px;" OnClick="Button2_Click" />
        
        <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text="CLIENTES" style="position:absolute; top: 127px; left: 540px;"></asp:Label>
        
        <asp:FileUpload ID="FileUpload2" runat="server" style="position:absolute; top: 721px; height: 22px; left: 186px;"/>
        
            <asp:Button ID="Button3" runat="server" Text="Cargar" style="position:absolute; top: 723px; left: 99px; height: 26px;" OnClick="Button3_Click"  />
        
        <asp:Label ID="Label15" runat="server" Text="Ciudades" style="position:absolute; top: 687px; left: 30px; height: 20px;"></asp:Label>

        <asp:FileUpload ID="FileUpload3" runat="server" style="position:absolute; top: 679px; left: 185px;; height: 22px; "/>
        
            <asp:Button ID="Button4" runat="server" Text="Cargar" style="position:absolute; top: 678px; left: 99px;" OnClick="Button4_Click"  />
        
        <asp:Label ID="Label16" runat="server" Text="Dep" style="position:absolute; top: 731px; left: 37px; width: 26px;"></asp:Label>
        
        <div style="height: 346px; width: 400px; position:absolute; top: 763px; left: 28px;" >

            <asp:Label style="position:absolute; top: 204px; left: 35px; height: 20px;" ID="Label17" runat="server" Text="Vigencia inicio"></asp:Label>
            <asp:Label style="position:absolute; top: 249px; left: 34px; height: 16px;" ID="Label18" runat="server" Text="Vijencia fin"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Asignar" style="position:absolute; top: 298px; left: 148px; height: 28px;" OnClick="Button5_Click"  />
        
            <asp:Label ID="Label19" runat="server" Font-Size="X-Large" Text="Asignar Lista" style="position:absolute; top: 54px; left: 124px;"></asp:Label>
        
            <asp:TextBox ID="TextBox13" runat="server" style="position:absolute; top: 127px; left: 145px; bottom: 197px;"></asp:TextBox>
            <asp:TextBox ID="TextBox14" runat="server" style="position:absolute; top: 161px; left: 145px; "></asp:TextBox>
            <asp:TextBox ID="TextBox15" runat="server" style="position:absolute; top: 204px; left: 145px; "></asp:TextBox>
            <asp:TextBox ID="TextBox16" runat="server" style="position:absolute; top: 247px; left: 144px; "></asp:TextBox>

            <asp:Label style="position:absolute; top: 129px; left: 36px; height: 20px;" ID="Label20" runat="server" Text="Nit"></asp:Label>
            <asp:Label style="position:absolute; top: 161px; left: 36px; height: 16px;" ID="Label21" runat="server" Text="Codigo Lista"></asp:Label>
        </div>
        
            <asp:Button ID="Button6" runat="server" Text="Cargar" style="position:absolute; top: 143px; right: 404px;" OnClick="Button6_Click"  />
        
        <asp:FileUpload ID="FileUpload4" runat="server" style="position:absolute; top: 140px; right: 51px;"/>
        
        <asp:Label ID="Label22" runat="server" Text="Clientes" style="position:absolute; top: 107px; left: 751px; height: 20px;"></asp:Label>

        <asp:Label ID="Label23" runat="server" Text="Lista" style="position:absolute; top: 146px; left: 754px; height: 20px;"></asp:Label>

        </div>
</asp:Content>
