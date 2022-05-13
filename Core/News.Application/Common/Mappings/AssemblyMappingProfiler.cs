using AutoMapper;
using System.Linq;
using System.Reflection;

namespace News.Application.Common.Mappings
{
    public class AssemblyMappingProfiler : Profile
    {
        public AssemblyMappingProfiler(Assembly assembly) => ApplyMappingFromAssembly(assembly);

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var assemblyTypes = assembly.GetExportedTypes().Where(t => t.GetCustomAttributes<MapWithAttribute>().Any()).ToList();

            foreach (var assemblyType in assemblyTypes)
            {
                foreach (var attr in assemblyType.GetCustomAttributes<MapWithAttribute>())
                {
                    this.CreateMap(attr.MapSourceType, assemblyType);
                }
            }
        }
    }
}
