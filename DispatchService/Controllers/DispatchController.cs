using AutoMapper;
using DispatchService.Data;
using DispatchService.Dtos;
using DispatchService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace DispatchService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        public readonly ICrud<DispatchServiceResponseDto,DispatchServiceRequestDto> _DispatchRepository;
        public readonly IMapper _Mapper;
        public readonly KafkaProducer _KafkaProducer;

        public DispatchController(ICrud<DispatchServiceResponseDto, DispatchServiceRequestDto> dispatchRepository, IMapper mapper,KafkaProducer kp)
        {
            _DispatchRepository = dispatchRepository;
            _Mapper = mapper;
            _KafkaProducer = kp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DispatchServiceResponseDto>>> Get() {

            try
            {
                var data = await _DispatchRepository.GetAllAsync();
                if(!data.Any())
                    return NotFound(new { Message = "El recurso solicitado no se encontró." });
                return Ok(data);
            }
            catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DispatchServiceResponseDto>> Get(int id)
        {

            try
            {
                var data = await _DispatchRepository.GetByIdAsync(id);
                if (data == null)
                    return NotFound(new { Message = "El recurso solicitado no se encontró." });
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<DispatchServiceResponseDto>> Get([FromBody] DispatchServiceRequestDto model)
        {

            try
            {
                var data = await _DispatchRepository.AddAsync(model);
                return CreatedAtAction(nameof(Get), new { id = data.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<DispatchServiceResponseDto>> Put([FromBody] DispatchServiceResponseDto model)
        {

            try
            {
                var data = await _DispatchRepository.UpdateAsync(model);
                await _KafkaProducer.ProduceAsync("test-topic", JsonConvert.SerializeObject(data));
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DispatchServiceResponseDto>> Delete(int id)
        {

            try
            {
                var data = await _DispatchRepository.DeleteAsync(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
