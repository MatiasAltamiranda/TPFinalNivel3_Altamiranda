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
                <div class="d-flex mb-3 mt-3">
                    <label class="me-3 form-label fs-5" for="filtro">Filtro</label>
                    <asp:TextBox CssClass="form-control w-75" runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeHolder="Busqueda por nombre o código del articulo" />
                </div>
                <div class="mb-3">
                    <asp:CheckBox Text="Filtro Avanzado" runat="server" CssClass="" ID="chbAvanzado" AutoPostBack="true" OnCheckedChanged="filtroAvanzado_CheckedChanged" />
                </div>
                <%if (chbAvanzado.Checked)
                    { %>
                <div class="row">
                    <div class="col-3 mb-4">
                        <asp:Label Text="Campo" runat="server" CssClass="form-label" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoria" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-3 mb-4">
                        <asp:Label Text="Criterio" runat="server" CssClass="form-label" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-3 mb-4">
                        <asp:Label Text="Valor" runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>
                    <div class="col-3 mb-4 d-flex align-items-end">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary fs-5" ID="btnBuscar" OnClick="btnBuscar_Click" />
                    </div>

                </div>
                <%   } %>
                <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"
                    AutoGenerateColumns="false" DataKeyNames="Id"
                    OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍🏻" />
                    </Columns>
                </asp:GridView>
                <a href="FormArt.aspx" class="btn btn-primary">Agregar </a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
