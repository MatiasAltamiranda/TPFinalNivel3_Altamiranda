﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Catalogo_Web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtPassRepet.Text)
            {

                try
                {
                    Usuario user = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                    user.Nombre = txtNombre.Text;
                    user.Apellido = txtApellido.Text;
                    user.Email = txtEmail.Text;
                    user.Pass = txtPass.Text;

                    int id = usuarioNegocio.registrarUsuario(user);

                    Response.Redirect("Default.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                }
            }
            else
            {
                labelConfirm.Text = "Las contraseñas no coinciden"; 
            }

        }
    }
}