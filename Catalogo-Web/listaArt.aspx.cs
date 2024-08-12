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

        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //TRAIGO LOS ARTICULOS DE LA BASE DE DATOS Y LOS GUARDO EN SESION PARA MOSTRARLOS EN LA LISTA DEL FRONT
            if (!IsPostBack) { 
            FiltroAvanzado = false;
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listar());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
            }
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

        protected void filtroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chbAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Comienza con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text); 
                dgvArticulos .DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}