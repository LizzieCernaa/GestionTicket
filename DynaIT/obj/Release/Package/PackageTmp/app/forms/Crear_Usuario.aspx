<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear_Usuario.aspx.cs" Inherits="DynaIT.app.forms.Crear_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DynamicsIT</title>
    <link href="../style/Style.css" rel="stylesheet" />
    <script src="../../js/Validacion_JavaScript.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</head>
<body>
    <form id="crearCliente" runat="server">
        <div class="container-fluid" style="margin: 0; padding: 0;">
            <div class="bodycrearcliente">

                  
                <asp:SqlDataSource ID="Grupo_Usuarios_Habilitados" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="SELECT id_area, area FROM Area WHERE (area_Habilitado = 'Si') OR (id_area = '1')"></asp:SqlDataSource>
                <!-- Modal para el boton del crear usuario -->
                <div class="modal fade" id="modal_crear_usuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <asp:ScriptManager ID="Scri" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel" runat="server"> 
                            

                            
                            <ContentTemplate>


                                <div class="modal-content">
                                    <%-----------------%>

                                    <div class="modal-header" style="text-align: center;">
                                        <h5 class="modal-title" id="exampleModalLabel">Crear usuario</h5>
                                        <asp:Label ID="Txt_Id_Usuario" runat="server" Visible="False">id_usuario</asp:Label>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <%-----------------------------------------------------%>
                                        <div class="row">
                                            <div class=" col-12">
                                                <%-- fila de dos columans nombre y correo ususario --%>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:Label class="mr-sm-2" ID="nombreCliente" runat="server" Text="Nombres"></asp:Label>
                                                        <asp:TextBox clss="form-control mb-2 mr-sm-2" ID="Txt_NombreUsuario" runat="server" Height="22px" Style="margin-top: 0px; text-transform:capitalize"></asp:TextBox>
                                                    </div>
                                                    <div class="col">
                                                        <asp:Label class="mr-sm-2" ID="Label3" runat="server" Text="Correo"></asp:Label><br />
                                                        <asp:TextBox class="form-control mb-2 mr-sm-2" type="email" ID="Txt_CorreoUsuario" runat="server" Height="22px" Style="margin-top: 0px"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <hr style="margin: 3px;" />
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:Label class="mr-sm-2" ID="Label4" runat="server" Text="Rol"></asp:Label><br />
                                                        <%--<asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_Cargo" runat="server" Height="22px" Style="margin-top: 0px" ></asp:TextBox>--%>
                                                        <asp:DropDownList ID="List_Rol" runat="server">
                                                            <asp:ListItem Value="1">--Seleccionar--</asp:ListItem>
                                                            <asp:ListItem Value="2">Administrador</asp:ListItem>
                                                            <asp:ListItem Value="3">Agente</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col">
                                                        <div style="margin: auto; align-content: center;">
                                                            <asp:Label class="mr-sm-2" ID="Label6" runat="server" Text="Área"></asp:Label>
                                                          <asp:DropDownList class="form-control mb-2 mr-sm-2" ID="Txt_Grupo" runat="server" AutoPostBack="True" DataSourceID="Grupo_Usuarios_Habilitados" DataTextField="area" DataValueField="id_area" OnSelectedIndexChanged="Txt_Grupo_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="Txt_Fk_Grupo_Usuario" runat="server" Text="Label" Visible="False"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <hr style="margin: 3px;" />
                                                <%-- Fila para el cargo el grupo --%>
                                                <div class="row">
                                                    <div class="col-6">
                                                        <div style="margin: auto; align-content: center;">
                                                            <asp:Label class="mr-sm-2" ID="Label2" runat="server" Text="Usuario"></asp:Label>
                                                            <br />
                                                            <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_Usuario" runat="server" Height="22px" Style="margin-top: 0px; text-transform:uppercase"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-6">
                                                        <div style="margin: auto; text-align: center;">
                                                            <asp:Label class="mr-sm-2" ID="Label1" runat="server" Text="Contraseña"></asp:Label>
                                                            <br />
                                                            <div>
                                                                <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_Contraseña" runat="server" Height="22px" Type="password" Style="margin-top: 0px"></asp:TextBox>
                                                                <asp:Button Text="Generar contraseña" runat="server" ID="Btn_Genera_contra_usuario" OnClick="Btn_Genera_contra_usuario_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- fila para los botones --%>
                                            </div>
                                        </div>
                                        <%---------------------------------------------------------%>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button class="btn btn-primary" ID="Btn_Restablecer" runat="server" Text="Habilitar" Visible="False" OnClick="Btn_Restablecer_Click" />
                                        <asp:Button class="btn btn-primary" ID="Btn_Editar" runat="server" Text="Editar" OnClick="Btn_Editar_Click" Visible="False" />
                                        <asp:Button class="btn btn-primary" ID="Btn_CrearUsuario" runat="server" Text="Crear" OnClick="Btn_CrearUsuario_Click" />
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                    </div>

                                    <%--------------------%>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
        <%--fin del modal--%>
        <div class="row">

            <div class=" col-12">
                <div class="div_titilo_crear_cliente">
                    <div class="TitleForm">
                        <asp:Label ID="lbl_Titulo_Habilitados" runat="server" Text="Lista de usuarios habilitados" Font-Size="X-Large" Visible="True"></asp:Label>
                        <asp:Label ID="lbl_Titulo_Eliminados" runat="server" Text="Lista de usuarios eliminados" Font-Size="X-Large" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col" style="text-align: center;">
                <asp:Button Text="Agregar usuario" class="btn btn-primary" runat="server" ID="btn_agregar_usuario" Style="padding: 5px; font-size: 100%;" OnClick="btn_agregar_usuario_Click" />
                <asp:Button Text="ver deshabilitados" class="btn btn-danger" runat="server" ID="Btn_ver_deshabilitados" Style="padding: 5px; font-size: 100%;" Visible="False" OnClick="Btn_ver_deshabilitados_Click" />
                <asp:Button Text="ver habilitados" class="btn btn-success" runat="server" ID="Btn_ver_habilitados" Style="padding: 5px; font-size: 100%;" Visible="False" OnClick="Btn_ver_habilitados_Click" />
                <asp:Label ID="lbl_habilitado" runat="server" Text="Si" Visible="False"></asp:Label>
            </div>
        </div>
        <%-- tabla de usuario --%>
        <div class="row" style="margin-top: 7px;">
            <div class="col-12">
                <div style="overflow: scroll; align-content: center; height: 75vh; width: 100%; text-align: center">
                    <asp:UpdatePanel runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger  ControlID="Btn_Restablecer"/>        
                        </Triggers>

                        <ContentTemplate>
                                <asp:GridView ID="Grilla_Crear_Usuario" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_usuario" DataSourceID="usuario_habilitado_grupos_habilitados" ForeColor="#333333" GridLines="None" AllowSorting="True" OnRowCommand="Grilla_Crear_Usuario_RowCommand" Width="100%" OnRowDeleted="Grilla_Crear_Usuario_RowDeleted" OnRowDeleting="Grilla_Crear_Usuario_RowDeleting" ValidateRequestMode="Enabled" OnSelectedIndexChanged="Grilla_Crear_Usuario_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" InsertVisible="False" ReadOnly="True" SortExpression="id_usuario" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="nombre_usuario" HeaderText="Nombres" SortExpression="nombre_usuario"></asp:BoundField>
                            <asp:BoundField DataField="correo_usu" HeaderText="Correo" SortExpression="correo_usu"></asp:BoundField>
                            <asp:BoundField DataField="rol" HeaderText="Rol" SortExpression="rol"></asp:BoundField>
                            <asp:BoundField DataField="usuario_Habilitado" HeaderText="usuario_Habilitado" SortExpression="usuario_Habilitado" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area"></asp:BoundField>
                            <asp:BoundField DataField="prefijo_usuario" HeaderText="Usuario" SortExpression="prefijo_usuario"></asp:BoundField>
                             <asp:ButtonField CommandName="Select" Text="Editar" />
                            <asp:ButtonField CommandName="Delete" Text="Eliminar" />
                            
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
                    
                    <asp:SqlDataSource ID="usuario_habilitado_grupos_habilitados" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="SELECT usuario.id_usuario, usuario.nombre_usuario, usuario.correo_usu, rol.rol, usuario.usuario_Habilitado, Area.area, usuario.prefijo_usuario 
					 FROM usuario INNER JOIN area ON usuario.area_id = Area.id_area INNER JOIN rol ON rol.id_rol =usuario.rol_id  
					 WHERE (usuario.Usuario_Habilitado = @Usuario_Habilitado) order by usuario.id_Usuario desc" DeleteCommand="Select * from ticket ">
                       
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lbl_habilitado" Name="Usuario_Habilitado" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                   </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <%-- - --%>
            </div>
        </div>
    </form>
</body>
</html>
