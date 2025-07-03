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
                      <p class="editorial"><%# Eval("Libro.Editorial.Descripcion") %></p>
                     <p class="precio">Precio unitario: $<%# Eval("Libro.Precio") %></p>
                      <p class="precio">Subtotal: $<%# Eval("Precio") %></p>
                    </div>
                    <div class="carrito-controles">
                        <label for="txtCantidad">Cantidad:</label>
                        <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>' Width="40" />
        
                        <asp:LinkButton ID="btnActualizar" runat="server" CommandArgument='<%# Eval("Libro.Id") %>' CommandName="Actualizar" CssClass="btn-actualizar">
                            Actualizar
                        </asp:LinkButton>
    
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Libro.Id") %>' CommandName="Eliminar" CssClass="btn-eliminar">
                            Eliminar
                        </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Button ID="Button1" runat="server" Text="Volver al Catálogo" CssClass="btn-volver" OnClick="btnVolverCatalogo_Click" />
        <div class="carrito-total">
            <asp:Label ID="lblTotal" runat="server" CssClass="carrito-total-texto" />
            <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn-finalizar" OnClick="btnFinalizarCompra_Click" />
        </div>
        
    </div>
</asp:Content>
