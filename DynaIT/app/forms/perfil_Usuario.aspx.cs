//using MySql.Data;
//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Web.UI;

namespace DynaIT.app.forms
{
    public partial class perfil_Usuario : System.Web.UI.Page
    {

        Clase_Parametros clase_Parametros = new Clase_Parametros();
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        static string correo, rol_inicio_usuario, rol_inicio_cliente;
        static int id_usuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
            if (Request.QueryString["correos"] == null)

                return;

            correo = Request.QueryString["correos"].ToString();

            //se declara la variable tipo sesión que permite llevar datos o cadenas de string entre formularios           
            Session["correos_inicio_sesion"] = correo;
            cargar_datos_ticket();
            ocultar_div();

            //}


        }
        private void cargar_datos_ticket()
        {
            rol_inicio_usuario = (string)Session["rol_usuario"];
            rol_inicio_cliente = (string)Session["rol_cliente"];

            lbl_correo_cliente.Text = rol_inicio_cliente;
            lbl_correo_usuario.Text = rol_inicio_usuario;


            if (rol_inicio_usuario != null)
            {
                clase_Parametros = Gestion_Datos.traer_nombre_rol_Usuario(correo);

                id_usuario = clase_Parametros.Id_usuario;
                lbl_nombre_usuario.Text = clase_Parametros.Nombre_Usuario;
                Lbl_cargo.Text = Convert.ToString(clase_Parametros.Rol_usuario);
                Lbl_cargo_tex.Text = clase_Parametros.Rol_usu_tex;

                lbl_nombre_usu_modal.Text = lbl_nombre_usuario.Text;

            }
            else
            {
                if (rol_inicio_cliente != null)
                {


                    clase_Parametros = Gestion_Datos.traer_nombre_rol_cliente(correo);

                    id_usuario = clase_Parametros.idCliente;
                    lbl_nombre_usuario.Text = clase_Parametros.Nombre_Cliente;
                    Lbl_cargo.Text = Convert.ToString(clase_Parametros.Rol_Cliente);
                    int Id_Empresa_cliente = clase_Parametros.Id_Empresa_cliente;
                    Lbl_cargo_tex.Text = clase_Parametros.Rol_Cli;
                    lbl_nombre_usu_modal.Text = lbl_nombre_usuario.Text;
                }
            }



        }



        private void ocultar_div()
        {
            if (Lbl_cargo.Text == "3")
            {
                Div_menu_tickets.Visible = true;
                idGenerar_Ticket.Visible = false;
                li_acta.Visible = false;
                Li_Dashboard.Visible = false;
            }
            else
            {
                if (Lbl_cargo.Text == "2")
                {
                    Div_menu_tickets.Visible = true;
                    Div_empresas_clientes.Visible = true;
                    Div_usuarios_grupos.Visible = true;
                    Div_actualizaciones.Visible = true;
                }
                else
                {
                    if (Lbl_cargo.Text == "5")
                    {
                        Div_menu_tickets.Visible = true;
                        li_acta.Visible = false;
                        Li_Dashboard.Visible = false;
                    }
                    else
                    {
                        if (Lbl_cargo.Text == "4")
                        {
                            Div_menu_tickets.Visible = true;
                            Div_empresas_clientes.Visible = true;

                            a_crearEmpresa.Visible = false;
                            li_acta.Visible = false;
                            Li_Dashboard.Visible = false;

                        }
                    }

                }

            }
        }


        protected void Btn_actualizar_datos_Click(object sender, EventArgs e)
        {
            string expresion = @"([a-zA-Z0-9]{14})";


            txt_nueva_contrasena_1.Text = txt_nueva_contrasena_1.Text.TrimStart();
            txt_nueva_contrasena_2.Text = txt_nueva_contrasena_2.Text.TrimStart();

            if (txt_nueva_contrasena_1.Text.Contains(" "))
            {
                validador_contrasena1.Visible = true;
                validador_contrasena1.InnerText = "No debe contener espacios";
                validador_contrasena1.Style["color"] = "red";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_nueva_contrasena_1.Text))
                {
                    validador_contrasena1.Visible = true;
                    validador_contrasena1.InnerText = "Campo vacio";
                    validador_contrasena1.Style["color"] = "red";
                }
                else
                {

                    validador_contrasena1.Visible = false;

                    if (txt_nueva_contrasena_2.Text.Contains(" "))
                    {
                        validador_contrasena2.Visible = true;
                        validador_contrasena2.InnerText = "No debe contener espacios";
                        validador_contrasena2.Style["color"] = "red";
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txt_nueva_contrasena_2.Text))
                        {
                            validador_contrasena2.Visible = true;
                            validador_contrasena2.InnerText = "Campo vacio";
                            validador_contrasena2.Style["color"] = "red";
                        }
                        else
                        {
                            validador_contrasena2.Visible = false;

                            if (txt_nueva_contrasena_1.Text.Contains(expresion) && txt_nueva_contrasena_2.Text.Contains(expresion))
                            {
                                if (txt_nueva_contrasena_1.Text == txt_nueva_contrasena_2.Text)
                                {
                                    if (rol_inicio_cliente != null)
                                    {
                                        clase_Parametros.idCliente = id_usuario;
                                        clase_Parametros.Contraseña = txt_nueva_contrasena_1.Text;

                                        if (Gestion_Datos.Cambio_clave_Cli(clase_Parametros) == true)
                                        {
                                            validador_contrasena1.Visible = false;
                                            validador_contrasena2.Visible = false;
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Cambio de contraseña exitosa', confirmButtonText: 'Ok' })  ", true);
                                            txt_nueva_contrasena_1.Text = "";
                                            txt_nueva_contrasena_2.Text = "";
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos', confirmButtonText: 'Ok' })  ", true);
                                        }
                                    }
                                    else
                                    {
                                        if (rol_inicio_usuario != null)
                                        {
                                            clase_Parametros.Id_usuario = id_usuario;
                                            clase_Parametros.Contraseña_Usuario = txt_nueva_contrasena_1.Text;

                                            if (Gestion_Datos.Cambio_clave_usu(clase_Parametros) == true)
                                            {
                                                validador_contrasena1.Visible = false;
                                                validador_contrasena2.Visible = false;
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Cambio de contraseña exitosa', confirmButtonText: 'Ok' })  ", true);
                                                txt_nueva_contrasena_1.Text = "";
                                                txt_nueva_contrasena_2.Text = "";
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos', confirmButtonText: 'Ok' })  ", true);
                                            }

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos', confirmButtonText: 'Ok' })  ", true);
                                        }
                                    }



                                }
                                else
                                {

                                    //ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: '', confirmButtonText: 'Ok' })  ", true);
                                    validador_contrasena1.Visible = true;
                                    validador_contrasena1.Style["color"] = "red";
                                    validador_contrasena1.InnerText = "Las contraseñas no coinciden";

                                    validador_contrasena2.Visible = true;
                                    validador_contrasena2.Style["color"] = "red";
                                    validador_contrasena2.InnerText = "Las contraseñas no coinciden";
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'La contraseña debe tener Mayusculas minusculas y numeros, minimo 12 caracteres y maximo 14', confirmButtonText: 'Ok' })  ", true);
                            }
                        }

                    }
                }
            }



        }


    }
}