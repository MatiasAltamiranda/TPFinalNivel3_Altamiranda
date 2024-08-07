<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listaArt.aspx.cs" Inherits="Catalogo_Web.listaArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Articulos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Listado de Articulos</h1>
        <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"
            AutoGenerateColumns="false" DataKeyNames="Id"
            OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍🏻" />
            </Columns>
        </asp:GridView>
        <a href="FormArt.aspx" class="btn btn-primary">Agregar </a>
    </div>
</asp:Content>
