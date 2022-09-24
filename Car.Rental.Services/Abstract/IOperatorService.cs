using Car.Rental.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Services.Abstract
{
    public interface IOperatorService
    {
        Task<ReturnModel> AddOperator(OperatorModel model);
    }
}
