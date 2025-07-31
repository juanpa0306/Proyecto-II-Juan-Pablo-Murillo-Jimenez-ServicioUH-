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
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDdlTecnicos();
            }

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    TecnicosGrid.DataSource = rdr;
                    TecnicosGrid.DataBind();
                }
            }
        }

        protected void LlenarDdlTecnicos()
        {
            ddlTecnicoID.Items.Clear();

            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT TecnicoID FROM Tecnicos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ddlTecnicoID.Items.Add(rdr["TecnicoID"].ToString());
                    }
                }
            }

        }

        //----------------------------Agregar-----------------

        protected void BotAgregar(object sender, EventArgs e)
        {
            SQLAgregar_Tecnico();
        }

        protected void SQLAgregar_Tecnico()
        {
            ClsTecnicos.nombreTecnico = nombreTecnico.Text;
            ClsTecnicos.especialidad = especialidad.Text;
           


            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "INSERT INTO Tecnicos (Nombre, Especialidad)" +
                "VALUES (@Nombre, @Especialidad)", conexion))
            {
                comando.Parameters.AddWithValue("@Nombre", ClsTecnicos.nombreTecnico.Trim());
                comando.Parameters.AddWithValue("@Especialidad", ClsTecnicos.especialidad.Trim());
                

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlTecnicos();

                    ddlTecnicoID.SelectedIndex = 0;
                    nombreTecnico.Text = string.Empty;
                    especialidad.Text = string.Empty;


                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void BotBorrar(object sender, EventArgs e)
        {
            SQLBorrar_Tecnico();
        }

        protected void SQLBorrar_Tecnico()
        {
            ClsTecnicos.tecnicoID = int.Parse(ddlTecnicoID.SelectedValue);
            ClsTecnicos.nombreTecnico = nombreTecnico.Text;
            ClsTecnicos.especialidad = especialidad.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "DELETE FROM Tecnicos WHERE TecnicoID = @TecnicoID", conexion))
            {
                comando.Parameters.AddWithValue(@"TecnicoID", ClsTecnicos.tecnicoID);


                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlTecnicos();

                    ddlTecnicoID.SelectedIndex = 0;
                    nombreTecnico.Text = string.Empty;
                    especialidad.Text = string.Empty;


                }
                catch (Exception ex)
                {

                }
            }
        }

        //-----------------------Actualizar------------------

        protected void BotActualizar(object sender, EventArgs e)
        {
            SQLActualizar_Tecnico();
        }

        protected void SQLActualizar_Tecnico()
        {
            ClsTecnicos.tecnicoID = int.Parse(ddlTecnicoID.SelectedValue);
            ClsTecnicos.nombreTecnico = nombreTecnico.Text;
            ClsTecnicos.especialidad = especialidad.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "UPDATE Tecnicos SET Nombre = @Nombre, Especialidad = @Especialidad WHERE TecnicoID = @TecnicoID", conexion))
            {
                comando.Parameters.AddWithValue(@"TecnicoID", ClsTecnicos.tecnicoID);
                comando.Parameters.AddWithValue("@Nombre", ClsTecnicos.nombreTecnico.Trim());
                comando.Parameters.AddWithValue("@Especialidad", ClsTecnicos.especialidad.Trim());

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    LlenarGrid();
                    LlenarDdlTecnicos();

                    ddlTecnicoID.SelectedIndex = 0;
                    nombreTecnico.Text = string.Empty;
                    especialidad.Text = string.Empty;
                }
                catch (Exception ex)
                {

                }
            }
        }





    }
}