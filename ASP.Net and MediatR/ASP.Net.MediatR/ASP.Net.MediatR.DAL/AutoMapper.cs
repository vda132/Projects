using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.DAL.Models;
using AutoMapper;

namespace ASP.Net.MediatR.DAL;

public class AutoMapper : Profile
{
	public AutoMapper()
	{
		CreateMap<Order, OrderDto>().ReverseMap();
		CreateMap<User, UserDto>()
			.ForMember(el => el.Role, 
					opt => opt.MapFrom((src, dest) => dest.Role = src.Role?.Name!));
		CreateMap<UserDto, User>()
			.ForMember(el => el.Password, opt => opt.Condition(src => src.Password is not null))
			.ForMember(el => el.Role, opt => opt.Ignore());
		CreateMap<Product, ProductDto>().ReverseMap();
		CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
		CreateMap<Role, RoleDto>().ReverseMap();
	}
}
