using ASP.Net.MediatR.API.ViewModels.Order;
using ASP.Net.MediatR.API.ViewModels.Product;
using ASP.Net.MediatR.API.ViewModels.Role;
using ASP.Net.MediatR.API.ViewModels.User;
using ASP.Net.MediatR.Contacts.Dto;
using AutoMapper;

namespace ASP.Net.MediatR.API;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<CreateUserViewModel, UserDto>()
            .ForMember(el => el.Id, opt => opt.MapFrom((_, dest) => dest.Id = Guid.NewGuid()))
            .ForMember(el => el.RegisterDate, opt => opt.MapFrom((_, dest) => dest.RegisterDate = DateTime.UtcNow));
        CreateMap<UserViewModel, UserDto>().ReverseMap();

        CreateMap<CreateRoleViewModel, RoleDto>();
        CreateMap<RoleViewModel, RoleDto>().ReverseMap();

        CreateMap<CreateProductViewModel, ProductDto>();
        CreateMap<ProductViewModel, ProductDto>().ReverseMap();

        CreateMap<CreateOrderViewModel, OrderDto>();
        CreateMap<OrderViewModel, OrderDto>().ReverseMap();

        CreateMap<CreateOrderDetailViewModel, OrderDetailDto>();
        CreateMap<OrderDetailViewModel, OrderDetailDto>().ReverseMap();
    }
}
