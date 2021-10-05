using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Config
{
    public class AuthorizeOption
    {
        public const string ISSUER = "TheBestBicycleShop";
        public const string AUDIENCE = "MeDear";
        const string KEY = "ILoveGirlsSFJKSFJLKfjjfjlsdfjk";
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.Default.GetBytes(KEY));
        }
    }
}
