using AspNetCoreMvc.Client.Domain.Interfaces.Repositorys;
using AspNetCoreMvc.Client.Domain.Interfaces.Services;
using AspNetCoreMvc.Client.Domain.Models;
using AspNetCoreMvc.Client.Domain.Models.Validations;
using AspNetCoreMvc.Client.Domain.Notifications;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Client.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly INotifierService _notifierService;

        public ClientService(IClientRepository clientRepository, INotifierService notifierService)
        {
            _clientRepository = clientRepository;
            _notifierService = notifierService;
        }

        public async Task<ICollection<Models.Client>> ToList()
        {
            return await _clientRepository.GetAll();
        }

        public async Task NewClient(ClientPhysical clientPhysical)
        {            
            if(!RunValidation(new ClientPhisycalValidation(), clientPhysical)) return;

            //Validar se CPF já está cadastado no banco
            if (_clientRepository.GetByCpf(clientPhysical.Cpf).Result != null)
            {
                _notifierService.AddErro("Cpf já cadastrado no banco de dados.");
                return;
            }

            await _clientRepository.Insert(clientPhysical);

            await _clientRepository.SaveChanges();
        }

        private bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            foreach (var item in validator.Errors)
            {
                _notifierService.AddErro(item.ErrorMessage);
            }

            return false;
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }

        
    }
}
