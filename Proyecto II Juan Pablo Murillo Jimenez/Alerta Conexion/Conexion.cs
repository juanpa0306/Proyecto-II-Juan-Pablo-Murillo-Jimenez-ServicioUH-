using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Proyecto_II_Juan_Pablo_Murillo_Jimenez.Alerta_Conexion
{
    public class conexion
    {
        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }
    }
}