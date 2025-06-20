<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TPC_PROG_III.Registrarse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="contenedor-registro">
        <h2>Crear Cuenta</h2>

        <div class="formulario">
            <label for="txtNombre">Nombre completo</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="ingresar-info" />
        </div>

        <div class="formulario">
            <label for="txtEmail">Correo electrónico</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="ingresar-info" />
        </div>

        <div class="formulario">
            <label for="txtPassword">Contraseña</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="ingresar-info" />
        </div>

        <div class="formulario">
            <label for="txtConfirmar">Confirmar contraseña</label>
            <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" CssClass="ingresar-info" />
        </div>

        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn-login" OnClick="btnRegistrar_Click" />

        <p class="registro-link">Ya tenés cuenta? <a href="/usuario/IniciarSesion.aspx">Iniciar sesión</a></p>
    </div>
</asp:Content>
