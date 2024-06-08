use DynaIT

select top(@top_trabajados) nombre_usuario, 
(select count(id_acta) from acta where fecha_crea_acta between @fecha_inicio and @fecha_fin and acta.fk_usuario_id = usuario.id_usuario ) as n_tickets
from usuario where usuario_Habilitado = 'Si' 

select  nombre_usuario, 
(select count(id_acta) from acta where fecha_crea_acta between '2022-05-11 00:00:00' and '2022-05-11 23:59:58' and acta.fk_usuario_id = usuario.id_usuario ) as n_tickets
from usuario where usuario_Habilitado = 'Si' order by n_tickets desc


select nombre_usuario, 
(select count(*) from (select DISTINCT ticket_id from acta where fecha_crea_acta between @fecha_inicio and @fecha_fin and acta.fk_usuario_id = usuario.id_usuario )t ) as n_ticket
from usuario where usuario_Habilitado = 'Si' order by n_ticket desc


select id_usuario, nombre_usuario, 
(select count(*) from (select DISTINCT ticket_id from acta where fecha_crea_acta between '2022-05-13 00:00:00' and '2022-05-13 23:59:58' and acta.fk_usuario_id = usuario.id_usuario )t ) as n_ticket
from usuario where usuario_Habilitado = 'Si' order by n_ticket desc

select top(@top_trabajados) nombre_usuario, count(ticket.id_ticket) as N_tickets from ticket 
  inner join nota on nota.id_ticket = ticket.id_ticket
  inner join usuario on usuario.id_usuario = nota.nota_creada_por
                 where FechaNota between @fecha_inicio AND @fecha_fin group by nombre_usuario	


select * from acta where fecha_crea_acta between '2022-05-13 00:00:00' and '2022-05-13 23:59:58'
select id_ticket, fecha_vencimiento from ticket
