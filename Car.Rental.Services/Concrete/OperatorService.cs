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

            var existingEntity = _operatorRepository.GetByEnrollmentCode(model.EnrollmentCode);
            if (existingEntity != null)
                return new ReturnModel { Errors = "EnrollmentCode already registred" };

            model.Password = PasswordService.GeneratePassword(model.Password);
            var newEntity = _mapper.Map<Operator>(model);
            await _operatorRepository.Insert(newEntity);

            return new ReturnModel { Data = _mapper.Map<OperatorModel>(newEntity) };
        }

        public async Task<ReturnModel> DeleteOperator(int id)
        {
            try
            {
                await _operatorRepository.Delete(id);
            }
            catch (Exception ex)
            {

                new ReturnModel { Errors = ex.Message };
            }

            return new ReturnModel { Data = "" };
        }

        public async Task<ReturnModel> GetOperatorById(int id)
        {
            return new ReturnModel { Data = _mapper.Map<OperatorModel>(await _operatorRepository.GetById(id)) };
        }

        public async Task<ReturnModel> UpdateOperator(OperatorModel model)
        {
            var validator = new OperatorValidator().Validate(model);
            if (!validator.IsValid)
                return new ReturnModel { Errors = validator.Errors };

            var userOperator = await _operatorRepository.GetById(model.Id);
            if (userOperator == null)
                return new ReturnModel { Errors = "User not Found" };

            userOperator.Password = PasswordService.GeneratePassword(model.Password);
            await _operatorRepository.Update(userOperator);

            var result = _mapper.Map<ClientModel>(userOperator);
            return new ReturnModel { Data = result };
        }
    }
}
