using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamScheduler.Core.Responses;

namespace TeamScheduler.Infrastructure.Services.Abstract
{
    public interface IUserService : IService
    {
        Task<UserDto> GetUser(string email);
    }
}
