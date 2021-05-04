using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using SocketUtils;

namespace MensajeroApp.Threads
{
    public class HiloCliente
    {
        private ClienteSocket cliente;
        private IMensajesDAL dal = MensajesDALFactory.CreateDAL();
        public HiloCliente(ClienteSocket cliente)
        {
            this.cliente = cliente;
        }

        public void Ejecutar()
        {
            string detalle, nombre;
            do
            {
                cliente.Escribir("Ingrese su nombre por favor");
                nombre = cliente.Leer().Trim();


            } while (nombre == string.Empty);
            do
            {
                cliente.Escribir("Ingrese su mensaje por favor");
                detalle = cliente.Leer().Trim();


            } while (detalle == string.Empty);
            Mensaje mensaje = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "TCP"
            };
            lock (dal)
            {
                dal.Save(mensaje);
            }
            cliente.CerrarConexion();

        }
    }
}
