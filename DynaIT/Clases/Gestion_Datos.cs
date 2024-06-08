using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DynaIT.Clases
{
    public class Gestion_Datos
    {

        //Atributos de conexion 
        //public MySqlConnection conexion;
        public string error;
        Visualizar_Tickets Visualizar_Tickets = new Visualizar_Tickets();
        static string conex = @"Integrated Security=True;Initial Catalog=DynaIT;Data Source=DESKTOP-L5T5BI3";
        SqlConnection conexion = new SqlConnection(conex);
        public Gestion_Datos()
        {
            this.conexion = Conexion_MySQL.getConexion();
        }


        //Realiza una insercion en la tabla insertar_Empresa 
        public Boolean insertar_Empresa(Clase_Parametros myTicket)
        {
            Boolean estado = false;
            try
            {

                string sql = " insert into empresa ( Nombre_Empresa, Nit, telefono_empresa, Representante_empresa ) " +
                    " values(@Nombre_Empresa, @Nit, @Telefono, @Representante_empresa)  ";
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@Nombre_Empresa", myTicket.Nombre_Empresa);
                cmd.Parameters.AddWithValue("@Nit", myTicket.Nit);
                cmd.Parameters.AddWithValue("@Telefono", myTicket.Telefono_Empresa);
                cmd.Parameters.AddWithValue("@Representante_empresa", myTicket.Representante_empresa);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }

        //Realiza una insercion en la tabla Usuario 
        public Boolean insertar_Usuario(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                //string sql = " insert into usuario ( nombre_usuario, correo_usu, rol_id, area_id, contrasena_usu, prefijo_usuario ) " +
                //    " values ( @Nombres, @Correo, @Rol_usuario, @area_idarea, @Contrasena, @Usuario  )";

                string patron = "Dynamics1", cliente_habilitado = "Si";
                SqlCommand cmd = new SqlCommand("Sp_pass_usu", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@nombre_usuario", myParametro.Nombre_Usuario);
                cmd.Parameters.AddWithValue("@correo_usu", myParametro.Correo_Usuario);
                cmd.Parameters.AddWithValue("@rol_id", myParametro.Rol_usuario);
                cmd.Parameters.AddWithValue("@area_id", myParametro.Tabla_Grupos_Usuario);
                cmd.Parameters.AddWithValue("@contrasena_usu", myParametro.Contraseña_Usuario);
                cmd.Parameters.AddWithValue("@prefijo_usuario", myParametro.Usuario);
                cmd.Parameters.AddWithValue("@usuario_Habilitado", cliente_habilitado);
                cmd.Parameters.AddWithValue("@Patron", patron);


                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }

        //Realiza una insercion en la tabla Ticket 
        public Boolean insertarNotas(Clase_Parametros myTicket)
        {
            Boolean estado = false;
            try
            {

                string sql = " INSERT INTO nota (descripcionNota, FechaNota, id_ticket, usuario_id_nota, cliente_id_nota, nota_interna, Adjuntos_nota, nota_usuario) " +
                    " VALUES(@descripcionNota, @FechaNota, @Ticket_idTicket, @usuario_id_nota, @cliente_id_nota, @nota_interna, @Adjuntos_nota, @nota_usuario) ";
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@descripcionNota", myTicket.descripcionNota);
                cmd.Parameters.AddWithValue("@FechaNota", myTicket.FechaNota);
                cmd.Parameters.AddWithValue("@Ticket_idTicket", myTicket.Ticket_idTicket_nota);

                cmd.Parameters.AddWithValue("@usuario_id_nota", myTicket.usuario_id_nota);
                cmd.Parameters.AddWithValue("@cliente_id_nota", myTicket.cliente_id_nota);
                cmd.Parameters.AddWithValue("@nota_interna", myTicket.nota_interna);
                cmd.Parameters.AddWithValue("@Adjuntos_nota", myTicket.Adjuntos_nota);
                cmd.Parameters.AddWithValue("@nota_usuario", myTicket.Nota_usuario);
                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }


        //Realiza una insercion en la TABLA ACTAS
        public Boolean inserta_Acta(Clase_Parametros myTicket)
        {
            Boolean estado = false;
            try
            {

                string sql = " INSERT INTO acta (Numero_Acta, Fecha_crea_acta, ticket_id, N_creditos_acta, fk_usuario_id) " +
                    " VALUES(@Numero_Acta, @Fecha_crea_acta, @ticket_idTicket, @N_creditos_acta, @fk_usuario_id) ";
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@Numero_Acta", myTicket.Numero_Acta);
                cmd.Parameters.AddWithValue("@Fecha_crea_acta", myTicket.Fecha_crea_acta);
                cmd.Parameters.AddWithValue("@ticket_idTicket", myTicket.ticket_idTicket);
                cmd.Parameters.AddWithValue("@N_creditos_acta", myTicket.N_creditos_acta);
                cmd.Parameters.AddWithValue("@N_credi_garantia_acta", myTicket.N_credi_garantia_acta);
                cmd.Parameters.AddWithValue("@fk_usuario_id", myTicket.fk_usuario_id);

                cmd.ExecuteNonQuery();
                estado = true;
            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }


        //Realiza una insercion en la tabla nota_compartida
        public Boolean insertar_nota_compartida(Clase_Parametros myTicket)
        {
            Boolean estado = false;
            try
            {

                string sql = " INSERT INTO notas_compartida_usuario (nota_id, usario_id) VALUES (@nota_idNota, @usario_idUsuario) ";
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@nota_idNota", myTicket.nota_idNota_compartida);
                cmd.Parameters.AddWithValue("@usario_idUsuario", myTicket.usuario_idUsuario_compartida);


                cmd.ExecuteNonQuery();

                estado = true;
            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }


        //Realiza la update en la tabla Usuario 
        public Boolean editar_Usuario(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string patron = "Dynamics1", usuario_habilitado = "Si";

                //string sql = (" UPDATE usuario SET nombre_usuario = @Nombres, " +
                //    " correo_usu = @Correo, rol_id = @Rol_usuario, prefijo_usuario = @Usuario, area_id = @area_idarea," +
                //    " contrasena_usu = @Contrasena WHERE id_usuario = @idUsuario ");
                SqlCommand cmd = new SqlCommand("Sp_update_usu", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id_usuario", myParametro.Id_usuario);
                cmd.Parameters.AddWithValue("@nombre_usuario", myParametro.Nombre_Usuario);
                cmd.Parameters.AddWithValue("@correo_usu", myParametro.Correo_Usuario);
                cmd.Parameters.AddWithValue("@rol_id", myParametro.Rol_usuario);
                cmd.Parameters.AddWithValue("@prefijo_usuario", myParametro.Prefijo_Usuario);
                cmd.Parameters.AddWithValue("@area_id", myParametro.fk_area_id_area);
                cmd.Parameters.AddWithValue("@contrasena_usu", myParametro.Contraseña_Usuario);
                cmd.Parameters.AddWithValue("@usuario_Habilitado", usuario_habilitado);
                cmd.Parameters.AddWithValue("@Patron", patron);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
            }
            return estado;

        }


        //Realiza la update en la tabla Usuario 
        public Boolean editar_Cliente(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                //string sql = (" UPDATE cliente SET nombre_cliente = @NombreCliente, correo_cli = @Correo, Telefono_cliente = @Telefono, rol_id = @Rol_Cliente, " +
                //    " Contrasena_cli = @Contraseña, empresa_id = @Id_Empresa " +
                //    " WHERE(id_Cliente = @idCliente) ");

                string patron = "Dynamics1", cliente_habilitado = "Si";
                SqlCommand cmd = new SqlCommand("Sp_update_cli", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id_Cliente", myParametro.Id_cliente);

                cmd.Parameters.AddWithValue("@nombre_cliente", myParametro.Nombre_Cliente);
                cmd.Parameters.AddWithValue("@correo_cli", myParametro.Correo_Cliente);
                cmd.Parameters.AddWithValue("@Telefono_cliente", myParametro.Telefono_Cliente);
                cmd.Parameters.AddWithValue("@rol_id", myParametro.Rol_Cliente);
                cmd.Parameters.AddWithValue("@Contrasena_cli", myParametro.Contraseña);
                cmd.Parameters.AddWithValue("@empresa_id", myParametro.Fk_Empresa);
                cmd.Parameters.AddWithValue("@Patron", patron);
                cmd.Parameters.AddWithValue("@Cliente_Habilitado", cliente_habilitado);


                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }

        //Realiza la update en la tabla cliente para el cambio de clave desde el perfil
        public Boolean Cambio_clave_Cli(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string patron = "Dynamics1";
                SqlCommand cmd = new SqlCommand("change_password_cli", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id_Cliente", myParametro.idCliente);
                cmd.Parameters.AddWithValue("@Contrasena_cli", myParametro.Contraseña);
                cmd.Parameters.AddWithValue("@Patron", patron);
                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }

        //Realiza la update en la tabla cliente para el cambio de clave desde el perfil
        public Boolean Recover_clave_Cli(string correo, string clave)
        {
            Boolean estado = false;
            try
            {
                string patron = "Dynamics1";
                SqlCommand cmd = new SqlCommand("recover_pass_cli", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@correo_cli", correo);
                cmd.Parameters.AddWithValue("@Contrasena_cli", clave);
                cmd.Parameters.AddWithValue("@Patron", patron);
                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }
        //Realiza la update en la tabla cliente para el cambio de clave desde el perfil
        public Boolean Cambio_clave_usu(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string patron = "Dynamics1";
                SqlCommand cmd = new SqlCommand("change_password_usu", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id_usuario", myParametro.Id_usuario);
                cmd.Parameters.AddWithValue("@contrasena_usu", myParametro.Contraseña_Usuario);
                cmd.Parameters.AddWithValue("@Patron", patron);
                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }

        //Realiza larecuperacion de la clave con el correo regsitrado para el usuario 
        public Boolean recover_clave_usu(string correo, string contraseña)
        {
            Boolean estado = false;
            try
            {
                string patron = "Dynamics1";
                SqlCommand cmd = new SqlCommand("recover_pass_usu", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@correo_usu", correo);
                cmd.Parameters.AddWithValue("@contrasena_usu", contraseña);
                cmd.Parameters.AddWithValue("@Patron", patron);
                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }


        //Realiza la update en la tabla ticket 
        public Boolean editar_ticket(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE ticket SET Usuario_id = @Usuario_idUsuario, estado_id = @estado_idEstadoticket, Fecha_inicio_proceso = @Fecha_inicio_proceso, " +
                    " creditos_desarrollo = creditos_desarrollo + @h_adicionales, Fecha_resuelto_ticket = @Fecha_resuelto_ticket, " +
                    " Fecha_cierre_ticket = @Fecha_cierre_ticket, Resumen_Problema = @Resumen_Problema, descripcion = @descripcion, " +
                    " Cliente_id = @Cliente_idCliente, creditos_garantia = creditos_garantia + @N_creditos_garantia WHERE id_ticket = @idTicket ");

                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idTicket", myParametro.No_ticket);

                cmd.Parameters.AddWithValue("@Usuario_idUsuario", myParametro.Fk_Id_Usuario);
                cmd.Parameters.AddWithValue("@estado_idEstadoticket", myParametro.Estado);
                cmd.Parameters.AddWithValue("@fecha_inicio_proceso", myParametro.Fecha_inicio_proceso);
                cmd.Parameters.AddWithValue("@h_adicionales", myParametro.h_adicionales);
                cmd.Parameters.AddWithValue("TiempoDesarrollo", myParametro.TiempoDesarrollo);
                cmd.Parameters.AddWithValue("@Fecha_resuelto_ticket", myParametro.Fecha_resuelto_ticket);
                cmd.Parameters.AddWithValue("@Fecha_cierre_ticket", myParametro.Fecha_cierre_ticket);
                cmd.Parameters.AddWithValue("@Resumen_Problema", myParametro.Resumen_Problema);
                cmd.Parameters.AddWithValue("@descripcion", myParametro.Descripcion);
                cmd.Parameters.AddWithValue("@Cliente_idCliente", myParametro.Cliente_idCliente);
                cmd.Parameters.AddWithValue("@N_creditos_garantia", myParametro.N_creditos_garantia);


                cmd.ExecuteNonQuery();

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
            }
            return estado;

        }



        public Boolean cerrar_ticket(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE ticket SET estado_id = 6 WHERE (id_ticket = @idTicket)  ");

                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idTicket", myParametro.No_ticket);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
            }
            return estado;

        }


        //Realiza una insercion en la tabla Cliente 
        public Boolean insertar_Cliente(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                //string sql = "insert into cliente ( nombre_cliente, correo_cli, Telefono_cliente, rol_id, Contrasena_cli, empresa_id) " +
                //    " values ( @NombreCliente, @Correo, @Telefono, @Rol_Cliente, @Contraseña, @Id_Empresa )";
                string Cliente_Habilitado = "Si", patron = "Dynamics1";
                SqlCommand cmd = new SqlCommand("Sp_pass_clien", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@nombre_cliente", myParametro.Nombre_Cliente);
                cmd.Parameters.AddWithValue("@correo_cli", myParametro.Correo_Cliente);
                cmd.Parameters.AddWithValue("@Telefono_cliente", myParametro.Telefono_Cliente);
                cmd.Parameters.AddWithValue("@rol_id", myParametro.Rol_Cliente);
                cmd.Parameters.AddWithValue("@Contrasena_cli", myParametro.Contraseña);
                cmd.Parameters.AddWithValue("@empresa_id", myParametro.Fk_Empresa);
                cmd.Parameters.AddWithValue("@Cliente_Habilitado", Cliente_Habilitado);
                cmd.Parameters.AddWithValue("@Patron", patron);

                cmd.ExecuteNonQuery();

                estado = true;
            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
                estado = false;
            }
            return estado;


        }

        //realiza insercion en la tabla estados ticket
        public Boolean Insertar_EstadosTicket(Clase_Parametros myParameters)
        {
            Boolean estado = false;
            try
            {
                string sql = " INSERT INTO estado_ticket (estado_Ticket) VALUES (@Estado_Ticket) ";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@Estado_Ticket", myParameters.Estados_tickets);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;
        }

        //Realiza una insercion en la tabla grupo Usuarios
        public Boolean Insertar_GruposUsuario(Clase_Parametros myParameters)
        {
            Boolean estado = false;
            try
            {
                string sql = " INSERT INTO area (area) VALUES (@area_usuario);";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@area_usuario", myParameters.Tabla_Grupos_Usuario);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;
        }
        //Realiza una insercion en la tabla grupo Usuarios
        public Boolean Insertar_Tipo_tickets(Clase_Parametros myParameters)
        {
            Boolean estado = false;
            try
            {
                string sql = " INSERT INTO tipo_ticket (tipo_Ticket, H_respuesta_tipo_ticket) VALUES(@tipo_Ticket, @Horas_respuesta) ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@tipo_Ticket", myParameters.tipos_tickets);
                cmd.Parameters.AddWithValue("@Horas_respuesta", myParameters.horas_respuesta_tipos_tickets);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;
        }


        //Realiza una insercion en la tabla Ticket 
        public Boolean insertar_Ticket(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string sql = " INSERT INTO ticket (Fecha, Resumen_Problema, Descripcion, prioridad_id, cliente_id, usuario_id, " +
                    " estado_id, tipo_ticket_id, fecha_vencimiento, ticket_Creado_por, Adjuntos_ticket, fecha_inicio_proceso) VALUES (@Fecha, @Resumen_Problema, @Descripcion, @Prioridad, @Cliente_idCliente, " +
                    " @Usuario_idUsuario, @estado_idEstadoticket, @Tipo_idTipoTcket, @tiempo_Respuesta, @Ticket_Creado_por, @Adjuntos_ticket, @Fecha_inicio_proceso ) ";
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@Fecha", myParametro.Fecha);
                cmd.Parameters.AddWithValue("@Tipo_idTipoTcket", myParametro.Tipo_ticket);
                cmd.Parameters.AddWithValue("@Resumen_Problema", myParametro.Resumen);
                cmd.Parameters.AddWithValue("@Descripcion", myParametro.Descripcion);
                cmd.Parameters.AddWithValue("@estado_idEstadoticket", myParametro.Estado);
                cmd.Parameters.AddWithValue("@Prioridad", myParametro.Prioridad);
                cmd.Parameters.AddWithValue("@tiempo_Respuesta", myParametro.tiempo_Respuesta);
                cmd.Parameters.AddWithValue("@Ticket_Creado_por", myParametro.Ticket_Creado_por);
                cmd.Parameters.AddWithValue("@Adjuntos_ticket", myParametro.Adjuntos_ticket);
                cmd.Parameters.AddWithValue("@Fecha_inicio_proceso", myParametro.Fecha_inicio_proceso);

                cmd.Parameters.AddWithValue("@Cliente_idCliente", myParametro.Id_cliente);
                cmd.Parameters.AddWithValue("@Usuario_idUsuario", myParametro.Fk_Id_Usuario);

                cmd.ExecuteNonQuery();
                estado = true;
            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
                estado = false;
            }
            return estado;
        }




        //  traer el listado de Todos los Tickets a la grilla por empresa
        public List<Visualizar_Tickets> listar_Tickets_por_empresa(string Id_Empresa)
        {
            string sql = "Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por, ticket.Fecha_cierre_ticket from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where cliente.empresa_id = @Id_Empresa order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(11);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todas las actas a la grilla por empresa
        public List<Visualizar_Tickets> listar_Actas_por_empresa(string Id_Empresa)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket, estado_ticket.estado_Ticket FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " where Id_Empresa = @Id_Empresa order by acta.id_acta desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.Fecha = registro.GetDateTime(11);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(12);
                myTicket.estado_ticket = registro.GetString(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todas las actas a la grilla por estado del ticket
        public List<Visualizar_Tickets> Listar_Actas_por_estado(string idEstado_Ticket)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where ticket.estado_id = @idEstado_Ticket order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todas las actas a la grilla por empresa y consulto
        public List<Visualizar_Tickets> listar_Actas_por_empresa_consultor(string Id_Empresa, string idUsuario)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where Id_Empresa = @Id_Empresa and usuario.id_usuario = @idUsuario order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todas las actas a la grilla por empresa y consulto
        public List<Visualizar_Tickets> listar_Actas_por_estado_consultor(string idEstadoticket, string idUsuario)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id  " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where ticket.estado_id = @idEstadoticket and usuario.id_usuario = @idUsuario order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idEstadoticket", idEstadoticket);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todas las actas a la grilla por fechas
        public List<Visualizar_Tickets> listar_Actas_por_fechas(DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket,   " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where Fecha_crea_acta between @Fecha_inicio and @Fecha_fin order by acta.id_acta desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todas las actas a la grilla por fechas y empresa
        public List<Visualizar_Tickets> listar_Actas_por_fechas_empresa(DateTime Fecha_inicio, DateTime Fecha_fin, string Id_Empresa)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id  " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where Id_Empresa = @Id_Empresa and Fecha_crea_acta between @Fecha_inicio and @Fecha_fin order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todas las actas a la grilla por fechas y empresa
        public List<Visualizar_Tickets> listar_Actas_por_fechas_estado(DateTime Fecha_inicio, DateTime Fecha_fin, string idEstadoticket)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where ticket.estado_id = @idEstadoticket and Fecha_crea_acta between @Fecha_inicio and @Fecha_fin order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            cmd.Parameters.AddWithValue("@idEstadoticket", idEstadoticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todas las actas a la grilla por fechas y consultor
        public List<Visualizar_Tickets> listar_Actas_por_fechas_consultor(DateTime Fecha_inicio, DateTime Fecha_fin, string idUsuario)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where usuario.id_usuario = @idUsuario and Fecha_crea_acta between @Fecha_inicio and @Fecha_fin order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todas las actas a la grilla por empresa consultor y estado
        public List<Visualizar_Tickets> listar_Actas_por_empresa_consultor_estado(string id_Empresas, string idUsuario, string idEstado_Ticket)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta  " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id  " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where id_Empresa = @id_Empresas and id_usuario = @idUsuario and id_Estado_Ticket = @idEstado_Ticket order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todas las actas a la grilla por fechas, empresa y consultor
        public List<Visualizar_Tickets> listar_Actas_por_fechas_empresa_consultor(DateTime Fecha_inicio, DateTime Fecha_fin, string idUsuario, string Id_Empresa)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket,  " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where Id_Empresa = @Id_Empresa and usuario.id_usuario = @idUsuario and Fecha_crea_acta between @Fecha_inicio and @Fecha_fin order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todas las actas a la grilla por fechas, empresa y estado
        public List<Visualizar_Tickets> listar_Actas_por_fechas_empresa_estado(DateTime Fecha_inicio, DateTime Fecha_fin, string Id_Empresa, string estado_idEstadoticket)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket,  " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where Id_Empresa = @Id_Empresa and id_Estado_Ticket = @estado_idEstadoticket and Fecha_crea_acta between @Fecha_inicio and @Fecha_fin order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            cmd.Parameters.AddWithValue("@estado_idEstadoticket", estado_idEstadoticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }




        //  traer el listado de Todas las actas a la grilla por consulto, estado y fechas
        public List<Visualizar_Tickets> Listar_Actas_por_consultor_estado_fechas(string idUsuario, string idEstado, DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where usuario.id_usuario = @idUsuario and estado_id = @estado_idEstadoticket and Fecha_crea_acta between @Fecha_inicio and @Fecha_fin order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@estado_idEstadoticket", idEstado);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todas las actas a la grilla por empresa y estado
        public List<Visualizar_Tickets> listar_Actas_por_empresa_estado(string Id_Empresa, string idEstado)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where Id_Empresa = @Id_Empresa and id_Estado_Ticket = @idEstado order by id_acta desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            cmd.Parameters.AddWithValue("@idEstado", idEstado);

            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todas las actas a la grilla por fechas, empresa, estado y consultor
        public List<Visualizar_Tickets> listar_Actas_por_fechas_empresa_consultor_estado(DateTime Fecha_inicio, DateTime Fecha_fin, string idUsuario, string Id_Empresa, string idEstado_Ticket)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket, " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_Ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id  " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket  " +
                " where Id_Empresa = @Id_Empresa and usuario.id_usuario = @idUsuario and Id_Empresa = @Id_Empresa and Fecha_crea_acta between @Fecha_inicio and @Fecha_fin and ticket.estado_id = @idEstado_Ticket order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
            cmd.Parameters.AddWithValue("@Fecha_fin", Fecha_fin);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todas actas a la grilla por empresa
        public List<Visualizar_Tickets> listar_Actas_por_consutor(string idUsuario)
        {
            string sql = " SELECT id_acta, Numero_Acta, ticket_id, Fecha_crea_acta, ticket.creditos_desarrollo, N_creditos_acta, ticket.Resumen_Problema, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.nombre_usuario, acta.Numero_Factura, estado_ticket.estado_Ticket,  " +
                " ticket.Fecha, ticket.Fecha_cierre_ticket " +
                " FROM acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on usuario.id_usuario = acta.fk_usuario_id " +
                " inner join estado_ticket on ticket.estado_id = estado_ticket.id_Estado_Ticket " +
                " where usuario.id_usuario = @idUsuario order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.id_acta = registro.GetInt32(0);
                myTicket.Numero_Acta = registro.GetString(1);
                myTicket.ticket_id = registro.GetInt32(2);
                myTicket.Fecha_crea_acta = registro.GetDateTime(3);
                myTicket.TiempoDesarrollo = registro.GetInt32(4);
                myTicket.N_creditos_acta = registro.GetInt32(5);
                myTicket.Resumen_Problema = registro.GetString(6);
                myTicket.nombre_empresa = registro.GetString(7);
                myTicket.Representante_empresa = registro.GetString(8);
                myTicket.Nombres = registro.GetString(9);
                myTicket.Numero_Factura = registro.GetString(10);
                myTicket.estado_ticket = registro.GetString(11);
                myTicket.Fecha = registro.GetDateTime(12);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(13);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets a la grilla por empresa y cliente de la empresa
        public List<Visualizar_Tickets> listar_Tickets_por_empresa_cliente(string Id_Empresa, string Cliente_idCliente)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.nombre_empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id  " +
                " where cliente.empresa_id = @Id_Empresa and Cliente_id = @Cliente_idCliente order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            cmd.Parameters.AddWithValue("@Cliente_idCliente", Cliente_idCliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets a la grilla por empresa, estado del ticket y cliente de la empresa
        public List<Visualizar_Tickets> listar_Tickets_por_empresa_cliente_estado(string Id_Empresa, string Cliente_idCliente, string estado_idEstadoticket)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion," +
                " prioridad.Prioridad, empresa.nombre_empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id  " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id  " +
                " where cliente.empresa_id = @Id_Empresa and Cliente_id = @Cliente_idCliente and estado_id = @estado_idEstadoticket " +
                " order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            cmd.Parameters.AddWithValue("@Cliente_idCliente", Cliente_idCliente);
            cmd.Parameters.AddWithValue("@estado_idEstadoticket", estado_idEstadoticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets a la grilla por empresa y por el agenteal que se asigne
        public List<Visualizar_Tickets> listar_Tickets_por_empresa_agente(string Usuario_idUsuario, string Id_Empresa)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where Usuario_id = @Usuario_idUsuario and cliente.empresa_id = @Id_Empresa order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets a la grilla por cliente y por el agente al que se asigne el ticket
        public List<Visualizar_Tickets> listar_Tickets_por_cliente_agente(string Usuario_idUsuario, string Cliente_idCliente)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where Usuario_id = @Usuario_idUsuario and ticket.Cliente_id = @Cliente_idCliente order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@Cliente_idCliente", Cliente_idCliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets a la grilla por estado y por el agente logeado
        public List<Visualizar_Tickets> listar_Tickets_por_estado_agente(string Usuario_idUsuario, string estado_idEstadoticket)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por, ticket.fecha_vencimiento " +
                " from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where Usuario_id = @Usuario_idUsuario and estado_id = @estado_idEstadoticket order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@estado_idEstadoticket", estado_idEstadoticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.tiempo_Respuesta = registro.GetDateTime(11);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets a la grilla por id de cliente
        public List<Visualizar_Tickets> listar_Tickets_por_Cliente(string idCliente)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where cliente.id_Cliente = @idCliente order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets a la grilla por id de cliente y empresa
        public List<Visualizar_Tickets> listar_Tickets_Cliente_empresa(string idCliente, string id_Empresas)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where cliente.id_Cliente = @idCliente AND id_empresa = @id_Empresas order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }




        //  traer el listado de Todos los Tickets a la grilla por el estado en que se encuentra el estado
        public List<Visualizar_Tickets> listar_Tickets_por_Estado(string estado_idEstadoticket)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por, ticket.fecha_vencimiento " +
                " from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where ticket.estado_id = @estado_idEstadoticket order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@estado_idEstadoticket", estado_idEstadoticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.tiempo_Respuesta = registro.GetDateTime(11);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }




        //  traer el listado de Todos los Tickets a la grilla por el estado seleccionado y una empresa seleccionada
        public List<Visualizar_Tickets> listar_Tickets_por_Estado_empresa(string idEstado_Ticket, string id_Empresas)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where estado_ticket.id_Estado_Ticket = @idEstado_Ticket and empresa.id_empresa = @id_Empresas order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets a la grilla por el estado seleccionado y una empresa seleccionada
        public List<Visualizar_Tickets> listar_Tickets_sin_asignar(string Usuario_idUsuario)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where usuario_id = @Usuario_idUsuario order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets a la grilla por el estado seleccionado y una empresa seleccionada y el agente logeado
        public List<Visualizar_Tickets> listar_Tickets_por_Estado_empresa_agente(string Usuario_idUsuario, string idEstado_Ticket, string id_Empresas)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where Usuario_id = @Usuario_idUsuario and estado_ticket.id_Estado_Ticket= @idEstado_Ticket and empresa.id_Empresa = @id_Empresas order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets a la grilla por empresa seleccionado, un cliente y el agente logeado
        public List<Visualizar_Tickets> listar_Tickets_por_empresa_cliente_agente(string Usuario_idUsuario, string id_cliente, string id_Empresas)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where Usuario_id = @Usuario_idUsuario and ticket.Cliente_id = @Cliente_idCliente and empresa.id_Empresa = @id_Empresas order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);
            cmd.Parameters.AddWithValue("@Cliente_idCliente", id_cliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets a la grilla por estadpo seleccionado, un cliente y el agente logeado
        public List<Visualizar_Tickets> listar_Tickets_por_cliente_estado_agente(string Usuario_idUsuario, string id_cliente, string id_estado)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where Usuario_id = @Usuario_idUsuario and ticket.Cliente_id = @Cliente_idCliente and ticket.estado_id = @id_estado order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@id_estado", id_estado);
            cmd.Parameters.AddWithValue("@Cliente_idCliente", id_cliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets a la grilla por el estado seleccionado, una empresa seleccionada, un cliente  y el agente logeado
        public List<Visualizar_Tickets> listar_Tickets_por_Estado_empresa_cliente_agente(string Usuario_idUsuario, string idEstado_Ticket, string id_Empresas, string Cliente_idCliente)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where Usuario_id = @Usuario_idUsuario and estado_ticket.id_Estado_Ticket = @idEstado_Ticket and empresa.id_Empresa = @id_Empresas and ticket.Cliente_id = @Cliente_idCliente order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            cmd.Parameters.AddWithValue("@Cliente_idCliente", Cliente_idCliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets a la grilla por el estado seleccionado y una cliente seleccionada
        public List<Visualizar_Tickets> listar_Tickets_por_Estado_cliente(string idEstado_Ticket, string idCliente)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where estado_ticket.id_Estado_Ticket = @idEstado_Ticket and cliente.id_Cliente = @idCliente order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets a la grilla por el estado seleccionado y una cliente seleccionada
        public List<Visualizar_Tickets> listar_Tickets_por_empresa_Estado_cliente(string idEstado_Ticket, string idCliente, string id_Empresas)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, Ticket_Creado_por, ticket.fecha_vencimiento " +
                " from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where estado_ticket.id_Estado_Ticket = @idEstado_Ticket and cliente.id_Cliente = @idCliente and empresa.id_Empresa = @id_Empresas order by id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", idEstado_Ticket);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.tiempo_Respuesta = registro.GetDateTime(11);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //traer la lista de notas de un ticket para el clientes sin que muestre las notas internas
        public List<Visualizar_Tickets> traer_notas_cliente(string Ticket_idTicket)
        {
            string sql = " SELECT id_nota, FechaNota, descripcionNota, usuario_id_nota, cliente_id_nota, nota_interna, Adjuntos_nota " +
                " FROM nota where id_ticket = @Ticket_idTicket and nota_interna = 'No' and Notas_Habilitado = 'Si' ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Ticket_idTicket", Ticket_idTicket);
            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets visualizar = new Visualizar_Tickets();

                visualizar.idnotas = registro.GetInt32(0);
                visualizar.FechaNota = registro.GetDateTime(1);
                visualizar.descripcionNota = registro.GetString(2);
                visualizar.usuario_id_nota = registro.GetInt32(3);
                visualizar.cliente_id_nota = registro.GetInt32(4);
                visualizar.nota_interna = registro.GetString(5);
                visualizar.Adjuntos_nota = registro.GetString(6);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(visualizar);
            }
            registro.Close();
            return Visualizar_Tickets;

        }




        //traer la lista de notas de un ticket para el usuario 
        public List<Visualizar_Tickets> traer_notas_usuarios(string Ticket_idTicket)
        {
            string sql = " SELECT id_nota, FechaNota, descripcionNota, usuario_id_nota, cliente_id_nota, nota_interna, Adjuntos_nota  " +
                " FROM nota where id_ticket = @Ticket_idTicket and Notas_Habilitado = 'Si'  ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Ticket_idTicket", Ticket_idTicket);
            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets visualizar = new Visualizar_Tickets();

                visualizar.idnotas = registro.GetInt32(0);
                visualizar.FechaNota = registro.GetDateTime(1);
                visualizar.descripcionNota = registro.GetString(2);
                visualizar.usuario_id_nota = registro.GetInt32(3);
                visualizar.cliente_id_nota = registro.GetInt32(4);
                visualizar.nota_interna = registro.GetString(5);
                visualizar.Adjuntos_nota = registro.GetString(6);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(visualizar);
            }
            registro.Close();
            return Visualizar_Tickets;

        }

        //traer la lista de notas de un ticket que fueron asociadas a otro agente
        public List<Visualizar_Tickets> traer_notas_asociadas(int Ticket_idTicket, int usario_idUsuario)
        {
            string sql = " SELECT DISTINCT idnotas, nota_creada_por, FechaNota,  descripcionNota, nota_interna, Adjuntos_nota FROM notas  " +
                " inner join notas_compartida_usuario on notas_compartida_usuario.nota_idNota = notas.idnotas " +
                " WHERE Ticket_idTicket = @Ticket_idTicket and notas_compartida_usuario.usario_idUsuario = @usario_idUsuario " +
                " and notas.Notas_Habilitado = 'Si' order by notas.idnotas desc ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Ticket_idTicket", Ticket_idTicket);
            cmd.Parameters.AddWithValue("@usario_idUsuario", usario_idUsuario);
            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets visualizar = new Visualizar_Tickets();

                visualizar.idnotas = registro.GetInt32(0);
                visualizar.nota_creada_por = registro.GetInt32(1);
                visualizar.FechaNota = registro.GetDateTime(2);
                visualizar.descripcionNota = registro.GetString(3);
                visualizar.nota_interna = registro.GetString(4);
                visualizar.Adjuntos_nota = registro.GetString(5);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(visualizar);
            }
            registro.Close();
            return Visualizar_Tickets;

        }

        //traer la lista de clientes de una empresa
        public List<Visualizar_Tickets> traer_clientes_empresa(string Cliente_Habilitado, int Id_Empresa)
        {
            string sql = " SELECT cliente.id_Cliente, cliente.nombre_cliente, cliente.Telefono_cliente, cliente.correo_cli, " +
                " rol.rol, empresa.Nombre_Empresa FROM cliente " +
                " INNER JOIN empresa ON cliente.empresa_id = empresa.id_empresa " +
                " inner join rol on rol.id_rol = cliente.rol_id " +
                "  WHERE(cliente.Cliente_Habilitado = @Cliente_Habilitado AND empresa.id_Empresa = @Id_Empresa) order by cliente.id_Cliente desc ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Cliente_Habilitado", Cliente_Habilitado);
            cmd.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets visualizar = new Visualizar_Tickets();

                visualizar.id_Cliente = registro.GetInt32(0);
                visualizar.Nombre_Cliente = registro.GetString(1);
                visualizar.Telefono_cliente = registro.GetString(2);
                visualizar.correo_cli = registro.GetString(3);
                visualizar.rol = registro.GetString(4);
                visualizar.nombre_empresa = registro.GetString(5);



                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(visualizar);
            }
            registro.Close();
            return Visualizar_Tickets;

        }


        //  traer el listado de Todos los Tickets a la grilla
        public List<Visualizar_Tickets> listar_Todos_Tickets()
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, ticket.Ticket_Creado_por, ticket.creditos_desarrollo, ticket.Fecha_cierre_ticket, ticket.Numero_Dias, ticket.fecha_vencimiento " +
                " from ticket " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " inner join cliente on cliente.id_Cliente = ticket.cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id where ticket_Habilitado='Si' order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.TiempoDesarrollo = registro.GetInt32(11);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(12);
                myTicket.Numero_Dias = registro.GetInt32(13);
                myTicket.tiempo_Respuesta = registro.GetDateTime(14);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets a la grilla
        public List<Visualizar_Tickets> tickets_vencidos(DateTime fecha_actual)
        {
            string sql = " SELECT id_ticket, fecha_vencimiento FROM ticket " +
                " where fecha_vencimiento <= @fecha_vencimiento and estado_id = 2 or estado_id = 3 ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@fecha_vencimiento", fecha_actual);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.Fecha_vencimiento = registro.GetDateTime(1);

                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        public List<Tickets_con_notas> tickets_con_notas()
        {
            string sql = " select ticket.id_ticket, isnull((select max(id_nota)as ultima_nota from nota where nota.id_ticket = ticket.id_ticket group by id_ticket),0)as n_ultim_nota from ticket ";

            List<Tickets_con_notas> Ticket_con_notas = new List<Tickets_con_notas>();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Tickets_con_notas myTicket = new Tickets_con_notas();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.N_ultima_nota = registro.GetInt32(1);

                Ticket_con_notas.Add(myTicket);
            }
            registro.Close();
            return Ticket_con_notas;
        }

        //Se deshabilita ticket que fue fusionado a otro
        public Boolean Eliminar_id_fusionado(string id_ticket)
        {
            Boolean estado = false;
            try
            {
                string sql = (" update ticket set ticket_Habilitado = 'No' where id_ticket = @id_ticket ");
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@id_ticket", id_ticket);


                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }


        //  traer el listado de Todos los Tickets asignados al usuario logeado
        public List<Visualizar_Tickets> listar_Todos_Tickets_usuario(int idUsuario)
        {
            string sql = " Select  ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.nombre_empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_Ticket, ticket.Ticket_Creado_por, ticket.creditos_desarrollo, ticket.fecha_cierre_ticket, ticket.numero_Dias, ticket.fecha_vencimiento " +
                " from ticket " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " inner join cliente on cliente.id_Cliente = ticket.cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id where usuario_id = @idUsuario and ticket_Habilitado= 'Si' order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.TiempoDesarrollo = registro.GetInt32(11);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(12);
                myTicket.Numero_Dias = registro.GetInt32(13);
                myTicket.tiempo_Respuesta = registro.GetDateTime(14);




                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets compartidos al usuario logeado
        public List<Visualizar_Tickets> listar_Todos_Tickets_compartidos(string idUsuario)
        {
            string sql = " Select DISTINCT ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.nombre_empresa, cliente.nombre_cliente, usuario.nombre_usuario, estado_ticket.estado_ticket, " +
                " ticket.Ticket_Creado_por, ticket.creditos_desarrollo, ticket.Fecha_cierre_ticket, ticket.Numero_Dias " +
                " from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id " +
                " inner join nota on nota.id_ticket = ticket.id_Ticket " +
                " inner join notas_compartida_usuario on notas_compartida_usuario.nota_id = nota.id_nota " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " where notas_compartida_usuario.usario_id = @idUsuario order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.TiempoDesarrollo = registro.GetInt32(11);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(12);
                myTicket.Numero_Dias = registro.GetInt32(13);



                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets creados al cliente logeado
        public List<Visualizar_Tickets> listar_Todos_Tickets_cliente(string Cliente_idCliente)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, ticket.Ticket_Creado_por, ticket.Fecha_cierre_ticket from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id where cliente_id = @Cliente_idCliente order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Cliente_idCliente", Cliente_idCliente);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(11);


                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets a la grilla creados por el egente logeado
        public List<Visualizar_Tickets> listar_Todos_Tickets_creados_usuario(string Ticket_Creado_por)
        {
            string sql = "  Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion," +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, ticket.Ticket_Creado_por, ticket.Fecha_cierre_ticket from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " inner join usuario on Usuario.id_usuario = ticket.usuario_id  " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id where Ticket_Creado_por = @Ticket_Creado_por and ticket_Habilitado= 'Si' order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Ticket_Creado_por", Ticket_Creado_por);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);
                myTicket.Fecha_cierre_ticket = registro.GetDateTime(11);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }



        //  traer el listado de Todos los Tickets creados y asignados al agente logeado
        public List<Visualizar_Tickets> Todos_Tickets_creados_asignados_agente(string Usuario_idUsuario, string Ticket_Creado_por)
        {
            string sql = " Select ticket.id_ticket, tipo_ticket.tipo_Ticket, ticket.Fecha, ticket.Resumen_Problema, ticket.Descripcion, " +
                " prioridad.Prioridad, empresa.Nombre_Empresa, cliente.nombre_cliente, usuario.nombre_usuario, " +
                " estado_ticket.estado_ticket, ticket.Ticket_Creado_por from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.Cliente_id " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id  " +
                " inner join usuario on Usuario.id_usuario = ticket.usuario_id  " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join prioridad on prioridad.id_prioridad = ticket.prioridad_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id where Usuario_id = @Usuario_idUsuario  or Ticket_Creado_por = @Ticket_Creado_por order by ticket.id_ticket desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Usuario_idUsuario", Usuario_idUsuario);
            cmd.Parameters.AddWithValue("@Ticket_Creado_por", Ticket_Creado_por);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.N_Ticket = registro.GetInt32(0);
                myTicket.tipo_ticket = registro.GetString(1);
                myTicket.Fecha_creacion = registro.GetDateTime(2);
                myTicket.Resumen_Problema = registro.GetString(3);
                myTicket.Descripcion = registro.GetString(4);
                myTicket.Tlp_prioridad = registro.GetString(5);
                myTicket.nombre_empresa = registro.GetString(6);
                myTicket.Nombre_Cliente = registro.GetString(7);
                myTicket.Nombre_usuario = registro.GetString(8);
                myTicket.estado_ticket = registro.GetString(9);
                myTicket.Ticket_Creado_por = registro.GetString(10);

                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }






        //------------------------------------
        //  traer datos de empresa para comparar
        public Clase_Parametros listar_Empresa(string Nombre_Empresa, string Nit)
        {
            string sql = "SELECT id_empresa, nombre_empresa, nit FROM empresa " +
                " where Nombre_Empresa = @Nombre_Empresa and Nit = @Nit";

            SqlCommand cmd = new SqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@Nombre_Empresa", Nombre_Empresa);
            cmd.Parameters.AddWithValue("@Nit", Nit);

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {           // por cada registro creo un objeto empresa
                Clase_Parametros myTicket = new Clase_Parametros();

                myTicket.id_Empresa = registro.GetInt32(0);
                myTicket.Empresa = registro.GetString(1);
                myTicket.Nit = registro.GetString(2);

                // Agrego el objeto parametro creado a la lista
                registro.Close();
                return myTicket;

            }
            else
            {

                registro.Close();
                return null;
            }
        }





        //traer el id de la empresa consultado para identificar a que campo o celda actualizar en la columna @nombreEmpresa de la tabla Empresas
        public Clase_Parametros traerID_Empresa(string Nombre_Empresa)

        {
            string sql = "SELECT id_empresa FROM empresa " +
                         " where nombre_empresa = @Nombre_Elemento ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Nombre_Elemento", Nombre_Empresa);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Fk_Empresa = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer el id de la empresa a la que pertenece un cliente para validar si esta habilitaa la empresa
        public Clase_Parametros traerID_Empresa_con_idCliente(int idCliente)

        {
            string sql = " SELECT empresa_id FROM cliente where id_Cliente = @idCliente ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Fk_Empresa = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }




        //traer el nombre de la empresa consultado para mostrar en la ventana emergente 
        public Clase_Parametros traer_nombre_Empresa(int id_Empresas)

        {
            string sql = "SELECT nombre_empresa FROM empresa " +
                         " where id_empresa = @id_Empresas ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_Empresas", id_Empresas);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Nombre_Empresa = registro.GetString(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }

        //traer el nombre del cliente consultado para mostrar en la ventana emergente de la lista de tickets
        public Clase_Parametros traer_nombre_Cliente(string idCliente)

        {
            string sql = "SELECT nombre_cliente FROM cliente " +
                         " where id_Cliente = @id_Cliente ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_Cliente", idCliente);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Nombre_Cliente = registro.GetString(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }




        //traer el numero de empresas repetidas con el mismo nit y nombre
        public Clase_Parametros traer_Empresa_repetidas(string Nombre_Empresa, string Nit)

        {
            string sql = " SELECT count(*) FROM empresa " +
                " where nombre_empresa = @nombre_empresa and nit = @Nit ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre_empresa", Nombre_Empresa);
            cmd.Parameters.AddWithValue("@Nit", Nit);

            SqlDataReader registro = cmd.ExecuteReader();


            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Contador_empresas = registro.GetString(0);

                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer el numero de empresas repetidas con el mismo nit y nombre
        public Clase_Parametros traer_Empresa(int id_Empresas)

        {
            string sql = " SELECT nombre_empresa, nit, telefono_empresa, representante_empresa FROM empresa " +
                " where id_empresa = @id_empresa ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_empresa", id_Empresas);

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Nombre_Empresa = registro.GetString(0);
                myParametro.Nit = registro.GetString(1);
                myParametro.Telefono_Empresa = registro.GetString(2);
                myParametro.Representante_empresa = registro.GetString(3);

                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer el id de la empresa consultado para identificar a que campo o celda actualizar en la columna @nombreEmpresa de la tabla Empresas
        public Clase_Parametros cargar_id_grupos(string nombreArea)

        {
            string sql = "SELECT id_area FROM area where area = @area";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@area", nombreArea);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Ta_id_area = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }



        //traer el id de la empresa consultado para identificar a que campo o celda actualizar en la columna @nombreEmpresa de la tabla Empresas
        public Clase_Parametros cargar_id_Tipos_tickes(string tipo_Ticket)

        {
            string sql = "SELECT id_tipo_Ticket FROM tipo_ticket where tipo_Ticket = @tipo_Ticket";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@tipo_Ticket", tipo_Ticket);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.id_tipos_tickets = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }




        //traer las horas de la tabla tipo ticket que se tiene para dar respuesta
        public Clase_Parametros cargar_horas_Tipos_tickes(string idtipo_Ticket)

        {
            string sql = " select H_respuesta_tipo_ticket from tipo_ticket where id_tipo_Ticket = @idtipo_Ticket";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idtipo_Ticket", idtipo_Ticket);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Tttipo_Horas_respuesta = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }

        //traer las horas de la tabla tipo ticket que se tiene para dar respuesta
        public Clase_Parametros cargar_horas_Prioridad(int id_prioridad)

        {
            string sql = " select H_respuesta_prioridad from prioridad where id_prioridad = @id_prioridad ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_prioridad", id_prioridad);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Tprioridad_Horas_respuesta = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }



        //traer la foranea del cliente consultado para identificar a que cliente va el ticket generado
        public Clase_Parametros traer_Cliente(string NombreCliente)

        {
            string sql = "SELECT * FROM cliente where nombre_cliente = @NombreCliente ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@NombreCliente", NombreCliente);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Id_cliente = registro.GetString(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer los clientes que pertenescan a una empresa 
        public Clase_Parametros traer_Cliente_por_empresa(string Id_Empresa)

        {
            string sql = " SELECT id_Cliente, nombre_cliente FROM cliente where empresa_id = @Id_Empresa";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id_Empresa", @Id_Empresa);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Id_cliente = registro.GetString(0);
                myParametro.Nombre_Cliente = registro.GetString(1);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }





        //traer la foranea del Usuario consultado para identificar que Ususario va el ticket generado
        public Clase_Parametros traer_Usuario(string idUsuario)

        {
            string sql = " SELECT * FROM usuario where id_usuario = @idUsuario ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Fk_Id_Usuario = registro.GetInt32(0);
                myParametro.Nombre_Usuario = registro.GetString(1);
                myParametro.Correo_Usuario = registro.GetString(2);

                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }




        //traer la la información del usuario a las texbox para la edicion de usuario
        public Clase_Parametros traer_Usuario_editar(string idUsuario)

        {
            string sql = " SELECT usuario.nombre_usuario, usuario.correo_usu, usuario.rol_id, " +
                " usuario.area_id, usuario.prefijo_usuario FROM usuario INNER JOIN area ON usuario.area_id = Area.id_area " +
                " where id_usuario = @idUsuario ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Nombre_Usuario = registro.GetString(0);
                myParametro.Correo_Usuario = registro.GetString(1);
                myParametro.Rol_usuario = registro.GetInt32(2);
                myParametro.fk_area_id_area = registro.GetInt32(3);
                myParametro.Prefijo_Usuario = registro.GetString(4);




                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }



        //traer la la información del cliente a las texbox para la edicion de cliente
        public Clase_Parametros traer_Cliente_editar(string idCliente)

        {
            string sql = " SELECT empresa.id_Empresa, cliente.nombre_cliente, cliente.correo_cli,cliente.Telefono_cliente, cliente.Contrasena_cli, cliente.rol_id  " +
                " FROM cliente " +
                " INNER JOIN empresa ON cliente.empresa_id = empresa.id_Empresa where id_Cliente = @idCliente ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Fk_Empresa = registro.GetInt32(0);
                myParametro.Nombre_Cliente = registro.GetString(1);
                myParametro.Correo_Cliente = registro.GetString(2);
                myParametro.Telefono_Cliente = registro.GetString(3);
                myParametro.Contraseña = registro.GetString(4);
                myParametro.Rol_Cliente = registro.GetInt32(5);



                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }



        //trae el correo del cliente al textbox en el formulario GenerarTicket.aspx
        public Clase_Parametros traer_Correo(string idCliente)

        {
            string sql = " SELECT correo_cli FROM cliente where id_Cliente = @idCliente ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Correo_Cliente = registro.GetString(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer los nombres de cliente despues de que seleccione en una empresa
        public Clase_Parametros traer_NombreCliente(string Nombre_Empresa)

        {
            string sql = "SELECT nombre_cliente FROM empresa " +
                " inner join cliente on cliente.empresa_id = empresa.id_empresa " +
                " where nombre_empresa = @Nombre_Elemento ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Nombre_Elemento", Nombre_Empresa);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Fk_Empresa = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }
        //traer un Cliente al formulario CreateTicket.apsx mediente una busqueda por filtro por "@id_Cliente"
        public Clase_Parametros Traer_datosCliente(string idCliente)
        {
            string sql = " SELECT nombre_cliente, Nombre_Empresa, correo_cli FROM cliente " +
                " inner join empresa on cliente.empresa_id = empresa.id_empresa " +
                " where cliente.id_Cliente = @idCliente ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myTicket = new Clase_Parametros();

                myTicket.Nombre = registro.GetString(0);
                myTicket.Empresa = registro.GetString(1);
                myTicket.Correo = registro.GetString(2);




                registro.Close();
                return myTicket;
            }
            else
            {
                registro.Close();
                return null;
            }
        }




        //traer el tipo ticket para compararlo en la edicion o actualizacion de los tipos de tickets"
        public Clase_Parametros Traer__id_Tipo_Ticket(string codigo)
        {
            string sql = "SELECT * FROM tipo_ticket where id_tipo_Ticket = @idtipo_Ticket";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idtipo_Ticket", codigo);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myTicket = new Clase_Parametros();

                myTicket.tipos_tickets = registro.GetString(1);
                myTicket.horas_respuesta_tipos_tickets = registro.GetInt32(3);

                registro.Close();
                return myTicket;
            }
            else
            {
                registro.Close();
                return null;
            }
        }

        //Realiza edicion en la tabla tipo tickets
        public Boolean Actualizar_Tipo_Ticket(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE tipo_ticket SET tipo_Ticket = @tipo_Ticket, Horas_respuesta = @Horas_respuesta WHERE (idtipo_Ticket = @idtipo_Ticket) ");
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idtipo_Ticket", myParametro.id_tipos_tickets);
                cmd.Parameters.AddWithValue("@tipo_Ticket", myParametro.tipos_tickets);
                cmd.Parameters.AddWithValue("@Horas_respuesta", myParametro.horas_respuesta_tipos_tickets);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }

        //traer el estado ticket para compararlo en la edicion o actualizacion de los estados del ticket"
        public Clase_Parametros Traer__id_estados_grupo(string codigo)
        {
            string sql = "SELECT * FROM estado_ticket where id_Estado_Ticket = @idEstado_Ticket";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idEstado_Ticket", codigo);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myTicket = new Clase_Parametros();


                myTicket.Id_Estados_tickets = registro.GetInt32(0);
                myTicket.Estados_tickets = registro.GetString(1);

                registro.Close();
                return myTicket;
            }
            else
            {
                registro.Close();
                return null;
            }
        }

        //traer la foranea del cliente consultado para identificar a que cliente va el ticket generado
        public Clase_Parametros Traer_Todos_Clientes()

        {
            string sql = " SELECT * FROM cliente  ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Nombre_Cliente = registro.GetString(1);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }






        //Realiza edicion en la tabla tipo tickets
        public Boolean Actualizar_Estados_ticket(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE estado_ticket SET estado_Ticket = @estado_Ticket WHERE(id_Estado_Ticket = @idEstado_Ticket)");

                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idEstado_Ticket", myParametro.Id_Estados_tickets);
                cmd.Parameters.AddWithValue("@estado_Ticket", myParametro.Estados_tickets);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }

        //traer el grupo de usuario a compararlo en la edicion o actualizacion de los grupos de usuario"
        public Clase_Parametros Traer__id_Grupos_Usuario(string codigo)
        {
            string sql = " SELECT * FROM area where id_area = @id_area_usuario ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id_area_usuario", codigo);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myTicket = new Clase_Parametros();

                myTicket.Tabla_Grupos_Usuario = registro.GetString(1);

                registro.Close();
                return myTicket;
            }
            else
            {
                registro.Close();
                return null;
            }
        }



        //Realiza edicion en la tabla tipo tickets
        public Boolean Actualizar_Grupos_Usuario(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string sql = (" UPDATE area SET area = @area_usuario WHERE (id_area = @id_area_usuario )");

                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@id_area_usuario", myParametro.Ta_id_area);
                cmd.Parameters.AddWithValue("@area_usuario", myParametro.Tabla_Grupos_Usuario);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }




        //Realiza edicion en la tabla grupos de usuario para habilitar el grupo
        public Boolean Actualizar_Grupos_Habilitado(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE area SET area = @area_usuario, area_Habilitado = @area_Habilitado WHERE (id_area = @id_area_usuario )");

                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@id_area_usuario", myParametro.Ta_id_area);
                cmd.Parameters.AddWithValue("@area_usuario", myParametro.Tabla_Grupos_Usuario);
                cmd.Parameters.AddWithValue("@area_Habilitado", myParametro.Tabla_Grupos_Habilitado);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }




        //Realiza edicion en la tabla clientes para habilitar
        public Boolean Actualizar_Cliente_Habilitado(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                //string sql = (" UPDATE cliente SET Cliente_Habilitado = @Cliente_Habilitado WHERE (id_Cliente = @idCliente) ");
                //SqlCommand cmd = new SqlCommand(sql, conexion);

                string patron = "Dynamics1";
                SqlCommand cmd = new SqlCommand("Sp_update_cli", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id_Cliente", myParametro.Id_cliente);
                cmd.Parameters.AddWithValue("@nombre_cliente", myParametro.Nombre_Cliente);
                cmd.Parameters.AddWithValue("@correo_cli", myParametro.Correo_Cliente);
                cmd.Parameters.AddWithValue("@Telefono_cliente", myParametro.Telefono_Cliente);
                cmd.Parameters.AddWithValue("@rol_id", myParametro.Rol_Cliente);
                cmd.Parameters.AddWithValue("@empresa_id", myParametro.Fk_Empresa);
                cmd.Parameters.AddWithValue("@Contrasena_cli", myParametro.Contraseña);
                cmd.Parameters.AddWithValue("@Cliente_Habilitado", myParametro.cliente_habilitado);
                cmd.Parameters.AddWithValue("@Patron", patron);

                cmd.ExecuteNonQuery();
                estado = true;
            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }


        //Realiza edicion en la tabla notas para habilitar la eliminación
        public Boolean Eliminar_nota(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string sql = (" UPDATE nota SET Notas_Habilitado = 'No' WHERE (id_nota = @idnotas) ");
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idnotas", myParametro.id_notas);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
            }
            return estado;
        }

        //Realiza edicion en la tabla notas para cambiar la nota de ID
        public Boolean fusionar_nota(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string sql = (" UPDATE nota SET id_ticket = @id_ticket, descripcionNota = CONCAT(@descripcionNota, descripcionNota) WHERE (id_nota = @id_nota) ");
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@id_nota", myParametro.id_notas);
                cmd.Parameters.AddWithValue("@descripcionNota", myParametro.descripcionNota);
                cmd.Parameters.AddWithValue("@id_ticket", myParametro.Ticket_idTicket_nota);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                this.error = exception.Message;
            }
            return estado;
        }


        //Realiza edicion en la tabla tipo tickets
        public Boolean Actualizar_Tipo_Ticket_Habilitado(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE tipo_ticket SET tipo_Ticket = @tipo_Ticket, Tipo_Ticket_Habilitado = @Tipo_Ticket_Habilitado, H_respuesta_tipo_ticket = @Horas_respuesta WHERE ( id_tipo_Ticket = @idtipo_Ticket )");

                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idtipo_Ticket", myParametro.id_tipos_tickets);
                cmd.Parameters.AddWithValue("@tipo_Ticket", myParametro.tipos_tickets);
                cmd.Parameters.AddWithValue("@Tipo_Ticket_Habilitado", myParametro.Tipo_Ticket_Habilitado);
                cmd.Parameters.AddWithValue("@Horas_respuesta", myParametro.horas_respuesta_tipos_tickets);

                cmd.ExecuteNonQuery();

                estado = true;
            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
                estado = false;
            }
            return estado;

        }





        //Realiza edicion en la tabla estados de ticket
        public Boolean Actualizar_Estados_ticket_Habilitado(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string sql = (" UPDATE estado_ticket SET estado_Ticket = @estado_Ticket, estado_Habilitado = @estado_Habilitado WHERE(id_Estado_Ticket = @idEstado_Ticket) ");
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idEstado_Ticket", myParametro.Id_Estados_tickets);
                cmd.Parameters.AddWithValue("@estado_Ticket", myParametro.Estados_tickets);
                cmd.Parameters.AddWithValue("@estado_Habilitado", myParametro.estado_Habilitado);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }




        //Realiza edicion en la tabla usuarios para habilitarlo
        public Boolean Actualizar_usuario_Habilitado(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string patron = "Dynamics1", usuario_habilitado = "Si";
                //string sql = (" UPDATE usuario SET nombre_usuario = @Nombres, correo_usu = @Correo, rol_id = @Rol_usuario, prefijo_usuario = @Usuario, area_id = @area_idarea, " +
                //    " contrasena_usu = @Contrasena, Usuario_Habilitado = 'Si' WHERE(id_usuario = @idUsuario) ");

                SqlCommand cmd = new SqlCommand("Sp_update_usu", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id_usuario", myParametro.Id_usuario);
                cmd.Parameters.AddWithValue("@nombre_usuario", myParametro.Nombre_Usuario);
                cmd.Parameters.AddWithValue("@correo_usu", myParametro.Correo_Usuario);
                cmd.Parameters.AddWithValue("@rol_id", myParametro.Rol_usuario);
                cmd.Parameters.AddWithValue("@prefijo_usuario", myParametro.Prefijo_Usuario);
                cmd.Parameters.AddWithValue("@area_id", myParametro.Grupo_Usuario);
                cmd.Parameters.AddWithValue("@contrasena_usu", myParametro.Contraseña_Usuario);
                cmd.Parameters.AddWithValue("@usuario_Habilitado", usuario_habilitado);
                cmd.Parameters.AddWithValue("@Patron", patron);



                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;
        }

        //Realiza edicion en la tabla usuarios para habilitarlo
        public Boolean Actualizar_usuario_des_Habilitado(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE usuario SET Usuario_Habilitado = 'No' WHERE (id_Usuario = @idUsuario) ");
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@idUsuario", myParametro.Id_usuario);




                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;
        }


        //Realiza edicion en la tabla Empresa
        public Boolean Actualizar_Empresa(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE empresa SET Nombre_Empresa = @Nombre_Empresa, Nit = @Nit, telefono_empresa = @Telefono, Representante_empresa = @Representante_empresa WHERE (id_Empresa = @id_Empresas) ");

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id_Empresas", myParametro.id_Empresa);

                cmd.Parameters.AddWithValue("@Nombre_Empresa", myParametro.Nombre_Empresa);
                cmd.Parameters.AddWithValue("@Nit", myParametro.Nit);
                cmd.Parameters.AddWithValue("@Telefono", myParametro.Telefono_Empresa);
                cmd.Parameters.AddWithValue("@Representante_empresa", myParametro.Representante_empresa);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }


        //Realiza edicion en la tabla empresa para recuperarla
        public Boolean Actualizar_Empresa_habilitada(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {
                string sql = (" UPDATE empresa SET Empresa_Habilitada = 'Si' WHERE (id_Empresa = @id_Empresas) ");
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@id_Empresas", myParametro.id_Empresa);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;
        }


        //Realiza edicion en la tabla empresas para eliminarla
        public Boolean Actualizar_empresa_eliminar(Clase_Parametros myParametro)
        {
            Boolean estado = false;
            try
            {

                string sql = (" UPDATE empresa SET Empresa_Habilitada = @Empresa_Habilitada WHERE (id_Empresa = @id_Empresas) ");

                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@id_Empresas", myParametro.id_Empresa);
                cmd.Parameters.AddWithValue("@Empresa_Habilitada", myParametro.Empresa_Habilitada);

                cmd.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {

                this.error = exception.Message;
            }
            return estado;

        }




        //traer el id del ticket creado para mostrarlo en el en pantalla emergente al usuario
        public Clase_Parametros traerID_Ticket()
        {
            string sql = " SELECT id_ticket, usuario_id FROM ticket WHERE id_ticket=(SELECT max(id_ticket) FROM ticket) ";
            SqlCommand cmd = new SqlCommand(sql, conexion);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.No_ticket = registro.GetInt32(0);
                myParametro.Id_usuario = registro.GetInt32(1);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer el id de la nota creado para insertar en la tabla de las notas compartidas
        public Clase_Parametros traerID_nota_sas()
        {
            string sql = " SELECT id_nota FROM nota WHERE id_nota=(SELECT max(id_ticket) FROM ticket) ";
            SqlCommand cmd = new SqlCommand(sql, conexion);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.No_ticket = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer el id del ticket creado para mostrarlo en el en pantalla emergente al usuario
        public Clase_Parametros traer_Prefijo_Usario(string idUsuario)
        {
            string sql = " SELECT prefijo_usuario FROM usuario where id_usuario = @idUsuario ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();
                myParametro.Usuarioprefijo = registro.GetString(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }

        }


        //traer el id del acta para agregarlo al numero de acta a crear 
        public Clase_Parametros traerID_Acta()

        {
            string sql = " SELECT id_acta FROM acta WHERE id_acta=(SELECT max(id_acta) FROM acta) ";
            SqlCommand cmd = new SqlCommand(sql, conexion);


            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.idactas = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer el id del ticket creado para mostrarlo en el en pantalla emergente al usuario
        public Clase_Parametros traerID_nota()

        {
            string sql = " SELECT id_nota FROM nota WHERE id_nota=(SELECT max(id_nota) FROM nota) ";
            SqlCommand cmd = new SqlCommand(sql, conexion);


            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.id_notas = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //trae los datos de un ticket para realizar las notas 
        public Clase_Parametros traer_datos_ticket(int idTicket)

        {
            string sql = " select  Resumen_Problema, tipo_ticket.tipo_Ticket, estado_ticket.estado_ticket, " +
                " Descripcion, Fecha,  cliente.nombre_cliente, usuario.nombre_usuario, " +
                " Cliente_id, Usuario_id, estado_id, fecha_vencimiento, " +
                " Fecha_inicio_proceso, creditos_desarrollo, Adjuntos_ticket, empresa.id_Empresa, " +
                " empresa.Nombre_Empresa, empresa.Representante_empresa, usuario.prefijo_usuario, id_ticket from ticket " +
                " inner join cliente on cliente.id_cliente = ticket.Cliente_id " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id " +
                " inner join tipo_ticket on tipo_ticket.id_tipo_Ticket = ticket.tipo_ticket_id  " +
                " inner join empresa on empresa.id_Empresa = cliente.empresa_id " +
                " where ticket.id_ticket = @idTicket ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idTicket", idTicket);


            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.Resumen = registro.GetString(0);
                myParametro.Tipo_ticket = registro.GetString(1);
                myParametro.Estado = registro.GetString(2);
                myParametro.Descripcion = registro.GetString(3);
                myParametro.Fecha = registro.GetDateTime(4);
                myParametro.Nombre_Cliente = registro.GetString(5);
                myParametro.Nombre_Usuario = registro.GetString(6);
                myParametro.cliente_idCliente_nota = registro.GetInt32(7);
                myParametro.Usuario_idUsuario_nota = registro.GetInt32(8);
                myParametro.estado_idEstado_nota = registro.GetInt32(9);
                myParametro.tiempo_Respuesta = registro.GetDateTime(10);
                myParametro.Fecha_inicio_proceso = registro.GetDateTime(11);
                myParametro.TiempoDesarrollo = registro.GetInt32(12);
                myParametro.Adjuntos_ticket = registro.GetString(13);
                myParametro.id_Empresa = registro.GetInt32(14);
                myParametro.Nombre_Empresa = registro.GetString(15);
                myParametro.Representante_empresa = registro.GetString(16);
                myParametro.Usuario = registro.GetString(17);
                myParametro.No_ticket = registro.GetInt32(18);




                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }




        //contar los tickets abiertos para mostrar en la bandeja de entrada
        public Clase_Parametros traer_abiertos()

        {
            string sql = " select count(*) from ticket where estado_id = '2' ";
            SqlCommand cmd = new SqlCommand(sql, conexion);


            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.N_abiertos = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }

        public Clase_Parametros traer_Enproceso()

        {
            string sql = " select count(*) from ticket where estado_id = '3' ";
            SqlCommand cmd = new SqlCommand(sql, conexion);


            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.N_Cerrados = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }



        //contar los tickets pendientes para mostrar en la bandeja de entrada
        public Clase_Parametros traer_pendientes()

        {
            string sql = " select count(*) from ticket where estado_id = '4' ";
            SqlCommand cmd = new SqlCommand(sql, conexion);


            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.N_Pendientes = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }

        //contar los tickets resueltos para mostrar en la bandeja de entrada
        public Clase_Parametros traer_resueltos()

        {
            string sql = " select count(*) from ticket where estado_id = '5' ";
            SqlCommand cmd = new SqlCommand(sql, conexion);


            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.N_Resueltos = registro.GetInt32(0);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //contar los tickets En proceso para mostrar en la bandeja de entrada


        //traer la la información del usuario a las texbox para la edicion de usuario
        public Clase_Parametros traer_nombre_rol_Usuario(string Correo)

        {
            string sql = " select id_usuario, nombre_usuario, rol, rol_id from usuario inner join rol on rol.id_rol= usuario.rol_id where correo_usu = @Correo ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Correo", Correo);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();
                myParametro.Id_usuario = registro.GetInt32(0);
                myParametro.Nombre_Usuario = registro.GetString(1);
                myParametro.Rol_usu_tex = registro.GetString(2);
                myParametro.Rol_usuario = registro.GetInt32(3);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer la la información del cliente a las texbox para la edicion de cliente
        public Clase_Parametros traer_nombre_rol_cliente(string Correo)

        {
            string sql = " SELECT id_Cliente, nombre_cliente, rol_id, empresa_id, rol FROM cliente inner join rol on rol.id_rol= cliente.rol_id where correo_cli = @correo_cli ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@correo_cli", Correo);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.idCliente = registro.GetInt32(0);
                myParametro.Nombre_Cliente = registro.GetString(1);
                myParametro.Rol_Cliente = registro.GetInt32(2);
                myParametro.Id_Empresa_cliente = registro.GetInt32(3);
                myParametro.Rol_Cli = registro.GetString(4);




                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }


        //traer el id del ticket creado para mostrarlo en el en pantalla emergente al usuario
        public Clase_Parametros traerId_usuario_Ticket_area(int area_idarea)
        {
            string sql = " SELECT id_ticket, Usuario_id FROM ticket " +
                " inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " inner join Area on Area.id_area = usuario.area_id " +
                " WHERE usuario.area_id = @area_idarea  order by id_ticket desc ";

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@area_idarea", area_idarea);

            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                Clase_Parametros myParametro = new Clase_Parametros();

                myParametro.No_ticket = registro.GetInt32(0);
                myParametro.Id_usuario = registro.GetInt32(1);


                registro.Close();
                return myParametro;
            }
            else
            {
                registro.Close();
                return null;
            }
        }




        //traer el ultimo usuario al cual se le se asigno el ultimo ticket creado dependiendo el area del usuario
        public List<Visualizar_Tickets> Traer_ultimo_usuario_ticket(int area_idarea)
        {
            string sql = " select id_usuario from usuario where area_id = @area_idarea and usuario.usuario_Habilitado = 'Si' ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            //cmd.Parameters.AddWithValue("@Ticket_idTicket", Ticket_idTicket);
            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            cmd.Parameters.AddWithValue("@area_idarea", area_idarea);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets visualizar = new Visualizar_Tickets();

                visualizar.Tlu_id_usuario = registro.GetInt32(0);




                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(visualizar);
            }
            registro.Close();
            return Visualizar_Tickets;

        }


        //traer la lista de los 10 agentes con mas casos abiertos
        public List<Visualizar_Tickets> top10_agente_ticke_abiertos()
        {
            string sql = " select top 10 nombre_usuario from ticket inner join usuario on usuario.id_usuario = ticket.Usuario_id " +
                " where ticket.estado_id = 2 group by nombre_usuario order by count(2) desc ";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            //cmd.Parameters.AddWithValue("@Ticket_idTicket", Ticket_idTicket);
            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets visualizar = new Visualizar_Tickets();

                visualizar.Nombre_usuario = registro.GetString(0);
                //visualizar.n_abiertos = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(visualizar);
            }
            registro.Close();
            return Visualizar_Tickets;

        }

        //  traer el listado de Todos los Tickets cerrados por consulto en la grafica
        public List<Visualizar_Tickets> lista_tickets_cerrados_grafica(int top_cerrados, DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select top(@top_cerrados) nombre_usuario, count(id_ticket) as N_Ticket from ticket " +
                " inner join usuario on usuario.id_usuario = ticket.usuario_id " +
                " where estado_id = 5 and fecha_cierre_ticket between @fecha_inicio AND @fecha_fin group by nombre_usuario ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@top_cerrados", top_cerrados);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario = registro.GetString(0);
                myTicket.N_Ticket = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Visualizar_Tickets> lista_tickets_cerrados_grilla(DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select nombre_usuario, count(id_ticket) as N_Ticket from ticket " +
                " inner join usuario on usuario.id_usuario = ticket.usuario_id " +
                " where estado_id = 5 and fecha_cierre_ticket between @fecha_inicio AND @fecha_fin group by nombre_usuario ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario = registro.GetString(0);
                myTicket.N_Ticket = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets creados y asignados a los consultores en la grafica
        public List<Visualizar_Tickets> lista_tickets_creados_grafica(int top_creados, DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select top (@top_creados) nombre_usuario, count(id_ticket) as N_tickets from ticket " +
                " inner join usuario on usuario.id_usuario = ticket.usuario_id " +
                " where Fecha between @fecha_inicio AND @fecha_fin group by nombre_usuario ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@top_creados", top_creados);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario_grfica_creados = registro.GetString(0);
                myTicket.N_Ticket_grafica_creados = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Visualizar_Tickets> lista_tickets_creados_grilla(DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select nombre_usuario, count(id_ticket) as N_tickets from ticket " +
                " inner join usuario on usuario.id_usuario = ticket.usuario_id " +
                " where Fecha between @fecha_inicio AND @fecha_fin group by nombre_usuario ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario_grfica_creados = registro.GetString(0);
                myTicket.N_Ticket_grafica_creados = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets creados y asignados a los consultores en la grafica
        public List<Visualizar_Tickets> lista_tickets_trabajados_grafica(int top_trabajados, DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select top(@top_trabajados) nombre_usuario, (select count(id_acta) " +
                " from acta where fecha_crea_acta between @fecha_inicio and @fecha_fin and acta.fk_usuario_id = usuario.id_usuario) as n_tickets " +
                " from usuario where usuario_Habilitado = 'Si' order by n_tickets desc";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@top_trabajados", top_trabajados);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Visualizar_Tickets> lista_tickets_trabajados_grilla(DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select nombre_usuario, (select count(id_acta) " +
                " from acta where fecha_crea_acta between @fecha_inicio and @fecha_fin and acta.fk_usuario_id = usuario.id_usuario) as n_tickets " +
                " from usuario where usuario_Habilitado = 'Si' order by n_tickets desc ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets creados y asignados a los consultores en la grafica
        public List<Visualizar_Tickets> lista_tickets_por_estado_grafica(DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select  estado_Ticket, COUNT(id_Estado_Ticket) as N_tickets from ticket " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id where Fecha between @fecha_inicio AND @fecha_fin " +
                " group by estado_Ticket order by COUNT(2) ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.estado_ticket = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Visualizar_Tickets> lista_tickets_por_estado_grilla(DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select  estado_Ticket, COUNT(id_Estado_Ticket) as N_tickets from ticket " +
                " inner join estado_ticket on estado_ticket.id_Estado_Ticket = ticket.estado_id where Fecha between @fecha_inicio AND @fecha_fin " +
                " group by estado_Ticket order by COUNT(2) ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.estado_ticket = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }


        //  traer el listado de Todos los Tickets creados y asignados a los consultores en la grafica
        public List<Visualizar_Tickets> lista_tickets_por_empresa_grafica(int top_empresas, DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select top (@top_empresa) nombre_empresa, COUNT(id_Empresa) as N_tickets from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id where Fecha between @fecha_inicio AND @fecha_fin " +
                " group by nombre_empresa order by COUNT(2) ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@top_empresa", top_empresas);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.nombre_empresa = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Visualizar_Tickets> lista_tickets_por_empresa_grilla(DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select nombre_empresa, COUNT(id_Empresa) as N_tickets from ticket " +
                " inner join cliente on cliente.id_Cliente = ticket.cliente_id " +
                " inner join empresa on empresa.id_empresa = cliente.empresa_id where Fecha between @fecha_inicio AND @fecha_fin " +
                " group by nombre_empresa order by COUNT(2) ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.nombre_empresa = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Visualizar_Tickets> lista_creditos_por_agente_grilla(int top_creditos, DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select top(@top_creditos_cosnul)  nombre_usuario, count(ticket.id_ticket) as N_tickets, sum(n_creditos_acta) as N_creditos from acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join usuario on usuario.id_usuario = acta.fk_usuario_id " +
                " where acta.fecha_crea_acta between @fecha_inicio AND @fecha_fin group by nombre_usuario ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@top_creditos_cosnul", top_creditos);
            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                myTicket.N_creditos = registro.GetInt32(2);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }

        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Visualizar_Tickets> lista_creditos_por_agente_grilla_export(DateTime fecha_inicio, DateTime fecha_fin)
        {
            string sql = " select nombre_usuario, count(ticket.id_ticket) as N_tickets, sum(n_creditos_acta) as N_creditos from acta " +
                " inner join ticket on ticket.id_ticket = acta.ticket_id " +
                " inner join usuario on usuario.id_usuario = acta.fk_usuario_id " +
                " where acta.fecha_crea_acta between @fecha_inicio AND @fecha_fin group by nombre_usuario  ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Visualizar_Tickets myTicket = new Visualizar_Tickets();

                myTicket.Nombre_usuario = registro.GetString(0);
                myTicket.N_Tickets = registro.GetInt32(1);
                myTicket.N_creditos = registro.GetInt32(2);
                // Agrego el objeto estudiante creado a la lista
                Visualizar_Tickets.Add(myTicket);
            }
            registro.Close();
            return Visualizar_Tickets;
        }





        //  traer el listado de Todos los Tickets cerrados en la grilla para exportar a excel
        public List<Informe> Grilla_informe(DateTime fecha_inicio, DateTime fecha_fin)
        {

            List<Informe> List_informe = new List<Informe>();

            SqlCommand cmd = new SqlCommand("informe3", conexion) { CommandType = System.Data.CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@fecha_ini", fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();

            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Informe informe = new Informe();

                informe.id_usuario = registro.GetInt32(0);
                informe.prefijo_usuario = registro.GetString(1);
                informe.n_ticket_nuevos_dia = registro.GetInt32(2);
                informe.n_ticket_nuevos_dia_jornada = registro.GetInt32(3);
                informe.n_ticket_Resueltos_hoy = registro.GetInt32(4);
                informe.n_ticket_cerrados_hoy = registro.GetInt32(5);
                informe.N_casos_abierto_cierre_jornada = registro.GetInt32(6);
                informe.n_creditos_hoy = registro.GetInt32(7);
                informe.n_ticket_desarrollo = registro.GetInt32(8);
                informe.n_ticket_incidente= registro.GetInt32(9);
                informe.n_ticket_proyecto = registro.GetInt32(10);
                // Agrego el objeto estudiante creado a la lista
                List_informe.Add(informe);
            }
            registro.Close();
            return List_informe;
        }


        public List<Informe> sin_responder_por_usuario()
        {
            List<Informe> List_informe = new List<Informe>();
            string sql = " select (select prefijo_usuario from usuario where usuario.id_usuario = ticket.usuario_id) as usuario," +
                " id_ticket, isnull((select max(nota.id_nota) from nota where nota.id_ticket = ticket.id_ticket),0)as n_nota" +
                " from ticket where ticket_Habilitado='Si' and estado_id= 2 or estado_id= 3 or estado_id= 4";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);

            //cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            //cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();


            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Informe informe = new Informe();

                informe.id_usuario_sin_responder = registro.GetString(0);
                informe.id_ticket_sin_responder = registro.GetInt32(1);
                informe.n_nota_sin_responder = registro.GetInt32(2);
                
                
                List_informe.Add(informe);
            }
            registro.Close();
            return List_informe;
        }

        public List<Informe> sin_responder_por_cliente()
        {
            List<Informe> List_informe = new List<Informe>();
            string sql = " select (select nombre_cliente from cliente where cliente.id_Cliente = ticket.cliente_id) as cliente," +
                " id_ticket, isnull((select max(nota.id_nota) from nota where nota.id_ticket = ticket.id_ticket),0)as n_nota" +
                " from ticket where ticket_Habilitado='Si' and estado_id= 2 or estado_id= 3 or estado_id= 4 ";

            List<Visualizar_Tickets> Visualizar_Tickets = new List<Visualizar_Tickets>();

            SqlCommand cmd = new SqlCommand(sql, conexion);

            //cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            //cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            SqlDataReader registro = cmd.ExecuteReader();


            while (registro.Read())
            {           // por cada registro creo un objeto estudiante
                Informe informe = new Informe();

                informe.id_usuario_sin_responder = registro.GetString(0);
                informe.id_ticket_sin_responder = registro.GetInt32(1);
                informe.n_nota_sin_responder = registro.GetInt32(2);


                List_informe.Add(informe);
            }
            registro.Close();
            return List_informe;
        }

    }




}