using DynaIT.Clases;
using System;
//using MySql.Data;
//using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;
using Word = Microsoft.Office.Interop.Word;

namespace DynaIT.app.forms
{
    public partial class Notas_usuario : System.Web.UI.Page
    {
        Validaciones myValidaciones = new Validaciones();
        Gestion_Datos gestion_Datos = new Gestion_Datos();
        Clase_Parametros myparametro = new Clase_Parametros();
        Visualizar_Tickets Visualizar = new Visualizar_Tickets();


        string fecha_inicio_proceso, nombre_usuario_sesion;
        DateTime Fecha_resuelto_ticket = DateTime.Now, fecha_cierre = DateTime.Now;
        static int cont_desarrollo, n_horas, id_acta = 0, id_usuario_sesion, id_estado_ticket,
            n_cre_gara = 0, n_cred_diferencia = 0, rol_usuario_sesion, Nota_usuario, fk_usu_nota_id, fk_clie_nota_id;
        static string nota_interna = "No", ruta, Adjuntos_nota = "0", Representante_empresa, Nombre_Empresa, Usuario, prefijo_consultor, ruta_adjun_nota = "0", n_usuario, correo_usuario_usu_asig;
        static Label[] arreglolabel, arreglo2;
        static int contadorControles;


        protected void Page_Load(object sender, EventArgs e)
        {

            lbl_fecha_nota.Text = DateTime.Now.ToString();
            lbl_correo_sesion.Text = (string)Session["correos_inicio_sesion"];

            if (!IsPostBack)
            {
                lblContador.Text = "";
                arreglo2 = new Label[5];
                arreglolabel = new Label[5];

                contadorControles = 0;


            }

            try
            {
                for (int i = 0; i < contadorControles; i++)
                    for (int y = 0; y < contadorControles; y++)

                        AgregarControles(arreglolabel[i], arreglo2[y]);
            }
            catch (Exception ex)
            {
                lblContador.Text = ex.Message;
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (Request.QueryString["id"] == null)
                        return;
                    Lbl_id_ticket.Text = Convert.ToString(Request.QueryString["id"].ToString());

                    //Grilla_notas_ticket.DataSourceID = "Tabla_notas_2";
                }
                else
                {
                    if (Request.QueryString["id2"] != null)
                    {
                        if (Request.QueryString["id2"] == null)

                            return;
                        Lbl_id_ticket.Text = Request.QueryString["id2"].ToString();

                    }
                }

                cargar_datos_ticket();


            }

            cargar_datos_usuario_sesion();


            listar_notas(Lbl_id_ticket.Text);





            if (rol_usuario_sesion == 2)
            {


                Txt_Resumen_ticket.Enabled = true;
                //Grilla_notas_ticket.Columns[4].Visible = true;
                if (!IsPostBack)
                {
                    if (id_estado_ticket == 6)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'error', title: 'El ticket se encuentra cerrado', confirmButtonText: 'Ok' })  ", true);
                    }
                }


            }
            else
            {
                if (rol_usuario_sesion == 3)
                {
                    List_clientes_empresa.Enabled = false;
                    List_Usuarios.Enabled = false;
                    //Grilla_notas_ticket.Columns[4].Visible = true;


                    if (id_estado_ticket == 5)
                    {
                        List_estados.Enabled = false;

                        Txt_Resumen_ticket.Enabled = false;
                        List_clientes_empresa.Enabled = false;
                        List_Usuarios.Enabled = false;
                        Txt_descripcion_nota.Disabled = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' El ticket se encuentra CERRADO');", true);
                    }
                }
                else
                {
                    if (rol_usuario_sesion == 4)
                    {

                        Btn_Agregar_consultores.Visible = false;

                        nota_interna = "No";
                        List_estados.Enabled = false;
                        List_Usuarios.Enabled = false;
                        Btn_Agregar_consultores.Visible = false;
                        Check_nota_interna.Visible = false;
                        check_genera_acta.Visible = false;
                        Btn_fusionar_ticket.Visible = false;



                        if (id_estado_ticket == 5)
                        {
                            List_estados.Enabled = false;
                            Txt_Resumen_ticket.Enabled = false;
                            List_clientes_empresa.Enabled = false;
                            List_Usuarios.Enabled = false;
                            Txt_descripcion_nota.Disabled = true;
                            Btn_fusionar_ticket.Visible = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' El ticket se encuentra CERRADO');", true);
                        }
                    }
                    else
                    {
                        if (rol_usuario_sesion == 5)
                        {


                            Btn_Agregar_consultores.Visible = false;
                            Check_nota_interna.Visible = false;
                            check_genera_acta.Visible = false;
                            List_Usuarios.Enabled = false;

                            nota_interna = "No";
                            List_clientes_empresa.Enabled = false;


                            if (id_estado_ticket == 5)
                            {
                                List_estados.Enabled = false;
                                Txt_Resumen_ticket.Enabled = false;
                                List_clientes_empresa.Enabled = false;
                                List_Usuarios.Enabled = false;
                                Txt_descripcion_nota.Disabled = true;
                                ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' El ticket se encuentra CERRADO');", true);
                            }
                        }
                    }
                }
            }

            listar_adjuntos(lbl_ruta.Text);

            listar_adjuntos_nota(ruta_adjun_nota);

            //Grilla_notas_ticket.Columns[5].Visible = false;
            lbl_n_creditos.Visible = false;


        }
        private void cargar_datos_usuario_sesion()
        {
            string rol_inicio_usuario = (string)Session["rol_usuario"];
            string rol_inicio_cliente = (string)Session["rol_cliente"];

            if (rol_inicio_usuario != null)
            {
                myparametro = gestion_Datos.traer_nombre_rol_Usuario(lbl_correo_sesion.Text);

                id_usuario_sesion = myparametro.Id_usuario;
                nombre_usuario_sesion = myparametro.Nombre_Usuario;
                rol_usuario_sesion = myparametro.Rol_usuario;

                fk_usu_nota_id = id_usuario_sesion;
                fk_clie_nota_id = Convert.ToInt32(Lbl_id_cliente.Text);

                Nota_usuario = 1;
            }
            else
            {
                if (rol_inicio_cliente != null)
                {
                    myparametro = gestion_Datos.traer_nombre_rol_cliente(lbl_correo_sesion.Text);

                    id_usuario_sesion = myparametro.idCliente;
                    nombre_usuario_sesion = myparametro.Nombre_Cliente;
                    rol_usuario_sesion = myparametro.Rol_Cliente;
                    int Id_Empresa_cliente = myparametro.Id_Empresa_cliente;

                    fk_usu_nota_id = Convert.ToInt32(lbl_id_usuario.Text);
                    fk_clie_nota_id = id_usuario_sesion;
                    Nota_usuario = 0;

                }
            }
        }

        private void cargar_datos_ticket()
        {
            myparametro = gestion_Datos.traer_datos_ticket(Convert.ToInt32(Lbl_id_ticket.Text));

            Txt_Resumen_ticket.Text = myparametro.Resumen;
            Lbl_Tipo_Ticket.Text = myparametro.Tipo_ticket;
            List_estados.SelectedValue = Convert.ToString(myparametro.estado_idEstado_nota);
            Lbl_descripcion.Text = myparametro.Descripcion;
            Lbl_fecha.Text = Convert.ToString(myparametro.Fecha);
            lbl_Nombre_Cliente.Text = myparametro.Nombre_Cliente;
            List_Usuarios.SelectedValue = Convert.ToString(myparametro.Usuario_idUsuario_nota);
            Lbl_id_cliente.Text = Convert.ToString(myparametro.cliente_idCliente_nota);
            lbl_id_usuario.Text = Convert.ToString(myparametro.Usuario_idUsuario_nota);
            Lbl_id_estado.Text = Convert.ToString(myparametro.estado_idEstado_nota);
            lbl_tiempo_respuesta.Text = Convert.ToString(myparametro.tiempo_Respuesta);
            lbl_fecha_inicio.Text = Convert.ToString(myparametro.Fecha_inicio_proceso);
            lbl_id_empresa.Text = Convert.ToString(myparametro.id_Empresa);
            List_clientes_empresa.SelectedValue = Convert.ToString(myparametro.cliente_idCliente_nota);
            Nombre_Empresa = myparametro.Nombre_Empresa;
            Representante_empresa = myparametro.Representante_empresa;
            Usuario = myparametro.Usuario;
            id_estado_ticket = myparametro.estado_idEstado_nota;

            ruta = myparametro.Adjuntos_ticket;
            lbl_ruta.Text = ruta;

            cont_desarrollo = myparametro.TiempoDesarrollo;


            listar_notas(Lbl_id_ticket.Text);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Panel_notas.Controls.Clear();
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Validacion_JavaScript", "function show_confirm()", true);
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "text", "ver_adjuntos()", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Panel_notas.Controls.Clear();
            //listar_adjuntos_nota(ruta_adjun_nota);
        }

        protected void listar_adjuntos(string ruta_adjuntos)
        {
            
            DirectoryInfo di = new DirectoryInfo(ruta_adjuntos);  /*se carga la variable di con la ruta que se trae de la base de datos atravez del parametro */
            FileInfo[] files = di.GetFiles();   /*trae la lista de nombres de los archivos almacenados en la ruta de la linea anterios */
            foreach (FileInfo file in files)     /*Se realia el arreglo para listar los documentos adjuntos del ticket unicados en la carpeta*/
            {
                LinkButton link = new LinkButton();    /*Se crea una instancia del control linkbuton para listar los adjuntos de la carpeta*/

                link.Style["font-weight"] = "normal";
                link.Style["font-weight"] = "bold";
                link.Style["width"] = "50%";

                link.Style["white-space"] = "pre";
                link.Style["padding"] = "5px";
                link.Style["color"] = "cadetblue";
                link.Style["size"] = "XX-Small";

                link.Text = file.Name;
                link.CommandArgument = file.Name;                   /*Se envia la ruta de archivo que se crea en cada linkbuto para la descarga*/
                link.Click += new System.EventHandler(Descargar);   /* Se ejecuta el metodo al realizar el clic en el linkbutton*/
                Panel3.Controls.Add(link);   /*se agrega un nuevo linkbutton por cada archivo encontrado en la ruta en el panel de la vista*/

            }

        }

        protected void Tickets_fusionar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);   //toma el numero de la fila seleccionada y la comvierte en un valor entero
            int valor = Convert.ToInt32(Tickets_fusionar.DataKeys[index].Value);


            if (myValidaciones.Existe_ticket(Convert.ToString(valor)))
            {
                Tickets_fusionar.Visible = false;
                myparametro = gestion_Datos.traer_datos_ticket(valor);

                id_ticket_duscado.Text = Convert.ToString(myparametro.No_ticket);
                lbl_titulo_t_buscado.Text = myparametro.Resumen;
                lbl_descripcion_buscado.Text = myparametro.Descripcion;
                lbl_estado_buscado.Text = myparametro.Estado;
                Cancerlar_seleccón.Visible = true;
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' Numero de ticket no encontrado ');", true);
            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void Cancerlar_seleccón_Click(object sender, EventArgs e)
        {
            Tickets_fusionar.Visible = true;
            id_ticket_duscado.Text = "";
            lbl_titulo_t_buscado.Text = "";
            lbl_descripcion_buscado.Text = "";
            lbl_estado_buscado.Text = "";
            Cancerlar_seleccón.Visible = false;
        }

        public void agregar_agente_nota()
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {



            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cargar()", true);
        }

        protected void Btn_buscar_ticket_Click(object sender, EventArgs e)
        {
            if (txt_id_ticket_buscar.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' Digite el numero de ticket a buscar');", true);
            }
            else
            {
                if (myValidaciones.Existe_ticket(txt_id_ticket_buscar.Text))
                {
                    myparametro = gestion_Datos.traer_datos_ticket(Convert.ToInt32(txt_id_ticket_buscar.Text));

                    id_ticket_duscado.Text = Convert.ToString(myparametro.No_ticket);
                    lbl_titulo_t_buscado.Text = myparametro.Resumen;
                    lbl_descripcion_buscado.Text = myparametro.Descripcion;
                    lbl_estado_buscado.Text = Convert.ToString(myparametro.estado_idEstado_nota);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' Numero de ticket no encontrado ');", true);
                }


            }


        }

        protected void btn_fusionar_Click(object sender, EventArgs e)
        {

            if (lbl_estado_buscado.Text != "5")
            {



                if (myValidaciones.Existe_notas_ticket(id_ticket_duscado.Text))
                {
                    List<Visualizar_Tickets> lista_notas_fusionar = new List<Visualizar_Tickets>();
                    lista_notas_fusionar = gestion_Datos.traer_notas_usuarios(id_ticket_duscado.Text);
                    foreach (var L_tic_fusion in lista_notas_fusionar)
                    {
                        try
                        {
                            myparametro.id_notas = L_tic_fusion.idnotas;
                            myparametro.descripcionNota = "<div style = 'background-color:gainsboro;'><p style ='color: red;' ><small style='font-size:.6em; '> N_ticket: " + id_ticket_duscado.Text + "</small></p></div>";
                            myparametro.Ticket_idTicket_nota = Lbl_id_ticket.Text;
                            gestion_Datos.fusionar_nota(myparametro);
                        }
                        catch (Exception)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' Error en la base de datos');", true);

                        }

                    }
                }

                /// se genera update en caso de que se cambie le estado del ticket y el asignatario
                myparametro.No_ticket = Convert.ToInt32(Lbl_id_ticket.Text);
                myparametro.Estado = List_estados.SelectedValue;
                myparametro.Fecha_inicio_proceso = Convert.ToDateTime(lbl_fecha_inicio.Text);
                myparametro.Fk_Id_Usuario = Convert.ToInt32(List_Usuarios.SelectedValue);
                myparametro.h_adicionales = Convert.ToInt32(lbl_n_creditos.Text);
                myparametro.Fecha_resuelto_ticket = Fecha_resuelto_ticket;
                //sasasasasas
                myparametro.Fecha_cierre_ticket = fecha_cierre;
                myparametro.Resumen_Problema = Txt_Resumen_ticket.Text;
                myparametro.Descripcion = " <div style='background-color:gainsboro; '><h5> " + " N_ tICKET: " + id_ticket_duscado.Text + "</h5><h3> " + lbl_titulo_t_buscado.Text + " </h3> <p> " + lbl_descripcion_buscado.Text + "</p><p></p> </div> " + Lbl_descripcion.Text + "  ";
                myparametro.Cliente_idCliente = List_clientes_empresa.SelectedValue;
                myparametro.N_creditos_garantia = n_cre_gara;

                gestion_Datos.editar_ticket(myparametro);

                gestion_Datos.Eliminar_id_fusionado(id_ticket_duscado.Text);
                ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' Se fusiono ');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' El ticket se encuentra cerrado y no es posible fusionarlo ');", true);
            }
        }




        protected void Check_nota_interna_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_nota_interna.Checked)
            {
                nota_interna = "Si";

            }
            else
            {
                nota_interna = "No";


            }
        }

        protected void check_genera_acta_CheckedChanged(object sender, EventArgs e)
        {

            if (check_genera_acta.Checked)
            {


                nota_interna = "No";

                //se toma la hora en la que se cambia de estado para calcular el tiempo que duro en proceso
                DateTime hora_final = Convert.ToDateTime(DateTime.Now.ToString());

                //se convierte el a dataTime la hora en que se cambio el estado a en-proceso 
                DateTime hora_inicio = Convert.ToDateTime(lbl_fecha_inicio.Text);

                //se le restan a la hora final la hora de inicio para hallar las horas que duro en proceso
                TimeSpan resultado_horas = hora_final.Subtract(hora_inicio);

                // se almacena el toal de horas en el contador para almacenarlo
                n_horas = Convert.ToInt32(resultado_horas.TotalHours);


                N_creditos.Value = Convert.ToString(n_horas);



                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "agregar_creditos();", true);



            }

        }

        protected void List_clientes_empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            myparametro = gestion_Datos.Traer_datosCliente(List_clientes_empresa.SelectedValue);

        }

        protected void btn_agregar_creditos_Click2(object sender, EventArgs e)
        {
            lbl_n_creditos.Text = N_creditos.Value;
            check_genera_acta.Enabled = false;
        }


        protected void Btn_agrega_agente_Click(object sender, EventArgs e)
        {
            try
            {
                int numeroRegistros = contadorControles;
                int contadorlabel2 = contadorControles;
                Label labelN = new Label();
                labelN.Text = List_agregar_agentes_nota.SelectedItem.Text;
                labelN.Style["margin"] = "7px";
                labelN.Style["width"] = "100%";
                arreglolabel[numeroRegistros] = labelN;

                Label label2 = new Label();
                label2.Text = List_agregar_agentes_nota.SelectedValue;
                label2.Visible = false;
                arreglo2[contadorlabel2] = label2;

                AgregarControles(labelN, label2);
                contadorControles++;

            }
            catch (Exception)
            {
                lblContador.Text = "El numero maximo de agentes permitidos es 5";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "agregar_consultor()", true);
        }
        public void insertar_notas_compartidas(int id_nota)
        {
            for (int i = 0; i < contadorControles; i++)
            {
                string id_usuario = arreglo2[i].Text;

                myparametro.nota_idNota_compartida = id_nota;
                myparametro.usuario_idUsuario_compartida = id_usuario;

                if (gestion_Datos.insertar_nota_compartida(myparametro) == true)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' Error al notificar uno de los consultores asociados al caso');", true);

                }


            }

        }

        public void notificar_consultores_asociados(string nota_descripcion)
        {
            if (contadorControles != 0)
            {
                for (int i = 0; i < contadorControles; i++)
                {
                    string id_usuario = arreglo2[i].Text;

                    myparametro = gestion_Datos.traer_Usuario_editar(id_usuario);

                    myValidaciones.Notificar_consultores(myparametro.Correo_Usuario, myparametro.Nombre_Usuario, Lbl_id_ticket.Text, nota_descripcion);

                }
            }

        }



        protected void AgregarControles(Label txt, Label lbl2)
        {
            //agrega labels al panel con los agentes a los cuales se les va a compartir la nota
            Panel_agentes_nota.Controls.Add(lbl2);
            Panel_agentes_nota.Controls.Add(txt);

        }

        public void Descargar(object sender, EventArgs e)
        {


            LinkButton btn = (LinkButton)(sender);    /*Se crea una instancia de linkbutton  */
            string archivo_descargar = btn.CommandArgument;  /*Se recibe la ruta del  archivo para cada linkbuton creado, enviada en la propiedad commendAgument en el evento click de cada commandAgument*/

            Response.ContentType = "";
            Response.AppendHeader("Content-Disposition", "attachment; filename= " + archivo_descargar + "");
            string rutas = System.IO.Path.Combine(lbl_ruta.Text, archivo_descargar); /*Se combinan la ruta con el nombre del archivo a descargar */
            Response.TransmitFile(rutas); /*Se accede a la ruta del archivo para descargar*/
            Response.End();      /*Se realiza la descarga del archivo*/


        }


        private void listar_adjuntos_nota(string ruta_adjuntos)
        {



            DirectoryInfo di_nota = new DirectoryInfo(ruta_adjuntos);  /*se carga la variable di con la ruta que se trae de la base de datos atravez del parametro */
            ruta_nota.Text = Convert.ToString(di_nota);

            FileInfo[] files = di_nota.GetFiles();   /*trae la lista de nombres de los archivos almacenados en la ruta de la linea anterios */
            object n = 0;


            foreach (FileInfo file_nota in files)     /*Se realia el arreglo para listar los documentos adjuntos del ticket unicados en la carpeta*/
            {


                LinkButton btn = new LinkButton();    /*Se crea una instancia del control linkbuton para listar los adjuntos de la carpeta*/
                btn.Style["font-weight"] = "normal";
                btn.Style["font-weight"] = "bold";
                btn.Style["padding"] = "5px";
                btn.Style["color"] = "cadetblue";
                btn.Style["size"] = "XX-Small";
                btn.Text = file_nota.Name;
                btn.CommandArgument = file_nota.Name;                   /*Se envia la ruta de archivo que se crea en cada linkbuto para la descarga*/
                btn.Click += new System.EventHandler(Descargar_notas);   /* Se ejecuta el metodo al realizar el clic en el linkbutton*/


                Panel_notas.Controls.Add(btn);   /*se agrega un nuevo linkbutton por cada archivo encontrado en la ruta en el panel de la vista*/
            }



        }

        protected void Descargar_notas(object sender, EventArgs e)
        {

            LinkButton btn1 = (LinkButton)(sender);    /*Se crea una instancia de linkbutton  */
            string archivo_descargar_notas = btn1.CommandArgument; /*btn1.CommandArgument*/;  /*Se recibe la ruta del  archivo para cada linkbuton creado, enviada en la propiedad commendAgument en el evento click de cada commandAgument*/

            Response.ContentType = "";
            Response.AppendHeader("Content-Disposition", "attachment; filename= " + archivo_descargar_notas + "");
            string rutas_notas = System.IO.Path.Combine(ruta_nota.Text, archivo_descargar_notas); /*Se combinan la ruta con el nombre del archivo a descargar */
            Response.TransmitFile(rutas_notas); /*Se accede a la ruta del archivo para descargar*/
            Response.End();      /*Se realiza la descarga del archivo*/


        }


        protected void limpiar_modal_c()
        {
            Panel_notas.Controls.Clear();
            //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Se limpia el panel.....');", true);
        }







        protected void Btn_agregar_Nota_Click(object sender, EventArgs e)
        {
            string nota_descripcion = Txt_descripcion_nota.Value;

            string extension = System.IO.Path.GetExtension(file_nota.FileName);

            if (file_nota.HasFile)
            {
                if (file_nota.PostedFile.ContentLength < 20971520)
                {
                    if (extension == ".txt" || extension == ".pdf" || extension == ".docx" || extension == ".rar" || extension == ".xml" || extension == ".xlsx" || extension == ".jpg" || extension == ".png" || extension == ".7z") /* Se valida los tipos de archivos que se pueden adjuntar al ticket*/
                    {
                        myparametro = gestion_Datos.traerID_nota();
                        int n_nota = Convert.ToInt32(myparametro.id_notas);

                        n_nota = n_nota + 1;

                        foreach (var archivo in file_nota.PostedFiles)
                        {
                            var informacionDelArchivo = String.Format("{0} es de tipo {1} y tiene un tamaño de {2} KB.", archivo.FileName, archivo.ContentType, archivo.ContentLength / 1024);

                            var pathCarpetaDestino = System.IO.Path.Combine(lbl_ruta.Text, " " + n_nota + "");
                            var carpetaDestino = new System.IO.DirectoryInfo(pathCarpetaDestino);
                            if (!carpetaDestino.Exists)
                                carpetaDestino.Create();


                            var nombreArchivo = System.IO.Path.GetFileName(archivo.FileName);
                            var pathArchivoDestino = System.IO.Path.Combine(pathCarpetaDestino, nombreArchivo);
                            archivo.SaveAs(pathArchivoDestino);

                            Adjuntos_nota = Convert.ToString(carpetaDestino);

                            using (var reader = new System.IO.StreamReader(archivo.InputStream))
                            {
                                var contenidoTexto = reader.ReadToEnd();
                            }

                            var len = archivo.ContentLength;
                            var bytes = new byte[len];
                            archivo.InputStream.Read(bytes, 0, len);
                        }


                        creacion_nota();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire(' el tipo de archivo no es permitido');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire('archivo supera el peso permitido');", true);
                }
            }
            else
            {
                myparametro = gestion_Datos.traerID_nota();
                int n_nota = 0 /*Convert.ToInt32(myparametro.id_notas)*/;

                n_nota = n_nota + 1;

                var pathCarpetaDestino = System.IO.Path.Combine(lbl_ruta.Text, " " + n_nota + "");
                var carpetaDestino = new System.IO.DirectoryInfo(pathCarpetaDestino);
                if (!carpetaDestino.Exists)
                    carpetaDestino.Create();

                Adjuntos_nota = Convert.ToString(carpetaDestino);



                creacion_nota();

                myparametro = gestion_Datos.traerID_nota();
                int idNot = myparametro.id_notas;


                insertar_notas_compartidas(idNot);
                notificar_consultores_asociados(nota_descripcion);

                //}

                Check_nota_interna.Checked = false;
                check_genera_acta.Checked = false;
                N_creditos.Value = "0";


            }



        }

        private void creacion_nota()
        {
            Txt_descripcion_nota.Value = Txt_descripcion_nota.Value.TrimStart();

            if (string.IsNullOrWhiteSpace(Txt_descripcion_nota.Value))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire('La descripcion de la nota esta vacia');", true);
            }
            else
            {
                if (Lbl_id_estado.Text == "2")
                {
                    if (List_estados.SelectedValue == "2")
                    {

                        fecha_inicio_proceso = lbl_fecha_inicio.Text;
                    }
                    else
                    {


                        if (List_estados.SelectedValue == "3")
                        {

                            fecha_inicio_proceso = DateTime.Now.ToString();
                            lbl_fecha_inicio.Text = fecha_inicio_proceso;
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se agrega la nota y se inicio el desarrollo del ticket', confirmButtonText: 'Ok' })  ", true);


                        }
                        else
                        {

                            if (List_estados.SelectedValue == "4")
                            {
                                Fecha_resuelto_ticket = DateTime.Now;
                                fecha_cierre = fecha_cierre.AddHours(24);
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Ticket resulto, se cerrara automaticamente en 24 hotas', confirmButtonText: 'Ok' })  ", true);
                            }
                            else
                            {
                                if (List_estados.SelectedValue == "5")
                                {

                                    fecha_cierre = DateTime.Now;
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Cerrado', text: ' Ticket cerrado ', confirmButtonText: 'Ok' })  ", true);
                                }
                            }

                        }
                    }
                }
                else
                {

                    if (Lbl_id_estado.Text == "3")
                    {
                        if (List_estados.SelectedValue == "2")
                        {
                            fecha_inicio_proceso = lbl_fecha_inicio.Text;

                            //se toma la hora en la que se cambia de estado para calcular el tiempo que duro en proceso
                            DateTime hora_final = Convert.ToDateTime(DateTime.Now.ToString());

                            //se convierte el a dataTime la hora en que se cambio el estado a en-proceso 
                            DateTime hora_inicio = Convert.ToDateTime(lbl_fecha_inicio.Text);

                            //se le restan a la hora final la hora de inicio para hallar las horas que duro en proceso
                            TimeSpan resultado_horas = hora_final.Subtract(hora_inicio);

                            // se almacena el toal de horas en el contador para almacenarlo
                            n_horas = Convert.ToInt32(resultado_horas.TotalHours);

                            //se notifica el numero de horas que se almacenaron
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se agrega la nota, el numero de horas de desarrollo fueron " + n_horas + " y su estado cambia abierto ', confirmButtonText: 'Ok' })  ", true);

                        }
                        else
                        {
                            if (List_estados.SelectedValue == "3")
                            {
                                fecha_inicio_proceso = DateTime.Now.ToString();
                                lbl_fecha_inicio.Text = fecha_inicio_proceso;

                                //se toma la hora en la que se cambia de estado para calcular el tiempo que duro en proceso
                                DateTime hora_final = Convert.ToDateTime(DateTime.Now.ToString());

                                //se convierte el a dataTime la hora en que se cambio el estado a en-proceso 
                                DateTime hora_inicio = Convert.ToDateTime(lbl_fecha_inicio.Text);

                                //se le restan a la hora final la hora de inicio para hallar las horas que duro en proceso
                                TimeSpan resultado_horas = hora_final.Subtract(hora_inicio);

                                // se almacena el toal de horas en el contador para almacenarlo
                                n_horas = Convert.ToInt32(resultado_horas.TotalHours);
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'No se cambio el estado del ticket, sigue en proceso y se agrega la nota ', confirmButtonText: 'Ok' })  ", true);

                            }
                            else
                            {
                                if (List_estados.SelectedValue == "4")
                                {
                                    //se notifica el numero de horas que se almacenaron
                                    Fecha_resuelto_ticket = DateTime.Now;
                                    fecha_cierre = fecha_cierre.AddHours(24);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se agrega la nota, el numero de horas de desarrollo fueron " + n_horas + " y el estado cambia a ( Pendiente ) ', confirmButtonText: 'Ok' })  ", true);

                                }
                                else
                                {
                                    if (List_estados.SelectedValue == "5")
                                    {
                                        fecha_cierre = DateTime.Now;
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Cerrado', text: ' Ticket cerrado ', confirmButtonText: 'Ok' })  ", true);

                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        if (Lbl_id_estado.Text == "4")
                        {
                            if (List_estados.SelectedValue == "2")
                            {
                                fecha_inicio_proceso = lbl_fecha_inicio.Text;
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', title: 'Reabierto', text: ' Ticket re abierto ', confirmButtonText: 'Ok' })  ", true);
                            }
                            else
                            {
                                if (List_estados.SelectedValue == "3")
                                {


                                    fecha_inicio_proceso = DateTime.Now.ToString();
                                    lbl_fecha_inicio.Text = fecha_inicio_proceso;
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'En proceso', text: ' Se agrega la nota y el ticket queda en estado en proceso', confirmButtonText: 'Ok' })  ", true);

                                }
                                else
                                {
                                    if (List_estados.SelectedValue == "4")
                                    {
                                        Fecha_resuelto_ticket = DateTime.Now;
                                        fecha_cierre = fecha_cierre.AddHours(24);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Resuelto', text: ' Ticket resuelto y se cerrara en 24 horas', confirmButtonText: 'Ok' })  ", true);
                                    }
                                    else
                                    {
                                        if (List_estados.SelectedValue == "5")
                                        {
                                            fecha_cierre = DateTime.Now;
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Cerrado', text: ' Ticket cerrado ', confirmButtonText: 'Ok' })  ", true);
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (Lbl_id_estado.Text == "5")
                            {
                                if (List_estados.SelectedValue == "2")
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: 'Se agrega la nota, el ticket cambio de estado cerrado a abierto ', confirmButtonText: 'Ok' })  ", true);
                                    fecha_inicio_proceso = lbl_fecha_inicio.Text;
                                }
                                else
                                {
                                    if (List_estados.SelectedValue == "3")
                                    {
                                        fecha_inicio_proceso = DateTime.Now.ToString();
                                        lbl_fecha_inicio.Text = fecha_inicio_proceso;
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' Se agrega la nota e inicio el desarrollo del ticket ', confirmButtonText: 'Ok' })  ", true);
                                    }
                                    else
                                    {
                                        if (List_estados.SelectedValue == "4")
                                        {
                                            Fecha_resuelto_ticket = DateTime.Now;
                                            fecha_cierre = Fecha_resuelto_ticket.AddHours(24);
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' Se agrega la nota, el ticket cambio de estado cerrado a resuelto ', confirmButtonText: 'Ok' })  ", true);
                                        }
                                        else
                                        {
                                            if (List_estados.SelectedValue == "5")
                                            {
                                                fecha_cierre = DateTime.Now;
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Cerrado', text: ' Ticket cerrado ', confirmButtonText: 'Ok' })  ", true);

                                            }
                                        }
                                    }
                                }

                            }

                        }
                    }

                }


                if (List_estados.SelectedValue == "4")
                {
                    myparametro = gestion_Datos.traer_Cliente_editar(Lbl_id_cliente.Text);
                    myValidaciones.Notificar_solucion_ticket(myparametro.Correo_Cliente, myparametro.Nombre_Cliente, Lbl_id_ticket.Text, Txt_descripcion_nota.Value);
                }

                if (List_estados.SelectedValue == "5")
                {
                    myparametro = gestion_Datos.traer_Cliente_editar(Lbl_id_cliente.Text);
                    myValidaciones.Notificar_cierre_ticket(myparametro.Correo_Cliente, myparametro.Nombre_Cliente, Lbl_id_ticket.Text, Txt_descripcion_nota.Value);
                }



                if (check_genera_acta.Checked == true)
                {
                    crearDocumento();
                }

                if (nota_interna == "No")
                {
                    if (Lbl_id_cliente.Text == List_clientes_empresa.SelectedValue)
                    {

                        myparametro = gestion_Datos.traer_Cliente_editar(Lbl_id_cliente.Text);
                        myValidaciones.Notificar_cliente_creacion_nota(myparametro.Correo_Cliente, myparametro.Nombre_Cliente, Lbl_id_ticket.Text, Txt_descripcion_nota.Value, Txt_Resumen_ticket.Text, Nombre_Empresa);
                    }
                    else
                    {
                        if (Lbl_id_cliente.Text != List_clientes_empresa.SelectedValue)
                        {
                            myparametro = gestion_Datos.traer_Cliente_editar(List_clientes_empresa.SelectedValue);
                            myValidaciones.Notificar_cliente_reasigan_creacion_nota(myparametro.Correo_Cliente, myparametro.Nombre_Cliente, Lbl_id_ticket.Text, Txt_descripcion_nota.Value, Txt_Resumen_ticket.Text, Nombre_Empresa);
                        }

                    }
                }

                if (List_Usuarios.SelectedValue != lbl_id_usuario.Text)
                {

                    myparametro = gestion_Datos.traer_Usuario(List_Usuarios.SelectedValue);

                    myValidaciones.Notificar_usuario_asigna_ticket(myparametro.Correo_Usuario, myparametro.Nombre_Usuario, Lbl_id_ticket.Text, Txt_descripcion_nota.Value, Txt_Resumen_ticket.Text);
                }
                else
                {
                    if (List_Usuarios.SelectedValue == lbl_id_usuario.Text)
                    {
                        myparametro = gestion_Datos.traer_Usuario(lbl_id_usuario.Text);
                        n_usuario = myparametro.Nombre_Usuario;
                        correo_usuario_usu_asig = myparametro.Correo_Usuario;
                        myValidaciones.Notificar_agente_creacion_nota(correo_usuario_usu_asig, n_usuario, Lbl_id_ticket.Text, Txt_descripcion_nota.Value, Txt_Resumen_ticket.Text, Nombre_Empresa);
                    }

                }

                /// se genera update en caso de que se cambie le estado del ticket y el asignatario
                myparametro.No_ticket = Convert.ToInt32(Lbl_id_ticket.Text);
                myparametro.Estado = List_estados.SelectedValue;
                myparametro.Fecha_inicio_proceso = Convert.ToDateTime(lbl_fecha_inicio.Text);
                myparametro.Fk_Id_Usuario = Convert.ToInt32(List_Usuarios.SelectedValue);
                myparametro.h_adicionales = Convert.ToInt32(lbl_n_creditos.Text);
                myparametro.Fecha_resuelto_ticket = Fecha_resuelto_ticket;
                //sasasasasas
                myparametro.Fecha_cierre_ticket = fecha_cierre;
                myparametro.Resumen_Problema = Txt_Resumen_ticket.Text;
                myparametro.Descripcion = Lbl_descripcion.Text;
                myparametro.Cliente_idCliente = List_clientes_empresa.SelectedValue;
                myparametro.N_creditos_garantia = n_cre_gara;

                gestion_Datos.editar_ticket(myparametro);


                // se inserta la nota dependiendo el ticket
                myparametro.descripcionNota = Txt_descripcion_nota.Value;
                myparametro.FechaNota = Convert.ToDateTime(lbl_fecha_nota.Text);
                myparametro.Ticket_idTicket_nota = Lbl_id_ticket.Text;
                myparametro.usuario_id_nota = fk_usu_nota_id;
                myparametro.cliente_id_nota = fk_clie_nota_id;
                myparametro.nota_interna = nota_interna;
                myparametro.Adjuntos_nota = Adjuntos_nota;
                myparametro.Nota_usuario = Nota_usuario;


                if (gestion_Datos.insertarNotas(myparametro))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire('Se agrego la nota correctamente');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "Swal.fire('Error en la base de datos');", true);
                }



                cargar_datos_ticket();
                Txt_descripcion_nota.Value = "";
                check_genera_acta.Enabled = true;
            }





        }





        private void crearDocumento()
        {
            try
            {
                myparametro = gestion_Datos.traerID_Acta();
                if (myparametro.idactas == 0)
                {
                    id_acta = 0;
                }
                else
                {
                    id_acta = myparametro.idactas;
                    id_acta = id_acta + 1;
                }
            }
            catch (Exception)
            {

                id_acta = 1;
            }




            myparametro = gestion_Datos.traer_Prefijo_Usario(List_Usuarios.SelectedValue);
            prefijo_consultor = myparametro.Usuarioprefijo;

            string n_empresa = lbl_id_empresa.Text;
            string num_acta = n_empresa + "-" + prefijo_consultor + "-" + id_acta;

            Word.Application objetoWord = new Word.Application();
            object objeto = System.Reflection.Missing.Value;

            string ruta = @"C:\Users\dinac\Desktop\REPOSITORIO CT\Control_tickets\DynaIT\notas_usu\Plantilla_Acta1.doc";
            object parametro = ruta;
            object Fecha_Creacion_acta = "Fecha_Creacion_acta";
            object numero_acta = "numero_acta";
            object nombre_empresa_obj = "nombre_empresa";
            object nombre_cliente_representante = "nombre_cliente_representante";
            object usuario_consultor = "usuario_consultor";
            object Creditos_trabajados = "Creditos_trabajados";
            object Creditos_trabajados_2 = "Creditos_trabajados_2";
            object Creditos_facturados = "Creditos_facturados";
            object Creditos_garantia = "Creditos_garantia";
            object Desarrollos_realizados = "Desarrollos_realizados";


            Word._Document objetoDocumento = objetoWord.Documents.Add(ref parametro, ref objeto, ref objeto, ref objeto);


            Word.Range fecha_acta = objetoDocumento.Bookmarks.get_Item(ref Fecha_Creacion_acta).Range;
            fecha_acta.Text = DateTime.Now.ToString();

            Word.Range n_acta = objetoDocumento.Bookmarks.get_Item(ref numero_acta).Range;
            n_acta.Text = num_acta;

            Word.Range nom_empresa = objetoDocumento.Bookmarks.get_Item(ref nombre_empresa_obj).Range;
            nom_empresa.Text = Nombre_Empresa;

            Word.Range nom_representante = objetoDocumento.Bookmarks.get_Item(ref nombre_cliente_representante).Range;
            nom_representante.Text = Representante_empresa;

            Word.Range usu_consultor = objetoDocumento.Bookmarks.get_Item(ref usuario_consultor).Range;
            usu_consultor.Text = prefijo_consultor;

            Word.Range credito_traba = objetoDocumento.Bookmarks.get_Item(ref Creditos_trabajados).Range;
            credito_traba.Text = Convert.ToString(lbl_n_creditos.Text);

            Word.Range credito_trabajado_2 = objetoDocumento.Bookmarks.get_Item(ref Creditos_trabajados_2).Range;
            credito_trabajado_2.Text = Convert.ToString(lbl_n_creditos.Text);

            Word.Range Creditos_facturado = objetoDocumento.Bookmarks.get_Item(ref Creditos_facturados).Range;
            Creditos_facturado.Text = Convert.ToString(n_cred_diferencia);

            Word.Range Creditos_garantias = objetoDocumento.Bookmarks.get_Item(ref Creditos_garantia).Range;
            Creditos_garantias.Text = Convert.ToString(n_cre_gara);

            Word.Range Desa_realizados = objetoDocumento.Bookmarks.get_Item(ref Desarrollos_realizados).Range;
            Desa_realizados.Text = Txt_descripcion_nota.Value;

            object rango1 = fecha_acta;
            object rango2 = n_acta;
            object rango3 = nom_empresa;
            object rango4 = nom_representante;
            object rango5 = usu_consultor;
            object rango6 = credito_traba;
            object rango7 = credito_trabajado_2;
            object rango8 = Creditos_facturado;
            object rango9 = Creditos_garantias;
            object rango10 = Desa_realizados;


            objetoDocumento.Bookmarks.Add("Fecha_Creacion_acta", ref rango1);
            objetoDocumento.Bookmarks.Add("numero_acta", ref rango2);
            objetoDocumento.Bookmarks.Add("nombre_empresa", ref rango3);
            objetoDocumento.Bookmarks.Add("nombre_cliente_representante", ref rango4);
            objetoDocumento.Bookmarks.Add("usuario_consultor", ref rango5);
            objetoDocumento.Bookmarks.Add("Creditos_trabajados", ref rango6);
            objetoDocumento.Bookmarks.Add("Creditos_trabajados_2", ref rango7);
            objetoDocumento.Bookmarks.Add("Creditos_facturados", ref rango8);
            objetoDocumento.Bookmarks.Add("Creditos_garantia", ref rango9);
            objetoDocumento.Bookmarks.Add("Desarrollos_realizados", ref rango10);


            objetoWord.Visible = true;



            var numero_actas = System.IO.Path.Combine(lbl_ruta.Text, "actas_generada");
            var carpetaDestino = new System.IO.DirectoryInfo(numero_actas);
            if (!carpetaDestino.Exists)
                carpetaDestino.Create();

            var pathCarpetaDestino = System.IO.Path.Combine(numero_actas, n_acta.Text);

            //var nuevaRuta = System.IO.Path.Combine(lbl_ruta.Text, n_acta.Text);
            //var carpetaDestino1 = new System.IO.DirectoryInfo(pathCarpetaDestino1);

            objetoWord.ActiveDocument.SaveAs2(FileName: pathCarpetaDestino + ".doc");


            myparametro.Numero_Acta = n_acta.Text;
            myparametro.Fecha_crea_acta = Convert.ToDateTime(lbl_fecha_nota.Text);
            myparametro.ticket_idTicket = Lbl_id_ticket.Text;
            myparametro.N_creditos_acta = credito_traba.Text;
            myparametro.N_credi_garantia_acta = n_cre_gara;
            myparametro.fk_usuario_id = id_usuario_sesion;

            gestion_Datos.inserta_Acta(myparametro);

        }



        protected void List_estados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Se ha cambiado el estado del ticket ');", true);

            if (Lbl_id_estado.Text == "6")
            {
                if (List_estados.SelectedValue == "2")
                {

                    // se solicita confirmación con javaScrips para reabrir el tickket, cambiando
                    // el selecvalu de la lista desplegable desde javascrip, utilizando la funcion llamada "Confirmacion_cambioestado()"
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cambio_estado_cerrado_abierto()", true);

                }
                else
                {
                    if (List_estados.SelectedValue == "3")
                    {
                        fecha_inicio_proceso = DateTime.Now.ToString();
                        lbl_fecha_inicio.Text = fecha_inicio_proceso;
                        // se solicita confirmación con javaScrips para reabrir el tickket, cambiando
                        // el selecvalu de la lista desplegable desde javascrip, utilizando la funcion llamada "Confirmacion_cambioestado()"
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cambio_estado_cerrado_proceso()", true);

                    }
                    else
                    {
                        if (List_estados.SelectedValue == "4")
                        {

                            // se solicita confirmación con javaScrips para reabrir el tickket, cambiando
                            // el selecvalu de la lista desplegable desde javascrip, utilizando la funcion llamada "Confirmacion_cambioestado()"
                            Fecha_resuelto_ticket = DateTime.Now;
                            fecha_cierre = Fecha_resuelto_ticket.AddDays(24);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cambio_estado_cerrado_pendiente()", true);

                        }
                        else
                        {
                            if (List_estados.SelectedValue == "5")
                            {
                                fecha_cierre = DateTime.Now;
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', title: 'Cerrado', text: ' Ticket cerrado ', confirmButtonText: 'Ok' })  ", true);
                            }

                        }
                    }
                }
            }

        }


        protected void List_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' Caso reasignado ', confirmButtonText: 'Ok' })  ", true);


        }


        protected void listar_notas(string id_nota)
        {
            List<Visualizar_Tickets> visualizar_Tickets = new List<Visualizar_Tickets>();

            if (rol_usuario_sesion == 5 || rol_usuario_sesion == 4)
            {
                visualizar_Tickets = gestion_Datos.traer_notas_cliente(Lbl_id_ticket.Text);
            }
            else
            {
                if (rol_usuario_sesion == 3 || rol_usuario_sesion == 2)
                {
                    visualizar_Tickets = gestion_Datos.traer_notas_usuarios(Lbl_id_ticket.Text); ;
                }
            }


            foreach (var item in visualizar_Tickets)
            {



                var div = new HtmlGenericControl("div");
                Literal literal;
                Literal literal2;
                Label lbl_nombre;


                literal = new Literal();
                literal2 = new Literal();


                lbl_nombre = new Label();
                lbl_nombre.Style["Font-Size"] = "10pt";
                lbl_nombre.Style["width"] = "50%";
                lbl_nombre.Style["padding"] = "5px";
                lbl_nombre.Text = Convert.ToString(item.nota_creada_por);
                Panel1.Controls.Add(lbl_nombre);



                Label lbl_fecha_nota = new Label();
                Label lbl_descri_nota = new Label();

                lbl_fecha_nota.Style["Font-Size"] = "10pt";
                lbl_fecha_nota.Style["width"] = "50%";
                lbl_nombre.Style["padding"] = "5px";
                lbl_fecha_nota.Text = Convert.ToString(item.FechaNota);


                Panel1.Controls.Add(lbl_fecha_nota);

                literal2.Text = item.Adjuntos_nota;

                //btn_adjunto.Click += new System.EventHandler(listar_adjuntos_nota(literal2.Text));




                literal.Text = "<div style='display: flex; justify-content: space-between; background-color: #e2e2e2; border-radius:15px; padding:15px; margin: 5px;'>";
                Panel1.Controls.Add(literal);

                //lbl_descri_nota.Style["border-radius"] = "7px";
                //lbl_descri_nota.Style["background-color"] = "aquamarine";
                lbl_descri_nota.Text = item.descripcionNota;
                Panel1.Controls.Add(lbl_descri_nota);
                literal = new Literal();

                literal.Text = "</div>";


                Panel1.Controls.Add(literal);
            }



        }


    }
}