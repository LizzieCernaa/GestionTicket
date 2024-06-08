using DynaIT.Clases;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace DynaIT
{
    public partial class login : System.Web.UI.Page
    {
        Validaciones validaciones = new Validaciones();
        Clase_Parametros Clase_Parametros = new Clase_Parametros();
        static string var1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {


            Session["rol_cliente"] = var1;
            Session["rol_usuario"] = var1;



        }



        protected void Btn_ingresar_Click(object sender, EventArgs e)
        {

            if (Tex_correo.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Campo vacio', text: 'El campo correo esta vacio', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                if (Text_password.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title:'Campo vacio', text: 'El campo contraseña esta vacio', confirmButtonText: 'Ok' })  ", true);

                }
                else
                {

                    String expresion;
                    //"\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w[])*";
                    expresion = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([A-Za-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                    if (Regex.IsMatch(Tex_correo.Text, expresion))
                    {



                        if (validaciones.inicio_sesion_cliente(Tex_correo.Text, Text_password.Text) == true)
                        {
                            string var1 = Tex_correo.Text;

                            Session["rol_cliente"] = var1;



                            Response.Redirect("forms/perfil_Usuario.aspx?correos=" + Tex_correo.Text);

                        }
                        else
                        {
                            if (validaciones.inicio_sesion_usuario(Tex_correo.Text, Text_password.Text) == true)
                            {
                                string var1 = Tex_correo.Text;

                                Session["rol_usuario"] = var1;



                                Response.Redirect("forms/perfil_Usuario.aspx?correos=" + Tex_correo.Text);

                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Correo o credenciales invalidas', confirmButtonText: 'Ok' })  ", true);
                            }





                        }

                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Correo o credenciales invalidas', confirmButtonText: 'Ok' })  ", true);

                    }



                }
            }


        }


    }

}