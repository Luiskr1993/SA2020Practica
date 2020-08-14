using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services.Protocols;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;

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
        ApiSA.readListRequest pedirContactos = new ApiSA.readListRequest();
        

        try
        {
            //Se asignan las credenciales para poder acceder a los recursos del servicio
            ICredentials credenciales = new NetworkCredential("sa", "usac");
            
            cliente.ClientCredentials.HttpDigest.ClientCredential.UserName = "sa";
            cliente.ClientCredentials.HttpDigest.ClientCredential.Password = "usac";
            cliente.ClientCredentials.UserName.UserName = "sa";
            cliente.ClientCredentials.UserName.Password = "usac";
            

            //Se llama a la funciòn readList del servicio y se envían como parámetros los datos de cantidad y filtro de búsqueda tomados de la pantalla principal.
            pedirContactos.limitStart = 0;
            pedirContactos.limit = Int32.Parse(this.textCantidad.Text);
            pedirContactos.filterSearch = this.textFiltro.Text;
            
            listadoRespuesta.list = cliente.readList(pedirContactos).list;

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
            this.labelListado.Text = "[Error]:Error en comunicación con el servicio SOAP" +Environment.NewLine + ex.ToString();
        }
      
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        this.spanAgregar.InnerHtml = "";
        //Se crea una instancia de cliente para el servicio
        ApiSA.administratorcontact100Client cliente = new ApiSA.administratorcontact100Client();
       
        ApiSA.readItemResponse respuesta = new ApiSA.readItemResponse();
        ApiSA.readItemResponse_item item = new ApiSA.readItemResponse_item();
        ApiSA.createRequest crearContacto = new ApiSA.createRequest();

        
        

        string nombre = "";
        Boolean resultado;
        //Se concatena mi número de carnet al nombre que se escriba en la interfaz gráfica.
        nombre = "201122864 " + this.textNombre.Text;

        try
        {
            //Se asignan las credenciales para poder acceder a los recursos del servicio
            ICredentials credenciales = new NetworkCredential("sa", "usac");
            cliente.ClientCredentials.UserName.UserName = "sa";
            cliente.ClientCredentials.UserName.Password = "usac";
            cliente.ClientCredentials.Windows.ClientCredential.UserName = "sa";
            cliente.ClientCredentials.Windows.ClientCredential.Password = "usac";
            cliente.ClientCredentials.HttpDigest.ClientCredential.UserName = "sa";
            cliente.ClientCredentials.HttpDigest.ClientCredential.Password = "usac";
            crearContacto.name = nombre;

            //Get the current binding 
            /*System.ServiceModel.Channels.Binding binding = cliente.Endpoint.Binding;
            //Get the binding elements 
            BindingElementCollection elements = binding.CreateBindingElements();
            //Locate the Security binding element
            SecurityBindingElement security = elements.Find<SecurityBindingElement>();

            //This should not be null - as we are using Certificate authentication anyway
            if (security != null)
            {
                UserNameSecurityTokenParameters uTokenParams = new UserNameSecurityTokenParameters();
                uTokenParams.InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient;
                security.EndpointSupportingTokenParameters.SignedEncrypted.Add(uTokenParams);
            }

            cliente.Endpoint.Binding = new CustomBinding(elements.ToArray());
            cliente.ClientCredentials.UserName.UserName = "sa";
            cliente.ClientCredentials.UserName.Password = "usac";*/

            //Se llama a la funcion create, propia del servicio y se le envían parámetros para crear un nuevo contacto.
            resultado = cliente.create(crearContacto).result;
            cliente.Close();
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
            this.spanAgregar.InnerHtml = "[Error]: Ocurrió un error en la comunicación con el servicio SOAP" + Environment.NewLine + ex.ToString();
        }

    }
}