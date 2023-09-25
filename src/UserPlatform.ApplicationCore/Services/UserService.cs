using AutoMapper;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.Domain.Entities;

namespace UserPlatform.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Create(CreateUserRequest createUserRequest)
        {
            var userDetails = _mapper.Map<UserDetails>(createUserRequest);
            var createdUser = await _userRepository.Create(userDetails);
            var createdUserResponse = _mapper.Map<CreateUserResponse>(createdUser);
            return createdUserResponse;
        }

        public async Task<GetByUserIdResponse> GetByUserId(Guid userId)
        {
            return new GetByUserIdResponse();
        }

        public async Task<GetByUserNameResponse> GetByUserName(string userName)
        {
            return new GetByUserNameResponse();
        }
    }
}