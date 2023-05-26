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
using FoodToGo_API.Models.Enums;

namespace FoodToGo_API.Controllers
{
    [Route("api/OrderAPI")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _dbOrder;
        public OrderController(
            IOrderRepository dbOrder,
            IMapper mapper)
        {
            _mapper = mapper;
            this._response = new APIResponse();
            _dbOrder = dbOrder;
        }

        [HttpGet(Name = "GetAllOrders")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAllOrders(
            int? searchCustomerId = null,
            int? searchMerchanId = null,
            int? searchShipperId = null,
            int? searchPromotionId = null,
            string? searchStatus = null,
            DateTime? searchPlacedDate = null,
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                List<Order> orderList = await _dbOrder.GetAllAsync(null, pageSize, pageNumber);

                if (searchCustomerId.HasValue)
                {
                    if (searchCustomerId > 0)
                    {
                        orderList = orderList.Where(e => e.CustomerId == searchCustomerId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid Customer Id!");
                        return BadRequest(_response);
                    }
                }

                if (searchMerchanId.HasValue)
                {
                    if (searchMerchanId > 0)
                    {
                        orderList = orderList.Where(e => e.MerchantId == searchMerchanId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid Merchant Id!");
                        return BadRequest(_response);
                    }
                }

                if (searchShipperId.HasValue)
                {
                    if (searchShipperId > 0)
                    {
                        orderList = orderList.Where(e => e.ShipperId == searchShipperId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid Shipper Id!");
                        return BadRequest(_response);
                    }
                }

                if (searchPromotionId.HasValue)
                {
                    if (searchPromotionId > 0)
                    {
                        orderList = orderList.Where(e => e.PromotionId == searchPromotionId).ToList();
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Invalid Shipper Id!");
                        return BadRequest(_response);
                    }
                }

                if (searchPlacedDate.HasValue)
                {
                    orderList = orderList.Where(e => e.PlacedTime.Date == searchPlacedDate.Value.Date).ToList();
                }

                if (string.IsNullOrEmpty(searchStatus) == false)
                {
                    orderList = orderList.Where(e => e.Status == searchStatus).ToList();
                }

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<Order>>(orderList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetOrder")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetOrder(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid Order ID.");
                    return BadRequest(_response);
                }

                var order = await _dbOrder.GetAsync(b => b.Id == id);
                if (order == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Order is not found.");
                    return NotFound(_response);
                }

                var orderDTO = _mapper.Map<OrderDTO>(order);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = orderDTO;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("successrate", Name = "GetSuccessRate")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetSuccessRate(int userId, string asType)
        {
            try
            {
                asType = char.ToUpper(asType[0]) + asType.Substring(1);
                if (userId <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid user ID.");
                    return BadRequest(_response);
                }

                if (!Enum.IsDefined(typeof(UserType), asType))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid asType.");
                    return BadRequest(_response);
                }
                
                List<Order> ordersList = new List<Order>();
                if (asType == UserType.Shipper.ToString())
                {
                    ordersList = await _dbOrder.GetAllAsync(b => b.ShipperId == userId);
                }
                else if (asType == UserType.Customer.ToString())
                {
                    ordersList = await _dbOrder.GetAllAsync(b => b.CustomerId == userId);
                }
                else if (asType == UserType.Merchant.ToString())
                {
                    ordersList = await _dbOrder.GetAllAsync(b => b.MerchantId == userId);
                }

                if (ordersList == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("ordersList is null.");
                    return NotFound(_response);
                }

                int successCount = 0;
                int cancelledCount = 0;
                ordersList.ForEach(o => { 
                    if(o.Status == OrderStatus.Completed.ToString())
                    {
                        successCount++;
                    }
                    if(o.Status == OrderStatus.Cancelled.ToString() && o.canceledBy == asType)
                    {
                        cancelledCount++;
                    }
                });


                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = new { 
                    success = successCount,
                    cancelled = cancelledCount,
                };

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
        public async Task<ActionResult<APIResponse>> CreateOrder([FromBody] OrderCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The order entity cannot be null!");
                    return BadRequest(createDTO);
                }

                Order order = _mapper.Map<Order>(createDTO);

                await _dbOrder.CreateAsync(order);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = order;
                return CreatedAtRoute("GetOrder", new { id = order.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"{ex.Message}");
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteOrder")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteOrder(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid Order ID.");
                    return BadRequest(_response);
                }

                var order = await _dbOrder.GetAsync(m => m.Id == id);
                if (order == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Order is not found!");
                    return NotFound(_response);
                }
                await _dbOrder.RemoveAsync(order);

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

        [HttpPut("{id:int}", Name = "UpdateOrder")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateOrder(int id, [FromBody] OrderUpdateDTO updateDTO)
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

                var order = _mapper.Map<Order>(updateDTO);

                await _dbOrder.UpdateAsync(order);
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
