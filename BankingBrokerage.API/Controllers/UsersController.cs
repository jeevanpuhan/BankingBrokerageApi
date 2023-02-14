using AutoMapper;
using BankingBrokerage.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingBrokerage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            
            var usersDTO = mapper.Map<List<Models.DTO.User>>(users);    

            return Ok(usersDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetUserAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAsync([FromRoute] int id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<Models.DTO.User>(user);

            return Ok(userDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddUserAsync([FromBody] Models.DTO.AddUserRequest addUserRequest)
        {
            var user = mapper.Map<Models.Domain.User>(addUserRequest);

            user = await _userService.AddUserAsync(user);

            var userDTO = mapper.Map<Models.DTO.User>(user);

            return CreatedAtAction(nameof(GetUserAsync), new {id = userDTO.Id}, userDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _userService.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<Models.DTO.User>(user);

            return Ok(userDTO);
        }


        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserAsync(
            [FromRoute] int id, 
            [FromBody] Models.DTO.UpdateUserRequest updateUserRequest)
        {
            var user = mapper.Map<Models.Domain.User>(updateUserRequest);

            user = await _userService.UpdateUserAsync(id, user);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<Models.DTO.User>(user);

            return Ok(userDTO);
        }
    }
}
