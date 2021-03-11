using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace CramCoding.UnitTests.AutoMapper
{
    /// <summary>
    /// Factory class which creates an instance of AutoMapper.
    /// It can be used for testing purposes instead of <see cref="IMapper"/> mock.
    /// </summary>
    /// <remarks>It uses all the mapping profiles which are found in the application.</remarks>
    internal static class AutoMapperFactory
    {
        private const string MappingProfilesAssemblyName = "CramCoding.WebApp";

        /// <summary>
        /// Creates an instance of AutoMapper.
        /// </summary>
        /// <returns>Instance of Automapper using application mapping profiles</returns>
        internal static IMapper Create()
        {
            var assembly = Assembly.Load(MappingProfilesAssemblyName);

            var profileClasses = assembly.GetTypes()
                .Where(t => t.BaseType == typeof(Profile))
                .ToArray();

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var singleProfileClass in profileClasses)
                {
                    Profile profileInstance = (Profile)Activator.CreateInstance(singleProfileClass);
                    cfg.AddProfile(profileInstance);
                }
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
