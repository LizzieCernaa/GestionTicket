<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil_Usuario.aspx.cs" Inherits="DynaIT.app.forms.perfil_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DynamicsIT</title>
    <link href="../style/Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />   
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://kit.fontawesome.com/474279b2ec.js" crossorigin="anonymous"></script>
    <link href="../style/Botones.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            display: block;
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin: 0; padding: 0; height: auto; overflow:hidden;">
        <div class="row" style="margin: 0; padding: 0; display:flex" >
            <div class="col-2 menuLateral" style="margin: 0; padding: 0; ">
                <div>
                    <div >
                    <ul style="padding:8px;" class="conten__menu">
                        <li class="margenlogo" style="padding: 0; text-align:center; align-items:center;">
                            <img class="img__logo" src="../img/logohelptikets-negro.png" />

                            <img class="img__logo2" src="../img/help%20tickets%20-%20HT.png" />
                                <%--<div class="imgLogin">

                                    <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                                        <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                                        <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z" />
                                    </svg>
                                </div>--%>
                        </li>
                        <li>  <button type="button" class="btn btn" data-toggle="modal" data-target="#adjuntos_ticket"  style="padding: 0; font-size: 100%;" id="Btn_crear_cliente"> <i class="fa-solid fa-address-card" style="font-size: 15px;margin-right: 5px;"></i><asp:Label ID="lbl_nombre_usuario" Font-Size="Small" runat="server" Text="nombre usuario"></asp:Label></button></li>
                        <li> <asp:Label ID="Lbl_cargo" runat="server" Text="cargo usuario" Font-Size="Small" Visible="false"></asp:Label></li>
                        <li> <i class="fa-solid fa-user-tie" style="font-size: 15px;margin-right: 5px;"></i> <asp:Label ID="Lbl_cargo_tex" runat="server" Text="cargo usuario" Font-Size="Small" ></asp:Label></li>
                        <li id="Li_Dashboard" runat="server">  <a href="Bandeja_Entrada.aspx" target="eliframe" > <i class="fa-solid fa-chart-line" style="font-size: 15px;margin-right: 5px;"></i> DASHBOARD</a></li>
                        <asp:Label ID="lbl_correo_usuario" runat="server" Text="lbl_correo_usuario" Visible="False"></asp:Label>
                        <asp:Label ID="lbl_correo_cliente" runat="server" Text="lbl_correo_cliente" Visible="False"></asp:Label>
                        <li  id="Div_menu_tickets" runat="server" visible="false">
                            <div class="dropdown" aria-orientation="horizontal" >
                                <a class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" >
                                    <i class="fa-solid fa-ticket-simple" style="font-size: 15px;margin-right: 5px;"></i>TICKETS
                                </a>
                                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                    <a runat="server" class="dropdown-item" href="Generar_Ticket_usuario.aspx" target="eliframe" id="idGenerar_Ticket">Crear TICKET</a>
                                    <a class="dropdown-item" href="Tickets_Generados_Usuario.aspx" target="eliframe">Todos los ticket</a> 
                                </div>               
                            </div>
                        </li>

                         <li  id="li_acta" runat="server" visible="true">
                            <div class="dropdown">
                                <a class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fa-solid fa-clipboard-list" style="font-size: 15px;margin-right: 5px;"></i> ACTAS
                                </a>
                                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                    <a runat="server" class="dropdown-item" href="Lista_actas.aspx" target="eliframe" id="A1">Total actas</a>
                                    
                                </div>
                                    
                            </div>

                        </li>

                        <%--Empresas y clientes--%>
                         <li id="Div_empresas_clientes" runat="server" visible="false">
                            <div class="dropdown">
                                <a id="empresas_clientes" runat="server" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fa-solid fa-city" style="font-size: 15px;margin-right: 5px;"></i>EMPRESAS Y CLIENTES 
                                </a>
                                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                    <a id="a_crearEmpresa" runat="server" class="dropdown-item" href="Crear_Empresa.aspx" target="eliframe">Empresa</a>
                                    <a class="dropdown-item"  href="Crear_Cliente.aspx " target="eliframe">Clientes</a>
                                </div>
                            </div>

                        </li>
                        <%--usuarios y grupos--%>
                        <li id="Div_usuarios_grupos" runat="server" visible="false">
                            <div class="dropdown" >
                                <a class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fa-solid fa-users" style="font-size: 15px;margin-right: 5px;"></i> USUARIOS Y GRUPOS
                                </a>
                                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton" style="padding:0;">
                                    <a class="dropdown-item" href="Crear_Usuario.aspx " target="eliframe">Usuario</a>
                                    <a class="dropdown-item" href="Crear_Grupo_Usuario.aspx" target="eliframe">Areas</a>                                   
                                </div>
                            </div>
                          </li>
                        <%--Actualizaciones--%>
                        <li id="Div_actualizaciones" runat="server" visible="false">
                            <div class="dropdown">
                                <a class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fa-solid fa-arrows-rotate" style="font-size: 15px;margin-right: 5px;"></i>ACTUALIZACIONES
                                </a>
                                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton" style="padding:0;">
                                    <a class="dropdown-item" href="crear_Estados_Ticket.aspx" target="eliframe">Agregar estados</a>
                                    <a class="dropdown-item" href="Crear_tipos_ticket.aspx" target="eliframe">Agregar tipos de tickets</a>
                                    

                                </div>
                            </div>
                        </li>
                                        
                        
                        <li><a href="../login.aspx">CERRAR SESIÓN</a></li>
                    </ul>
                </div>
            </div>
            </div>
            <!-- menu central -->
            <div class="col-10 " style="margin:0; padding:0; ">
                <div >

                    <iframe src="Tickets_Generados_Usuario.aspx" name="eliframe" id="eliframe"></iframe>

                </div>

            </div>

        </div>
    </div>
       <!-- Modal para el boton del ticket  el cual carga los adjuntos del ticket -->
                                <div class="modal fade" id="adjuntos_ticket" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                           <asp:ScriptManager ID="scripMananer_panel_crear_cliente" runat="server" />
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                           <%--   <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">Archivos adjuntos del ticket</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>--%>
                                            <div class="modal-body">
                                                 <div class="modal_picture" style="width:90%; margin: 0 auto; max-width: 40px; margin-bottom: 2rem;">
                                                    <%--<img src="../img/Dynamicsimg.png" />--%>
                                                    </div>
                                                 <h2 class="modal_title">¡Buen dia ! <spam class=" modal_title-bold"><asp:Label id="lbl_nombre_usu_modal" runat="server" /></spam>
                                                    </h2><p class="modal_paragraph">Contraseña nueva:  </p>
                                                    <div>
                                                        <asp:textbox ID="txt_nueva_contrasena_1" runat="server" name="txt_nueva_contrasena_1" MaxLength="14" type="password" />                                                            
                                                        <p id="validador_contrasena1" runat="server" visible="false"> La contraseñas no coinciden</p>
                                                    </div>
                                                <p class="modal_paragraph">Repita la contraseña:  </p>
                                                    <div>
                                                        <asp:textbox ID="txt_nueva_contrasena_2" name="txt_nueva_contrasena_2" value="" runat="server" MaxLength="14" type="password"/>  
                                                        <p id="validador_contrasena2" runat="server" visible="false"> La contraseñas no coinciden</p>
                                                    </div>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button Text="Actializar" runat="server" ID="Btn_actualizar_datos" OnClick="Btn_actualizar_datos_Click" />   
                                                <button runat="server" type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                            </div>
                                             </ContentTemplate>
                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                    <%--fin del modal--%>

    </form>
</body>
</html>
