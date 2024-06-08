using DynaIT.Clases;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynaIT.app.forms
{
    public partial class Crear_Usuario : System.Web.UI.Page
    {
        Validaciones myValidaciones = new Validaciones();
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        Clase_Parametros myParametro = new Clase_Parametros();
        static int rol;
        protected void Page_Load(object sender, EventArgs e)
        {

            Txt_Contraseña.Enabled = false;
            Btn_ver_deshabilitados.Visible = true;

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_CrearUsuario_Click(object sender, EventArgs e)
        {
            Btn_Editar.Visible = false;
            String expresion;

            expresion = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            if (Regex.IsMatch(Txt_CorreoUsuario.Text, expresion))
            {
                Txt_NombreUsuario.Text = Txt_NombreUsuario.Text.TrimStart();
                if (string.IsNullOrWhiteSpace(Txt_NombreUsuario.Text))         // me valida si el campo Txt_NombreUsuario esta vacio si lo esta me muestra un cuadro de dialogo
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo nombre usuario esta vacio', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {
                    Txt_CorreoUsuario.Text = Txt_CorreoUsuario.Text.TrimStart();
                    if (string.IsNullOrWhiteSpace(Txt_CorreoUsuario.Text))     // me valida si el campo Txt_CorreoUsuario esta vacio si lo esta me muestra un cuadro de dialogo
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo correo usuario esta vacio', confirmButtonText: 'Ok' })  ", true);
                    }
                    else
                    {

                        if (List_Rol.Text == "--Seleccionar--")      // me valida si el campo Txt_Cargo esta vacio si lo esta me muestra un cuadro de dialogo
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Sin seleccionar', text: ' No se ha seleccionado el rol del usuario', confirmButtonText: 'Ok' })  ", true);
                        }
                        else
                        {
                            int rol;
                            if (List_Rol.Text == "Agente")
                            {
                                rol = 3;
                            }
                            else
                            {
                                rol = 2;
                            }
                            if (Txt_Grupo.SelectedValue == "1")
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Sin seleccionar', text: '  Selecione un área a la cual pertenece el usuario ', confirmButtonText: 'Ok' })  ", true);
                            }
                            else
                            {
                                Txt_Usuario.Text = Txt_Usuario.Text.TrimStart();
                                if (string.IsNullOrWhiteSpace(Txt_Usuario.Text))
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo usuario vacio', text: ' El campo usuario esta vacio', confirmButtonText: 'Ok' })  ", true);
                                }
                                else
                                {

                                    if (string.IsNullOrWhiteSpace(Txt_Contraseña.Text))      // me valida si el campo Txt_Contraseña esta vacio si lo esta me muestra un cuadro de dialogo
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: '  El campo contraseña  esta vacio', confirmButtonText: 'Ok' })  ", true);
                                    }
                                    else
                                    {





                                        if (myValidaciones.Existe_Correo_usuario(Txt_CorreoUsuario.Text) == false)
                                        {

                                            if (myValidaciones.Existe_Correo_cliente(Txt_CorreoUsuario.Text) == false)
                                            {
                                                myParametro.Nombre_Usuario = Txt_NombreUsuario.Text;
                                                myParametro.Correo_Usuario = Txt_CorreoUsuario.Text;
                                                myParametro.Rol_usuario = rol;
                                                myParametro.Usuario = Txt_Usuario.Text;

                                                myParametro.Tabla_Grupos_Usuario = Txt_Grupo.SelectedValue;
                                                myParametro.Contraseña_Usuario = Txt_Contraseña.Text;



                                                if (Gestion_Datos.insertar_Usuario(myParametro) == false)                //Me realiza la inserciona la tabla Ticket 
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'ERROR AL ENVIAR', text: 'Se genero un error en la base de datos al ingresar los datos', confirmButtonText: 'Ok' })  ", true);
                                                }
                                                else
                                                {
                                                    myValidaciones.actualizar_editar_contra_usuario(Txt_CorreoUsuario.Text, Txt_Contraseña.Text, Txt_NombreUsuario.Text);

                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Usuario creado', confirmButtonText: 'Ok' })  ", true);

                                                    Txt_NombreUsuario.Text = "";
                                                    Txt_CorreoUsuario.Text = "";
                                                    List_Rol.Text = "--Seleccionar--";
                                                    //Txt_Usuario.Text = "";
                                                    Txt_Contraseña.Text = "";
                                                    Txt_Grupo.SelectedValue = "1";
                                                    Txt_Usuario.Text = "";
                                                    Grilla_Crear_Usuario.DataBind();

                                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_usuario').modal('hide');", true);
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'Warning', title:'Correo registrado', text: 'Este correo ya esta registrado en la tabla de clientes', confirmButtonText: 'Ok' })  ", true);

                                            }
                                        }
                                        else
                                        {

                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'Warning', title:'Correo registrado', text: 'Este correo ya esta registrado en la tabla de usuario', confirmButtonText: 'Ok' })  ", true);

                                        }

                                    }
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Correo no valido', text: 'Direccion de correo no es valida', confirmButtonText: 'Ok' })  ", true);
            }



        }

        protected void Txt_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            myParametro = Gestion_Datos.cargar_id_grupos(Txt_Grupo.Text);
            //Txt_Fk_Grupo_Usuario.Text = Convert.ToString(myParametro.Ta_id_area);
        }

        protected void Grilla_Crear_Usuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Select")
            {
                if (lbl_habilitado.Text == "Si")
                {
                    Btn_Editar.Visible = true;
                    Btn_CrearUsuario.Visible = false;
                    Btn_Restablecer.Visible = false;
                    Btn_ver_habilitados.Visible = false;
                    Btn_ver_deshabilitados.Visible = true;
                }
                else
                {
                    if (lbl_habilitado.Text == "No")
                    {
                        Btn_Editar.Visible = false;
                        Btn_CrearUsuario.Visible = false;
                        Btn_Restablecer.Visible = true;
                        Btn_ver_habilitados.Visible = true;
                        Btn_ver_deshabilitados.Visible = false;
                    }
                }

                int index = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(Grilla_Crear_Usuario.DataKeys[index].Value);
                Txt_Id_Usuario.Text = (valor);

                myParametro = Gestion_Datos.traer_Usuario_editar(Txt_Id_Usuario.Text);
                Txt_NombreUsuario.Text = myParametro.Nombre_Usuario;
                Txt_CorreoUsuario.Text = myParametro.Correo_Usuario;
                List_Rol.Text = Convert.ToString(myParametro.Rol_usuario);
                Txt_Usuario.Text = myParametro.Prefijo_Usuario;
                Txt_Grupo.SelectedValue = Convert.ToString(myParametro.fk_area_id_area);
                Txt_CorreoUsuario.Enabled = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_usuario').modal();", true);
            }
            else
            {
                if (e.CommandName == "Delete")
                {

                    if (lbl_habilitado.Text == "Si")
                    {
                        Btn_Editar.Visible = true;
                        Btn_CrearUsuario.Visible = false;
                        Btn_Restablecer.Visible = false;
                        Btn_ver_habilitados.Visible = false;
                        Btn_ver_deshabilitados.Visible = true;
                    }
                    else
                    {
                        if (lbl_habilitado.Text == "No")
                        {
                            Btn_Editar.Visible = false;
                            Btn_CrearUsuario.Visible = false;
                            Btn_Restablecer.Visible = true;
                            Btn_ver_habilitados.Visible = true;
                            Btn_ver_deshabilitados.Visible = false;
                        }
                    }
                    int index = Convert.ToInt32(e.CommandArgument);
                    string valor = Convert.ToString(Grilla_Crear_Usuario.DataKeys[index].Value);
                    Txt_Id_Usuario.Text = (valor);

                    if (myValidaciones.Existe_usuario_vinculado_aTicket(Convert.ToInt32(Txt_Id_Usuario.Text)) == true)
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El usuario tiene tickets asignados', confirmButtonText: 'Ok' })  ", true);
                    }
                    else
                    {
                        myParametro.Id_usuario = Convert.ToInt32(Txt_Id_Usuario.Text);

                        Gestion_Datos.Actualizar_usuario_des_Habilitado(myParametro);
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Usuario eliminado', confirmButtonText: 'Ok' })  ", true);
                    }
                }
            }


        }

        protected void Btn_Editar_Click(object sender, EventArgs e)
        {
            Txt_NombreUsuario.Text = Txt_NombreUsuario.Text.TrimStart();
            if (string.IsNullOrWhiteSpace(Txt_NombreUsuario.Text))         // me valida si el campo Txt_NombreUsuario esta vacio si lo esta me muestra un cuadro de dialogo
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo nombre usuario esta vacio', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {

                if (string.IsNullOrWhiteSpace(Txt_CorreoUsuario.Text))     // me valida si el campo Txt_CorreoUsuario esta vacio si lo esta me muestra un cuadro de dialogo
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' El campo correo usuario esta vacio', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {

                    if (List_Rol.SelectedValue == "1")      // me valida si el campo Txt_Cargo esta vacio si lo esta me muestra un cuadro de dialogo
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se ha seleccionado el rol del usuario', confirmButtonText: 'Ok' })  ", true);
                    }
                    else
                    {


                        if (List_Rol.SelectedValue == "3")
                        {
                            rol = 3;
                        }
                        else
                        {
                            if (List_Rol.SelectedValue == "2")
                            {
                                rol = 2;
                            }
                        }

                        if (string.IsNullOrWhiteSpace(Txt_Usuario.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' El campo usuario esta vacio', confirmButtonText: 'Ok' })  ", true);
                        }
                        else
                        {

                            if (Txt_Grupo.SelectedValue == "1")
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Sin seleccionar', text: '  Selecione un área a la cual pertenece el usuario ', confirmButtonText: 'Ok' })  ", true);
                            }
                            else
                            {


                                Txt_Contraseña.Text = Txt_Contraseña.Text.TrimStart();
                                if (string.IsNullOrWhiteSpace(Txt_Contraseña.Text))      // me valida si el campo Txt_Contraseña esta vacio si lo esta me muestra un cuadro de dialogo
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: '  El campo contraseña  esta vacio', confirmButtonText: 'Ok' })  ", true);
                                }
                                else
                                {
                                    myParametro.Id_usuario = Convert.ToInt32(Txt_Id_Usuario.Text);
                                    myParametro.Nombre_Usuario = Txt_NombreUsuario.Text;
                                    myParametro.Correo_Usuario = Txt_CorreoUsuario.Text;
                                    myParametro.Rol_usuario = rol;
                                    myParametro.Prefijo_Usuario = Txt_Usuario.Text;
                                    myParametro.fk_area_id_area = Convert.ToInt32(Txt_Grupo.SelectedValue);
                                    myParametro.Contraseña_Usuario = Txt_Contraseña.Text;

                                    if (!Gestion_Datos.editar_Usuario(myParametro))
                                    {
                                        myValidaciones.actualizar_editar_contra_usuario(Txt_CorreoUsuario.Text, Txt_Contraseña.Text, Txt_NombreUsuario.Text);

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Usuario actualizado', confirmButtonText: 'Ok' })  ", true);
                                        Txt_NombreUsuario.Text = "";
                                        Txt_CorreoUsuario.Text = "";
                                        List_Rol.Text = "--Seleccionar--";
                                        Txt_Contraseña.Text = "";
                                        Txt_Usuario.Text = "";
                                        Txt_Grupo.SelectedValue = "1";
                                        Grilla_Crear_Usuario.DataBind();

                                        Btn_Editar.Visible = false;
                                        Btn_CrearUsuario.Visible = true;
                                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_usuario').modal('hide');", true);
                                    }
                                    else

                                    {

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'ERROR AL ENVIAR', text:'Se genero un error en la base de datos al ingresar los datos', confirmButtonText: 'Ok' })  ", true);





                                    }
                                }

                            }
                        }



                    }

                }

            }




        }

        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {


            Txt_NombreUsuario.Text = "";
            Txt_CorreoUsuario.Text = "";
            List_Rol.Text = "--Seleccionar--";
            //Txt_Usuario.Text = "";
            Txt_Contraseña.Text = "";
            Txt_Grupo.SelectedValue = "--Seleccionar--";

            Btn_CrearUsuario.Visible = true;
            Btn_Editar.Visible = false;

            lbl_habilitado.Text = "Si";

            Btn_Restablecer.Visible = false;
            //Check_habilita_usuario.Checked = false;
            Grilla_Crear_Usuario.DataBind();
            Txt_Id_Usuario.Text = "id_usuario";
            Txt_Usuario.Text = "";
            Grilla_Crear_Usuario.Columns[7].Visible = true;
        }

        protected void Grilla_Crear_Usuario_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void Grilla_Crear_Usuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }




        protected void Btn_Restablecer_Click(object sender, EventArgs e)
        {

            if (Txt_Id_Usuario.Text == "id_usuario")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text:'No se ha seleccionado un usuario a reestablecer', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Txt_NombreUsuario.Text))

                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo nombre usuario esta vacio', confirmButtonText: 'Ok' })  ", true);

                }
                else
                {
                    if (string.IsNullOrWhiteSpace(Txt_CorreoUsuario.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: ' El campo correo usuario esta vacio', confirmButtonText: 'Ok' })  ", true);

                    }
                    else
                    {
                        if (List_Rol.SelectedValue == "1")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Sin seleccionar', text: ' No se ha seleccionado el rol del usuario', confirmButtonText: 'Ok' })  ", true);

                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(Txt_Contraseña.Text))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Campo vacio', text: '  El campo contraseña  esta vacio', confirmButtonText: 'Ok' })  ", true);
                            }
                            else
                            {
                                if (Txt_Grupo.SelectedValue == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se ha seleccionado el area ', confirmButtonText: 'Ok' })  ", true);
                                }
                                else
                                {

                                    myParametro.Id_usuario = Convert.ToInt32(Txt_Id_Usuario.Text);
                                    myParametro.Nombre_Usuario = Txt_NombreUsuario.Text;
                                    myParametro.Correo_Usuario = Txt_CorreoUsuario.Text;
                                    myParametro.Rol_usuario = Convert.ToInt32(List_Rol.SelectedValue);
                                    myParametro.Grupo_Usuario = Txt_Grupo.SelectedValue;
                                    myParametro.Contraseña_Usuario = Txt_Contraseña.Text;
                                    myParametro.Prefijo_Usuario = Txt_Usuario.Text;

                                    if (!Gestion_Datos.Actualizar_usuario_Habilitado(myParametro))
                                    {
                                        myValidaciones.actualizar_editar_contra_usuario(Txt_CorreoUsuario.Text, Txt_Contraseña.Text, Txt_Usuario.Text);

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Usuario habilitado', confirmButtonText: 'Ok' })  ", true);
                                        Grilla_Crear_Usuario.DataBind();

                                        if (lbl_habilitado.Text == "Si")
                                        {
                                            Btn_ver_deshabilitados.Visible = false;
                                            Btn_ver_deshabilitados.Visible = true;

                                        }
                                        else
                                        {
                                            if (lbl_habilitado.Text == "No")
                                            {
                                                Btn_ver_deshabilitados.Visible = false;
                                                Btn_ver_habilitados.Visible = true;
                                            }
                                        }


                                        Txt_NombreUsuario.Text = "";
                                        Txt_CorreoUsuario.Text = "";
                                        List_Rol.Text = "--Seleccionar--";
                                        Txt_Grupo.SelectedValue = "1";
                                        Txt_Contraseña.Text = "";
                                        Txt_Id_Usuario.Text = "id_usuario";
                                        Txt_Usuario.Text = "";
                                        Grilla_Crear_Usuario.Columns[7].Visible = true;
                                        Grilla_Crear_Usuario.DataBind();
                                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_usuario').modal('hide');", true);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'error en la base de datos', confirmButtonText: 'Ok' })  ", true);
                                    }




                                }
                            }
                        }
                    }
                }






            }

        }

        protected void Btn_Genera_contra_usuario_Click(object sender, EventArgs e)
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

        protected void btn_agregar_usuario_Click(object sender, EventArgs e)
        {
            if (lbl_habilitado.Text == "No")
            {
                Btn_ver_deshabilitados.Visible = false;
                Btn_ver_habilitados.Visible = true;
            }
            else
            {
                if (lbl_habilitado.Text == "Si")
                {
                    Btn_ver_deshabilitados.Visible = true;
                    Btn_ver_habilitados.Visible = false;
                }
            }
            Btn_CrearUsuario.Visible = true;
            Btn_Restablecer.Visible = false;
            Btn_Editar.Visible = false;
            Txt_CorreoUsuario.Enabled = true;
            Txt_NombreUsuario.Text = "";
            Txt_CorreoUsuario.Text = "";
            List_Rol.Text = "--Seleccionar--";
            Txt_Grupo.SelectedValue = "1";
            Txt_Contraseña.Text = "";
            Txt_Id_Usuario.Text = "id_usuario";
            Txt_Usuario.Text = "";


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "crear_cliente", "$('#modal_crear_usuario').modal();", true);
        }

        protected void Grilla_Crear_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Btn_ver_deshabilitados_Click(object sender, EventArgs e)
        {

            Btn_ver_deshabilitados.Visible = false;
            Btn_ver_habilitados.Visible = true;
            lbl_habilitado.Text = "No";
            //se des habilita la columna de eliminar 
            Grilla_Crear_Usuario.Columns[8].Visible = false;
            //se habilita la columna de editar para habilitar los usuarios que estan eliminados 
            Grilla_Crear_Usuario.Columns[7].Visible = true;
            Btn_Restablecer.Visible = true;
            Btn_CrearUsuario.Visible = false;
            Btn_Editar.Visible = false;
            lbl_Titulo_Eliminados.Visible = true;
            lbl_Titulo_Habilitados.Visible = false;

            Txt_NombreUsuario.Text = "";
            Txt_CorreoUsuario.Text = "";
            List_Rol.Text = "--Seleccionar--";
            Txt_Grupo.SelectedValue = "1";
            Txt_Contraseña.Text = "";
            Txt_Id_Usuario.Text = "id_usuario";

            if (Grilla_Crear_Usuario.Rows.Count != 0)
            {
                Grilla_Crear_Usuario.EmptyDataText = "No hay registros";
            }
        }

        protected void Btn_ver_habilitados_Click(object sender, EventArgs e)
        {

            Btn_ver_deshabilitados.Visible = true;
            Btn_ver_habilitados.Visible = false;
            lbl_habilitado.Text = "Si";

            Grilla_Crear_Usuario.Columns[7].Visible = true;
            Grilla_Crear_Usuario.Columns[8].Visible = true;

            Btn_Restablecer.Visible = false;
            Btn_CrearUsuario.Visible = true;
            Btn_Editar.Visible = false;
            lbl_Titulo_Eliminados.Visible = false;
            lbl_Titulo_Habilitados.Visible = true;

            Txt_NombreUsuario.Text = "";
            Txt_CorreoUsuario.Text = "";
            List_Rol.Text = "--Seleccionar--";
            Txt_Grupo.SelectedValue = "1";
            Txt_Contraseña.Text = "";
            Txt_Id_Usuario.Text = "id_usuario";
        }
    }
}