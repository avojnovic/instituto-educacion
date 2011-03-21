<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AsignacionMateria.aspx.cs" Inherits="InstitutoEducacion.Images.AsignacionMateria" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 127px;
        }
        .style2
        {
            width: 324px;
        }
        .style3
        {
            width: 109px;
        }
        .style4
        {
            width: 127px;
            height: 23px;
        }
        .style5
        {
            width: 324px;
            height: 23px;
        }
        .style6
        {
            width: 109px;
            height: 23px;
        }
        .style7
        {
            height: 23px;
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
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server" Text="Profesor:"></asp:Label>
                </td>
                <td class="style2" >
                    <asp:DropDownList ID="CmbProfesores" runat="server" AutoPostBack="True" 
                        Height="23px" ondatabinding="CmbProfesores_DataBinding" 
                        onselectedindexchanged="CmbProfesores_SelectedIndexChanged" Width="300px">
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label2" runat="server" Text="Materia:"></asp:Label>
                </td>
                <td class="style2" >
                    <asp:DropDownList ID="CmbMaterias" runat="server" Height="23px" Width="300px">
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    <asp:Button ID="BtnAsignar" runat="server" onclick="BtnAsignar_Click" 
                        Text="Asignar" />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Materias Asignadas a Profesor:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:ListBox ID="ListBoxMateriasAsignadas" runat="server" Height="121px" 
                        Width="246px"></asp:ListBox>
                    <asp:Button ID="BtnQuitar" runat="server" onclick="BtnQuitar_Click" 
                        Text="Quitar" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style4">
                </td>
                <td class="style5">
                </td>
                <td class="style6">
                </td>
                <td class="style7">
                    </td>
            </tr>
            
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td align="center" class="style1">
                    &nbsp;</td>
                <td align="center" class="style2">
                    &nbsp;</td>
                <td align="center" class="style3">
                    <asp:Button ID="BtnSalir" runat="server" Text="Salir" 
                        onclick="BtnSalir_Click" style="height: 26px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

                       

    
    </div>
</asp:Content>
