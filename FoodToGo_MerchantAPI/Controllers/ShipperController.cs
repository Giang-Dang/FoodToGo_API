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
    [Route("api/ShipperAPI")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IShipperRepository _dbShipper;
        private readonly IOnlineShipperStatusRepository _dbOnlineShipperStatus;
        private readonly IMapper _mapper;
        public ShipperController(
            IShipperRepository dbShipper, 
            IOnlineShipperStatusRepository dbOnlineShipperStatus, 
            IMapper mapper)
        {
            _dbShipper = dbShipper;
            _mapper = mapper;
            _dbOnlineShipperStatus = dbOnlineShipperStatus;
            this._response = new APIResponse();
        }

        [HttpGet(Name = "GetAllShippers")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllShippers(
            string? searchName = null,
            string? searchVehicleType = null,
            string? searchVehicleNumberPlate = null,
            bool? IsAvailable = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<Shipper> shipperList = await _dbShipper.GetAllAsync(null, pageSize, pageNumber);

                if (string.IsNullOrEmpty(searchName) == false)
                {
                    searchName = searchName.ToLower();
                    shipperList = shipperList.Where(s => $"{s.LastName} {s.MiddleName} {s.FirstName}".ToLower().Contains(searchName)).ToList();
                }

                if (string.IsNullOrEmpty(searchVehicleType) == false)
                {
                    searchVehicleType = searchVehicleType.ToLower();
                    shipperList = shipperList.Where(s => s.VehicleType.ToLower().Contains(searchVehicleType)).ToList();
                }

                if (string.IsNullOrEmpty(searchVehicleNumberPlate) == false)
                {
                    searchVehicleNumberPlate = searchVehicleNumberPlate.ToLower();
                    shipperList = shipperList.Where(s => s.VehicleNumberPlate.ToLower().Contains(searchVehicleNumberPlate)).ToList();
                }

                if (IsAvailable.HasValue)
                {
                    shipperList = await GetAvailableShippersAsync(shipperList);
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<ShipperDTO>>(shipperList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetShipper")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetShipper(int id)
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

                var shipper = await _dbShipper.GetAsync(s => s.UserId == id);
                if (shipper == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Shipper is not found.");
                    return NotFound(_response);
                }

                var shipperDTO = _mapper.Map<ShipperDTO>(shipper);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = shipperDTO;

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
        public async Task<ActionResult<APIResponse>> CreateShipper([FromBody] ShipperCreateDTO createDTO)
        {
            try
            {
                if (await _dbShipper.GetAsync(s => s.VehicleNumberPlate.ToLower() == createDTO.VehicleNumberPlate.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("This vehicle’s number plate already exists!");
                    return BadRequest(_response);
                }
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The shipper entity cannot be null!");
                    return BadRequest(createDTO);
                }

                Shipper shipper = _mapper.Map<Shipper>(createDTO);

                await _dbShipper.CreateAsync(shipper);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = shipper;
                return CreatedAtRoute("GetShipper", new { id = shipper.UserId }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteShipper")]
        [CustomAuthorize("LoginFromApp", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteShipper(int id)
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

                var shipper = await _dbShipper.GetAsync(m => m.UserId == id);
                if (shipper == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Shipper is not found!");
                    return NotFound(_response);
                }
                await _dbShipper.RemoveAsync(shipper);

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

        [HttpPut("{id:int}", Name = "UpdateShipper")]
        [CustomAuthorize("LoginFromApp", "Shipper", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateShipper(int id, [FromBody] ShipperUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.UserId)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Bad Request!");
                    return BadRequest(updateDTO);
                }

                var shipper = _mapper.Map<Shipper>(updateDTO);

                await _dbShipper.UpdateAsync(shipper);
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

        private async Task<bool> IsShipperAvailableAsync(Shipper shipper)
        {
            var onlineShipperStatus = await _dbOnlineShipperStatus.GetAsync(o => o.ShipperId == shipper.UserId);
            return onlineShipperStatus.IsAvailable;
        }
        private async Task<List<Shipper>> GetAvailableShippersAsync(List<Shipper> shipperList)
        {
            List<Shipper> availableShipperList = new();
            foreach (Shipper shipper in shipperList)
            {
                if (await IsShipperAvailableAsync(shipper))
                {
                    availableShipperList.Add(shipper);
                }
            }
            return availableShipperList;
        }
    }
}
