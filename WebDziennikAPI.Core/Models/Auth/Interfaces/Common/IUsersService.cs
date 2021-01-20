using System.Threading.Tasks;
using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Core.Models.Auth.Interfaces.Common
{
	public interface IUsersService
	{
		Task<User> GetUserByID(int userID);

		Task<User> GetUserByUsernameAndPassword(string username, string password);
	}
}
