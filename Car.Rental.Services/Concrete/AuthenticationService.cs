using Car.Rental.Data.Repositories.Abstract;
using Car.Rental.Services.Abstract;
using Car.Rental.Services.Model;
using System.Threading.Tasks;

namespace Car.Rental.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClientRepository _clientRepository;

        public AuthenticationService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public async Task<ReturnModel> ClientLogin(ClientLoginModel model)
        {
            var client = await _clientRepository.GetByCpf(model.Cpf);
            if (client == null)
                return new ReturnModel { Errors = "User or password is incorect" };

            var parts = client.Password.Split('.', 3);

            if (!PasswordService.PasswordIsCorrect(parts[1], parts[2], model.Password))
                return new ReturnModel { Errors = "User or password is incorect" };

            var token = TokenService.GenerateToken(client);

            return new ReturnModel { Data = token };
        }
    }
}
