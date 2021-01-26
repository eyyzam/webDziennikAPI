using System.Collections.Generic;
using WebDziennikAPI.Core.Models.Admin.Implementations;
using WebDziennikAPI.Core.Models.Common.Implementations;

namespace WebDziennikAPI.Core.Contracts.Admin.Responses
{
	public class GetRolesResponse : BasePerformOperationResponse
	{
		public List<Role> RolesList { get; set; }
	}
}
