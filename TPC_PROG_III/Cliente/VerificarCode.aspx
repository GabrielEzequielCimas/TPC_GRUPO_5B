<%@ Page Title="" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="VerificarCode.aspx.cs" Inherits="TPC_PROG_III.Cliente.VerificarCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtCodigo" runat="server" CssClass="ingresar-info" />
    <asp:Button ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" />
</asp:Content>
