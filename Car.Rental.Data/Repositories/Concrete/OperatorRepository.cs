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
    public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
    {
        public OperatorRepository(AuthContext context) : base(context)
        {
        }

        public async Task<Operator> GetByEnrollmentCode(string enrollmentCode)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.EnrollmentCode == enrollmentCode);
        }
    }
}
