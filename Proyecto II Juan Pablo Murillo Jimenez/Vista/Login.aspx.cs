using Proyecto_II_Juan_Pablo_Murillo_Jimenez.Alerta_Conexion;
using Proyecto_II_Juan_Pablo_Murillo_Jimenez.Datos__Clases_;
using Proyecto_II_Juan_Pablo_Murillo_Jimenez.Tablas_Paginas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_Juan_Pablo_Murillo_Jimenez
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Cls_Login.correoLog = correo.Text;
            Cls_Login.claveLog = clave.Text;


            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.validar_usuario", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@correo", Cls_Login.correoLog);
                comando.Parameters.AddWithValue("@clave", Cls_Login.claveLog);

             

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        Cls_Login.nombreLog = reader["Nombre"].ToString();
                        Cls_Login.tipoUsuarioLog = Convert.ToInt32(reader["tipousuario"]);

                        Session["nombre"] = Cls_Login.nombreLog;
                        Session["correo"] = Cls_Login.correoLog;
                        Session["tipoUsuario"] = Cls_Login.tipoUsuarioLog;

                        if (Cls_Login.tipoUsuarioLog == 1) 
                        {
                            Response.Redirect("Menu Principal.aspx");
                        }
                        else 
                        {
                            Response.Redirect("Menu Principal2.aspx");
                        }
                    }
                    else 
                    {
                       Alerta_Conexion.conexion.MostrarAlerta(this, "Usuario o clave incorrecta");
                    }
                


                       correo.Text = string.Empty;
                       clave.Text = string.Empty;

                }
                catch (Exception ex)
                {

                }
            }
        }
    }

    
}