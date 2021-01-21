using AutoMapper;
using WebDziennikAPI.Core.Contexts.Auth.Tables;
using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Core.Mappings
{
	public class AuthProfile : Profile
	{
		public AuthProfile()
		{
			// Table Users -> User class
			CreateMap<Users, User>().ReverseMap();
		}
	}
}
