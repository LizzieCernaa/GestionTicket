//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynaIT.app.forms
{
    public partial class crear_Estados_Ticket : System.Web.UI.Page
    {
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        Clase_Parametros myparameters = new Clase_Parametros();
        Validaciones validaciones = new Validaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_Editar_Estados.Visible = false;
            Btn_ver_deshabilitados.Visible = true;
            Grilla_Estados_Ticket.DataBind();
        }

        protected void Grid_EstadoTicket_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_Editar_Click(object sender, EventArgs e)
        {

            Btn_Editar_Estados.Visible = true;
            Btn_Crear_Estado_Ticket.Visible = false;

            Txt_EstadosTicket.Text = Txt_EstadosTicket.Text.TrimStart();

            if (string.IsNullOrWhiteSpace(Txt_EstadosTicket.Text))      // me valida si el campo Txt_Contraseña esta vacio si lo esta me muestra un cuadro de dialogo
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo estado esta vacio', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {

                myparameters.Estados_tickets = Txt_EstadosTicket.Text;


                if (!validaciones.Existe_Estado_Ticket(Txt_EstadosTicket.Text))
                {

                    myparameters.Id_Estados_tickets = Convert.ToInt32(Txt_id_estados_ticket.Text);
                    myparameters.Estados_tickets = Txt_EstadosTicket.Text;



                    if (!Gestion_Datos.Actualizar_Estados_ticket(myparameters))
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' Estado actualizado', confirmButtonText: 'Ok' })  ", true);

                        Txt_EstadosTicket.Text = "";

                        Grilla_Estados_Ticket.DataBind();

                        Btn_Editar_Estados.Visible = false;
                        Btn_Crear_Estado_Ticket.Visible = true;

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_estado').modal('hide');", true);

                    }
                    else

                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'Error', text: ' Error al actualizar estado', confirmButtonText: 'Ok' })  ", true);

                    }

                }
                else
                {


                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' El estado ya esta registrado', confirmButtonText: 'Ok' })  ", true);


                }


            }
            Grilla_Estados_Ticket.DataBind();
        }

        protected void Grilla_Estados_Ticket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (Lbl_Ver_Eliminados.Text == "Si")
                {
                    Btn_ver_habilitados.Visible = false;
                    Btn_ver_deshabilitados.Visible = true;
                    Btn_Editar_Estados.Visible = true;
                    Btn_recuperar_Estados.Visible = false;
                    Btn_Crear_Estado_Ticket.Visible = false;
                }
                else
                {
                    if (Lbl_Ver_Eliminados.Text == "No")
                    {
                        Btn_ver_habilitados.Visible = true;
                        Btn_ver_deshabilitados.Visible = false;
                        Btn_Editar_Estados.Visible = false;
                        Btn_recuperar_Estados.Visible = true;
                        Btn_Crear_Estado_Ticket.Visible = false;
                    }
                }
                int index = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(Grilla_Estados_Ticket.DataKeys[index].Value);
                Txt_id_estados_ticket.Text = (valor);

                myparameters = Gestion_Datos.Traer__id_estados_grupo(Txt_id_estados_ticket.Text);

                Txt_EstadosTicket.Text = myparameters.Estados_tickets;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_estado').modal();", true);

            }
        }

        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Txt_EstadosTicket.Text = "";
            Btn_Editar_Estados.Visible = false;
            Btn_Crear_Estado_Ticket.Visible = true;


            Btn_recuperar_Estados.Visible = false;


            Lbl_Ver_Eliminados.Text = "Si";


            Lbl_Titulo_Eliminados.Visible = false;
            Lbl_Titulo_Todos_Creados.Visible = true;
            Lbl_Recuperar.Text = "No";




        }


        protected void Btn_recuperar_Estados_Click(object sender, EventArgs e)
        {
            Txt_EstadosTicket.Text = Txt_EstadosTicket.Text.TrimStart();

            if (string.IsNullOrWhiteSpace(Txt_EstadosTicket.Text))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'No se ha seleccionado un registro a recuperar', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                Lbl_Recuperar.Text = "Si";
                myparameters.Id_Estados_tickets = Convert.ToInt32(Txt_id_estados_ticket.Text);
                myparameters.Estados_tickets = Txt_EstadosTicket.Text;
                myparameters.estado_Habilitado = Lbl_Recuperar.Text;

                Gestion_Datos.Actualizar_Estados_ticket_Habilitado(myparameters);


                Btn_Editar_Estados.Visible = false;

                Grilla_Estados_Ticket.DataBind();
                Txt_EstadosTicket.Text = "";
                Lbl_Recuperar.Text = "No";


                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se recupero el registro correctamente', confirmButtonText: 'Ok' })  ", true);


                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_estado').modal('hide');", true);

            }




        }

        protected void btn_agregar_estado_Click(object sender, EventArgs e)
        {
            if (Lbl_Ver_Eliminados.Text == "Si")
            {
                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
                Btn_Crear_Estado_Ticket.Visible = true;
                Btn_recuperar_Estados.Visible = false;
            }
            else
            {
                if (Lbl_Ver_Eliminados.Text == "No")
                {
                    Btn_ver_habilitados.Visible = true;
                    Btn_ver_deshabilitados.Visible = false;
                    Btn_Crear_Estado_Ticket.Visible = true;
                    Btn_recuperar_Estados.Visible = false;
                }
            }
            Txt_EstadosTicket.Text = "";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_estado').modal();", true);

        }



        protected void Btn_ver_deshabilitados_Click(object sender, EventArgs e)
        {

            if (Grilla_Estados_Ticket.Rows.Count != 0)
            {
                Grilla_Estados_Ticket.EmptyDataText = "No hay registros";
            }
            Btn_ver_deshabilitados.Visible = false;
            Btn_ver_habilitados.Visible = true;
            Lbl_Ver_Eliminados.Text = "No";
            Lbl_Titulo_Eliminados.Visible = true;
            Lbl_Titulo_Todos_Creados.Visible = false;

            Btn_recuperar_Estados.Visible = true;
            Btn_Crear_Estado_Ticket.Visible = false;
            Btn_Editar_Estados.Visible = false;
            Txt_EstadosTicket.Text = "";

            Grilla_Estados_Ticket.Columns[3].Visible = false;
        }

        protected void Btn_ver_habilitados_Click(object sender, EventArgs e)
        {
            Btn_ver_deshabilitados.Visible = true;
            Btn_ver_habilitados.Visible = false;
            Lbl_Ver_Eliminados.Text = "Si";
            Lbl_Titulo_Eliminados.Visible = false;
            Lbl_Titulo_Todos_Creados.Visible = true;

            Btn_Crear_Estado_Ticket.Visible = true;
            Btn_recuperar_Estados.Visible = false;
            Btn_Editar_Estados.Visible = false;
            Txt_EstadosTicket.Text = "";

            Grilla_Estados_Ticket.Columns[3].Visible = true;
        }

        protected void Btn_Crear_Estado_Ticket_Click(object sender, EventArgs e)
        {
            Btn_Editar_Estados.Visible = false;

            Txt_EstadosTicket.Text = Txt_EstadosTicket.Text.TrimStart();

            if (!string.IsNullOrWhiteSpace(Txt_EstadosTicket.Text))
            {
                if (!validaciones.Existe_Estado_Ticket(Txt_EstadosTicket.Text))
                {
                    myparameters.Estados_tickets = Txt_EstadosTicket.Text;


                    if (!Gestion_Datos.Insertar_EstadosTicket(myparameters))
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Estado creado correctamente', confirmButtonText: 'Ok' })  ", true);

                        Grilla_Estados_Ticket.DataBind();

                        Txt_EstadosTicket.Text = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_estado').modal('hide');", true);
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error al insertar en la base de datos', confirmButtonText: 'Ok' })  ", true);
                        Txt_EstadosTicket.Text = "";
                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El estado ya se encuentra registrado', confirmButtonText: 'Ok' })  ", true);
                    Txt_EstadosTicket.Text = "";
                }

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Campo se encuentra vacio', confirmButtonText: 'Ok' })  ", true);
                Txt_EstadosTicket.Text = "";
            }

            Grilla_Estados_Ticket.DataBind();
        }

        protected void Grilla_Estados_Ticket_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (Lbl_Ver_Eliminados.Text == "Si")
            {
                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
                Btn_recuperar_Estados.Visible = false;
                Btn_Crear_Estado_Ticket.Visible = true;
            }
            else
            {
                if (Lbl_Ver_Eliminados.Text == "No")
                {
                    Btn_ver_habilitados.Visible = true;
                    Btn_ver_deshabilitados.Visible = false;
                    Btn_recuperar_Estados.Visible = true;
                    Btn_Crear_Estado_Ticket.Visible = false;
                }
            }
            int a;
            a = Convert.ToInt32(e.RowIndex.ToString());
            Txt_id_estados_ticket.Text = Grilla_Estados_Ticket.Rows[a].Cells[0].Text;

            myparameters = Gestion_Datos.Traer__id_estados_grupo(Txt_id_estados_ticket.Text);
            Txt_id_estados_ticket.Text = Convert.ToString(myparameters.Id_Estados_tickets);
            Txt_EstadosTicket.Text = myparameters.Estados_tickets;


            if (!validaciones.Existe_ticket_vinculado_estado(Txt_id_estados_ticket.Text))
            {
                Lbl_Recuperar.Text = "No";
                myparameters.Id_Estados_tickets = Convert.ToInt32(Txt_id_estados_ticket.Text);
                myparameters.Estados_tickets = Txt_EstadosTicket.Text;
                myparameters.estado_Habilitado = Lbl_Recuperar.Text;

                if (!Gestion_Datos.Actualizar_Estados_ticket_Habilitado(myparameters))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se elimino el estado correctamente', confirmButtonText: 'Ok' })  ", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos', confirmButtonText: 'Ok' })  ", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' Hay ticket creados los cuales estan en este estado ', confirmButtonText: 'Ok' })  ", true);

            }
        }
    }
}