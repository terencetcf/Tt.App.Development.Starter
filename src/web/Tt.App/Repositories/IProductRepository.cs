﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tt.App.Contracts;

namespace Tt.App.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int productId);
    }
}