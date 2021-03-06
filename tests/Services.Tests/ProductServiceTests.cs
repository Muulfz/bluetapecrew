﻿using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Repositories.Interfaces;
using Services.Models;
using Xunit;
using Entity = Repositories.Entities;

namespace Services.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task Test()
        {
            //arrange
            const int expectedProductId = 1;
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Product, Entity.Product>(It.IsAny<Product>())).Returns(new Entity.Product
            {
                Id = expectedProductId
            });
            var sut = new ProductService(
                new Mock<IProductRepository>().Object,
                new Mock<IStyleRepository>().Object,
                new Mock<ICategoryRepository>().Object,
                new Mock<IReviewRepository>().Object,
                new Mock<IProductImageRepository>().Object,
                mockMapper.Object
                );

            //act
            var actualProduct = new Product { Id = 0 };
            await sut.Create(actualProduct);

            //assert
            Assert.Equal(expectedProductId, actualProduct.Id);
        }
    }
}
