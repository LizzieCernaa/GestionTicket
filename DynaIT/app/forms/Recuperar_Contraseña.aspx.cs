using DynaIT.Clases;
using System;
using System.Web.UI;

namespace DynaIT.app.forms
{
    public partial class Recuperar_Contraseña : System.Web.UI.Page
    {
        Validaciones validaciones = new Validaciones();
        Clase_Parametros Clase_Parametros = new Clase_Parametros();
        Gestion_Datos datos = new Gestion_Datos();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btn_recupera_contraseña_Click(object sender, EventArgs e)
        {


            if (Txt_correo_recupera.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'Campo vacio'; text: ' No se ha ingresado el correo ', confirmButtonText: 'Ok' })  ", true);
            }
            else
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

                String Nueva_clave = contraseniaAleatoria;
                //string nombres;
                if (validaciones.Existe_Correo_usuario(Txt_correo_recupera.Text) == true)
                {
                    if (datos.recover_clave_usu(Txt_correo_recupera.Text, contraseniaAleatoria) == true)
                    {

                        if (validaciones.recuperar_contraseña(Txt_correo_recupera.Text, Txt_correo_recupera.Text, Nueva_clave) == true)
                        {
                            //Response.Redirect("../login.aspx");
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'succes', text: '  Se enviaron las credenciales por correo', confirmButtonText: 'Ok' })  ", true);




                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' El correo ingresado no se encuentra registrado ', confirmButtonText: 'Ok' })  ", true);

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'Error', text: ' Contactece con el administrador ', confirmButtonText: 'Ok' })  ", true);
                    }


                }
                else
                {
                    if (validaciones.Existe_Correo_cliente(Txt_correo_recupera.Text) == true)
                    {


                        if (datos.Recover_clave_Cli(Txt_correo_recupera.Text, contraseniaAleatoria) == true)
                        {
                            ////ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'succes', text: ' Se enviaron las credenciales por correo', confirmButtonText: 'Ok' })  ", true);

                            if (validaciones.recuperar_contraseña(Txt_correo_recupera.Text, Txt_correo_recupera.Text, Nueva_clave) == true)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({title: 'Are you sure?',text: 'You won't be able to revert this!',icon: 'warning',showCancelButton: true,confirmButtonColor: '#3085d6',cancelButtonColor: '#d33', confirmButtonText: 'Yes, delete it!' }).then((result) => { if (result.isConfirmed) {Swal.fire('Deleted!', 'Your file has been deleted.','success' ) }})  ", true);
                                //Response.Redirect("../login.aspx");



                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' El correo ingresado no se encuentra registrado ', confirmButtonText: 'Ok' })  ", true);

                            }

                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' El correo ingresado no se encuentra registrado ', confirmButtonText: 'Ok' })  ", true);
                    }

                }




            }
        }
    }
}