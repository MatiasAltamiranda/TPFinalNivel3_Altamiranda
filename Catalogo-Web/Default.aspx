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
                            <a href="#" class="text-decoration-none">
                                <h5 class="card-title"><%: articulo.Nombre %></h5>
                            </a>
                            <p class="card-text text-secondary"><%: articulo.Descripcion %></p>
                            <p class="card-text fs-4">$ <%: articulo.Precio %></p>
                        </div>
                    </div>
                </div>
            <% } %>
        </div>
    </div>
</asp:Content>

