using AutoMapper;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.Domain.Constant;
using UserPlatform.Domain.Entities;
using UserPlatform.Domain.Exceptions;

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

        public async Task<CreateUserResponse> CreateAsync(CreateUserRequest createUserRequest)
        {
            var userDetails = _mapper.Map<UserDetails>(createUserRequest);
            if (await _userRepository.CheckIfUserIsUnique(userDetails))
            {
                throw new RecordAlreadyExistsException(Constant.RecordExistsErrorMessage);
            }
            userDetails.ModifiedOn = DateTime.UtcNow;
            userDetails.CreatedOn = DateTime.UtcNow;
            var createdUser = await _userRepository.CreateAsync(userDetails);
            var createdUserResponse = _mapper.Map<CreateUserResponse>(createdUser);
            return createdUserResponse;
        }

        public async Task<GetByUserIdResponse> GetByUserByUserIdAsync(Guid userId)
        {
            var userDetails = await _userRepository.GetUserByUserIdAsync(userId);
            var userResponse = _mapper.Map<GetByUserIdResponse>(userDetails);
            return userResponse;
        }

        public async Task<GetByUserNameResponse> GetByUserNameAsync(string userName)
        {
            var userDetails = await _userRepository.GetByUserNameAsync(userName);
            var userResponse = _mapper.Map<GetByUserNameResponse>(userDetails);
            return userResponse;
        }

        public async Task<IEnumerable<GetUsersResponse>> GetUsersAsync()
        {
            var userDetails = await _userRepository.GetUsersAsync();
            var userResponse = _mapper.Map<IEnumerable<GetUsersResponse>>(userDetails);
            return userResponse;
        }

        public async Task<bool> UpdateNameAsync(UpdateNameRequest updateNameRequest)
        {
            await ValidateUpdateUser(updateNameRequest.UserId);
            var userDetails = _mapper.Map<UserDetails>(updateNameRequest);
            var isUserNameUpdated = await _userRepository.UpdateNameAsync(userDetails);
            return isUserNameUpdated;
        }

        public async Task<bool> UpdatePhoneNumberAsync(UpdatePhoneNumberRequest updatePhoneNumberRequest)
        {
            await ValidateUpdateUser(updatePhoneNumberRequest.UserId);
            var userDetails = _mapper.Map<UserDetails>(updatePhoneNumberRequest);
            var isUserPhoneUpdated = await _userRepository.UpdatePhoneNumberAsync(userDetails);
            return isUserPhoneUpdated;
        }

        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest updateUserRequest)
        {
            var userDetails = _mapper.Map<UserDetails>(updateUserRequest);
            var createdUser = await _userRepository.UpdateAsync(userDetails);
            var updateUserResponse = _mapper.Map<UpdateUserResponse>(createdUser);
            return updateUserResponse;
        }

        private async Task ValidateUpdateUser(Guid userId)
        {
            if (await _userRepository.GetUserByUserIdAsync(userId) == null)
            {
                throw new NotFoundException(string.Format(Constant.UserIdNotFound, userId));
            }
        }
    }
}