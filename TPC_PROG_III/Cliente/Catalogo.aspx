<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_PROG_III.Cliente.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;">Catálogo</h2>

    <div class="filtros" style="margin: 20px 0; display: flex; flex-wrap: wrap; gap: 15px;">
        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Buscar por título" />

        <asp:DropDownList ID="ddlAutor" runat="server" CssClass="form-control">
        </asp:DropDownList>

        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
        </asp:DropDownList>

        <asp:DropDownList ID="ddlOrdenPrecio" runat="server" CssClass="form-control">
            <asp:ListItem Text="Ordenar por precio" Value="" />
            <asp:ListItem Text="Precio: menor a mayor" Value="asc" />
            <asp:ListItem Text="Precio: mayor a menor" Value="desc" />
        </asp:DropDownList>

        <asp:Button ID="btnFiltrar" runat="server" Text="Aplicar Filtros" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
    </div>

    <div class="catalogo-grid">
        <asp:Repeater ID="rptLibros" runat="server" OnItemCommand="rptLibros_ItemCommand">
            <ItemTemplate>
                <div class="carta-libro">
                    <div class="imagen-placeholder">
                        <img src='<%# Eval("Imagen") %>' alt="Portada" style="width:100%; height:180px; object-fit:cover; border-radius:6px;" />
                    </div>
                    <h4 style="font-size: 16px;"><%# Eval("Titulo") %></h4>
                    <p style="color: #007bff;"><%# String.Format("${0:N2}", Eval("Precio")) %></p>
                    <asp:Button ID="btnVer" runat="server" CommandName="VerDetalle" CommandArgument='<%# Eval("Id") %>' Text="Ver detalle" CssClass="btn-ver" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>