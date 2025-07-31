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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDdlUsuario();
            }
        }


        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    UsuariosGrid.DataSource = rdr;
                    UsuariosGrid.DataBind();
                }
            }
        }

        protected void LlenarDdlUsuario()
        {
            ddlUsuarioID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT UsuarioID FROM usuarios", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ddlUsuarioID.Items.Add(rdr["UsuarioID"].ToString());
                    }
                }
            }
        }

        //--------------Agregar----------------------
        protected void BotAgregar(object sender, EventArgs e)
        {
            SQLAgregar_Usuario();
        }

        protected void SQLAgregar_Usuario()
        {
            ClsUsuario.nombreuUsuario = nombreUsuario.Text;
            ClsUsuario.correo = correo.Text;
            ClsUsuario.telefono = telefono.Text;
            ClsUsuario.clave = clave.Text;
            ClsUsuario.tipoUsuario = tipoUsuario.Text;


            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "INSERT INTO usuarios (Nombre, correo, Telefono, clave, tipousuario) " +
                "VALUES (@nombre, @correo, @Telefono, @clave, @tipoUsuario)", conexion))
            {
                comando.Parameters.AddWithValue("@nombre", ClsUsuario.nombreuUsuario.Trim());
                comando.Parameters.AddWithValue("@correo", ClsUsuario.correo.Trim());
                comando.Parameters.AddWithValue("@Telefono", ClsUsuario.telefono.Trim());
                comando.Parameters.AddWithValue("@clave", ClsUsuario.clave.Trim());
                comando.Parameters.AddWithValue("@tipoUsuario", ClsUsuario.tipoUsuario.Trim());


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlUsuario();
                    nombreUsuario.Text = string.Empty;
                    correo.Text = string.Empty;
                    telefono.Text = string.Empty;
                    clave.Text = string.Empty;
                    tipoUsuario.Text = string.Empty;

                }
                catch (Exception ex)
                {

                }
            }
        }
        //--------------Borrar--------------------
        protected void BotBorrar(object sender, EventArgs e)
        {
            SQLBorrar_Usuario();
        }
        protected void SQLBorrar_Usuario()
        {
            ClsUsuario.usuarioID = int.Parse(ddlUsuarioID.SelectedValue);
            ClsUsuario.nombreuUsuario = nombreUsuario.Text;
            ClsUsuario.correo = correo.Text;
            ClsUsuario.telefono = telefono.Text;
            ClsUsuario.clave = clave.Text;
            ClsUsuario.tipoUsuario = tipoUsuario.Text;




            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "DELETE FROM usuarios WHERE usuarioID = @usuarioID", conexion))
            {
                comando.Parameters.AddWithValue(@"usuarioID", ClsUsuario.usuarioID);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlUsuario();
                    ddlUsuarioID.SelectedIndex = 0;
                    nombreUsuario.Text = string.Empty;
                    correo.Text = string.Empty;
                    telefono.Text = string.Empty;
                    clave.Text = string.Empty;
                    tipoUsuario.Text = string.Empty;
                }
                catch (Exception ex)
                {

                }
            }
        }
        //--------------Actualizar-----------------------

        protected void BotActualizar(object sender, EventArgs e)
        {
            SQLActualizar_Usuario();
        }
        protected void SQLActualizar_Usuario()
        {
            ClsUsuario.usuarioID = int.Parse(ddlUsuarioID.SelectedValue);
            ClsUsuario.nombreuUsuario = nombreUsuario.Text;
            ClsUsuario.correo = correo.Text;
            ClsUsuario.telefono = telefono.Text;
            ClsUsuario.clave = clave.Text;
            ClsUsuario.tipoUsuario = tipoUsuario.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "UPDATE usuarios SET Nombre = @nombre, correo = @correo, Telefono = @Telefono, clave = @clave, tipousuario = @tipoUsuario  WHERE UsuarioID = @usuarioID", conexion))
            {
                comando.Parameters.AddWithValue(@"usuarioID", ClsUsuario.usuarioID);
                comando.Parameters.AddWithValue("@nombre", ClsUsuario.nombreuUsuario.Trim());
                comando.Parameters.AddWithValue("@correo", ClsUsuario.correo.Trim());
                comando.Parameters.AddWithValue("@Telefono", ClsUsuario.telefono.Trim());
                comando.Parameters.AddWithValue("@clave", ClsUsuario.clave.Trim());
                comando.Parameters.AddWithValue("@tipoUsuario", ClsUsuario.tipoUsuario.Trim());

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    

                    ddlUsuarioID.SelectedIndex = 0;
                    nombreUsuario.Text = string.Empty;
                    correo.Text = string.Empty;
                    telefono.Text = string.Empty;
                    clave.Text = string.Empty;
                    tipoUsuario.Text = string.Empty;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}

    
    

        