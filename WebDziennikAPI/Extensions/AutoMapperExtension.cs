using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace WebDziennikAPI.Extensions
{
	public static class AutoMapperExtension
	{
		private static readonly List<Assembly> _assemblies = new List<Assembly>();

		public static IServiceCollection AutoMapperAddAssembly(this IServiceCollection services, Type type)
		{
			if (!type.IsSubclassOf(typeof(Profile)))
				throw new ArgumentException(null, nameof(type));

			var assembly = type.Assembly;

			if (!_assemblies.Contains(assembly))
				_assemblies.Add(assembly);

			return services;
		}

		public static IReadOnlyList<Assembly> GetAssemblies()
		{
			return _assemblies.AsReadOnly();
		}
	}
}
