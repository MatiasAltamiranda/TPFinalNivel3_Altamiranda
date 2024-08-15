<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-5">
        <div class="row g-4 flex-row justify-content-center">
            <% foreach (Dominio.Articulo articulo in listaArticulos)
                { %>
            <div class="col-md-4 col-xl-3 col-xxl-2 mt-4">
                <div class="card" style="width: 16rem;">
                    <img style="height: 15rem;" src="<%: articulo.ImagenUrl %>" class="card-img-top img-fluid" alt="<%: articulo.Nombre %>" />
                    <div class="card-body">
                        <a href="#" class="text-decoration-none" data-bs-toggle="modal" data-bs-target="#<%: articulo.Id %>">
                            <h5 class="card-title"><%: articulo.Nombre %></h5>
                        </a>
                        <p class="card-text text-secondary"><%: articulo.Descripcion %></p>
                        <p class="card-text fs-4">$ <%: articulo.Precio %></p>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="<%: articulo.Id %>" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body row">
                            <div class="col-12">
                                <h3 class="mb-2"><%: articulo.Nombre %></h3>
                            </div>
                            <div class="col-6">
                                <img src="<%: articulo.ImagenUrl %>" class="img-fluid" alt="<%: articulo.Nombre %>" />
                            </div>
                            <div class="col-6 mt-3">
                                <p class="text-primary fw-bold">Categoria: <span class="text-black fw-normal"><%: articulo.Categoria %></span></p>
                                <p class="text-primary fw-bold">Marca: <span class="text-black fw-normal"><%: articulo.Marca %></span></p>
                                <p class="text-primary fw-bold">SKU: <span class="text-black fw-normal"><%: articulo.Codigo %></span></p>
                                <p class="fs-5">$ <span class="fs-3 fw-bold"> <%: articulo.Precio %></span></p>
                            </div>
                            <div class="col-12">
                                <p class="fw-bold text-secondary">Descripción: </p>
                                <p class="text-secondary"><%: articulo.Descripcion %></p>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>

