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
    public class VehiculoController : ControllerBase
    {
        private VehiculoService vehiculoservice;
        public VehiculoController(TallerContext context)
        {
            vehiculoservice = new VehiculoService(context); 
        }
        [HttpPost]
        public ActionResult<VehiculoViewModel> PostVehiculo(VehiculoInputModel VehiculoInput)
        {
            var vehiculo = MapearVehiculo(VehiculoInput);
            var response = vehiculoservice.GuardarVehiculo(vehiculo);
            if (!response.Error)
            {
                var VehiculoViewModel = new VehiculoViewModel(vehiculo);
                return Ok(VehiculoViewModel);
            }
            return BadRequest(response.Mensaje);
        }
       [HttpGet]
        public ActionResult<IEnumerable<VehiculoViewModel>> GetVehiculo()
        {
            var response = vehiculoservice.Consultar();
            if (!response.Error)
            {
                var vehiculoViewModels = response.Vehiculos.Select(p => new VehiculoViewModel(p));
                return Ok(vehiculoViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        private Vehiculo MapearVehiculo(VehiculoInputModel vehiculoInput)
        {
            var vehiculo = new Vehiculo()
            {
                Placa = vehiculoInput.Placa,
                cliente = new Cliente(){Identificacion = vehiculoInput.Cliente.Identificacion, Nombre = vehiculoInput.Cliente.Nombre, Apellido = vehiculoInput.Cliente.Apellido, Edad = vehiculoInput.Cliente.Edad, Telefono = vehiculoInput.Cliente.Telefono, Sexo= vehiculoInput.Cliente.Sexo },
                Tipo = vehiculoInput.Tipo,
                Modelo = vehiculoInput.Modelo, 
                Color = vehiculoInput.Color,
                Marca = vehiculoInput.Marca,
            };
            return vehiculo;
        }
    }
}
