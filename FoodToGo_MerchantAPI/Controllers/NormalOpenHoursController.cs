using AutoMapper;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO.CreateDTO;
using FoodToGo_API.Models.DTO.UpdateDTO;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FoodToGo_API.Controllers
{
    [Route("api/NormalOpenHoursAPI")]
    [ApiController]
    public class NormalOpenHoursController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly INormalOpenHoursRepository _dbNormalOpenHours;
        public NormalOpenHoursController(
            INormalOpenHoursRepository dbNormalOpenHours,
            IMapper mapper)
        {
            _mapper = mapper;
            this._response = new APIResponse();
            _dbNormalOpenHours = dbNormalOpenHours;
        }

        [HttpGet(Name = "GetAllNormalOpenHours")]
        [Authorize]
        [ResponseCache(Duration = 1000)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllNormalOpenHours(
            int? searchMerchanId = null,
            int? searchDayOfWeek = null,
            int? searchSessionNo = null,
            DateTime? searchOpenTime = null,
            DateTime? searchCloseTime = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<NormalOpenHours> normalOpenHoursList = await _dbNormalOpenHours.GetAllAsync(null, pageSize, pageNumber);

                if (searchMerchanId.HasValue)
                {
                    if (searchMerchanId > 0)
                    {
                        normalOpenHoursList = normalOpenHoursList.Where(b => b.MerchantId == searchMerchanId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid Merchant Id!");
                        return BadRequest(_response);
                    }
                }

                if (searchDayOfWeek.HasValue)
                {
                    if (searchDayOfWeek > 0)
                    {
                        normalOpenHoursList = normalOpenHoursList.Where(b => b.DayOfWeek == searchDayOfWeek).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid searchDayOfWeek!");
                        return BadRequest(_response);
                    }
                }

                if (searchSessionNo.HasValue)
                {
                    if (searchSessionNo > 0)
                    {
                        normalOpenHoursList = normalOpenHoursList.Where(b => b.SessionNo == searchSessionNo).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid searchSessionNo!");
                        return BadRequest(_response);
                    }
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<NormalOpenHours>>(normalOpenHoursList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetNormalOpenHours")]
        [Authorize]
        [ResponseCache(Duration = 1000)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetNormalOpenHours(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid NormalOpenHours ID.");
                    return BadRequest(_response);
                }

                var normalOpenHours = await _dbNormalOpenHours.GetAsync(b => b.Id == id);
                if (normalOpenHours == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("NormalOpenHours is not found.");
                    return NotFound(_response);
                }

                var normalOpenHoursDTO = _mapper.Map<NormalOpenHoursDTO>(normalOpenHours);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = normalOpenHoursDTO;

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
        public async Task<ActionResult<APIResponse>> CreateNormalOpenHours([FromBody] NormalOpenHoursCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The normalOpenHours entity cannot be null!");
                    return BadRequest(createDTO);
                }

                NormalOpenHours normalOpenHours = _mapper.Map<NormalOpenHours>(createDTO);

                await _dbNormalOpenHours.CreateAsync(normalOpenHours);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = normalOpenHours;
                return CreatedAtRoute("GetNormalOpenHours", new { id = normalOpenHours.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteNormalOpenHours")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteNormalOpenHours(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid NormalOpenHours ID.");
                    return BadRequest(_response);
                }

                var normalOpenHours = await _dbNormalOpenHours.GetAsync(m => m.Id == id);
                if (normalOpenHours == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("NormalOpenHours is not found!");
                    return NotFound(_response);
                }
                await _dbNormalOpenHours.RemoveAsync(normalOpenHours);

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

        [HttpPut("{id:int}", Name = "UpdateNormalOpenHours")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateNormalOpenHours(int id, [FromBody] NormalOpenHoursUpdateDTO updateDTO)
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

                var normalOpenHours = _mapper.Map<NormalOpenHours>(updateDTO);

                await _dbNormalOpenHours.UpdateAsync(normalOpenHours);
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
