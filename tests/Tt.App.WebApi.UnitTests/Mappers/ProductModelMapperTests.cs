using AutoMapper;
using NUnit.Framework;
using System.Collections.ObjectModel;
using FluentAssertions;
using Tt.App.WebApi.Mappers;
using Tt.App.WebApi.Mappers.Profiles;
using Tt.App.Data;
using Tt.App.WebApi.Models;

namespace Tt.App.WebApi.UnitTests.Mappers
{
    public class ProductModelMapperTests
    {
        private IProductModelMapper sut;

        [SetUp]
        public void Setup()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductModelProfile());
            });
            var mapper = mockMapper.CreateMapper();

            sut = new ProductModelMapper(mapper);
        }

        [Test]
        public void MapProducts_Always_ReturnExpectedResult()
        {
            var products = new Collection<Product>
            {
                new Product {
                    Id = "1",
                    Name = "Product 1",
                    ProductCategoryProducts = new Collection<ProductCategoryProduct>  {
                        new ProductCategoryProduct
                        {
                            ProductId = "1",
                            ProductCategoryId = "1",
                            ProductCategory = new ProductCategory { Name = "Cat 1" }
                        }
                    }
                },
                new Product {
                    Id = "2",
                    Name = "Product 2",
                    ProductCategoryProducts = new Collection<ProductCategoryProduct>  {
                        new ProductCategoryProduct
                        {
                            ProductId = "2",
                            ProductCategoryId = "2",
                            ProductCategory = new ProductCategory { Name = "Cat 2" }
                        }
                    }
                },
                new Product {
                    Id = "3",
                    Name = "Product 3",
                    ProductCategoryProducts = new Collection<ProductCategoryProduct>  {
                        new ProductCategoryProduct
                        {
                            ProductId = "3",
                            ProductCategoryId = "1",
                            ProductCategory = new ProductCategory { Name = "Cat 1" }
                        }
                    }
                }
            };

            var result = sut.Map(products);

            result.Should().BeEquivalentTo(new Collection<ProductModel>
            {
                new ProductModel {
                    Id = "1",
                    Name = "Product 1",
                    ProductCategories = new Collection<ProductCategoryModel>  {
                        new ProductCategoryModel { Id = "1", Name = "Cat 1" }
                    }
                }
                ,
                new ProductModel {
                    Id = "2",
                    Name = "Product 2",
                    ProductCategories = new Collection<ProductCategoryModel>  {
                        new ProductCategoryModel { Id = "2", Name = "Cat 2" }
                    }
                },
                new ProductModel {
                    Id = "3",
                    Name = "Product 3",
                    ProductCategories = new Collection<ProductCategoryModel>  {
                        new ProductCategoryModel { Id = "1", Name = "Cat 1" }
                    }
                }
            });
        }
    }
}
