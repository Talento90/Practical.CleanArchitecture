using ClassifiedAds.Domain.Events;
using ClassifiedAds.Modules.Identity.Contracts.DTOs;
using ClassifiedAds.Modules.Identity.Contracts.Services;
using ClassifiedAds.Modules.Identity.Entities;
using ClassifiedAds.Modules.Identity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassifiedAds.Modules.Identity.Services
{
    public class UserService : CrudService<User>, IUserService
    {
        public UserService(IRepository<User, Guid> userRepository, IDomainEvents domainEvents)
            : base(userRepository, domainEvents)
        {
        }

        List<UserDTO> IUserService.Get()
        {
            return _repository.GetAll().Select(
                x => new UserDTO
                {
                    Id = x.Id,
                    UserName = x.UserName,
                }).ToList();
        }
    }
}
