﻿using Notes.Application.Interfaces;
using System.Security.Claims;

namespace Notes.WebAPI.Services
{
    public sealed class CurrentUserService : ICurrentUserService
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid UserId
        {
            get 
            {
                var id = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                return string.IsNullOrWhiteSpace(id)
                    ? Guid.Empty
                    : Guid.Parse(id);
            }
        }
    }
}
