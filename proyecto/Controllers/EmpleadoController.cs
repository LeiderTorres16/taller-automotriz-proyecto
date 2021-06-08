using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using proyecto.models;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class EmpleadoController : ControllerBase
    {
        private EmpleadoService empleadoservice;
        public EmpleadoController(TallerContext context)
        {
            empleadoservice= new EmpleadoService(context);
        }
        [HttpPost]
        public ActionResult<EmpleadoViewModel> PostEmpleado(EmpleadoInputModel empleadoInput)
        {
            var empleado = MapearEmpleado(empleadoInput);
            var response = empleadoservice.GuardarEmpleado(empleado);
            if (!response.Error)
            {
                var EmpleadoViewModel = new EmpleadoViewModel(empleado);
                return Ok(EmpleadoViewModel);
            }
            return BadRequest(response.Mensaje);
        }
        [HttpGet]
        public ActionResult<IEnumerable<EmpleadoViewModel>> GetEmpleado()
        {
            var response = empleadoservice.Consultar();
            if (!response.Error)
            {
                var EmpleadoViewModels = response.Empleados.Select(p => new EmpleadoViewModel(p));
                return Ok(EmpleadoViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        private Empleado MapearEmpleado(EmpleadoInputModel empleadoInput)
        {
            var empleado = new Empleado()
            {
                Identificacion = empleadoInput.Identificacion,
                Nombre = empleadoInput.Nombre,
                Apellido = empleadoInput.Apellido,
                Edad = empleadoInput.Edad, 
                Telefono = empleadoInput.Telefono,
                Sexo= empleadoInput.Sexo 
            };
            return empleado;
        }
    }
}
