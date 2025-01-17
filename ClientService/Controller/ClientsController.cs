using AutoMapper;
using ClientService.Dto;
using ClientService.Models;
using ClientService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientResponseDto>>> Get() {
            try
            {
                var clients = await _clientRepository.GetAll();
                if (!clients.Any()) // Si no hay clientes
                {
                    return NotFound("No se encontraron clientes.");
                }

                return Ok(clients); // Respuesta HTTP 200 con datos
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Error al obtener los clientes: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ClientResponseDto>>> Get(int id)
        {
            try
            {
                var clients = await _clientRepository.GetById(id);
                if (clients == null) // Si no hay clientes
                {
                    return NotFound("No se encontraron clientes.");
                }

                return Ok(clients); // Respuesta HTTP 200 con datos
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Error al obtener los clientes: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClientResponseDto>> Post([FromBody] ClientRequestDto Model)
        {
            var Client = _mapper.Map<Client>(Model);
            try
            {

                await _clientRepository.Create(Client);
                return Ok(Model); // Respuesta HTTP 200 con datos
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Error al obtener los clientes: {ex.Message}");
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<ClientResponseDto>> Update([FromBody] Client Model)
        {

            try
            {
                await _clientRepository.Update(Model);
                return Ok(Model); // Respuesta HTTP 200 con datos
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Error al obtener los clientes: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {

            try
            {
                return Ok(await _clientRepository.Delete(id)); // Respuesta HTTP 200 con datos
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Error al obtener los clientes: {ex.Message}");
            }

        }
    }
}
