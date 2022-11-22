using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// UserEntity repo, work with Postgres and IdentityFraemwork
    /// </summary>
    public interface IUserAuthenticationRepository
    {
        /// <summary>
        /// Async user registration
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task RegistrateAsync(UserDto input);

        /// <summary>
        /// Async login in account
        /// </summary>
        /// <param name="request"></param>
        /// <returns><see cref="LoginResponseDto"/></returns>
        public Task<LoginResponseDto> LoginAsync(AutentificationRequestDto request);

        /// <summary>
        /// Async give role to user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task GiveRoleToUserAsync(ChangeRoleRequestDto email);

        /// <summary>
        /// Get user data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CurrentUserDto> GetUserDataById(Guid id);
        

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="input"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task ChangePasswordAsync(ChangePasswordDto input, Guid userId);

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task ConfirmEmail(Guid id, string token);
    }
}
