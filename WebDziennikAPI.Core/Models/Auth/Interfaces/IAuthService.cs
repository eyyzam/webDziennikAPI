using System.Collections.Generic;
using System.Threading.Tasks;
using WebDziennikAPI.Core.Contexts.Auth.Tables;

namespace WebDziennikAPI.Core.Models.Auth.Interfaces
{
	public interface IAuthService
	{
		Task<List<Users>> GetUsersAsync();
	}
}
