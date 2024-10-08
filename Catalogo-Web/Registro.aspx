﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Catalogo_Web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registrarse</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 rounded border-4 opacity-75  mt-5 bg-primary px-5 pt-4 pb-5">
                <h2 class="lead fs-1 mb-4 fw-bold text-white">Crear Usuario</h2>
                <div class="mb-3 text-start">
                    <label class="form-label fs-5 lead text-white" for="txtNombre">Nombre</label>
                    <asp:TextBox MaxLength="50" runat="server" CssClass="form-control" ID="txtNombre" PlaceHolder="Ingresa tu nombre"></asp:TextBox>
                </div>

                <div class="mb-3 text-start">
                    <label class="form-label fs-5 lead text-white" for="txtApellido">Apellido</label>
                    <asp:TextBox  MaxLength="50" runat="server" CssClass="form-control" ID="txtApellido" PlaceHolder="Ingresa tu Apellido"></asp:TextBox>
                </div>

                <div class="mb-2 text-start">
                    <label class="form-label fs-5 lead text-white" for="txtEmail">Email</label>
                    <asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioEmail" />
                    <asp:TextBox MaxLength="100" runat="server" CssClass="form-control" ID="txtEmail" TextMode="Email" PlaceHolder="Ingresa tu dirección de correo electronico" required="true"></asp:TextBox>
                     <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ValidationExpression="^^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorMessage="La dirección de correo no es válida"  ForeColor="Red" />
                </div>

                <div class="mb-4 text-start">
                    <label class="form-label fs-5 lead text-white" for="txtPass">Contraseña</label>
                    <asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioPass" />
                    <asp:TextBox MaxLength="20" runat="server" CssClass="form-control" ID="txtPass" PlaceHolder="Ingresa una contraseña" TextMode="Password" required="true"></asp:TextBox>

                </div>

                <div class="mb-4 text-start">
                    <label class="form-label fs-5 lead text-white" for="txtPassRepet">Repetir Contraseña</label>
                    <asp:Label Text="" runat="server" CssClass="text-danger  fw-bold" ID="obligatorioPassRepeat" />
                    <asp:TextBox MaxLength="20" runat="server" CssClass="form-control" ID="txtPassRepet" PlaceHolder="Repite la contraseña" TextMode="Password" required="true"></asp:TextBox>
                </div>
                <asp:Button Text="Registrarse" runat="server" CssClass="btn btn-light mt-4 w-100 fs-5" ID="btnRegistro" OnClick="btnRegistro_Click" />
            </div>
            <asp:Label Text="" runat="server" ID="labelConfirm" CssClass="text-danger fw-bold mt-3" />
            <div class="col-4"></div>
        </div>
    </div>
</asp:Content>
