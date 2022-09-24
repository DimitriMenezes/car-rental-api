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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }      

        public async Task<ReturnModel> AddClient(ClientModel model)
        {            
            var clientValidator = new ClientValidator().Validate(model);
            if(!clientValidator.IsValid)            
                return new ReturnModel { Errors = clientValidator.Errors };            

            model.Password = PasswordService.GeneratePassword(model.Password);
            var entity = _mapper.Map<Client>(model);            
            await _clientRepository.Insert(entity);

            return new ReturnModel { Data = model };
        }
      
    }
}
