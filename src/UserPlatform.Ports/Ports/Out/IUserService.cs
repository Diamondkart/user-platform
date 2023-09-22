using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPlatform.Core.Models.Request;
using UserPlatform.Core.Models.Response;

namespace UserPlatform.Ports.Ports.Out
{
	public interface IUserService
	{
		public Task<bool> Create(CreateUserRequest createUserRequest);
		public Task<CreateUserResponse> Get(string userName);
	}
}
