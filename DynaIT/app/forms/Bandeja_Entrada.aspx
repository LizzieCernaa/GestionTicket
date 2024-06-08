<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bandeja_Entrada.aspx.cs" Inherits="DynaIT.app.forms.Bandeja_Entrada" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <link href="../style/Style.css" rel="stylesheet" />
    <script src="../js/Validacion_JavaScript.js"></script>
    <link href="../style/Botones.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin: 0;">
            <asp:ScriptManager ID="aaaa" runat="server"></asp:ScriptManager>
            <%-- barra de notificaciones--%>
            <div class="row" style="height: 55px; background-color: #727272">
                <div class="col-12" style="">
                    <div class="row" style="margin-top: 16px;">
                        <div class="col-2" style="margin-left: 4%;">
                            <div style="text-align: center">
                                <asp:Label ID="lbl_abiertos" runat="server" Text="Abiertos" ForeColor="White"></asp:Label>
                                <asp:Label ID="Lbl_N_Abiertos" runat="server" OnLoad="Lbl_N_Abiertos_Load" ForeColor="White"></asp:Label>
                            </div>
                        </div>
                        <div class="col-2">
                            <div>
                                <asp:Label ID="lbl_pendientes" runat="server" Text="En proceso" ForeColor="White"></asp:Label>
                                <asp:Label ID="Lbl_N_pendientes" runat="server" OnLoad="Lbl_N_pendientes_Load" ForeColor="White"></asp:Label>
                            </div>
                        </div>
                        <div class="col-2 ">
                            <div>
                                <asp:Label ID="lbl_enp" runat="server" Text="Resuelto" ForeColor="White"></asp:Label>
                                <asp:Label ID="Lbl_Enproceso" runat="server" OnLoad="Enproceso_Load" ForeColor="White"></asp:Label>
                            </div>
                        </div>
                        <div class="col-2 ">
                            <div>
                                <asp:Label ID="lbl_" runat="server" Text="cerrado" ForeColor="White"></asp:Label>
                                <asp:Label ID="Lbl_NResueltos" runat="server" OnLoad="Lbl_NResueltos_Load" ForeColor="White"></asp:Label>
                            </div>
                        </div>
                        <div class="col-2 ">
                            <div>
                                <asp:Label ID="Label9" runat="server" Text="vencidos" ForeColor="White"></asp:Label>
                                <asp:LinkButton Text="0" runat="server" ForeColor="White" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" style="overflow: auto; height: 95vh;">
                <div class="col-12">

                    <div class="row">

                        <%--fila2--%><%--<div class="row">--%>
                        <%-------------------------------------------%>
                      <%------------------------------------%>
                        <div class="col-6" style="margin: 0; height: 581px; overflow: auto;">
                            <!-- Example Pie Chart Card-->
                            <div class="card mb-4" style="left: 0px; top: 0px;">
                                <div class="card-header" style="background-color: #424C52; display: flex; justify-content: space-between; color: white">
                                    <div>
                                        <i class="fa fa-pie-chart" style="text-decoration-color: white"></i>Ticket cerrados                                       
                                    </div>
                                    <div>
                                        <asp:DropDownList ID="list_top_cerrados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="list_top_cerrados_SelectedIndexChanged">
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="card-body" style="background-color: lightgray">
                                    <div style="display: flex; justify-content: space-around; margin-bottom: 20px;">
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="lbl_fecha_inicio" runat="server" Text="Fecha inicio" Font-Size="Medium"></asp:Label>

                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fec_ini_cerrados" type="date" runat="server" style="font-size: medium; border-radius: 10px;" />
                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="lbl_fec_fin_empresas" runat="server" Text="Fecha Fin" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fec_fin_cerrados" type="date" runat="server" style="font-size: Medium; border-radius: 10px" />
                                            </div>

                                        </div>
                                        <div>
                                            <asp:Button Text="Buscar" CssClass="btn-ghost secundary round" runat="server" ID="Btn_cerrados_agente" OnClick="Btn_cerrados_agente_Click1" />
                                        </div>
                                    </div>
                                    <%--<--grafica de -->--%>
                                    <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="list_top_cerrados" />
                                            <asp:AsyncPostBackTrigger ControlID="Btn_cerrados_agente" />

                                        </Triggers>
                                        <ContentTemplate>

                                            <asp:Chart runat="server" ID="grafica_cerrados_agente" DataSourceID="Grafica_cerrados_agente_grafica" Width="566px" OnLoad="grafica_cerrados_agente_Load">
                                                <Series>
                                                    <asp:Series Name="Series1" XValueMember="nombre_usuario" YValueMembers="N_Ticket" IsValueShownAsLabel="true"></asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                            <asp:GridView Visible="false" ID="Grilla_cerrados_por_consultor" runat="server" CssClass="table table-head-fixed text-nowrap" AutoGenerateColumns="False" CellPadding="3" DataSourceID="tablas_cerrados_por_consultor_griv" GridLines="None" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" OnLoad="Grilla_cerrados_por_consultor_Load">
                                                <Columns>
                                                    <asp:BoundField DataField="nombre_usuario" HeaderText="Consultor" SortExpression="nombre_usuario" />
                                                    <asp:BoundField DataField="N_Ticket" HeaderText="Tickets cerrados" ReadOnly="True" SortExpression="N_Ticket" />
                                                </Columns>
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#33276A" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="Grafica_cerrados_agente_grafica" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select top (@top_cerrados) nombre_usuario, count(id_ticket) as N_Ticket from ticket 
  inner join usuario on usuario.id_usuario = ticket.usuario_id
  where estado_id = 5 and fecha_cierre_ticket between @fecha_inicio AND @fecha_fin group by nombre_usuario">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="list_top_cerrados" DbType="Int32" DefaultValue="5" Name="top_cerrados" PropertyName="SelectedValue" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" DefaultValue="0" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:SqlDataSource ID="tablas_cerrados_por_consultor_griv" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select nombre_usuario, count(id_ticket) as N_Ticket from ticket 
  inner join usuario on usuario.id_usuario = ticket.usuario_id
  where estado_id = 5 and fecha_cierre_ticket between @fecha_inicio AND @fecha_fin group by nombre_usuario">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" DefaultValue="0" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <%--  --%>
                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Label ID="lbl_fecha" Text="" runat="server" />
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="Btn_Todos_cerrados_por_agente" OnClick="Btn_Todos_cerrados_por_agente_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-6" style="margin: 0; height: 581px;">
                            <!-- Example Pie Chart Card-->
                            <div class="card mb-4">
                                <div class="card-header" style="background-color: #424C52; display: flex; justify-content: space-between; color: white">
                                    <i class="fa fa-pie-chart" style="color: white;"></i>Tickets creados y asignados
                                    <asp:Label ID="lbl_fecha_dia_hoy_ini" runat="server" Visible="false" />
                                    <asp:Label ID="lbl_fecha_dia_hoy_fin" runat="server" Visible="false" />
                                    <div>
                                        <asp:DropDownList ID="List_creados_asignados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List_creados_asignados_SelectedIndexChanged">
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="card-body" style="background-color: lightgray">
                                    <div style="display: flex; justify-content: space-around; margin-bottom: 20px;">
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label4" runat="server" Text="Fecha inicio" Font-Size="Medium"></asp:Label>

                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="Inp_fe_ini_creado_asignados" type="date" runat="server" style="font-size: medium; border-radius: 10px" />

                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label6" runat="server" Text="Fecha Fin" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="Inp_fe_fin_creado_asignados" type="date" runat="server" style="font-size: Medium; border-radius: 10px" />
                                            </div>

                                        </div>
                                        <div>
                                            <asp:Button Text="Buscar" CssClass="btn-ghost secundary round" runat="server" ID="Btn_buscar_creados_asignados" OnClick="Btn_buscar_creados_asignados_Click" />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Btn_buscar_creados_asignados" />
                                            <asp:AsyncPostBackTrigger ControlID="List_creados_asignados" />
                                        </Triggers>
                                        <ContentTemplate>

                                            <asp:Chart runat="server" ID="Grafica_abiertos_asignados_agente" DataSourceID="tickets_creados_y_asignados" Width="500px" OnLoad="Grafica_abiertos_asignados_agente_Load" Visible="true">
                                                <Series>
                                                    <asp:Series Name="Series1" XValueMember="Nombre_usuario_grfica_creados" YValueMembers="N_Ticket_grafica_creados"></asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                            <%----grilla----%>
                                            <asp:GridView ID="Grilla_tickets_creados" runat="server" AutoGenerateColumns="False" DataSourceID="Tickets_creados_asignados" CssClass="table table-head-fixed text-nowrap" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Nombre_usuario_grfica_creados" HeaderText="nombre_usuario" SortExpression="nombre_usuario" />
                                                    <asp:BoundField DataField="N_Ticket_grafica_creados" HeaderText="N_tickets" ReadOnly="True" SortExpression="N_tickets" />
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

                                            <asp:SqlDataSource ID="Tickets_creados_asignados" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select nombre_usuario, count(id_ticket) as N_tickets from ticket 
  inner join usuario on usuario.id_usuario = ticket.usuario_id
  where Fecha between @fecha_inicio AND @fecha_fin group by nombre_usuario">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                            <asp:SqlDataSource ID="tickets_creados_y_asignados" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select top (@top_creados) nombre_usuario, count(id_ticket) as N_tickets from ticket 
  inner join usuario on usuario.id_usuario = ticket.usuario_id
  where Fecha between @fecha_inicio AND @fecha_fin group by nombre_usuario">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="List_creados_asignados" DbType="Int32" DefaultValue="5" Name="top_creados" PropertyName="SelectedValue" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" DefaultValue="0" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="Btn_exportar_tickets_creados" OnClick="Btn_exportar_tickets_creados_Click" />

                                </div>
                            </div>
                        </div>
                        <div class="col-6" style="margin: 0; height: 581px;">


                            <div class="card mb-4" style="">
                                <div class="card-header" style="background-color: #424C52; display: flex; justify-content: space-between; color: white">
                                    <i class="fa fa-pie-chart"></i>Tickets trabajados
                                    <div>
                                        <asp:DropDownList ID="List_tickets_trabajados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List_tickets_trabajados_SelectedIndexChanged">
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="card-body" style="background-color: lightgray">
                                    <div style="display: flex; justify-content: space-around; margin-bottom: 20px;">
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label7" runat="server" Text="Fecha inicio" Font-Size="Medium"></asp:Label>

                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_trabajados_ini" type="date" runat="server" style="font-size: medium; border-radius: 10px" />

                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label8" runat="server" Text="Fecha Fin" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_trabajados_fin" type="date" runat="server" style="font-size: Medium; border-radius: 10px" />
                                            </div>

                                        </div>
                                        <div>
                                            <asp:Button Text="Buscar" CssClass="btn-ghost secundary round" runat="server" ID="Btn_buscar_trabajados" OnClick="Btn_buscar_trabajados_Click" />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Btn_buscar_trabajados" />
                                            <asp:AsyncPostBackTrigger ControlID="List_tickets_trabajados" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:Chart  ID="Grafica_Ticket_trabajados" runat="server" DataSourceID="tickets_trabajados" OnLoad="Grafica_Ticket_trabajados_Load" Width="500px">
                                                <Series  >
                                                    <asp:Series Name="Series1" XValueMember="nombre_usuario" YValueMembers="N_tickets"></asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>


                                            <asp:SqlDataSource ID="tickets_trabajados" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand=" select (@top_trabajados) nombre_usuario, 
(select count(*) from (select DISTINCT ticket_id from acta where fecha_crea_acta between @fecha_inicio and @fecha_fin and acta.fk_usuario_id = usuario.id_usuario )t ) as n_ticket
from usuario where usuario_Habilitado = 'Si' order by n_ticket desc  ">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="List_tickets_trabajados" DbType="Int32" DefaultValue="5" Name="top_trabajados" PropertyName="SelectedValue" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" DefaultValue="0" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>


                                            <%--grilla--%>
                                            <asp:GridView Visible="False" ID="Grilla_Ticket_trabajado_fecha" runat="server" AutoGenerateColumns="False" DataSourceID="Tickets_trabajados_driv" CssClass="table table-head-fixed text-nowrap" CellPadding="4" ForeColor="#333333" GridLines="None" OnLoad="Grilla_Ticket_trabajado_fecha_Load">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="nombre_usuario" HeaderText="nombre_usuario" SortExpression="nombre_usuario" />
                                                    <asp:BoundField DataField="n_ticket" HeaderText="n_ticket" ReadOnly="True" SortExpression="n_ticket" />
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



                                            <asp:SqlDataSource ID="Tickets_trabajados_driv" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand=" select nombre_usuario, 
(select count(*) from (select DISTINCT ticket_id from acta where fecha_crea_acta between @fecha_inicio and @fecha_fin and acta.fk_usuario_id = usuario.id_usuario )t ) as n_ticket
from usuario where usuario_Habilitado = 'Si' order by n_ticket desc ">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Label ID="Label5" Text="" runat="server" />
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="Btn_exportar_Trabajados" OnClick="Btn_exportar_Trabajados_Click" />
                                </div>

                            </div>
                            <div>

                                <asp:Panel runat="server" ID="panel1"></asp:Panel>
                            </div>
                        </div>
                        <%--</div>--%><%--fin fila 2--%>
                        <div class="col-6" style="margin: 0; height: 581px;">
                            <!-- Example Pie Chart Card-->
                            <div class="card mb-4">
                                <div class="card-header" style="background-color: #424C52; display: flex; justify-content: space-between; color: white">
                                    <i class="fa fa-pie-chart"></i>Tickets generados por Empresas
                                     <div>
                                         <asp:DropDownList ID="List_tick_empresas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List_tick_empresas_SelectedIndexChanged">
                                             <asp:ListItem>5</asp:ListItem>
                                             <asp:ListItem>10</asp:ListItem>
                                             <asp:ListItem>15</asp:ListItem>
                                         </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="card-body" style="background-color: lightgray">
                                    <div style="display: flex; justify-content: space-around; margin-bottom: 20px;">
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label10" runat="server" Text="Fecha inicio" Font-Size="Medium"></asp:Label>

                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fecha_ini_empresas" type="date" runat="server" style="font-size: medium; border-radius: 10px" />

                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label11" runat="server" Text="Fecha Fin" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fecha_fin_empresas" type="date" runat="server" style="font-size: Medium; border-radius: 10px" />
                                            </div>

                                        </div>
                                        <div>
                                            <asp:Button Text="Buscar" CssClass="btn-ghost secundary round" runat="server" ID="Btn_buscar_empresas" OnClick="Btn_buscar_empresas_Click" />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Btn_buscar_empresas" />
                                            <asp:AsyncPostBackTrigger ControlID="List_tick_empresas" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:Chart ID="Grafica_tickets_por_empresa" runat="server" DataSourceID="tabla_ticket_empresa_graf" Palette="Bright" Width="500px" OnLoad="Grafica_tickets_por_empresa_Load" BackImageAlignment="Bottom">
                                                <Series>
                                                    <asp:Series Name="Series1" XValueMember="nombre_empresa" YValueMembers="N_Tickets" YValuesPerPoint="4"></asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>

                                            <%--grillaa empresas--%>
                                            <asp:GridView Visible="false" ID="grilla_tickets_por_empresa" runat="server" AutoGenerateColumns="False" DataSourceID="tabla_ticket_empresa_grid" CssClass="table table-head-fixed text-nowrap" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="nombre_empresa" HeaderText="Empresa" SortExpression="nombre_empresa" />
                                                    <asp:BoundField DataField="N_tickets" HeaderText="N tickets" ReadOnly="True" SortExpression="N_tickets" />
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
                                            <%--grillaa empresas--%>
                                            <asp:SqlDataSource ID="tabla_ticket_empresa_graf" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select top (@top_empresas) nombre_empresa, COUNT(id_Empresa) as N_tickets from ticket 
 inner join cliente on cliente.id_Cliente = ticket.cliente_id
 inner join empresa on empresa.id_empresa = cliente.empresa_id 
where Fecha between @fecha_inicio AND @fecha_fin group by nombre_empresa order by COUNT (2)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="List_tick_empresas" DbType="Int32" DefaultValue="5" Name="top_empresas" PropertyName="SelectedValue" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" DefaultValue="0" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:SqlDataSource ID="tabla_ticket_empresa_grid" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select nombre_empresa, COUNT(id_Empresa) as N_tickets from ticket 
 inner join cliente on cliente.id_Cliente = ticket.cliente_id
 inner join empresa on empresa.id_empresa = cliente.empresa_id
 group by nombre_empresa
 order by COUNT (2)"></asp:SqlDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Label ID="Label1" Text="" runat="server" />
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="exportar_empresa" OnClick="exportar_empresa_Click" />
                                </div>
                            </div>


                        </div>
                        <div class="col-6" style="margin: 0; height: 581px;">
                            <!-- Example Pie Chart Card-->
                            <div class="card mb-4">
                                <div class="card-header" style="display: flex; justify-content: center; background-color: #424C52; color: white">
                                    <i class="fa fa-pie-chart"></i>Estados 
                                </div>
                                <div class="card-body" style="background-color: lightgray">
                                    <div style="display: flex; justify-content: space-around; margin-bottom: 20px;">
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label12" runat="server" Text="Fecha inicio" Font-Size="Medium"></asp:Label>

                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fecha_ini_estados" type="date" runat="server" style="font-size: medium; border-radius: 10px" />

                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label13" runat="server" Text="Fecha Fin" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fecha_fin_estados" type="date" runat="server" style="font-size: Medium; border-radius: 10px" />
                                            </div>

                                        </div>
                                        <div>
                                            <asp:Button Text="Buscar" CssClass="btn-ghost secundary round" runat="server" ID="Btn_buscar_estados" OnClick="Btn_buscar_estados_Click" />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Btn_buscar_estados" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:Chart ID="Grafica_tickets_por_estado" runat="server" DataSourceID="ticket_estados_" Height="342px" Width="500px" ImageType="Jpeg" ImageStorageMode="UseImageLocation" ViewStateMode="Enabled" OnLoad="Grafica_tickets_por_estado_Load">
                                                <Series>
                                                    <asp:Series Name="Series1" XValueMember="estado_Ticket" YValueMembers="N_tickets"></asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                            <%--grillaa estados--%>
                                            <asp:GridView Visible="false" ID="Grilla_por_estados" runat="server" CssClass="table table-head-fixed text-nowrap" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ticket_estados_grid" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="estado_Ticket" HeaderText="Estado" SortExpression="estado_Ticket" />
                                                    <asp:BoundField DataField="N_tickets" HeaderText="N tickets" ReadOnly="True" SortExpression="N_tickets" />
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                <SortedDescendingHeaderStyle BackColor="#820000" />
                                            </asp:GridView>
                                            <%--grillaa estados--%>
                                            <asp:SqlDataSource ID="ticket_estados_" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand=" select  estado_Ticket, COUNT(id_Estado_Ticket) as N_tickets from ticket 
inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id where Fecha between @fecha_inicio AND @fecha_fin group by estado_Ticket order by COUNT (2)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:SqlDataSource ID="ticket_estados_grid" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand=" select  estado_Ticket, COUNT(id_Estado_Ticket) as N_tickets from ticket 
inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id where Fecha between @fecha_inicio AND @fecha_fin group by estado_Ticket order by COUNT (2)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" DefaultValue="0" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" ConvertEmptyStringToNull="False" DbType="DateTime" DefaultValue="0" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Label ID="Label2" Text="" runat="server" />
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="Btn_exportar_tickets_estados" OnClick="Btn_exportar_tickets_estados_Click" />
                                </div>
                            </div>
                        </div>
                        <%--</div>--%>                     <%--fila3-----------------------------------------------------%><%--<div class="row">--%>
                        <div id="creditos" class="col-6" style="margin: 0;">


                            <div class="card mb-4" style="height: 570px">
                                <div class="card-header" style="display: flex; justify-content: space-between; background-color: #424C52; color: white">
                                    <i class="fa fa-pie-chart"></i>Creditos por consultor
                                    <div>
                                        <asp:DropDownList ID="List_creditos_consult" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List_creditos_consult_SelectedIndexChanged">
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="card-body" style="overflow: auto; background-color: lightgray">
                                    <div style="display: flex; justify-content: space-around; margin-bottom: 20px;">
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label14" runat="server" Text="Fecha inicio" Font-Size="Medium"></asp:Label>

                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fecha_ini_creditos" type="date" runat="server" style="font-size: medium; border-radius: 10px" />

                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label15" runat="server" Text="Fecha Fin" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_fecha_fin_creditos" type="date" runat="server" style="font-size: Medium; border-radius: 10px" />
                                            </div>

                                        </div>
                                        <div>
                                            <asp:Button Text="Buscar" CssClass="btn-ghost secundary round" href="#creditos" runat="server" ID="Btn_Buscar_creditos" OnClick="Btn_Buscar_creditos_Click" />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Btn_Buscar_creditos" />
                                            <asp:AsyncPostBackTrigger ControlID="List_creditos_consult" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:GridView ID="Grilla_creditos_tickets" runat="server" AutoGenerateColumns="False" DataSourceID="N_creditos_consultor" CssClass="table table-head-fixed text-nowrap" CellPadding="4" ForeColor="#333333" GridLines="None" OnLoad="Grilla_creditos_tickets_Load">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="nombre_usuario" HeaderText="Consultor" SortExpression="nombre_usuario" />
                                                    <asp:BoundField DataField="N_tickets" HeaderText="N actas" ReadOnly="True" SortExpression="N_tickets" />
                                                    <asp:BoundField DataField="N_creditos" HeaderText="N creditos" ReadOnly="True" SortExpression="N_creditos" />
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
                                            <asp:GridView Visible="false" ID="Grilla_creditos_tickets2" runat="server" AutoGenerateColumns="False" DataSourceID="N_creditos_consultor2" CssClass="table table-head-fixed text-nowrap" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="nombre_usuario" HeaderText="Consultor" SortExpression="nombre_usuario" />
                                                    <asp:BoundField DataField="N_tickets" HeaderText="N actas" ReadOnly="True" SortExpression="N_tickets" />
                                                    <asp:BoundField DataField="N_creditos" HeaderText="N creditos" ReadOnly="True" SortExpression="N_creditos" />
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
                                            <asp:SqlDataSource ID="N_creditos_consultor" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="SELECT * FROM [acta]"></asp:SqlDataSource>
                                            <asp:SqlDataSource ID="N_creditos_consultor2" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="select nombre_usuario, count(ticket.id_ticket) as N_tickets, sum(n_creditos_acta) as N_creditos from acta
inner join ticket on ticket.id_ticket = acta.ticket_id
inner join usuario on usuario.id_usuario = acta.fk_usuario_id 
where acta.fecha_crea_acta  between @fecha_inicio AND @fecha_fin  group by nombre_usuario">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DbType="DateTime" Name="fecha_inicio" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DbType="DateTime" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Label ID="Label3" Text="" runat="server" />
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="Btn_creditos_por_consultor" OnClick="Btn_creditos_por_consultor_Click" />
                                </div>
                            </div>
                            <div>
                                <asp:Panel runat="server" ID="panel_grilla"></asp:Panel>
                            </div>
                        </div>
                        <div class="col-6" style="margin: 0; height: 500px; overflow: auto;">
                            <!-- Example Pie Chart Card-->
                            <div class="card mb-4" style="left: 0px; top: 0px;">
                                <div class="card-header" style="background-color: #424C52; display: flex; justify-content: space-between; color: white;">
                                    <div>
                                        <i class="fa fa-pie-chart" style="text-decoration-color: white"></i>Ticket Sin Responder consultor                                    
                                    </div>
                                   
                                </div>
                                <div class="card-body" style="background-color: lightgray">
                                    <asp:Chart ID="Chart_usuario" runat="server" RightToLeft="Yes" Width="509px" CssClass="accordion">
                                <Series >
                                    <asp:Series Name="Series1" IsValueShownAsLabel="true" ChartType="Bar" IsVisibleInLegend="True" XAxisType="Secondary" YAxisType="Secondary"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                                </asp:Chart>
                                    <%--  --%>
                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="Button2"  />
                                </div>
                            </div>
                        </div>
                        <div class="col-6" style="height: 500px;margin: 0;  overflow: auto;">
                            <!-- Example Pie Chart Card-->
                            <div class="card mb-4" style="left: 0px; top: 0px; ">
                                <div class="card-header" style="background-color: #424C52; display: flex; justify-content: space-between; color: white; ">
                                    <div>
                                        <i class="fa fa-pie-chart" style="text-decoration-color: white"></i>Ticket Sin responder cliente                                      
                                    </div>
                                </div>
                                <div class="card-body" style="background-color: lightgray">
                                  <asp:Chart ID="Chart_cliente" runat="server" RightToLeft="Yes" Width="578px">
                                <Series>
                                    <asp:Series Name="Series1" IsValueShownAsLabel="true" ChartType="Bar" ></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                                <BorderSkin BackColor="Transparent" BorderColor="Transparent" />
                            </asp:Chart>
                                    <%--  --%>
                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52; height: 60px">
                                    <asp:Button Text="Exportar" class="btn-ghost round" runat="server" ID="Button1"  />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--fin fila 3--%>
                    <div class="row">
                        <div class="col-12">
                            <div class="card mb-4">
                                <div class="card-header" style="background-color: #424C52; align-content: center;">
                                    <i class="fa fa-pie-chart"></i>Informe                                       
                                </div>
                                <div class="card-body">

                                    <div style="display: flex; justify-content: space-around; margin-bottom: 20px;">
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label16" runat="server" Text="Fecha inicio" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_Fecha_ini_info" type="date" runat="server" style="font-size: medium" />
                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="">
                                                <asp:Label ID="Label17" runat="server" Text="Fecha Fin" Font-Size="Medium"></asp:Label>
                                            </div>
                                            <div style="display: flex; padding: 0;">
                                                <input id="inp_Fecha_fin_info" type="date" runat="server" style="font-size: Medium" />
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Button Text="Buscar" runat="server" ID="Btn_buscar_informe" OnClick="Btn_buscar_informe_Click" />
                                        </div>
                                    </div>
                                    <%--<--grafica de -->--%>
                                    <asp:UpdatePanel runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Btn_buscar_informe" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:GridView ID="Grilla_informe" runat="server" DataSourceID="informe3" AutoGenerateColumns="False" DataKeyNames="id_usuario" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1175px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" InsertVisible="False" ReadOnly="True" SortExpression="id_usuario" Visible="false" />
                                                    <asp:BoundField DataField="prefijo_usuario" HeaderText="Consultor" SortExpression="nombre_usuario">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="n_ticket_nuevos_dia" HeaderText="Número de casos(Inicio jornada)" ReadOnly="True" SortExpression="n_ticket_nuevos_dia">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="n_ticket_nuevos_dia_jornada" HeaderText="Número de casos nuevos(Día)" ReadOnly="True" SortExpression="n_ticket_nuevos_dia_jornada">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="n_ticket_Resueltos_hoy" HeaderText="Número de casos resuletos" ReadOnly="True" SortExpression="n_ticket_Resueltos_hoy">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="n_ticket_cerrados_hoy" HeaderText="Número de casos cerrados (Final día) " ReadOnly="True" SortExpression="n_ticket_cerrados_hoy">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="N_casos_abierto_cierre_jornada" HeaderText="Número de casos abiertos (Cierre de jornada)" ReadOnly="True" SortExpression="N_casos_abierto_cierre_jornada">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="n_ticket_desarrollo" HeaderText="Número de casos que corresponden a desarrollo" ReadOnly="True" SortExpression="n_ticket_desarrollo">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="n_ticket_incidente" HeaderText="Número de casos que corresponden a incidentes" ReadOnly="True" SortExpression="n_ticket_incidente">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="n_ticket_proyecto" HeaderText="Número de casos que corresponden a proyecto" ReadOnly="True" SortExpression="n_ticket_proyecto" />
                                                    <asp:BoundField DataField="n_creditos_hoy" HeaderText="Número de créditos facturados" ReadOnly="True" SortExpression="n_creditos_hoy">
                                                        <HeaderStyle />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" Wrap="False" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="informe3" runat="server" ConnectionString="<%$ ConnectionStrings:Myconect %>" SelectCommand="informe3" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_ini" DefaultValue="0" DbType="DateTime" Name="fecha_ini" PropertyName="Text" />
                                                    <asp:ControlParameter ControlID="lbl_fecha_dia_hoy_fin" DefaultValue="0" DbType="DateTime" Name="fecha_fin" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="card-footer small text-muted" style="background-color: #424C52;">
                                    <asp:Label ID="Label18" Text="" runat="server" />
                                    <asp:Button Text="Exportar" runat="server" ID="Btn_exportar_informe" OnClick="Btn_exportar_informe_Click" />
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
