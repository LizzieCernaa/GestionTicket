//using MySql.Data;
//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Windows.Forms;


namespace DynaIT.app.forms
{
    public partial class Generar_Ticket : System.Web.UI.Page
    {
        Validaciones myValidaciones = new Validaciones();
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        Clase_Parametros myParametro = new Clase_Parametros();
        //string connectionString = @"server=localhost; userid=root; password=Diamante1020*; database=dynait;";       // cadena de conexion hacia mysql
        static string connectionString = @"Integrated Security=True;Initial Catalog=DynaIT;Data Source=DESKTOP-L5T5BI3";
        static DateTime nuevaFecha;
        static string Empresa_cliente, Adjuntos_ticket, nombre_cliente, n_usuario, correo_usuario, nombre_usuario;

        static int id_cliente, rol, id_usuario2, id_prioridad;
        static int posicion;

        protected void Page_Load(object sender, EventArgs e)
        {


            Lbl_Fecha_Ticket.Text = DateTime.Now.ToString();             //me trae el valor del la fecha y hora actual del sistema al textbox Txt_Fecha_Ticket
            Lbl_correo_inicio_sesion.Text = (string)Session["correos_inicio_sesion"];
            datos_usuario_sesion();


            if (rol == 2)
            {
                id_usuario2 = Convert.ToInt32(Lbl__Fk_id_Usuario.Text);

            }
            else
            {
                if (rol == 3)
                {

                }
                else
                {
                    if (rol == 4)
                    {

                        List_EmpresaCliente.SelectedValue = Lbl_id_empresa.Text;
                        List_NombreCliente.SelectedValue = Lbl_id_Cliente.Text;

                        List_Prioridad.SelectedValue = "1";

                        if (!IsPostBack)
                        {

                            List_EmpresaCliente.Enabled = false;
                            List_NombreCliente.Enabled = false;
                            Div_prioridad.Visible = false;
                            List_NombreCliente.SelectedValue = Convert.ToString(id_cliente);
                            cargar_lista_clientes_por_empresa(Lbl_id_empresa.Text);
                            myParametro = Gestion_Datos.traer_Correo(List_NombreCliente.SelectedValue);
                            Txt_Correo.Text = myParametro.Correo_Cliente;
                            div_lista_grupo.Visible = true;
                            div_lista_agente.Visible = false;


                        }




                    }
                    else
                    {
                        if (rol == 5)
                        {
                            List_EmpresaCliente.SelectedValue = Lbl_id_empresa.Text;


                            if (!IsPostBack)
                            {

                                List_EmpresaCliente.Enabled = false;
                                List_NombreCliente.Enabled = false;
                                List_NombreCliente.SelectedValue = Convert.ToString(id_cliente);
                                cargar_lista_clientes_por_empresa(Lbl_id_empresa.Text);
                                myParametro = Gestion_Datos.traer_Correo(List_NombreCliente.SelectedValue);
                                Txt_Correo.Text = myParametro.Correo_Cliente;
                                div_lista_grupo.Visible = true;
                                div_lista_agente.Visible = false;
                                Div_prioridad.Visible = false;

                            }
                        }
                    }
                }
            }



        }

        private void datos_usuario_sesion()
        {
            string rol_inicio_usuario = (string)Session["rol_usuario"];
            string rol_inicio_cliente = (string)Session["rol_cliente"];

            if (rol_inicio_usuario != null)
            {
                myParametro = Gestion_Datos.traer_nombre_rol_Usuario(Lbl_correo_inicio_sesion.Text);

                int id_usuario = myParametro.Id_usuario;
                nombre_usuario = myParametro.Nombre_Usuario;
                rol = myParametro.Rol_usuario;

            }
            else
            {
                if (rol_inicio_cliente != null)
                {


                    myParametro = Gestion_Datos.traer_nombre_rol_cliente(Lbl_correo_inicio_sesion.Text);

                    id_cliente = myParametro.idCliente;
                    nombre_usuario = myParametro.Nombre_Cliente;
                    rol = myParametro.Rol_Cliente;
                    Lbl_id_empresa.Text = Convert.ToString(myParametro.Id_Empresa_cliente);


                }
            }

        }

        protected void Btn_CrearTicket_Click(object sender, EventArgs e)
        {
            nuevaFecha = Convert.ToDateTime(Lbl_Fecha_Ticket.Text);


            if (List_TemaConsultoria.SelectedValue == "1")         // me valida si el campo Txt_NombreUsuario esta vacio si lo esta me muestra un cuadro de dialogo
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione el tipo de ticket', confirmButtonText: 'Ok' })  ", true);
            }
            else
            {
                myParametro = Gestion_Datos.cargar_horas_Tipos_tickes(List_TemaConsultoria.SelectedValue);
                nuevaFecha = nuevaFecha.AddHours(myParametro.Tttipo_Horas_respuesta);

                if (List_EmpresaCliente.SelectedValue == "1")      // me valida si el campo Txt_Cargo esta vacio si lo esta me muestra un cuadro de dialogo
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione la empresa la cual solicita el ticket', confirmButtonText: 'Ok' })  ", true);
                }
                else
                {
                    if (List_NombreCliente.SelectedValue == "1")      // me valida si el campo Txt_Cargo esta vacio si lo esta me muestra un cuadro de dialogo
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione el cliente que solicita el ticket', confirmButtonText: 'Ok' })  ", true);
                    }
                    else
                    {
                        if (List_Prioridad.SelectedValue == "1")      // me valida si el campo Txt_Cargo esta vacio si lo esta me muestra un cuadro de dialogo
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione la prioridad del ticket', confirmButtonText: 'Ok' })  ", true);

                        }
                        else
                        {
                            try
                            {
                                id_prioridad = Convert.ToInt32(List_Prioridad.SelectedValue);

                            }
                            catch (Exception)
                            {

                                id_prioridad = 2;
                            }

                            myParametro = Gestion_Datos.cargar_horas_Prioridad(id_prioridad);
                            nuevaFecha = nuevaFecha.AddHours(myParametro.Tprioridad_Horas_respuesta);


                            if (List_Grupo.SelectedValue == "1")      // me valida si el campo Txt_Grupo esta vacio si lo esta me muestra un cuadro de dialogo
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione el área a la cual se le asignara el ticket', confirmButtonText: 'Ok' })  ", true);

                            }
                            else
                            {
                                if (List_Agente.SelectedValue == "--Seleccionar--")      // me valida si el campo Txt_Grupo esta vacio si lo esta me muestra un cuadro de dialogo
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione el consultor que estara acargo del ticket', confirmButtonText: 'Ok' })  ", true);
                                }
                                else
                                {
                                    Txt_Resumen.Text = Txt_Resumen.Text.TrimStart();
                                    if (string.IsNullOrWhiteSpace(Txt_Resumen.Text))      // me valida si el campo Txt_Grupo esta vacio si lo esta me muestra un cuadro de dialogo
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo titulo del ticket esta vacio', confirmButtonText: 'Ok' })  ", true);
                                    }
                                    else
                                    {
                                        Txt_DetallesProblema.Text = Txt_DetallesProblema.Text.TrimStart();

                                        if (string.IsNullOrWhiteSpace(Txt_DetallesProblema.Text))      // me valida si el campo Txt_Grupo esta vacio si lo esta me muestra un cuadro de dialogo
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'El campo descripción del ticket esta vacio', confirmButtonText: 'Ok' })  ", true);
                                        }
                                        else
                                        {
                                            if (File_Archivo.HasFile == true)
                                            {

                                                string extension = System.IO.Path.GetExtension(File_Archivo.FileName);

                                                if (File_Archivo.PostedFile.ContentLength < 20971520)
                                                {
                                                    if (extension == ".txt" || extension == ".pdf" || extension == ".docx" || extension == ".rar" || extension == ".xml" || extension == ".xlsx" || extension == ".jpg" || extension == ".png" || extension == ".7z") /* Se valida los tipos de archivos que se pueden adjuntar al ticket*/
                                                    {

                                                        Cargar_achivos();

                                                        myParametro.Fecha = Convert.ToDateTime(Lbl_Fecha_Ticket.Text);
                                                        myParametro.Tipo_ticket = List_TemaConsultoria.SelectedValue;
                                                        myParametro.Resumen = Txt_Resumen.Text;
                                                        myParametro.Descripcion = Txt_DetallesProblema.Text;
                                                        myParametro.Estado = List_Estado.SelectedValue;
                                                        myParametro.Prioridad = id_prioridad;
                                                        myParametro.tiempo_Respuesta = nuevaFecha;
                                                        myParametro.Ticket_Creado_por = Lbl_correo_inicio_sesion.Text;
                                                        myParametro.Adjuntos_ticket = Adjuntos_ticket;
                                                        myParametro.Fecha_inicio_proceso = Convert.ToDateTime(Lbl_Fecha_Ticket.Text);

                                                        myParametro.Id_cliente = Lbl_id_Cliente.Text;
                                                        myParametro.Fk_Id_Usuario = Convert.ToInt32(List_Agente.SelectedValue);




                                                        if (!Gestion_Datos.insertar_Ticket(myParametro))                //Me realiza la inserciona la tabla Ticket 
                                                        {
                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos, campos vacios', confirmButtonText: 'Ok' })  ", true);
                                                        }
                                                        else
                                                        {
                                                            myParametro = Gestion_Datos.traerID_Ticket();
                                                            Lbl_id_ticket.Text = Convert.ToString(myParametro.No_ticket);

                                                            myValidaciones.Notificar_cliente_creacion_ticket(Txt_Correo.Text, nombre_cliente, Lbl_id_ticket.Text, Txt_DetallesProblema.Text, Txt_Resumen.Text);

                                                            myValidaciones.Notificar_agente_creacion_ticket(n_usuario, correo_usuario, Lbl_id_ticket.Text, Txt_DetallesProblema.Text, Txt_Resumen.Text, nombre_cliente, Empresa_cliente);


                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se ha creado el Ticket numero  ( " + Lbl_id_ticket.Text + " ) ', confirmButtonText: 'Ok' })  ", true);
                                                            Response.Redirect("Tickets_Generados_Usuario.aspx");


                                                        }

                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' el tipo de archivo no es permitido');", true);
                                                    }
                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('archivo supera el peso permitido');", true);

                                                }
                                            }
                                            else
                                            {
                                                int id_ticket;
                                                try
                                                {
                                                    myParametro = Gestion_Datos.traerID_Ticket();
                                                    id_ticket = myParametro.No_ticket + 1;
                                                }
                                                catch (Exception)
                                                {

                                                    id_ticket = 1;
                                                }



                                                var pathCarpetaDestino = System.IO.Path.Combine(@"C:\Users\dinac\Desktop\REPOSITORIO CT\Control_tickets\DynaIT\notas_usu", "" + id_ticket + "");
                                                var carpetaDestino = new System.IO.DirectoryInfo(pathCarpetaDestino);
                                                if (!carpetaDestino.Exists)
                                                    carpetaDestino.Create();

                                                Adjuntos_ticket = Convert.ToString(carpetaDestino);

                                                myParametro.Fecha = Convert.ToDateTime(Lbl_Fecha_Ticket.Text);
                                                myParametro.Tipo_ticket = List_TemaConsultoria.SelectedValue;
                                                myParametro.Resumen = Txt_Resumen.Text;
                                                myParametro.Descripcion = Txt_DetallesProblema.Text;
                                                myParametro.Estado = List_Estado.SelectedValue;
                                                myParametro.Prioridad = id_prioridad;
                                                myParametro.tiempo_Respuesta = nuevaFecha;
                                                myParametro.Ticket_Creado_por = Lbl_correo_inicio_sesion.Text;
                                                myParametro.Adjuntos_ticket = Adjuntos_ticket;
                                                myParametro.Fecha_inicio_proceso = Convert.ToDateTime(Lbl_Fecha_Ticket.Text);

                                                myParametro.Id_cliente = Lbl_id_Cliente.Text;
                                                myParametro.Fk_Id_Usuario = Convert.ToInt32(List_Agente.SelectedValue);




                                                if (!Gestion_Datos.insertar_Ticket(myParametro))                //Me realiza la inserciona la tabla Ticket 
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', text: 'Error en la base de datos, campos vacios', confirmButtonText: 'Ok' })  ", true);

                                                }
                                                else
                                                {
                                                    myParametro = Gestion_Datos.traerID_Ticket();

                                                    int n_ticket = Convert.ToInt32(myParametro.No_ticket);
                                                    Lbl_id_ticket.Text = Convert.ToString(n_ticket);

                                                    myValidaciones.Notificar_cliente_creacion_ticket(Txt_Correo.Text, nombre_cliente, Lbl_id_ticket.Text, Txt_DetallesProblema.Text, Txt_Resumen.Text);

                                                    myValidaciones.Notificar_agente_creacion_ticket(correo_usuario, n_usuario, Lbl_id_ticket.Text, Txt_DetallesProblema.Text, Txt_Resumen.Text, nombre_cliente, Empresa_cliente);

                                                    DialogResult listbox_enBlanco = MessageBox.Show("Se ha generado el Ticket numero  ( " + Lbl_id_ticket.Text + " ) satisfactoriamente", " TICKET GENERADO CORRECTAMENTE ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                                    Response.Redirect("Tickets_Generados_Usuario.aspx");


                                                }

                                            }
                                        }
                                    }
                                }
                            }







                        }


                    }
                }
            }
        }


        protected void Txt_EmpresaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_lista_clientes_por_empresa(List_EmpresaCliente.SelectedValue);
        }

        private void cargar_lista_clientes_por_empresa(string n)
        {
            // Me realiza una consulta al primer DropdownList-Empresa,  que me trae y llena el segundo DropdownList-Cliente y trae todo el listado de la columna NombreCliente de la tabla cliente
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            string query = "  SELECT id_Cliente, nombre_cliente FROM cliente " +
            " inner join empresa on cliente.empresa_id = empresa.id_empresa where id_empresa = @id_Empresas AND Cliente_Habilitado = 'Si' OR id_Cliente = '1' ";
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@id_Empresas", n);
            comando.ExecuteNonQuery();

            List_NombreCliente.DataSource = comando.ExecuteReader();
            List_NombreCliente.DataValueField = "id_Cliente";
            List_NombreCliente.DataTextField = "nombre_cliente";

            List_NombreCliente.DataBind();



            //myParametro = Gestion_Datos.traer_Cliente(List_NombreCliente.Text);
            Lbl_id_Cliente.Text = List_NombreCliente.SelectedValue;

        }


        protected void Txt_NombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //myParametro = Gestion_Datos.traer_Cliente(List_NombreCliente.SelectedValue);
            Lbl_id_Cliente.Text = List_NombreCliente.SelectedValue;
            nombre_cliente = Convert.ToString(List_NombreCliente.SelectedItem);

            myParametro = Gestion_Datos.traer_Correo(List_NombreCliente.SelectedValue);
            Txt_Correo.Text = myParametro.Correo_Cliente;

            myParametro = Gestion_Datos.traerID_Empresa_con_idCliente(Convert.ToInt32(List_NombreCliente.SelectedValue));

            myParametro = Gestion_Datos.traer_nombre_Empresa(myParametro.Fk_Empresa);

            Empresa_cliente = myParametro.Nombre_Empresa;


        }





        protected void Txt_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {

            cargar_list_agente(List_Grupo.SelectedValue);
            asignar_ticket();
        }



        protected void List_TemaConsultoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void Cargar_achivos()
        {


            foreach (var archivo in File_Archivo.PostedFiles)
            {

                int id_ticket;
                try
                {
                    myParametro = Gestion_Datos.traerID_Ticket();
                    id_ticket = myParametro.No_ticket + 1;
                }
                catch (Exception)
                {

                    id_ticket = 1;
                }




                var pathCarpetaDestino1 = System.IO.Path.Combine(@"C:\Users\dinac\Desktop\REPOSITORIO CT\Control_tickets\DynaIT\notas_usu", "" + id_ticket + "");
                var carpetaDestino1 = new System.IO.DirectoryInfo(pathCarpetaDestino1);
                if (!carpetaDestino1.Exists)
                    carpetaDestino1.Create();

                var nombreArchivo = System.IO.Path.GetFileName(archivo.FileName);
                var pathArchivoDestino1 = System.IO.Path.Combine(pathCarpetaDestino1, nombreArchivo);
                archivo.SaveAs(pathArchivoDestino1);

                Adjuntos_ticket = Convert.ToString(carpetaDestino1);

                using (var reader = new System.IO.StreamReader(archivo.InputStream))
                {
                    var contenidoTexto = reader.ReadToEnd();
                }

                var len = archivo.ContentLength;
                var bytes = new byte[len];
                archivo.InputStream.Read(bytes, 0, len);
            }







        }

        private void cargar_list_agente(string area_idarea)
        {
            // Me realiza una consulta al primer DropdownList-grupo,  que me trae y llena el segundo DropdownList-Agente de la tebal Usuario y trae todo el listado de la columna NombreUsuario de la tabla Usuario
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            string query = " SELECT id_usuario, nombre_usuario FROM usuario  " +
                " where usuario.area_id = @area_idarea and Usuario_Habilitado = 'Si' OR id_usuario = '1' OR id_usuario = '3' ";
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@area_idarea", area_idarea);
            comando.ExecuteNonQuery();


            List_Agente.DataSource = comando.ExecuteReader();
            List_Agente.DataValueField = "id_usuario";
            List_Agente.DataTextField = "nombre_usuario";
            List_Agente.DataBind();
            Lbl__Fk_id_Usuario.Text = List_Agente.SelectedValue;
        }




        protected void List_Agente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lbl__Fk_id_Usuario.Text = List_Agente.SelectedValue;

            myParametro = Gestion_Datos.traer_Usuario(List_Agente.SelectedValue);

            n_usuario = myParametro.Nombre_Usuario;
            correo_usuario = myParametro.Correo_Usuario;

        }

        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tickets_Generados_Usuario.aspx");
        }

        protected void Txt_Prioridad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void asignar_ticket()
        {
            int id_usuario;

            List<Visualizar_Tickets> usuarios_habilitados = Gestion_Datos.Traer_ultimo_usuario_ticket(Convert.ToInt32(List_Grupo.SelectedValue));

            try
            {
                //se consulta el ultimo ticket regisrado y se toma el consultor al cual esta asignado
                myParametro = Gestion_Datos.traerId_usuario_Ticket_area(Convert.ToInt32(List_Grupo.SelectedValue));
                //Se captura el id del usuario al cual esta asignado el ultimo ticket

                id_usuario = myParametro.Id_usuario;
                int id_usuario_habilitado;

                //se recorre la lista de usuarios y consultores
                foreach (var usu_habilitados in usuarios_habilitados)
                {
                    //se captura el id del usuario de la lista de usuarios habilitados en la base de datos
                    id_usuario_habilitado = usu_habilitados.Tlu_id_usuario;
                    //se compara si son iguales el id de la ultimo ticket registrado con el id de la lista de habilitados se captura la posición
                    if (id_usuario == id_usuario_habilitado)
                    {
                        posicion = usuarios_habilitados.IndexOf(usu_habilitados);
                        posicion = posicion + 1;
                    }

                }


                if (posicion >= usuarios_habilitados.Count)
                {
                    // si la posición es la mayoy o igual al catidad de objetos almacenados en la lista se le asigna el id de la posición 0 de la lista
                    id_usuario2 = usuarios_habilitados[0].Tlu_id_usuario;
                    List_Agente.SelectedValue = Convert.ToString(id_usuario2);
                }
                else
                {
                    //si la posisción es menor del total de las posiciones de la lista se le asigna el id de la siguiente posición de la lista de habilitados
                    if (posicion <= usuarios_habilitados.Count)
                    {
                        id_usuario2 = usuarios_habilitados[posicion].Tlu_id_usuario;
                        List_Agente.SelectedValue = Convert.ToString(id_usuario2);
                        myParametro = Gestion_Datos.traer_Usuario(List_Agente.SelectedValue);

                        n_usuario = myParametro.Nombre_Usuario;
                        correo_usuario = myParametro.Correo_Usuario;
                    }
                }
            }
            catch (Exception)
            {

                id_usuario2 = 1;
                List_Agente.SelectedValue = Convert.ToString(id_usuario2);
                myParametro = Gestion_Datos.traer_Usuario(List_Agente.SelectedValue);

                n_usuario = myParametro.Nombre_Usuario;
                correo_usuario = myParametro.Correo_Usuario;

            }



        }



    }
}