<%@ Page Title="Inicio Admin" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="TPC_PROG_III.InicioAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bienvenido a la librería online</h2>
    <p>Explorá nuestras novedades y libros destacados.</p>
    <p><a href="/cliente/Catalogo" class="btn btn-primary btn-md">Catalogo &raquo;</a></p>
    <asp:Button ID="btnAdmin" runat="server" Text="Administrador" CssClass="btn btn-primary" OnClick="btnAdmin_Click"/>
</asp:Content>