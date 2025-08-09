using Proyecto_II_Juan_Pablo_Murillo_Jimenez.Tablas_Paginas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_Juan_Pablo_Murillo_Jimenez
{
    public partial class Reparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDdlReparaciones();
                LlenarDdlEquipo();
            }

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM reparaciones", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    ReparacionesGrid.DataSource = rdr;
                    ReparacionesGrid.DataBind();
                }
            }
        }

        protected void LlenarDdlReparaciones()
        {
            ddlReparacionID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT ReparacionID FROM reparaciones", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ddlReparacionID.Items.Add(rdr["ReparacionID"].ToString());
                    }
                }
            }

        }

        protected void LlenarDdlEquipo()
        {
            rDdlEquipoID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT EquipoID FROM equipos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        rDdlEquipoID.Items.Add(rdr["EquipoID"].ToString());
                    }
                }
            }

        }

        //--------------Agregar----------------------

        protected void BotAgregar(object sender, EventArgs e)
        {
            SQLAgregar_Reparacion();
        }

        protected void SQLAgregar_Reparacion()
        {
            ClsReparaciones.fechaSolicitud = fechaSolicitud.Text;
            ClsReparaciones.estado = estado.Text;
            ClsEquipo.equipoID = int.Parse(rDdlEquipoID.SelectedValue);


            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_AgregarReparacion", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@EquipoID", ClsEquipo.equipoID);
                comando.Parameters.AddWithValue("@FechaSolicitud", ClsReparaciones.fechaSolicitud.Trim());
                comando.Parameters.AddWithValue("@Estado", ClsReparaciones.estado);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlReparaciones();
                    LlenarDdlEquipo();
                    ddlReparacionID.SelectedIndex = 0;
                    fechaSolicitud.Text = string.Empty;
                    estado.Text = string.Empty;
                    rDdlEquipoID.SelectedIndex = 0;

                }
                catch (Exception ex)
                {

                }
            }
        }

        //---------------Eliminar----------------------

        protected void BotBorrar(object sender, EventArgs e)
        {
            SQLBorrar_Reparacion();
        }

        protected void SQLBorrar_Reparacion()
        {
            ClsReparaciones.reparacionID = int.Parse(ddlReparacionID.SelectedValue);
            ClsReparaciones.fechaSolicitud = fechaSolicitud.Text;
            ClsReparaciones.estado = estado.Text;
            ClsEquipo.equipoID = int.Parse(rDdlEquipoID.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_EliminarReparacion", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue(@"ReparacionID", ClsReparaciones.reparacionID);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlReparaciones();
                    LlenarDdlEquipo();
                    ddlReparacionID.SelectedIndex = 0;
                    fechaSolicitud.Text = string.Empty;
                    estado.Text = string.Empty;
                    rDdlEquipoID.SelectedIndex = 0;
                }
                catch (Exception ex)
                {

                }
            }
        }

        //---------------Actualizar----------------------
        protected void BotActualizar(object sender, EventArgs e)
        {
            SQLActualizar_Reparacion();
        }

        protected void SQLActualizar_Reparacion()
        {
            ClsReparaciones.reparacionID = int.Parse(ddlReparacionID.SelectedValue);
            ClsReparaciones.fechaSolicitud = fechaSolicitud.Text;
            ClsReparaciones.estado = estado.Text;
            ClsEquipo.equipoID = int.Parse(rDdlEquipoID.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_ActualizarReparacion", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue(@"ReparacionID", ClsReparaciones.reparacionID);
                comando.Parameters.AddWithValue("@EquipoID", ClsEquipo.equipoID);
                comando.Parameters.AddWithValue("@FechaSolicitud", ClsReparaciones.fechaSolicitud.Trim());
                comando.Parameters.AddWithValue("@Estado", ClsReparaciones.estado);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlReparaciones();
                    LlenarDdlEquipo();
                    ddlReparacionID.SelectedIndex = 0;
                    fechaSolicitud.Text = string.Empty;
                    estado.Text = string.Empty;
                    rDdlEquipoID.SelectedIndex = 0;
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}