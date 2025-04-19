using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Dtos;
using ProfileService.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProfileService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IprofileServiceRepository _Profilerepository;
        private readonly IMapper _Mapper;

        public ProfileController(IprofileServiceRepository profilerepository, IMapper mapper)
        {
            _Profilerepository = profilerepository;
            _Mapper = mapper;
        }



        // GET: api/<ProfileController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileServiceResponseDto>>> Get()
        {
            try {
                var data = await _Profilerepository.GetAllAsync();
                if (!data.Any())
                    return NotFound();
                return Ok(_Mapper.Map<IEnumerable<ProfileServiceResponseDto>>(data));
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProfileController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileServiceResponseDto>> Get(int id)
        {
            try
            {
                var data = await _Profilerepository.GetByIdAsync(id);
                if (data == null)
                    return NotFound();
                return CreatedAtAction(nameof(Get),data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProfileController>
        [HttpPost]
        public async Task<ActionResult<ProfileServiceResponseDto>> Post([FromBody] ProfileServiceRequestDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var data = await _Profilerepository.AddAsync(value);
                return Ok(data);
            }
            catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        // PUT api/<ProfileController>/5
        [HttpPut]
        public async Task<ActionResult<ProfileServiceResponseDto>> Put([FromBody] ProfileServiceResponseDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var data = await _Profilerepository.UpdateAsync(value);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var data = await _Profilerepository.DeleteAsync(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
