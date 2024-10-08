﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Helper;
using Negocio;

namespace Catalogo_Web
{
    public partial class FormArt : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.isAdmin(Session["sessionActiva"]))
            {
                Response.Redirect("Default.aspx", false);
            }

            txtID.Enabled = false;
            ConfirmaEliminacion = false;
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

                //CONFIGURACION EN CASO DE EDITAR UN ARTICULO

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    //PRE-CARGA DATOS ARTICULO SELECCIONADO EN FORMULARIO

                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Articulo seleccionado = (articuloNegocio.listar(id))[0];
                    txtCodigo.Text = seleccionado.Codigo;
                    txtID.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.ImagenUrl;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    cargarImagen();
                    btnAceptar.Text = "Modificar";
                    btnAceptar.CssClass = "btn btn-warning";
                }



            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw ex;
            }
        }

       

        public void cargarImagen()
        {
            //ACTUALIZA LA IMAGEN CARGADA EN EL FORMULARIO
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!(Validacion.validarTextoVacio(txtCodigo.Text) || Validacion.validarTextoVacio(txtNombre.Text) || Validacion.validarTextoVacio(txtPrecio.Text) || Validacion.validarTextoVacio(txtDescripcion.Text)))
                {
                try
                {
                    Page.Validate();
                    if (!Page.IsValid)
                        return;


                    // CREA UN ARTICULO NUEVO Y RELLENA CON LOS DATOS DE LOS TEXTBOX
                    Articulo nuevoArt = new Articulo();
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    nuevoArt.Codigo = txtCodigo.Text;
                    nuevoArt.Nombre = txtNombre.Text;
                    nuevoArt.Descripcion = txtDescripcion.Text;
                    nuevoArt.Precio = decimal.Parse(txtPrecio.Text);
                    nuevoArt.ImagenUrl = txtUrlImagen.Text;

                    nuevoArt.Marca = new Marca();
                    nuevoArt.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                    nuevoArt.Categoria = new Categoria();
                    nuevoArt.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                    //EVALUA SI SE ESTA AGREGANDO O MODIFICANDO UN ARTICULO

                    if (Request.QueryString["id"] != null)
                        // MODIFICA EL ARTICULO EN LA BASE DE DATOS
                    {
                        nuevoArt.Id = int.Parse(txtID.Text);
                        articuloNegocio.modificar(nuevoArt);
                    }

                    else
                         // AGREGA EL ARTICULO NUEVO A LA BASE DE DATOS
                        articuloNegocio.agregar(nuevoArt);
                       


                    Response.Redirect("listaArt.aspx", false);
                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex);
                    throw ex;
                }
            }
            else
            {
                lblCamposVacios.Text = "Verifica que los campos obligatorios no estén vacíos.";
                obligatorioTextCategoria.Text = "*";
                obligatorioTextCodigo.Text = "*";
                obligatorioTextNombre.Text = "*";
                obligatorioTextPrecio.Text = "*";
                obligatorioTextDescripcion.Text = "*";
                obligatorioTextMarca.Text = "*";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //CAMBIA EL ESTADO DE CONFIRMAELIMINACION PARA PODER RENDERIZAR EN PANTALLA EL BOTON DE CONFIRMAR ELIMINADO
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //CONFIRMA CHECKED EN TRUE PARA REALIZAR DELETE
                if (confirmaEliminar.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtID.Text));
                    Response.Redirect("listaArt.aspx");
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
            cargarImagen();
        }
    }
}