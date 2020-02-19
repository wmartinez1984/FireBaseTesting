using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FireBaseTesting
{
    public partial class PdfAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.NewGuid();
                string fileNameURL = "";
                if (FileUpload1.HasFile)
                {
                    foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        postedFile.SaveAs(Server.MapPath("~/pdfs/") + fileName);
                        fileNameURL = fileName;

                    }

                    string script = @"<script type='text/javascript'>  swal('Link generado!', 'El link se generó correctamente', 'success');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                    Alink.HRef = "ViewPdf.aspx?link=" + id;
                    divDatos.Style.Add("display", "none");
                    divLink.Style.Add("display", "inline");
                }
                else
                {
                    string script = @"<script type='text/javascript'>swal('Error', 'Debe seleccionar un archivo pdf', 'error');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }

                
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                                        swal('Error al generar el Link', 'Por favor vuelva a intentarlo', 'error');
                                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                Response.Write(ex.ToString());
            }
        }
    }
}