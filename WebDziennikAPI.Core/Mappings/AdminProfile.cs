using AutoMapper;
using WebDziennikAPI.Core.Models.Admin.Implementations;
using WebDziennikAPI.Core.Tables;

namespace WebDziennikAPI.Core.Mappings
{
	public class AdminProfile : Profile
	{
		public AdminProfile()
		{
			CreateMap<Roles, Role>().ReverseMap();
		}
	}
}
