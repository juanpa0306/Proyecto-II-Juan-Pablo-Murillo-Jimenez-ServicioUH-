using Proyecto_II_Juan_Pablo_Murillo_Jimenez.Tablas_Paginas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_Juan_Pablo_Murillo_Jimenez
{
    public partial class DetallesReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDdlDetalles();
                LlenarDdlReparaciones();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM DetallesReparacion", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DetallesGrid.DataSource = rdr;
                    DetallesGrid.DataBind();
                }
            }
        }

        protected void LlenarDdlDetalles()
        {
            ddlDetalle.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT DetalleID FROM DetallesReparacion", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ddlDetalle.Items.Add(rdr["DetalleID"].ToString());
                    }
                }
            }

        }

        protected void LlenarDdlReparaciones()
        {
            dDdlReparacionID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT ReparacionID FROM reparaciones", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dDdlReparacionID.Items.Add(rdr["ReparacionID"].ToString());
                    }
                }
            }

        }
        //------------Agregar-----------------

        protected void BotAgregar(object sender, EventArgs e)
        {
            SQLAgregar_Detalle();
        }

        protected void SQLAgregar_Detalle()
        {
            //ClsDetalles.DetalleID = int.Parse(ddlDetalle.SelectedValue);
            ClsReparaciones.reparacionID = int.Parse(dDdlReparacionID.SelectedValue);
            ClsDetalles.Descripcion = descripcion.Text;
            ClsDetalles.FechaIn = fechaIn.Text;
            ClsDetalles.FechaFin = fechaFin.Text;




            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_AgregarDetalle", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@ReparacionID", ClsReparaciones.reparacionID);
                comando.Parameters.AddWithValue("@Descripcion", ClsDetalles.Descripcion.Trim());
                comando.Parameters.AddWithValue("@FechaInicio", ClsDetalles.FechaIn.Trim());
                comando.Parameters.AddWithValue("@FechaFin", ClsDetalles.FechaFin.Trim());


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlDetalles();
                    LlenarDdlReparaciones();
                    
                    ddlDetalle.SelectedIndex = 0;
                    dDdlReparacionID.SelectedIndex = 0;
                    descripcion.Text = string.Empty;
                    fechaIn.Text = string.Empty;
                    fechaFin.Text = string.Empty;
                    

                }
                catch (Exception ex)
                {

                }
            }
        }
        //------------Eliminar-----------------

        protected void BotBorrar(object sender, EventArgs e)
        {
            SQLBorrar_Detalle();
        }

        protected void SQLBorrar_Detalle()
        {
            ClsDetalles.DetalleID = int.Parse(ddlDetalle.SelectedValue);
            ClsReparaciones.reparacionID = int.Parse(dDdlReparacionID.SelectedValue);
            ClsDetalles.Descripcion = descripcion.Text;
            ClsDetalles.FechaIn = fechaIn.Text;
            ClsDetalles.FechaFin = fechaFin.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_EliminarDetalle", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue(@"DetalleID", ClsDetalles.DetalleID);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlDetalles();
                    LlenarDdlReparaciones();

                    ddlDetalle.SelectedIndex = 0;
                    dDdlReparacionID.SelectedIndex = 0;
                    descripcion.Text = string.Empty;
                    fechaIn.Text = string.Empty;
                    fechaFin.Text = string.Empty;

                }
                catch (Exception ex)
                {

                }
            }
        }

        //------------Actualizar-----------------
        protected void BotActualizar(object sender, EventArgs e)
        {
            SQLActualizar_Detalle();
        }

        protected void SQLActualizar_Detalle()
        {
           
            ClsDetalles.DetalleID = int.Parse(ddlDetalle.SelectedValue);
            ClsReparaciones.reparacionID = int.Parse(dDdlReparacionID.SelectedValue);
            ClsDetalles.Descripcion = descripcion.Text;
            ClsDetalles.FechaIn = fechaIn.Text;
            ClsDetalles.FechaFin = fechaFin.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("dbo.PA_ActualizarDetalle", conexion))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;


                comando.Parameters.AddWithValue(@"DetalleID", ClsDetalles.DetalleID);
                comando.Parameters.AddWithValue("@ReparacionID", ClsReparaciones.reparacionID);
                comando.Parameters.AddWithValue("@Descripcion", ClsDetalles.Descripcion.Trim());
                comando.Parameters.AddWithValue("@FechaInicio", ClsDetalles.FechaIn.Trim());
                comando.Parameters.AddWithValue("@FechaFin", ClsDetalles.FechaFin.Trim());
                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlDetalles();
                    LlenarDdlReparaciones();

                    ddlDetalle.SelectedIndex = 0;
                    dDdlReparacionID.SelectedIndex = 0;
                    descripcion.Text = string.Empty;
                    fechaIn.Text = string.Empty;
                    fechaFin.Text = string.Empty;
                }
                catch (Exception ex)
                {

                }
            }
        }


    }
}