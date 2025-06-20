<%@ Page Title="Administrar Generos" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="AdminGeneros.aspx.cs" Inherits="TPC_PROG_III.AdminGeneros" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Administrar Generos</h2>
    <div class="d-flex mb-3">
        <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" CssClass="form-control me-2" placeholder="Buscar" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
    </div>

    <div class="d-flex mb-3">
        <asp:TextBox ID="txtModificar" runat="server" CssClass="form-control me-2" placeholder="Modificar genero" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click"  />
    </div>

    <div class="d-flex mb-3">
        <asp:TextBox ID="txtAgregar" runat="server" CssClass="form-control me-2" placeholder="Nuevo genero" />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
    </div>
    <asp:Button ID="btnEliminar" runat="server" Text="Desactivar" CssClass="btn btn-primary" OnClick="btnDesactivar_Click"/>
    <asp:Button ID="btnActivar" runat="server" Text="Activar" CssClass="btn btn-primary" OnClick="btnActivar_Click"/>

    <asp:GridView ID="dgvGenero" runat="server" AutoGenerateColumns="False"
        OnSelectedIndexChanged="dgvGenero_SelectedIndexChanged"
        OnRowDataBound="dgvGenero_RowDataBound"
        SelectedRowStyle-BackColor="#D3D3D3"
        CssClass="table table-hover">

        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="DescripcionGenero" HeaderText="Descripción" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Style="display: none;"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
