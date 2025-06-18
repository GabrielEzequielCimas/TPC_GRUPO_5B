<%@ Page Title="Detalle del Libro" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="DetalleLibro.aspx.cs" Inherits="TPC_PROG_III.DetalleLibro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" CssClass="h3" />
    <br />
    <asp:Label ID="lblGenero" runat="server" CssClass="badge bg-secondary" />
    <br />
    <asp:Image ID="imgLibro" runat="server" Width="200" />
    <br />
    <asp:Label ID="lblDescripcion" runat="server" CssClass="p" />
    <br />
    <asp:Label ID="lblAutor" runat="server" CssClass="ms-2 text-primary" />
    <br /><br />

    <!-- Botones -->
    <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-primary w-100" />
    <asp:Button ID="btnComprar" runat="server" Text="Comprar" CssClass="btn btn-primary w-100" />
</asp:Content>