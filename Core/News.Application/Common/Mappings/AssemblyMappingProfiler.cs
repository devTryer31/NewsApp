using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace News.Application.Common.Mappings
{
    public class AssemblyMappingProfiler : Profile
    {
        public AssemblyMappingProfiler(Assembly assembly) => ApplyMappingFromAssembly(assembly);

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes()
                .Where(t =>
                t.GetInterfaces().
                Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>))
                );

            foreach (var assemblyType in assemblyTypes)
            {

                var obj = Activator.CreateInstance(assemblyType);
                assemblyType.GetMethod("CreateMapping")?.Invoke(obj, new[] { this });
            }
        }
    }
}
