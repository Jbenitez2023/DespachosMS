using AccountingconceptService.Dtos;
using AccountingconceptService.Models;
using AccountingconceptService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingconceptService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingConceptController : ControllerBase
    {
        private readonly IAccountingConceptRepository _accountingconceptRepository;

        public AccountingConceptController(IAccountingConceptRepository accountingconceptRepository)
        {
            _accountingconceptRepository = accountingconceptRepository;
        }


        // GET: api/<AccountingConceptController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountingConceptResponseDto>>> Get()
        {

            try { 
                var data =  await _accountingconceptRepository.GetAll();
                if (!data.Any())
                    return NotFound();
                return Ok(data);
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        // GET api/<AccountingConceptController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountingConceptResponseDto>> Get(int id)
        {
            try
            {
                var data = await _accountingconceptRepository.GetById(id);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<AccountingConceptController>
        [HttpPost]
        public async Task<ActionResult<AccountingConceptResponseDto>> Post([FromBody] AccountingConceptRequestDto value)
        {
            try { 
                var data = await _accountingconceptRepository.Create(value);
                return Ok(data);
            } catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<AccountingConceptController>/5
        [HttpPut]
        public async Task<ActionResult<AccountingConceptResponseDto>> Put([FromBody] AccountingConceptResponseDto value)
        {
            try
            {
                var data = await _accountingconceptRepository.Update(value);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<AccountingConceptController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var data = await _accountingconceptRepository.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
