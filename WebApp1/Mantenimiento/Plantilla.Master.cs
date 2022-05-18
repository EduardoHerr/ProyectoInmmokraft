using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp1.Mantenimiento
{
    public partial class Plantilla : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                cargarLinks();
                if (Session["nombre"] != null)
                {
                    
                        string nombre= Session["nombre"].ToString();
                        lblNombre.Text = "Bienvenido, de nuevo " + nombre;
                    
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

                if (Session["rol"] != null)
                {
                    int rol = Convert.ToInt32(Session["rol"]);
                    if (rol != 1)
                    {
                        pnlAdmin.Visible = false;
                    }

                }
            }
        }

        private void cargarLinks()
        {
            ListItem i;
            i = new ListItem("Reportes Mensuales", "1");
            ddlLista.Items.Add(i);
            i = new ListItem("Enero", "2");
            ddlLista.Items.Add(i);
            i = new ListItem("Febrero", "3");
            ddlLista.Items.Add(i);
            i = new ListItem("Marzo", "4");
            ddlLista.Items.Add(i);
            i = new ListItem("Abril", "5");
            ddlLista.Items.Add(i);
            i = new ListItem("Mayo", "6");
            ddlLista.Items.Add(i);
            i = new ListItem("Junio", "7");
            ddlLista.Items.Add(i);
            i = new ListItem("Julio", "8");
            ddlLista.Items.Add(i);
            i = new ListItem("Agosto", "9");
            ddlLista.Items.Add(i);
            i = new ListItem("Septiembre", "10");
            ddlLista.Items.Add(i);
            i = new ListItem("Octubre", "11");
            ddlLista.Items.Add(i);
            i = new ListItem("Noviembre", "12");
            ddlLista.Items.Add(i);
            i = new ListItem("Diciembre", "13");
            ddlLista.Items.Add(i);
            i = new ListItem("TODOS", "14");
            ddlLista.Items.Add(i);
        }

        protected void lnkDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/PageDatos.aspx");
        }

        protected void lnkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/PageUsuarios.aspx");
        }

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session["nombre"] = null;
            Response.Redirect("~/Login.aspx");

        }

        protected void lnkInicio_Click(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                int rol = Convert.ToInt32(Session["rol"]);
                if (rol == 2)
                {
                    Response.Redirect("~/Mantenimiento/postViewer.aspx");
                }
                else if (rol==3)
                {
                    Response.Redirect("~/Mantenimiento/analistaView.aspx");
                }
                else
                {
                    Response.Redirect("~/inicioAdmin.aspx");
                }

            }
           
        }

        protected void ddlLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pag = ddlLista.SelectedIndex;
            if (pag != 0)
            {
                switch (pag)
                {
                    case 1:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=01");
                        
                        break;
                    case 2:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=02");
                        break;
                    case 3:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=03");
                        break;
                    case 4:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=04");
                        break;
                    case 5:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=05");
                        break;
                    case 6:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=06");
                        break;
                    case 7:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=07");
                        break;
                    case 8:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=08");
                        break;
                    case 9:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=09");
                        break;
                    case 10:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=10");
                        break;
                    case 11:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=11");
                        break;
                    case 12:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=12");
                        break;
                    case 13:
                        Response.Redirect("~/Mantenimiento/Reportes/WebForm1.aspx?cod=13");
                        break;
                    default:
                        Response.Redirect("~/Mantenimiento/vistaAdmin.com");
                        break;

                }
                ddlLista.SelectedIndex = 0;
            }
        }
    }
}