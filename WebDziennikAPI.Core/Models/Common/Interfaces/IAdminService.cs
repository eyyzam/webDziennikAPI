using System.Threading.Tasks;
using WebDziennikAPI.Core.Contracts.Admin.Responses;
using WebDziennikAPI.Core.Models.Admin.Implementations;

namespace WebDziennikAPI.Core.Models.Common.Interfaces
{
	public interface IAdminService
	{
		public Task<GetRolesResponse> GetRoles();

		public Task<EditRoleResponse> EditRole(int roleID, Role newRole);

		public Task<DeleteRoleResponse> DeleteRole(int roleID);
	}
}
