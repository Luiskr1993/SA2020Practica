using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        StringBuilder ss = new StringBuilder();

        //se crea una instancia de cliente para el servicio.
        ApiSA.administratorcontact100Client cliente;
        cliente = new ApiSA.administratorcontact100Client();
        
        //Se crea un objeto para almacenar las respuestas del servicio.
        ApiSA.readListResponse listadoRespuesta = new ApiSA.readListResponse();
        ApiSA.readListResponse_list_item lista = new ApiSA.readListResponse_list_item();

        try
        {
            //Se llama a la funciòn readList del servicio y se envían como parámetros los datos de cantidad y filtro de búsqueda tomados de la pantalla principal.
            listadoRespuesta.list = cliente.readList(0,Int32.Parse(this.textCantidad.Text),this.textFiltro.Text, null, "", "", "").ToArray();
            
            int cantidadResultados = listadoRespuesta.list.Count();

            //Se maquetan en una tabla los items que retorna la función readList propia del servicio
            if (cantidadResultados > 0)
            {
                ss.Append("<table class='table'>");
                ss.Append("<tr>");
                ss.Append("<th align='center'>ID</th>");
                ss.Append("<th align='center'>Nombre</th>");
                ss.Append("</tr>");
                for (int i = 0; i < cantidadResultados; i++)
                {
                    lista = listadoRespuesta.list.ElementAt(i);
                    ss.Append("<tr>");
                    ss.Append("<td>" + lista.id + "</td>");
                    ss.Append("<td>" + lista.name + "</td>");
                    ss.Append("</tr>");
                }

                ss.Append("</table>");
                this.labelListado.Text = ss.ToString();
            }
            else
            {
                this.labelListado.Text = "No se obtuvieron resultados.";
            }
        }
        catch (Exception ex) {
            this.labelListado.Text = "[Error]:Error en comunicación con el servicio SOAP";
        }
      
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        this.spanAgregar.InnerHtml = "";
        //Se crea una instancia de cliente para el servicio
        ApiSA.administratorcontact100Client cliente = new ApiSA.administratorcontact100Client();
        ApiSA.readItemResponse respuesta = new ApiSA.readItemResponse();
        ApiSA.readItemResponse_item item = new ApiSA.readItemResponse_item();
        
        string nombre = "";
        Boolean resultado;
        //Se concatena mi número de carnet al nombre que se escriba en la interfaz gráfica.
        nombre = "201122864 " + this.textNombre.Text;

        try
        {
           //Se llama a la funcion create, propia del servicio y se le envían parámetros para crear un nuevo contacto.
           resultado = cliente.create(nombre, 0, "", 0);
            if (resultado == true)
            {
                this.spanAgregar.InnerHtml = "Contacto Agregado Exitosamente";
                this.textNombre.Text = "";
            }
            else {
                this.spanAgregar.InnerHtml = "Error al agregar contacto";
            }
        }
        catch(Exception ex)
        {
            this.spanAgregar.InnerHtml = "[Error]: Ocurrió un error en la comunicación con el servicio SOAP";
        }

    }
}