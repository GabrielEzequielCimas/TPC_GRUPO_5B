<%@ Page Title="Panel Admin" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="TPC_PROG_III.Admin" %>
<asp:Content ID="Administracion" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnAutores" runat="server" Text="Administrar autores" CssClass="btn btn-primary" OnClick="btnAutores_Click"/>
    <asp:Button ID="btnEditoriales" runat="server" Text="Administrar editoriales" CssClass="btn btn-primary" OnClick="btnEditoriales_Click"/>
    <asp:Button ID="btnGeneros" runat="server" Text="Administrar generos" CssClass="btn btn-primary" OnClick="btnGeneros_Click"/>
    <asp:Button ID="btnLibros" runat="server" Text="Administrar libros" CssClass="btn btn-primary" OnClick="btnLibros_Click"/>
    <asp:Button ID="btnVentas" runat="server" Text="Administrar ventas" CssClass="btn btn-primary" OnClick="btnVentas_Click"/>
</asp:Content>
