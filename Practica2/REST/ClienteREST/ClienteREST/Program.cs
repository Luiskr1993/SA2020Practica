using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace ClienteREST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************************************************************************" +Environment.NewLine);
            Console.WriteLine("****************************************************************************" + Environment.NewLine);
            Console.WriteLine("*********************CREANDO CONTACTOS 201122864****************************" + Environment.NewLine);
            Console.WriteLine("****************************************************************************" + Environment.NewLine);
            Console.WriteLine("****************************************************************************" + Environment.NewLine);

            Console.WriteLine("\n");
            Console.WriteLine("Obteniendo token..." + Environment.NewLine);
            
            string resultado = "";
            var contacto="";

            //Se crea la petición de token para el cliente
            var client = new RestClient("https://api.softwareavanzado.world/index.php?option=token&api=oauth2");
            var peticion = new RestRequest(Method.POST);
            peticion.AddHeader("cache-control", "no-cache");
            peticion.AddHeader("content-type", "application/x-www-form-urlencoded");
            //Se asignan los parámetros de usuario para solicitar el token
            peticion.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=sa&client_secret=fb5089840031449f1a4bf2c91c2bd2261d5b2f122bd8754ffe23be17b107b8eb103b441de3771745", ParameterType.RequestBody);

            IRestResponse response = client.Execute(peticion);

            //Se obtiene de la respuesta el valor del token para poder utilizarlo en la credencial
            dynamic respuesta = JObject.Parse(response.Content);// JObject.Parse(response.Content);
            String token = respuesta.access_token;

            //Se valida si el token tiene datos para mostrarlo en pantalla
            if (token != "") {
                Console.WriteLine("El token obtenido es: "+token + Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("****************************************************************************" + Environment.NewLine);
            Console.WriteLine("****************************************************************************" + Environment.NewLine);
            Console.WriteLine("Creando contactos nuevos... ");
            Console.Write("");
            Console.Write("");
            Console.Write("");

            //Se crea un ciclo para crear 20 contactos 
            for (int i = 1; i <= 20; i++) {
                Console.WriteLine("-------------------------------------------------------------------------");
                //Se redirecciona el cliente a la URL de la funciòn crear
                client = new RestClient("https://api.softwareavanzado.world/index.php?webserviceClient=administrator&webserviceVersion=1.0.0&option=contact&api=hal");
                peticion = new RestRequest(Method.POST);

                //Se concatena el token a la instrucciòn Bearer para completar la autenticación.
                peticion.AddHeader("Authorization", "Bearer " + token);
                peticion.AddHeader("cache-control", "no-cache");

                //Se formatea el contacto para que incluya mi nùmero de carnet
                contacto = "201122864_Contacto_"+i;
                Contacto nuevo = new Contacto { name = contacto, published = 1 };

                //Se crea un nuevo objeto JSON para enviar el paràmetro de nombre de contacto
                peticion.AddJsonBody(new { name = contacto });
                //Se ejecuta la peticiòn al cliente
                response = client.Execute(peticion);
                respuesta = JObject.Parse(response.Content);
                resultado = respuesta.result;

                //Se valida la respuesta del servicio y se muestra un mensaje en pantalla
                if (resultado == "True")
                {
                    Console.WriteLine("Contacto" + i + ": Creado exitosamente");
                }
                else {
                    Console.WriteLine("Contacto" + i + ": No fue creado");
                }

                Console.WriteLine("-------------------------------------------------------------------------");

            }

            Console.Write("Presione <Enter> para listar contactos... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            //**********************************************CODIGO PARA LISTAR CONTACTOS ****************************************
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("****************************************************************************" + Environment.NewLine);
            Console.WriteLine("****************************************************************************" + Environment.NewLine);
            Console.WriteLine("Listando contactos de 201122864... ");
            Console.WriteLine();
            Console.WriteLine();

            //Se redirecciona el cliente a la función de listar contactos
            client = new RestClient("https://api.softwareavanzado.world/index.php?webserviceClient=administrator&webserviceVersion=1.0.0&option=contact&api=hal");
            peticion = new RestRequest(Method.GET);

            //Se concatena el token a la instrucciòn Bearer para completar la autenticación.
            peticion.AddHeader("Authorization", "Bearer " + token);
            peticion.AddHeader("cache-control", "no-cache");

            //Se agregan parámetros para realizar la búsqueda y delimitación de contactos.
            peticion.AddParameter("filter[search]", "201122864_");
            peticion.AddParameter("list[limit]", 20);

            //Se ejecuta la petición al servicio.
            response = client.Execute(peticion);
            respuesta = JObject.Parse(response.Content);
            
            //La respuesta debido a que está en formato JSON, se recorre para mostrar en pantalla únicamente el nombre de los contactos.
            for (int a = 0; a < 20; a++) {
                Console.WriteLine(respuesta._embedded.item[a].name);
            } 
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("****************************************************************************" + Environment.NewLine);
            Console.WriteLine("****************************************************************************" + Environment.NewLine);

            Console.Write("Presione <Enter> para salir... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

        }
    }
}
