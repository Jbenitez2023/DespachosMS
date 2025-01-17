using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TipoPagosService.Dto;
using TipoPagosService.Repositories;

namespace TipoPagosService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PayTypeController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IPayTypeRepository _PayTypeRepository;

        public PayTypeController(IMapper mapper, IPayTypeRepository payTypeRepository)
        {
            _Mapper = mapper;
            _PayTypeRepository = payTypeRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayTypeResponseDto>>> Get() {

            try
            {
                var payTypes = await _PayTypeRepository.Getall();
                if (!payTypes.Any())
                {
                    return NotFound("No se encontraron datos");
                }
                return Ok(payTypes);
            }
            catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }

        [HttpGet("id")]
        public async Task<ActionResult<PayTypeResponseDto>> Get(int id)
        {

            try
            {
                var payTypes = await _PayTypeRepository.GetByid(id);
                if (payTypes== null)
                {
                    return NotFound("No se encontraron datos");
                }
                return Ok(payTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<PayTypeResponseDto>> Post([FromBody] PayTypeRequestDto Model)
        {
            try
            {
                var data = await _PayTypeRepository.Create(Model);
                return Ok(data);
            }
            catch (Exception ex) { 
            
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<PayTypeResponseDto>> Put([FromBody] PayTypeResponseDto Model)
        {
            try
            {
                var data = await _PayTypeRepository.Update(Model);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("id")]
        public async Task<ActionResult<PayTypeResponseDto>> Delete(int id)
        {
            try
            {
                var payTypes = await _PayTypeRepository.Delete(id);
                return Ok(payTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}
