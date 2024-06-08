<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear_tipos_ticket.aspx.cs" Inherits="DynaIT.app.forms.Crear_tipos_ticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>crear tipos de tickets</title>
    <link href="../style/Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="padding: 0;">
            <div class="contenidoFormulariosCreacion">
                <!-- Modal para el boton del crearcliente -->
                <div class="modal fade" id="modal_crear_grupo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <asp:ScriptManager ID="scripMananer_panel_crear_cliente" runat="server" />
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="modal-header" style="text-align: center;">
                                        <div class="TitleForm">
                                                            <h4>Crear tipos de tickets</h4>
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
                                                                <asp:Label ID="Label1" runat="server" Text="Tipos de tickets"></asp:Label>
                                                                <asp:TextBox class="form-control mb-2" ID="Txt_Tipos_Tckets" runat="server" Style="text-transform:capitalize"></asp:TextBox>
                                                                <asp:Label Text="Horas de respuesta" runat="server" />
                                                                <input  name="name" value="0" runat="server" id="txt_horas_respuesta" type="number" />
                                                                <asp:Label ID="txt_id_tipo_ticket" runat="server" Text="Label" Visible="False"></asp:Label>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <%---------------------------------------------------------%>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button class="btn btn-primary" ID="Btn_Editar" runat="server" Text="Editar" Visible="False" />
                                        
                                        
                                            <asp:Button class="btn btn-primary" ID="Btn_Recuperar_tipo_ticket" runat="server" Text="Habilitar" OnClick="Btn_Recuperar_Click" Visible="false" />
                                            <asp:Button class="btn btn-primary" ID="Btn_Editar_tipo_ticket" runat="server" Text="Editar" OnClick="Btn_Editar_Click" />
                                            <asp:Button class="btn btn-primary" ID="Btn_Crear_Tipo_Ticket" runat="server" Text="Crear" OnClick="Btn_CrearTicket_Click" />
                                            
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>


                                        

                                    </div>
                                </ContentTemplate>
                                <Triggers>
      <asp:PostBackTrigger ControlID="Grilla_Tipos_Ticket" /> 
     </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--fin del modal--%>


                <div class="row">
                    <div class="col-12">
                        <div class="row" style="margin-top:20px;">
                            <div class="col-12" style="margin: 10px; text-align: center">
                                <asp:Label ID="Lbl_Titulo_Todos_Creados" runat="server" Text="Tipos de tickets Creados" Font-Bold="True" Font-Size="20pt"></asp:Label>
                                <asp:Label ID="Lbl_Titulo_Eliminados" runat="server" Text="Tipos de tickets Eliminados" Visible="False" Font-Bold="True" Font-Size="20pt"></asp:Label>


                            </div>
                        </div>
                        <div class="row" style="margin:20px;">
                            <div class="col-12">
                                <div style="margin: auto; text-align: center;">
                                    
                                    
                                    <asp:Label ID="Lbl_Recuperar" runat="server" Text="Si" Visible="False"></asp:Label>
                                    <asp:Button Text="Agregar grupo" class="btn btn-primary" runat="server" ID="btn_agregar_grupo" Style="padding: 5px; font-size: 100%;" OnClick="btn_agregar_grupo_Click" />
                                    <asp:Button Text="ver deshabilitados" class="btn btn-danger" runat="server" ID="Btn_ver_deshabilitados" Style="padding: 5px; font-size: 100%;"  Visible="False" OnClick="Btn_ver_deshabilitados_Click" />
                                     <asp:Button Text="ver habilitados" class="btn btn-success" runat="server" ID="Btn_ver_habilitados" Style="padding: 5px; font-size: 100%;"  Visible="False" OnClick="Btn_ver_habilitados_Click" />
                                    <asp:Label ID="Lbl_Ver_Eliminados" runat="server" Text="Si" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin:30px;">
                            <div class="col-12">

                                <div class="row">
                                    <div class="col-12" >
                                        <div class="GrillaInferior" style="width: 100%; text-align:center; justify-content: center; display: flex;">
                                            <div class="table-responsive" style="width:70%">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="Grilla_Tipos_Ticket" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="id_tipo_Ticket" DataSourceID="Tipo_ticket" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="6" Width="100%" OnRowCommand="Grilla_Tipos_Ticket_RowCommand" OnRowDeleting="Grilla_Tipos_Ticket_RowDeleting">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="id_tipo_Ticket" HeaderText="idtipo_Ticket" ReadOnly="True" SortExpression="idtipo_Ticket" Visible="False" />
                                                    <asp:BoundField DataField="tipo_Ticket" HeaderText="Tipos de Ticket" SortExpression="tipo_Ticket"></asp:BoundField>
                                                    <asp:BoundField DataField="H_respuesta_tipo_ticket" HeaderText="horas respuesta" SortExpression="Horas_respuesta"></asp:BoundField>
                                                    <asp:BoundField DataField="Tipo_Ticket_Habilitado" HeaderText="Tipo_Ticket_Habilitado" SortExpression="Tipo_Ticket_Habilitado" Visible="False"></asp:BoundField>
                                                    <asp:ButtonField CommandName="Select" Text="Editar" />
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" ></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#3399FF" BorderStyle="None" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerStyle BackColor="#3399FF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" BorderStyle="None" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="Tipo_ticket" runat="server" ConnectionString="<%$ ConnectionStrings:Myconexion2 %>" SelectCommand="SELECT id_tipo_Ticket, tipo_Ticket, Tipo_Ticket_Habilitado, H_respuesta_tipo_ticket FROM tipo_ticket WHERE (Tipo_Ticket_Habilitado = @Tipo_Ticket_Habilitado )" DeleteCommand="SELECT * FROM ticket">
                                                <SelectParameters>
                                                    <asp:ControlParameter Name="Tipo_Ticket_Habilitado" ControlID="Lbl_Ver_Eliminados" PropertyName="Text" />
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


                </div>
            </div>
        </div>
    </form>
</body>
</html>
