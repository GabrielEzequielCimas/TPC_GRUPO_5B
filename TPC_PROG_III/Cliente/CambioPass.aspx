<%@ Page Title="" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="CambioPass.aspx.cs" Inherits="TPC_PROG_III.Cliente.CambioPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="contenedor-registro">
    <h2>Cambiar contraseña</h2>
    <div class="formulario">
        <label for="txtPassword">Contraseña</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="ingresar-info" required />
    </div>

    <div class="formulario">
        <label for="txtConfirmar">Confirmar contraseña</label>
        <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" CssClass="ingresar-info" required />
    </div>

    <asp:Button ID="btnCambiar" runat="server" Text="Confirmar" CssClass="btn-login" OnClick="btnCambiar_Click" />
</div>
</asp:Content>
