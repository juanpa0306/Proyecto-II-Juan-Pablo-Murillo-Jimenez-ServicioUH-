<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesReparacion.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.DetallesReparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalles de reparacion - Servicio UH</title>
     <link rel="stylesheet" href="../css/estilos.css"> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Detalles de reparacion - Servicio UH</h1>
        </div>

        <div>

<asp:GridView ID="DetallesGrid" runat="server"></asp:GridView>

<label>ID del detalle</label>
<asp:DropDownList ID="ddlDetalle" runat="server"></asp:DropDownList>

<label>ID de la reparacion</label>
 <asp:DropDownList ID="dDdlReparacionID" runat="server"></asp:DropDownList>

<label>Descripcion</label>
<asp:TextBox ID="descripcion" runat="server"></asp:TextBox>

<label>Fecha de inicio</label>
<asp:TextBox ID="fechaIn" runat="server"></asp:TextBox>

<label>Fecha de fin</label>
<asp:TextBox ID="fechaFin" runat="server"></asp:TextBox>
        </div>


 <div>
    <asp:Button ID="botAgregar" runat="server" Text="Agregar" OnClick="BotAgregar"/>
    <asp:Button ID="botBorrar" runat="server" Text="Borrar" OnClick="BotBorrar"/>
    <asp:Button ID="botEditar" runat="server" Text="Editar" OnClick="BotActualizar"/>
 </div>


    </form>
</body>
</html>
