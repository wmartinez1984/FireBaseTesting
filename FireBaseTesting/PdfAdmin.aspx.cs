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
                DateTime date =  DateTime.Parse(datepicker.Value);
                string fileNameURL = "";
                string fileExtension = "";
                bool guardar = false;
                if (FileUpload1.HasFile)
                {
                    foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                    {
                        fileExtension = Path.GetExtension(postedFile.FileName);
                        if(fileExtension.Equals(".pdf"))
                        {
                            postedFile.SaveAs(Server.MapPath("~/pdfs/") + id + ".pdf");
                            fileNameURL = id.ToString();
                            guardar = true;
                        }
                        else
                        {
                            string script2 = @"<script type='text/javascript'>
                                        swal('Error al generar el Link', 'El archivo adjunto debe ser PDF', 'error');
                                        </script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script2, false);
                        }

                    }

                    if(guardar)
                    {
                        LINKDataEntity lINKDataEntity = new LINKDataEntity();
                        lINKDataEntity.id = id;
                        lINKDataEntity.FechaCaducidad = date;
                        lINKDataEntity.Documento = id.ToString() + ".pdf";
                        lINKDataEntity.Descripcion = txtDescripciones.Text;
                        LINKDataDAL lINKDataDAL = new LINKDataDAL();
                        lINKDataDAL.LINKDataInsert(lINKDataEntity);

                        string script = @"<script type='text/javascript'>  swal('Link generado!', 'El link se generó correctamente', 'success');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        txtDescripciones.Text = String.Empty;
                        datepicker.Value = String.Empty;

                        Alink.HRef = "ViewPdf.aspx?link=" + id;
                        divDatos.Style.Add("display", "none");
                        divLink.Style.Add("display", "inline");
                    }
                   
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