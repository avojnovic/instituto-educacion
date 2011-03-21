<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="InstitutoEducacion.Materias" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
  <br />
   <br />
  <asp:Button ID="BtnEditar" runat="server"  
        Text="Editar" onclick="BtnEditar_Click"   />
    <asp:Button ID="BtnNuevo" runat="server" 
        Text="Nuevo" onclick="BtnNuevo_Click" />
    <asp:Button ID="BtnBorrar" runat="server" 
        Text="Borrar" style="height: 26px" onclick="BtnBorrar_Click"   />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" 
                GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="Solid" 
                BorderWidth="2px" HorizontalAlign="Center" Width="100%" Font-Size="Small" 
                Font-Names="Frutiger-Roman" PageSize="20"  
                AutoGenerateSelectButton="True" onpageindexchanging="GridView1_PageIndexChanging" 
              >
                <PagerSettings PageButtonCount="5" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>
                    <asp:BoundField DataField="IdMateria" HeaderText="Id" ReadOnly="True"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True"  />
                    <asp:BoundField DataField="CodigoStr" HeaderText="Codigo"  />

                   
                </Columns>
               
                <SelectedRowStyle BackColor="Silver" HorizontalAlign="Center" 
                    VerticalAlign="Middle" />
               
                <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
               
            </asp:GridView>
        </div>
            
       
         <br />
    <br />

    
</asp:Content>
