using Car.Rental.Data.Repositories.Abstract;
using Car.Rental.Domain.Context;
using Car.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Data.Repositories.Concrete
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationContext context) : base(context)
        {
            
        }

        public async Task<Client> GetByCpf(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Cpf == cpf);
        }
    }
}
