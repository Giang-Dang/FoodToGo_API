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
    [Route("api/OnlineCustomerLocationAPI")]
    [ApiController]
    public class OnlineCustomerLocationController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IOnlineCustomerLocationRepository _dbOnlineCustomerLocation;
        private readonly IMapper _mapper;
        public OnlineCustomerLocationController(
            IOnlineCustomerLocationRepository dbOnlineCustomerLocation,
            IMapper mapper)
        {
            _mapper = mapper;
            _dbOnlineCustomerLocation = dbOnlineCustomerLocation;
            this._response = new APIResponse();
        }

        [HttpGet(Name = "GetAllOnlineCustomerLocations")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllOnlineCustomerLocations(
            double? startLatitude = null,
            double? startLongitude = null,
            double? searchDistanceInKm = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<OnlineCustomerLocation> onlineCustomerLocationList = await _dbOnlineCustomerLocation.GetAllAsync(null, pageSize, pageNumber);

                //filter by distance
                if (startLatitude.HasValue && startLongitude.HasValue && searchDistanceInKm.HasValue)
                {
                    List<OnlineCustomerLocation> customersWithinDistance = new();
                    foreach (var c in onlineCustomerLocationList)
                    {
                        double distance = Math.Sqrt(
                            Math.Pow(111.2 * (c.GeoLatitude - startLatitude.Value), 2) +
                            Math.Pow(111.2 * (startLongitude.Value - c.GeoLongitude) * Math.Cos(c.GeoLatitude / 57.3), 2)
                        );
                        if (distance <= searchDistanceInKm.Value)
                        {
                            customersWithinDistance.Add(c);
                        }
                    }

                    onlineCustomerLocationList = new(customersWithinDistance);
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<OnlineCustomerLocation>>(onlineCustomerLocationList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetOnlineCustomerLocation")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetOnlineCustomerLocation(int id)
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

                var onlineCustomerLocation = await _dbOnlineCustomerLocation.GetAsync(c => c.CustomerId == id);
                if (onlineCustomerLocation == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("OnlineCustomerLocation is not found.");
                    return NotFound(_response);
                }

                var onlineCustomerLocationDTO = _mapper.Map<OnlineCustomerLocationDTO>(onlineCustomerLocation);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = onlineCustomerLocationDTO;

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
        [CustomAuthorize("LoginFromApp", "Customer", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateOnlineCustomerLocation([FromBody] OnlineCustomerLocationCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The onlineCustomerLocation entity cannot be null!");
                    return BadRequest(createDTO);
                }

                OnlineCustomerLocation onlineCustomerLocation = _mapper.Map<OnlineCustomerLocation>(createDTO);

                await _dbOnlineCustomerLocation.CreateAsync(onlineCustomerLocation);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = onlineCustomerLocation;
                return CreatedAtRoute("GetOnlineCustomerLocation", new { id = onlineCustomerLocation.CustomerId }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteOnlineCustomerLocation")]
        [CustomAuthorize("LoginFromApp", "Customer", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteOnlineCustomerLocation(int id)
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

                var onlineCustomerLocation = await _dbOnlineCustomerLocation.GetAsync(m => m.CustomerId == id);
                if (onlineCustomerLocation == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("OnlineCustomerLocation is not found!");
                    return NotFound(_response);
                }
                await _dbOnlineCustomerLocation.RemoveAsync(onlineCustomerLocation);

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

        [HttpPut("{id:int}", Name = "UpdateOnlineCustomerLocation")]
        [CustomAuthorize("LoginFromApp", "Customer", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateOnlineCustomerLocation(int id, [FromBody] OnlineCustomerLocationUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.CustomerId)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Bad Request!");
                    return BadRequest(updateDTO);
                }

                var onlineCustomerLocation = _mapper.Map<OnlineCustomerLocation>(updateDTO);

                await _dbOnlineCustomerLocation.UpdateAsync(onlineCustomerLocation);
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
