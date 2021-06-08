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
    public class ServicioController :ControllerBase
    {
        private ServicioService servicioservice;
        public ServicioController(TallerContext context)
        {
            servicioservice = new ServicioService(context); 
        }
        [HttpPost]
        public ActionResult<ServicioViewModel> PostServicio(ServicioInputModel servicioInput)
        {

            var servicio = MapearServicio(servicioInput);
            var response = servicioservice.GuardarServicio(servicio);
            if (!response.Error)
            {
                var ServicioViewModel = new ServicioViewModel(servicio);
                return Ok(ServicioViewModel);
            }
            return BadRequest(response.Mensaje);
        }


        [HttpGet]
        public ActionResult<IEnumerable<ServicioViewModel>> GetServicios()
        {
            var response = servicioservice.Consultar();
            if (!response.Error)
            {
                var ServicioViewModels = response.Servicios.Select(p => new ServicioViewModel(p));
                return Ok(ServicioViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        private Servicio MapearServicio(ServicioInputModel servicioInput)
        {
            var servicio = new Servicio()
            {
                Nombre = servicioInput.Nombre,
                Precio = servicioInput.Precio,
            };
            return servicio;
        }
    }
}
