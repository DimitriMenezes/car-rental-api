using AutoMapper;
using Car.Rental.Services.Abstract;
using Car.Rental.Services.Concrete;
using Car.Rental.Services.Mapper;
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

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServicesMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IOperatorService, OperatorService>();
        }
    }
}
