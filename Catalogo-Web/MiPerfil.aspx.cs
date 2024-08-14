using Dominio;
using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_Web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!(Seguridad.sessionActiva(Session["sessionActiva"])))
                    {
                        //PRECARGA LOS DATOS DEL USUARIO EN EL FORMULARIO DE MI PERFIL
                        Usuario usuario = (Usuario)Session["sessionActiva"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtEmail.Enabled = false;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        if(!string.IsNullOrEmpty(usuario.UrlImagen) )
                        {
                            imgPerfil.ImageUrl = "~/Images/" + usuario.UrlImagen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("erro", ex);
            }
          
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                // ACTUALIZA LOS DATOS DEL USUARIO
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["sessionActiva"];
                if(txtImagen.PostedFile.FileName != "") { 

                string ruta = Server.MapPath("./Images/");
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                usuario.UrlImagen = "perfil-" + usuario.Id + ".jpg";

                }

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;


                usuarioNegocio.actualizar(usuario);

                imgPerfil.ImageUrl = "~/Images/" + usuario.UrlImagen;


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}