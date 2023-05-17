using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO.CreateDTO;
using FoodToGo_API.Models.DTO.UpdateDTO;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FoodToGo_API.Controllers
{
    [Route("api/BanAPI")]
    [ApiController]
    public class BanController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IBanRepository _dbBan;
        public BanController(
            IBanRepository dbBan,
            IMapper mapper)
        {
            _mapper = mapper;
            this._response = new APIResponse();
            _dbBan = dbBan;
        }

        [HttpGet(Name = "GetAllBans")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllBans(
            int? searchUserId,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<Ban> banList = await _dbBan.GetAllAsync(null, pageSize, pageNumber);

                if(searchUserId.HasValue)
                {
                    if (searchUserId > 0)
                    {
                        banList = banList.Where(b => b.UserId == searchUserId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid User Id!");
                        return BadRequest(_response);
                    }
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<Ban>>(banList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetBan")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetBan(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid Ban ID.");
                    return BadRequest(_response);
                }

                var ban = await _dbBan.GetAsync(b => b.BanId == id);
                if (ban == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Ban is not found.");
                    return NotFound(_response);
                }

                var banDTO = _mapper.Map<BanDTO>(ban);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = banDTO;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("byuser/{id:int}", Name = "GetBanByUserId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetBanByUserId(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("ID cannot be 0.");
                    return BadRequest(_response);
                }

                var ban = await _dbBan.GetAsync(b => b.UserId == id);
                if (ban == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Ban is not found.");
                    return NotFound(_response);
                }

                var banDTO = _mapper.Map<BanDTO>(ban);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = banDTO;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateBan([FromBody] BanCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The ban entity cannot be null!");
                    return BadRequest(createDTO);
                }

                Ban ban = _mapper.Map<Ban>(createDTO);

                await _dbBan.CreateAsync(ban);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = createDTO;
                return CreatedAtRoute("GetBan", new { id = ban.BanId }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteBan")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteBan(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("ID cannot be 0.");
                    return BadRequest(_response);
                }

                var ban = await _dbBan.GetAsync(m => m.BanId == id);
                if (ban == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Ban is not found!");
                    return NotFound(_response);
                }
                await _dbBan.RemoveAsync(ban);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return NoContent();
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateBan")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateBan(int id, [FromBody] BanUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.BanId)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Bad Request!");
                    return BadRequest(updateDTO);
                }

                var ban = _mapper.Map<Ban>(updateDTO);

                await _dbBan.UpdateAsync(ban);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }

            return _response;
        }
    }
}
