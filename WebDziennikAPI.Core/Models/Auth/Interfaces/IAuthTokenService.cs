using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Core.Models.Auth.Interfaces
{
	public interface IAuthTokenService
	{
		Token NewToken();
	}
}
