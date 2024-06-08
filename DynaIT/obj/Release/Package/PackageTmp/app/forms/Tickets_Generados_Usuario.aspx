<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tickets_Generados_Usuario.aspx.cs" Inherits="DynaIT.app.forms.Tickets_Generados_Usuario" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/Botones.css" rel="stylesheet" />

    <link href="../style/Style.css" rel="stylesheet" />
    <script src="../js/Validacion_JavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrip_manager_tickets" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="100000" OnTick="Timer1_Tick_cierre_caso" ClientIDMode="AutoID" ViewStateMode="Enabled"></asp:Timer>
        <div class="container-fluid" style="height: 100vh; width: 100%;">

            <div class="row" style="height: 100vh; margin-bottom: 0px; width:auto;">
                <div class="col-12">
                    
                    <asp:UpdatePanel runat="server">
                        <Triggers>
                           <%-- <asp:AsyncPostBackTrigger  ControlID="List_Empresas"/>
                            <asp:AsyncPostBackTrigger  ControlID="List_clientes"/>
                            <asp:AsyncPostBackTrigger  ControlID="List_estado_ticket"/>
                            <asp:AsyncPostBackTrigger  ControlID="List_Agente"/>
                            <asp:AsyncPostBackTrigger  ControlID="Btn_todos_ticket"/>
                            <asp:AsyncPostBackTrigger  ControlID="Btn_mis_tickets"/>
                            <asp:AsyncPostBackTrigger  ControlID="Btn_tickets_compartidos"/>
                            <asp:AsyncPostBackTrigger  ControlID="Btn_sin_asignar"/>--%>
                        </Triggers>
                        <ContentTemplate>
                             <div class="row" style="margin: 5px; padding-bottom: 20px; background-color: #727272">



                        <div class="col-12" style="display: flex; justify-content: space-around;">
                            <div style="margin: 0; padding: 0;">
                                <br />
                                <%--<asp:Panel ID="panel_cerrar" runat="server"></asp:Panel>--%>
                                <asp:Label Text="0" runat="server" ID="lbl_n_registro" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Style="border-radius: 100%; border: solid white 2px; padding: 13px; margin: 0;" />
                            </div>
                            <div style="padding: 0;">
                                <br />
                                <asp:Button ID="Btn_todos_ticket" runat="server" Text="Ver todos los tickets" OnClick="Btn_todos_ticket_Click" CssClass="col-121" Style="border-radius: 5px; margin: 3px;" BorderColor="White" ForeColor="White" Font-Italic="True" />
                            </div>
                            <div style="padding: 20px, 2px,2px,2px;">
                                <br />
                                <asp:Button ID="Btn_mis_tickets" runat="server" Text="Mis tickets" OnClick="Btn_mis_tickets_Click" CssClass="col-121" Style="border-radius: 5px; margin: 3px;" BorderColor="White" ForeColor="White" Font-Italic="True" />
                            </div>
                            <div>
                                <br />
                                <asp:Button ID="Btn_tickets_compartidos" runat="server" Text="Tickets compartidos" CssClass="col-121" Style="border-radius: 5px; margin: 3px;" OnClick="Btn_tickets_compartidos_Click" BorderColor="White" ForeColor="White" Font-Italic="True" />
                                
                            </div>
                            <div>
                                <br />
                                <asp:Button ID="Btn_sin_asignar" runat="server" Text="tickets sin asignar" CssClass="col-121" Style="border-radius: 5px; margin: 3px;" OnClick="Btn_sin_asignar_Click" BorderColor="White" ForeColor="White" Font-Italic="True" />
                            </div>
                            <div>
                                <br />
                                <asp:Button ID="Btn_exportar" runat="server" Text="exportar" CssClass="col-121" Style="border-radius: 5px; margin: 3px;" OnClick="Btn_exportar_Click" BorderColor="White" ForeColor="White" Font-Italic="True" />
                            </div>
                            <div>
                                <br />
                                <button type="button" class="btn-buscarTickets" data-toggle="modal" data-target="#buscar_tickets" style="border-radius: 5px; margin: 3px;">Buscar</button>



                                <!-- Modal para el boton del ticket el cual carga los adjuntos del ticket -->
                                <div class="modal fade" id="buscar_tickets" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-dismiss="modal" data-keyboard="false">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">Filtros</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-12" style="justify-content: space-around; width:fit-content;">
                                                        <div id="div_col_empresa" runat="server">
                                                            <div>
                                                                <asp:Label ID="Label6" runat="server" Text="Empresa" Font-Size="Smaller"></asp:Label><br />
                                                            </div>
                                                            <div>
                                                                <asp:DropDownList ID="List_Empresas" runat="server" AutoPostBack="True" DataSourceID="Tabla_empresas" DataTextField="Nombre_Empresa" DataValueField="id_empresa" OnSelectedIndexChanged="List_Empresas_SelectedIndexChanged" Font-Size="Smaller"></asp:DropDownList>
                                                                <asp:SqlDataSource ID="Tabla_empresas" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="SELECT * FROM empresa WHERE empresa_habilitada = 'Si' OR id_empresa = '1'"></asp:SqlDataSource>
                                                            </div>
                                                        </div>
                                                        <div id="div_col_cliente" runat="server">
                                                            <div>
                                                                <asp:Label ID="Label7" runat="server" Text="Cliente" Font-Size="Smaller"></asp:Label><br />
                                                            </div>
                                                            <div>
                                                                <asp:DropDownList ID="List_clientes" runat="server" AutoPostBack="True" DataSourceID="Clientes_tabla" DataTextField="nombre_cliente" DataValueField="id_Cliente" OnSelectedIndexChanged="List_clientes_SelectedIndexChanged" OnTextChanged="List_clientes_TextChanged" Font-Size="Smaller"></asp:DropDownList>
                                                                <asp:SqlDataSource ID="Clientes_tabla" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="select id_Cliente, nombre_cliente from cliente where cliente.id_Cliente = '1' or cliente.Cliente_Habilitado = 'Si'" ProviderName="<%$ ConnectionStrings:dynamicsitConnectionString2.ProviderName %>"></asp:SqlDataSource>
                                                            </div>
                                                        </div>
                                                        <div id="div_col_estado" runat="server">
                                                            <div>
                                                                <asp:Label ID="Label8" runat="server" Text="Estado" Font-Size="Smaller"></asp:Label><br />
                                                            </div>
                                                            <div>
                                                                <asp:DropDownList ID="List_estado_ticket" runat="server" DataSourceID="Tabla_estados_ticket" DataTextField="estado_Ticket" DataValueField="id_Estado_Ticket" AutoPostBack="True" OnSelectedIndexChanged="List_estado_ticket_SelectedIndexChanged" Font-Size="Smaller"></asp:DropDownList>
                                                                <asp:SqlDataSource ID="Tabla_estados_ticket" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" ProviderName="<%$ ConnectionStrings:dynaitConnectionString.ProviderName %>" SelectCommand="SELECT * FROM estado_ticket"></asp:SqlDataSource>
                                                            </div>
                                                        </div>
                                                        <div id="div_agente" runat="server">
                                                            <div>
                                                                <asp:Label ID="lbl_Agente" runat="server" Text="Agente" Font-Size="Smaller"></asp:Label><br />
                                                            </div>
                                                            <div>
                                                                <asp:DropDownList ID="List_Agente" runat="server" AutoPostBack="True" Font-Size="Smaller" DataSourceID="tabla_Agentes" DataTextField="nombre_usuario" DataValueField="id_usuario" OnSelectedIndexChanged="List_Agente_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:SqlDataSource ID="tabla_Agentes" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="SELECT id_usuario, nombre_usuario FROM usuario"></asp:SqlDataSource>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--fin del modal--%>
                            </div>
                        </div>
                            <asp:Label ID="Lbl_id_usuario" runat="server" Text="id_usuario" Visible="False"></asp:Label>
                            <asp:Label ID="lbl_rol_usuario" runat="server" Text="lbl_rol_usuario" Visible="False"></asp:Label>
                            <asp:Label ID="lbl_nombre_usuario" runat="server" Text="lbl_correo_usuario" Visible="False"></asp:Label>
                            <asp:Label ID="lbl_correo2" runat="server" Text="lbl_correo_usuario" Visible="False"></asp:Label>
                       </div>

                    <div class="row">
                        <div class="col-12" style="justify-content: center; text-align: center; align-content: center; padding-top: 10px; ">

                            <div class="card-body table-responsive p-0" style=" align-content: center; height: 83vh; width: 100%; overflow: scroll;">


                                <asp:GridView CssClass="table table-head-fixed text-nowrap" ID="Grilla_Tickets_generados_usuario" runat="server" CellPadding="1" ForeColor="#000" GridLines="None" Width="100%" Height="90%" AutoGenerateColumns="False" OnPageIndexChanging="Grilla_Tickets_generados_usuario_PageIndexChanging" HorizontalAlign="Center" RowHeaderColumn="N_Ticket" OnLoad="Grilla_Tickets_generados_usuario_Load" OnPageIndexChanged="Grilla_Tickets_generados_usuario_PageIndexChanged" AllowCustomPaging="True" DataKeyNames="N_Ticket" OnRowCommand="Grilla_Tickets_generados_usuario_RowCommand" OnSelectedIndexChanged="Grilla_Tickets_generados_usuario_SelectedIndexChanged" OnRowDataBound="Grilla_Tickets_generados_usuario_RowDataBound" OnSelectedIndexChanging="Grilla_Tickets_generados_usuario_SelectedIndexChanging" OnDataBinding="Grilla_Tickets_generados_usuario_DataBinding" OnDataBound="Grilla_Tickets_generados_usuario_DataBound">
                                    <AlternatingRowStyle BorderStyle="None" BackColor="White" />
                                    <Columns>
                                        <asp:ButtonField CommandName="Select" HeaderText="Nº Ticket" DataTextField="N_Ticket">
                                            <ControlStyle Font-Underline="True" ForeColor="#000" />
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="Select_2" HeaderText="Nº Ticket" DataTextField="N_Ticket" Visible="False">
                                            <ControlStyle Font-Underline="True" ForeColor="#0000CC" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="Fecha_creacion" ReadOnly="true" HeaderText="Fecha de creacion"></asp:BoundField>
                                        <asp:BoundField DataField="estado_ticket" ReadOnly="true" HeaderText="Estado"></asp:BoundField>
                                        <asp:BoundField DataField="tipo_ticket" ReadOnly="true" HeaderText="Tipo de ticket" Visible="true"></asp:BoundField>
                                        <asp:BoundField DataField="Tlp_prioridad" ReadOnly="true" HeaderText="Prioridad" Visible="true"></asp:BoundField>
                                        <asp:BoundField DataField="nombre_empresa" ReadOnly="true" HeaderText="Empresa"></asp:BoundField>
                                        <asp:BoundField DataField="Nombre_Cliente" ReadOnly="true" HeaderText="Cliente solicitante: " Visible="true"></asp:BoundField>
                                        <asp:BoundField DataField="Nombre_usuario" ReadOnly="true" HeaderText="Consultor asignado:"></asp:BoundField>
                                        <asp:BoundField DataField="Ticket_Creado_por" ReadOnly="true" HeaderText="Creado por:" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="TiempoDesarrollo" ReadOnly="true" HeaderText="Creditos:"></asp:BoundField>
                                        <asp:BoundField DataField="Fecha_cierre_ticket" ReadOnly="true" HeaderText="Fecha de cierre:" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="Numero_Dias" ReadOnly="true" HeaderText="Dias" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="Resumen_Problema" ReadOnly="true" HeaderText="Nombre del caso"></asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" ReadOnly="true" HeaderText="Descripcion" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="tiempo_Respuesta" ReadOnly="true" HeaderText="f_vencimiento" Visible="true" DataFormatString="{0:g}"></asp:BoundField>

                                    </Columns>
                                    <EditRowStyle BorderStyle="None" BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BorderStyle="None" HorizontalAlign="Center" BackColor="#424C52" Font-Bold="True" Font-Italic="True" ForeColor="White" Font-Size="Smaller" />
                                    <PagerSettings NextPageText="&gt;&gt;;" PageButtonCount="6" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" CssClass="alinearColumnas" Font-Size="Smaller" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>

                            </div>

                            <%--////--%>
                        </div>
                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                   
                </div>
            </div>
        </div>
    </form>
</body>
</html>
