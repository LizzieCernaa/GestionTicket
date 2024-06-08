//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynaIT.app.forms
{
    public partial class Crear_Empresa : System.Web.UI.Page
    {
        Validaciones Validaciones = new Validaciones();
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        Clase_Parametros myParametro = new Clase_Parametros();
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_ver_empresa_deshabilitada.Visible = true;
            Grilla_crear_empresa.DataBind();
        }

        protected void Btn_CrearCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Empresa.Text))         // me valida si el campo Txt_Empresa esta vacio si lo esta me muestra un cuadro de dialogo
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo nombre empresa esta vacio', confirmButtonText: 'Ok' })  ", true);

            }
            else
            {

                if (string.IsNullOrWhiteSpace(Txt_Nit.Text))     // me valida si el campo Txt_Nit esta vacio si lo esta me muestra un cuadro de dialogo
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo nit empresa esta vacio', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {

                    if (string.IsNullOrWhiteSpace(Txt_TelefonoEmpresa.Text))      // me valida si el campo Txt_TelefonoEmpresa esta vacio si lo esta me muestra un cuadro de dialogo
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo Telefono empresa esta vacio', confirmButtonText: 'Ok' })  ", true);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(Txt_representante.Text))
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo representante esta vacio', confirmButtonText: 'Ok' })  ", true);
                        }
                        else
                        {
                            if (!Validaciones.Existe_empresa(Txt_Empresa.Text, Txt_Nit.Text))
                            {
                                myParametro.Nombre_Empresa = Txt_Empresa.Text;
                                myParametro.Nit = Txt_Nit.Text;
                                myParametro.Telefono_Empresa = Txt_TelefonoEmpresa.Text;
                                myParametro.Representante_empresa = Txt_representante.Text;



                                if (Gestion_Datos.insertar_Empresa(myParametro))                //Me realiza la inserciona la tabla Ticket 

                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'ERROR AL ENVIAR', text: 'Se genero un error en la base de datos al ingresar los datos', confirmButtonText: 'Ok' })  ", true);

                                }
                                else
                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Empresa creada', confirmButtonText: 'Ok' })  ", true);


                                    Txt_Empresa.Text = "";
                                    Txt_Nit.Text = "";
                                    Txt_TelefonoEmpresa.Text = "";
                                    Txt_representante.Text = "";
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_empresa", "$('#modal_crear_empresa').modal('hide');", true);

                                    Grilla_crear_empresa.DataBind();
                                }
                            }
                            else
                            {


                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'Valor duplicado', text:'Ya hay una empresa registrada con el numero de nit' , confirmButtonText: 'Ok' })  ", true);

                            }
                        }
                    }
                }
            }
            Grilla_crear_empresa.DataBind();
        }





        protected void Grilla_crear_empresa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a;
            a = Convert.ToInt32(e.RowIndex.ToString());
            Lbl_id_Empresa.Text = Grilla_crear_empresa.Rows[a].Cells[1].Text;


            myParametro = Gestion_Datos.traerID_Empresa(Lbl_id_Empresa.Text);
            Lbl_id_Empresa.Text = Convert.ToString(myParametro.Fk_Empresa);

            if (Validaciones.Existe_cliente_vinculado(Lbl_id_Empresa.Text) == true)
            {


                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text:'No se puede eliminar la empresa porque tiene clientes activos y vinculadosen este momento' , confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                myParametro.id_Empresa = Convert.ToInt32(Lbl_id_Empresa.Text);
                myParametro.Empresa_Habilitada = "No";

                Gestion_Datos.Actualizar_empresa_eliminar(myParametro);
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text:'Se elimino la Empresa correctamente' , confirmButtonText: 'Ok' })  ", true);

            }


        }

        protected void Grilla_crear_empresa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Habilitar")
            {
                if (Lbl_Ver_Eliminados.Text == "No")
                {
                    btn_ver_empresa_habilitada.Visible = true;
                    btn_ver_empresa_deshabilitada.Visible = false;

                }
                else
                {
                    btn_ver_empresa_habilitada.Visible = false;
                    btn_ver_empresa_deshabilitada.Visible = true;
                }

                int index = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(Grilla_crear_empresa.DataKeys[index].Value);
                Lbl_id_Empresa.Text = (valor);

                myParametro.id_Empresa = Convert.ToInt32(Lbl_id_Empresa.Text);
                Gestion_Datos.Actualizar_Empresa_habilitada(myParametro);

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text:'Empresa habilitada' , confirmButtonText: 'Ok' })  ", true);
                Grilla_crear_empresa.DataBind();

            }
            else
            {
                if (e.CommandName == "Editar")
                {
                    Btn_CrearCliente.Visible = false;
                    btn_editar.Visible = true;

                    int index = Convert.ToInt32(e.CommandArgument);
                    string valor = Convert.ToString(Grilla_crear_empresa.DataKeys[index].Value);
                    Lbl_id_Empresa.Text = (valor);
                    myParametro.id_Empresa = Convert.ToInt32(Lbl_id_Empresa.Text);

                    myParametro = Gestion_Datos.traer_Empresa(Convert.ToInt32(Lbl_id_Empresa.Text));

                    Txt_Empresa.Text = myParametro.Nombre_Empresa;
                    Txt_Nit.Text = myParametro.Nit;
                    Txt_TelefonoEmpresa.Text = myParametro.Telefono_Empresa;
                    Txt_representante.Text = myParametro.Representante_empresa;


                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_empresa", "$('#modal_crear_empresa').modal();", true);

                }
            }
        }

        protected void btn_agregar_empresa_Click(object sender, EventArgs e)
        {
            if (Lbl_Ver_Eliminados.Text == "No")
            {
                btn_ver_empresa_habilitada.Visible = true;
                btn_ver_empresa_deshabilitada.Visible = false;

            }
            else
            {
                btn_ver_empresa_habilitada.Visible = false;
                btn_ver_empresa_deshabilitada.Visible = true;
            }

            Txt_Empresa.Text = "";
            Txt_Nit.Text = "";
            Txt_TelefonoEmpresa.Text = "";
            Txt_representante.Text = "";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_empresa", "$('#modal_crear_empresa').modal();", true);

        }

        protected void btn_ver_empresa_deshabilitada_Click(object sender, EventArgs e)
        {
            if (Grilla_crear_empresa.Rows.Count != 0)
            {
                Grilla_crear_empresa.EmptyDataText = "Sin empresas deshabilitadas";
            }


            Lbl_Ver_Eliminados.Text = "No";
            Grilla_crear_empresa.Columns[6].Visible = false;

            Txt_Empresa.Text = "";
            Txt_Nit.Text = "";
            Txt_TelefonoEmpresa.Text = "";
            Lbl_id_Empresa.Text = "Lbl_id_Empresa";
            Lbl_Titulo_Eliminados.Visible = true;
            Lbl_Titulo_Habilitados.Visible = false;
            Grilla_crear_empresa.Columns[5].Visible = false;
            Grilla_crear_empresa.Columns[7].Visible = true;

            btn_ver_empresa_habilitada.Visible = true;
            btn_ver_empresa_deshabilitada.Visible = false;

        }


        protected void btn_ver_empresa_habilitada_Click(object sender, EventArgs e)
        {
            Lbl_Ver_Eliminados.Text = "Si";
            Grilla_crear_empresa.Columns[6].Visible = true;
            Grilla_crear_empresa.Columns[5].Visible = true;
            Grilla_crear_empresa.Columns[7].Visible = false;
            Txt_Empresa.Text = "";
            Txt_Nit.Text = "";
            Txt_TelefonoEmpresa.Text = "";
            Lbl_id_Empresa.Text = "Lbl_id_Empresa";
            Lbl_Titulo_Eliminados.Visible = false;
            Lbl_Titulo_Habilitados.Visible = true;

            btn_ver_empresa_deshabilitada.Visible = true;
            btn_ver_empresa_habilitada.Visible = false;
        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Empresa.Text))         // me valida si el campo Txt_Empresa esta vacio si lo esta me muestra un cuadro de dialogo
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo nombre empresa esta vacio', confirmButtonText: 'Ok' })  ", true);

            }
            else
            {

                if (string.IsNullOrWhiteSpace(Txt_Nit.Text))     // me valida si el campo Txt_Nit esta vacio si lo esta me muestra un cuadro de dialogo
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo nit empresa esta vacio', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {

                    if (string.IsNullOrWhiteSpace(Txt_TelefonoEmpresa.Text))      // me valida si el campo Txt_TelefonoEmpresa esta vacio si lo esta me muestra un cuadro de dialogo
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo Telefono empresa esta vacio', confirmButtonText: 'Ok' })  ", true);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(Txt_representante.Text))
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo representante esta vacio', confirmButtonText: 'Ok' })  ", true);
                        }
                        else
                        {

                            myParametro.id_Empresa = Convert.ToInt32(Lbl_id_Empresa.Text);
                            myParametro.Nombre_Empresa = Txt_Empresa.Text;
                            myParametro.Nit = Txt_Nit.Text;
                            myParametro.Telefono_Empresa = Txt_TelefonoEmpresa.Text;
                            myParametro.Representante_empresa = Txt_representante.Text;
                            if (!Gestion_Datos.Actualizar_Empresa(myParametro))
                            {
                                Grilla_crear_empresa.DataBind();


                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Datos actualizados', confirmButtonText: 'Ok' })  ", true);
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_empresa", "$('#modal_crear_empresa').modal('hide');", true);
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'ERROR AL ENVIAR ', text:'Se genero un error en la base de datos al ingresar los datos' confirmButtonText: 'Ok' })  ", true);
                            }
                        }
                    }
                }
            }

        }
    }
}