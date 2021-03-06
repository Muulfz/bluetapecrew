﻿using BlueTapeCrew.Areas.Admin.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Services.Models;
using Xunit;

namespace Web.Tests.Controllers
{
    [Collection("UnitTest")]
    public class AdminProductsControllerTests
    {
        private readonly UnitTestFixture _fixture;

        public AdminProductsControllerTests(UnitTestFixture fixture)
        {
            _fixture = fixture;
        }

        private AdminProductsController GetSut()
        {
            return new AdminProductsController(
                _fixture.ProductService.Object,
                _fixture.ImageService.Object,
                _fixture.SiteSettingsService.Object,
                _fixture.StyleService.Object,
                _fixture.CategoryService.Object,
                _fixture.Mapper.Object);
        }

        [Fact]
        public async Task GivenARequest_Create_DoesNotThrowAnException()
        {
            try
            {
                //arrange
                var sut = GetSut();

                //act
                await sut.Create(new Product(), _fixture.FormFile.Object, 1);
                
                //assert
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
