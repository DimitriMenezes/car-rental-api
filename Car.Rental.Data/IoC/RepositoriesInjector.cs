using Car.Rental.Data.Repositories.Abstract;
using Car.Rental.Data.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace Car.Rental.Data.IoC
{
    public static class RepositoriesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOperatorRepository, OperatorRepository>();
        }
    }
}
