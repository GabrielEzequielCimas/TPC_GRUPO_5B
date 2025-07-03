<%@ Page Title="Finalizar Compra" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="TPC_PROG_III.Cliente.FinalizarCompra" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Finalizar Compra</h2>

    <asp:Panel runat="server" ID="pnlFormulario">

        <h4>Datos del Comprador</h4>
        <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control" />
        <asp:TextBox ID="txtApellido" runat="server" Placeholder="Apellido" CssClass="form-control" />
        <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control" />
        <asp:TextBox ID="txtDocumento" runat="server" Placeholder="Documento" CssClass="form-control" />

        <h4>Dirección de Envío</h4>
        <asp:TextBox ID="txtDireccion" runat="server" Placeholder="Dirección" CssClass="form-control" />

        <h4>Método de Pago</h4>
        <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccionar..." Value="" />
            <asp:ListItem Text="Tarjeta de Crédito" Value="Tarjeta" />
            <asp:ListItem Text="Transferencia Bancaria" Value="Transferencia" />
            <asp:ListItem Text="Efectivo en punto de retiro" Value="Efectivo" />
        </asp:DropDownList>

        <asp:CheckBox ID="chkTerminos" runat="server" Text="Acepto los Términos y Condiciones" />

        <br />
        <asp:Button ID="btnFinalizar" runat="server" Text="Confirmar Compra" OnClick="btnFinalizar_Click" CssClass="btn btn-success" />
    </asp:Panel>

    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
</asp:Content>
