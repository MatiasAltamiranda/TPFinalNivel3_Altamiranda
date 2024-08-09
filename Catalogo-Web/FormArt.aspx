<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormArt.aspx.cs" Inherits="Catalogo_Web.FormArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Articulos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row mt-5">
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label" for="txtID">ID</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtID" />
                </div>
                <div class="mb-3">
                    <label class="form-label" for="txtCodigo">Codigo</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo" />
                </div>
                <div class="mb-3">
                    <label class="form-label" for="txtNombre">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="mb-3">
                    <label class="form-label" for="ddlMarca">Marca</label>
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="ddlCategoria">Categoria</label>
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-4">
                    <label class="form-label" for="txtPrecio">Precio</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" CssClass="btn btn-success" OnClick="btnAceptar_Click" />
                    <a href="listaArt.aspx">Cancelar</a>
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label" for="txtDescripcion">Descripcion</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control" ID="txtDescripcion" />
                </div>  
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                         <div class="mb-3">
                              <label class="form-label" for="txtUrlImagen">Url Imagen</label>
                             <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />
                         </div>
                        <asp:Image ImageUrl="https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg" runat="server" ID="imgArticulo" Width="60%" Height="400px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
