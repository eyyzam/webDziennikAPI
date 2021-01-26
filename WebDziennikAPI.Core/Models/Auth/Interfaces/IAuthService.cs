using System.Collections.Generic;
using System.Threading.Tasks;
using WebDziennikAPI.Core.Contracts.Auth.Requests;
using WebDziennikAPI.Core.Contracts.Auth.Responses;
using WebDziennikAPI.Core.Tables;

namespace WebDziennikAPI.Core.Models.Auth.Interfaces
{
	public interface IAuthService
	{
		Task<List<Users>> GetUsersAsync();

		Task<AuthenticateByCredentialsResponse> AuthenticateByCredentials(AuthenticateByCredentialsRequest request);
	}
}
