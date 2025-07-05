<%@ Page Title="Mis Compras" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="TPC_PROG_III.MisCompras" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mis Compras</h2>

    <asp:Repeater ID="rptCompras" runat="server" OnItemCommand="rptCompras_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Nro Factura</th>
                        <th>Fecha</th>
                        <th>Estado</th>
                        <th>Dirección Entrega</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("NumeroFactura") %></td>
                <td><%# Eval("Fecha", "{0:dd/MM/yyyy}") %></td>
                <td><%# Eval("Estado") %></td>
                <td><%# Eval("DireccionEntrega") %></td>
                <td>
                    <asp:LinkButton ID="lnkVerDetalles" runat="server" CommandName="VerDetalles" CommandArgument='<%# Eval("Id") %>'>
                        Ver Detalles
                    </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Panel ID="pnlDetalles" runat="server" Visible="false" CssClass="mt-3">
        <h3>Detalles de la Compra</h3>
        <asp:Repeater ID="rptDetalles" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Libro</th>
                            <th>Cantidad</th>
                            <th>Precio</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Libro.Titulo") %></td>
                    <td><%# Eval("Cantidad") %></td>
                    <td>$<%# Eval("Precio") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
</asp:Content>
