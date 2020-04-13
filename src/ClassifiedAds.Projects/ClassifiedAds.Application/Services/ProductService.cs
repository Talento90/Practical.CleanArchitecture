using ClassifiedAds.Domain.Entities;
using ClassifiedAds.Domain.Identity;
using ClassifiedAds.Domain.Repositories;
using System;

namespace ClassifiedAds.Application.Services
{
    public class ProductService : CrudService<Product>, IProductService
    {
        public ProductService(IRepository<Product, Guid> productRepository, ICurrentUser currentUser)
            : base(productRepository)
        {
        }
    }
}
