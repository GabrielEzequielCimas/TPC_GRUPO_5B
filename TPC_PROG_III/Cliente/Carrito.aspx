<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_PROG_III.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Carrito de Compras</h2>

    <div class="contenedor-carrito">

        <!-- Lista de productos -->
        <div class="item-carrito">
            <div class="carrito-imagen"></div>
            <div class="carrito-info">
                <h4 class="titulo-libro">Título del Libro</h4>
                <p class="editorial">Editorial</p>
                <p class="precio">Precio: $0</p>
            </div>
            <div class="carrito-controles">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="input-cantidad" Text="1" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-eliminar" />
            </div>
        </div>

        <div class="carrito-total">
            <p>Total: $0</p>
            <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn-finalizar" />
        </div>
    </div>
</asp:Content>
