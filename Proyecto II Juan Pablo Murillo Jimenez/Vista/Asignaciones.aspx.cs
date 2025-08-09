using Proyecto_II_Juan_Pablo_Murillo_Jimenez.Tablas_Paginas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_Juan_Pablo_Murillo_Jimenez
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDdlAsignaciones();
                LlenarDdlReparaciones();
                LlenarDdlTecnicos();
            }

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Asignaciones", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    AsignacionesGrid.DataSource = rdr;
                    AsignacionesGrid.DataBind();
                }
            }
        }

        protected void LlenarDdlAsignaciones()
        {
            ddlAsignacionID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT AsignacionID FROM Asignaciones", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ddlAsignacionID.Items.Add(rdr["AsignacionID"].ToString());
                    }
                }
            }

        }

        protected void LlenarDdlReparaciones()
        {
            aDdlReparacionID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT ReparacionID FROM reparaciones", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        aDdlReparacionID.Items.Add(rdr["ReparacionID"].ToString());
                    }
                }
            }

        }

        protected void LlenarDdlTecnicos()
        {
            aDdlTecnicoID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT TecnicoID FROM Tecnicos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        aDdlTecnicoID.Items.Add(rdr["TecnicoID"].ToString());
                    }
                }
            }

        }
        //------------------Agregar---------------------------

        protected void BotAgregar(object sender, EventArgs e)
        {
            SQLAgregar_Asignaciones();
        }

        protected void SQLAgregar_Asignaciones()
        {
            //ClsAsignaciones.asignacionID = int.Parse(ddlAsignacionID.SelectedValue);
            ClsReparaciones.reparacionID = int.Parse(aDdlReparacionID.SelectedValue);
            ClsTecnicos.tecnicoID = int.Parse(aDdlTecnicoID.SelectedValue);
            ClsAsignaciones.fechaAsignacion = asignacionFecha.Text;


            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_AgregarAsignacion", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;


                comando.Parameters.AddWithValue("@ReparacionID", ClsReparaciones.reparacionID);
                comando.Parameters.AddWithValue("@TecnicoID", ClsTecnicos.tecnicoID);
                comando.Parameters.AddWithValue("@FechaAsignacion", ClsAsignaciones.fechaAsignacion.Trim());


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    LlenarGrid();
                    LlenarDdlReparaciones();
                    LlenarDdlTecnicos();
                    ddlAsignacionID.SelectedIndex = 0;
                    aDdlReparacionID.SelectedIndex = 0;
                    aDdlTecnicoID.SelectedIndex = 0;
                    asignacionFecha.Text = string.Empty;
       
                }
                catch (Exception ex)
                {

                }
            }
        }

        //--------------------Eliminar---------------------------
        protected void BotBorrar(object sender, EventArgs e)
        {
            SQLBorrar_Asignacion();
        }

        protected void SQLBorrar_Asignacion()
        {
            ClsAsignaciones.asignacionID = int.Parse(ddlAsignacionID.SelectedValue);
            ClsReparaciones.reparacionID = int.Parse(aDdlReparacionID.SelectedValue);
            ClsTecnicos.tecnicoID = int.Parse(aDdlTecnicoID.SelectedValue);
            ClsAsignaciones.fechaAsignacion = asignacionFecha.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_EliminarAsignacion", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;


                comando.Parameters.AddWithValue(@"AsignacionID", ClsAsignaciones.asignacionID);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    LlenarGrid();
                    LlenarDdlReparaciones();
                    LlenarDdlTecnicos();
                    ddlAsignacionID.SelectedIndex = 0;
                    aDdlReparacionID.SelectedIndex = 0;
                    aDdlTecnicoID.SelectedIndex = 0;
                    asignacionFecha.Text = string.Empty;

                }
                catch (Exception ex)
                {

                }
            }
        }

        //----------------------Actualizar---------------------------

        protected void BotActualizar(object sender, EventArgs e)
        {
            SQLActualizar_Asignacion();
        }

        protected void SQLActualizar_Asignacion()
        {
            ClsAsignaciones.asignacionID = int.Parse(ddlAsignacionID.SelectedValue);
            ClsReparaciones.reparacionID = int.Parse(aDdlReparacionID.SelectedValue);
            ClsTecnicos.tecnicoID = int.Parse(aDdlTecnicoID.SelectedValue);
            ClsAsignaciones.fechaAsignacion = asignacionFecha.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_ActualizarAsignacion", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;


                comando.Parameters.AddWithValue(@"AsignacionID", ClsAsignaciones.asignacionID);
                comando.Parameters.AddWithValue("@ReparacionID", ClsReparaciones.reparacionID);
                comando.Parameters.AddWithValue("@TecnicoID", ClsTecnicos.tecnicoID);
                comando.Parameters.AddWithValue("@FechaAsignacion", ClsAsignaciones.fechaAsignacion.Trim());

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();


                    conexion.Open();
                    comando.ExecuteNonQuery();

                    LlenarGrid();
                    LlenarDdlReparaciones();
                    LlenarDdlTecnicos();
                    ddlAsignacionID.SelectedIndex = 0;
                    aDdlReparacionID.SelectedIndex = 0;
                    aDdlTecnicoID.SelectedIndex = 0;
                    asignacionFecha.Text = string.Empty;

                }
                catch (Exception ex)
                {

                }
            }
        }


    }
}