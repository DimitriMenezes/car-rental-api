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
    }
}
