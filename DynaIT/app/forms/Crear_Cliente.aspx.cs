//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynaIT.app.forms
{
    public partial class Crear_Cliente : System.Web.UI.Page
    {
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        Clase_Parametros myParametro = new Clase_Parametros();
        Validaciones myvalidacion = new Validaciones();
        static string correo, rol_inicio_usuario, rol_inicio_cliente;
        static int Id_Empresa_cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            correo = (string)Session["correos_inicio_sesion"];
            if (!IsPostBack)
            {
                cargar_datos_sesion();

            }

            Txt_Contraseña.Enabled = false;
            Btn_ver_deshabilitados.Visible = true;

        }


        private void cargar_datos_sesion()
        {
            rol_inicio_usuario = (string)Session["rol_usuario"];
            rol_inicio_cliente = (string)Session["rol_cliente"];




            if (rol_inicio_usuario != null)
            {


            }
            else
            {
                if (rol_inicio_cliente != null)
                {

                    myParametro = Gestion_Datos.traer_nombre_rol_cliente(correo);

                    int id_usuario = myParametro.idCliente;
                    Lbl_cargo.Text = Convert.ToString(myParametro.Rol_Cliente);
                    Id_Empresa_cliente = myParametro.Id_Empresa_cliente;

                    if (Lbl_cargo.Text == "4")
                    {
                        Grilla_Cliente.DataSourceID = "";

                        List<Visualizar_Tickets> visualiza = Gestion_Datos.traer_clientes_empresa(Lbl_Ver_Eliminados.Text, Id_Empresa_cliente);
                        Grilla_Cliente.DataSource = visualiza;
                        Grilla_Cliente.DataBind();

                        List_Empresa.Enabled = false;

                        List_Empresa.SelectedValue = Convert.ToString(Id_Empresa_cliente);
                    }

                }
            }



        }
        protected void BtnCrearCliente_Click(object sender, EventArgs e)
        {
            String expresion;
            //"\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w[])*";
            expresion = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([A-Za-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            if (Regex.IsMatch(Txt_CorreoCliente.Text, expresion))
            {
                if (List_Empresa.SelectedValue == "1")         // valida si no se ha seleccionado una empresa
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Seleccione la empresa a la cual pertenece el cliente ', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(Txt_NombreCliente.Text))         // me valida si el campo Txt_TemaConsultoria esta vacio si lo esta me muestra un cuadro de dialogo
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Campo vacio', text: 'El campo nombre esta vacio', confirmButtonText: 'Ok' })  ", true);
                    }
                    else
                    {

                        if (string.IsNullOrWhiteSpace(Txt_CorreoCliente.Text))     // me valida si el campo txt_Valor_TiempoSancion esta vacio si lo esta me muestra un cuadro de dialogo
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Campo vacio', text: 'El campo correo esta vacio', confirmButtonText: 'Ok' })  ", true);
                        }
                        else
                        {

                            if (string.IsNullOrWhiteSpace(Txt_TelefonoCliente.Text))      // me valida si el campo txt_Motivo esta vacio si lo esta me muestra un cuadro de dialogo
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Campo vacio', text: 'El campo telefono esta vacio', confirmButtonText: 'Ok' })  ", true);
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(Txt_Contraseña.Text))      // me valida si el campo txt_Motivo esta vacio si lo esta me muestra un cuadro de dialogo
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Campo vacio', text: 'El campo contraseña esta vacio', confirmButtonText: 'Ok' })  ", true);
                                }
                                else
                                {
                                    if (!myvalidacion.Existe_Correo_cliente(Txt_CorreoCliente.Text))
                                    {

                                        if (!myvalidacion.Existe_Correo_usuario(Txt_CorreoCliente.Text))
                                        {
                                            if (Check_VisualizarTickets.Checked == true)
                                            {
                                                Txt_VisualizarTickets.Text = "4";
                                            }
                                            else
                                            {
                                                Txt_VisualizarTickets.Text = "5";
                                            }

                                            //myParametro = Gestion_Datos.traerID_Empresa(Txt_Empresa.Text);
                                            //Txt_Fk_Empresas.Text = myParametro.Fk_Empresa;

                                            myParametro.Nombre_Cliente = Txt_NombreCliente.Text;
                                            myParametro.Correo_Cliente = Txt_CorreoCliente.Text;
                                            myParametro.Telefono_Cliente = Txt_TelefonoCliente.Text;
                                            myParametro.Rol_Cliente = Convert.ToInt32(Txt_VisualizarTickets.Text);
                                            myParametro.Contraseña = Txt_Contraseña.Text;
                                            myParametro.Fk_Empresa = Convert.ToInt32(List_Empresa.SelectedValue);

                                            if (!Gestion_Datos.insertar_Cliente(myParametro))                //Me realiza la inserciona la tabla Ticket 
                                            {

                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Campo vacio', text: ' Error de datos', confirmButtonText: 'Ok' })  ", true);
                                            }
                                            else
                                            {

                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Datos creados', confirmButtonText: 'Ok' })  ", true);

                                                List_Empresa.SelectedValue = "1";
                                                Txt_NombreCliente.Text = "";
                                                Txt_CorreoCliente.Text = "";
                                                Txt_TelefonoCliente.Text = "";
                                                Check_VisualizarTickets.Checked = false;
                                                Txt_Contraseña.Text = "";
                                                cargar_datos_sesion();
                                                Txt_CorreoCliente.Enabled = true;

                                                Grilla_Cliente.DataBind();

                                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_cliente').modal('hide');", true);
                                            }
                                        }
                                        else
                                        {

                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'El correo ya se encuentra registrado para un usuario', confirmButtonText: 'Ok' })  ", true);
                                        }
                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'El correo ya se encuentra registrado para un cliente', confirmButtonText: 'Ok' })  ", true);
                                    }


                                }
                            }
                        }
                    }
                }

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'la direccion de correo no es valida', confirmButtonText: 'Ok' })  ", true);
            }
        }

        protected void Grilla_crear_cliente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grilla_Cliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(Grilla_Cliente.DataKeys[index].Value);
                Lbl_id_cliente.Text = (valor);

                myParametro = Gestion_Datos.traer_Cliente_editar(Lbl_id_cliente.Text);
                List_Empresa.SelectedValue = Convert.ToString(myParametro.Fk_Empresa);
                Txt_NombreCliente.Text = myParametro.Nombre_Cliente;
                Txt_CorreoCliente.Text = myParametro.Correo_Cliente;
                Txt_TelefonoCliente.Text = myParametro.Telefono_Cliente;
                Txt_VisualizarTickets.Text = Convert.ToString(myParametro.Rol_Cliente);



                if (Txt_VisualizarTickets.Text == "4")
                {
                    Check_VisualizarTickets.Checked = true;
                }
                else
                {
                    Check_VisualizarTickets.Checked = false;
                }

                Btn_Editar.Visible = true;
                BtnCrearCliente.Visible = false;
                Txt_CorreoCliente.Enabled = false;
                Grilla_Cliente.DataBind();
                cargar_datos_sesion();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_cliente').modal();", true);



            }
            else
            {
                if (e.CommandName == "Eliminar")
                {

                    int index = Convert.ToInt32(e.CommandArgument);
                    string valor = Convert.ToString(Grilla_Cliente.DataKeys[index].Value);
                    Lbl_id_cliente.Text = (valor);

                    myParametro = Gestion_Datos.traer_Cliente_editar(Lbl_id_cliente.Text);


                    if (myvalidacion.Existe_cliente_vinculado_aTicket(Convert.ToInt32(Lbl_id_cliente.Text)) == false)
                    {
                        myParametro.Id_cliente = Lbl_id_cliente.Text;
                        myParametro.cliente_habilitado = "No";
                        if (Gestion_Datos.Actualizar_Cliente_Habilitado(myParametro))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se elimino el cliente correctamente', confirmButtonText: 'Ok' })  ", true);
                            Grilla_Cliente.DataBind();
                            cargar_datos_sesion();

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error al eliminar', confirmButtonText: 'Ok' })  ", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'El cliente tiene tickets creados',text: 'Se deben reasignar a un usuario habilitado', confirmButtonText: 'Ok' })  ", true);
                    }




                }
                else
                {
                    if (e.CommandName == "Restaurar")
                    {
                        int index = Convert.ToInt32(e.CommandArgument);
                        string valor = Convert.ToString(Grilla_Cliente.DataKeys[index].Value);
                        Lbl_id_cliente.Text = (valor);

                        //myParametro = Gestion_Datos.traerID_Empresa_con_idCliente(Convert.ToInt32(Lbl_id_cliente.Text));
                        myParametro = Gestion_Datos.traer_Cliente_editar(Lbl_id_cliente.Text);

                        Lbl_id_empresa.Text = Convert.ToString(myParametro.Fk_Empresa);

                        if (myvalidacion.empresa_habilitada(Lbl_id_empresa.Text) == true)
                        {
                            myParametro.Id_cliente = Lbl_id_cliente.Text;

                            myParametro.cliente_habilitado = "Si";

                            if (Gestion_Datos.Actualizar_Cliente_Habilitado(myParametro))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se restauro el cliente correctamente', confirmButtonText: 'Ok' })  ", true);
                                Grilla_Cliente.DataBind();
                                cargar_datos_sesion();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos', confirmButtonText: 'Ok' })  ", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'La empresa a la cual pertenece el cliente se encuentra desHabilitada', confirmButtonText: 'Ok' })  ", true);
                        }

                        Btn_ver_deshabilitados.Visible = false;
                        Btn_ver_habilitados.Visible = true;

                    }
                }
            }

        }

        protected void Check_VisualizarTickets_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_VisualizarTickets.Checked == true)
            {
                Txt_VisualizarTickets.Text = "Cliente_Admin";
            }
            else
            {
                Txt_VisualizarTickets.Text = "Cliente";
            }


        }

        protected void Btn_Editar_Click(object sender, EventArgs e)
        {

            if (List_Empresa.SelectedValue == "1")         // me valida si en el campo Txt_empresa se ha seleccionado una empresa
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Seleccione la empresa a la cual pertenece el cliente ', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {

                if (string.IsNullOrWhiteSpace(Txt_NombreCliente.Text))     // me valida si el campo Txt_nombre cliente esta vacio si lo esta me muestra un cuadro de dialogo
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'Campos sin completar', text: 'Campo nombre del cliente esta vacio', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {

                    if (string.IsNullOrWhiteSpace(Txt_CorreoCliente.Text))      // me valida si el campo Txt_CorreoCliente esta vacio si lo esta me muestra un cuadro de dialogo
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'Campos sin completar', text: 'Campo correo esta vacio', confirmButtonText: 'Ok' })  ", true);

                    }
                    else
                    {

                        if (string.IsNullOrWhiteSpace(Txt_TelefonoCliente.Text))      // me valida si el campo Txt_TelefonoCliente esta vacio si lo esta me muestra un cuadro de dialogo
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'Campos sin completar', text: 'Campo telefono esta vacio', confirmButtonText: 'Ok' })  ", true);
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(Txt_Contraseña.Text))      // me valida si el campo Txt_Contraseña esta vacio si lo esta me muestra un cuadro de dialogo
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'Campos sin completar', text: 'Campo contraseña esta vacio', confirmButtonText: 'Ok' })  ", true);
                            }
                            else
                            {



                                if (Check_VisualizarTickets.Checked == true)
                                {
                                    Txt_VisualizarTickets.Text = "4";
                                }
                                else
                                {
                                    Txt_VisualizarTickets.Text = "5";
                                }

                                myParametro.Id_cliente = Lbl_id_cliente.Text;
                                myParametro.Fk_Empresa = Convert.ToInt32(List_Empresa.SelectedValue);
                                myParametro.Nombre_Cliente = Txt_NombreCliente.Text;
                                myParametro.Correo_Cliente = Txt_CorreoCliente.Text;
                                myParametro.Telefono_Cliente = Txt_TelefonoCliente.Text;
                                myParametro.Contraseña = Txt_Contraseña.Text;
                                myParametro.Rol_Cliente = Convert.ToInt32(Txt_VisualizarTickets.Text);


                                if (Gestion_Datos.editar_Cliente(myParametro) == true)
                                {
                                    myvalidacion.actualizar_editar_contra_usuario(Txt_CorreoCliente.Text, Txt_Contraseña.Text, Txt_NombreCliente.Text);

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'ACTUALIZACION DE DATOS', text: 'Se actualizaron los datos correctamente', confirmButtonText: 'Ok' })  ", true);

                                    List_Empresa.SelectedValue = "1";
                                    Txt_NombreCliente.Text = "";
                                    Txt_CorreoCliente.Text = "";
                                    Txt_TelefonoCliente.Text = "";
                                    Check_VisualizarTickets.Checked = false;
                                    Txt_Contraseña.Text = "";


                                    Grilla_Cliente.DataBind();
                                    cargar_datos_sesion();
                                    Btn_Editar.Visible = false;
                                    BtnCrearCliente.Visible = true;
                                    Txt_CorreoCliente.Enabled = true;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_cliente').modal('hide');", true);
                                }
                                else

                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'Error al enviar', text: 'Se genero un error en la base de datos al ingresar los datos', confirmButtonText: 'Ok' })  ", true);
                                }

                            }
                        }

                    }

                }

            }
        }

        protected void Txt_Empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //myParametro = Gestion_Datos.traerID_Empresa(Txt_Empresa.Text);
            //Txt_Fk_Empresas.Text = myParametro.Fk_Empresa;
        }

        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            List_Empresa.SelectedValue = "1";
            Txt_NombreCliente.Text = "";
            Txt_CorreoCliente.Text = "";
            Txt_TelefonoCliente.Text = "";
            Check_VisualizarTickets.Checked = false;
            Txt_Contraseña.Text = "";




            Grilla_Cliente.Columns[7].Visible = true;
            Grilla_Cliente.Columns[8].Visible = true;
            //Grilla_Cliente.Columns[9].Visible = false;
            Btn_Editar.Visible = false;
            BtnCrearCliente.Visible = true;

            Txt_Titulo_Eliminados.Visible = false;
            Txt_Titulo_Habilitados.Visible = true;
            Txt_CorreoCliente.Enabled = true;
            Grilla_Cliente.DataBind();
            cargar_datos_sesion();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }

            Txt_Contraseña.Text = contraseniaAleatoria;
        }

        protected void btn_agregar_cliente_Click(object sender, EventArgs e)
        {
            if (rol_inicio_usuario != null)
            {

                List_Empresa.SelectedValue = "1";
            }
            else
            {
                if (rol_inicio_cliente != null)
                {
                    List_Empresa.SelectedValue = Convert.ToString(Id_Empresa_cliente);
                }
            }
            Btn_Editar.Visible = false;
            BtnCrearCliente.Visible = true;
            Txt_NombreCliente.Text = "";
            Txt_CorreoCliente.Text = "";
            Txt_TelefonoCliente.Text = "";
            Check_VisualizarTickets.Checked = false;
            Txt_Contraseña.Text = "";


            if (Lbl_Ver_Eliminados.Text == "No")
            {
                Btn_ver_habilitados.Visible = true;
                Btn_ver_deshabilitados.Visible = false;
            }
            else
            {

                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
            }


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_cliente').modal();", true);

        }

        protected void Btn_ver_eliminados_Click(object sender, EventArgs e)
        {

            if (Grilla_Cliente.Rows.Count != 0)
            {
                Grilla_Cliente.EmptyDataText = "No hay registros";
            }

            Lbl_Ver_Eliminados.Text = "No";
            Txt_Titulo_Eliminados.Visible = true;
            Txt_Titulo_Habilitados.Visible = false;

            Grilla_Cliente.Columns[6].Visible = false;
            Grilla_Cliente.Columns[7].Visible = false;
            Grilla_Cliente.Columns[8].Visible = true;

            Btn_Editar.Visible = false;
            BtnCrearCliente.Visible = true;

            cargar_datos_sesion();
            Btn_ver_habilitados.Visible = true;
            Btn_ver_deshabilitados.Visible = false;


        }

        protected void Btn_ver_habilitados_Click(object sender, EventArgs e)
        {
            Btn_ver_deshabilitados.Visible = true;
            Btn_ver_habilitados.Visible = false;
            Lbl_Ver_Eliminados.Text = "Si";
            Txt_Titulo_Eliminados.Visible = false;
            Txt_Titulo_Habilitados.Visible = true;
            Grilla_Cliente.Columns[6].Visible = true;
            Grilla_Cliente.Columns[7].Visible = true;
            Grilla_Cliente.Columns[8].Visible = false;

            Btn_Editar.Visible = false;
            BtnCrearCliente.Visible = true;
            cargar_datos_sesion();
        }
    }
}