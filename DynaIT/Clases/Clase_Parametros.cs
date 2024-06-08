using System;

namespace DynaIT.Clases
{
    public class Clase_Parametros
    {
        //*********************** [grupo insercion de tabla Ticket ]*****************************************************************

        public int No_ticket { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Tipo_ticket { get; set; }
        public string Resumen { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public DateTime tiempo_Respuesta { get; set; }
        public string Ticket_Creado_por { get; set; }
        public string Adjuntos_ticket { get; set; }

        public string Grupo { get; set; }
        public string Agente { get; set; }
        public DateTime Fecha_inicio_proceso { get; set; }
        public int TiempoDesarrollo { get; set; }
        public int h_adicionales { get; set; }
        public DateTime Fecha_resuelto_ticket { get; set; }
        public DateTime Fecha_cierre_ticket { get; set; }
        public string Resumen_Problema { get; set; }
        public string Cliente_idCliente { get; set; }
        public int N_creditos_garantia { get; set; }


        public string Id_cliente { get; set; }
        public int Fk_Id_Usuario { get; set; }
        public string area_id_area { get; set; }



        //*********************** [grupo vista cliente en la creacion Ticket ]**************************************


        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Empresa { get; set; }


        //*********************** [grupo insercion de tabla empresa ]*****************************************************************

        public int id_Empresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public string Nit { get; set; }
        public string Telefono_Empresa { get; set; }
        public string Empresa_Habilitada { get; set; }
        public string Representante_empresa { get; set; }



        public string Contador_empresas { get; set; }
        //*********************** [grupo insercion de tabla Cliente ]*****************************************************************

        public int idCliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Correo_Cliente { get; set; }
        public string Telefono_Cliente { get; set; }
        public int Rol_Cliente { get; set; }
        public string Rol_Cli { get; set; }
        public string cliente_habilitado { get; set; }
        public int Id_Empresa_cliente { get; set; }

        public string Contraseña { get; set; }
        public int Fk_Empresa { get; set; }

        //*********************** [grupo insercion de tabla Usuario ]*****************************************************************

        public int Id_usuario { get; set; }

        public string Nombre_Usuario { get; set; }
        public string Correo_Usuario { get; set; }
        public int Rol_usuario { get; set; }
        public string Rol_usu_tex { get; set; }
        public string Usuario { get; set; }    /*aaaaaaaaaaaaa*/
        public int fk_area_id_area { get; set; }    /*aaaaaaaaaaaaa*/
        public string Prefijo_Usuario { get; set; }
        public string Contraseña_Usuario { get; set; }
        public string Usuarioprefijo { get; set; }    /*aaaaaaaaaaaaa*/


        public string Grupo_Usuario { get; set; }

        //************** [ Insercion de tabla crear estados de tickets ] ***********************

        public int Id_Estados_tickets { get; set; }
        public string Estados_tickets { get; set; }
        public string estado_Habilitado { get; set; }

        //************** [ Insercion de tabla crear area de usuario ] ***********************
        public int Ta_id_area { get; set; }
        public string Tabla_Grupos_Usuario { get; set; }
        public string Tabla_Grupos_Habilitado { get; set; }


        //************** [ Insercion de tabla tipós de tickets ] ***********************

        public int id_tipos_tickets { get; set; }
        public string tipos_tickets { get; set; }
        public int horas_respuesta_tipos_tickets { get; set; }

        public string Tipo_Ticket_Habilitado { get; set; }
        public int Tttipo_Horas_respuesta { get; set; }


        // ***********************[traer contadores de los tickets abietos pendientes resueltos y cerrados]
        public int N_abiertos { get; set; }
        public int N_Pendientes { get; set; }
        public int N_Resueltos { get; set; }
        public int N_Cerrados { get; set; }


        //*****************insertar en la tabla notas **************************
        public int id_notas { get; set; }
        public string descripcionNota { get; set; }
        public DateTime FechaNota { get; set; }
        public string Ticket_idTicket_nota { get; set; }
        public int Usuario_idUsuario_nota { get; set; }
        public int cliente_idCliente_nota { get; set; }
        public int estado_idEstado_nota { get; set; }
        public int usuario_id_nota { get; set; }
        public int cliente_id_nota { get; set; }
        public string nota_interna { get; set; }
        public string Adjuntos_nota { get; set; }
        public int Nota_usuario { get; set; }



        //*****************insertar en la tabla actas **************************

        public int idactas { get; set; }
        public string Numero_Acta { get; set; }
        public DateTime Fecha_crea_acta { get; set; }
        public string ticket_idTicket { get; set; }
        public string N_creditos_acta { get; set; }
        public int N_credi_garantia_acta { get; set; }
        public int fk_usuario_id { get; set; }


        //*****************insertar en la tabla nota compartida **************************
        public int nota_idNota_compartida { get; set; }
        public string usuario_idUsuario_compartida { get; set; }

        //*****************tabla prioridad **************************
        public int Tprioridad_Horas_respuesta { get; set; }
    }
}