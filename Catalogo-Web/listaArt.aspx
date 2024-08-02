<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listaArt.aspx.cs" Inherits="Catalogo_Web.listaArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Articulos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class ="mb-4">Listado de Articulos</h1>
        <asp:GridView ID="DgvArticulos" runat="server" CssClass="table"></asp:GridView>
    </div>
</asp:Content>
