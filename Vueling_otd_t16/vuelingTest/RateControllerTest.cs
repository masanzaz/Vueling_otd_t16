using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using vuelingApi.Controllers;
using vuelingApi.Infraestructure;
using vuelingApi.Models;
using Xunit;

namespace vuelingTest
{
    public class RateControllerTest
    {
        RateController _controller;
        public RateControllerTest()
        {
            var autoMapping = new AutoMapping();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(autoMapping);
            });
            var mapper = new Mapper(config);
            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
            _controller = new RateController(mapper);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllRates();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllRates()
        {
            // Act
            var okResult = _controller.GetAllRates().Result as OkObjectResult;
            // Assert
            Assert.IsType<List<DtoRate>>(okResult.Value);
        }
    }
}

