using AspNetCoreMvc.Client.Domain.Interfaces.Repositorys;
using AspNetCoreMvc.Client.Domain.Interfaces.Services;
using AspNetCoreMvc.Client.Domain.Models;
using AspNetCoreMvc.Client.Domain.Models.Validations;
using FluentValidation;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Client.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task NewClient(ClientPhysical clientPhysical)
        {
            //TODO Validar a entidade antes de salvar no banco
            if(RunValidation(new ClientPhisycalValidation(), clientPhysical))
            {
                //Gravar uma Notificação de Erro
                return;
            }

            //Validar se CPF já está cadastado no banco
            if(_clientRepository.GetByCpf(clientPhysical.Cpf).Result != null)
            {
                //Gravar uma Notificação de Erro
                return;
            }

            await _clientRepository.Insert(clientPhysical);

            await _clientRepository.SaveChanges();
        }

        private bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            //Notify(validator);

            return false;
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
