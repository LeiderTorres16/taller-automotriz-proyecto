using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ClienteService
    {
        private readonly TallerContext _context;
        public ClienteService(TallerContext context)
        {
            _context = context;
        }
        public GuardarClienteResponse GuardarCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return new GuardarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarClienteResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
        public ConsultaClienteResponse Consultar()
        {
            try
            {
                List<Cliente> clientes = _context.Clientes.ToList();
                if (clientes == null)
                {
                    return new ConsultaClienteResponse("la lista se encuentra vacia");
                }
                return new ConsultaClienteResponse(clientes);
            }
            catch (Exception e)
            {
                return new ConsultaClienteResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
        public MostrarClienteResponse ConsultarClienteIdentificacion(string identificaion)
        {
            try
            {
                var Cliente = _context.Clientes.Find(identificaion);
                if (Cliente == null)
                {
                    return new MostrarClienteResponse("No se encontraron Pagos para el tercero solicitado");
                }
                return new MostrarClienteResponse(Cliente);
            }
            catch (Exception e)
            {
                return new MostrarClienteResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
    }
    public class GuardarClienteResponse
    {
        public Cliente Cliente { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarClienteResponse(Cliente cliente)
        {
            Cliente = cliente;
            Error = false;
        }

        public GuardarClienteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class MostrarClienteResponse
    {
        public Cliente Cliente { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public MostrarClienteResponse(Cliente cliente)
        {
            Cliente = cliente;
            Error = false;
        }

        public MostrarClienteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class ConsultaClienteResponse
    {
        public List<Cliente> Clientes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultaClienteResponse(List<Cliente> clientes)
        {
            Clientes = clientes;
            Error = false;
        }

        public ConsultaClienteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
