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
    public class CitaController : ControllerBase
    { 
        private CitaService citaservice;
        public CitaController(TallerContext context)
        {
            citaservice = new CitaService(context); 
        }
        [HttpPost]
        public ActionResult<CitaViewModel> PostCita(CitaInputModel citaInput)
        {

            var cita = MapearCita(citaInput);
            var response = citaservice.GuardarCita(cita);
            if (!response.Error)
            {
                var CitaViewModel = new CitaViewModel(cita);
                return Ok(CitaViewModel);
            }
            return BadRequest(response.Mensaje);
        }


        [HttpGet]
        public ActionResult<IEnumerable<CitaViewModel>> GetCitas()
        {
            var response = citaservice.Consultar();
            if (!response.Error)
            {
                var CitaViewModels = response.Citas.Select(p => new CitaViewModel(p));
                return Ok(CitaViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        private Cita MapearCita(CitaInputModel citaInput)
        {
            var cita = new Cita()
            {
                clienteId = citaInput.cliente.Identificacion,
                cliente = new Cliente(){Identificacion = citaInput.cliente.Identificacion, Nombre = citaInput.cliente.Nombre, Apellido = citaInput.cliente.Apellido, Edad = citaInput.cliente.Edad, Telefono = citaInput.cliente.Telefono, Sexo= citaInput.cliente.Sexo },
                Vehiculo = new Vehiculo(){ Placa = citaInput.vehiculo.Placa, ClienteId = citaInput.vehiculo.ClienteId ,Tipo= citaInput.vehiculo.Tipo ,Modelo = citaInput.vehiculo.Modelo, Color = citaInput.vehiculo.Color,Marca = citaInput.vehiculo.Marca},
                fecha = citaInput.fecha,
            };
            return cita;
        }
    }
}
