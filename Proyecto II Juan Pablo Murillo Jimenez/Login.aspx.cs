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
            string usuario = correo.Text;
            string password = clave.Text;

            
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            string query = "SELECT COUNT(*) FROM usuarios WHERE correo=@correo AND clave=@clave";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@correo", usuario);
                cmd.Parameters.AddWithValue("@clave", password);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    Session["usuario"] = usuario;
                    Response.Redirect("Menu Principal.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Correo o clave incorrecta');</script>");
                }
            }
        }

    }
}