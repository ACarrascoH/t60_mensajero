using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    class Program
    {
        static IMensajesDAL dal = MensajesDALFactory.CreateDAL();
        static void IngresarMensaje()
        {
            string detalle, nombre, tipo;
            do
            {
                Console.WriteLine("Ingrese su nombre por favor");
                nombre = Console.ReadLine().Trim();
                
                
            } while (nombre== string.Empty);
            do
            {
                Console.WriteLine("Ingrese su mensaje por favor");
                detalle = Console.ReadLine().Trim();
                

            } while (detalle == string.Empty);
            Mensaje mensaje = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "Aplicacion"
            };
            dal.Save(mensaje);
            
        }
        static void MostrarTodos()
        {
            List<Mensaje> lista = dal.GetAll();
            lista.ForEach(m =>
            {
            Console.WriteLine("N:{0} | D:{1} | T:{2}", m.Nombre, m.Detalle, m.Tipo);
            });
        }
        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Ingrese opcion:");
            Console.WriteLine("1. Ingrese mensaje");
            Console.WriteLine("2. Mostrar Mensajes");
            switch (Console.ReadLine().Trim())
            {
                case "1": IngresarMensaje();
                    break;
                case "2": MostrarTodos();
                    break;
                case "0": continuar = false;
                    break;
            }
            return continuar;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
    }
}
