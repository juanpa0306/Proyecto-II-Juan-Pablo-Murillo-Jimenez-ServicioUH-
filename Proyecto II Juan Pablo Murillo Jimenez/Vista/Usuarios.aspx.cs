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
                LlenarDdlTipoUsuario();
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

        protected void LlenarDdlTipoUsuario()
        {
            ddlTipoUsuario.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT ID FROM roles", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ddlTipoUsuario.Items.Add(rdr["ID"].ToString());
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
            ClsUsuario.tipoUsuario = ddlTipoUsuario.SelectedValue;


            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_AgregarUsuario", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", ClsUsuario.nombreuUsuario.Trim());
                comando.Parameters.AddWithValue("@Correo", ClsUsuario.correo.Trim());
                comando.Parameters.AddWithValue("@Telefono", ClsUsuario.telefono.Trim());
                comando.Parameters.AddWithValue("@Clave", ClsUsuario.clave.Trim());
                comando.Parameters.AddWithValue("@TipoUsuario", ClsUsuario.tipoUsuario);


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
                    ddlTipoUsuario.SelectedIndex = 0;

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
            ClsUsuario.tipoUsuario = ddlTipoUsuario.SelectedValue;




            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_EliminarUsuario", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue(@"UsuarioID", ClsUsuario.usuarioID);


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
                    ClsUsuario.tipoUsuario = ddlTipoUsuario.SelectedValue;
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
            ClsUsuario.tipoUsuario = ddlTipoUsuario.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_ActualizarUsuario", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue(@"UsuarioID", ClsUsuario.usuarioID);
                comando.Parameters.AddWithValue("@Nombre", ClsUsuario.nombreuUsuario.Trim());
                comando.Parameters.AddWithValue("@Correo", ClsUsuario.correo.Trim());
                comando.Parameters.AddWithValue("@Telefono", ClsUsuario.telefono.Trim());
                comando.Parameters.AddWithValue("@Clave", ClsUsuario.clave.Trim());
                comando.Parameters.AddWithValue("@TipoUsuario", ClsUsuario.tipoUsuario);

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
                    ClsUsuario.tipoUsuario = ddlTipoUsuario.SelectedValue;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}

    
    

        