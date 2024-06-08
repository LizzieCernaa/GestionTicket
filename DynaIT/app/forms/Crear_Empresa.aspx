<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear_Empresa.aspx.cs" Inherits="DynaIT.app.forms.Crear_Empresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DynamicsIT</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <link href="../style/Style.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/Botones.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin: 0; padding: 0;">

                <!-- Modal para el boton del crear empresa -->
                <div class="modal fade" id="modal_crear_empresa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <asp:ScriptManager ID="scripMananer_panel_crear_cliente" runat="server" />
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="modal-header" style="text-align: center;">
                                        <h5 class="modal-title" id="exampleModalLabel">Crear empresa</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <%-----------------------------------------------------%>
                                        <div class="row">
                                            <div class=" col-12" style="height: 30vh">
                                                <%-- fila del titulo --%>
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="TitleForm">
                                                            <h3>Datos de la empresa</h3>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--  Fila de nit y telefono--%>
                                                <div class="row">

                                                    <div class="col-6">
                                                        <asp:Label ID="Lbl_id_Empresa" runat="server" Text="Lbl_Id_empresa" Visible="False"></asp:Label>
                                                        <asp:Label class="mr-sm-2" ID="Label6" runat="server" Text="Nit"></asp:Label>
                                                        <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_Nit" runat="server" Height="22px" Style="margin-top: 0px"></asp:TextBox>
                                                    </div>
                                                    <div class="col-6">
                                                        <asp:Label class="" ID="Label2" runat="server" Text="Nombre de la Empresa"></asp:Label>
                                                        <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_Empresa" runat="server" Height="22px" Style="margin-top: 0px"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-6">
                                                        <asp:Label class="mr-sm-2" ID="Label4" runat="server" Text="Telefono"></asp:Label>
                                                        <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_TelefonoEmpresa" runat="server" Height="22px" Style="margin-top: 0px"></asp:TextBox>
                                                    </div>
                                                    <div class="col-6">
                                                        <asp:Label class="mr-sm-2" ID="Label1" runat="server" Text="Representante"></asp:Label>
                                                        <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_representante" runat="server" Height="22px" Style="margin-top: 0px"></asp:TextBox>
                                                    </div>
                                                </div>
                                              
                                            </div>
                                        </div>
                                        <%---------------------------------------------------------%>
                                    </div>
                                    <div class="modal-footer" style="text-align:center;">
                                        <asp:Button class="btn btn-primary" ID="Btn_CrearCliente" runat="server" Text="Crear" OnClick="Btn_CrearCliente_Click" />
                                        <asp:Button class="btn btn-primary" ID="btn_editar" Text="Editar" runat="server" OnClick="btn_editar_Click" Visible="false" />
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
      <asp:PostBackTrigger ControlID="Grilla_crear_empresa" /> 
     </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--fin del modal--%>



                <div class="">
                    <div class=" col-12" style="background-color:#727272">
                        <div class="">
                        <div class="TitleForm" style="padding-bottom:20px">

                            <asp:Label ID="Lbl_Ver_Eliminados" runat="server" Text="Si" Visible="False"></asp:Label><br />
                            <asp:Label ID="Lbl_Titulo_Eliminados" runat="server" Text="Lista de empresas deshabilitadas" Font-Size="Large" Visible="False" ForeColor="White"></asp:Label>
                            <asp:Label ID="Lbl_Titulo_Habilitados" runat="server" Text="Lista de empresas habilitadas" Font-Size="Large" ForeColor="White"></asp:Label>
                        </div>
                         </div>
                    </div>
                </div>

                <div class="row" style="margin: 10px;">
                    <div class="col" style="text-align:center;">
                        <div>
                        <asp:Button Text="Agregar empresa" class="btn-agregarempresa" runat="server" ID="btn_agregar_empresa" Style="padding: 4px; font-size: 12px;" OnClick="btn_agregar_empresa_Click" />
                        
                            <asp:Button Text="Ver deshabilitada" class="btn-verdeshabilitados" runat="server" ID="btn_ver_empresa_deshabilitada" Style="padding: 4px; " OnClick="btn_ver_empresa_deshabilitada_Click" Visible="False" Font-Size="12px" />
                        <asp:Button Text="Ver habilitada" class="btn-verhabilitados" runat="server" ID="btn_ver_empresa_habilitada" Style="padding: 4px; " OnClick="btn_ver_empresa_habilitada_Click" Visible="False" Font-Size="12px"   />
                            </div>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-12">
                        <div style="overflow: scroll; align-content: center; height: 70vh; width: 100%; text-align: center">
                            <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger controlid="Btn_CrearCliente"/>
                                        </Triggers>
                                        <ContentTemplate>
                            <asp:GridView ID="Grilla_crear_empresa" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="id_Empresa" DataSourceID="empresas" GridLines="None" CellPadding="4" HorizontalAlign="Left" ForeColor="#000000" PageSize="7" Width="100%" OnRowCommand="Grilla_crear_empresa_RowCommand" OnRowDeleting="Grilla_crear_empresa_RowDeleting">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="id_empresa" HeaderText="ID Empresas" SortExpression="id_Empresa" Visible="False">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre_empresa" HeaderText="Empresa" SortExpression="Nombre_Empresa">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nit" HeaderText="Nit" SortExpression="Nit">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="telefono_empresa" HeaderText="Telefono" SortExpression="Telefono">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="representante_empresa" HeaderText="Representante " SortExpression="Representante_empresa">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:ButtonField CommandName="Editar" Text="Editar" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('Esta seguro de eliminar el registro?'); "></asp:LinkButton>
                                        </ItemTemplate>
                                        <ControlStyle ForeColor="Black" />
                                    </asp:TemplateField>
                                    <asp:ButtonField CommandName="Habilitar" Text="Restaurar" Visible="False" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#424C52" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#727272" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="empresas" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT * FROM empresa where Empresa_Habilitada = @Empresa_Habilitada order by empresa.id_Empresa desc" DeleteCommand="SELECT * FROM empresa" UpdateCommand="UPDATE empresa SET nombre_empresa = @Nombre_Empresa, nit= @Nit, telefono_empresa = @Telefono, representante_empresa= @Representante_empresa WHERE (id_empresa = @id_Empresas)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="Lbl_Ver_Eliminados" Name="Empresa_Habilitada" PropertyName="Text" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Nombre_Empresa" />
                                    <asp:Parameter Name="Nit" />
                                    <asp:Parameter Name="Telefono" />
                                    <asp:Parameter Name="Representante_empresa" />
                                    <asp:Parameter Name="id_Empresa" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                                            </ContentTemplate>
                                </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>