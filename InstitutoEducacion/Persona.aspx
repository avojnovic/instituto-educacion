<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="InstitutoEducacion.Persona" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="margin-right: 0px">

                       

    
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="DNI:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDni" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtContrasena" runat="server"  ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Perfil:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="CmbPerfil" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td align="center">
                    <asp:Button ID="BtnGuardar" runat="server" onclick="Button1_Click" 
                        Text="Guardar" />
                </td>
                <td align="center">
                    <asp:Button ID="BtnSalir" runat="server" Text="Salir" 
                        onclick="BtnSalir_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

                       

    
    </div>
        
    
</asp:Content>