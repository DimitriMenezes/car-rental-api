using Car.Rental.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Services.Abstract
{
    public interface IClientService
    {       
        Task<ReturnModel> AddClient(ClientModel model);
        Task<ReturnModel> GetClientById(int id);
        Task<ReturnModel> UpdateClient(ClientModel model);
        Task<ReturnModel> DeleteClient(int id);
    }
}
