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

            var existingEntity = _clientRepository.GetByCpf(model.Cpf);
            if(existingEntity != null)
                return new ReturnModel { Errors = "CPF already registred" };

            model.Password = PasswordService.GeneratePassword(model.Password);
            var entity = _mapper.Map<Client>(model);            
            await _clientRepository.Insert(entity);

            return new ReturnModel { Data = _mapper.Map<ClientModel>(entity) };
        }

        public async Task<ReturnModel> DeleteClient(int id)
        {
            try
            {
                await _clientRepository.Delete(id);
            }
            catch (Exception ex)
            {

                new ReturnModel { Errors = ex.Message };
            }            

            return new ReturnModel { Data = "" };
        }

        public async Task<ReturnModel> GetClientById(int id)
        {
            return new ReturnModel { Data = _mapper.Map<ClientModel>(await _clientRepository.GetById(id)) };
        }

        public async Task<ReturnModel> UpdateClient(ClientModel model)
        {
            var validator = new ClientValidator().Validate(model);
            if (!validator.IsValid)
                return new ReturnModel { Errors = validator.Errors };

            var client = await _clientRepository.GetById(model.Id);
            if (client == null)
                return new ReturnModel { Errors = "User not Found" };

            client.Password = PasswordService.GeneratePassword(model.Password);
            await _clientRepository.Update(client);

            var result = _mapper.Map<ClientModel>(client);            
            return new ReturnModel { Data = result };
        }
    }
}
