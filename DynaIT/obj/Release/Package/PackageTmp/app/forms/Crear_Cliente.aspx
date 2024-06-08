<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear_Cliente.aspx.cs" Inherits="DynaIT.app.forms.Crear_Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DynamicsIT</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/Style.css" rel="stylesheet" />
    <script src="../../js/Validacion_JavaScript.js"></script>
</head>
<body>
    <form id="crearCliente" runat="server">
    <asp:ScriptManager ID="scripMananer_panel_crear_cliente" runat="server" />
        <div class="container-fluid">
            <div class="bodycrearcliente">
                <!-- Modal para el boton del crearcliente -->
                <div class="modal fade" id="modal_crear_cliente" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <asp:UpdatePanel runat="server" ID="panel_crear_cliente">
                                <ContentTemplate>
                                    <div class="modal-header" style="text-align: center;">
                                        <h5 class="modal-title" id="exampleModalLabel">Crear cliente</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <%-----------------------------------------------------%>
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="TitleForm">
                                                    <h3>Datos del Cliente
                                                        
                                                        <asp:Label ID="Txt_VisualizarTickets" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="Txt_Fk_Empresas" runat="server" Visible="False"></asp:Label>
                                                    </h3>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <div class="row">
                                                    <div class="col-4">
                                                        <asp:Label ID="Lbl_id_cliente" runat="server" Text="Label" Visible="False"></asp:Label>
                                                        <asp:Label ID="Lbl_cargo" runat="server" Text="Lbl_cargo" Visible="False"></asp:Label>
                                                        <asp:Label ID="Lbl_id_empresa" runat="server" Text="Lbl_id_empresa" Visible="False"></asp:Label>
                                                        <asp:Label CssClass="mr-sm-1" ID="Label6" runat="server" Text="Empresa"></asp:Label>
                                                        <asp:DropDownList CssClass="custom-select custom-select-sm" ID="List_Empresa" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre_empresa" DataValueField="id_empresa" AutoPostBack="True" OnSelectedIndexChanged="Txt_Empresa_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-4 ">
                                                        <asp:Label CssClass="mr-sm-3" ID="nombreCliente" runat="server" Text="Nombre completo"></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_NombreCliente" runat="server"  Style="margin-top: 0px; text-transform:capitalize"></asp:TextBox>
                                                    </div>
                                                    <div class="col-4">
                                                        <asp:Label CssClass="mr-sm-2" ID="Label3" runat="server" Text="Correo"></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_CorreoCliente" runat="server"  Style="margin-top: 0px"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="row ">
                                                    <div class="col-4">
                                                        <asp:Label CssClass="mr-sm-2" ID="Label4" runat="server" Text="Telefono"></asp:Label>
                                                        <asp:TextBox CssClass="form-control mb-2 mr-sm-2" ID="Txt_TelefonoCliente" runat="server"  Style="margin-top: 0px"></asp:TextBox>
                                                    </div>
                                                    <div class="col-8">
                                                        <asp:Label CssClass="mr-sm-2" ID="Label2" runat="server" Text="Contraseña Temporal"></asp:Label>
                                                        <div style="align-content: flex-end; display: flex;">
                                                            <asp:TextBox CssClass="form-control mb-2 mr-sm-2" ID="Txt_Contraseña" runat="server" type="password" Style="margin-top: 0px"></asp:TextBox>
                                                            <asp:Button Text="Generar contraseña" runat="server" Font-Size="XX-Small" OnClick="Unnamed1_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="Label7" runat="server" Text="Permitir visualizar todos los tickets de la compañia (Para clientes administradores?)"></asp:Label><br />
                                                <asp:CheckBox ID="Check_VisualizarTickets" runat="server" AutoPostBack="True" OnCheckedChanged="Check_VisualizarTickets_CheckedChanged" />
                                            </div>
                                        </div>
                                    
                                        <%---------------------------------------------------------%>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button class="btn btn-primary" ID="Btn_Editar" runat="server" Text="Editar" OnClick="Btn_Editar_Click" Visible="False" />
                                                    <asp:Button class="btn btn-primary" ID="BtnCrearCliente" runat="server" Text="Crear" OnClick="BtnCrearCliente_Click" />
                                                    <%--<asp:Button class="btn btn-danger" ID="Btn_Cancelar" runat="server" Text="Cancelar" OnClick="Btn_Cancelar_Click" />--%>
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    </div>
                                </ContentTemplate>
                               <%--<Triggers>
      <asp:PostBackTrigger ControlID="Grilla_Cliente" /> 
     </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--fin del modal--%>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="SELECT id_Empresa, Nombre_Empresa FROM empresa WHERE (id_Empresa = 1) OR (Empresa_Habilitada = 'Si')"></asp:SqlDataSource>
                <div class="row">
                    <div class=" col-12">
                        <div class="div_titilo_crear_cliente">
                            <div class="TitleForm">
                                <asp:Label ID="Lbl_Ver_Eliminados" runat="server" Text="Si" Visible="False"></asp:Label>
                                <asp:Label ID="Txt_Titulo_Habilitados" runat="server" Text="Lista de clientes habilitados" Font-Size="X-Large" Visible="True"></asp:Label>
                                <asp:Label ID="Txt_Titulo_Eliminados" runat="server" Text="Lista de clientes eliminados" Font-Size="X-Large" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin: 10px;">
                    <div class="col" style="text-align:center;">
                        <asp:Button Text="Agregar cliente" class="btn btn-primary" runat="server" ID="btn_agregar_cliente" OnClick="btn_agregar_cliente_Click"  Style="padding: 5px; font-size: 100%;" />
                        <asp:Button Text="ver deshabilitados" class="btn btn-danger" runat="server" ID="Btn_ver_deshabilitados" Style="padding: 5px; font-size: 100%;" OnClick="Btn_ver_eliminados_Click" Visible="False" />
                        <asp:Button Text="ver habilitados" class="btn btn-success" runat="server" ID="Btn_ver_habilitados" Style="padding: 5px; font-size: 100%;" OnClick="Btn_ver_habilitados_Click" Visible="False" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="row">
                            <%----------------------------Grilla de clientes ------------------------------------------%>
                            <div class="col-12">
                                <div style="overflow: scroll; align-content: center; height: 80vh; width: 100%; text-align: center">
                                    <asp:UpdatePanel runat="server">
                                        
                                        <ContentTemplate>
                                             <asp:GridView ID="Grilla_Cliente" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_Cliente" DataSourceID="Tabla_Clientes" ForeColor="#333333" GridLines="None" OnRowCommand="Grilla_Cliente_RowCommand" Width="100%" AllowSorting="True">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="id_Cliente" HeaderText="id_Cliente" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="id_Cliente" />
                                            <asp:BoundField DataField="Nombre_Cliente" HeaderText="Nombre" SortExpression="nombre_cliente"/>
                                            <asp:BoundField DataField="Telefono_cliente" HeaderText="Telefono" SortExpression="Telefono_cliente" />
                                            <asp:BoundField DataField="correo_cli" HeaderText="correo" SortExpression="correo_cli" />
                                            <asp:BoundField DataField="rol" HeaderText="rol" SortExpression="rol" />
                                            <asp:BoundField DataField="nombre_empresa" HeaderText="Empresa" SortExpression="nombre_empresa" />
                                            <asp:ButtonField CommandName="Select" Text="Editar" />
                                            <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
                                            <asp:ButtonField CommandName="Restaurar" Text="Habilitar" Visible="False" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="Tabla_Clientes" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="SELECT cliente.id_Cliente, cliente.nombre_cliente, cliente.Telefono_cliente, cliente.correo_cli, rol.rol, empresa.nombre_empresa FROM cliente INNER JOIN empresa ON cliente.empresa_id = empresa.id_Empresa inner join rol on rol.id_rol = cliente.rol_id WHERE (cliente.Cliente_Habilitado = @Cliente_Habilitado) order by cliente.id_Cliente desc" DeleteCommand="UPDATE cliente SET Cliente_Habilitado = 'No' WHERE (id_Cliente = @idCliente)">
                                        <DeleteParameters>
                                            <asp:Parameter Name="idCliente" />
                                        </DeleteParameters>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="Lbl_Ver_Eliminados" Name="Cliente_Habilitado" PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
