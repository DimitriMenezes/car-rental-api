using Car.Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Data.Repositories.Abstract
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client> GetByCpf(string cpf);
    }
}
