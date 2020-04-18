using ClassifiedAds.Domain.Entities;
using ClassifiedAds.Domain.Events;
using ClassifiedAds.Domain.Repositories;
using System;

namespace ClassifiedAds.Application.Products.Commands
{
    public class AddUpdateProductCommand : ICommand
    {
        public Product Product { get; set; }
    }

    internal class AddUpdateProductCommandHandler : ICommandHandler<AddUpdateProductCommand>
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IDomainEvents _domainEvents;

        public AddUpdateProductCommandHandler(IRepository<Product, Guid> productRepository, IDomainEvents domainEvents)
        {
            _productRepository = productRepository;
            _domainEvents = domainEvents;
        }

        public void Handle(AddUpdateProductCommand command)
        {
            var adding = command.Product.Id.Equals(default);

            _productRepository.AddOrUpdate(command.Product);
            _productRepository.UnitOfWork.SaveChanges();

            if (adding)
            {
                _domainEvents.Dispatch(new EntityCreatedEvent<Product>(command.Product, DateTime.Now));
            }
            else
            {
                _domainEvents.Dispatch(new EntityUpdatedEvent<Product>(command.Product, DateTime.Now));
            }
        }
    }
}
