using Car.Rental.Data.Repositories.Abstract;
using Car.Rental.Services.Abstract;
using Car.Rental.Services.Model;
using System.Threading.Tasks;

namespace Car.Rental.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IOperatorRepository _operatorRepository;

        public AuthenticationService(IClientRepository clientRepository, IOperatorRepository operatorRepository)
        {
            _clientRepository = clientRepository;
            _operatorRepository = operatorRepository;
        }


        public async Task<ReturnModel> ClientLogin(ClientLoginModel model)
        {
            var client = await _clientRepository.GetByCpf(model.Cpf);
            if (client == null)
                return new ReturnModel { Errors = "User or password is incorrect" };

            var parts = client.Password.Split('.', 3);

            if (!PasswordService.PasswordIsCorrect(parts[1], parts[2], model.Password))
                return new ReturnModel { Errors = "User or password is incorrect" };

            var token = TokenService.GenerateToken(client);

            return new ReturnModel { Data = token };
        }

        public async Task<ReturnModel> OperatorLogin(OperatorLoginModel model)
        {
            var user = await _operatorRepository.GetByEnrollmentCode(model.EnrollmentCode);
            if (user == null)
                return new ReturnModel { Errors = "User or password is incorrect" };

            var parts = user.Password.Split('.', 3);

            if (!PasswordService.PasswordIsCorrect(parts[1], parts[2], model.Password))
                return new ReturnModel { Errors = "User or password is incorrect" };

            var token = TokenService.GenerateToken(user);

            return new ReturnModel { Data = token };
        }
    }
}
