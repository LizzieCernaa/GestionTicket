//using MySql.Data.MySqlClient;
using DynaIT.Clases;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace DynaIT.app.forms
{
    public partial class Lista_actas : System.Web.UI.Page
    {
        Gestion_Datos Gestion_Datos = new Gestion_Datos();
        static List<Visualizar_Tickets> Visualizar_Tickets1 = new List<Visualizar_Tickets>();

        OdbcParameter N_Acta = new OdbcParameter();
        OdbcParameter N_Factura = new OdbcParameter();

        

        //string connectionString = @"server=localhost; userid=root; password=Diamante1020*; database=dynait;";       // cadena de conexion hacia mysql
        static string connectionString = @"Server=127.0.0.1,1433;Database=DynaIT;User Id=Lizzie;Password=NADA1234;";
        protected void Page_Load(object sender, EventArgs e)
        {
            //setTimeout("()", 100);

            Grilla_actas.Columns[0].Visible = false;
        }
        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            List_empresas.SelectedValue = "1";
            List_agente.SelectedValue = "1";
            List_estados.SelectedValue = "1";
            Txt_fecha_fin.Value = "";
            Txt_fecha_inicio.Value = "";
            //Visualizar_Tickets1.Count = null;            
            Grilla_actas.DataSourceID = "tabla_actas";
            Grilla_actas.DataBind();

        }

        protected void List_empresas_SelectedIndexChanged(object sender, EventArgs e)
        {

            string hora_inicio = "00:00:00", hora_fin = "23:59:59";
            DateTime fecha_inicio = Convert.ToDateTime("" + Txt_fecha_inicio.Value + " " + hora_inicio + "");
            DateTime fecha_fin = Convert.ToDateTime("" + Txt_fecha_fin.Value + " " + hora_fin + "");


            if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
            {

                //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_empresa(List_empresas.SelectedValue);
                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa(List_empresas.SelectedValue);

                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                     //registros encontrados si no se genera alerta de no se encontraron registros


                    Grilla_actas.DataSourceID = "";
                    Grilla_actas.DataSource = Visualizar_Tickets1;
                    Grilla_actas.DataBind();

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrados a la empresa ');", true);
                }
            }
            else
            {
                if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
                {

                    //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_empresa_consulto(List_empresas.SelectedValue, List_agente.SelectedValue);
                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_consultor(List_empresas.SelectedValue, List_agente.SelectedValue);

                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                        Grilla_actas.DataSourceID = "";
                        Grilla_actas.DataSource = Visualizar_Tickets1;
                        Grilla_actas.DataBind();

                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada y creadas por el agente selecionado');", true);
                    }
                }
                else
                {
                    if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                    {

                        //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_empresa_estado(List_empresas.SelectedValue, List_estados.SelectedValue);
                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_estado(List_empresas.SelectedValue, List_estados.SelectedValue);

                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                            Grilla_actas.DataSourceID = "";
                            Grilla_actas.DataSource = Visualizar_Tickets1;
                            Grilla_actas.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registradas de la empresa seleccionada y el estado seleccionado');", true);
                        }
                    }
                    else
                    {

                        if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                        }
                        else
                        {
                            if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                            }
                            else
                            {
                                if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                                }
                                else
                                {
                                    if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                                    }
                                    else
                                    {
                                        if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                                        }
                                        else
                                        {
                                            if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                                            }
                                            else
                                            {

                                                if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                                                }
                                                else
                                                {
                                                    if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                                                    }
                                                    else
                                                    {
                                                        if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                                                        {
                                                            //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_empresa(fecha_inicio, fecha_fin, List_empresas.SelectedValue);
                                                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa(fecha_inicio, fecha_fin, List_empresas.SelectedValue);

                                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                                Grilla_actas.DataSourceID = "";
                                                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                Grilla_actas.DataBind();

                                                            }
                                                            else
                                                            {

                                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada y el rango de fechas seleccionadas');", true);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                                                            {

                                                                //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue);
                                                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue);

                                                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                                                    Grilla_actas.DataSourceID = "";
                                                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                    Grilla_actas.DataBind();

                                                                }
                                                                else
                                                                {

                                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada y creadas por el agente selecionado');", true);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                                                {

                                                                    //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);
                                                                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                                                        Grilla_actas.DataSourceID = "";
                                                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                        Grilla_actas.DataBind();

                                                                    }
                                                                    else
                                                                    {

                                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada, las fechas selecionadas, el estado seleccionado y creadas por el agente selecionado');", true);
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                                                    {

                                                                        //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);
                                                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_estado(fecha_inicio, fecha_fin, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                                                            Grilla_actas.DataSourceID = "";
                                                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                            Grilla_actas.DataBind();

                                                                        }
                                                                        else
                                                                        {

                                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registradas de la empresa seleccionada, las fechas seleccionadas y el estado seleccionado ');", true);
                                                                        }
                                                                    }
                                                                    else
                                                                    {

                                                                        if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                                                                        {

                                                                            //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_empresa_consultor_estado(List_empresas.SelectedValue, List_agente.SelectedValue, List_estados.SelectedValue);
                                                                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_consultor_estado(List_empresas.SelectedValue, List_agente.SelectedValue, List_estados.SelectedValue);

                                                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                                                Grilla_actas.DataSourceID = "";
                                                                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                                Grilla_actas.DataBind();

                                                                            }
                                                                            else
                                                                            {

                                                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registradas de la empresa seleccionada el agente seleccionado y el estado seleccionado');", true);
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
                                }



                            }
                        }
                    }
                }
            }




        }
        protected void List_estados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hora_inicio = "00:00:00", hora_fin = "23:59:59";
            DateTime fecha_inicio = Convert.ToDateTime("" + Txt_fecha_inicio.Value + " " + hora_inicio + "");
            DateTime fecha_fin = Convert.ToDateTime("" + Txt_fecha_fin.Value + " " + hora_fin + "");


            if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue == "1")
            {

                //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.Listar_Actas_por_estado(List_estados.SelectedValue);
                Visualizar_Tickets1 = Gestion_Datos.Listar_Actas_por_estado(List_estados.SelectedValue);

                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                    Grilla_actas.DataSourceID = "";
                    Grilla_actas.DataSource = Visualizar_Tickets1;
                    Grilla_actas.DataBind();

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrados a la empresa ');", true);
                }
            }
            else
            {
                if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue == "1")
                {

                    //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_estado_consulto(List_estados.SelectedValue, List_agente.SelectedValue);
                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_estado_consultor(List_estados.SelectedValue, List_agente.SelectedValue);

                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                        Grilla_actas.DataSourceID = "";
                        Grilla_actas.DataSource = Visualizar_Tickets1;
                        Grilla_actas.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas con el estado seleccionado y creadas por el agente selecionado');", true);
                    }
                }
                else
                {
                    if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue != "1")
                    {

                        //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_empresa_estado(List_empresas.SelectedValue, List_estados.SelectedValue);
                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_estado(List_empresas.SelectedValue, List_estados.SelectedValue);

                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                            Grilla_actas.DataSourceID = "";
                            Grilla_actas.DataSource = Visualizar_Tickets1;
                            Grilla_actas.DataBind();

                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada y creadas por el agente selecionado');", true);
                        }
                    }
                    else
                    {
                        if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue != "1")
                        {

                            //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_empresa_consultor_estado(List_empresas.SelectedValue, List_agente.SelectedValue, List_estados.SelectedValue);
                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_consultor_estado(List_empresas.SelectedValue, List_agente.SelectedValue, List_estados.SelectedValue);

                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                Grilla_actas.DataSourceID = "";
                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                Grilla_actas.DataBind();

                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada, el agente seleccionado y en el estado seleccionado');", true);
                            }
                        }
                        else
                        {
                            if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue == "1")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                            }
                            else
                            {
                                if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                                }
                                else
                                {
                                    if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue == "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                                    }
                                    else
                                    {
                                        if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue == "1")
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                                        }
                                        else
                                        {

                                            if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue != "1")
                                            {
                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                                            }
                                            else
                                            {
                                                if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue != "1")
                                                {
                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                                                }
                                                else
                                                {
                                                    if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_empresas.SelectedValue != "1")
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha final para completar el rango de busqueda');", true);
                                                    }
                                                    else
                                                    {
                                                        if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue != "1")
                                                        {
                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' Seleccione una fecha inicial para completar el rango de busqueda');", true);
                                                        }
                                                        else
                                                        {
                                                            if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue == "1")
                                                            {

                                                                //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_estado(fecha_inicio, fecha_fin, List_estados.SelectedValue);
                                                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_estado(fecha_inicio, fecha_fin, List_estados.SelectedValue);

                                                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                                                    Grilla_actas.DataSourceID = "";
                                                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                    Grilla_actas.DataBind();

                                                                }
                                                                else
                                                                {

                                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas con el estado seleecionado y el rango de fechas seleccionado ');", true);
                                                                }
                                                            }
                                                            else
                                                            {

                                                                if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue != "1")
                                                                {

                                                                    //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);
                                                                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                                                        Grilla_actas.DataSourceID = "";
                                                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                        Grilla_actas.DataBind();

                                                                    }
                                                                    else
                                                                    {

                                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada, el agente seleccionado, el estado seleccionado y el rango de fechas seleccionado');", true);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (List_agente.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue != "1")
                                                                    {

                                                                        //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_empresa_estado(fecha_inicio, fecha_fin, List_empresas.SelectedValue, List_estados.SelectedValue);
                                                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_estado(fecha_inicio, fecha_fin, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                                                            Grilla_actas.DataSourceID = "";
                                                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                            Grilla_actas.DataBind();

                                                                        }
                                                                        else
                                                                        {

                                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada, el rango de fechas seleccionado y creadas por el agente selecionado');", true);
                                                                        }
                                                                    }
                                                                    else
                                                                    {

                                                                        if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue == "1")
                                                                        {

                                                                            //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_fechas_empresa_estado(fecha_inicio, fecha_fin, List_empresas.SelectedValue, List_estados.SelectedValue);
                                                                            Visualizar_Tickets1 = Gestion_Datos.Listar_Actas_por_consultor_estado_fechas(List_agente.SelectedValue, List_estados.SelectedValue, fecha_inicio, fecha_fin);

                                                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                                                Grilla_actas.DataSourceID = "";
                                                                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                                Grilla_actas.DataBind();

                                                                            }
                                                                            else
                                                                            {

                                                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas con el estado seleccionado, el rango de fechas seleccionado y creadas por el agente selecionado');", true);
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



                                }
                            }
                        }
                    }
                }
            }


        }

        protected void List_agente_SelectedIndexChanged(object sender, EventArgs e)
        {

            string hora_inicio = "00:00:00", hora_fin = "23:59:59";
            DateTime fecha_inicio = Convert.ToDateTime("" + Txt_fecha_inicio.Value + " " + hora_inicio + "");
            DateTime fecha_fin = Convert.ToDateTime("" + Txt_fecha_fin.Value + " " + hora_fin + "");


            if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
            {
                //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_consutor(List_agente.SelectedValue);
                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_consutor(List_agente.SelectedValue);

                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                    Grilla_actas.DataSourceID = "";
                    Grilla_actas.DataSource = Visualizar_Tickets1;
                    Grilla_actas.DataBind();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'No se encontraron actas creadas por el agente seleccionado  ', confirmButtonText: 'Ok' })  ", true);
                }
            }
            else
            {
                if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
                {

                    //List<Visualizar_Tickets> Visualizar_Actas = Gestion_Datos.listar_Actas_por_empresa_consulto(List_empresas.SelectedValue, List_agente.SelectedValue);
                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_consultor(List_empresas.SelectedValue, List_agente.SelectedValue);

                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                        Grilla_actas.DataSourceID = "";
                        Grilla_actas.DataSource = Visualizar_Tickets1;
                        Grilla_actas.DataBind();
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'No se encontraron actas creadas para la empresa selecionada y el consultor seleccionado ', confirmButtonText: 'Ok' })  ", true);
                    }
                }
                else
                {
                    if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                    {
                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_estado_consultor(List_estados.SelectedValue, List_agente.SelectedValue);

                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                            Grilla_actas.DataSourceID = "";
                            Grilla_actas.DataSource = Visualizar_Tickets1;
                            Grilla_actas.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron actas creadas en el estado seleccionado y el agente seleccionado  ', confirmButtonText: 'Ok' })  ", true);
                        }
                    }
                    else
                    {
                        if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                        {

                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_consultor_estado(List_empresas.SelectedValue, List_agente.SelectedValue, List_estados.SelectedValue);

                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                Grilla_actas.DataSourceID = "";
                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                Grilla_actas.DataBind();
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron actas creadas para la empresa selecionada y el consultor seleccionado   ', confirmButtonText: 'Ok' })  ", true);
                            }
                        }
                        else
                        {
                            if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
                            {

                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: '  Seleccione una fecha final para completar el rango de busqueda  ', confirmButtonText: 'Ok' })  ", true);

                            }
                            else
                            {
                                if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                                {

                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione una fecha inicial para completar el rango de busqueda', confirmButtonText: 'Ok' })  ", true);
                                }
                                else
                                {
                                    if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                                    {

                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione una fecha inicial para completar el rango de busqueda', confirmButtonText: 'Ok' })  ", true);
                                    }
                                    else
                                    {
                                        if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue == "1")
                                        {

                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione una fecha final para completar el rango de busqueda', confirmButtonText: 'Ok' })  ", true);
                                        }
                                        else
                                        {
                                            if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                                            {

                                                ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'Seleccione una fecha final para completar el rango de busqueda', confirmButtonText: 'Ok' })  ", true);
                                            }
                                            else
                                            {
                                                if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                                {



                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' Seleccione una fecha de inicio para completar el rango de busqueda', confirmButtonText: 'Ok' })  ", true);
                                                }
                                                else
                                                {
                                                    if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "" && List_estados.SelectedValue != "1")
                                                    {


                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' Seleccione una fecha inicial para completar el rango de busqueda', confirmButtonText: 'Ok' })  ", true);
                                                    }
                                                    else
                                                    {
                                                        if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                                        {

                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' Seleccione una fecha final para completar el rango de busqueda  ', confirmButtonText: 'Ok' })  ", true);
                                                        }
                                                        else
                                                        {
                                                            if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                                                            {
                                                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue);

                                                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                                                    Grilla_actas.DataSourceID = "";
                                                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                    Grilla_actas.DataBind();

                                                                }
                                                                else
                                                                {

                                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'No se encontraron actas registrasdas en el rango de fecha seleccionado y el agente seleccionado ', confirmButtonText: 'Ok' })  ", true);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue == "1")
                                                                {

                                                                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue);

                                                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                                                        Grilla_actas.DataSourceID = "";
                                                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                        Grilla_actas.DataBind();

                                                                    }
                                                                    else
                                                                    {

                                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: ' No se encontraron actas registrasdas de la empresa seleccionada, el agente selecionado y el rango de fecha seleccionado ', confirmButtonText: 'Ok' })  ", true);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (List_empresas.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                                                    {

                                                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                                                            Grilla_actas.DataSourceID = "";
                                                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                            Grilla_actas.DataBind();

                                                                        }
                                                                        else
                                                                        {


                                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", " Swal.fire({ position: 'top-center', icon: 'warning', text: 'No se encontraron actas registrasdas de la empresa seleccionada, el agente selecionado, el estado seleccionado y el rango de fecha seleccionado ', confirmButtonText: 'Ok' })  ", true);
                                                                            //asasa
                                                                        }
                                                                    }
                                                                    else
                                                                    {

                                                                        if (List_empresas.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_estados.SelectedValue != "1")
                                                                        {

                                                                            Visualizar_Tickets1 = Gestion_Datos.Listar_Actas_por_consultor_estado_fechas(List_agente.SelectedValue, List_estados.SelectedValue, fecha_inicio, fecha_fin);

                                                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                                                Grilla_actas.DataSourceID = "";
                                                                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                                Grilla_actas.DataBind();

                                                                            }
                                                                            else
                                                                            {

                                                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas en el estado seleccionada, el rango de fecha seleccionado y el agente seleccionado');", true);
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


                                }
                            }
                        }
                    }
                }
            }
        }

        protected void Btn_busca_actas_Click(object sender, EventArgs e)
        {
            string hora_inicio = "00:00:00", hora_fin = "23:59:59";
            DateTime fecha_inicio = Convert.ToDateTime("" + Txt_fecha_inicio.Value + " " + hora_inicio + "");
            DateTime fecha_fin = Convert.ToDateTime("" + Txt_fecha_fin.Value + " " + hora_fin + "");


            if (Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Digite un rango de fecha para la busqueda ');", true);
            }
            else
            {
                if (Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Digite una fecha inicial para completar el rango de busqueda ');", true);
                }
                else
                {
                    if (Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Digite un fecha final para completar el rango de busqueda ');", true);
                    }
                    else
                    {
                        if (fecha_inicio > fecha_fin)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('La fecha de inicio es mayor que la fecha fin ');", true);
                        }
                        else
                        {
                            if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue == "1")
                            {

                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas(fecha_inicio, fecha_fin);

                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                    Grilla_actas.DataSourceID = "";
                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                    Grilla_actas.DataBind();

                                }
                                else
                                {


                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas en el rango de fechas selecionadas ');", true);
                                }

                            }
                            else
                            {
                                if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue == "1")
                                {
                                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa(fecha_inicio, fecha_fin, List_empresas.SelectedValue);

                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                        Grilla_actas.DataSourceID = "";
                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                        Grilla_actas.DataBind();

                                    }
                                    else
                                    {


                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas para la empresa seleccionada en el rango de fechas selecionadas ');", true);
                                    }

                                }
                                else
                                {
                                    if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue == "1")
                                    {
                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue);

                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                            Grilla_actas.DataSourceID = "";
                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                            Grilla_actas.DataBind();

                                        }
                                        else
                                        {


                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas en el rango de fechas selecionadas y el agente selecionado ');", true);
                                        }

                                    }
                                    else
                                    {
                                        if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue != "1")
                                        {
                                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_estado(fecha_inicio, fecha_fin, List_estados.SelectedValue);

                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                Grilla_actas.DataSourceID = "";
                                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                                Grilla_actas.DataBind();

                                            }
                                            else
                                            {


                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas en el rango de fechas selecionadas y el agente selecionado ');", true);
                                            }

                                        }
                                        else
                                        {
                                            if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue == "1")
                                            {
                                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue);

                                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                                    Grilla_actas.DataSourceID = "";
                                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                                    Grilla_actas.DataBind();

                                                }
                                                else
                                                {


                                                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas en el rango de fechas selecionadas de la empresa y el agente seleccionado  ');", true);
                                                }


                                            }
                                            else
                                            {
                                                if (List_estados.SelectedValue != "1" && List_agente.SelectedValue != "1" && List_empresas.SelectedValue == "1")
                                                {
                                                    Visualizar_Tickets1 = Gestion_Datos.Listar_Actas_por_consultor_estado_fechas(List_agente.SelectedValue, List_estados.SelectedValue, fecha_inicio, fecha_fin);

                                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                                        Grilla_actas.DataSourceID = "";
                                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                                        Grilla_actas.DataBind();

                                                    }
                                                    else
                                                    {


                                                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas en el rango de fechas selecionadas el estado seleccionado y el agente seleccionado  ');", true);
                                                    }

                                                }
                                                else
                                                {
                                                    if (List_estados.SelectedValue != "1" && List_empresas.SelectedValue != "1" && List_agente.SelectedValue == "1")
                                                    {
                                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_estado(fecha_inicio, fecha_fin, List_empresas.SelectedValue, List_agente.SelectedValue);

                                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                                            Grilla_actas.DataSourceID = "";
                                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                                            Grilla_actas.DataBind();

                                                        }
                                                        else
                                                        {


                                                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas en el rango de fechas selecionadas el estado seleccionado y la empresa seleccionada  ');", true);
                                                        }

                                                    }
                                                    else
                                                    {

                                                        if (List_agente.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "" && List_empresas.SelectedValue != "1" && List_estados.SelectedValue != "1")
                                                        {

                                                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                                Grilla_actas.DataSourceID = "";
                                                                Grilla_actas.DataSource = Visualizar_Tickets1;

                                                                Grilla_actas.DataBind();

                                                            }
                                                            else
                                                            {

                                                                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(' No se encontraron actas registrasdas de la empresa seleccionada, el agente seleccionado, el estado seleccionado y el rango de fechas seleccionado');", true);
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

                }

            }


            //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Fecha inicio ("+fecha_inicio+")y fin "+fecha_fin+" ');", true);

        }

        //metodo para exportar grilla a archivo de excel, en el diseño, en el archivo aspx se debe agregar la propiedad
        //EnableEventValidation = "false" para que permita la exportacion de la grilla en la linea 1 <%@ Page Language="C#" 
        private void exportar_actas()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Lista_actas" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application / vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Grilla_actas.GridLines = GridLines.Both;
            Grilla_actas.HeaderStyle.Font.Bold = true;
            Grilla_actas.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        //metodo requerido para la exportacion de la grilla a excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            // necesario para evitar el error de tiempo de ejecución "
            // El control 'GridView1' de tipo 'GridView' debe colocarse dentro de una etiqueta de formulario con runat = server.
        }

        protected void Btn_exportar_actas_Click(object sender, EventArgs e)
        {
            exportar_actas();

        }


        protected void Grilla_actas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void Grilla_actas_RowEditing(object sender, GridViewEditEventArgs e)
        {


            Grilla_actas.EditIndex = e.NewEditIndex;
            Recargar_grilla();

            Grilla_actas.Columns[0].Visible = true;
            Grilla_actas.DataBind();

            //Grilla_actas.DataSourceID = "";
            //Grilla_actas.DataSource = Visualizar_Tickets1;


        }
        protected void Grilla_actas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            //Restablece el índice de edición
            Grilla_actas.EditIndex = -1;

            //Vincular datos al control

            Recargar_grilla();
            //Grilla_actas.DataSourceID = "";
            //Grilla_actas.DataSource = Visualizar_Tickets1;
            //Grilla_actas.DataBind();

        }

        protected void Grilla_actas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            int ID = Convert.ToInt32(Grilla_actas.Rows[Grilla_actas.EditIndex].Cells[0].Text.ToString());
            string n_factura = e.NewValues[0].ToString();

            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            string query = " UPDATE acta SET Numero_Factura = @Numero_Factura WHERE  id_acta = @idactas ";
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@idactas", ID);
            comando.Parameters.AddWithValue("@Numero_Factura", n_factura);
            comando.ExecuteNonQuery();
            Grilla_actas.EditIndex = -1;

            Recargar_grilla();


            Grilla_actas.Columns[0].Visible = false;
            Grilla_actas.DataBind();

        }

        protected void Grilla_actas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //Grilla_actas.DataSourceID = "";
            //Grilla_actas.DataSource = Visualizar_Tickets1;
            //Grilla_actas.DataBind();


        }

        protected void Grilla_actas_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {




        }

        protected void Recargar_grilla()
        {
            string hora_inicio = "00:00:00", hora_fin = "23:59:59";
            DateTime fecha_inicio = Convert.ToDateTime("" + Txt_fecha_inicio.Value + " " + hora_inicio + "");
            DateTime fecha_fin = Convert.ToDateTime("" + Txt_fecha_fin.Value + " " + hora_fin + "");

            if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
            {
                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa(List_empresas.SelectedValue);

                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                    Grilla_actas.DataSourceID = "";
                    Grilla_actas.DataSource = Visualizar_Tickets1;
                    Grilla_actas.DataBind();


                }
                else
                {
                }
            }
            else
            {
                if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
                {
                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_consutor(List_agente.SelectedValue);

                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                        Grilla_actas.DataSourceID = "";
                        Grilla_actas.DataSource = Visualizar_Tickets1;
                        Grilla_actas.DataBind();

                    }
                    else
                    {
                    }
                }
                else
                {
                    if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
                    {
                        Visualizar_Tickets1 = Gestion_Datos.Listar_Actas_por_estado(List_estados.SelectedValue);

                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                            Grilla_actas.DataSourceID = "";
                            Grilla_actas.DataSource = Visualizar_Tickets1;
                            Grilla_actas.DataBind();

                        }
                        else
                        {



                        }

                    }
                    else
                    {

                        if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                        {
                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas(fecha_inicio, fecha_fin);

                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                Grilla_actas.DataSourceID = "";
                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                Grilla_actas.DataBind();

                            }
                            else
                            {
                            }

                        }
                        else
                        {
                            if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
                            {
                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_consultor(List_empresas.SelectedValue, List_agente.SelectedValue);

                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                    Grilla_actas.DataSourceID = "";
                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                    Grilla_actas.DataBind();

                                }
                                else
                                {
                                }

                            }
                            else
                            {
                                if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
                                {
                                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_estado(List_empresas.SelectedValue, List_estados.SelectedValue);

                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                        Grilla_actas.DataSourceID = "";
                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                        Grilla_actas.DataBind();
                                    }
                                    else
                                    {
                                    }

                                }
                                else
                                {

                                    if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                                    {
                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa(fecha_inicio, fecha_fin, List_empresas.SelectedValue);

                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                            Grilla_actas.DataSourceID = "";
                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                            Grilla_actas.DataBind();

                                        }
                                        else
                                        {
                                        }

                                    }
                                    else
                                    {
                                        if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                                        {
                                            Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue);

                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                Grilla_actas.DataSourceID = "";
                                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                                Grilla_actas.DataBind();

                                            }
                                            else
                                            {
                                            }

                                        }
                                        else
                                        {
                                            if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
                                            {
                                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_estado_consultor(List_estados.SelectedValue, List_agente.SelectedValue);

                                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                                    Grilla_actas.DataSourceID = "";
                                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                                    Grilla_actas.DataBind();

                                                }
                                                else
                                                {
                                                }

                                            }
                                            else
                                            {
                                                if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                                                {
                                                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_estado(fecha_inicio, fecha_fin, List_estados.SelectedValue);

                                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                                        Grilla_actas.DataSourceID = "";
                                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                                        Grilla_actas.DataBind();

                                                    }
                                                    else
                                                    {
                                                    }

                                                }
                                                else
                                                {
                                                    if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
                                                    {

                                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_empresa_consultor_estado(List_empresas.SelectedValue, List_agente.SelectedValue, List_estados.SelectedValue);

                                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                                            Grilla_actas.DataSourceID = "";
                                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                                            Grilla_actas.DataBind();
                                                        }
                                                        else
                                                        {
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                                                        {

                                                            Visualizar_Tickets1 = Gestion_Datos.Listar_Actas_por_consultor_estado_fechas(List_agente.SelectedValue, List_estados.SelectedValue, fecha_inicio, fecha_fin);

                                                            if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                 //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                            {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                 //registros encontrados si no se genera alerta de no se encontraron registros
                                                                Grilla_actas.DataSourceID = "";
                                                                Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                Grilla_actas.DataBind();
                                                            }
                                                            else
                                                            {
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                                                            {

                                                                Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_estado(fecha_inicio, fecha_fin, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                                if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                     //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                     //registros encontrados si no se genera alerta de no se encontraron registros
                                                                    Grilla_actas.DataSourceID = "";
                                                                    Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                    Grilla_actas.DataBind();
                                                                }
                                                                else
                                                                {
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                                                                {

                                                                    Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue);

                                                                    if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                         //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                    {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                         //registros encontrados si no se genera alerta de no se encontraron registros
                                                                        Grilla_actas.DataSourceID = "";
                                                                        Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                        Grilla_actas.DataBind();
                                                                    }
                                                                    else
                                                                    {
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (List_empresas.SelectedValue != "1" && List_agente.SelectedValue != "1" && List_estados.SelectedValue != "1" && Txt_fecha_inicio.Value != "" && Txt_fecha_fin.Value != "")
                                                                    {

                                                                        Visualizar_Tickets1 = Gestion_Datos.listar_Actas_por_fechas_empresa_consultor_estado(fecha_inicio, fecha_fin, List_agente.SelectedValue, List_empresas.SelectedValue, List_estados.SelectedValue);

                                                                        if (Visualizar_Tickets1.Count != 0)                  //Me confronta si el select del metodo listar_Tickets_por_Estado_empresa
                                                                                                                             //me trae campos o datos de la tabla tickets de no ser asi el valor se comvierte en 0 con tipo count = 0
                                                                        {                                                    //encapsulado en la variable visualizar_Tickets y count es diferente a 0 se carga la grilla con los  
                                                                                                                             //registros encontrados si no se genera alerta de no se encontraron registros
                                                                            Grilla_actas.DataSourceID = "";
                                                                            Grilla_actas.DataSource = Visualizar_Tickets1;
                                                                            Grilla_actas.DataBind();
                                                                        }
                                                                        else
                                                                        {
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (List_empresas.SelectedValue == "1" && List_agente.SelectedValue == "1" && List_estados.SelectedValue == "1" && Txt_fecha_inicio.Value == "" && Txt_fecha_fin.Value == "")
                                                                        {


                                                                            //registros encontrados si no se genera alerta de no se encontraron registros
                                                                            Grilla_actas.DataSourceID = "tabla_actas";
                                                                            Grilla_actas.DataBind();

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
                            }
                        }
                    }
                }
            }
        }
    }




}