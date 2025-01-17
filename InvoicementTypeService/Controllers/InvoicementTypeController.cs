using AutoMapper;
using InvoicementTypeService.Dtos;
using InvoicementTypeService.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoicementTypeService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvoicementTypeController : ControllerBase
    {
        private readonly IInvoicementTypeRepository _invoicementTypeRepository;
        private readonly IMapper _mapper;

        public InvoicementTypeController(IInvoicementTypeRepository invoicementTypeRepository, IMapper mapper)
        {
            _invoicementTypeRepository = invoicementTypeRepository;
            _mapper = mapper;
        }


        // GET: api/<InvoicementTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoicementTypeResponseDto>>> Get()
        {
            try {
                var data = await _invoicementTypeRepository.GetAll();
                if(!data.Any()) 
                    return NotFound("No se encontraron datos");
                return Ok(data);
            } catch( Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<InvoicementTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoicementTypeResponseDto>> Get(int id)
        {
            try
            {
                var data = await _invoicementTypeRepository.GetById(id);
                if (data == null)
                    return NotFound("No se encontraron datos");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<InvoicementTypeController>
        [HttpPost]
        public async Task<ActionResult<InvoicementTypeResponseDto>> Post([FromBody] InvoicementTypeRequestDto value)
        {
            try {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var data = await _invoicementTypeRepository.Create(value);
                return Ok(data);
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<InvoicementTypeController>/5
        [HttpPut]
        public async Task<ActionResult<InvoicementTypeResponseDto>> Put([FromBody] InvoicementTypeResponseDto value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var data = await _invoicementTypeRepository.Update(value);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<InvoicementTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                return Ok(await _invoicementTypeRepository.DeleteById(id));
            }
            catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
           
        }
    }
}
