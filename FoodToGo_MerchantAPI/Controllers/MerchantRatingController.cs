using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models.DTO.CreateDTO;
using FoodToGo_API.Models.DTO.UpdateDTO;
using FoodToGo_API.Models.Enums;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Json;

namespace FoodToGo_API.Controllers
{

    [Route("api/MerchantRatingAPI")]
    [ApiController]
    public class MerchantRatingController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMerchantRatingRepository _dbMerchantRating;
        private readonly IMapper _mapper;
        public MerchantRatingController(
            IMerchantRatingRepository dbMerchantRating,
            IMapper mapper)
        {
            _mapper = mapper;
            _dbMerchantRating = dbMerchantRating;
            this._response = new APIResponse();
        }

        [HttpGet(Name = "GetAllMerchantRatings")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllMerchantRatings(
            int? fromUserId,
            string? fromUserType,
            int? toMerchantId,
            int? orderId,
            double? minRating,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<MerchantRating> merchantRatingList = await _dbMerchantRating.GetAllAsync(null, pageSize, pageNumber);

                if (fromUserId.HasValue)
                {
                    merchantRatingList = merchantRatingList.Where(ur => ur.FromUserId == fromUserId.Value).ToList();
                }

                if (!fromUserType.IsNullOrEmpty())
                {
                    if (Enum.IsDefined(typeof(UserType), fromUserType))
                    {
                        merchantRatingList = merchantRatingList.Where(ur => ur.FromUserType == fromUserType).ToList();
                    }
                }

                if (toMerchantId.HasValue)
                {
                    merchantRatingList = merchantRatingList.Where(ur => ur.ToMerchantId == toMerchantId.Value).ToList();
                }

                if (orderId.HasValue)
                {
                    merchantRatingList = merchantRatingList.Where(ur => ur.OrderId == orderId.Value).ToList();
                }

                if(minRating.HasValue)
                {
                    merchantRatingList = merchantRatingList.Where(ur => ur.Rating >= minRating.Value).ToList();
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<MerchantRating>>(merchantRatingList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("avgrating", Name = "GetAvgMerchantRating")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAvgMerchantRating(int toMerchantId)
        {
            try
            {

                if (toMerchantId <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid toMerchant ID.");
                    return BadRequest(_response);
                }

                var merchantRatingList = await _dbMerchantRating.GetAllAsync(c => c.ToMerchantId == toMerchantId);

                if (merchantRatingList.IsNullOrEmpty())
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Result = 0;
                    return Ok(_response);
                }

                double sum = 0;

                foreach (var rating in merchantRatingList)
                {
                    sum += rating.Rating;
                }

                double avgRating = sum / merchantRatingList.Count;

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = avgRating;

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
        [CustomAuthorize("LoginFromApp", "Customer", "Shipper", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateMerchantRating([FromBody] MerchantRatingCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The merchantRating entity cannot be null!");
                    return BadRequest(createDTO);
                }

                MerchantRating merchantRating = _mapper.Map<MerchantRating>(createDTO);

                await _dbMerchantRating.CreateAsync(merchantRating);

                MerchantRatingDTO merchantRatingDTO = _mapper.Map<MerchantRatingDTO>(merchantRating);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = merchantRatingDTO;
                return CreatedAtRoute("GetAvgMerchantRating", new { id = merchantRating.Id}, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteMerchantRating")]
        [CustomAuthorize("LoginFromApp", "Customer", "Shipper", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteMerchantRating(int id)
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

                var merchantRating = await _dbMerchantRating.GetAsync(m => m.Id == id);
                if (merchantRating == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("MerchantRating is not found!");
                    return NotFound(_response);
                }
                await _dbMerchantRating.RemoveAsync(merchantRating);

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

        [HttpPut("{id:int}", Name = "UpdateMerchantRating")]
        [CustomAuthorize("LoginFromApp", "Customer", "Shipper", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateMerchantRating(int id, [FromBody] MerchantRatingUpdateDTO updateDTO)
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

                var merchantRating = _mapper.Map<MerchantRating>(updateDTO);

                await _dbMerchantRating.UpdateAsync(merchantRating);
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
