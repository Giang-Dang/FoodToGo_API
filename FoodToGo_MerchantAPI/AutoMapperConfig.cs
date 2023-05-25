using AutoMapper;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models.DTO.CreateDTO;
using FoodToGo_API.Models.DTO.UpdateDTO;

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

            CreateMap<NormalOpenHours, NormalOpenHoursDTO>().ReverseMap();
            CreateMap<NormalOpenHours, NormalOpenHoursUpdateDTO>().ReverseMap();
            CreateMap<NormalOpenHours, NormalOpenHoursCreateDTO>().ReverseMap();

            CreateMap<OverrideOpenHours, OverrideOpenHoursDTO>().ReverseMap().ForMember(dest => dest.Merchant, opt => opt.Ignore());
            CreateMap<OverrideOpenHours, OverrideOpenHoursUpdateDTO>().ReverseMap().ForMember(dest => dest.Merchant, opt => opt.Ignore());
            CreateMap<OverrideOpenHours, OverrideOpenHoursCreateDTO>().ReverseMap().ForMember(dest => dest.Merchant, opt => opt.Ignore());

            CreateMap<MenuItemImage, MenuItemImageDTO>().ReverseMap();
            CreateMap<MenuItemImage, MenuItemImageUpdateDTO>().ReverseMap();
            CreateMap<MenuItemImage, MenuItemImageCreateDTO>().ReverseMap();

            CreateMap<MenuItemRating, MenuItemRatingDTO>().ReverseMap();
            CreateMap<MenuItemRating, MenuItemRatingUpdateDTO>().ReverseMap();
            CreateMap<MenuItemRating, MenuItemRatingCreateDTO>().ReverseMap();

            CreateMap<Ban, BanDTO>().ReverseMap();
            CreateMap<Ban, BanUpdateDTO>().ReverseMap();
            CreateMap<Ban, BanCreateDTO>().ReverseMap();

            CreateMap<UserRating, UserRatingDTO>().ReverseMap();
            CreateMap<UserRating, UserRatingUpdateDTO>().ReverseMap();
            CreateMap<UserRating, UserRatingCreateDTO>().ReverseMap();

            CreateMap<MerchantProfileImage, MerchantProfileImageDTO>().ReverseMap();
            CreateMap<MerchantProfileImage, MerchantProfileImageUpdateDTO>().ReverseMap();
            CreateMap<MerchantProfileImage, MerchantProfileImageCreateDTO>().ReverseMap();
        }
    }
}
