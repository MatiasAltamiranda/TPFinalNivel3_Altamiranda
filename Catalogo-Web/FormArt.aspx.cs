using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Catalogo_Web
{
    public partial class FormArt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Marca> marcas = marcaNegocio.listar();
                    List<Categoria> categorias = categoriaNegocio.listar();

                    //CARGA LISTA DESPLEGABLE DE MARCAS DESDE DB
                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    //CARGA LISTA DESPLEGABLE DE CATEGORIAS DESDE DB
                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw ex;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevoArt = new Articulo();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                nuevoArt.Codigo = txtCodigo.Text;
                nuevoArt.Nombre = txtNombre.Text;
                nuevoArt.Descripcion = txtDescripcion.Text;
                nuevoArt.Precio = int.Parse(txtPrecio.Text);
                nuevoArt.ImagenUrl = txtUrlImagen.Text;

                nuevoArt.Marca = new Marca();
                nuevoArt.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevoArt.Categoria = new Categoria();
                nuevoArt.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);


                articuloNegocio.agregar(nuevoArt);
                Response.Redirect("listaArt.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw ex;
            }
        }
    }
}