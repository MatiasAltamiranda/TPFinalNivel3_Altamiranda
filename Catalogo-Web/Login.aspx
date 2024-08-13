<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Catalogo_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 rounded border-4 opacity-75  mt-5 bg-primary px-5 pt-4 pb-5">
                <h2 class="lead fs-1 mb-4 fw-bold text-white">Iniciar Sesion</h2>

                <div class="mb-3 text-start">
                    <label class="form-label fs-5 lead text-white" for="txtEmail">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" TextMode="Email" PlaceHolder="Ingresa tu dirección de correo electronico"></asp:TextBox>
                </div>

                <div class="mb-4 text-start">
                    <label class="form-label fs-5 lead text-white" for="txtPass">Contraseña</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" PlaceHolder="Ingresa una contraseña" TextMode="Password"></asp:TextBox>
                </div>

                <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-light mt-4 w-100 fs-5" ID="btnLoguearse" OnClick="btnLoguearse_Click"/>
            </div>
            <asp:Label Text="" runat="server" ID="labelLogin" CssClass="text-danger fw-bold mt-3" />
            <div class="col-4"></div>
        </div>
    </div>
</asp:Content>
