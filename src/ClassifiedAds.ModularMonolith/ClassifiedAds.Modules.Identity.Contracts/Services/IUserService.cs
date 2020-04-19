using ClassifiedAds.Modules.Identity.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassifiedAds.Modules.Identity.Contracts.Services
{
    public interface IUserService
    {
        List<UserDTO> Get();
    }
}
