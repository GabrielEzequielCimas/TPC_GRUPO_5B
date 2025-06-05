<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_PROG_III.Catalogo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Catálogo de Libros</h2>
    <div class="catalogo-grid">
        <div class="carta-libro">
            <div class="imagen-placeholder"></div>
            <h4>Título del Libro</h4>
            <p>Autor</p>
            <p><strong>Precio</strong></p>
            <asp:Button ID="btnDetalle1" runat="server" Text="Ver Detalle" CssClass="btn-ver" />
        </div>

        <div class="carta-libro">
            <div class="imagen-placeholder"></div>
            <h4>Título del Libro</h4>
            <p>Autor</p>
            <p><strong>Precio</strong></p>
            <asp:Button ID="btnDetalle2" runat="server" Text="Ver Detalle" CssClass="btn-ver" />
        </div>

        <div class="carta-libro">
            <div class="imagen-placeholder"></div>
            <h4>Título del Libro</h4>
            <p>Autor</p>
            <p><strong>Precio</strong></p>
            <asp:Button ID="btnDetalle3" runat="server" Text="Ver Detalle" CssClass="btn-ver" />
        </div>
    </div>
</asp:Content>
