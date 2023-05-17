using AutoMapper;
using FoodToGo_API.Models;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO.CreateDTO;
using FoodToGo_API.Models.DTO.UpdateDTO;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Text.Json;
using System.Diagnostics;

namespace FoodToGo_API.Controllers
{
    [Route("api/MenuItemAPI")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _dbMenuItem;
        public MenuItemController(
            IMenuItemRepository dbMenuItem,
            IMapper mapper)
        {
            _mapper = mapper;
            this._response = new APIResponse();
            _dbMenuItem = dbMenuItem;
        }

        [HttpGet(Name = "GetAllMenuItems")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllMenuItems(
            int? searchMerchanId = null,
            int? searchItemTypeId = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<MenuItem> menuItemList = await _dbMenuItem.GetAllAsync(null, pageSize, pageNumber);

                if (searchMerchanId.HasValue)
                {
                    if (searchMerchanId > 0)
                    {
                        menuItemList = menuItemList.Where(b => b.MerchantId == searchMerchanId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid Merchant Id!");
                        return BadRequest(_response);
                    }
                }

                if (searchItemTypeId.HasValue)
                {
                    if (searchItemTypeId > 0)
                    {
                        menuItemList = menuItemList.Where(b => b.ItemTypeId == searchItemTypeId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid ItemType Id!");
                        return BadRequest(_response);
                    }
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<MenuItem>>(menuItemList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetMenuItem")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetMenuItem(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid MenuItem ID.");
                    return BadRequest(_response);
                }

                var menuItem = await _dbMenuItem.GetAsync(b => b.Id == id);
                if (menuItem == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("MenuItem is not found.");
                    return NotFound(_response);
                }

                var menuItemDTO = _mapper.Map<MenuItemDTO>(menuItem);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = menuItemDTO;

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
        public async Task<ActionResult<APIResponse>> CreateMenuItem([FromBody] MenuItemCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The menuItem entity cannot be null!");
                    return BadRequest(createDTO);
                }

                MenuItem menuItem = _mapper.Map<MenuItem>(createDTO);

                await _dbMenuItem.CreateAsync(menuItem);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = createDTO;
                return CreatedAtRoute("GetMenuItem", new { id = menuItem.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteMenuItem")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteMenuItem(int id)
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

                var menuItem = await _dbMenuItem.GetAsync(m => m.Id == id);
                if (menuItem == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("MenuItem is not found!");
                    return NotFound(_response);
                }
                await _dbMenuItem.RemoveAsync(menuItem);

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

        [HttpPut("{id:int}", Name = "UpdateMenuItem")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateMenuItem(int id, [FromBody] MenuItemUpdateDTO updateDTO)
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

                var menuItem = _mapper.Map<MenuItem>(updateDTO);

                await _dbMenuItem.UpdateAsync(menuItem);
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
