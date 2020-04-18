using ClassifiedAds.Domain.Entities;
using ClassifiedAds.Domain.Events;
using ClassifiedAds.Domain.Repositories;
using System;

namespace ClassifiedAds.Application.Products.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Product Product { get; set; }
    }

    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IDomainEvents _domainEvents;

        public DeleteProductCommandHandler(IRepository<Product, Guid> productRepository, IDomainEvents domainEvents)
        {
            _productRepository = productRepository;
            _domainEvents = domainEvents;
        }

        public void Handle(DeleteProductCommand command)
        {
            _productRepository.Delete(command.Product);
            _productRepository.UnitOfWork.SaveChanges();
            _domainEvents.Dispatch(new EntityDeletedEvent<Product>(command.Product, DateTime.Now));
        }
    }
}
