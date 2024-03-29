﻿using Microsoft.AspNetCore.Identity;

namespace NzWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
