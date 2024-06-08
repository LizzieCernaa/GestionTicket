namespace DynaIT.Clases
{
    public class Informe
    {
        public int id_usuario { get; set; }
        public string prefijo_usuario { get; set; }
        public int n_ticket_nuevos_dia { get; set; }
        public int n_ticket_nuevos_dia_jornada { get; set; }
        public int n_ticket_Resueltos_hoy { get; set; }
        public int n_ticket_cerrados_hoy { get; set; }
        public int N_casos_abierto_cierre_jornada { get; set; }
        public int n_creditos_hoy { get; set; }
        public int n_ticket_desarrollo { get; set; }
        public int n_ticket_incidente { get; set; }
        public int n_ticket_proyecto { get; set; }

        //--------------------------------------------

        public string id_usuario_sin_responder { get; set; }
        public int id_ticket_sin_responder { get; set; }
        public int n_nota_sin_responder { get; set; }

        //--------------------------------------------



    }
}