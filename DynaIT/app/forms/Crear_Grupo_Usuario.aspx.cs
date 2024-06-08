//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynaIT.app.forms

{
    public partial class Crear_Grupo_Usuario : System.Web.UI.Page
    {
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        Clase_Parametros myparameters = new Clase_Parametros();
        Validaciones validaciones = new Validaciones();


        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_ver_deshabilitados.Visible = true;
        }

        protected void Btn_Crear_Grupo_usuario(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(Txt_Grupo_usuario.Text))
            {
                if (!validaciones.Existe_Grupos_usuario(Txt_Grupo_usuario.Text))
                {
                    myparameters.Tabla_Grupos_Usuario = Txt_Grupo_usuario.Text;

                    if (!Gestion_Datos.Insertar_GruposUsuario(myparameters))
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Área creada correctamente', confirmButtonText: 'Ok' })  ", true);

                        Grilla_Grupo_usuario.DataBind();
                        Txt_Grupo_usuario.Text = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal('hide');", true);
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos campos vacios', confirmButtonText: 'Ok' })  ", true);
                        Txt_Grupo_usuario.Text = "";
                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El área se encuentra registrado', confirmButtonText: 'Ok' })  ", true);
                    Txt_Grupo_usuario.Text = "";

                }

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo se encuentra vacio', confirmButtonText: 'Ok' })  ", true);
                Txt_Grupo_usuario.Text = "";
            }

            if (Txt_Grupos_Habilitados.Text == "Si")
            {
                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
            }
            else
            {
                if (Txt_Grupos_Habilitados.Text == "No")
                {
                    Btn_ver_habilitados.Visible = true;
                    Btn_ver_deshabilitados.Visible = false;
                    Btn_Recuperar_campo.Visible = false;
                }
            }
        }


        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {

        }



        protected void Grilla_Grupo_usuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (Txt_Grupos_Habilitados.Text == "Si")
                {
                    Btn_Crear_Grupo_Usuario.Visible = false;
                    Btn_Recuperar_campo.Visible = false;
                    Btn_Editar_grupo_Usuario.Visible = true;
                    Btn_ver_deshabilitados.Visible = true;
                    Btn_ver_habilitados.Visible = false;
                }
                else
                {
                    if (Txt_Grupos_Habilitados.Text == "No")
                    {

                        Btn_Crear_Grupo_Usuario.Visible = false;
                        Btn_Recuperar_campo.Visible = true;
                        Btn_Editar_grupo_Usuario.Visible = false;
                        Btn_ver_deshabilitados.Visible = false;
                        Btn_ver_habilitados.Visible = true;

                    }
                }
                int index = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(Grilla_Grupo_usuario.DataKeys[index].Value);
                Txt_Id_Grupos_usuarios.Text = (valor);

                myparameters = Gestion_Datos.Traer__id_Grupos_Usuario(Txt_Id_Grupos_usuarios.Text);

                Txt_Grupo_usuario.Text = myparameters.Tabla_Grupos_Usuario;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal();", true);


            }
        }

        protected void Btn_Editar_Grupo_Usuario(object sender, EventArgs e)
        {

            Txt_Grupo_usuario.Text = Txt_Grupo_usuario.Text.TrimStart();

            if (string.IsNullOrWhiteSpace(Txt_Grupo_usuario.Text))      // me valida si el campo Txt_Contraseña esta vacio si lo esta me muestra un cuadro de dialogo
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo se encuentra vacio', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {

                myparameters.Tabla_Grupos_Usuario = Txt_Grupo_usuario.Text.TrimStart();


                if (!validaciones.Existe_Grupos_usuario(Txt_Grupo_usuario.Text))
                {

                    myparameters.Ta_id_area = Convert.ToInt32(Txt_Id_Grupos_usuarios.Text);
                    myparameters.Tabla_Grupos_Usuario = Txt_Grupo_usuario.Text;


                    if (!Gestion_Datos.Actualizar_Grupos_Usuario(myparameters))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se actualizo la información correctamente', confirmButtonText: 'Ok' })  ", true);
                        Txt_Grupo_usuario.Text = "";

                        Grilla_Grupo_usuario.DataBind();

                        Btn_Editar_grupo_Usuario.Visible = false;
                        Btn_Crear_Grupo_Usuario.Visible = true;

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal('hide');", true);

                    }
                    else

                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error al crear área en la base de datos', confirmButtonText: 'Ok' })  ", true);

                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El área ya se encuentra registrada', confirmButtonText: 'Ok' })  ", true);



                }


            }
        }

        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Txt_Grupo_usuario.Text = "";

            Btn_Editar_grupo_Usuario.Visible = false;
            Btn_Crear_Grupo_Usuario.Visible = true;
            Btn_Recuperar_campo.Visible = false;
            Txt_Grupos_Habilitados.Text = "Si";
            Txt_Titulo_Eliminados.Visible = false;
            Txt_Titulo_Habilitados.Visible = true;





        }



        protected void Btn_Recuperar_Grupo_Usuario(object sender, EventArgs e)
        {
            if (Txt_Grupo_usuario.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo se encuentra vacio', confirmButtonText: 'Ok' })  ", true);

            }
            else
            {

                myparameters.Ta_id_area = Convert.ToInt32(Txt_Id_Grupos_usuarios.Text);
                myparameters.Tabla_Grupos_Usuario = Txt_Grupo_usuario.Text;
                myparameters.Tabla_Grupos_Habilitado = Txt_Recuperar_Grupo.Text;

                Gestion_Datos.Actualizar_Grupos_Habilitado(myparameters);


                Btn_Editar_grupo_Usuario.Visible = false;

                Grilla_Grupo_usuario.DataBind();
                Txt_Grupo_usuario.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "Titulo", "confirmarRecuperacion();", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal('hide');", true);
            }


            if (Txt_Grupos_Habilitados.Text == "Si")
            {
                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
            }
            else
            {
                if (Txt_Grupos_Habilitados.Text == "No")
                {
                    Btn_ver_habilitados.Visible = true;
                    Btn_ver_deshabilitados.Visible = false;
                    Btn_Recuperar_campo.Visible = false;
                }
            }
        }



        protected void Grilla_Grupo_usuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Grilla_Grupo_usuario.Columns[0].Visible = true;
            Grilla_Grupo_usuario.DataBind();

            int a;
            a = Convert.ToInt32(e.RowIndex.ToString());

            Lbl_id_grupo_habilita.Text = Grilla_Grupo_usuario.Rows[a].Cells[0].Text;
            Txt_Grupo_usuario.Text = Grilla_Grupo_usuario.Rows[a].Cells[1].Text;

            if (validaciones.Existe_usuario_vinculado(Convert.ToInt32(Lbl_id_grupo_habilita.Text)) == true)
            {


                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'No se puede eliminar el grupo porque tiene usuario activos y vinculados en este momento ', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                myparameters.Ta_id_area = Convert.ToInt32(Lbl_id_grupo_habilita.Text);
                myparameters.Tabla_Grupos_Usuario = Txt_Grupo_usuario.Text;
                myparameters.Tabla_Grupos_Habilitado = "No";

                Gestion_Datos.Actualizar_Grupos_Habilitado(myparameters);

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Área eliminada correctamente ', confirmButtonText: 'Ok' })  ", true);

            }


            Grilla_Grupo_usuario.Columns[0].Visible = false;
            Grilla_Grupo_usuario.DataBind();

        }

        protected void btn_agregar_grupo_Click(object sender, EventArgs e)
        {
            Txt_Grupo_usuario.Text = "";
            Btn_Crear_Grupo_Usuario.Visible = true;
            if (Txt_Grupos_Habilitados.Text == "Si")
            {
                Btn_ver_habilitados.Visible = false;
                Btn_ver_deshabilitados.Visible = true;
            }
            else
            {
                if (Txt_Grupos_Habilitados.Text == "No")
                {
                    Btn_ver_habilitados.Visible = true;
                    Btn_ver_deshabilitados.Visible = false;
                    Btn_Recuperar_campo.Visible = false;
                }
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_grupo').modal();", true);

        }

        protected void Btn_ver_deshabilitados_Click(object sender, EventArgs e)
        {
            Btn_ver_deshabilitados.Visible = false;
            Btn_ver_habilitados.Visible = true;
            Txt_Grupos_Habilitados.Text = "No";
            //Check_Habilitar_Grupos_usuarios.Visible = true;

            Txt_Titulo_Eliminados.Visible = true;
            Txt_Titulo_Habilitados.Visible = false;

            Btn_Recuperar_campo.Visible = true;
            Btn_Crear_Grupo_Usuario.Visible = false;
            Btn_Editar_grupo_Usuario.Visible = false;

            Grilla_Grupo_usuario.Columns[3].Visible = false;
            Txt_Grupo_usuario.Text = "";
        }

        protected void Btn_ver_habilitados_Click(object sender, EventArgs e)
        {
            Btn_ver_deshabilitados.Visible = true;
            Btn_ver_habilitados.Visible = false;
            Txt_Grupos_Habilitados.Text = "Si";

            Txt_Titulo_Eliminados.Visible = false;
            Txt_Titulo_Habilitados.Visible = true;

            Btn_Crear_Grupo_Usuario.Visible = true;
            Btn_Recuperar_campo.Visible = false;
            Btn_Editar_grupo_Usuario.Visible = false;

            Grilla_Grupo_usuario.Columns[3].Visible = true;
            Txt_Grupo_usuario.Text = "";
        }

        protected void Txt_Grupo_usuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}