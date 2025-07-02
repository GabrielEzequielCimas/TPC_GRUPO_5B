<%@ Page Title="Finalizar Compra" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="TPC_PROG_III.Cliente.FinalizarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Finalizar Compra</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />

    <div class="form-group">
        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtNombre" ErrorMessage="Ingrese su nombre" Display="Dynamic" CssClass="text-danger" runat="server" />
    </div>

    <div class="form-group">
        <label>Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtApellido" ErrorMessage="Ingrese su apellido" Display="Dynamic" CssClass="text-danger" runat="server" />
    </div>

    <div class="form-group">
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtEmail" ErrorMessage="Ingrese su email" Display="Dynamic" CssClass="text-danger" runat="server" />
    </div>

    <h4>Dirección de Envío</h4>

    <div class="form-group">
        <label>Calle</label>
        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtCalle" ErrorMessage="Ingrese la calle" Display="Dynamic" CssClass="text-danger" runat="server" />
    </div>

    <div class="form-group">
        <label>Número</label>
        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtNumero" ErrorMessage="Ingrese el número" Display="Dynamic" CssClass="text-danger" runat="server" />
    </div>

    <div class="form-group">
        <label>Localidad</label>
        <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtLocalidad" ErrorMessage="Ingrese la localidad" Display="Dynamic" CssClass="text-danger" runat="server" />
    </div>

    <div class="form-group">
        <label>Provincia</label>
        <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ControlToValidate="txtProvincia" ErrorMessage="Ingrese la provincia" Display="Dynamic" CssClass="text-danger" runat="server" />
    </div>

    <h4>Método de Pago</h4>
    <asp:DropDownList ID="ddlPago" runat="server" CssClass="form-control">
        <asp:ListItem Text="Seleccione un método de pago" Value="" />
        <asp:ListItem Text="Tarjeta de crédito" Value="Tarjeta" />
        <asp:ListItem Text="Transferencia bancaria" Value="Transferencia" />
        <asp:ListItem Text="Pago contra entrega" Value="ContraEntrega" />
    </asp:DropDownList>
    <asp:RequiredFieldValidator ControlToValidate="ddlPago" InitialValue="" ErrorMessage="Seleccione un método de pago" Display="Dynamic" CssClass="text-danger" runat="server" />

    <div class="form-group mt-3">
        <asp:CheckBox ID="chkTerminos" runat="server" />
        <label for="chkTerminos">Acepto los términos y condiciones</label>
        <asp:CustomValidator ID="cvTerminos" runat="server" ClientValidationFunction="validarTerminos" ErrorMessage="Debe aceptar los términos y condiciones" Display="Dynamic" CssClass="text-danger" />
    </div>

    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Compra" CssClass="btn btn-success" OnClick="btnConfirmar_Click" />
    
    <script>
    function validarTerminos(sender, args) {
        args.IsValid = document.getElementById('<%= chkTerminos.ClientID %>').checked;
    }
    </script>
</asp:Content>
