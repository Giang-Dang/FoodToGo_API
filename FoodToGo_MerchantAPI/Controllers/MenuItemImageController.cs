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
    [Route("api/MenuItemImageAPI")]
    [ApiController]
    public class MenuItemImageController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMenuItemImageRepository _dbMenuItemImage;
        private readonly IMapper _mapper;
        public MenuItemImageController(
            IMenuItemImageRepository dbMenuItemImage,
            IMapper mapper)
        {
            _mapper = mapper;
            _dbMenuItemImage = dbMenuItemImage;
            this._response = new APIResponse();
        }

        [HttpGet(Name = "GetAllMenuItemImages")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllMenuItemImages(
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<MenuItemImage> menuItemImageList = await _dbMenuItemImage.GetAllAsync(null, pageSize, pageNumber);

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };


                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<MenuItemImage>>(menuItemImageList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetMenuItemImage")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetMenuItemImage(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid MemuItemImage ID.");
                    return BadRequest(_response);
                }

                var menuItemImage = await _dbMenuItemImage.GetAsync(c => c.Id == id);
                if (menuItemImage == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("MenuItemImage is not found.");
                    return NotFound(_response);
                }

                var menuItemImageDTO = _mapper.Map<MenuItemImageDTO>(menuItemImage);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = menuItemImageDTO;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("bymenuitem/{id:int}", Name = "GetMenuItemImageByItemId")]
        [Authorize]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetMenuItemImageByItemId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid MemuItem ID.");
                    return BadRequest(_response);
                }

                var menuItemImage = await _dbMenuItemImage.GetAsync(c => c.MenuItemId == id);
                if (menuItemImage == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("MenuItemImage is not found.");
                    return NotFound(_response);
                }

                var menuItemImageDTO = _mapper.Map<MenuItemImageDTO>(menuItemImage);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = menuItemImageDTO;

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
        public async Task<ActionResult<APIResponse>> CreateMenuItemImage([FromBody] MenuItemImageCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The menuItemImage entity cannot be null!");
                    return BadRequest(createDTO);
                }

                createDTO.Id = 0;

                MenuItemImage menuItemImage = _mapper.Map<MenuItemImage>(createDTO);

                await _dbMenuItemImage.CreateAsync(menuItemImage);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = menuItemImage;
                return CreatedAtRoute("GetMenuItemImage", new { id = menuItemImage.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteMenuItemImage")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteMenuItemImage(int id)
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

                var menuItemImage = await _dbMenuItemImage.GetAsync(m => m.Id == id);
                if (menuItemImage == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("MenuItemImage is not found!");
                    return NotFound(_response);
                }
                await _dbMenuItemImage.RemoveAsync(menuItemImage);

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

        [HttpPut("{id:int}", Name = "UpdateMenuItemImage")]
        [CustomAuthorize("LoginFromApp", "Merchant", "Management")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateMenuItemImage(int id, [FromBody] MenuItemImageUpdateDTO updateDTO)
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

                var menuItemImage = _mapper.Map<MenuItemImage>(updateDTO);

                await _dbMenuItemImage.UpdateAsync(menuItemImage);
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
