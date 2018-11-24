using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Dto;

namespace TeamScheduler.Infrastructure.Services.Abstract
{
    public interface IJwtService : IService
    {
        JwtDto CreateToken(int userId, string role);
    }
}
