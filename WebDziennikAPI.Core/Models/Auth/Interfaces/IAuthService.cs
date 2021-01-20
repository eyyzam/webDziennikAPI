using System.Collections.Generic;
using System.Threading.Tasks;
using WebDziennikAPI.Core.Contexts.Auth.Tables;
using WebDziennikAPI.Core.Contracts.Auth.Requests;
using WebDziennikAPI.Core.Contracts.Auth.Responses;

namespace WebDziennikAPI.Core.Models.Auth.Interfaces
{
	public interface IAuthService
	{
		Task<List<Users>> GetUsersAsync();

		Task<AuthenticateByCredentialsResponse> AuthenticateByCredentials(AuthenticateByCredentialsRequest request);
	}
}
