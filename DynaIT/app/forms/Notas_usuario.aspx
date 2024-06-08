<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notas_usuario.aspx.cs" Inherits="DynaIT.app.forms.Notas_usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DynamicsIT</title>  
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://kit.fontawesome.com/30f6829453.js" crossorigin="anonymous"></script>
   <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>
   <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/Style.css" rel="stylesheet" />
    <script src="../js/Validacion_JavaScript.js"></script>
    
</head>
<body>
    <form id="Notas_usuario" runat="server">
        <div class="container-fluid" style="overflow: hidden;">
             <asp:ScriptManager ID="ScriptManag" runat="server" />
            <div class="row"  >
                <div class="col-9" >
                    <div class="card direct-chat direct-chat-primary">
                        <div class="card-header">
                <h3 class="card-title">Notas creadas</h3>
                            <div>    <button runat="server" type="button" class="btn btn-primary" data-toggle="modal" data-target="#Fusionar_ticket" style="padding: 0; font-size: 100%;" id="Btn_fusionar_ticket">fusinar ticket</button>

                        </div>
                  </div>
                        
                <div class="card-body">
                  <div class="direct-chat-messages" id="div_chat_notas" style="height: 65vh; overflow: auto;" >
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                </div>
              </div>
                <div class="card-footer" >
                  <div style="text-align: left; display: flex; justify-content: space-around; margin: 0; padding: 0; margin:5px;" >
                                <%--<asp:LinkButton  title="Adjuntar" runat="server" Text="<span class='fa fa-paperclip'></span>" />--%>
                                <button title="Agregar consultores" id="Btn_Agregar_consultores" runat="server" type="button" class="btn btn-primary" data-toggle="modal" data-target="#agentes_agregados" style="padding: 0; font-size: 100%; width:30px;" ><i class="fa-solid fa-user-tie" style="-moz-animation:forwards,alternate;"></i></button>
                                <asp:CheckBox title="¿Nota Interna?" text="Nota interna" ID="Check_nota_interna" runat="server" AutoPostBack="True" OnCheckedChanged="Check_nota_interna_CheckedChanged" Font-Size="XX-Small" />
                                <asp:CheckBox Text="Generar acta" runat="server" ID="check_genera_acta" AutoPostBack="True" Font-Size="X-Small" OnCheckedChanged="check_genera_acta_CheckedChanged" />
                                <asp:FileUpload  ID="file_nota" runat="server" AllowMultiple="true" Font-Size="Smaller" Visible="true" Font-Overline="True" />
                            </div>
                  <div class="input-group">
                      <%--<asp:TextBox class="form-control"  TextMode="MultiLine" Width="100%"></asp:TextBox>--%>
                    <input type="text" name="message" placeholder="Responder.........." class="form-control" id="Txt_descripcion_nota" runat="server"/>
                    <span class="input-group-append">
                      <asp:Button ID="Btn_agregar_Nota" runat="server" Text="Responder" CssClass="btn btn-outline-info" OnClick="Btn_agregar_Nota_Click" />
                    </span>
                  </div>
              </div>
            </div>
                </div>
                <div class="col-3 " style=" width:100%; overflow: auto;">
                    <div class="bandejaEntradaDivdos" style="background-color: #E5E2E2; height: 98vh; ">
                        <div class="row" style="">
                            <div class="col-12">
                                 <div class="row">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-6" style="width:50%;" > 
                                        <asp:Label runat="server" Text="Numero de ticket: " Font-Bold="True" Font-Size="10pt" ForeColor="Black" ></asp:Label><br />
                                        <asp:Label ID="Lbl_id_ticket" runat="server" Text="Lbl_id_ticket" Font-Size="15pt" Font-Italic="True" ForeColor="Black"></asp:Label>
                                    </div>
                                    <div class="col-6"> 
                                        <asp:Label ID="Lbl_Tipo_t" runat="server" Text="Tipo Ticket" Font-Bold="True" Font-Size="10pt" ForeColor="Black"></asp:Label><br />
                                        <asp:Label ID="Lbl_Tipo_Ticket" runat="server" Text="Lbl_Tipo_Ticket" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                    </div>
                                </div>
                                <hr />
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-12">
                                         <div>
                                            <asp:Label ID="lbl_1" runat="server" Text="Titulo" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                            <asp:TextBox ID="Txt_Resumen_ticket" runat="server" Enabled="False" Width="100%" Font-Size="10pt" ForeColor="Black"></asp:TextBox>
                                        </div>
                                        <asp:Label ID="Label6" runat="server" Text="Descripción: " Font-Bold="True" ForeColor="Black"></asp:Label><br />
                                        
                                            <asp:Label ID="Lbl_descripcion" runat="server" Text="Lbl_descripcion" Font-Bold="False" Font-Italic="True" ForeColor="Black" Font-Size="10pt"></asp:Label>
                                        
                                    </div>
                                   

                                </div>

                            </div>
                        </div>
                                <hr />
                                <div class="row">
                                    <div class="col-6">
                                        <asp:Label ID="Label1" runat="server" Text="Estado" Font-Bold="True" Font-Size="10pt" ForeColor="Black"></asp:Label><br />
                                        <asp:DropDownList ID="List_estados" runat="server" DataSourceID="Tabla_estados" DataTextField="estado_Ticket" DataValueField="id_Estado_Ticket" AutoPostBack="True" OnSelectedIndexChanged="List_estados_SelectedIndexChanged" Font-Size="Smaller" ForeColor="Black"></asp:DropDownList>
                                        <asp:SqlDataSource ID="Tabla_estados" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT * FROM [estado_ticket]"></asp:SqlDataSource>
                                    </div>
                                    <div class="col-6">
                                        <div style="width: auto; text-align: center;">
                                            <br />
                                            <!-- Button trigger modal -->
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#adjuntos_ticket" style="padding: 0; font-size: 100%;" id="Btn_crear_cliente">Ver adjuntos</button>
                                        </div>
                                    </div>
                                </div>                        <hr />
                        <div class="row" style="margin-top: 10px; ">
                            <div class="col-12">
                                
                                    <asp:Label ID="Label2" runat="server" Text="Fecha de creación" Font-Size="10pt" Font-Bold="True" ForeColor="Black"></asp:Label><br />
                                    <asp:Label ID="Lbl_fecha" runat="server" Text="Lbl_fecha" Font-Size="10pt" ForeColor="Black"></asp:Label><br />
                                     
                                    <asp:Label ID="labela" runat="server" Text="Fecha de vencimiento" Font-Size="10pt" Font-Bold="True" ForeColor="Black"></asp:Label><br />
                                    <asp:Label ID="lbl_tiempo_respuesta" runat="server" Text="Sin fecha" Font-Size="10pt" ForeColor="Black"></asp:Label><br />
                                </div>
                            
                        </div>
                                <hr />
                                <div class="row" style="margin:0; padding:0;">
                                    <div class="col-12">
                                <div >
                                    <asp:Label ID="Label4" runat="server" Text="Solicitado por : " Font-Bold="True" Font-Size="10pt" ForeColor="Black"></asp:Label><br />
                                    <%--<asp:Label ID="Lbl_cliente" runat="server" Text="Lbl_cliente"></asp:Label>--%>
                                    <asp:DropDownList ID="List_clientes_empresa" runat="server" AutoPostBack="True" DataSourceID="tabla_clientes_empresa" DataTextField="Nombre_Cliente" DataValueField="id_Cliente" OnSelectedIndexChanged="List_clientes_empresa_SelectedIndexChanged" Font-Size="Smaller" ForeColor="Black"></asp:DropDownList>
                                    <asp:SqlDataSource ID="tabla_clientes_empresa" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT id_Cliente, nombre_cliente FROM cliente WHERE (empresa_id = @Id_Empresa)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="lbl_id_empresa" Name="Id_Empresa" PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                           
                                <div style="width: 100%;">
                                    <asp:Label ID="Label5" runat="server" Text="Asignado a " Font-Bold="True" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="List_Usuarios" runat="server" DataSourceID="Tabla_usuarios" DataTextField="nombre_usuario" DataValueField="id_Usuario" AutoPostBack="True" OnSelectedIndexChanged="List_Usuarios_SelectedIndexChanged" Font-Size="Smaller" ForeColor="Black"></asp:DropDownList>
                                    <asp:SqlDataSource ID="Tabla_usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT id_Usuario, nombre_usuario FROM usuario WHERE (id_Usuario = '1') OR (id_Usuario = '2') OR (Usuario_Habilitado = 'Si')"></asp:SqlDataSource>
                                </div>
                            </div>
                                </div>
                            </div>
                        </div>
                        <div id="pruebas" class="row" runat="server">
                            <asp:Label ID="lbl_ruta" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="ruta_nota" Text="ruta_nota" runat="server" Visible="False" />
                        </div>
                    </div>
                    <asp:Label ID="lbl_fecha_nota" runat="server" Text="lbl_fecha_nota" Visible="False" Font-Size="10pt"></asp:Label>
                    <asp:Label ID="Lbl_id_cliente" runat="server" Text="Lbl_id_cliente" Visible="False"></asp:Label>
                    <asp:Label ID="lbl_id_usuario" runat="server" Text="lbl_id_usuario" Visible="False"></asp:Label>
                    <asp:Label ID="Lbl_id_estado" runat="server" Text="Lbl_id_estado" Visible="False"></asp:Label>
                    <asp:Label ID="lbl_fecha_inicio" runat="server" Text="lbl_fecha_inicio" Visible="False"></asp:Label>
                    <asp:Label ID="lbl_correo_sesion" runat="server" Text="lbl_correo_sesion" Visible="False"></asp:Label>
                    <asp:Label ID="lbl_id_empresa" runat="server" Text="lbl_id_empresa" Visible="False"></asp:Label>
                    <asp:Label ID="lbl_Nombre_Cliente" runat="server" Text="lbl_Nombre_Cliente" Visible="False"></asp:Label>
                    <!-- Modal para el boton del ticket  el cual carga los adjuntos del ticket -->
                                <div class="modal fade" id="adjuntos_ticket" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">Archivos adjuntos del ticket</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <asp:Panel ID="Panel3" runat="server"></asp:Panel>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    <%--fin del modal--%>
                    <!-- Modal para el boton de la grilla el cual carga los adjuntos de la nota -->
                                <div class="modal fade" id="adjunto_nota" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-dismiss="modal" data-backdrop="static" data-keyboard="false">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="Titulo_Adjuntos">Archivos adjuntos de la nota</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <asp:Panel ID="Panel_notas" runat="server"></asp:Panel>
                                            </div>
                                            <div class="modal-footer">
                                                <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    <%--cierre de modal de los adjuntos de la nota--%>
                    <!-- Modal para cambiar numero de creditos para la creación del acta -->
                                <div class="modal fade" id="Editar_credito" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-dismiss="modal" data-backdrop="static" data-keyboard="false">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="Creditos">Numero de creditos trabajados</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <%--<asp:TextBox ID="Txt_N_creditos" runat="server" Type="" ></asp:TextBox>--%>
                                                 <input type="number" runat="server" id="N_creditos" placeholder="text" />
                                                <asp:Label ID="lbl_n_creditos" runat="server" Text="0" Visible="true"></asp:Label>
                                                <br />  
                                                <%--<asp:Label Text="Tiene creditos de garantia" runat="server" />--%>
                                                <br />
                                                <asp:Button ID="btn_agregar_creditos" runat="server" Text="Agregar" OnClick="btn_agregar_creditos_Click2"  />
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    <%--<%--cierre de modal de los creditos--%>
                                <%--apertura de modal para agregar agentes a la nota que se va a crear--%>
                            <div class="modal fade" id="agentes_agregados" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-dismiss="modal" data-backdrop="static" data-keyboard="false">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="agentes_agregados_nota">Agentes agregados a la nota</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <asp:DropDownList ID="List_agregar_agentes_nota" runat="server" DataSourceID="List_agrega_agentes_nota" DataTextField="nombre_usuario" DataValueField="id_usuario"></asp:DropDownList>
                                                        <asp:SqlDataSource ID="List_agrega_agentes_nota" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT id_usuario, nombre_usuario FROM usuario WHERE (id_usuario = '1') OR (Usuario_Habilitado = 'Si')"></asp:SqlDataSource>
                                                        <asp:Panel ID="Panel_agentes_nota" runat="server" style=""></asp:Panel>
                                                        <asp:Button ID="Btn_agrega_agente" runat="server" Text="Agregar" OnClick="Btn_agrega_agente_Click" /><br />
                                                        <asp:Label ID="lblContador" runat="server" Text="Label" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                                    </div>
                                                </div>
                                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                                </div>
                    <%--cierre de modal para agregar los agentes a la nota que se va a crear--%>
                    
                    
                     <%--apertura de modal para Fusionar ticket--%>
                            <div class="modal fade" id="Fusionar_ticket" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-dismiss="modal" data-backdrop="static" data-keyboard="false">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <p class="modal-title" id="" visible="false" >Seleccione ticket a fusionar</p>
                                                        <asp:TextBox runat="server" id="txt_id_ticket_buscar" visible="false"/>
                                                        <asp:Button Text="Buscar" runat="server" id="Btn_buscar_ticket" OnClick="Btn_buscar_ticket_Click" visible="false"/>                                                        
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body" style="align-items:center;">
                                                       
                                                        <%-------------------------%>
                                                   <asp:GridView ID="Tickets_fusionar" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_ticket" DataSourceID="TICKETS_FUSIONAR1" ForeColor="#333333" GridLines="None" Height="250px" OnRowCommand="Tickets_fusionar_RowCommand" Width="100%">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                              
                                                                <asp:ButtonField CommandName="Select_ticket" DataTextField="id_ticket" Text="N_tickets" HeaderText="N_tickets">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:ButtonField>
                                                                <asp:BoundField DataField="Resumen_Problema" HeaderText="Titulo" SortExpression="Resumen_Problema">
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" visible="false"/>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#2461BF" Height="10px" />
                                                            <EmptyDataRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#EFF3FB" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                        </asp:GridView>

                                                         <asp:LinkButton  runat="server" id="id_ticket_duscado" ForeColor="BlueViolet"/><br />
                                                        <asp:Label  runat="server" id="lbl_titulo_t_buscado" /><br />
                                                        <asp:Label runat="server" id="lbl_descripcion_buscado"  /><br />
                                                        <asp:Label runat="server" id="lbl_estado_buscado" /><br />
                                                        <asp:Button Text="Cancelar" runat="server" OnClick="Cancerlar_seleccón_Click" ID="Cancerlar_seleccón" Visible="false"/> 
                                                        <%-------------------------%>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button Text="Fusionar" runat="server" ID="btn_fusionar" OnClick="btn_fusionar_Click" />
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                                    </div>
                                                </div>
                                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                                </div>
                    <%--cierre de modal para agregar los agentes a la nota que se va a crear--%>
                </div>
            </div>
        </div>
             
                                                        
                 <asp:SqlDataSource ID="TICKETS_FUSIONAR1" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT id_ticket, Resumen_Problema, Descripcion FROM TICKET where ticket_Habilitado='Si'and estado_id=2"></asp:SqlDataSource>                                          
    </form>
</body>
</html>
