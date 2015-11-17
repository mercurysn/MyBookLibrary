using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyBookLibrary.Service.Mapper;
using MyBookLibrary.Service.Model;
using NUnit.Framework;

namespace MyBookLibrary.UnitTests.AutoMapper
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void Test_AutoMapper_Mapping()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MapToModelProfile()));

            Mapper.AssertConfigurationIsValid();
        }
    }
}
