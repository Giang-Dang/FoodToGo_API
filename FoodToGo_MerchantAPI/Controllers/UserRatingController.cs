﻿using AutoMapper;
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
using Microsoft.IdentityModel.Tokens;
using FoodToGo_API.Models.Enums;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Eventing.Reader;

namespace FoodToGo_API.Controllers
{
    [Route("api/UserRatingAPI")]
    [ApiController]
    public class UserRatingController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUserRatingRepository _dbUserRating;
        private readonly IMapper _mapper;
        public UserRatingController(
            IUserRatingRepository dbUserRating,
            IMapper mapper)
        {
            _mapper = mapper;
            _dbUserRating = dbUserRating;
            this._response = new APIResponse();
        }

        [HttpGet(Name = "GetAllUserRatings")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllUserRatings(
            int? fromUserId,
            string? fromUserType,
            int? toUserId,
            string? toUserType,
            int? orderId,
            double? rating,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<UserRating> userRatingList = await _dbUserRating.GetAllAsync(null, pageSize, pageNumber);

                if (fromUserId.HasValue) { 
                    if (fromUserId > 0)
                    {
                        userRatingList = userRatingList.Where(ur => ur.FromUserId == fromUserId).ToList();
                    }
                }

                if (fromUserType.IsNullOrEmpty()) 
                { 
                    if(Enum.IsDefined(typeof(UserType), fromUserType) )
                    {
                        userRatingList = userRatingList.Where(ur => ur.FromUserType == fromUserType).ToList();
                    }
                }

                if (toUserId.HasValue)
                {
                    if (toUserId > 0)
                    {
                        userRatingList = userRatingList.Where(ur => ur.ToUserId == toUserId).ToList();
                    }
                }

                if (toUserType.IsNullOrEmpty())
                {
                    if (Enum.IsDefined(typeof(UserType), toUserType))
                    {
                        userRatingList = userRatingList.Where(ur => ur.ToUserType == toUserType).ToList();
                    }
                }

                if(orderId.HasValue)
                {
                    if(orderId > 0)
                    {
                        userRatingList = userRatingList.Where(ur => ur.OrderId == orderId).ToList();
                    }
                }

                if(rating.HasValue)
                {
                    if (rating > 0)
                    {
                        userRatingList = userRatingList.Where(ur => ur.Rating == rating).ToList();
                    }
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<UserRating>>(userRatingList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("avgrating", Name = "GetAvgUserRating")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAvgUserRating(int toUserId, string asType)
        {
            try
            {
                asType = char.ToUpper(asType[0]) + asType.Substring(1);

                if (!Enum.IsDefined(typeof(UserType), asType))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid asType.");
                    return BadRequest(_response);
                }

                if (toUserId <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid MemuItemImage ID.");
                    return BadRequest(_response);
                }

                var userRatingList = await _dbUserRating.GetAllAsync(c => c.ToUserId == toUserId && c.ToUserType == asType);

                if (userRatingList.IsNullOrEmpty())
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Result = 0;
                    return Ok(_response);
                }

                double sum = 0;

                foreach (var rating in userRatingList)
                {
                    sum += rating.Rating;
                }

                double avgRating = sum / userRatingList.Count;

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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateUserRating([FromBody] UserRatingCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The userRating entity cannot be null!");
                    return BadRequest(createDTO);
                }

                UserRating userRating = _mapper.Map<UserRating>(createDTO);

                await _dbUserRating.CreateAsync(userRating);

                UserRatingDTO userRatingDTO = _mapper.Map<UserRatingDTO>(userRating);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = userRatingDTO;
                return CreatedAtRoute("GetAvgUserRating", new { id = userRating.Id , asType = userRating.ToUserType }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteUserRating")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteUserRating(int id)
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

                var userRating = await _dbUserRating.GetAsync(m => m.Id == id);
                if (userRating == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("UserRating is not found!");
                    return NotFound(_response);
                }
                await _dbUserRating.RemoveAsync(userRating);

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

        [HttpPut("{id:int}", Name = "UpdateUserRating")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateUserRating(int id, [FromBody] UserRatingUpdateDTO updateDTO)
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

                var userRating = _mapper.Map<UserRating>(updateDTO);

                await _dbUserRating.UpdateAsync(userRating);
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
