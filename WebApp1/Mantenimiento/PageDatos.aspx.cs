using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace WebApp1.Mantenimiento
{
    public partial class PageDatos : System.Web.UI.Page
    {
        logDatos dat = new logDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            cargarDatos();
        }

        private void cargarDatos()
        {
            string cadena = "workstation id=Inmmokraft.mssql.somee.com;packet size=4096;user id=Barbas_SQLLogin_1;pwd=xhuilpj8aq;data source=Inmmokraft.mssql.somee.com;persist security info=False;initial catalog=Inmmokraft";
            SqlConnection con = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsuario,tblDatos,tblPagina,tblGrupos Where tblDatos.idUsuario=tblUsuario.idUsuario and tblDatos.idGrupo=tblGrupos.idGrupo and tblDatos.idPagina=tblPagina.idPagina and tblDatos.datEstado='A'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            gdvDatos.DataSource = dt;
            gdvDatos.DataBind();
            con.Close();
            
        }
        protected void gdvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int codigo = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName=="Editar")
            {
                Response.Redirect("~/Mantenimiento/nuevoDato.aspx?cod=" + codigo,true);
                Context.ApplicationInstance.CompleteRequest();
            }
            else if (e.CommandName=="Eliminar")
            {
                tblDatos data = new tblDatos();

                data=logDatos.obtenerDatos(codigo);
                if (data!=null)
                {
                    logDatos.eliminarDatos(data);
                    cargarDatos();
                }
            }
        }

        protected void btnAgregarDato_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/nuevoDato.aspx");
        }
    }
}