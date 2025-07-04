<%@ Page Title="Administrar Libros" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="AdminLibros.aspx.cs" Inherits="TPC_PROG_III.AdminLibros" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Administrar Libros</h2>
    <div class="row mb-4 justify-content-center">
        <div class="col-md-6 d-flex">
            <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Buscar" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
        </div>
    </div>
    <asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Codigo" />
    <asp:TextBox ID="txtTitulo" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Titulo" />
    <asp:TextBox ID="txtDescripcion" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Descripcion" />
    <asp:TextBox ID="txtUrl" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="URL Imagen" />
    <asp:TextBox ID="txtPaginas" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Paginas" />
    <asp:TextBox ID="txtPrecio" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Precio" />
    <asp:TextBox ID="txtStock" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Stock" />
    <div class="row mb-3">
        <div class="col-md-4">
            <asp:DropDownList ID="ddlEditoriales" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlGeneros" runat="server" CssClass="form-control"
                AutoPostBack="true" OnSelectedIndexChanged="ddlGeneros_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlSubGeneros" runat="server" CssClass="form-control"
                AutoPostBack="true" OnSelectedIndexChanged="ddlSubGeneros_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <%--<asp:DropDownList ID="ddlCheckList" runat="server" CssClass="form-control" multiple="multiple"></asp:DropDownList>--%>
    <p>Seleccione Autor/es:</p>
    <div style="height: 200px; overflow-y: auto; border: 1px solid #ccc; padding: 5px;">
        <asp:CheckBoxList
            ID="chkAutores"
            runat="server"
            CssClass="form-check"
            RepeatLayout="Flow"
            RepeatDirection="Vertical">
        </asp:CheckBoxList>
    </div>
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Desactivar" CssClass="btn btn-primary" OnClick="btnDesactivar_Click" />
    <asp:Button ID="btnActivar" runat="server" Text="Activar" CssClass="btn btn-primary" OnClick="btnActivar_Click" />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false" />
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
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <%--<asp:BoundField DataField="Editorial.Descripcion" HeaderText="Editorial" />--%>
            <%--<asp:BoundField DataField="Genero.Descripcion" HeaderText="Descripcion" />--%>
            <%--<asp:BoundField DataField="Paginas" HeaderText="Paginas" />--%>
            <%--            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Style="display: none;"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
