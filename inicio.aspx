<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Proyecto1.inicio" %>

<!DOCTYPE html>

<!-- Programacion del lado del cliente (Frontend) -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    Libros:
                    <asp:DropDownList ID="ddwLibros" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddwLibros_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Libro:
                    <asp:TextBox ID="txtLibro" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGuardar" runat="server" Text ="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                </td>
            </tr>
            <tr>
                <asp:GridView ID="gvDato" runat="server"></asp:GridView>
            </tr>
        </table>
    </form>
</body>
</html>
