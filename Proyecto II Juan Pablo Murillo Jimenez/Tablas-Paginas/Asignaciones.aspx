<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.Asignaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignaciones - Servicio UH</title>
    <link rel="stylesheet" href="../css/estilos.css"> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Asignaciones - Servicio UH</h1>
        </div>

        
         <div>

        <asp:GridView ID="AsignacionesGrid" runat="server"></asp:GridView>

        <label>ID de la asignacion</label>
        <asp:DropDownList ID="ddlAsignacionID" runat="server"></asp:DropDownList>

        <label>ID de la reparacion</label>
        <asp:DropDownList ID="aDdlReparacionID" runat="server"></asp:DropDownList>

         <label>ID del tecnico</label>
         <asp:DropDownList ID="aDdlTecnicoID" runat="server"></asp:DropDownList>

        <label>FechaAsignacion</label>
        <asp:TextBox ID="asignacionFecha" runat="server"></asp:TextBox>

        </div>


        
       <div>
          <asp:Button ID="botAgregar" runat="server" Text="Agregar" OnClick="BotAgregar"/>
          <asp:Button ID="botBorrar" runat="server" Text="Borrar" OnClick="BotBorrar"/>
          <asp:Button ID="botEditar" runat="server" Text="Editar" OnClick="BotActualizar"/>
       </div>


    </form>
</body>
</html>
