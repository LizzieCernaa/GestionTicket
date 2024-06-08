using System;

namespace DynaIT.Clases
{
    public class Visualizar_Tickets
    {
        public int N_Ticket { get; set; }
        public int N_Tickets { get; set; }

        public string tipo_ticket { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public string Resumen_Problema { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad_id_prioridad { get; set; }
        public string nombre_empresa { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Nombre_usuario { get; set; }

        public string estado_ticket { get; set; }
        public string Ticket_Creado_por { get; set; }
        public int TiempoDesarrollo { get; set; }
        public DateTime Fecha_cierre_ticket { get; set; }
        public int Numero_Dias { get; set; }
        public string Numero_Factura { get; set; }
        public DateTime tiempo_Respuesta { get; set; }
        public DateTime Fecha { get; set; }
        public int estado_idEstadoticket { get; set; }
        public DateTime Fecha_vencimiento { get; set; }



        //------------------------Parametros de nota tickets------------------------

        public int idnotas { get; set; }
        public DateTime FechaNota { get; set; }
        public string descripcionNota { get; set; }
        public int nota_creada_por { get; set; }
        public string nota_interna { get; set; }
        public string Adjuntos_nota { get; set; }
        public int cliente_id_nota { get; set; }
        public int usuario_id_nota { get; set; }

        //------------------------Parametros de nota Cliente------------------------


        public int id_Cliente { get; set; }
        //public string nombre_cliente { get; set; }
        public string Telefono_cliente { get; set; }
        public string correo_cli { get; set; }
        public string rol { get; set; }
        public string Contrasena_cli { get; set; }
        //public string nombre_empresa { get; set; }



        //------------------------Parametros de actas------------------------

        public int id_acta { get; set; }
        public string Numero_Acta { get; set; }
        public int ticket_id { get; set; }
        public DateTime Fecha_crea_acta { get; set; }
        public int N_creditos_acta { get; set; }

        public string Representante_empresa { get; set; }
        public string Nombres { get; set; }

        //------------------------Parametros numero de tickers abiertos------------------------

        public int n_abiertos { get; set; }

        //------------------------parametros de la tabla usuario------------------------

        public int Tlu_id_usuario { get; set; }
        public string Tlu_nombre_usuario { get; set; }
        public string Tu_correo_usuario { get; set; }


        //------------------------parametros de la tabla prioridad------------------------
        public int Tlp_id_prioridad { get; set; }
        public string Tlp_prioridad { get; set; }

        //------------------------parametros de la grfica de creados ------------------------
        public string Nombre_usuario_grfica_creados { get; set; }
        public int N_Ticket_grafica_creados { get; set; }
        //------------------------parametros de la grfica de trabajados ------------------------
        public string Nombre_usuario_grfica_trabajados { get; set; }
        public int N_Ticket_grafica_trabajados { get; set; }
        public int N_creditos { get; set; }

    }





}