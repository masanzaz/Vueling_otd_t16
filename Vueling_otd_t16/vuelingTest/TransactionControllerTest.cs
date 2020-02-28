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
    public class TransactionControllerTest
    {

        TransactionController _controller;
        public TransactionControllerTest()
        {
            var autoMapping = new AutoMapping();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(autoMapping);
            });
            var mapper = new Mapper(config);
            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
            _controller = new TransactionController(mapper);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllTransactions();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllTransactions()
        {
            // Act
            var okResult = _controller.GetAllTransactions().Result as OkObjectResult;
            // Assert
            Assert.IsType<List<DtoTransaction>>(okResult.Value);
        }

        [Fact]
        public void GetBySKU_UnknownSKUPassed_ReturnsNotFoundResult()
        {
            // Act            
            var notFoundResult = _controller.GetTransactionsBySKU("UnknownSKU");

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetBySKU_ExistingSKUPassed_ReturnsOkResult()
        {
            // Arrange
            string sku = "N2486";
            // Act            
            var okResult = _controller.GetTransactionsBySKU(sku);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetBySKU_ExistingSKUPassed_ReturnsRightItem()
        {
            // Arrange
            string sku = "N2486";

            // Act
            var okResult = _controller.GetTransactionsBySKU(sku).Result as OkObjectResult;

            // Assert
            Assert.IsType<DtoTransactionTotal>(okResult.Value);
            Assert.Equal(sku, (okResult.Value as DtoTransactionTotal).transactionList[0].sku);
        }




    }
}

