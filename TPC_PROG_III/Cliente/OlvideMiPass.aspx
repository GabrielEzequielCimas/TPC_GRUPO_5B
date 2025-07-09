<%@ Page Title="" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="OlvideMiPass.aspx.cs" Inherits="TPC_PROG_III.Cliente.OlvideMiPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">¿Olvidaste tu contraseña?</h2>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Correo electrónico</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>
        <asp:Button ID="btnEnviarCodigo" runat="server" Text="Enviar código" CssClass="btn btn-primary" OnClick="btnEnviarCodigo_Click" />
    </div>
</asp:Content>
