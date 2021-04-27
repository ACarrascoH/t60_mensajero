using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    public class MensajesDALArchivos : IMensajesDAL
    {
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "mensajes.txt";

        //Larman UML y Patrones
        //Patron singleton
        //1. Un constructor privado
        private MensajesDALArchivos()
        {

        }
        //3.Una referencia estatica a si mismo
        private static IMensajesDAL instancia;
        //2. Un metodo estatico que retorne la unica instancia
        public static IMensajesDAL GetInstance()
        {
            if(instancia == null)
            {
                instancia = new MensajesDALArchivos();
            }
            return instancia;
        }


        public List<Mensaje> GetAll()
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = null;
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            //Procesamiento de la linea
                            string[] textoArray = texto.Trim().Split(';');

                            Mensaje m = new Mensaje()
                            {
                                //0 nombre
                                Nombre = textoArray[0],
                                //1 mensaje
                                Detalle = textoArray[1],
                                //2 tipo
                                Tipo = textoArray[2]
                            };
                            mensajes.Add(m);
                            
                        }
                    }while(texto != null);
                }

            }catch (IOException ex)
            {
                mensajes = null;
            }
            return mensajes;
        }

        public void Save(Mensaje m)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }

            }catch(Exception ex)
            {

            }
        }
    }
}
