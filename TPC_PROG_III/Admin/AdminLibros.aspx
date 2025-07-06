<%@ Page Title="Administrar Libros" Language="C#" MasterPageFile="~/Compartido/Site.Master" AutoEventWireup="true" CodeBehind="AdminLibros.aspx.cs" Inherits="TPC_PROG_III.AdminLibros" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Script para abrir el popup --%>
    <script type="text/javascript">
        function abrirModalLibro() {
            var myModal = new bootstrap.Modal(document.getElementById('modalLibro'));
            myModal.show();
        }
    </script>
    <%--    ---------------------------------------buscar---------------------------------- --%>
    <h2>Administrar Libros</h2>

    <div class="row mb-4 justify-content-center">
        <div class="col-md-6 d-flex">
            <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="true" CssClass="form-control me-2" placeholder="Buscar" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
        </div>
    </div>
    <%--    ------------------------------------------------------------------------- --%>
    <!-- Popup -->
    <div class="modal fade" id="modalLibro" tabindex="-1" aria-labelledby="modalLibroLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLibroLabel"></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>

                <div class="modal-body">

                    <!-- Código y Título -->
                    <div class="row mb-3">
                        <div class="col-6 px-1">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Código" />
                        </div>
                        <div class="col-6 px-1">
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Título" />
                        </div>
                    </div>

                    <!-- Descripción -->
                    <div class="row mb-3">
                        <div class="form-label">
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Descripción" />
                        </div>
                    </div>

                    <!-- URL Imagen -->
                    <div class="row mb-3">
                        <div class="col-12">
                            <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control" placeholder="URL Imagen" />
                        </div>
                    </div>

                    <!-- Páginas, Precio, Stock -->
                    <div class="row mb-3">
                        <div class="col-4 px-1">
                            <asp:TextBox ID="txtPaginas" runat="server" CssClass="form-control" placeholder="Páginas" />
                        </div>
                        <div class="col-4 px-1">
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Precio" />
                        </div>
                        <div class="col-4 px-1">
                            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Stock" />
                        </div>
                    </div>

                    <!-- Editorial, Género, Subgénero -->
                    <div class="row mb-3">
                        <div class="col-4 px-1">
                            <asp:DropDownList ID="ddlEditoriales" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-4 px-1">
                            <asp:DropDownList ID="ddlGeneros" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGeneros_SelectedIndexChanged" />
                        </div>
                        <div class="col-4 px-1">
                            <asp:DropDownList ID="ddlSubGeneros" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubGeneros_SelectedIndexChanged" />
                        </div>
                    </div>

                    <!-- Autores -->
                    <div class="row mb-3">
                        <div class="col-12">
                            <label class="form-label">Seleccione Autor/es:</label>
                            <div style="height: 200px; overflow-y: auto; border: 1px solid #ccc; padding: 5px;">
                                <asp:CheckBoxList
                                    ID="chkAutores"
                                    runat="server"
                                    CssClass="form-check"
                                    RepeatLayout="Flow"
                                    RepeatDirection="Vertical" />
                            </div>
                        </div>
                    </div>

                    <!-- mensaje de rror -->
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger d-block mt-2" Visible="false" />

                </div>

                <div class="modal-footer">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- fin popup--------------------------------------------- -->
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    <asp:Button ID="btnEstado" runat="server" Text="Cambiar Estado" CssClass="btn btn-primary" OnClick="btnEstado_Click" />
    <%--<asp:Button ID="btnEliminar" runat="server" Text="Desactivar" CssClass="btn btn-primary" OnClick="btnDesactivar_Click" />
    <asp:Button ID="btnActivar" runat="server" Text="Activar" CssClass="btn btn-primary" OnClick="btnActivar_Click" />--%>

    <%-- DGV-------------------------------------------- --%>
    <asp:GridView ID="dgvLibro" runat="server" AutoGenerateColumns="False"
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
    <%-- ------------------------------------------------ --%>
</asp:Content>
