<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" Inherits="InstitutoEducacion.Inscripcion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 359px;
        }
        .style2
        {
            width: 73px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="margin-right: 0px">

                       

    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server" Text="Inscripcion a Materias"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Materias Inscriptas"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:CheckBoxList ID="ListMateriasCheck" runat="server" BorderColor="Black" 
                        Height="300px" Width="300px" AutoPostBack="True" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        ToolTip="Seleccione las materias en que se desea inscribir." >
                    </asp:CheckBoxList>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:ListBox ID="ListBoxMateriasInscriptas" runat="server" Height="300px" 
                        Width="300px"></asp:ListBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="BtnGuardar" runat="server" 
                        Text="Inscribirse" onclick="BtnGuardar_Click" />
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnSalir" runat="server" Text="Salir" 
                        onclick="BtnSalir_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td align="center" class="style1">
                    &nbsp;</td>
                <td align="center" class="style2">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

                       

    
    </div>
        
    
</asp:Content>