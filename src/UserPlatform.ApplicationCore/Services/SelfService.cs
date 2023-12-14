using AutoMapper;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.Domain.Constant;
using UserPlatform.Domain.Entities;
using UserPlatform.Domain.Exceptions;
using static UserPlatform.ApplicationCore.Utils.Utils;

namespace UserPlatform.ApplicationCore.Services
{
    public class SelfService : ISelfService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ISelfServiceRepository _selfServiceRepository;

        public SelfService(IMapper mapper, IUserRepository userRepository, ISelfServiceRepository selfServiceRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _selfServiceRepository = selfServiceRepository;
        }

        public async Task<ChangePasswordResponse> RequestChangePasswordAsync(ChangePasswordRequest changePasswordRequest)
        {
            var userDetails = await _userRepository.GetUserByEmailAsync(changePasswordRequest.UserIdentifier);
            if (userDetails == null)
            {
                throw new NotFoundException(string.Format(Constant.UserIdNotFound, changePasswordRequest.UserIdentifier));
            }
            var tokenObj = GenerateToken(Guid.NewGuid().ToString());
            var token = GenerateFullToken(new List<string> { tokenObj.Password });
            var changePassword = new ChangePassword
            {
                UserId = userDetails.UserId,
                ExpireOn = DateTime.UtcNow.AddMinutes(120),
                Token = token,
                TempPassword = GenerateRandomPassword(),
                IsValid = true
            };
            var passwordChanged = await _selfServiceRepository.RequestChangePasswordAsync(changePassword);
            var changePasswordResponse = _mapper.Map<ChangePasswordResponse>(passwordChanged);
            return changePasswordResponse;
        }

        public async Task<bool> GeneratePasswordAsync(GeneratePasswordRequest generatePasswordRequest)
        {
            var changePassword = _mapper.Map<ChangePassword>(generatePasswordRequest);
            var changePasswordResponse = await _selfServiceRepository.GetChangePasswordByTokenPasswordAsync(changePassword);
            if (changePasswordResponse == null)
            {
                throw new NotFoundException(Constant.InvalidTokenOrTokenNotFOund);
            }
            else if (!changePasswordResponse.IsValid)
            {
                throw new BadRequestException(Constant.InvalidToken);
            }
            else if (changePasswordResponse.ExpireOn < DateTime.UtcNow)
            {
                throw new BadRequestException(Constant.TokenExpired);
            }
            var userDetails = _mapper.Map<UserDetails>(generatePasswordRequest);
            userDetails.UserId = changePasswordResponse.UserId;
            changePasswordResponse.IsValid = false;
            var isUpdated = await _selfServiceRepository.UpdatePasswordAndPasswordTokenValidityAsync(userDetails, changePasswordResponse);
            return isUpdated;
        }

        public async Task<bool> VerifyUserCredAsync(VerifyUserCredRequest verifyUserCredRequest)
        {
            var userDetails = _mapper.Map<UserDetails>(verifyUserCredRequest);
            var userObj = await _userRepository.GetByUserNameAsync(userDetails.UserName);
            if (userObj == null)
            {
                // For backend api only, client application needs to make their own message.
                throw new NotFoundException(string.Format(Constant.UserIdNotFound, userDetails.UserName));
            }
            var securedPassword = GetSecurePassword(verifyUserCredRequest.Password, userObj.Salt).Password;

            if (securedPassword != userObj.Password)
            {
                throw new BadRequestException(Constant.InvalidUserNameOrPassword);
            }
            return (userObj != null && userObj.Password == securedPassword);
        }
    }
}