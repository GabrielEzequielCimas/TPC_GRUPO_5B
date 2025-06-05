<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="TPC_PROG_III.IniciarSesion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contenedor-login">
        <h2>Iniciar Sesión</h2>

        <div class="formulario">
            <label for="txtEmail">Correo electrónico</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="ingresar-info" />
        </div>

        <div class="form-group">
            <label for="txtPassword">Contraseña</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="ingresar-info" />
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn-login" />

        <p class="registro-link">No tenés cuenta? <a href="/usuario/registrarse.aspx">Registrate</a></p>
    </div>
</asp:Content>
