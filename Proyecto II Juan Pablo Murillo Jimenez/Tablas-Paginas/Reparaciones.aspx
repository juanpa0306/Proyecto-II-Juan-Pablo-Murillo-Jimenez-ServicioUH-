<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reparaciones.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.Reparaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Reparaciones - Servicio UH</title>
    <link rel="stylesheet" href="../css/estilos.css"> 
</head>
<body>
    <form id="form1" runat="server">

        <div>

    <asp:GridView ID="ReparacionesGrid" runat="server"></asp:GridView>

    <label>ID de la reparacion</label>
    <asp:DropDownList ID="ddlReparacionID" runat="server"></asp:DropDownList>

   <label>ID del equipo</label>
   <asp:DropDownList ID="rDdlEquipoID" runat="server"></asp:DropDownList>

    <label>Fecha de la solicitud</label>
    <asp:TextBox ID="fechaSolicitud" runat="server"></asp:TextBox>

    <label>Estado</label>
    <asp:TextBox ID="estado" runat="server"></asp:TextBox>

  

        </div>

         <div>
             <asp:Button ID="botAgregar" runat="server" Text="Agregar" OnClick="BotAgregar"/>
             <asp:Button ID="botBorrar" runat="server" Text="Borrar" OnClick="BotBorrar"/>
             <asp:Button ID="botEditar" runat="server" Text="Editar" OnClick="BotActualizar"/>
        </div>

    </form>
</body>
</html>
