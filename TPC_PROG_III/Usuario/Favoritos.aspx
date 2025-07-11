<%@ Page Title="" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPC_PROG_III.Usuarios.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .boton-fav {
            position: absolute;
            top: 10px;
            right: 10px;
            border-radius: 50%;
            font-size: 14px;
            width: 28px;
            height: 28px;
            padding: 0;
            text-align: center;
            line-height: 28px;
            box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);
        }
    </style>
    <h2 style="text-align: center;">Mis Favoritos</h2>

    <asp:Repeater ID="rptFavoritos" runat="server" OnItemCommand="rptFavoritos_ItemCommand">
        <ItemTemplate>
            <div class="carta-libro" style="position: relative;">
                <asp:Button ID="btnQuitarFav" runat="server"
                    CommandName="QuitarFavorito"
                    CommandArgument='<%# Eval("Id") %>'
                    Text="♥"
                    CssClass="btn btn-success btn-sm boton-fav" />

                <div class="imagen-placeholder">
                    <img src='<%# Eval("Imagen") %>' alt="Portada"
                        style="width: 100%; height: 180px; object-fit: cover; border-radius: 6px;" />
                </div>
                <h4 style="font-size: 16px;"><%# Eval("Titulo") %></h4>
                <p style="color: #007bff;"><%# String.Format("${0:N2}", Eval("Precio")) %></p>
                <asp:Button ID="btnVerDetalle" runat="server" CommandName="VerDetalle"
                    CommandArgument='<%# Eval("Id") %>' Text="Ver detalle" CssClass="btn-ver" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
