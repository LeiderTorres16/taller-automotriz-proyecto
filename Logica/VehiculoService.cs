using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class VehiculoService
    {
        private readonly TallerContext _context;
        public VehiculoService(TallerContext context)
        {
            _context = context;
        }
          public GuardarVehiculoResponse GuardarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                var cliente = _context.Clientes.Find(vehiculo.cliente.Identificacion);
                if(cliente != null){
                    vehiculo.cliente = cliente;
                    _context.Vehiculos.Add(vehiculo);
                    _context.SaveChanges();
                    return new GuardarVehiculoResponse(vehiculo);
                }
                return new GuardarVehiculoResponse("vehiculo no se puede registrar");
            }
            catch (Exception e)
            {
                return new GuardarVehiculoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
        public ConsultaVehiculoResponse Consultar()
        {
            try
            {
                List<Vehiculo> vehiculos = _context.Vehiculos.Include("cliente").ToList();
                if (vehiculos == null)
                {
                    return new ConsultaVehiculoResponse("la lista se encuentra vacia");
                }
                return new ConsultaVehiculoResponse(vehiculos);
            }
            catch (Exception e)
            {
                return new ConsultaVehiculoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
    }
    public class GuardarVehiculoResponse
    {
        public Vehiculo Vehiculo { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarVehiculoResponse(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
            Error = false;
        }

        public GuardarVehiculoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
      public class ConsultaVehiculoResponse
    {
        public List<Vehiculo> Vehiculos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultaVehiculoResponse(List<Vehiculo> vehiculos)
        {
            Vehiculos = vehiculos;
            Error = false;
        }

        public ConsultaVehiculoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
