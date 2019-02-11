using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public virtual User User { get; set; }
    }
}

    
