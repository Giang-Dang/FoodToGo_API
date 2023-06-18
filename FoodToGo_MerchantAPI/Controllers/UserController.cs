using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models.DTO.UpdateDTO;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Json;

namespace FoodToGo_API.Controllers
{
    [Route("api/UserAPI")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _dbUser;
        private readonly IBanRepository _dbBan;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public UserController(IUserRepository dbUser, IMapper mapper, IBanRepository dbBan)
        {
            _dbUser = dbUser;
            _mapper = mapper;
            _dbBan = dbBan;
            this._response = new APIResponse();            
        }

        [HttpGet(Name = "GetAll")]
        [Authorize(Roles = "Admin")]
        [CustomAuthorize("LoginFromApp", "Management")]
        [ResponseCache(Duration = 1000)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAll(
            string? searchUserName,
            string? searchRole,
            string? searchEmail,
            string? searchPhoneNumber,
            int pageSize = 0,
            int pageNumber = 1)
        {
            try
            {
                List<User> userList = await _dbUser.GetAllAsync(null, pageSize, pageNumber);

                if (!searchUserName.IsNullOrEmpty())
                {
                    userList = userList.Where(e => e.Username.ToLower() == searchUserName!.ToLower()).ToList();
                }

                if (!searchRole.IsNullOrEmpty())
                {
                    userList = userList.Where(e => e.Role.ToLower() == searchRole!.ToLower()).ToList();
                }
                if (!searchEmail.IsNullOrEmpty())
                {
                    userList = userList.Where(e => e.Email.ToLower() == searchEmail!.ToLower()).ToList();
                }
                if (!searchPhoneNumber.IsNullOrEmpty())
                {
                    userList = userList.Where(e => e.PhoneNumber.ToLower() == searchPhoneNumber!.ToLower()).ToList();
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<UserDTO>>(userList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("checkusername", Name = "IsUsernameExisting")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> IsUsernameExisting(
            string? searchUserName)
        {
            try 
            {
                List<User> userList = await _dbUser.GetAllAsync(null, 0, 1);

                if(!searchUserName.IsNullOrEmpty())
                {
                    userList = userList.Where(e => e.Username.ToLower() == searchUserName!.ToLower()).ToList();
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = !userList.IsNullOrEmpty();

                return Ok(_response);
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "Get")]
        [Authorize]
        [ResponseCache(Duration = 1000)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            if (id <= 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Invalid Id");
                return BadRequest(_response);
            }

            var user = await _dbUser.GetAsync(e => e.Id == id);
            var userDTO = _mapper.Map<UserDTO>(user);

            if (userDTO == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"Cannot find the user {id}");
                return NotFound(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = userDTO;
            return Ok(_response);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginResponseDTO = await _dbUser.Login(loginRequestDTO);
            if (loginResponseDTO.IsSuccess == false)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(loginResponseDTO.ErrorMessage);
                return BadRequest(_response);
            }

            List<Ban> banList = new();
            banList.AddRange(await _dbBan.GetAllAsync(e => e.UserId == loginResponseDTO.User.Id));
            if (banList.Count > 0)
            {
                foreach (var ban in banList)
                {
                    if (ban.StartDate <= DateTime.Now && DateTime.Now <= ban.EndDate)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add($"User {loginResponseDTO.User!.Username} has been banned from {ban.StartDate.ToShortDateString} to {ban.EndDate.ToShortDateString}.");
                        return BadRequest(_response);
                    }
                }
            }
            

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.ErrorMessages.Clear();
            _response.Result = loginResponseDTO;
            return Ok(_response);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO registerationRequestDTO)
        {
            bool isUsernameUnique = await _dbUser.IsUniqueUser(registerationRequestDTO.Username);
            if (isUsernameUnique == false)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            if (registerationRequestDTO.Username.IsNullOrEmpty() || registerationRequestDTO.Password.IsNullOrEmpty())
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username and Password cannot be null or empty");
                return BadRequest(_response);
            }

            var user = await _dbUser.Register(registerationRequestDTO);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("User is null.");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = user;
            _response.ErrorMessages.Clear();
            return Ok(_response);
        }
        [HttpPut("{id:int}", Name = "Update")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody]UserUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("id does not match.");
                    return BadRequest(_response);
                }

                var user = await _dbUser.GetAsync(u => u.Id == id);

                user.PhoneNumber = updateDTO.PhoneNumber;
                user.Email = updateDTO.Email;

                await _dbUser.UpdateAsync(user);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = updateDTO;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
