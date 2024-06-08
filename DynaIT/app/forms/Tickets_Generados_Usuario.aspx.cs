//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynaIT.app.forms
{

    public partial class Tickets_Generados_Usuario : System.Web.UI.Page
    {

        Validaciones myValidaciones = new Validaciones();
        Gestion_Datos gestion_Datos = new Gestion_Datos();
        Clase_Parametros myparametro = new Clase_Parametros();
        //string connectionString = @"server=localhost; userid=root; password=Diamante1020*; database=dynait;";       // cadena de conexion hacia mysql
        static string connectionString = @"Integrated Security=True;Initial Catalog=DynaIT;Data Source=DESKTOP-L5T5BI3";
        perfil_Usuario perfil_Usuario = new perfil_Usuario();
        string correo, Id_Empresa_cliente;

        protected void Page_Load(object sender, EventArgs e)
        {


            correo = (string)Session["correos_inicio_sesion"];
            cargar_datos_usuario();

            if (!IsPostBack)
            {

                //se declara la variable tipo sesión que permite llevar datos o cadenas de string entre formularios 

                if (lbl_rol_usuario.Text == "3")
                {
                    cargar_grilla_asignado_por_agente();

                    Btn_sin_asignar.Visible = false;
                    Btn_mis_tickets.Visible = false;
                    List_clientes.Visible = true;

                    div_col_empresa.Visible = true;
                    div_col_cliente.Visible = true;
                    div_col_estado.Visible = true;

                    lbl_correo2.Text = correo;
                    Btn_exportar.Visible = false;
                    div_agente.Visible = false;
                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
                }
                else
                {
                    if (lbl_rol_usuario.Text == "2")
                    {
                        cargar_grilla_tickets();

                        List_Empresas.Visible = true;
                        List_clientes.Visible = true;
                        List_estado_ticket.Visible = true;
                        div_col_empresa.Visible = true;
                        div_col_cliente.Visible = true;
                        div_col_estado.Visible = true;
                        lbl_correo2.Text = correo;
                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
                    }
                    else
                    {
                        if (lbl_rol_usuario.Text == "5")
                        {
                            lbl_correo2.Text = correo;

                            cargar_grilla_por_cliente_idcliente();


                            div_col_empresa.Visible = false;
                            div_col_cliente.Visible = false;
                            div_col_estado.Visible = true;

                            Btn_todos_ticket.Visible = true;
                            Btn_mis_tickets.Visible = false;
                            Btn_sin_asignar.Visible = false;
                            Btn_exportar.Visible = false;

                            Grilla_Tickets_generados_usuario.Columns[9].Visible = false;
                            Grilla_Tickets_generados_usuario.Columns[11].Visible = false;
                            Btn_tickets_compartidos.Visible = false;

                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {
                            if (lbl_rol_usuario.Text == "4")
                            {
                                lbl_correo2.Text = correo;

                                div_col_empresa.Visible = false;
                                div_col_cliente.Visible = true;
                                div_col_estado.Visible = true;

                                cargar_grilla_por_empresa();
                                Btn_todos_ticket.Text = "Todos los tickets";
                                Btn_mis_tickets.Text = "Mis tickets creados";
                                Btn_sin_asignar.Visible = false;
                                Btn_exportar.Visible = false;
                                cargar_list_cliente();
                                Grilla_Tickets_generados_usuario.Columns[9].Visible = false;
                                Grilla_Tickets_generados_usuario.Columns[11].Visible = false;

                                Btn_tickets_compartidos.Visible = false;

                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
                            }
                        }
                    }

                }

            }

        }

        private void cargar_grilla_tickets()
        {
            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Todos_Tickets();
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();
        }


        private void cargar_grilla_por_empresa()
        {
            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_empresa(Id_Empresa_cliente);
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();

        }


        private void cargar_datos_usuario()
        {
            string rol_inicio_usuario = (string)Session["rol_usuario"];
            string rol_inicio_cliente = (string)Session["rol_cliente"];



            if (rol_inicio_usuario != null)
            {


                myparametro = gestion_Datos.traer_nombre_rol_Usuario(correo);

                Lbl_id_usuario.Text = Convert.ToString(myparametro.Id_usuario);
                lbl_nombre_usuario.Text = myparametro.Nombre_Usuario;
                lbl_rol_usuario.Text = Convert.ToString(myparametro.Rol_usuario);
            }
            else
            {
                if (rol_inicio_cliente != null)
                {
                    myparametro = gestion_Datos.traer_nombre_rol_cliente(correo);

                    Lbl_id_usuario.Text = Convert.ToString(myparametro.idCliente);
                    lbl_nombre_usuario.Text = myparametro.Nombre_Cliente;
                    lbl_rol_usuario.Text = Convert.ToString(myparametro.Rol_Cliente);
                    Id_Empresa_cliente = Convert.ToString(myparametro.Id_Empresa_cliente);
                }

            }
        }


        private void cargar_grilla_asignado_por_agente()
        {
            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Todos_Tickets_usuario(Convert.ToInt32(Lbl_id_usuario.Text));
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();
            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
        }


        private void cargar_grilla_por_cliente_idcliente()
        {
            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Todos_Tickets_cliente(Lbl_id_usuario.Text);
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();
            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

        }

        private void cargar_grilla_creados_por_agente()
        {
            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Todos_Tickets_creados_usuario(lbl_correo2.Text);
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();
            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
        }

        private void Todos_Tickets_creados_asignados_agente()
        {
            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.Todos_Tickets_creados_asignados_agente(Lbl_id_usuario.Text, lbl_nombre_usuario.Text);
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();
            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
        }
        private void cargar_list_cliente()
        {
            List_clientes.DataSourceID = "";

            // Me realiza una consulta al primer DropdownList-Empresa,  que me trae y llena el segundo DropdownList-Cliente y trae todo el listado de la columna NombreCliente de la tabla cliente
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            string query = "  SELECT id_Cliente, nombre_cliente FROM cliente " +
                " where cliente.empresa_id = @Id_Empresa and cliente.Cliente_Habilitado = 'Si' or id_Cliente = '1'";
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@Id_Empresa", Id_Empresa_cliente);
            comando.ExecuteNonQuery();
            List_clientes.DataSource = comando.ExecuteReader();
            List_clientes.DataValueField = "id_Cliente";
            List_clientes.DataTextField = "nombre_cliente";
            List_clientes.DataBind();

            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
        }


        protected void List_Empresas_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lbl_rol_usuario.Text == "2")
            {
                List_clientes.DataSourceID = "";

                // Me realiza una consulta al primer DropdownList-Empresa,  que me trae y llena el segundo DropdownList-Cliente y trae todo el listado de la columna NombreCliente de la tabla cliente
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string query = "  SELECT id_Cliente, nombre_cliente FROM cliente " +
                    " where empresa_id = @Id_Empresa or id_Cliente = '1' ";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Id_Empresa", List_Empresas.SelectedValue);
                comando.ExecuteNonQuery();
                List_clientes.DataSource = comando.ExecuteReader();
                List_clientes.DataValueField = "id_Cliente";
                List_clientes.DataTextField = "nombre_cliente";
                List_clientes.DataBind();


                //se trae el nombre del cliente para mostrarlo en pantalla al seleccionar un nombre de la lista desplegable 
                //si no se encontraron tickets creados por ese cliente
                myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                string nombre_cliente = myparametro.Nombre_Cliente;

                //se traen los nombres de la empresa para mostrar como
                //mensaje al selecciona una de la lista desplegable si no se encuentran tickets 
                myparametro = gestion_Datos.traer_nombre_Empresa(Convert.ToInt32(List_Empresas.SelectedValue));
                string nombre_empresa = myparametro.Nombre_Empresa;

                //se trae el nombre del estado para mostrarlo en un mensaje despues de seleccionar un estado de la lista
                //desplegable si no se encuentran tickets
                myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                string nombre_estado = myparametro.Estados_tickets;

                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                if (List_clientes.SelectedValue == "1" && List_estado_ticket.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                {
                    List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_empresa(List_Empresas.SelectedValue);

                    if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros

                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                        Grilla_Tickets_generados_usuario.DataBind();
                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket registrados por la empresa  (" + nombre_empresa + ") ', confirmButtonText: 'Ok' })  ", true);
                    }

                }
                else
                {
                    if (List_clientes.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1" && List_Agente.SelectedValue == "1")
                    {
                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa(List_estado_ticket.SelectedValue, List_Empresas.SelectedValue);

                        if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                           //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' La (" + nombre_empresa + ") no tiene tickets en estado  (" + nombre_estado + ") ', confirmButtonText: 'Ok' })  ", true);
                        }

                    }
                    else
                    {

                        if (List_clientes.SelectedValue != "1" && List_estado_ticket.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_Cliente_empresa(List_clientes.SelectedValue, List_Empresas.SelectedValue);


                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: '  el cliente (" + nombre_cliente + ") de la empresa  (" + nombre_empresa + ") no tienen tickets registrados ', confirmButtonText: 'Ok' })  ", true);
                            }

                        }
                        else
                        {
                            if (List_clientes.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1" && List_Agente.SelectedValue == "1")
                            {


                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_Estado_cliente(List_estado_ticket.SelectedValue, List_clientes.SelectedValue, List_Empresas.SelectedValue);


                                if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                    //registros encontrados si no se genera alerta de no se encontraron registros    
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: '  No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                }




                            }
                            else
                            {
                                if (List_clientes.SelectedValue == "1" && List_estado_ticket.SelectedValue == "1" && List_Agente.SelectedValue != "1")
                                {


                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_agente(List_Agente.SelectedValue, List_Empresas.SelectedValue);


                                    if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                        //registros encontrados si no se genera alerta de no se encontraron registros    
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();

                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: '  No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ', confirmButtonText: 'Ok' })  ", true);
                                    }




                                }
                                else
                                {
                                    if (List_clientes.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1" && List_Agente.SelectedValue != "1")
                                    {


                                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue, List_clientes.SelectedValue);


                                        if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                            //registros encontrados si no se genera alerta de no se encontraron registros    
                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ');", true);
                                        }




                                    }
                                    else
                                    {
                                        if (List_clientes.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1" && List_Agente.SelectedValue != "1")
                                        {


                                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue);


                                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                                Grilla_Tickets_generados_usuario.DataBind();

                                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ', confirmButtonText: 'Ok' })  ", true);
                                            }




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
                if (lbl_rol_usuario.Text == "3")
                {
                    List_clientes.DataSourceID = "";

                    // Me realiza una consulta al primer DropdownList-Empresa,  que me trae y llena el segundo DropdownList-Cliente y trae todo el listado de la columna NombreCliente de la tabla cliente
                    SqlConnection conexion = new SqlConnection(connectionString);
                    conexion.Open();
                    string query = "  SELECT id_Cliente, nombre_cliente FROM cliente" +
                        " where empresa_id = @Id_Empresa or id_Cliente = '1' ";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@Id_Empresa", List_Empresas.SelectedValue);
                    comando.ExecuteNonQuery();
                    List_clientes.DataSource = comando.ExecuteReader();
                    List_clientes.DataValueField = "id_Cliente";
                    List_clientes.DataTextField = "nombre_cliente";
                    List_clientes.DataBind();

                    //se traen los nombres de la empresa para mostrar como
                    //mensaje al selecciona una de la lista desplegable si no se encuentran tickets 
                    myparametro = gestion_Datos.traer_nombre_Empresa(Convert.ToInt32(List_Empresas.SelectedValue));
                    string nombre_empresa = myparametro.Nombre_Empresa;

                    //se trae el nombre del estado para mostrarlo en un mensaje despues de seleccionar un estado de la lista
                    //desplegable si no se encuentran tickets
                    myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                    string nombre_estado = myparametro.Estados_tickets;

                    if (List_estado_ticket.SelectedValue == "1" && List_clientes.SelectedValue == "1")
                    {
                        List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_empresa_agente(Lbl_id_usuario.Text, List_Empresas.SelectedValue);

                        if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                             //registros encontrados si no se genera alerta de no se encontraron registros

                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket registrados por la empresa  (" + nombre_empresa + ") ', confirmButtonText: 'Ok' })  ", true);
                        }

                    }
                    else
                    {
                        if (List_estado_ticket.SelectedValue != "1" && List_clientes.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue);

                            if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                               //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'La empresa (" + nombre_empresa + ") no tiene tickets en estado  (" + nombre_estado + ")  ', confirmButtonText: 'Ok' })  ", true);

                            }

                        }
                        else
                        {
                            if (List_estado_ticket.SelectedValue == "1" && List_clientes.SelectedValue != "1")
                            {
                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_cliente_agente(Lbl_id_usuario.Text, List_clientes.SelectedValue, List_Empresas.SelectedValue);

                                if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                   //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' La (" + nombre_estado + ") no tiene tickets en estado  (" + nombre_estado + ") ', confirmButtonText: 'Ok' })  ", true);
                                }

                            }
                            else
                            {
                                if (List_estado_ticket.SelectedValue != "1" && List_clientes.SelectedValue != "1")
                                {
                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue, List_clientes.SelectedValue);

                                    if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                       //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: '  La (" + nombre_estado + ") no tiene tickets en estado  (" + nombre_estado + ") ', confirmButtonText: 'Ok' })  ", true);
                                    }

                                }
                            }
                        }


                    }
                }

            }
        }


        protected void Grilla_Tickets_generados_usuario_PageIndexChanged(object sender, EventArgs e)
        {


        }
        protected void Grilla_Tickets_generados_usuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grilla_Tickets_generados_usuario.PageIndex = e.NewPageIndex;
            Grilla_Tickets_generados_usuario.DataBind();
            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

        }
        //--------------------------------lista desplegable de clientes------------------------------

        protected void List_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lbl_rol_usuario.Text == "2")
            {
                myparametro = gestion_Datos.traer_nombre_Empresa(Convert.ToInt32(List_Empresas.SelectedValue));
                string nombre_empresa = myparametro.Nombre_Empresa;

                myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                string nombre_estado = myparametro.Estados_tickets;


                myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                string nombre_cliente = myparametro.Nombre_Cliente;


                if (List_Empresas.SelectedValue == "1" && List_estado_ticket.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                {
                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Cliente(List_clientes.SelectedValue);



                    if (visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros

                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                        Grilla_Tickets_generados_usuario.DataBind();
                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket del cliente  (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                    }

                }
                else
                {
                    if (List_Empresas.SelectedValue != "1" && List_estado_ticket.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                    {
                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_cliente(List_Empresas.SelectedValue, List_clientes.SelectedValue);

                        if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                           //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' El cliente (" + nombre_cliente + ") de la  empresa (" + nombre_empresa + ") no tien tickets registrados ', confirmButtonText: 'Ok' })  ", true);
                        }

                    }
                    else
                    {

                        if (List_Empresas.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1" && List_Agente.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_cliente(List_estado_ticket.SelectedValue, List_clientes.SelectedValue);


                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con este estado (" + nombre_estado + ") y el cliente (" + nombre_cliente + ") ', confirmButtonText: 'Ok' })  ", true);
                            }

                        }
                        else
                        {
                            if (List_Empresas.SelectedValue == "1" && List_estado_ticket.SelectedValue == "1" && List_Agente.SelectedValue != "1")
                            {


                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_cliente_agente(List_Agente.SelectedValue, List_clientes.SelectedValue);


                                if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                    //registros encontrados si no se genera alerta de no se encontraron registros    
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                }




                            }
                            else
                            {


                                if (List_Empresas.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1" && List_Agente.SelectedValue != "1")
                                {


                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue, List_clientes.SelectedValue);


                                    if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                        //registros encontrados si no se genera alerta de no se encontraron registros    
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();

                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);

                                    }




                                }
                                else
                                {

                                    if (List_Empresas.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1" && List_Agente.SelectedValue != "1")
                                    {


                                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_cliente_estado_agente(List_Agente.SelectedValue, List_clientes.SelectedValue, List_estado_ticket.SelectedValue);


                                        if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                            //registros encontrados si no se genera alerta de no se encontraron registros    
                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ', confirmButtonText: 'Ok' })  ", true);
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
                if (lbl_rol_usuario.Text == "4")
                {
                    if (List_estado_ticket.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                    {
                        myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                        string nombre_cliente = myparametro.Nombre_Cliente;

                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_cliente(Id_Empresa_cliente, List_clientes.SelectedValue);

                        if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                            //registros encontrados si no se genera alerta de no se encontraron registros    
                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket  de (" + nombre_cliente + ") ');", true);
                        }

                    }
                    else
                    {

                        if (List_Agente.SelectedValue != "1" && List_estado_ticket.SelectedValue == "1")
                        {
                            myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                            string nombre_estado = myparametro.Estados_tickets;

                            myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                            string nombre_cliente = myparametro.Nombre_Cliente;

                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_cliente_agente(List_Agente.SelectedValue, List_clientes.SelectedValue, Id_Empresa_cliente);


                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), del cliente (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                            }


                        }
                        else
                        {
                            if (List_Agente.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1")
                            {
                                myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                                string nombre_estado = myparametro.Estados_tickets;

                                myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                                string nombre_cliente = myparametro.Nombre_Cliente;

                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_cliente_estado(Id_Empresa_cliente, List_clientes.SelectedValue, List_estado_ticket.SelectedValue);


                                if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                    //registros encontrados si no se genera alerta de no se encontraron registros    
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), del cliente (" + nombre_cliente + ") ', confirmButtonText: 'Ok' })  ", true);
                                }


                            }
                            else
                            {
                                if (List_Agente.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1")
                                {
                                    myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                                    string nombre_estado = myparametro.Estados_tickets;

                                    myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                                    string nombre_cliente = myparametro.Nombre_Cliente;

                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, Id_Empresa_cliente, List_clientes.SelectedValue);


                                    if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                        //registros encontrados si no se genera alerta de no se encontraron registros    
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), del cliente (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                    }


                                }
                            }
                        }

                    }
                }
                else
                {
                    if (lbl_rol_usuario.Text == "3")
                    {
                        if (List_Empresas.SelectedValue == "1" && List_estado_ticket.SelectedValue == "1")
                        {
                            myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                            string nombre_cliente = myparametro.Nombre_Cliente;

                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_cliente_agente(Lbl_id_usuario.Text, List_clientes.SelectedValue);

                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket  de (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                            }



                        }
                        else
                        {
                            if (List_Empresas.SelectedValue != "1" && List_estado_ticket.SelectedValue == "1")
                            {
                                myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                                string nombre_cliente = myparametro.Nombre_Cliente;

                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_cliente_agente(Lbl_id_usuario.Text, List_clientes.SelectedValue, List_Empresas.SelectedValue);

                                if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                    //registros encontrados si no se genera alerta de no se encontraron registros    
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket  de (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                }



                            }
                            else
                            {
                                if (List_Empresas.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1")
                                {
                                    myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                                    string nombre_cliente = myparametro.Nombre_Cliente;

                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_cliente_estado_agente(Lbl_id_usuario.Text, List_clientes.SelectedValue, List_estado_ticket.SelectedValue);

                                    if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                        //registros encontrados si no se genera alerta de no se encontraron registros    
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket  de (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                    }



                                }
                                else
                                {
                                    if (List_Empresas.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1")
                                    {
                                        myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                                        string nombre_cliente = myparametro.Nombre_Cliente;

                                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue, List_clientes.SelectedValue);

                                        if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                            //registros encontrados si no se genera alerta de no se encontraron registros    
                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket  de (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                        }



                                    }
                                }
                            }
                        }
                    }
                }
            }


        }

        protected void List_Agente_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lbl_rol_usuario.Text == "2")
            {
                myparametro = gestion_Datos.traer_nombre_Empresa(Convert.ToInt32(List_Empresas.SelectedValue));
                string nombre_empresa = myparametro.Nombre_Empresa;

                myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                string nombre_estado = myparametro.Estados_tickets;

                myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                string nombre_cliente = myparametro.Nombre_Cliente;

                if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue == "1" && List_estado_ticket.SelectedValue == "1")
                {
                    List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Todos_Tickets_usuario(Convert.ToInt32(List_Agente.SelectedValue));



                    if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros

                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                        Grilla_Tickets_generados_usuario.DataBind();
                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                    }
                    else
                    {


                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: '  No se encontraron ticket en  (" + nombre_estado + ")  ', confirmButtonText: 'Ok' })  ", true);
                    }

                }
                else
                {
                    if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue == "1" && List_estado_ticket.SelectedValue == "1")
                    {
                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_agente(List_Agente.SelectedValue, List_Empresas.SelectedValue);

                        if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                           //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' La empresa (" + nombre_empresa + ")no tiene tickets en estado  (" + nombre_estado + ") ', confirmButtonText: 'Ok' })  ", true);
                        }

                    }
                    else
                    {

                        if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue != "1" && List_estado_ticket.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_cliente_agente(List_Agente.SelectedValue, List_clientes.SelectedValue);


                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con este estado (" + nombre_estado + ") y el cliente (" + nombre_cliente + ") ', confirmButtonText: 'Ok' })  ", true);
                            }

                        }
                        else
                        {
                            if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1")
                            {


                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_estado_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue);


                                if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                    //registros encontrados si no se genera alerta de no se encontraron registros    
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                }




                            }
                            else
                            {
                                if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1")
                                {


                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue, List_clientes.SelectedValue);


                                    if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                        //registros encontrados si no se genera alerta de no se encontraron registros    
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ');", true);
                                    }




                                }
                                else
                                {
                                    if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue != "1" && List_estado_ticket.SelectedValue == "1")
                                    {


                                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_cliente_agente(List_Agente.SelectedValue, List_clientes.SelectedValue, List_Empresas.SelectedValue);


                                        if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                            //registros encontrados si no se genera alerta de no se encontraron registros    
                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ');", true);
                                        }




                                    }
                                    else
                                    {
                                        if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1")
                                        {


                                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_cliente_estado_agente(List_Agente.SelectedValue, List_clientes.SelectedValue, List_estado_ticket.SelectedValue);


                                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                                Grilla_Tickets_generados_usuario.DataBind();
                                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ")  ', confirmButtonText: 'Ok' })  ", true);
                                            }




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
                if (lbl_rol_usuario.Text == "3")
                {
                    myparametro = gestion_Datos.traer_nombre_Empresa(Convert.ToInt32(List_Empresas.SelectedValue));
                    string nombre_empresa = myparametro.Nombre_Empresa;

                    myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                    string nombre_estado = myparametro.Estados_tickets;

                    if (List_Empresas.SelectedValue != "1" && List_estado_ticket.SelectedValue == "1")
                    {
                        List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_empresa_agente(Lbl_id_usuario.Text, List_Empresas.SelectedValue);

                        if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                             //registros encontrados si no se genera alerta de no se encontraron registros

                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket registrados por la empresa  (" + nombre_empresa + ") ', confirmButtonText: 'Ok' })  ", true);
                        }

                    }
                    else
                    {
                        if (List_Empresas.SelectedValue != "1" && List_estado_ticket.SelectedValue != "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue);

                            if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                               //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {


                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' La empresa (" + nombre_empresa + ") no tiene tickets en estado  (" + nombre_estado + ") ', confirmButtonText: 'Ok' })  ", true);
                            }

                        }
                        else
                        {
                            if (List_Empresas.SelectedValue == "1" && List_estado_ticket.SelectedValue != "1")
                            {
                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_estado_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue);

                                if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                   //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: '  No se encontraron tickets en estado  (" + nombre_estado + ") ', confirmButtonText: 'Ok' })  ", true);
                                }

                            }
                        }


                    }
                }
                else
                {
                    if (lbl_rol_usuario.Text == "5")
                    {
                        myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                        string nombre_estado = myparametro.Estados_tickets;

                        if (List_estado_ticket.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_cliente_agente(List_Agente.SelectedValue, Lbl_id_usuario.Text);

                            if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros

                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket en  (" + nombre_estado + ")  ', confirmButtonText: 'Ok' })  ", true);
                            }


                        }
                        else
                        {
                            if (List_estado_ticket.SelectedValue != "1")
                            {
                                List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_cliente_estado_agente(List_Agente.SelectedValue, Lbl_id_usuario.Text, List_estado_ticket.SelectedValue);

                                if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros

                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket en  (" + nombre_estado + ")  ', confirmButtonText: 'Ok' })  ", true);
                                }


                            }
                        }
                    }
                    else
                    {
                        if (lbl_rol_usuario.Text == "4")
                        {
                            myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                            string nombre_cliente = myparametro.Nombre_Cliente;

                            myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                            string nombre_estado = myparametro.Estados_tickets;

                            if (List_estado_ticket.SelectedValue == "1" && List_clientes.SelectedValue == "1")
                            {
                                List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_empresa_agente(List_Agente.SelectedValue, Id_Empresa_cliente);

                                if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros

                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'success', text: ' No se encontraron ticket en  (" + nombre_estado + ")  ', confirmButtonText: 'Ok' })  ", true);
                                }


                            }
                            else
                            {
                                if (List_estado_ticket.SelectedValue != "1" && List_clientes.SelectedValue == "1")
                                {
                                    List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_Estado_empresa_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, Id_Empresa_cliente);

                                    if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros

                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") del cliente (" + nombre_cliente + ")  ');", true);
                                    }


                                }
                                else
                                {
                                    if (List_estado_ticket.SelectedValue == "1" && List_clientes.SelectedValue != "1")
                                    {
                                        List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_empresa_cliente_agente(List_Agente.SelectedValue, List_clientes.SelectedValue, Id_Empresa_cliente);

                                        if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros

                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {

                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
                                        }


                                    }
                                    if (List_estado_ticket.SelectedValue != "1" && List_clientes.SelectedValue != "1")
                                    {
                                        List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, Id_Empresa_cliente, List_clientes.SelectedValue);

                                        if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros

                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {

                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
                                        }


                                    }
                                }
                            }
                        }
                    }

                }
            }

        }


        protected void List_estado_ticket_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lbl_rol_usuario.Text == "2")
            {
                myparametro = gestion_Datos.traer_nombre_Empresa(Convert.ToInt32(List_Empresas.SelectedValue));
                string nombre_empresa = myparametro.Nombre_Empresa;

                myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                string nombre_estado = myparametro.Estados_tickets;

                myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                string nombre_cliente = myparametro.Nombre_Cliente;

                if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                {
                    List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_Estado(List_estado_ticket.SelectedValue);



                    if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros

                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                        Grilla_Tickets_generados_usuario.DataBind();
                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
                    }

                }
                else
                {
                    if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                    {
                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa(List_estado_ticket.SelectedValue, List_Empresas.SelectedValue);

                        if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                           //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {


                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' La empresa (" + nombre_empresa + ")no tiene tickets en estado  (" + nombre_estado + ") ');", true);
                        }

                    }
                    else
                    {

                        if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue != "1" && List_Agente.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_cliente(List_estado_ticket.SelectedValue, List_clientes.SelectedValue);


                            if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                //registros encontrados si no se genera alerta de no se encontraron registros    
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket con este estado (" + nombre_estado + ") y el cliente (" + nombre_cliente + ")');", true);
                            }

                        }
                        else
                        {
                            if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue != "1" && List_Agente.SelectedValue == "1")
                            {


                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_empresa_Estado_cliente(List_estado_ticket.SelectedValue, List_clientes.SelectedValue, List_Empresas.SelectedValue);


                                if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                    //registros encontrados si no se genera alerta de no se encontraron registros    
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ');", true);
                                }




                            }
                            else
                            {
                                if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue == "1" && List_Agente.SelectedValue != "1")
                                {


                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_estado_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue);


                                    if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                        //registros encontrados si no se genera alerta de no se encontraron registros    
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ');", true);
                                    }




                                }
                                else
                                {
                                    if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue != "1" && List_Agente.SelectedValue != "1")
                                    {


                                        List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue, List_clientes.SelectedValue);


                                        if (visualizar_Tickets1.Count != 0) //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                            //registros encontrados si no se genera alerta de no se encontraron registros    
                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('No se encontraron ticket con el estado (" + nombre_estado + "), la empresa (" + nombre_empresa + ") y el cliente (" + nombre_cliente + ") ');", true);
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
                if (lbl_rol_usuario.Text == "3")
                {
                    myparametro = gestion_Datos.traer_nombre_Empresa(Convert.ToInt32(List_Empresas.SelectedValue));
                    string nombre_empresa = myparametro.Nombre_Empresa;

                    myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                    string nombre_estado = myparametro.Estados_tickets;


                    if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue == "1")
                    {
                        List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_estado_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue);

                        if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                             //registros encontrados si no se genera alerta de no se encontraron registros

                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                            Grilla_Tickets_generados_usuario.DataBind();
                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket registrados por la empresa  (" + nombre_empresa + ") ');", true);
                        }

                    }
                    else
                    {
                        if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue);

                            if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                               //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {


                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' La empresa (" + nombre_empresa + ") no tiene tickets en estado  (" + nombre_estado + ") ');", true);
                            }

                        }
                        else
                        {
                            if (List_Empresas.SelectedValue == "1" && List_clientes.SelectedValue != "1")
                            {
                                List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_cliente_estado_agente(Lbl_id_usuario.Text, List_clientes.SelectedValue, List_estado_ticket.SelectedValue);

                                if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                   //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {


                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron tickets en estado  (" + nombre_estado + ") ');", true);
                                }

                            }
                            else
                            {
                                if (List_Empresas.SelectedValue != "1" && List_clientes.SelectedValue != "1")
                                {
                                    List<Visualizar_Tickets> visualizar_Tickets1 = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(Lbl_id_usuario.Text, List_estado_ticket.SelectedValue, List_Empresas.SelectedValue, List_clientes.SelectedValue);

                                    if (visualizar_Tickets1.Count != 0)//Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                       //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                   //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets1;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {


                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron tickets en estado  (" + nombre_estado + ") ');", true);
                                    }

                                }

                            }
                        }


                    }
                }
                else
                {
                    if (lbl_rol_usuario.Text == "5")
                    {
                        myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                        string nombre_estado = myparametro.Estados_tickets;

                        if (List_Agente.SelectedValue == "1")
                        {
                            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_Estado_cliente(List_estado_ticket.SelectedValue, Lbl_id_usuario.Text);

                            if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros

                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                Grilla_Tickets_generados_usuario.DataBind();
                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
                            }


                        }
                        else
                        {
                            if (List_Agente.SelectedValue != "1")
                            {
                                List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_cliente_estado_agente(List_Agente.SelectedValue, Lbl_id_usuario.Text, List_estado_ticket.SelectedValue);

                                if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros

                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
                                }


                            }
                        }
                    }
                    else
                    {
                        if (lbl_rol_usuario.Text == "4")
                        {
                            myparametro = gestion_Datos.traer_nombre_Cliente(List_clientes.SelectedValue);
                            string nombre_cliente = myparametro.Nombre_Cliente;

                            myparametro = gestion_Datos.Traer__id_estados_grupo(List_estado_ticket.SelectedValue);
                            string nombre_estado = myparametro.Estados_tickets;

                            if (List_clientes.SelectedValue == "1" && List_Agente.SelectedValue == "1")
                            {
                                List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_Estado_empresa(List_estado_ticket.SelectedValue, Id_Empresa_cliente);

                                if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                    //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros

                                    Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                    Grilla_Tickets_generados_usuario.DataBind();
                                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                }
                                else
                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
                                }


                            }
                            else
                            {
                                if (List_clientes.SelectedValue != "1" && List_Agente.SelectedValue == "1")
                                {
                                    List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_empresa_Estado_cliente(List_estado_ticket.SelectedValue, List_clientes.SelectedValue, Id_Empresa_cliente);

                                    if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                        //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros

                                        Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                        Grilla_Tickets_generados_usuario.DataBind();
                                        lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") del cliente (" + nombre_cliente + ")  ');", true);
                                    }


                                }
                                else
                                {
                                    if (List_clientes.SelectedValue == "1" && List_Agente.SelectedValue != "1")
                                    {
                                        List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_Estado_empresa_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, Id_Empresa_cliente);

                                        if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                            //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros

                                            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                            Grilla_Tickets_generados_usuario.DataBind();
                                            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                        }
                                        else
                                        {

                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
                                        }


                                    }
                                    else
                                    {
                                        if (List_clientes.SelectedValue != "1" && List_Agente.SelectedValue != "1")
                                        {
                                            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_por_Estado_empresa_cliente_agente(List_Agente.SelectedValue, List_estado_ticket.SelectedValue, Id_Empresa_cliente, List_clientes.SelectedValue);

                                            if (visualizar_Tickets.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros

                                                Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
                                                Grilla_Tickets_generados_usuario.DataBind();
                                                lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                                            }
                                            else
                                            {

                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron ticket en  (" + nombre_estado + ") ');", true);
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

        protected void Grilla_Tickets_generados_usuario_Load(object sender, EventArgs e)
        {

            //foreach (DataGridViewRow rowp in dgvLineaCompra.Rows)
            //{
            //    int kia = rowp.Index;

            //    if (kia == p)
            //    {
            //        dgvLineaCompra.Rows[p].DefaultCellStyle.BackColor = Color.Yellow;
            //    }


            //    else if (kia != p)
            //    {
            //        dgvLineaCompra.Rows[kia].DefaultCellStyle.BackColor = Color.White;
            //    }
            //}
        }

        protected void List_clientes_TextChanged(object sender, EventArgs e)
        {

        }




        protected void Grilla_Tickets_generados_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            
        }

        protected void Grilla_Tickets_generados_usuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")    //se utiliza el boton del seleccionar y toma la propiedad del comanamey busca el valor en este casi es "Select
            {
                int index = Convert.ToInt32(e.CommandArgument);   //toma el numero de la fila seleccionada y la comvierte en un valor entero
                int valor = Convert.ToInt32(Grilla_Tickets_generados_usuario.DataKeys[index].Value); // se identifica el numero del encabezado del datakeyname que se establecio en la propiedad y toma el valor y se comvierte en estring
                Response.Redirect("Notas_usuario.aspx?id=" + valor); //cambia de ventana y envia el valor del datakeyname seleccionado a la ventana o formulario indicado 


            }
            else
            {
                if (e.CommandName == "Select_2")    //se utiliza el boton del seleccionar y toma la propiedad del comanamey busca el valor en este casi es "Select
                {

                    int index = Convert.ToInt32(e.CommandArgument);   //toma el numero de la fila seleccionada y la comvierte en un valor entero
                    string valor = Convert.ToString(Grilla_Tickets_generados_usuario.DataKeys[index].Value); // se identifica el numero del encabezado del datakeyname que se establecio en la propiedad y toma el valor y se comvierte en estring
                    Response.Redirect("Notas_usuario.aspx?id2=" + valor); //cambia de ventana y envia el valor del datakeyname seleccionado a la ventana o formulario indicado 

                }


            }

        }
        protected void Btn_mis_tickets_Click(object sender, EventArgs e)
        {

            if (lbl_rol_usuario.Text == "3")
            {
                //el nombre del boton queda como mis tickets creados y cargaran solo los que creo el agente 
                cargar_grilla_creados_por_agente();


                div_col_empresa.Visible = true;
                div_col_cliente.Visible = false;
                div_col_estado.Visible = true;
            }
            else
            {
                if (lbl_rol_usuario.Text == "2")
                {
                    cargar_grilla_asignado_por_agente();

                    List_Empresas.Visible = true;
                    List_clientes.Visible = true;
                    List_estado_ticket.Visible = true;
                    div_col_empresa.Visible = true;
                    div_col_cliente.Visible = true;
                    div_col_estado.Visible = true;
                }
                else
                {
                    if (lbl_rol_usuario.Text == "4")
                    {

                        cargar_grilla_por_cliente_idcliente();


                        div_col_empresa.Visible = false;
                        div_col_cliente.Visible = true;
                        div_col_estado.Visible = true;
                    }
                }

            }

        }

        protected void Btn_sin_asignar_Click(object sender, EventArgs e)
        {

            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Tickets_sin_asignar("3");
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();
            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
            div_col_empresa.Visible = true;
            div_col_cliente.Visible = true;
            div_col_estado.Visible = true;
        }


        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void Btn_exportar_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();

        }

        //metodo para exportar grilla a archivo de excel, en el diseño, en el archivo aspx se debe agregar la propiedad
        //EnableEventValidation = "false" para que permita la exportacion de la grilla en la linea 1 <%@ Page Language="C#" 
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Lista_Tickets " + DateTime.Now + " .xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application / vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Grilla_Tickets_generados_usuario.GridLines = GridLines.Both;
            Grilla_Tickets_generados_usuario.HeaderStyle.Font.Bold = true;
            Grilla_Tickets_generados_usuario.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void Btn_tickets_compartidos_Click(object sender, EventArgs e)
        {

            Grilla_Tickets_generados_usuario.DataSource = "";
            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Todos_Tickets_compartidos(Lbl_id_usuario.Text);
            Grilla_Tickets_generados_usuario.DataSource = visualizar_Tickets;
            Grilla_Tickets_generados_usuario.DataBind();

            lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);
            div_col_empresa.Visible = false;
            div_col_cliente.Visible = false;
            div_col_estado.Visible = false;

            Grilla_Tickets_generados_usuario.Columns[0].Visible = false;
            Grilla_Tickets_generados_usuario.Columns[1].Visible = true;
            Grilla_Tickets_generados_usuario.DataBind();
        }

        protected void Grilla_Tickets_generados_usuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DateTime fecahaAcual = DateTime.Now;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<Visualizar_Tickets> Tickets_vencidos = gestion_Datos.tickets_vencidos(fecahaAcual);
                foreach (var tickets in Tickets_vencidos)
                {

                    int id_ticket_vencido = tickets.N_Ticket;
                    int id_ticket_grilla = (int)DataBinder.Eval(e.Row.DataItem, "N_Ticket");

                    if (id_ticket_vencido == id_ticket_grilla)
                    {
                        e.Row.BackColor = Color.FromArgb(249, 30, 30);
                    }


                }

                List<Tickets_con_notas> tickets_con_notas = gestion_Datos.tickets_con_notas();

                foreach (var T_con_notas in tickets_con_notas)
                {
                    int T_c_nota = T_con_notas.N_Ticket;
                    int N_nota = T_con_notas.N_ultima_nota;

                    if (myValidaciones.Validar_nota(N_nota) == false)
                    {
                        int Id_ticket_grilla = (int)DataBinder.Eval(e.Row.DataItem, "N_Ticket");
                        if (T_c_nota == Id_ticket_grilla)
                        {
                            e.Row.BackColor = Color.FromArgb(23, 192, 241);
                        }
                    }

                }
            }
        }

        protected void Grilla_Tickets_generados_usuario_DataBinding(object sender, EventArgs e)
        {
            //List<Visualizar_Tickets> Tickets_vencidos = gestion_Datos.tickets_vencidos();
            //foreach (var l_vencido in Tickets_vencidos)
            //{
            //    int id_ticket = l_vencido.N_Ticket;

            //    foreach (DataGrid rowp in Grilla_Tickets_generados_usuario.Rows)
            //    {
            //        int index = Convert.ToInt32(e.CommandArgument)
            //        int ticket_id = rowp.DataKeys[index].Value;
            //        if (ticket_id == id_ticket)
            //        {

            //            rowp.ControlStyle.BackColor = Color.Red;
            //        }

            //    }




            //}
        }
        protected void Grilla_Tickets_generados_usuario_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Detalle_ticket", "$('#modal_detalle_ticket').modal();", true);
            GridViewRow row = Grilla_Tickets_generados_usuario.Rows[e.NewSelectedIndex];
            MessageLabel.Text = row.Cells[3].Text;
        }

        protected void Btn_todos_ticket_Click(object sender, EventArgs e)
        {
            if (lbl_rol_usuario.Text == "3")
            {
                //el nombre del boton queda como mis tickets asigados y cargaran solo los que se le han asignado
                cargar_grilla_asignado_por_agente();


                List_clientes.Visible = true;

                div_col_empresa.Visible = true;
                div_col_cliente.Visible = true;
                div_col_estado.Visible = true;
                List_Empresas.SelectedValue = "1";
                List_estado_ticket.SelectedValue = "1";

                if (List_clientes.DataSource == null)
                {
                    List_clientes.DataSourceID = "Clientes_tabla";
                    List_clientes.DataBind();

                }

                List_clientes.SelectedValue = "1";

            }
            else
            {
                if (lbl_rol_usuario.Text == "2")
                {
                    cargar_grilla_tickets();
                    if (List_clientes.DataSource == null)
                    {
                        List_clientes.DataSourceID = "Clientes_tabla";
                        List_clientes.DataBind();

                    }

                    List_Empresas.SelectedValue = "1";
                    List_clientes.SelectedValue = "1";
                    List_estado_ticket.SelectedValue = "1";
                    List_Agente.SelectedValue = "1";
                    div_col_empresa.Visible = true;
                    div_col_cliente.Visible = true;
                    div_col_estado.Visible = true;
                    lbl_n_registro.Text = Convert.ToString(Grilla_Tickets_generados_usuario.Rows.Count);

                }
                else
                {
                    if (lbl_rol_usuario.Text == "4")
                    {
                        cargar_grilla_por_empresa();
                        List_clientes.SelectedValue = "1";
                        List_estado_ticket.SelectedValue = "1";
                        List_Agente.SelectedValue = "1";
                    }
                    else
                    {
                        if (lbl_rol_usuario.Text == "5")
                        {
                            cargar_grilla_por_cliente_idcliente();
                            List_estado_ticket.SelectedValue = "1";
                        }
                    }
                }

            }






        }




        protected void Timer1_Tick_cierre_caso(object sender, EventArgs e)
        {

            List<Visualizar_Tickets> visualizar_Tickets = gestion_Datos.listar_Todos_Tickets();

            foreach (var t_tickets in visualizar_Tickets)
            {

                DateTime fecha_actual = DateTime.Now;
                DateTime fecha_Ticket_cierre = t_tickets.Fecha_cierre_ticket;

                int n_tic = t_tickets.N_Ticket;


                int id_estado = t_tickets.estado_idEstadoticket;

                if (DateTime.Compare(fecha_actual, fecha_Ticket_cierre) > 0)
                {


                    if (id_estado == 5)
                    {
                        myparametro.No_ticket = n_tic;
                        gestion_Datos.cerrar_ticket(myparametro);

                    }


                }

                DateTime fecha_Ticket_vence = t_tickets.tiempo_Respuesta;

                DateTime f_vence = fecha_actual.AddMinutes(-1);

                if (DateTime.Compare(f_vence, fecha_Ticket_vence) < 0 && DateTime.Compare(fecha_actual, fecha_Ticket_vence) >= 0)
                {
                    if (id_estado != 5 && id_estado != 6)
                    {
                        myValidaciones.Notificar_vencimienot_caso(t_tickets.Tu_correo_usuario, t_tickets.Nombre_usuario, n_tic, t_tickets.Resumen_Problema, t_tickets.nombre_empresa);
                    }
                }
            }




        }

    }
}