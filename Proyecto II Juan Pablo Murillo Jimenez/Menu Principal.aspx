<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu Principal.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.Menu_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Principal - Servicio UH</title>
    <link rel="stylesheet" href="css/estilos.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Menu Principal - Servicio UH</h1>
        </div>

        <div>
            <ul>
                <li><a class="active" href="#home">Inicio</a></li>
                <li><a href="Tablas-Paginas/Usuarios.aspx">Usuarios</a></li>
                <li><a href="Tablas-Paginas/Equipos.aspx">Equipos</a></li>
                <li><a href="Tablas-Paginas/Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="Tablas-Paginas/DetallesReparacion.aspx">Detalles de reparacion</a></li>
                <li><a href="Tablas-Paginas/Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="Tablas-Paginas/Asignaciones.aspx">Asignaciones</a></li>
            </ul>
        </div>

    </form>
</body>
</html>
