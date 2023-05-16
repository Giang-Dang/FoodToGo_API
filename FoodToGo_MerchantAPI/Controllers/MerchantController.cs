using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoodToGo_API.Controllers
{
    public class MerchantController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMerchantRepository _dbMerchant;
        private readonly IMapper _mapper;
        public MerchantController(IMerchantRepository dbMerchant, IMapper mapper)
        {
            _dbMerchant = dbMerchant;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [Authorize]
        [CustomAuthorize("LoginFromApp", "Management")]
        [CustomAuthorize("LoginFromApp", "Merchant")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetMerchants(
            [FromQuery(Name = "OpenHoursCheckTime")] DateTime? openHoursCheckTime,
            [FromQuery(Name = "SearchName")] string? searchName, 
            [FromQuery(Name = "NearbyCheckGeoLatitude")] double? nearbyCheckGeoLatitude,
            [FromQuery(Name = "NearbyCheckGeoLongtitude")] double? nearbyCheckGeoLongtitude,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
