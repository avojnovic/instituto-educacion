<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MateriaEdit.aspx.cs" Inherits="InstitutoEducacion.MateriaEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 190px;
        }
        .style2
        {
            width: 91px;
        }
        .style3
        {
            width: 236px;
        }
        .style4
        {
            width: 29px;
        }
        .style5
        {
            width: 7px;
        }
        .style6
        {
            width: 228px;
        }
        .style7
        {
            width: 91px;
            height: 25px;
        }
        .style8
        {
            width: 190px;
            height: 25px;
        }
        .style9
        {
            width: 29px;
            height: 25px;
        }
        .style10
        {
            width: 228px;
            height: 25px;
        }
        .style11
        {
            width: 7px;
            height: 25px;
        }
        .style12
        {
            width: 236px;
            height: 25px;
        }
        .style13
        {
            height: 25px;
        }
        .style14
        {
            width: 91px;
            height: 228px;
        }
        .style15
        {
            width: 190px;
            height: 228px;
        }
        .style16
        {
            width: 29px;
            height: 228px;
        }
        .style17
        {
            width: 228px;
            height: 228px;
        }
        .style18
        {
            width: 7px;
            height: 228px;
        }
        .style19
        {
            width: 236px;
            height: 228px;
        }
        .style20
        {
            height: 228px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="margin-right: 0px">

                       

    
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label6" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                <td class="style1">
                    <asp:TextBox ID="TxtNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6" align="center" colspan="3">
                    <asp:Label ID="Label9" runat="server" Text="Asignacion de Correlatividades"></asp:Label>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Codigo:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="TxtCodigo" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Label ID="Label8" runat="server" Text="Todas las Materias:"></asp:Label>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Label7" runat="server" Text="Materias Correlativas:"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14">
                    </td>
                <td class="style15">
                    </td>
                <td class="style16">
                    </td>
                <td class="style17">
                    <asp:ListBox ID="ListBoxMateriasTodas" runat="server" Height="100%" 
                        Width="100%" AutoPostBack="True" 
                        onselectedindexchanged="ListBoxMateriasTodas_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="style18">
                    <asp:Button ID="BtnQtarCorrelativa" runat="server" 
                        onclick="BtnQtarCorrelativa_Click" Text="&lt;" />
                    <asp:Button ID="BtnAgrCorrelativa" runat="server" 
                        onclick="BtnAgrCorrelativa_Click" Text="&gt;" />
                </td>
                <td class="style19">
                    <asp:ListBox ID="ListBoxMateriasCorrelativas" runat="server" Height="100%" 
                        Width="100%" AutoPostBack="True" 
                        onselectedindexchanged="ListBoxMateriasCorrelativas_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="style20">
                    </td>
            </tr>

            
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6" align="center" colspan="3">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style7">
                    </td>
                <td class="style8">
                    </td>
                <td class="style9">
                    </td>
                <td class="style10">
                    </td>
                <td class="style11">
                    </td>
                <td class="style12">
                    </td>
                <td class="style13">
                    </td>
            </tr>
            
            <tr>
                <td align="center" class="style2">
                    &nbsp;</td>
                <td align="center" class="style1">
                    <asp:Button ID="BtnGuardar" runat="server"
                        Text="Guardar" onclick="BtnGuardar_Click" />
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="BtnSalir" runat="server" Text="Salir" onclick="BtnSalir_Click" 
                        />
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

                       

    
    </div>
        
    
</asp:Content>