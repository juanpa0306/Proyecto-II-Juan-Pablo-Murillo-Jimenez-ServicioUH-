<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Usuarios - Servicio UH</title>
    <link rel="stylesheet" href="../css/estilos.css"> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Usuarios - Servicio UH</h1>
        </div>

        <div>
            <asp:GridView ID="UsuariosGrid" runat="server"></asp:GridView>

            <label>ID del usuario</label>
            <asp:DropDownList ID="ddlUsuarioID" runat="server"></asp:DropDownList>

            <label>Nombre</label>
            <asp:TextBox ID="nombreUsuario" runat="server"></asp:TextBox>

            <label>Correo</label>
            <asp:TextBox ID="correo" runat="server"></asp:TextBox>

            <label>Telefono</label>
             <asp:TextBox ID="telefono" runat="server"></asp:TextBox>

            <label>Clave</label>
            <asp:TextBox ID="clave" runat="server"></asp:TextBox>

            <label>Tipo de usuario</label>
            <asp:DropDownList ID="ddlTipoUsuario" runat="server"></asp:DropDownList>

        </div>

        <div>
            <asp:Button ID="botAgregar" runat="server" Text="Agregar" OnClick="BotAgregar"/>
            <asp:Button ID="botBorrar" runat="server" Text="Borrar" OnClick="BotBorrar" />
            <asp:Button ID="botEditar" runat="server" Text="Editar" OnClick="BotActualizar"/>
        </div>


    </form>
</body>
</html>
