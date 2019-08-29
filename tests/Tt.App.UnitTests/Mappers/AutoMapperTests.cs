﻿using AutoMapper;
using NUnit.Framework;

namespace Tt.App.UnitTests.Mappers
{
    public class AutoMapperTests
    {
        [Test]
        public void MappingConfigurationIsValid()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new ProductProfile());
            });

            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}