﻿using RLPortalBackend.Models;
using RLPortalBackend.Models.Autentification;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// User repo, work with Postgres and IdentityFraemwork
    /// </summary>
    public interface IUserAuthenticationRepository
    {
        /// <summary>
        /// Async user registration
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task RegistrateAsync(UserModel input);

        /// <summary>
        /// Async login in account
        /// </summary>
        /// <param name="request"></param>
        /// <returns><see cref="JWT"/></returns>
        public Task<JWT> LoginAsync(AutentificationRequest request);

        /// <summary>
        /// Async give role to user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task GiveRoleToUserAsync(EmailAndRole email);

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task ConfirmEmail(Guid id, string token);
    }
}
