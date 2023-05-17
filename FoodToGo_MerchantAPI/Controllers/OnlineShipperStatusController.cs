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
    [Route("api/OnlineShipperStatusAPI")]
    [ApiController]
    public class OnlineShipperStatusController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IOnlineShipperStatusRepository _dbOnlineShipperStatus;
        private readonly IMapper _mapper;
        public OnlineShipperStatusController(
            IOnlineShipperStatusRepository dbOnlineShipperStatus,
            IMapper mapper)
        {
            _mapper = mapper;
            _dbOnlineShipperStatus = dbOnlineShipperStatus;
            this._response = new APIResponse();
        }

        [HttpGet(Name = "GetAllOnlineShipperStatuses")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllOnlineShipperStatuses(
            bool? IsAvailable = null,
            [FromQuery(Name = "StartLatitude")] double? startLatitude = null,
            [FromQuery(Name = "StartLongitude")] double? startLongitude = null,
            [FromQuery(Name = "distanceInKm")] double? searchDistanceInKm = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<OnlineShipperStatus> onlineShipperStatusList = await _dbOnlineShipperStatus.GetAllAsync(null, pageSize, pageNumber);


                if (IsAvailable.HasValue)
                {
                    onlineShipperStatusList = onlineShipperStatusList.Where(o => o.IsAvailable).ToList();
                }

                //filter by distance
                if (startLatitude.HasValue && startLongitude.HasValue && searchDistanceInKm.HasValue)
                {
                    List<OnlineShipperStatus> shippersWithinDistance = new();
                    foreach (var s in onlineShipperStatusList)
                    {
                        double distance = Math.Sqrt(
                            Math.Pow(111.2 * (s.GeoLatitude - startLatitude.Value), 2) +
                            Math.Pow(111.2 * (startLongitude.Value - s.GeoLongitude) * Math.Cos(s.GeoLatitude / 57.3), 2)
                        );
                        if (distance <= searchDistanceInKm.Value)
                        {
                            shippersWithinDistance.Add(s);
                        }
                    }

                    onlineShipperStatusList = new(shippersWithinDistance);
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<OnlineShipperStatus>>(onlineShipperStatusList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetOnlineShipperStatus")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetOnlineShipperStatus(int id)
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

                var onlineShipperStatus = await _dbOnlineShipperStatus.GetAsync(c => c.ShipperId == id);
                if (onlineShipperStatus == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("OnlineShipperStatus is not found.");
                    return NotFound(_response);
                }

                var onlineShipperStatusDTO = _mapper.Map<OnlineShipperStatusDTO>(onlineShipperStatus);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = onlineShipperStatusDTO;

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
        [CustomAuthorize("LoginFromApp", "Shipper", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateOnlineShipperStatus([FromBody] OnlineShipperStatusCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The onlineShipperStatus entity cannot be null!");
                    return BadRequest(createDTO);
                }

                OnlineShipperStatus onlineShipperStatus = _mapper.Map<OnlineShipperStatus>(createDTO);

                await _dbOnlineShipperStatus.CreateAsync(onlineShipperStatus);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = createDTO;
                return CreatedAtRoute("GetOnlineShipperStatus", new { id = onlineShipperStatus.ShipperId }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteOnlineShipperStatus")]
        [CustomAuthorize("LoginFromApp", "Shipper", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteOnlineShipperStatus(int id)
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

                var onlineShipperStatus = await _dbOnlineShipperStatus.GetAsync(m => m.ShipperId == id);
                if (onlineShipperStatus == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("OnlineShipperStatus is not found!");
                    return NotFound(_response);
                }
                await _dbOnlineShipperStatus.RemoveAsync(onlineShipperStatus);

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

        [HttpPut("{id:int}", Name = "UpdateOnlineShipperStatus")]
        [CustomAuthorize("LoginFromApp", "Shipper", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateOnlineShipperStatus(int id, [FromBody] OnlineShipperStatusUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.ShipperId)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Bad Request!");
                    return BadRequest(updateDTO);
                }

                var onlineShipperStatus = _mapper.Map<OnlineShipperStatus>(updateDTO);

                await _dbOnlineShipperStatus.UpdateAsync(onlineShipperStatus);
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
