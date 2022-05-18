using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp1.Mantenimiento.Reportes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        string time = DateTime.Now.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request["cod"]!=null)
                {
                    if (Request["cod"] == "13")
                    {
                        string getdate1 = "SELECT* FROM[tblDatos]";
                        SqlDataSource1.SelectCommand = getdate1;
                    }
                    else
                    {
                        string getdate = "SELECT* FROM[tblDatos] WHERE datepart(mm, datFechaHoraPub) = datepart(mm,'2022-" + Request["cod"] + "-07 12:44:21.907' )";
                        SqlDataSource1.SelectCommand = getdate;
                    }
                }

                
                ReportViewer1.LocalReport.Refresh();
            }
            
        }

        


        protected void Export(object sender, EventArgs e)
        {
            
            try {
                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                //Export the RDLC Report to Byte Array.
                byte[] bytes = ReportViewer1.LocalReport.Render(rbFormat.SelectedItem.Value, null, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=Inmmokraft "+time+" ." + extension);
                Response.BinaryWrite(bytes);
                Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

    }
}