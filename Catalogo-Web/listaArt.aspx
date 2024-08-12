<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listaArt.aspx.cs" Inherits="Catalogo_Web.listaArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Articulos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container mt-4">
        <h1 class="mb-4">Listado de Articulos</h1>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <div class="d-flex justify-content-center mb-4 mt-3">
                    <label class="form-label fs-5 mx-2" for="filtro">Filtro</label>
                    <asp:TextBox CssClass="form-control w-75" runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeHolder="Busqueda por nombre o código del articulo" />
                </div>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
