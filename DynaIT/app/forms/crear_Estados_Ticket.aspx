<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crear_Estados_Ticket.aspx.cs" Inherits="DynaIT.app.forms.crear_Estados_Ticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Estados de tickets</title>
    <link href="../style/Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/Botones.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="padding: 0; height: 95vh">
            <div class="contenidoFormulariosCreacion">
                <!-- Modal para el boton del crearcliente -->
                <div class="modal fade" id="modal_crear_estado" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <asp:ScriptManager ID="scripMananer_panel_crear_cliente" runat="server" />
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="modal-header" style="text-align: center;">
                                        <div class="TitleForm">
                                            <h4>Crear estados de tickets</h4>
                                        </div>
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
                                                                <asp:Label ID="Label1" runat="server" Text="Estados de tickets"></asp:Label>
                                                                <asp:TextBox class="form-control mb-2" ID="Txt_EstadosTicket" runat="server"></asp:TextBox>

                                                                <asp:Label ID="Lbl_Recuperar" runat="server" Text="No" Visible="False"></asp:Label>


                                                                <asp:Label ID="Txt_id_estados_ticket" runat="server" Text="Id_primaria" Visible="False"></asp:Label>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>


                                        <%---------------------------------------------------------%>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button class="btn btn-primary" ID="Btn_recuperar_Estados" runat="server" Text="Habilitar" OnClick="Btn_recuperar_Estados_Click" Visible="False" />
                                        <asp:Button class="btn btn-primary" ID="Btn_Editar_Estados" runat="server" Text="Editar" OnClick="Btn_Editar_Click" Visible="False" />
                                        <asp:Button class="btn btn-primary" ID="Btn_Crear_Estado_Ticket" runat="server" Text="Crear" OnClick="Btn_Crear_Estado_Ticket_Click" />
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
      <asp:PostBackTrigger ControlID="Grilla_Estados_Ticket" /> 
     </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--fin del modal--%>



                        <div class="row">
                            <div class="col-12">
                                <div class="row" style="background-color:#727272; text-align: center;">
                                    <div class="col-12" >
                                        <div class="div_titilo_crear_cliente" style="text-align: center;">
                                            <asp:Label ID="Lbl_Titulo_Todos_Creados" runat="server" Text="Estados creados" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
                                            <asp:Label ID="Lbl_Titulo_Eliminados" runat="server" Text="Estados eliminados" Visible="False" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="margin: 20px;">

                                    <div class="col" style="text-align: center;">
                                        <asp:Label ID="Lbl_Ver_Eliminados" runat="server" Text="Si" Visible="False"></asp:Label>
                                        <asp:Button Text="Agregar estado" class="btn-agregarempresa" runat="server" ID="btn_agregar_estado" OnClick="btn_agregar_estado_Click" />
                                        <asp:Button Text="ver deshabilitados" class="btn-verdeshabilitados" runat="server" ID="Btn_ver_deshabilitados" Style="padding: 5px; font-size: 12px;" Visible="False" OnClick="Btn_ver_deshabilitados_Click" />
                                        <asp:Button Text="ver habilitados" class="btn-verhabilitados" runat="server" ID="Btn_ver_habilitados" Style="padding: 5px; font-size: 12px;" Visible="False" OnClick="Btn_ver_habilitados_Click" />
                                    </div>
                                </div>
                                <div class="row" style="margin: 30px;">
                                    <div class="col-12">
                                        <div class="GrillaInferior" style="width: 100%; text-align: center; justify-content: center; display: flex; ">
                                            <div style="width: 70%">
                                                <asp:UpdatePanel runat="server" ID="panel_tabla_estados"> 
                                                    
                                                    <ContentTemplate>
                                                      <asp:GridView ID="Grilla_Estados_Ticket" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="id_Estado_Ticket" DataSourceID="estados_Ticket" AllowSorting="True" CellPadding="4" ForeColor="#000000" GridLines="None" PageSize="6" OnRowCommand="Grilla_Estados_Ticket_RowCommand" HorizontalAlign="Center" OnRowDeleting="Grilla_Estados_Ticket_RowDeleting">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="id_Estado_Ticket" HeaderText="N Estado" InsertVisible="False" ReadOnly="True" SortExpression="id_Estado_Ticket" />
                                                        <asp:BoundField DataField="estado_Ticket" HeaderText="Estados de Tickets" SortExpression="estado_Ticket">
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:ButtonField CommandName="Select" Text="Editar">
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:ButtonField>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1"  runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('Esta seguro de eliminar el registro?'); " ForeColor="Black"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" ForeColor="Black" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#424C52" BorderStyle="None" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <PagerStyle BackColor="#3399FF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" BorderStyle="None" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#0000" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="estados_Ticket" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" DeleteCommand="select * from estado_ticket;" SelectCommand="SELECT id_Estado_Ticket, estado_Ticket, estado_Habilitado FROM estado_ticket where estado_Habilitado = @estado_Habilitado" UpdateCommand="UPDATE dynait.estado_ticket SET estado_Ticket = @estado_Ticket WHERE (id_Estado_Ticket = @idEstado_Ticket)">
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="idEstado_Ticket" />
                                                    </DeleteParameters>
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="Lbl_Ver_Eliminados" Name="estado_Habilitado" PropertyName="Text" />
                                                    </SelectParameters>
                                                    <UpdateParameters>
                                                        <asp:Parameter Name="estado_Ticket" />
                                                        <asp:Parameter DefaultValue="" Name="idEstado_Ticket" />
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
</body>
</html>
