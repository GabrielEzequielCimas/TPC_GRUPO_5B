<%@ Page Title="Administrar Libros" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="AdminLibros.aspx.cs" Inherits="TPC_PROG_III.AdminLibros" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Administrar Libros</h2>
    <asp:GridView ID="dgvLibro" runat="server" AutoGenerateColumns="False"
    OnSelectedIndexChanged="dgvLibro_SelectedIndexChanged"
    OnRowDataBound="dgvLibro_RowDataBound"
    SelectedRowStyle-BackColor="#D3D3D3"
    CssClass="table table-hover">

    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" />
        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
        <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
        <asp:BoundField DataField="Editorial.Descripcion" HeaderText="Editorial" />
        <asp:BoundField DataField="Paginas" HeaderText="Paginas" />
        <asp:BoundField DataField="Stock" HeaderText="Stock" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Style="display: none;"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
