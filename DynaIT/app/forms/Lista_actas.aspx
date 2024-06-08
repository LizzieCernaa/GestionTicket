<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lista_actas.aspx.cs" Inherits="DynaIT.app.forms.Lista_actas" EnableEventValidation="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DynamicsIT</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous" />
    <link href="../style/Style.css" rel="stylesheet" />
    <script src="../js/Validacion_JavaScript.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/Botones.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrip_lis_actas" runat="server"></asp:ScriptManager>
        <div class="container-fluid" style="height: 99vh;">
            <div class="row">
                <div class="menuActas" style="display: flex; justify-content: space-around; padding: 0; width: 100%">
                   
                     <div class="">
                        <div style="">
                            <div>
                                <br />
                          <asp:Button ID="btn_limpiar" runat="server" Text="Borrar Filtros" CssClass="col-121" Style="border-radius: 5px; margin: 1px;" BorderColor="White" ForeColor="White" Font-Italic="True" OnClick="btn_limpiar_Click" BorderWidth="1px" />
                            </div>
                        </div>
                     </div>
                    <div class="">
                        <div style="">
                            <div>
                                <br />
                                <asp:Button ID="Btn_exportar_actas" runat="server" Text="Exportar" CssClass="col-121" Style="border-radius: 5px; margin: 1px;" BorderColor="White" ForeColor="White" Font-Italic="True" OnClick="Btn_exportar_actas_Click" BorderWidth="1px" />
                            </div>
                        </div>
                    </div>
                    <div class="">
                        <div style="">

                            <div>
                                <br />
                                <button type="button" class="btn-buscarTickets" data-toggle="modal" data-target="#modal_busqueda_actas" style="border-radius: 5px; margin: 1px;">Buscar</button>

                            </div>
                        </div>

                    </div>


                    <%--</div>--%>
                </div>
            </div>

            
                      <!-- Modal para el boton del crear usuario -->
                <div class="modal fade" id="modal_busqueda_actas" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <%--<asp:ScriptManager ID="scripMananer_panel_crear_cliente" runat="server" />--%>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="modal-header" style="text-align: center;">
                                        <h5 class="modal-title" id="title_modal_deta_ticket">Detalle de ticket </h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body" style="background-color: #EBEFF0; text-align: center">
                                        <%-----------------------------------------------------%>
                                     
                                        <div class="">
                        <div style="">
                            <asp:Label ID="Label1" runat="server" Text="Empresa" Font-Size="Medium"></asp:Label>
                        </div>
                        <div style="">
                            <asp:DropDownList ID="List_empresas" runat="server" DataSourceID="lista_empresas" DataTextField="Nombre_Empresa" DataValueField="id_Empresa" OnSelectedIndexChanged="List_empresas_SelectedIndexChanged" AutoPostBack="True" Font-Size="Medium"></asp:DropDownList>
                            <asp:SqlDataSource ID="lista_empresas" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" ProviderName="<%$ ConnectionStrings:dynamicsitConnectionString.ProviderName %>" SelectCommand="SELECT id_Empresa, Nombre_Empresa FROM empresa where Empresa_Habilitada = 'Si' or id_Empresa = '1'"></asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="">
                        <div style="display: flex; padding: 0;">
                            <asp:Label ID="Label2" runat="server" Text="Agente" Font-Size="Medium"></asp:Label>

                        </div>
                        <div style="">
                            <asp:DropDownList ID="List_agente" runat="server" DataSourceID="lista_agentes" DataTextField="nombre_usuario" DataValueField="id_usuario" AutoPostBack="True" OnSelectedIndexChanged="List_agente_SelectedIndexChanged" Font-Size="Medium"></asp:DropDownList>
                            <asp:SqlDataSource ID="lista_agentes" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" ProviderName="<%$ ConnectionStrings:dynamicsitConnectionString.ProviderName %>" SelectCommand="SELECT id_usuario, nombre_usuario FROM usuario where Usuario_Habilitado = 'Si' or id_usuario = '1'"></asp:SqlDataSource>

                        </div>
                    </div>
                    <div>
                        <div style="">
                            <asp:Label Text="Estado" runat="server" Font-Size="Medium" />
                        </div>
                        <div style="">
                            <asp:DropDownList ID="List_estados" runat="server" DataSourceID="Lista_estados" DataTextField="estado_Ticket" DataValueField="id_Estado_Ticket" Font-Size="Medium" AutoPostBack="True" OnSelectedIndexChanged="List_estados_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource ID="Lista_estados" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" ProviderName="<%$ ConnectionStrings:dynamicsitConnectionString2.ProviderName %>" SelectCommand="SELECT id_Estado_Ticket, estado_Ticket FROM estado_ticket where estado_Habilitado = 'Si' or id_Estado_Ticket = '1'"></asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="">
                        <div style="">
                            <asp:Label ID="lbl_fecha_inicio" runat="server" Text="Fecha inicio Acta" Font-Size="Medium"></asp:Label>

                        </div>
                        <div style="display: flex; padding: 0;">
                            <input id="Txt_fecha_inicio" type="date" runat="server" style="font-size: medium" />

                        </div>
                    </div>
                    <div class="">
                        <div style="">
                            <asp:Label ID="lbl_fecha_fin" runat="server" Text="Fecha Fin Acta" Font-Size="Medium"></asp:Label>
                        </div>
                        <div style="display: flex; padding: 0;">
                            <input id="Txt_fecha_fin" type="date" runat="server" style="font-size: Medium" />
                        </div>

                    </div>
                    <div class="">
                        <div style="">
                            <div>
                                <br />
                                <asp:Button ID="Btn_buscar_fecha" runat="server" Text="Buscar fechas" CssClass="btn btn-outline-success btn-sm" OnClick="Btn_busca_actas_Click" />
                            </div>
                        </div>

                    </div>
                                        <%---------------------------------------------------------%>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button Text="Limpiar" runat="server" OnClick="btn_limpiar_Click"/>
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    </div>
                                </ContentTemplate>
                                <triggers>
                                  <asp:PostBackTrigger ControlID="Grilla_actas" />
                                </triggers>
                                       </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--fin del modal--%>


            <div class="row">
                <div class="col-12" style="justify-content: center; text-align: center; align-content: center; top: -5px; left: 0px; margin-top: 10px; width: 100%;">
                    <div style="overflow: auto; align-content: center; height: 84vh; width: 100%;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                               <asp:GridView ID="Grilla_actas" CssClass="table table-head-fixed text-nowrap" runat="server" AutoGenerateColumns="False" DataKeyNames="id_acta" DataSourceID="tabla_actas" CellPadding="0" ForeColor="#333333" GridLines="None" Width="97%" Font-Size="Smaller" HorizontalAlign="Left" OnRowEditing="Grilla_actas_RowEditing" Height="124px" OnSelectedIndexChanged="Grilla_actas_SelectedIndexChanged" OnRowCancelingEdit="Grilla_actas_RowCancelingEdit" OnRowUpdating="Grilla_actas_RowUpdating" OnRowCommand="Grilla_actas_RowCommand" OnRowUpdated="Grilla_actas_RowUpdated">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_acta" HeaderText="idactas" InsertVisible="False" ReadOnly="True" SortExpression="id_acta" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha Del Caso" SortExpression="Fecha" ReadOnly="True" />
                                <asp:BoundField DataField="Fecha_crea_acta" HeaderText="Fecha Creación Acta" SortExpression="Fecha_crea_acta" ReadOnly="True" />
                                <asp:BoundField DataField="Numero_Acta" HeaderText="N° Acta" SortExpression="Numero_Acta" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="ticket_id" HeaderText="N° Ticket" SortExpression="ticket_idTicket" ReadOnly="True" />
                                <asp:BoundField DataField="Resumen_Problema" HeaderText="Titulo Caso" SortExpression="Resumen_Problema" ReadOnly="True" />
                                <asp:BoundField DataField="nombre_usuario" HeaderText="Consultor" SortExpression="Nombres" ReadOnly="True" />
                                <asp:BoundField DataField="estado_Ticket" HeaderText="Estado" SortExpression="estado_Ticket" ReadOnly="True" />
                                <asp:BoundField DataField="TiempoDesarrollo" HeaderText="Total Creditos" SortExpression="TiempoDesarrollo" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="N_creditos_acta" HeaderText="N° Creditos acta" SortExpression="N_creditos_acta" ReadOnly="True" />
                                <asp:BoundField DataField="Fecha_cierre_ticket" HeaderText="Fecha Cierre Caso" SortExpression="Fecha_cierre_ticket" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="Nombre_Empresa" HeaderText="Empresa" SortExpression="Nombre_Empresa" ReadOnly="True" />
                                <asp:BoundField DataField="Representante_empresa" HeaderText="Cliente" SortExpression="Representante_empresa" ReadOnly="True" />
                                <asp:BoundField DataField="Numero_Factura" HeaderText="N° Factura" SortExpression="Numero_Factura" />
                                <asp:CommandField ShowEditButton="True" />
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



                          <asp:SqlDataSource ID="tabla_actas" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" ProviderName="<%$ ConnectionStrings:dynamicsitConnectionString.ProviderName %>" SelectCommand="SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, empresa.Nombre_Empresa, 
empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, ticket.Fecha, ticket.Fecha_cierre_ticket, estado_ticket.estado_Ticket
FROM acta inner join ticket on ticket.id_ticket = acta.ticket_id
                                 inner join cliente on cliente.id_Cliente = ticket.Cliente_id
                                 inner join empresa on empresa.id_Empresa = cliente.empresa_id
                                 inner join usuario on usuario.id_usuario = acta.fk_usuario_id
                                 inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket order by id_Empresa"
                            UpdateCommand=" select * from acta"></asp:SqlDataSource>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </div>
                </div>
            </div>
            
        </div>
    </form>
</body>
</html>
