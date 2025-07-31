<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.Tecnicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tecnicos - Servicio UH</title>
     <link rel="stylesheet" href="../css/estilos.css"> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Tecnicos - Servicio UH</h1>
        </div>

   <div>

    <asp:GridView ID="TecnicosGrid" runat="server"></asp:GridView>

    <label>ID del Tecnico</label>
    <asp:DropDownList ID="ddlTecnicoID" runat="server"></asp:DropDownList>

    <label>Nombre del tecnico</label>
    <asp:TextBox ID="nombreTecnico" runat="server"></asp:TextBox>

    <label>Especialidad</label>
    <asp:TextBox ID="especialidad" runat="server"></asp:TextBox>



   </div>

   <div>
      <asp:Button ID="botAgregar" runat="server" Text="Agregar" OnClick="BotAgregar"/>
      <asp:Button ID="botBorrar" runat="server" Text="Borrar" OnClick="BotBorrar" />
      <asp:Button ID="botEditar" runat="server" Text="Editar" OnClick="BotActualizar" />

    </form>
</body>
</html>
