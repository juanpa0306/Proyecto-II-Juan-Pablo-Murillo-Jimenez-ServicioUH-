using Proyecto_II_Juan_Pablo_Murillo_Jimenez.Tablas_Paginas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_Juan_Pablo_Murillo_Jimenez
{
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDdlEquipo();
                LlenarDdlUsuario();
            }
         
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM equipos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    EquiposGrid.DataSource = rdr;
                    EquiposGrid.DataBind();
                }
            }
        }

        protected void LlenarDdlEquipo()
        {
            ddlEquipoID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT EquipoID FROM equipos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ddlEquipoID.Items.Add(rdr["EquipoID"].ToString());
                    }
                }
            }

        }

        protected void LlenarDdlUsuario()
        {
            eDdlUsuarioID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT UsuarioID FROM usuarios", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        eDdlUsuarioID.Items.Add(rdr["UsuarioID"].ToString());
                    }
                }
            }
        }

        //---------------Agregar----------------------

        protected void BotAgregar(object sender, EventArgs e)
        {
            SQLAgregar_Equipo();
        }

        protected void SQLAgregar_Equipo()
        {
            ClsEquipo.tipoEquipo = tipoEquipo.Text;
            ClsEquipo.modelo = modelo.Text;
            ClsUsuario.usuarioID = int.Parse(eDdlUsuarioID.SelectedValue);


            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "INSERT INTO equipos (TipoEquipo, modelo, UsuarioID)" +
                "VALUES (@TipoEquipo, @modelo, @UsuarioID)", conexion))
            {
                comando.Parameters.AddWithValue("@TipoEquipo", ClsEquipo.tipoEquipo.Trim());
                comando.Parameters.AddWithValue("@modelo", ClsEquipo.modelo.Trim());
                comando.Parameters.AddWithValue("@UsuarioID", ClsUsuario.usuarioID);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlEquipo();
                    ddlEquipoID.SelectedIndex=0;
                    tipoEquipo.Text = string.Empty;
                    modelo.Text = string.Empty;
                    eDdlUsuarioID.SelectedIndex=0;
                 
                }
                catch (Exception ex)
                {

                }
            }
        }


        //---------------Borrar----------------------
        protected void BotBorrar(object sender, EventArgs e)
        {
            SQLBorrar_Equipo();
        }

        protected void SQLBorrar_Equipo()
        {
            ClsEquipo.equipoID = int.Parse(ddlEquipoID.SelectedValue);
            ClsEquipo.tipoEquipo = tipoEquipo.Text;
            ClsEquipo.modelo = modelo.Text;
            ClsUsuario.usuarioID = int.Parse(eDdlUsuarioID.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "DELETE FROM equipos WHERE EquipoID = @EquipoID", conexion))
            {
                comando.Parameters.AddWithValue(@"EquipoID", ClsEquipo.equipoID);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlEquipo();
                    ddlEquipoID.SelectedIndex = 0;
                    tipoEquipo.Text = string.Empty;
                    modelo.Text = string.Empty;
                    eDdlUsuarioID.SelectedIndex = 0;
                }
                catch (Exception ex)
                {

                }
            }
        }

        //---------------Editar----------------------

        protected void BotActualizar(object sender, EventArgs e)
        {
            SQLActualizar_Equipo();
        }

        protected void SQLActualizar_Equipo()
        {
            ClsEquipo.equipoID = int.Parse(ddlEquipoID.SelectedValue);
            ClsEquipo.tipoEquipo = tipoEquipo.Text;
            ClsEquipo.modelo = modelo.Text;
            ClsUsuario.usuarioID = int.Parse(eDdlUsuarioID.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "UPDATE equipos SET TipoEquipo = @TipoEquipo, modelo = @modelo, UsuarioID = @UsuarioID WHERE EquipoID = @EquipoID", conexion))
            {
                comando.Parameters.AddWithValue(@"EquipoID", ClsEquipo.equipoID);
                comando.Parameters.AddWithValue("@TipoEquipo", ClsEquipo.tipoEquipo.Trim());
                comando.Parameters.AddWithValue("@modelo", ClsEquipo.modelo.Trim());
                comando.Parameters.AddWithValue("@UsuarioID", ClsUsuario.usuarioID);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();


                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlEquipo();
                    ddlEquipoID.SelectedIndex = 0;
                    tipoEquipo.Text = string.Empty;
                    modelo.Text = string.Empty;
                    eDdlUsuarioID.SelectedIndex = 0;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}