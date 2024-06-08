//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynaIT.app.forms
{
    public partial class Crear_tipos_ticket : System.Web.UI.Page
    {
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        Clase_Parametros myparameters = new Clase_Parametros();
        Validaciones validaciones = new Validaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_Editar_tipo_ticket.Visible = false;
            Btn_ver_deshabilitados.Visible = true;



        }

        protected void Btn_CrearTicket_Click(object sender, EventArgs e)
        {
            Txt_Tipos_Tckets.Text = Txt_Tipos_Tckets.Text.TrimStart();
            txt_horas_respuesta.Value = txt_horas_respuesta.Value.TrimStart();

            if (!string.IsNullOrWhiteSpace(Txt_Tipos_Tckets.Text))
            {
                if (!string.IsNullOrWhiteSpace(txt_horas_respuesta.Value))
                {
                    if (!validaciones.Existe_tipo_ticket(Txt_Tipos_Tckets.Text))
                    {

                        myparameters.tipos_tickets = Txt_Tipos_Tckets.Text;
                        myparameters.horas_respuesta_tipos_tickets = Convert.ToInt32(txt_horas_respuesta.Value);

                        if (!Gestion_Datos.Insertar_Tipo_tickets(myparameters))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se creo el estado de los tickets', confirmButtonText: 'Ok' })  ", true);

                            Grilla_Tipos_Ticket.DataBind();

                            Txt_Tipos_Tckets.Text = "";

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error al insertar en la base de datos', confirmButtonText: 'Ok' })  ", true);
                            Txt_Tipos_Tckets.Text = "";
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El estado ya se encuentra registrado', confirmButtonText: 'Ok' })  ", true);
                        Txt_Tipos_Tckets.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo esta vacio', confirmButtonText: 'Ok' })  ", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo esta vacio', confirmButtonText: 'Ok' })  ", true);
                Txt_Tipos_Tckets.Text = "";
            }
        }




        protected void Btn_Editar_Click(object sender, EventArgs e)
        {

            Clase_Parametros valorMyParametro = new Clase_Parametros();

            Btn_Crear_Tipo_Ticket.Visible = false;
            Btn_Editar_tipo_ticket.Visible = true;


            Txt_Tipos_Tckets.Text = Txt_Tipos_Tckets.Text.TrimStart();
            txt_horas_respuesta.Value = txt_horas_respuesta.Value.TrimStart();



            if (string.IsNullOrWhiteSpace(Txt_Tipos_Tckets.Text))      // me valida si el campo Txt_Contraseña esta vacio si lo esta me muestra un cuadro de dialogo
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo esta vacio', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_horas_respuesta.Value))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo esta vacio', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {
                    myparameters.id_tipos_tickets = Convert.ToInt32(txt_id_tipo_ticket.Text);
                    myparameters.tipos_tickets = Txt_Tipos_Tckets.Text;
                    myparameters.horas_respuesta_tipos_tickets = Convert.ToInt32(txt_horas_respuesta.Value);



                    if (!Gestion_Datos.Actualizar_Tipo_Ticket(myparameters))
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se actualizaron los datos correctamente', confirmButtonText: 'Ok' })  ", true);

                        Txt_Tipos_Tckets.Text = "";

                        Grilla_Tipos_Ticket.DataBind();

                        Btn_Editar_tipo_ticket.Visible = false;
                        Btn_Crear_Tipo_Ticket.Visible = true;


                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal('hide');", true);
                    }
                    else

                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Se genero un error en la base de datos al ingresar los datos', confirmButtonText: 'Ok' })  ", true);
                    }
                }

            }



        }

        protected void Grilla_Tipos_Ticket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (Lbl_Ver_Eliminados.Text == "Si")
                {
                    Btn_ver_habilitados.Visible = false;
                    Btn_ver_deshabilitados.Visible = true;
                    Btn_Recuperar_tipo_ticket.Visible = false;
                    Btn_Editar_tipo_ticket.Visible = true;
                    Btn_Crear_Tipo_Ticket.Visible = false;
                }
                else
                {
                    if (Lbl_Ver_Eliminados.Text == "No")
                    {
                        Btn_ver_habilitados.Visible = true;
                        Btn_ver_deshabilitados.Visible = false;
                        Btn_Recuperar_tipo_ticket.Visible = true;
                        Btn_Editar_tipo_ticket.Visible = false;
                        Btn_Crear_Tipo_Ticket.Visible = false;
                    }
                }


                int index = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(Grilla_Tipos_Ticket.DataKeys[index].Value);
                txt_id_tipo_ticket.Text = (valor);
                myparameters = Gestion_Datos.Traer__id_Tipo_Ticket(txt_id_tipo_ticket.Text);
                Txt_Tipos_Tckets.Text = myparameters.tipos_tickets;
                txt_horas_respuesta.Value = Convert.ToString(myparameters.horas_respuesta_tipos_tickets);
                if (Lbl_Ver_Eliminados.Text == "no")
                {
                    Btn_Editar_tipo_ticket.Visible = true;
                    Btn_Crear_Tipo_Ticket.Visible = false;
                    Txt_Tipos_Tckets.Text = "";
                    Txt_Tipos_Tckets.Text = myparameters.tipos_tickets;

                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal();", true);
            }

        }

        protected void Grilla_Tipos_Ticket_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Lbl_Ver_Eliminados.Text == "Si")
            {
                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
                Btn_Recuperar_tipo_ticket.Visible = false;
                Btn_Crear_Tipo_Ticket.Visible = true;
            }
            else
            {
                if (Lbl_Ver_Eliminados.Text == "No")
                {
                    Btn_ver_habilitados.Visible = true;
                    Btn_ver_deshabilitados.Visible = false;
                    Btn_Recuperar_tipo_ticket.Visible = true;
                    Btn_Crear_Tipo_Ticket.Visible = false;
                }
            }
            int a;
            a = Convert.ToInt32(e.RowIndex.ToString());
            txt_id_tipo_ticket.Text = Grilla_Tipos_Ticket.Rows[a].Cells[1].Text;

            myparameters = Gestion_Datos.cargar_id_Tipos_tickes(txt_id_tipo_ticket.Text);
            txt_id_tipo_ticket.Text = Convert.ToString(myparameters.id_tipos_tickets);

            myparameters = Gestion_Datos.Traer__id_Tipo_Ticket(txt_id_tipo_ticket.Text);
            Txt_Tipos_Tckets.Text = myparameters.tipos_tickets;

            myparameters.id_tipos_tickets = Convert.ToInt32(txt_id_tipo_ticket.Text);
            myparameters.tipos_tickets = Txt_Tipos_Tckets.Text;
            myparameters.Tipo_Ticket_Habilitado = "No";

            if (validaciones.Existe_ticket_vinculado_tipo(Convert.ToInt32(txt_id_tipo_ticket.Text)))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' Hay ticket creados de este tipo los cuales estan en revisión ', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                if (Gestion_Datos.Actualizar_Tipo_Ticket_Habilitado(myparameters))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se elimino el Tipo de ticket correctamente', confirmButtonText: 'Ok' })  ", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos', confirmButtonText: 'Ok' })  ", true);
                }
            }





        }


        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Txt_Tipos_Tckets.Text = "";

            Btn_Editar_tipo_ticket.Visible = false;
            Btn_Crear_Tipo_Ticket.Visible = true;
            Btn_Recuperar_tipo_ticket.Visible = false;
            Lbl_Ver_Eliminados.Text = "Si";


            Lbl_Titulo_Eliminados.Visible = false;
            Lbl_Titulo_Todos_Creados.Visible = true;


        }



        protected void Btn_Recuperar_Click(object sender, EventArgs e)
        {
            Btn_ver_deshabilitados.Visible = false;
            Btn_ver_habilitados.Visible = true;

            if (string.IsNullOrWhiteSpace(Txt_Tipos_Tckets.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo esta vacio', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal('hide');", true);
                myparameters.id_tipos_tickets = Convert.ToInt32(txt_id_tipo_ticket.Text);
                myparameters.Tipo_Ticket_Habilitado = Lbl_Recuperar.Text;
                myparameters.tipos_tickets = Txt_Tipos_Tckets.Text;
                myparameters.horas_respuesta_tipos_tickets = Convert.ToInt32(txt_horas_respuesta.Value);
                Gestion_Datos.Actualizar_Tipo_Ticket_Habilitado(myparameters);

                Btn_Editar_tipo_ticket.Visible = false;
                Grilla_Tipos_Ticket.DataBind();
                Txt_Tipos_Tckets.Text = "";

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se recupero el registro correctamente', confirmButtonText: 'Ok' })  ", true);

            }
        }



        protected void btn_agregar_grupo_Click(object sender, EventArgs e)
        {
            Txt_Tipos_Tckets.Text = "";
            if (Lbl_Ver_Eliminados.Text == "Si")
            {
                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
            }
            else
            {
                if (Lbl_Ver_Eliminados.Text == "No")
                {
                    Btn_ver_habilitados.Visible = true;
                    Btn_ver_deshabilitados.Visible = false;
                }
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal();", true);

        }



        protected void Btn_ver_habilitados_Click(object sender, EventArgs e)
        {
            Btn_ver_habilitados.Visible = false;
            Btn_ver_deshabilitados.Visible = true;

            Lbl_Ver_Eliminados.Text = "Si";
            Lbl_Titulo_Eliminados.Visible = false;
            Lbl_Titulo_Todos_Creados.Visible = true;
            Btn_Crear_Tipo_Ticket.Visible = true;
            Btn_Recuperar_tipo_ticket.Visible = false;
            Btn_Editar_tipo_ticket.Visible = false;
            Grilla_Tipos_Ticket.Columns[5].Visible = true;
            Txt_Tipos_Tckets.Text = "";
        }

        protected void Btn_ver_deshabilitados_Click(object sender, EventArgs e)
        {
            if (Grilla_Tipos_Ticket.Rows.Count != 0)
            {
                Grilla_Tipos_Ticket.EmptyDataText = "No hay registros";
            }

            Btn_ver_habilitados.Visible = true;
            Btn_ver_deshabilitados.Visible = false;

            Lbl_Ver_Eliminados.Text = "No";
            Lbl_Titulo_Eliminados.Visible = true;
            Lbl_Titulo_Todos_Creados.Visible = false;
            Btn_Recuperar_tipo_ticket.Visible = true;
            Btn_Crear_Tipo_Ticket.Visible = false;
            Btn_Editar_tipo_ticket.Visible = false;
            Grilla_Tipos_Ticket.Columns[5].Visible = false;
            Txt_Tipos_Tckets.Text = "";
        }


    }


}


