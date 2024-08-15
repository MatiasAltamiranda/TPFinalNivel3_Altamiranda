<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormArt.aspx.cs" Inherits="Catalogo_Web.FormArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Articulos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row mt-5">
            <div class="col-md-6 col-12 ">
                <div class="mb-3">
                    <label class="form-label" for="txtID">ID</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtID" />
                </div>
                <div class="mb-3">
                    <label class="form-label" for="txtCodigo">Codigo</label><asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioTextCodigo" />
                    <asp:TextBox MaxLength="50" runat="server" CssClass="form-control" ID="txtCodigo" required="true" />
                </div>
                <div class="mb-3">
                    <label class="form-label" for="txtNombre">Nombre</label><asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioTextNombre" />
                    <asp:TextBox MaxLength="50" runat="server" CssClass="form-control" ID="txtNombre" required="true" />
                </div>
                <div class="mb-3">
                    <label class="form-label" for="ddlMarca">Marca</label><asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioTextMarca" />
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" required="true"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="ddlCategoria">Categoria</label><asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioTextCategoria" />
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" required="true"></asp:DropDownList>
                </div>
                <div class="mb-4">
                    <label class="form-label" for="txtPrecio">Precio</label><asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioTextPrecio" />
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" required="true" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPrecio" ValidationExpression="^\d+([,]\d+)?$" ErrorMessage="El campo solo acepta valores númericos enteros y decimales separados con ',' (coma) "
                     ForeColor="Red" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" CssClass="btn btn-success" OnClick="btnAceptar_Click" />
                    <a class="mx-3" href="listaArt.aspx">Cancelar</a>
                </div>
                <asp:Label Text="" runat="server" ID="lblCamposVacios" CssClass="text-danger fs-5" />
            </div>
            <div class="col-12 col-md-6">
                <div class="mb-3">
                    <label class="form-label" for="txtDescripcion">Descripcion</label><asp:Label Text="" runat="server" CssClass="text-danger fw-bold" ID="obligatorioTextDescripcion" />
                    <asp:TextBox runat="server" MaxLength="150" TextMode="MultiLine" CssClass="form-control" ID="txtDescripcion" required="true" />
                </div>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label class="form-label" for="txtUrlImagen">Url Imagen</label>
                            <asp:TextBox MaxLength="1000" runat="server" ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />
                        </div>
                        <asp:Image ImageUrl="https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg" runat="server" ID="imgArticulo" Width="60%" Height="400px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%
            //CONDICION EVALUA SI SE TRATA DE UN ARTICULI PRECARGADO PARA NO RENDERIZAR BOTON DE ELIMINAR EN EL CASO DE AGREGAR UN PRODUCTO NUEVO
            if (Request.QueryString["id"] != null)
            { %>
        <div class="row text-end">
            <div class="col-12 col-md-6">
                <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button Text="Eliminar" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
                        </div>

                        <%if (ConfirmaEliminacion)
                            {

                        %>

                        <div class="mb-3">
                            <asp:CheckBox Text="Esta por eliminar el articulo. ¿Esta seguro? " ID="confirmaEliminar" runat="server" />
                            <asp:Button Text="Confirmar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" runat="server" CssClass="btn btn-outline-danger" />
                        </div>

                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%  } %>
    </div>
</asp:Content>
