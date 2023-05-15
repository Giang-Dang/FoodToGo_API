using AutoMapper;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;

namespace FoodToGo_API
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();

            CreateMap<User, RegisterationRequestDTO>().ReverseMap();

            CreateMap<Shipper, ShipperDTO>().ReverseMap();
            CreateMap<Shipper, ShipperUpdateDTO>().ReverseMap();
            CreateMap<Shipper, ShipperCreateDTO>().ReverseMap();

            CreateMap<Promotion, PromotionDTO>().ReverseMap();
            CreateMap<Promotion, PromotionUpdateDTO>().ReverseMap();
            CreateMap<Promotion, PromotionCreateDTO>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailUpdateDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailCreateDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();

            CreateMap<OnlineShipperStatus, OnlineShipperStatusDTO>().ReverseMap();
            CreateMap<OnlineShipperStatus, OnlineShipperStatusUpdateDTO>().ReverseMap();
            CreateMap<OnlineShipperStatus, OnlineShipperStatusCreateDTO>().ReverseMap();

            CreateMap<OnlineCustomerLocation, OnlineCustomerLocationDTO>().ReverseMap();
            CreateMap<OnlineCustomerLocation, OnlineCustomerLocationUpdateDTO>().ReverseMap();
            CreateMap<OnlineCustomerLocation, OnlineCustomerLocationCreateDTO>().ReverseMap();

            CreateMap<Merchant, MerchantDTO>().ReverseMap();
            CreateMap<Merchant, MerchantUpdateDTO>().ReverseMap();
            CreateMap<Merchant, MerchantCreateDTO>().ReverseMap();

            CreateMap<MenuItemType, MenuItemTypeDTO>().ReverseMap();
            CreateMap<MenuItemType, MenuItemTypeUpdateDTO>().ReverseMap();
            CreateMap<MenuItemType, MenuItemTypeCreateDTO>().ReverseMap();

            CreateMap<MenuItem, MenuItemDTO>().ReverseMap();
            CreateMap<MenuItem, MenuItemUpdateDTO>().ReverseMap();
            CreateMap<MenuItem, MenuItemCreateDTO>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
        }
    }
}
