using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler.Infrastructure.Services.Abstract
{
    public interface IEncrypter : IService
    {
        string GetSalt(string value);
        string GetHash(string values, string salt);
    }
}
