<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_PROG_III.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Carrito de Compras</h2>

    <div class="contenedor-carrito">

        <!-- Lista de productos -->
        <asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="rptCarrito_ItemCommand">
            <ItemTemplate>
                <div class="item-carrito">
                    <div class="carrito-imagen">
                        <img src='<%# Eval("Libro.Imagen") %>' width="100" />
                    </div>
                    <div class="carrito-info">
                      <h4 class="titulo-libro"><%# Eval("Libro.Titulo") %></h4>
                      <p class="editorial"><%# Eval("Libro.Editorial") %></p>
                     <p class="precio">Precio unitario: $<%# Eval("Libro.Precio") %></p>
                      <p class="precio">Subtotal: $<%# Eval("Precio") %></p>
                    </div>
                    <div class="carrito-controles">
                       Cantidad: <%# Eval("Cantidad") %>
                      <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Libro.Id") %>' CommandName="Eliminar" CssClass="btn-eliminar">
                          Eliminar
                      </asp:LinkButton> 
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="carrito-total">
            <asp:Label ID="lblTotal" runat="server" CssClass="carrito-total-texto" />
            <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn-finalizar" />
        </div>
    </div>
</asp:Content>
