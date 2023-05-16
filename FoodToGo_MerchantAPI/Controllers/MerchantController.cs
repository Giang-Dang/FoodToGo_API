using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
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

        [HttpGet]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllMerchants(
            [FromQuery(Name = "OpenHoursCheckTime")] DateTime? openHoursCheckTime,
            [FromQuery(Name = "SearchName")] string? searchName, 
            [FromQuery(Name = "NearbyCheckGeoLatitude")] double? nearbyCheckGeoLatitude,
            [FromQuery(Name = "NearbyCheckGeoLongtitude")] double? nearbyCheckGeoLongtitude,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<Merchant> merchantList = await _dbMerchant.GetAllAsync(null, pageSize, pageNumber);

                List<Merchant> openMerchantList = new();
                if (openHoursCheckTime.HasValue)
                {
                    foreach(Merchant merchant in merchantList)
                    {
                        if(await IsMerchantOpen(merchant, openHoursCheckTime.Value))
                        {
                            openMerchantList.Add(merchant);
                        }
                    }
                    merchantList = new(openMerchantList);
                }

                if(!string.IsNullOrEmpty(searchName))
                {
                    searchName = searchName.ToLower();
                    merchantList = merchantList.Where(m => m.Name.ToLower().Contains(searchName)).ToList();
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
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetMerchant(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("id cannot be 0.");
                    return BadRequest(_response);
                }

                var merchant = await _dbMerchant.GetAsync(m => m.MerchantId == id);
                var normalOpenHoursList = await _dbNormalOpenHours.GetAllAsync(n => n.MerchantId == id);
                var overrideOpenHoursList = await _dbOverrideOpenHours.GetAllAsync(o => o.MerchantId == id);
                if (merchant == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Merchant is not found.");
                    return NotFound(_response);
                }

                var merchantDTO = _mapper.Map<MerchantDTO>(merchant);
                var normalOpenHoursListDTO = _mapper.Map<List<NormalOpenHoursDTO>>(normalOpenHoursList);
                var overrideOpenHoursListDTO = _mapper.Map<List<OverrideOpenHoursDTO>>(overrideOpenHoursList);
                merchantDTO.NormalOpenHoursList = normalOpenHoursListDTO;
                merchantDTO.OverrideOpenHoursList = overrideOpenHoursListDTO;

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

        private async Task<bool> IsMerchantOpen(Merchant merchant, DateTime checkDateTime)
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
                    return checkDateTime.TimeOfDay >= overrideHour.AltOpenTime.TimeOfDay && checkDateTime.TimeOfDay <= overrideHour.AltCloseTime.TimeOfDay;
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
    }
}
