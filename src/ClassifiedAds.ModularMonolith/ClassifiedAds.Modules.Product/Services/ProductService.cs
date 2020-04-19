using ClassifiedAds.Domain.Events;
using ClassifiedAds.Domain.Identity;
using ClassifiedAds.Modules.Product.Repositories;
using System;

namespace ClassifiedAds.Modules.Product.Services
{
    public class ProductService : CrudService<Entities.Product>, IProductService
    {
        public ProductService(IRepository<Entities.Product, Guid> productRepository, IDomainEvents domainEvents, ICurrentUser currentUser)
            : base(productRepository, domainEvents)
        {
        }
    }
}
