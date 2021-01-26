using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebDziennikAPI.Core.Contexts;
using WebDziennikAPI.Core.Contracts.Admin.Responses;
using WebDziennikAPI.Core.Models.Admin.Implementations;
using WebDziennikAPI.Core.Models.Common.Interfaces;
using WebDziennikAPI.Core.Tables;

namespace WebDziennikAPI.Core.Services.Admin
{
	public class AdminService : IAdminService
	{
		private readonly IMapper _mapper;
		private readonly RolesContext _rolesContext;

		public AdminService(IConfiguration config, IMapper mapper)
		{
			_mapper = mapper;

			var configEnumerable = config.AsEnumerable();
			var connectionString = configEnumerable.FirstOrDefault(item => item.Key == "connectionString").Value;

			if (string.IsNullOrWhiteSpace(connectionString)) return;

			var optionsBuilder = new DbContextOptionsBuilder<RolesContext>();
			optionsBuilder.UseSqlServer(connectionString);
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
			_rolesContext = new RolesContext(optionsBuilder.Options);
		}

		public async Task<GetRolesResponse> GetRoles()
		{
			var response = new GetRolesResponse();
			try
			{
				var roles = _mapper.Map<List<Roles>, List<Role>>(await _rolesContext.Roles.ToListAsync());

				response.RolesList = roles;
				response.OperationSucceded = true;
			}
			catch (Exception)
			{
				response.OperationSucceded = false;
			}

			return response;
		}

		public async Task<EditRoleResponse> EditRole(int roleID, Role newRole)
		{
			var response = new EditRoleResponse();

			try
			{
				var role = await _rolesContext.Roles.FirstAsync(x => x.Id == roleID);

				role.Name = newRole.Name;

				_rolesContext.Entry(role).State = EntityState.Modified;
				await _rolesContext.SaveChangesAsync();

				response.OperationSucceded = true;
				response.Message = "Role editted successfully";
			}
			catch (Exception)
			{
				response.OperationSucceded = false;
			}

			return response;
		}

		public async Task<DeleteRoleResponse> DeleteRole(int roleID)
		{
			var response = new DeleteRoleResponse();

			try
			{
				var role = await _rolesContext.Roles.FirstAsync(x => x.Id == roleID);

				_rolesContext.Roles.Remove(role);
				_rolesContext.Entry(role).State = EntityState.Deleted;
				await _rolesContext.SaveChangesAsync();

				response.OperationSucceded = true;
				response.Message = "Role removed successfully";
			}
			catch (Exception)
			{
				response.OperationSucceded = false;
			}

			return response;
		}
	}
}
