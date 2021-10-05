using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication5.Config;
using WebApplication5.Models;

namespace WebApplication5.Controllers.Api
{

  public  class TmpUser 
    { 
        public string UserName { set; get; }
        public string Password { set; get; }
        
    }



    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public  IActionResult Token(TmpUser user)
        {
            var identity =  GetIdentity(user.UserName, user.Password).Result;
            if (identity == null)
            {
                return BadRequest(new { error = "Invalid login and/or password" });
            }

            var jwt = new JwtSecurityToken(
                issuer: AuthorizeOption.ISSUER,
                audience: AuthorizeOption.AUDIENCE,
                claims: identity.Claims,
                expires: DateTime.Now.AddMinutes(AuthorizeOption.LIFETIME),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(AuthorizeOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Json(new
            {
                access_token = encodedJwt
            });
        }

        private async Task<ClaimsIdentity> GetIdentity(string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            { 
                var res = await signInManager.CheckPasswordSignInAsync(user, password, false);
                if (res.Succeeded)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, password)
                    };

                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }
            }

            return null;
        }
    }
}
