using System.Threading.Tasks;
using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Core.Models.Auth.Interfaces.Common
{
	public interface IUsersService
	{
		User GetUserByID(int userID);

		Task<User> GetUserByIDAsync(int userID);

		Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
	}
}
