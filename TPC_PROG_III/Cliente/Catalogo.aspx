<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_PROG_III.Catalogo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center my-4">Catalogo</h2>
    <div class="row justify-content-center">
        <asp:Repeater ID="rptLibros" runat="server" OnItemCommand="rptLibros_ItemCommand">
            <ItemTemplate>
                <div class="col-md-4 d-flex justify-content-center mb-4">
                    <asp:LinkButton ID="btnDetalle" runat="server" CommandName="VerDetalle"
                        CommandArgument='<%# Eval("Id") %>' CssClass="card p-0" Style="width: 18rem;">
                        <asp:Image ID="imgArticulo" runat="server" CssClass="card-img-top"
                            ImageUrl='<%# Eval("Imagen.Url") %>' AlternateText="Imagen"
                            Style="height: 200px; width: 100%; object-fit: contain; background-color: #f8f9fa;" />
                        <div class="card-body text-center">
                            <h5 class="card-title"><%# Eval("Titulo") %></h5>
                            <p class="card-text"><%# "$" + String.Format("{0:0.00}", Eval("Precio")) %></p>
                        </div>
                    </asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
