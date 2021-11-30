using AspNetCoreMvc.Client.Domain.Models;
using System;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Client.Domain.Interfaces.Repositorys
{
    public interface IClientRepository : IDisposable
    {
        Task<ClientPhysical> GetByCpf(string cpf);

        Task Insert(ClientPhysical clientPhysical);

        Task<int> SaveChanges();
    }
}
