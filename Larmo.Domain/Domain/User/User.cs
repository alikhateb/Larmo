﻿using Microsoft.AspNetCore.Identity;

namespace Larmo.Domain.Domain.User
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public RefreshToken RefreshToken { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}