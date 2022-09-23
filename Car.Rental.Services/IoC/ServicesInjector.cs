using Car.Rental.Services.Abstract;
using Car.Rental.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Services.IoC
{
    public static class ServicesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {            
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
