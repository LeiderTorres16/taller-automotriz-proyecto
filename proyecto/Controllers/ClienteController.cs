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
    public class ClienteController : ControllerBase
    {
        private ClienteService clienteservice;
        public ClienteController(TallerContext context)
        {
            clienteservice = new ClienteService(context);
        }
        [HttpPost]
        public ActionResult<ClienteViewModel> PostCliente(ClienteInputModel clienteInput)
        {
            var cliente = MapearCliente(clienteInput);
            var response = clienteservice.GuardarCliente(cliente);
            if (!response.Error)
            {
                var ClienteViewModel = new ClienteViewModel(cliente);
                return Ok(ClienteViewModel);
            }
            return BadRequest(response.Mensaje);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClienteViewModel>> GetCliente()
        {
            var response = clienteservice.Consultar();
            if (!response.Error)
            {
                var ClienteViewModels = response.Clientes.Select(p => new ClienteViewModel(p));
                return Ok(ClienteViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        private Cliente MapearCliente(ClienteInputModel clienteInput)
        {
            var cliente = new Cliente()
            {
                Identificacion = clienteInput.Identificacion,
                Nombre = clienteInput.Nombre,
                Apellido = clienteInput.Apellido,
                Edad = clienteInput.Edad, 
                Telefono = clienteInput.Telefono,
                Sexo= clienteInput.Sexo 
            };
            return cliente;
        } 
    }
}
