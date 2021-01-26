using AutoMapper;
using System;
using WebDziennikAPI.Core.Models.Auth.Enums;
using WebDziennikAPI.Core.Models.Auth.Implementations;
using WebDziennikAPI.Core.Tables;

namespace WebDziennikAPI.Core.Mappings
{
	public class AuthProfile : Profile
	{
		public AuthProfile()
		{
			// Table Users -> User class
			CreateMap<Users, User>()
				.ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.GetName(typeof(Role), (ushort) src.RoleID).ToString()));
		}
	}
}
