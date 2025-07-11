<%@ Page Title="" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="UpdateDatosCliente.aspx.cs" Inherits="TPC_PROG_III.UpdateDatosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Modificar Datos</h2>

    <asp:Panel runat="server" ID="pnlEditarDatos">
        <asp:Label Text="Nombre" AssociatedControlID="txtNombre" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />

        <asp:Label Text="Apellido" AssociatedControlID="txtApellido" runat="server" />
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />

        <asp:Label Text="Documento" AssociatedControlID="txtDocumento" runat="server" />
        <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" />

        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    </asp:Panel>

    <asp:Label ID="lblMensaje" runat="server" CssClass="text-success" />
</asp:Content>
