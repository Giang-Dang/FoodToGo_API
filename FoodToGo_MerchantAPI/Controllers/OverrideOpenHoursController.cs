using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models.DTO.CreateDTO;
using FoodToGo_API.Models.DTO.UpdateDTO;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FoodToGo_API.Controllers
{
    [Route("api/OverrideOpenHoursAPI")]
    [ApiController]
    public class OverrideOpenHoursController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IOverrideOpenHoursRepository _dbOverrideOpenHours;
        public OverrideOpenHoursController(
            IOverrideOpenHoursRepository dbOverrideOpenHours,
            IMapper mapper)
        {
            _mapper = mapper;
            this._response = new APIResponse();
            _dbOverrideOpenHours = dbOverrideOpenHours;
        }

        [HttpGet(Name = "GetAllOverrideOpenHours")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllOverrideOpenHours(
            int? searchMerchanId = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<OverrideOpenHours> overrideOpenHoursList = await _dbOverrideOpenHours.GetAllAsync(null, pageSize, pageNumber);

                if (searchMerchanId.HasValue)
                {
                    if (searchMerchanId > 0)
                    {
                        overrideOpenHoursList = overrideOpenHoursList.Where(b => b.MerchantId == searchMerchanId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid Merchant Id!");
                        return BadRequest(_response);
                    }
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<OverrideOpenHours>>(overrideOpenHoursList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetOverrideOpenHours")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetOverrideOpenHours(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid OverrideOpenHours ID.");
                    return BadRequest(_response);
                }

                var overrideOpenHours = await _dbOverrideOpenHours.GetAsync(b => b.Id == id);
                if (overrideOpenHours == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("OverrideOpenHours is not found.");
                    return NotFound(_response);
                }

                var overrideOpenHoursDTO = _mapper.Map<OverrideOpenHoursDTO>(overrideOpenHours);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = overrideOpenHoursDTO;

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
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateOverrideOpenHours([FromBody] OverrideOpenHoursCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The overrideOpenHours entity cannot be null!");
                    return BadRequest(createDTO);
                }

                OverrideOpenHours overrideOpenHours = _mapper.Map<OverrideOpenHours>(createDTO);

                await _dbOverrideOpenHours.CreateAsync(overrideOpenHours);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = createDTO;
                return CreatedAtRoute("GetOverrideOpenHours", new { id = overrideOpenHours.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteOverrideOpenHours")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteOverrideOpenHours(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid OverrideOpenHours ID.");
                    return BadRequest(_response);
                }

                var overrideOpenHours = await _dbOverrideOpenHours.GetAsync(m => m.Id == id);
                if (overrideOpenHours == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("OverrideOpenHours is not found!");
                    return NotFound(_response);
                }
                await _dbOverrideOpenHours.RemoveAsync(overrideOpenHours);

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

        [HttpPut("{id:int}", Name = "UpdateOverrideOpenHours")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateOverrideOpenHours(int id, [FromBody] OverrideOpenHoursUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Bad Request!");
                    return BadRequest(updateDTO);
                }

                var overrideOpenHours = _mapper.Map<OverrideOpenHours>(updateDTO);

                await _dbOverrideOpenHours.UpdateAsync(overrideOpenHours);
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
