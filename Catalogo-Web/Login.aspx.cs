using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoguearse_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                //EN EL USUARIO CREADO GUARDA LOS VALORES INGRESADOS DESDE LOS TEXTBOX
                user.Email= txtEmail.Text;
                user.Pass = txtPass.Text;
                //EJECUTA EL LOGUEO SI EL USUARIO COINCIDE SE DIRECCIONA A LA PAGINA DE INICIO
                if (usuarioNegocio.login(user))
                {
                    Session.Add("sessionActiva", user);
                    Session.Add("isAdmin", user.Admin? "true" : "false");
                    Response.Redirect("default.aspx", false);
                }
                //EN CASO DE NO COINCIDIR EL USUARIO SE MOSTRARA UN ERROR EN LA PANTALLA
                else
                {
                    labelLogin.Text = "Email o contraseña incorrecto";
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}