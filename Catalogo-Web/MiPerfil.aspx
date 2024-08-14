<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Catalogo_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mi Perfil</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="mt-4 lead fs-2 fw-bold">Mi Perfil</h2>
        <div class="row">
                <div class="col-1"></div>
            <div class="col-5">
                <div class="mt-5 mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                </div>
                <div class="mb-3 mt-5">
                    <asp:Button Text="Guardar" runat="server" CssClass="btn btn-primary" ID="btnGuardar" onclick="btnGuardar_Click"/>
                </div>
            </div>
            <div class="col-4">
                <div class="mt-5 mb-3">
                    <label class="form-label">Imagen de Perfil</label>
                    <input  type="file" id="txtImagen" runat="server" class="form-control"/>
                </div>
                <asp:Image ImageUrl="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png" runat="server" ID="imgPerfil" CssClass="img-fluid mb-3 rounded-circle w-50 h-50 mx-5" />
            </div>
              <div class="col-3"></div>
        </div>
    </div>
</asp:Content>
