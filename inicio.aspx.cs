using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class inicio : System.Web.UI.Page
    {

        //Programacion del lado del servidor Backend


        #region "Funciones y procedimientos"
        private void ConsultarLibros()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ\\DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";
            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "CONSULTA_LIBROS";

            

            DataTable dt = new DataTable();

            SqlDataAdapter oDatos = new SqlDataAdapter();
            oDatos.SelectCommand = oCmd;

            

            try
            {
                oDatos.Fill(dt);
                this.gvDato.DataSource = dt;
                this.DataBind();

                this.ddwLibros.DataSource = dt;
                this.ddwLibros.DataTextField = "LIBRO";
                this.ddwLibros.DataValueField = "ID_LIBRO";
                this.DataBind();
                this.ddwLibros.Items.Insert(0, "---Selecciona un libro---");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDatos.Dispose();
            }
        }

        private void AgregarLibro(string NombreLibro)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ\\DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";
            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "AGREGA_LIBRO";

            //Paso de parametros al procedimiento almacenados
            oCmd.Parameters.Add("LIBRO", SqlDbType.VarChar, 40);
            oCmd.Parameters["LIBRO"].Value = NombreLibro;

            DataTable dt = new DataTable();

            SqlDataAdapter oDatos = new SqlDataAdapter();
            oDatos.SelectCommand = oCmd;

            try
            {
                oDatos.Fill(dt);
                Response.Write(dt.Rows[0]["SALIDA"].ToString());
                //this.gvDato.DataSource = dt;
                //this.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDatos.Dispose();
            }
        }

        private void ActualizarLibro(int IdLibro, string NombreLibro)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ\\DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";
            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ACTUALIZA_LIBRO";

            //Paso de parametros al procedimiento almacenados
            oCmd.Parameters.Add("ID_LIBRO", SqlDbType.Int);
            oCmd.Parameters["ID_LIBRO"].Value = IdLibro;

            oCmd.Parameters.Add("LIBRO", SqlDbType.VarChar, 40);
            oCmd.Parameters["LIBRO"].Value = NombreLibro;

            DataTable dt = new DataTable();

            SqlDataAdapter oDatos = new SqlDataAdapter();
            oDatos.SelectCommand = oCmd;

            try
            {
                oDatos.Fill(dt);
                Response.Write(dt.Rows[0]["SALIDA"].ToString());
                //this.gvDato.DataSource = dt;
                //this.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDatos.Dispose();
            }
        }

        private void EliminarLibro(int IdLibro)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ\\DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";
            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ELIMINA_LIBRO_LOG";

            //Paso de parametros al procedimiento almacenados
            oCmd.Parameters.Add("ID_LIBRO", SqlDbType.Int);
            oCmd.Parameters["ID_LIBRO"].Value = IdLibro;

            DataTable dt = new DataTable();

            SqlDataAdapter oDatos = new SqlDataAdapter();
            oDatos.SelectCommand = oCmd;

            try
            {
                oDatos.Fill(dt);
                Response.Write(dt.Rows[0]["SALIDA"].ToString());
                //this.gvDato.DataSource = dt;
                //this.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDatos.Dispose();
            }
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConsultarLibros();
            }            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex == 0)
            {
                AgregarLibro(txtLibro.Text);
            }
            else
            {
                ActualizarLibro(int.Parse(ddwLibros.SelectedItem.Value), txtLibro.Text);
            }
            ConsultarLibros();

        }

        protected void ddwLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Preguntar si esta en el registro
            if (ddwLibros.SelectedIndex == 0)
            {
                txtLibro.Text = "";
            }
            else
            {
                txtLibro.Text = ddwLibros.SelectedItem.Text.ToString();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex != 0)
            {
                EliminarLibro(int.Parse(ddwLibros.SelectedItem.Value));
            }
            else
            {
                Response.Write("Selecciona un libro para eliminar");
            }
            ConsultarLibros();
        }
    }
}