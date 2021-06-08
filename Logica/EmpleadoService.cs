using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class EmpleadoService
    {
        private readonly TallerContext _context;
        public EmpleadoService(TallerContext context)
        {
            _context = context;
        }
          public GuardarEmpleadoResponse GuardarEmpleado(Empleado empleado)
        {
            try
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return new GuardarEmpleadoResponse(empleado);
            }
            catch (Exception e)
            {
                return new GuardarEmpleadoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
           public ConsultaEmpleadoResponse Consultar()
        {
            try
            {
                List<Empleado> empleados = _context.Empleados.ToList();
                if(empleados == null){
                    return new ConsultaEmpleadoResponse("la lista se encuentra vacia");
                }
                return new ConsultaEmpleadoResponse(empleados);
            }
            catch (Exception e)
            {
                return new ConsultaEmpleadoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
    }
        public class GuardarEmpleadoResponse
    {
        public Empleado Empleado { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarEmpleadoResponse(Empleado empleado)
        {
            Empleado = empleado;
            Error = false;
        }

        public GuardarEmpleadoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
      public class ConsultaEmpleadoResponse
    {
        public List<Empleado> Empleados { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultaEmpleadoResponse(List<Empleado> empleados)
        {
            Empleados = empleados;
            Error = false;
        }

        public ConsultaEmpleadoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
