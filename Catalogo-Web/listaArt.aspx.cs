using System;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;


namespace Catalogo_Web
{
    public partial class listaArt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TRAIGO LOS ARTICULOS DE LA BASE DE DATOS Y LOS GUARDO EN SESION PARA MOSTRARLOS EN LA LISTA DEL FRONT
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listar());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GUARDO EL ID OBTENIDO A TRAVEZ DEL DATA GRID  PARA REDIRECCIONAR EL ARTICULO SELECCIONADO A SU CORRESPONDIENTE FORMULARIO
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormArt.aspx?id=" + id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            //GUARDO EN UNA LISTA LOS ARTICULOS GUARDADOS EN SESION FILTRADOS POR TEXTO INGRESADO EN TEXTBOX
            List<Articulo> listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll(a => a.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || a.Codigo.ToLower().Contains(txtFiltro.Text.ToLower()));
            //ACTUALIZO LA LISTA DE ARTICULOS EN EL FRONT CON LA NUEVA LISTA FILTRADA
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos .DataBind();
        }
    }
}