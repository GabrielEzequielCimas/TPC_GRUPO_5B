<%@ Page Title="Compra Confirmada" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionCompra.aspx.cs" Inherits="TPC_PROG_III.Cliente.ConfirmacionCompra" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 text-center">
        <h2 class="text-success">¡Gracias por tu compra!</h2>
        <p>Tu pedido ha sido registrado correctamente.</p>

        <asp:Button ID="btnSeguirComprando" runat="server" Text="Seguir Comprando" CssClass="btn btn-primary mt-3" OnClick="btnSeguirComprando_Click" />
    </div>
</asp:Content>
