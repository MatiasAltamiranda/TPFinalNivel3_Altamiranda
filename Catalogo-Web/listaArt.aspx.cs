using System;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Catalogo_Web
{
    public partial class listaArt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          ArticuloNegocio negocio = new ArticuloNegocio();
          DgvArticulos.DataSource = negocio.listar();
          DgvArticulos.DataBind();
        }
    }
}