<%@ Page Title="Administrar Ventas" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="AdminVentas.aspx.cs" Inherits="TPC_PROG_III.AdminVentas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Administrar Ventas</h2>

    <asp:GridView ID="dgvVentas" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged" CssClass="table table-hover" SelectedRowStyle-BackColor="#D3D3D3">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Venta" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:BoundField DataField="NumeroFactura" HeaderText="Factura" />
            <asp:BoundField DataField="Cliente.Nombre" HeaderText="Cliente" />
            <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Cliente.Email" HeaderText="Email" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select">Ver Detalle</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <h4>Detalle de la venta seleccionada</h4>
    <asp:GridView ID="dgvDetalle" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="Libro.Titulo" HeaderText="Libro" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
</asp:Content>
