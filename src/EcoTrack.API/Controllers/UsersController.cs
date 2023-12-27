using AutoMapper;
using EcoTrack.API.Dtos;
using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.Users.Interfaces;
using EcoTrack.PL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using System.Security.Claims;

namespace EcoTrack.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        public UsersController(
            IUsersService usersService,
            IMapper mapper,
            ILogger<UsersController> logger
            )
        {
            _usersService = usersService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(
            [FromQuery] string? firstName,
            [FromQuery] string? lastName,
            [FromQuery] string? cityName,
            [FromQuery] string? countryName,
            [FromQuery] int pageSize = 30,
            [FromQuery] int page = 1
            )
        {
            //TODO-POLICY:retrieve just followed user.??X
            //TODO-POLICY:Admin can get all.
            //TODO: Return pagination metadata.

            var users = await _usersService.GetAllUsersAsync(firstName, lastName, cityName, countryName, pageSize, page);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersDto);
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            var user = await _usersService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPatch("{userId}")]
        public async Task<ActionResult> PartiallyUpdateUser
            (
                int userId,
                JsonPatchDocument<UserDtoForUpdate> userJsonPatch
            )
        {
            //TODO-POLICY: User can update just himself.
            var user = await _usersService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }
            var userDtoForUpdate = _mapper.Map<UserDtoForUpdate>(user);
            userJsonPatch.ApplyTo(userDtoForUpdate, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(userDtoForUpdate))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(userDtoForUpdate, user);
            await _usersService.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserRegistrationDto userRegistrationDto)
        {
            //TODO: add validation attributes on the UserRegistrationDto
            var user = _mapper.Map<User>(userRegistrationDto);
            try
            {
                await _usersService.AddUserAsync(user);
            }
            catch (UsernameUsedException e)
            {
                return Conflict(new
                {
                    message = e.Message
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error on adding a user");
                return StatusCode(500, "Internal Server Error.");
            }
            return NoContent();
        }

        [HttpDelete("{userId}")]
        [Authorize]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var userRequestedId =long.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))!.Value);

            if (userId != userRequestedId)
            {
                return Forbid();
            }
            
            try
            {
                await _usersService.DeleteUserAsync(userId);
            }
            catch (NotFoundUserException e)
            {
                return NotFound(new
                {
                    Message = e.Message
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error deleting a user with {userId} id.");
                return StatusCode(500, "Internal Server Error.");
            }
            return NoContent();
        }
    }
}
