<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear_Grupo_Usuario.aspx.cs" Inherits="DynaIT.app.forms.Crear_Grupo_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DynamicsIT</title>
    <script src="../js/Validacion_JavaScript.js"></script>
    <link href="../style/Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/Botones.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="">
                <!-- Modal para el boton del crearcliente -->
                <div class="modal fade" id="modal_crear_grupo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <asp:ScriptManager ID="scripMananer_panel_crear_grupo" runat="server" />
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="modal-header" style="text-align: center;">
                                        <h5 class="modal-title" id="exampleModalLabel">Crear área</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <%-----------------------------------------------------%>
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="formularioCreacion">
                                                            <div style="width: 50%;">
                                                                <asp:Label ID="Label1" runat="server" Text="Nueva área"></asp:Label>
                                                                <asp:TextBox CssClass="form-control mb-2" ID="Txt_Grupo_usuario" runat="server" OnTextChanged="Txt_Grupo_usuario_TextChanged"></asp:TextBox>
                                                                <asp:Label ID="Txt_Recuperar_Grupo" runat="server" Visible="False" >Si</asp:Label>
                                                                <asp:Label ID="Txt_Id_Grupos_usuarios" runat="server" Text="Label" Visible="False"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%---------------------------------------------------------%>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button class="btn btn-primary" ID="Btn_Recuperar_campo" runat="server" Text="Habilitar" OnClick="Btn_Recuperar_Grupo_Usuario" Visible="False" />
                                        <asp:Button class="btn btn-primary" ID="Btn_Editar_grupo_Usuario" runat="server" Text="Editar" OnClick="Btn_Editar_Grupo_Usuario" Visible="False" />
                                        <asp:Button class="btn btn-primary" ID="Btn_Crear_Grupo_Usuario" runat="server" Text="Crear" OnClick="Btn_Crear_Grupo_usuario" />
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="Grilla_Grupo_usuario" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--fin del modal--%>
                <div class="row" >
                    <div class=" col-12" style="background-color:#727272">
                        <div class="div_titilo_crear_cliente">
                            <div style="text-align: center; padding-bottom:10px; width:100%">
                                <asp:Label ID="Txt_Grupos_Habilitados" runat="server" Text="Si" Visible="False"></asp:Label>
                                <asp:Label ID="Txt_Titulo_Eliminados" runat="server" Text="ÁREAS ELIMINADAS" Font-Size="Large" Visible="False" ForeColor="White"></asp:Label>
                                <asp:Label ID="Txt_Titulo_Habilitados" runat="server" Text="ÁREAS CREADAS" Font-Size="Large" ForeColor="White"></asp:Label>
                                <asp:Label ID="Lbl_id_grupo_habilita" runat="server" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="row">
                            <div class="col-12">
                                <div class="" style="margin-top: 10px; text-align: center;">
                                    <asp:Button Text="Agregar Área" runat="server" class="btn-agregarempresa" OnClick="btn_agregar_grupo_Click" ID="btn_agregar_grupo" Style="padding: 5px; font-size: 12px;" Font-Size="Smaller" />
                                    <asp:Button Text="ver deshabilitados" class="btn-verdeshabilitados" runat="server" ID="Btn_ver_deshabilitados" Style="padding: 5px; font-size: 11px;" Visible="False" OnClick="Btn_ver_deshabilitados_Click" Font-Size="Smaller" />
                                    <asp:Button Text="ver habilitados" class="btn-verhabilitados" runat="server" ID="Btn_ver_habilitados" Style="padding: 5px; font-size: 11px;" Visible="False" OnClick="Btn_ver_habilitados_Click" Font-Size="Smaller" />

                                </div>

                            </div>
                        </div>

                        <div class="row">

                            <div class="col-12">
                                <div class="GrillaInferior" style="width: 100%; text-align: center; justify-content: center; display: flex;">
                                    <div class="table-responsive" style="width: 70%; margin-top: 50px;">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Grilla_Grupo_usuario" runat="server" AutoGenerateColumns="False" DataKeyNames="id_area" DataSourceID="grupoUsuarios" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="6" Width="100%" OnRowCommand="Grilla_Grupo_usuario_RowCommand" OnRowDeleting="Grilla_Grupo_usuario_RowDeleting">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="id_area" HeaderText="id_area_usuario" InsertVisible="False" SortExpression="id_area_usuario" Visible="False" />
                                                        <asp:BoundField DataField="area" HeaderText="Áreas" SortExpression="area_usuario">
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:ButtonField CommandName="Select" Text="Editar">
                                                            <FooterStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:ButtonField>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" ForeColor="Black"></asp:LinkButton>

                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#424C52" BorderStyle="None" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    <PagerStyle BackColor="#3399FF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" BorderStyle="None" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>



                                                <asp:SqlDataSource ID="grupoUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT id_area, area FROM area WHERE (area_Habilitado = @area_Habilitado)" UpdateCommand="UPDATE area SET area = @area_usuario WHERE id_area = @id_area_usuario" DeleteCommand="SELECT * FROM area">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="Txt_Grupos_Habilitados" Name="area_Habilitado" PropertyName="Text" />
                                                    </SelectParameters>
                                                    <UpdateParameters>
                                                        <asp:Parameter Name="area" />
                                                        <asp:Parameter Name="id_area" />
                                                    </UpdateParameters>
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
        </div>

    </form>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js "> </script>
</body>
</html>