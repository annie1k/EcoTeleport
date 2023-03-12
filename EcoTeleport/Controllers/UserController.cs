using EcoTeleport.Dto;
using EcoTeleport.Interfaces;
using EcoTeleport.Model;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace EcoTeleport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
    
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public IActionResult GetAllUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetAllUsers());
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("UserDto object is null");
            }

            var user = _mapper.Map<User>(userDto);

            var createdUser = _userRepository.CreateUser(user.user_name, user.password);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUserDto = _mapper.Map<UserDto>(createdUser);

            return CreatedAtRoute("GetUserById", new { userId = createdUserDto.user_uuid }, createdUserDto);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(Guid userId, [FromBody] User user)
        {
            var existingUser = _userRepository.GetUserById(userId);

            if (existingUser == null)
                return NotFound();

            existingUser.user_name = user.user_name;
            existingUser.password = user.password;

            _userRepository.UpdateUser(existingUser);

            return Ok(existingUser);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.GetUserById(user.user_uuid);

            return NoContent();
        }
    }
}
