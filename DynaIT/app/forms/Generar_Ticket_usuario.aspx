<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generar_Ticket_usuario.aspx.cs" Inherits="DynaIT.app.forms.Generar_Ticket" %>

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
    <script src="https://cdn.tiny.cloud/1/ru8su9eg3n8dv236yckfxc61kwnikz0wsx7altpwsplujhmi/tinymce/5/tinymce.min.js" referrerpolicy="origin"></script>
    <script>
        tinymce.init({
            selector: '#Txt_DetallesProblema'
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scripMananer_crear_ticket" runat="server" />
        <div class="container-fluid" style="">

            <asp:UpdatePanel runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="List_TemaConsultoria" />
                    
                </Triggers>
                <ContentTemplate>
                    <div style="overflow: scroll; height: 100vh; width: 100%;">

                        <div class="card card-default">
                            <div class="card-header" style="padding: 7px;">
                                <h3 class="card-title">Crear nuevo Ticket</h3>
                            </div>

                            <!-- /.card-header -->
                            <div class="card-body" style="padding: 7px;">
                                <!-- fin de fila 1 con empresa, nombre del cliente y correo-->
                                <div class="row" style="display: flex; justify-content: space-around;">

                                    <div class="col-md">
                                        <div class="form-group">

                                            <asp:Label class="" ID="Label3" runat="server" Text="Tipo de ticket "></asp:Label>
                                            <br />
                                            <asp:DropDownList class="form-control select2" ID="List_TemaConsultoria" runat="server" DataSourceID="TipoTcket" DataTextField="tipo_Ticket" DataValueField="id_tipo_Ticket" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="TipoTcket" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" ProviderName="<%$ ConnectionStrings:dynaitConnectionString.ProviderName %>" SelectCommand="SELECT id_tipo_Ticket, tipo_Ticket, Tipo_Ticket_Habilitado FROM tipo_ticket WHERE (Tipo_Ticket_Habilitado = 'Si') OR (id_tipo_Ticket = '1')"></asp:SqlDataSource>
                                        </div>
                                    </div>

                                    <div class="col-md">
                                        <div class="form-group">
                                            <asp:Label class="" ID="Label1" runat="server" Text="Estado"></asp:Label>
                                            <asp:DropDownList class="form-control select2" ID="List_Estado" runat="server" AutoPostBack="True" DataSourceID="Estados_ticket" DataTextField="estado_Ticket" DataValueField="id_Estado_Ticket">
                                                <asp:ListItem class="bordesDrop">Abierto</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="Estados_ticket" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" ProviderName="<%$ ConnectionStrings:dynaitConnectionString.ProviderName %>" SelectCommand="SELECT * FROM estado_ticket where id_Estado_Ticket = '2'"></asp:SqlDataSource>
                                            <asp:Label ID="Lbl_id_ticket" runat="server" Text="Lbl_estado" Visible="False"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="col-md" id="Div_prioridad" runat="server">
                                        <div class="form-group">
                                            <asp:Label class="" ID="lbl_prioridad" runat="server" Text="Prioridad"></asp:Label>
                                            <asp:DropDownList class="form-control select2" ID="List_Prioridad" runat="server" DataSourceID="tabla_prioridad" DataTextField="prioridad" DataValueField="id_prioridad">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="tabla_prioridad" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select id_prioridad, prioridad from prioridad where prioridad_habilitada = 'Si' or id_prioridad = 1"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>

                                <hr />
                                <div class="row" style="display: flex; justify-content: space-around;">
                                    <div class="col-md-4">
                                        <!-- lista de empresas para seleccionar -->
                                        <div class="form-group">
                                            <asp:Label class="" ID="Label7" runat="server" Text="Empresa"></asp:Label>
                                            <br />
                                            <asp:DropDownList class="form-control select2" ID="List_EmpresaCliente" runat="server" AutoPostBack="True" DataSourceID="NombreEmpresa" DataTextField="nombre_empresa" DataValueField="id_empresa" OnSelectedIndexChanged="Txt_EmpresaCliente_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:Label class="mr-sm-2" ID="Label6" runat="server" Text="Nombre Completo"></asp:Label>
                                            <br />
                                            <asp:DropDownList class="form-control select2" ID="List_NombreCliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Txt_NombreCliente_SelectedIndexChanged">
                                                <asp:ListItem class="bordesDrop">--Seleccionar--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:Label class="mr-sm-2" ID="Label5" runat="server" Text="Correo Electronico"></asp:Label><br />
                                            <asp:TextBox class="form-control" ID="Txt_Correo" runat="server" ValidateRequestMode="Enabled" Enabled="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <!-- fin de fila 1 con empresa, nombre del cliente y correo-->
                                <hr />
                                <!-- /.row -->
                                <div class="row" style="display: flex; justify-content: space-around;">
                                    <div class="col-md">
                                        <div class="form-group" runat="server" id="div_lista_grupo">
                                            <asp:Label class="" ID="Label16" runat="server" Text="Area"></asp:Label>
                                            <asp:DropDownList class="form-control select2" ID="List_Grupo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Txt_Grupo_SelectedIndexChanged" DataSourceID="grupo_usuarios" DataTextField="area" DataValueField="id_area">
                                            </asp:DropDownList>

                                            <asp:Label ID="Label17" runat="server" Text="Lbl_id_grupo" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md">
                                        <div class="form-group" runat="server" id="div_lista_agente">
                                            <asp:Label class="" ID="Label18" runat="server" Text="Agente"></asp:Label>
                                            <asp:DropDownList class="form-control select2" ID="List_Agente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List_Agente_SelectedIndexChanged" DataValueField="idUsuario">
                                                <asp:ListItem>--Seleccionar--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label10" runat="server" Text="Titulo" Width="50%"></asp:Label>
                                        <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_Resumen" runat="server" Width="50%"></asp:TextBox>
                                        <asp:Label ID="Label11" runat="server" Text="Descripción "></asp:Label>
                                        <br />

                                        <asp:TextBox class="form-control mb-2 mr-sm-2" ID="Txt_DetallesProblema" runat="server" Height="500px" TextMode="MultiLine" Width="100%" ValidateRequestMode="Disabled"></asp:TextBox>
                                        <%--<div class="form-control mb-2 mr-sm-2" id="Txt_DetallesProblema" runat="server" style="height:auto">  </div>--%>
                                        <asp:FileUpload ID="File_Archivo" runat="server" AllowMultiple="true" />
                                    </div>
                                </div>
                            </div>

                            <!-- /.card-body -->
                            <div class="card-footer">
                                <div class="TitleForm">
                                    <asp:Button class="btn btn-primary" ID="Btn_CrearTicket" runat="server" Text="Crear Ticket" OnClick="Btn_CrearTicket_Click" />
                                    <asp:Button class="btn btn-danger" ID="Btn_Cancelar" runat="server" Text="Cancelar" OnClick="Btn_Cancelar_Click" />
                                </div>
                            </div>
                        </div>

                        <%---------------label utilizados para almacenar datos no visibles--------------------------%>
                        <asp:Label ID="Lbl__Fk_id_Usuario" runat="server" Visible="False">3</asp:Label>
                        <asp:Label ID="Lbl_id_Cliente" runat="server" Visible="False">Lbl_id_Cliente</asp:Label>
                        <asp:Label ID="Lbl_Fecha_Ticket" runat="server" Visible="False">Lbl_Fecha_Ticket</asp:Label>
                        <asp:Label ID="Lbl_correo_inicio_sesion" runat="server" Visible="False">Lbl_correo_inicio_sesion</asp:Label>
                        <asp:Label ID="Lbl_id_empresa" runat="server" Text="Lbl_id_empresa" Visible="False"></asp:Label>
                        <%-----------------------------------------%>


                        <asp:SqlDataSource ID="NombreEmpresa" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT id_empresa, nombre_empresa FROM empresa WHERE id_empresa = '1' OR empresa_habilitada = 'Si'"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="grupo_usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT id_area, area FROM area where area_Habilitado = 'Si' or id_area=1 or id_area=2  "></asp:SqlDataSource>

                        <%---------------------------------------%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%----------------------------------------%>
    </form>
   
</body>
</html>
