<%@ Page Title="" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="UpdateDirecciones.aspx.cs" Inherits="TPC_PROG_III.UpdateDirecciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Modificar Dirección</h2>

    <asp:Panel ID="pnlEdicion" runat="server">
        <div class="form-group">
            <label>Provincia:</label>
            <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Localidad:</label>
            <asp:DropDownList ID="ddlLocalidades" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <asp:HiddenField ID="hfIdDireccion" runat="server" />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
    </asp:Panel>
</asp:Content>
