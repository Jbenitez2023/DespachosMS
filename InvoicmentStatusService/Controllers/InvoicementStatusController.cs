using AutoMapper;
using InvoicmentStatusService.Dtos;
using InvoicmentStatusService.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoicmentStatusService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvoicementStatusController : ControllerBase
    {
        private readonly IInvoicementStatusRepository _invoicementStatusRepository;
        private readonly IMapper _mapper;

        public InvoicementStatusController(IInvoicementStatusRepository invoicementStatusRepository, IMapper mapper)
        {
            _invoicementStatusRepository = invoicementStatusRepository;
            _mapper = mapper;
        }



        // GET: api/<InvoicementStatusController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoicementStatusResponseDto>>> Get()
        {
            try { 
                var data = await _invoicementStatusRepository.GetAll();
                return Ok(_mapper.Map<IEnumerable<InvoicementStatusResponseDto>>(data));
            } catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        // GET api/<InvoicementStatusController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoicementStatusResponseDto>> Get(int id)
        {
            try
            {
                var data = await _invoicementStatusRepository.GetById(id);
                return Ok(_mapper.Map<InvoicementStatusResponseDto>(data));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<InvoicementStatusController>
        [HttpPost]
        public async Task<ActionResult<InvoicementStatusResponseDto>> Post([FromBody] InvoicementStatusRequestDto model)
        {
            try 
            { 
                var data = await _invoicementStatusRepository.Create(model);
                return Ok(data);
            } catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<InvoicementStatusController>/5
        [HttpPut]
        public async Task<ActionResult<InvoicementStatusResponseDto>> Put([FromBody] InvoicementStatusResponseDto model)
        {
            try
            {
                var data = await _invoicementStatusRepository.Update(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<InvoicementStatusController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {

            try
            {
                var data = await _invoicementStatusRepository.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
