<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_II_Juan_Pablo_Murillo_Jimenez.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Servicio UH</title>
    <link rel="stylesheet" href="../css/estilos.css"> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login - Servicio UH</h1>
        </div>


        <div>

            <label>Correo Electronico</label>
            <asp:TextBox ID="correo" runat="server"></asp:TextBox>

            <label>Clave</label>
             <asp:TextBox ID="clave" runat="server"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" OnClick="btnLogin_Click" />

            <!--Hola profe el login lo puede hacer con el correo y clave de la tabla usuarios trate de dejar un usuario ya listo en la carpeta de la base de datos-->
        </div>




    </form>
</body>
</html>
