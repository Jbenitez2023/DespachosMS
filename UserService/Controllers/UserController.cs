using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Repositories;
using UserService.TokenGenerators;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _UserRepository;
        public readonly IMapper _Mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _UserRepository = userRepository;
            _Mapper = mapper;
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserServiceResponseDto>>> Get()
        {
            try {
                var data = await _UserRepository.GetAsync();
                return Ok(data);
            } catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserServiceResponseDto>> Get(int id)
        {
            try
            {
                var data = await _UserRepository.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("UserValidation")]
        public async Task<ActionResult<string>> Post([FromBody] UserValidationDto Model)
        {
            try
            {
               if(Model == null || string.IsNullOrWhiteSpace(Model.UserName) || string.IsNullOrWhiteSpace(Model.Password))
                    return BadRequest("Invalid data");

                var data = await _UserRepository.GetByUser(Model.UserName, Model.Password);
                if (data == null)
                    return NotFound("User not found");

                var tokenGenerator = new TokenGenerator();
                string token = tokenGenerator.GenerateJwtToken(data.UserName);
                
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserServiceResponseDto>> Post([FromBody] UserServiceRequestDto Model)
        {
            try
            {
                var data = await _UserRepository.Create(Model);
                return CreatedAtAction(nameof(Get),new { id = data.Id}, data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<ActionResult<UserServiceResponseDto>> Put([FromBody] UserServiceResponseDto Model)
        {
            try
            {
                var data = await _UserRepository.Update(Model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var data = await _UserRepository.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
