<%@ Page Title="" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="VerificarCode.aspx.cs" Inherits="TPC_PROG_III.Cliente.VerificarCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Se ha enviado un código al correo, ingrese para validar:</h3>
    <div class="mb-3">
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Placeholder="Ingrese el código" />
    </div>

    <asp:Button ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" CssClass="btn btn-primary" />

</asp:Content>
