using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models.DTO.CreateDTO;
using FoodToGo_API.Models.DTO.UpdateDTO;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace FoodToGo_API.Controllers
{
    [Route("api/MerchantAPI")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMerchantRepository _dbMerchant;
        private readonly INormalOpenHoursRepository _dbNormalOpenHours;
        private readonly IOverrideOpenHoursRepository _dbOverrideOpenHours;
        private readonly IMapper _mapper;
        public MerchantController(
            IMerchantRepository dbMerchant,
            IOverrideOpenHoursRepository dbOverrideOpenHours,
            INormalOpenHoursRepository dbNormalOpenHours, 
            IMapper mapper)
        {
            _dbMerchant = dbMerchant;
            _dbNormalOpenHours = dbNormalOpenHours;
            _dbOverrideOpenHours = dbOverrideOpenHours;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet(Name = "GetAllMerchants")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllMerchants(
            [FromQuery(Name = "OpenHoursCheckTime")] DateTime? openHoursCheckTime = null,
            [FromQuery(Name = "SearchName")] string? searchName = null, 
            [FromQuery(Name = "StartLatitude")] double? startLatitude = null,
            [FromQuery(Name = "StartLongitude")] double? startLongitude = null,
            [FromQuery(Name = "distanceInKm")] double? searchDistanceInKm = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<Merchant> merchantList = await _dbMerchant.GetAllAsync(null, pageSize, pageNumber);

                if (openHoursCheckTime.HasValue)
                {
                    merchantList = await GetOpenMerchantsAsync(merchantList, openHoursCheckTime.Value);
                }

                if(!string.IsNullOrEmpty(searchName))
                {
                    searchName = searchName.ToLower();
                    merchantList = merchantList.Where(m => m.Name.ToLower().Contains(searchName)).ToList();
                }

                //filter by distance
                if (startLatitude.HasValue && startLongitude.HasValue && searchDistanceInKm.HasValue)
                {
                    List<Merchant> merchantsWithinDistance = new();
                    foreach (var m in merchantList)
                    {
                        double distance = Math.Sqrt(
                            Math.Pow(111.2 * (m.GeoLatitude - startLatitude.Value), 2) +
                            Math.Pow(111.2 * (startLongitude.Value - m.GeoLongitude) * Math.Cos(m.GeoLatitude / 57.3), 2)
                        );
                        if (distance <= searchDistanceInKm.Value)
                        {
                            merchantsWithinDistance.Add(m);
                        }
                    }

                    merchantList = new(merchantsWithinDistance);
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<MerchantDTO>>(merchantList);
                
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetMerchant")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetMerchant(int id)
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

                var merchant = await _dbMerchant.GetAsync(m => m.MerchantId == id);
                if (merchant == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Merchant is not found.");
                    return NotFound(_response);
                }

                var merchantDTO = _mapper.Map<MerchantDTO>(merchant);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = merchantDTO;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("byuser/{id:int}", Name = "GetMerchantByUserId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllMerchantsByUserId(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("User id cannot be 0.");
                    return BadRequest(_response);
                }

                var merchantList = await _dbMerchant.GetAllAsync(m => m.UserId == id);

                if (merchantList == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Merchant is not found.");
                    return NotFound(_response);
                }

                var merchantDTO = _mapper.Map<List<MerchantDTO>>(merchantList);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = merchantDTO;

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
        public async Task<ActionResult<APIResponse>> CreateMerchant([FromBody] MerchantCreateDTO createDTO)
        {
            try
            {
                if (await _dbMerchant.GetAsync(m => m.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Merchant already exists!");
                    return BadRequest(_response);
                }
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Merchant cannot be null!");
                    return BadRequest(createDTO);
                }

                Merchant merchant = _mapper.Map<Merchant>(createDTO);

                await _dbMerchant.CreateAsync(merchant);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = createDTO;
                return CreatedAtRoute("GetMerchant", new { id = merchant.MerchantId }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteMerchant")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteMerchant(int id)
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

                var merchant = await _dbMerchant.GetAsync(m => m.MerchantId == id);
                if (merchant == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Merchant is not found!");
                    return NotFound(_response);
                }
                await _dbMerchant.RemoveAsync(merchant);

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

        [HttpPut("{id:int}", Name = "UpdateMerchant")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateMerchant(int id, [FromBody]MerchantUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.MerchantId)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Bad Request!");
                    return BadRequest(updateDTO);
                }

                var merchant = _mapper.Map<Merchant>(updateDTO);

                await _dbMerchant.UpdateAsync(merchant);
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
        private async Task<bool> IsMerchantOpenAsync(Merchant merchant, DateTime checkDateTime)
        {
            
            var overrideHours = await _dbOverrideOpenHours.GetAllAsync(
                o => o.MerchantId == merchant.MerchantId && 
                o.OverrideStartDate <= checkDateTime && 
                o.OverrideEndDate >= checkDateTime
                );
            if(overrideHours.Any())
            {
                var overrideHour = overrideHours.First();
                if (overrideHour.IsClosed)
                {
                    return false;
                }
                else
                {
                    return checkDateTime.TimeOfDay >= overrideHour.AltOpenTime.Value.TimeOfDay && checkDateTime.TimeOfDay <= overrideHour.AltCloseTime.Value.TimeOfDay;
                }
            }

            int dayOfWeek = (int)checkDateTime.DayOfWeek;
            var normalOpenHours = await _dbNormalOpenHours.GetAllAsync(
                n => n.MerchantId == merchant.MerchantId &&
                n.DayOfWeek == dayOfWeek &&
                checkDateTime.TimeOfDay >= n.OpenTime.TimeOfDay &&
                checkDateTime.TimeOfDay <= n.CloseTime.TimeOfDay
                );
            if(normalOpenHours.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<List<Merchant>> GetOpenMerchantsAsync(List<Merchant> merchantList, DateTime openHoursCheckTime)
        {
            List<Merchant> openMerchantList = new();
            foreach (Merchant merchant in merchantList)
            {
                if (await IsMerchantOpenAsync(merchant, openHoursCheckTime))
                {
                    openMerchantList.Add(merchant);
                }
            }
            return openMerchantList;
        }
    }
}
