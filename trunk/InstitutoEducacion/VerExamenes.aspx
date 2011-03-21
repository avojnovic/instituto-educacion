<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerExamenes.aspx.cs" Inherits="InstitutoEducacion.VerExamenes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br />
  <br />
   <br />


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" 
                GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="Solid" 
                BorderWidth="2px" HorizontalAlign="Center" Width="100%" Font-Size="Small" 
                Font-Names="Frutiger-Roman" PageSize="20" 
             onpageindexchanging="GridView1_PageIndexChanging"      >
                <PagerSettings PageButtonCount="5" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>
                    <asp:BoundField DataField="MateriaStr" HeaderText="Materia" ReadOnly="True"  />
                    <asp:BoundField DataField="FechaStr" HeaderText="Fecha" ReadOnly="True"  />
                    <asp:BoundField DataField="NotaStr" HeaderText="Nota"  />

                   
                </Columns>
               
                <SelectedRowStyle BackColor="Silver" HorizontalAlign="Center" 
                    VerticalAlign="Middle" />
               
                <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
               
            </asp:GridView>
        </div>
            
       
         <br />
    <br />

    
</asp:Content>