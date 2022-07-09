﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;


namespace WebApp1.Mantenimiento
{
    public partial class vistaAdmin : System.Web.UI.Page
    {

        logUser us = new logUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUsuarios();
            }
            
        }

        private void cargarUsuarios()
        {
            if (Request["tusu"]!=null)
            {
                int key = Convert.ToInt32(Request["tusu"]);
                List<tblUsuario> user = new List<tblUsuario>();
                user = logUser.listarUsersxID(key);
                if (user.Count!=0)
                {
                    if (user != null)
                    {
                        grvCRUD.DataSource = user;
                        grvCRUD.DataBind();
                        lblMensaje.Visible = false;
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text="No hay datos registrados";
                }
            }

        }

        protected void grvCRUD_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Mantenimiento/nuevoUsuario.aspx?cod=" + codigo, true);
                Context.ApplicationInstance.CompleteRequest();
            }
            else if (e.CommandName == "Eliminar")
            {
                tblUsuario user = new tblUsuario();
                user = logUser.obtenerxID(codigo);
                if (user != null)
                {
                    logUser.eliminarUser(user);
                    cargarUsuarios();
                }
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Request["tusu"] != null)
            {
                int tusu = Convert.ToInt32(Request["tusu"].ToString());
                Response.Redirect("~/Mantenimiento/nuevoUsuario.aspx?tipo="+tusu);
            }
        }
    }
}