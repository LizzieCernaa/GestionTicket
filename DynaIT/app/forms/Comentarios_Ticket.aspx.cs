using System;

namespace DynaIT.app.forms
{
    public partial class Comentarios_Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] == null)
                return;
            // recibe el valor de la celda del datagrid view
            //Txt_Nº_Ticket.Text = Request.QueryString["id"].ToString();

            //if (Lbl_id_sancion.Text != "id_sancion")
            //{
            //    Btn_Editar.Visible = true;
            //    Btn_Enviar.Visible = false;
            //    cargar__datos_txt();
            //}
            //else
            //{

            //    Btn_Editar.Visible = false;
            //    Btn_Enviar.Visible = true;

            //}

        }
        //private void cargar_datosCliente_txt()
        //{

        //    Vista_inventario_elementos myElemento = Gestion_Datos.consultarElemento_traido(Lbl_id_Elemento.Text);

        //    txt_nombre_elemento.Text = myElemento.NOMBRE;
        //    txt_estado_elemento.Text = myElemento.ESTADO;
        //    txt_ubicacion_elemento.Text = myElemento.UBICACION;
        //    txt_detalle_elemento.Text = myElemento.DETALLE;



        //}
    }
}