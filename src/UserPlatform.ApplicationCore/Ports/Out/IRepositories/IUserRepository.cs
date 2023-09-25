using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPlatform.Domain.Entities;

namespace UserPlatform.ApplicationCore.Ports.Out.IRepositories
{
    public interface IUserRepository
    {
        Task<UserDetails> Create(UserDetails userDetails);
    }
}
