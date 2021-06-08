using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ServicioService
    {
    private readonly TallerContext _context;
        public ServicioService(TallerContext context)
        {
            _context = context;
        }
          public GuardarServicioResponse GuardarServicio(Servicio servicio)
        {
            try
            {
                
                _context.Servicios.Add(servicio);
                _context.SaveChanges();
                return new GuardarServicioResponse(servicio);
            }
            catch (Exception e)
            {
                return new GuardarServicioResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
           public ConsultaServicioResponse Consultar()
        {
            try
            {
                List<Servicio> servicios = _context.Servicios.ToList();
                if(servicios == null){
                    return new ConsultaServicioResponse("la lista se encuentra vacia");
                }
                return new ConsultaServicioResponse(servicios);
            }
            catch (Exception e)
            {
                return new ConsultaServicioResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
    }
        public class GuardarServicioResponse
    {
        public Servicio Servicio { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarServicioResponse(Servicio servicio)
        {
            Servicio = servicio;
            Error = false;
        }

        public GuardarServicioResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
      public class ConsultaServicioResponse
    {
        public List<Servicio> Servicios { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultaServicioResponse(List<Servicio> servicios)
        {
            Servicios = servicios;
            Error = false;
        }

        public ConsultaServicioResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
