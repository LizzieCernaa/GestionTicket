using System;
using System.Collections.Generic;

using System.Data.SqlClient;

namespace DynaIT.Clases
{
    public class Validaciones
    {

        public string error;
        Visualizar_Tickets Visualizar_Tickets = new Visualizar_Tickets();
        static string conex = @"Server=127.0.0.1,1433;Database=DynaIT;User Id=Lizzie;Password=NADA1234;";
        SqlConnection conexion = new SqlConnection(conex);
        public Validaciones()
        {
            this.conexion = Conexion_MySQL.getConexion();
        }

        
        public Boolean Existe_Nit(string codigo)
        {
            string sql = (" select * from empresa where Nit = @Nit ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Nit", codigo);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }//      validar si existe el Correo de usuario y contraseña 
        public Boolean inicio_sesion_usuario(string Correo, string Contrasena)
        {
            string patron = "Dynamics1";
            //string sql = ("select correo_usu, contrasena_usu from usuario where correo_usu = @correo_usu and contrasena_usu = @contrasena_usu and usuario_Habilitado = 'Si' ");
            SqlCommand cmd = new SqlCommand("Validar_usu", conexion) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@correo_usu", Correo);
            cmd.Parameters.AddWithValue("@contrasena_usu", Contrasena);
            cmd.Parameters.AddWithValue("@usuario_Habilitado", Correo);
            cmd.Parameters.AddWithValue("@Patron", patron);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }

        //      validar si existe el Correo de cliente y contraseña 
        public Boolean inicio_sesion_cliente(string Correo, string Contraseña)
        {
            //string sql = ("select * from cliente where correo_cli = @correo_cli and Contrasena_cli = @Contrasena_cli and Cliente_Habilitado = 'Si' ");
            string Cliente_Habilitado = "Si", patron = "Dynamics1";
            //SqlCommand cmd = new SqlCommand("Validar_cli", conexion);
            SqlCommand cmd = new SqlCommand("Validar_cli", conexion) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@correo_cli", Correo);
            cmd.Parameters.AddWithValue("@Contrasena_cli", Contraseña);
            cmd.Parameters.AddWithValue("@Cliente_Habilitado", Cliente_Habilitado);
            cmd.Parameters.AddWithValue("@Patron", patron);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }


        //      validar si existe el Correo de usuario 
        public Boolean Existe_Correo_usuario(string codigo)
        {
            string sql = ("select * from usuario where correo_usu = @Correo");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Correo", codigo);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }


        //      validar si existen notas
        public Boolean Existe_notas_ticket(string id_ticket)
        {
            string sql = (" select * from nota where id_ticket = @id_ticket ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_ticket", id_ticket);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }



        //      validar si existen notas
        public Boolean Existe_ticket(string id_ticket)
        {
            string sql = (" select * from ticket where id_ticket = @id_ticket ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_ticket", id_ticket);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }




        //      validar si existe el Correo de usuario 
        public Boolean Existe_Correo_cliente(string codigo)
        {
            string sql = ("select * from cliente where correo_cli = @Correo");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Correo", codigo);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }







        //      validar si existe un estado de ticket 
        public Boolean Existe_Estado_Ticket(string estado_ticket)
        {
            string sql = (" select * from estado_ticket where estado_Ticket = @estado_Ticket ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@estado_Ticket", estado_ticket);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }
        //      validar si existe un tipo ticket 
        public Boolean Existe_tipo_ticket(string estado_ticket)
        {
            string sql = (" select * from tipo_ticket where tipo_ticket = @tipo_ticket ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@tipo_ticket", estado_ticket);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }

        //      validar si existe el grupo de usuario
        public Boolean Existe_Grupos_usuario(string estado_ticket)
        {
            string sql = ("SELECT * FROM area where area = @area_usuario");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@area_usuario", estado_ticket);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }


        //      validar si hay usuario vinculados a el grupo a eliminar
        public Boolean Existe_usuario_vinculado(int grupo_idGrupo)
        {
            string sql = ("SELECT * FROM usuario  where area_id = @area_idarea And usuario_Habilitado = 'Si'");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@area_idarea", grupo_idGrupo);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }



        //      validar si hay usuario vinculados a el grupo a eliminar
        public Boolean Existe_usuario_vinculado_aTicket(int Usuario_idUsuario)
        {
            string sql = (" Select * from ticket where usuario_id = @Usuario_idUsuario ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }

        //      validar si clienteesta vinculado a tickets para evitar eliminarlos
        public Boolean Existe_cliente_vinculado_aTicket(int cliente_id)
        {
            string sql = (" Select * from ticket where cliente_id = @cliente_id ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@cliente_id", cliente_id);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }


        //valida si hay tickets vinculados a el tipo de ticket que se va a eliminar
        public Boolean Existe_ticket_vinculado_tipo(int tipo_ticket_id)
        {
            string sql = (" SELECT * FROM ticket  where tipo_ticket_id = @tipo_ticket_id And ticket_Habilitado = 'Si' ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@tipo_ticket_id ", tipo_ticket_id);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }

        //valida si hay tickets vinculados a el estado de ticket que se va a eliminar
        public Boolean Existe_ticket_vinculado_estado(string tipo_ticket_id)
        {
            string sql = (" SELECT * FROM ticket  where estado_id = @tipo_ticket_id And ticket_Habilitado = 'Si' ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@tipo_ticket_id ", tipo_ticket_id);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }


        //valida si hay tickets vinculados a el tipo de ticket que se va a eliminar
        public Boolean Existe_ticket_vinculado_estado(int id_Estado_Ticket)
        {
            string sql = (" SELECT * FROM estado_ticket  where id_Estado_Ticket = @id_Estado_Ticket And estado_Habilitado = 'Si' ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_Estado_Ticket ", id_Estado_Ticket);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }




        //      validar si hay empresas con el mismo nombre y nit
        public Boolean Existe_empresa(string Nombre_Empresa, string Nit)
        {
            string sql = (" SELECT * FROM empresa where nombre_empresa = @Nombre_Empresa or nit = @Nit ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Nombre_Empresa", Nombre_Empresa);
            cmd.Parameters.AddWithValue("@Nit", Nit);


            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }

        //      validar si la empresas esta habilitada
        public Boolean empresa_habilitada(string id_Empresas)
        {
            string sql = (" SELECT * FROM empresa where id_empresa = @id_Empresas and empresa_habilitada = 'Si' ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);



            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }


        //      validar si hay empresas con el mismo nombre y nit
        public Boolean Existe_empresa_editar(string Nombre_Empresa, string Nit)
        {
            string sql = (" SELECT count(*) FROM empresa " +
                " where Nombre_Empresa = @Nombre_Empresa and Nit = @Nit");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Nombre_Empresa", Nombre_Empresa);
            cmd.Parameters.AddWithValue("@Nit", Nit);


            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                registro.Close();

                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }



        //      validar si hay clientes vinculados a la empresa eliminar
        public Boolean Existe_cliente_vinculado(string Id_Empresa)
        {
            string sql = (" SELECT * FROM cliente where empresa_id = @Id_Empresa And Cliente_Habilitado = 'Si' ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                registro.Close();
                return true;
            }
            else
            {
                registro.Close();
                return false;
            }
        }
        public Boolean Validar_nota(int n_nota)
        {
            string sql = (" select nota_usuario from nota where id_nota = @id_nota ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_nota", n_nota);
            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Boolean valor = registro.GetBoolean(0);
                registro.Close();
                return valor;
            }
            else
            {
                Boolean valor = false;
                registro.Close();
                return valor;
            }
        }




        //      validar si existe el Correo de usuario y contraseña 
        public Boolean recuperar_contraseña(string Nombre, string Correo, string clave)
        {
            var mailService = new correo_recuperacion();
            mailService.sendMail(
                subject: "Solicitud recuperacion de contraseña",
                body: "Hola, " + Nombre + " solicitaste recuperacion de contraseña!" +
                " su contraseña es: " + clave + ".",
                recipientMail: new List<string> { Correo }
                );

            return true;
        }




        //      
        public Boolean recuperar_contraseña_cliente(string Correo)
        {
            string sql = (" select * from cliente where correo_cli = @Correo and Cliente_Habilitado = 'Si' ");
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Correo", Correo);

            //*** confronta la consulta o la insercion que le pido a mySQL y si me sale error en esta liena es por mal istruccion en la cadena de caracteres de mysql
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                string userName = registro.GetString(1);
                string userMail = registro.GetString(2);
                string accountPassword = registro.GetString(5);

                var mailService = new correo_recuperacion();
                mailService.sendMail(
                    subject: "Solicitud recuperacion de contraseña",
                    body: "Hola, " + userName + " solicitaste recuperacion de contraseña!" +
                    " su contraseña es: " + accountPassword + ".",
                    recipientMail: new List<string> { userMail }
                    );


                registro.Close();
                return true;

            }
            else
            {
                registro.Close();
                return false;
            }
        }

        public void actualizar_editar_contra_usuario(string recu_correo, string recu_contraseña, string username)
        {
            var mailService = new correo_recuperacion();
            mailService.sendMail(
                subject: " Registro de datos de acceso ",
                body: "Hola, " + username + " se registraron los siguientes datos de acceso !" +
                " su contraseña es: " + recu_contraseña + ".",
                recipientMail: new List<string> { recu_correo }
                );

        }

        public void Notificar_solucion_ticket(string correo, string username, string n_ticket, string solucion)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + username + "" + " Su solicitud N " + " " + n_ticket + " " + " se ha solucionado con el comentario: " + "</h4>" +
                    "<p>" + solucion + "</p>" +
                    "<p>" + " El caso sera cerrrado en las proximas 72 horas " + " </p>" +
                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(
                subject: " Su solicitud numero " + " " + n_ticket + " " + " ha sido resuelta",
                body: bodys,
                recipientMail: new List<string> { correo }
                );

        }

        public void Notificar_cierre_ticket(string correo, string username, string n_ticket, string solucion)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + username + "" + " Su solicitud N " + " " + n_ticket + " " + " se ha cerrado con el comentario: " + "</h4>" +
                    "<p>" + solucion + "</p>" +
                    "<p>" + "Fue un placer haberle asistido a lo largo de este caso, " + " </p>" +
                    "<p>" + "Este caso será archivado por inactividad. Si tuviera de nuevo problemas relacionados al Acuerdo de trabajo establecido en este caso, por favor abra un caso nuevo. " + " </p>" +
                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(
                subject: " Su solicitud numero " + " " + n_ticket + " " + " ha sido Cerredo",
                body: bodys,
                recipientMail: new List<string> { correo }
                );

        }


        //metodo para notificar consultores asociados a una fecha
        public void Notificar_consultores(string correo, string username, string n_ticket, string nota_descripcion)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + username + "" + " ha sido viculado en el ticket numero  " + " " + n_ticket + " " + " con el comentario: " + "</h4>" +
                    "<hr>" + "" + "</hr>" +
                    "<p>" + nota_descripcion + "</p>" +
                    "<hr>" + "" + "</hr>" +
                    "<p>" + "  " + " </p>" +
                    "<p>" + " " + " </p>" +
                "</body> ";

            var mailService = new correo_recuperacion();
            mailService.sendMail(
            subject: " Fue vinculado al ticket numero  " + " " + n_ticket + " " + " ",
            body: bodys,
            recipientMail: new List<string> { correo }
            );

        }


        public void Notificar_cliente_creacion_ticket(string correo, string username, string n_ticket, string solicitud, string titu_ticket)
        {
            string bodys = solicitud;
            var mailService = new correo_recuperacion();

            mailService.sendMail(

                subject: "Su solicitud fue registrada con numero:  " + " " + n_ticket + " " + " " + titu_ticket + "",

                body: bodys,
                recipientMail: new List<string> { correo }
                );

        }


        public void Notificar_agente_creacion_ticket(string correo_agente, string username, string n_ticket, string solicitud, string titu_ticket, string n_cliente, string nom_empresa)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + username + "" + " Se ha creado y se le ha asignado el caso N:" + " " + n_ticket + "" + "" + "</h4>" +
                    "<p>" + solicitud + "</p>" +
                    "<p>" + " " + "</p>" +
                    "<p>" + " solicitado por el cliente  " + "  " + n_cliente + "   vinculado a la empresa  " + "  " + nom_empresa + "" + "</p>" +
                    "<p>" + " " + " </p>" +
                    "<p>" + " Se requiere de su gestion en el menor tiempo posible " + " </p>" +
                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(

                subject: "Solicitud registrada con numero:  " + " " + n_ticket + " " + " " + titu_ticket + "",

                body: bodys,
                recipientMail: new List<string> { correo_agente }
                );

        }


        public void Notificar_agente_creacion_nota(string correo_agente, string username, string n_ticket, string nota, string titu_ticket, string nom_empresa)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + username + "" + " Se ha generado una nota al ticket numero:" + " " + n_ticket + "" + "" + "</h4>" +
                    "<p>" + nota + "</p>" +
                    "<p>" + " " + "</p>" +

                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(

                subject: "Se registro una nota al ticket numero:" + "  " + n_ticket + " " + " " + titu_ticket + "",

                body: bodys,
                recipientMail: new List<string> { correo_agente }
                );

        }


        public void Notificar_cliente_creacion_nota(string correo_cliente, string cliente_name, string n_ticket, string nota, string titu_ticket, string nom_empresa)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + cliente_name + "" + " Se ha generado una nota de gestion al ticket numero:" + " " + n_ticket + "" + "" + "</h4>" +
                    "<p>" + nota + "</p>" +
                    "<p>" + " " + "</p>" +

                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(

                subject: "Se registro una nota al ticket numero:" + "  " + n_ticket + " " + " " + titu_ticket + "",

                body: bodys,
                recipientMail: new List<string> { correo_cliente }
                );

        }
        public void Notificar_usuario_asigna_ticket(string correo_cliente, string cliente_name, string n_ticket, string nota, string titu_ticket)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + cliente_name + "" + " Se le ha asignado el ticket numero:" + " " + n_ticket + "" + "" + "</h4>" +
                    "<p>" + "   " + "</p>" + "<p>" + nota + "</p>" +
                    "<p>" + " " + "</p>" +

                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(

                subject: "Se le ha asignado el ticket numero:" + "   " + n_ticket + " " + " " + titu_ticket + "",

                body: bodys,
                recipientMail: new List<string> { correo_cliente }
                );

        }

        public void Notificar_cliente_reasigan_creacion_nota(string correo_cliente, string cliente_name, string n_ticket, string nota, string titu_ticket, string nom_empresa)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + cliente_name + "" + " Se ha asignado como responsable del ticket numero:" + " " + n_ticket + "" + "" + "</h4>" +
                    "<p>" + "  " + "</p>" +
                    "<p>" + nota + "</p>" +
                    "<p>" + " " + "</p>" +
                    "<hr>" + " Seguira recibiendo notificaciones durante la gestión del ticket. " + "</hr>" +

                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(

                subject: "Se asigna el ticket  :" + "  " + n_ticket + " " + " " + titu_ticket + "",

                body: bodys,
                recipientMail: new List<string> { correo_cliente }
                );

        }



        public void Notificar_vencimienot_caso(string correo_consultor, string name_consultor, int n_ticket, string titu_ticket, string nom_empresa)
        {
            string bodys =
                "<body>" +
                    "<h4> " + "Señor(a) " + "" + name_consultor + "" + " el ticket numero:" + " " + n_ticket + "" + "" + "</h4>" +
                    "<p>" + " Con titulo " + "</p>" +
                    "<p>" + titu_ticket + "</p>" +
                    "<p>" + "Se encuentra vencido " + "</p>" +

                    "<hr>" + " Seguira recibiendo notificaciones durante la gestión del ticket. " + "</hr>" +

                "</body> ";
            var mailService = new correo_recuperacion();

            mailService.sendMail(

                subject: " Ticket Vencido N:" + "  " + n_ticket + " " + " " + titu_ticket + "",

                body: bodys,
                recipientMail: new List<string> { correo_consultor }
                );

        }

    }
}