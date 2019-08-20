﻿using System.Collections.Generic;

namespace Tt.App.Contracts
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}