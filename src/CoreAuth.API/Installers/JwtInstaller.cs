using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoreAuth.API.Installers
{
    public class JwtInstaller : IInstaller
    {
        public JwtInstaller()
        {
        }

        public void InsallServices(IServiceCollection services, IConfiguration configuration)
        {
            string secureKey = $"Hey-this-is-so-secure-key";
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "someone",
                        ValidateAudience = true,
                        ValidAudience = "readers",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey))

                    };
                });
        }
    }
}
