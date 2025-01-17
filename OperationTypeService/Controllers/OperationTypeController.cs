using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using OperationTypeService.Dto;
using OperationTypeService.Repositories;
using System.Data;

namespace OperationTypeService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OperationTypeController : ControllerBase
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;

        public OperationTypeController(IOperationTypeRepository operationTypeRepository, IMapper mapper)
        {
            _operationTypeRepository = operationTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationTypeResponseDto>>> Get() {

            try
            {
                var operationTypes = await _operationTypeRepository.GetAll();
                if (!operationTypes.Any()) { 
                    return NotFound("No se encontraron datos");
                }
                return Ok(operationTypes);
            }
            catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los datos: {ex.Message}");
            }

        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<OperationTypeResponseDto>>> Get(int id)
        {

            try
            {
                var operationType = await _operationTypeRepository.GetById(id);
                if (operationType == null)
                {
                    return NotFound("No se encontraron datos");
                }
                return Ok(operationType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los datos: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<ActionResult<OperationTypeResponseDto>> Post([FromBody] OperationTyperequestDto Model)
        {
            var data = _mapper.Map<OperationTyperequestDto>(Model);
            try
            {
                await _operationTypeRepository.Create(data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<OperationTypeResponseDto>> Update([FromBody] OperationTypeResponseDto Model)
        {
            try
            {
                Model = await _operationTypeRepository.Update(Model);
                return Ok(Model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try {
                return Ok(await _operationTypeRepository.DeleteById(id));
            } catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
    }
}
