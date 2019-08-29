using AutoMapper;
using NUnit.Framework;
using Tt.App.WebApi.Mappers.Profiles;

namespace Tt.App.WebApi.UnitTests.Mappers
{
    public class AutoMapperTests
    {
        [Test]
        public void MappingConfigurationIsValid()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductModelProfile());
            });

            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}