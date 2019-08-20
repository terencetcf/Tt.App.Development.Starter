using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tt.App.Mappers;
using Tt.App.Mappers.Profiles;
using Tt.App.Contracts;
using FluentAssertions;
using Db = Tt.App.Data.EfCore.Entities;

namespace Tt.App.UnitTests.Mappers
{
    public class ProductMapperTests
    {
        private IProductMapper sut;

        [SetUp]
        public void Setup()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });
            var mapper = mockMapper.CreateMapper();

            sut = new ProductMapper(mapper);
        }

        [Test]
        public void MapProducts_Always_ReturnExpectedResult()
        {
            var products = new Collection<Db.Product>
            {
                new Db.Product {
                    Id = 1,
                    Name = "Product 1",
                    ProductCategoryProducts = new Collection<Db.ProductCategoryProduct>  {
                        new Db.ProductCategoryProduct { ProductId = 1, ProductCategoryId = 1
                        }
                    }
                },
                new Db.Product {
                    Id = 2,
                    Name = "Product 2",
                    ProductCategoryProducts = new Collection<Db.ProductCategoryProduct>  {
                        new Db.ProductCategoryProduct { ProductId = 2, ProductCategoryId = 2
                        }
                    }
                },
                new Db.Product {
                    Id = 3,
                    Name = "Product 3",
                    ProductCategoryProducts = new Collection<Db.ProductCategoryProduct>  {
                        new Db.ProductCategoryProduct { ProductId = 3, ProductCategoryId = 1
                        }
                    }
                }
            };

            var result = sut.Map(products);

            result.Should().BeEquivalentTo(new Collection<Product>
            {
                new Product {
                    Id = 1,
                    Name = "Product 1",
                    ProductCategories = new Collection<ProductCategory>  {
                        new ProductCategory { Id = 1 }
                    }
                }
                ,
                new Product {
                    Id = 2,
                    Name = "Product 2",
                    ProductCategories = new Collection<ProductCategory>  {
                        new ProductCategory { Id = 2 }
                    }
                },
                new Product {
                    Id = 3,
                    Name = "Product 3",
                    ProductCategories = new Collection<ProductCategory>  {
                        new ProductCategory { Id = 1 }
                    }
                }
            });
        }
    }
}
