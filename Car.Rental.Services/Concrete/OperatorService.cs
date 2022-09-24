using AutoMapper;
using Car.Rental.Data.Repositories.Abstract;
using Car.Rental.Domain.Entities;
using Car.Rental.Services.Abstract;
using Car.Rental.Services.FluentValidator;
using Car.Rental.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Services.Concrete
{
    public class OperatorService : IOperatorService
    {
        private readonly IOperatorRepository _operatorRepository;
        private readonly IMapper _mapper;
        public OperatorService(IOperatorRepository operatorRepository, IMapper mapper)
        {
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }

        public async Task<ReturnModel> AddOperator(OperatorModel model)
        {
            var clientValidator = new OperatorValidator().Validate(model);
            if (!clientValidator.IsValid)
                return new ReturnModel { Errors = clientValidator.Errors };

            model.Password = PasswordService.GeneratePassword(model.Password);
            var entity = _mapper.Map<Operator>(model);
            await _operatorRepository.Insert(entity);

            return new ReturnModel { Data = model };
        }
    }
}
