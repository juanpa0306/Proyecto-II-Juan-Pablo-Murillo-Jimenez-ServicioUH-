<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.Equipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Equipos - Servicio UH</title>
    <link rel="stylesheet" href="../css/estilos.css"> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Equipos - Servicio UH</h2>
        </div>

     <div>

        <asp:GridView ID="EquiposGrid" runat="server"></asp:GridView>

        <label>ID del equipo</label>
        <asp:DropDownList ID="ddlEquipoID" runat="server"></asp:DropDownList>

        <label>Tipo de equipo</label>
        <asp:TextBox ID="tipoEquipo" runat="server"></asp:TextBox>

        <label>Modelo</label>
        <asp:TextBox ID="modelo" runat="server"></asp:TextBox>

        <label>ID del usuario</label>
         <asp:DropDownList ID="eDdlUsuarioID" runat="server"></asp:DropDownList>

       </div>

       <div>
          <asp:Button ID="botAgregar" runat="server" Text="Agregar" OnClick="BotAgregar"/>
          <asp:Button ID="botBorrar" runat="server" Text="Borrar" OnClick="BotBorrar"/>
          <asp:Button ID="botEditar" runat="server" Text="Editar" OnClick="BotActualizar"/>
       </div>

    </form>
</body>
</html>
