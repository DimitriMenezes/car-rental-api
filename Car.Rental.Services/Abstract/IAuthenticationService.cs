
using Car.Rental.Services.Model;
using System.Threading.Tasks;

namespace Car.Rental.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<ReturnModel> ClientLogin(ClientLoginModel model);
        Task<ReturnModel> OperatorLogin(OperatorLoginModel model);
    }
}
