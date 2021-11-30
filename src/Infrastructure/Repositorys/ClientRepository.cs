using AspNetCoreMvc.Client.Domain.Interfaces.Repositorys;
using AspNetCoreMvc.Client.Domain.Models;
using AspNetCoreMvc.Client.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Client.Infrastructure.Repositorys
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _context;

        public ClientRepository(ClientContext context)
        {
            _context = context;
        }

        public Task<ClientPhysical> GetByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(ClientPhysical clientPhysical)
        {
            await _context.ClientPhysical.AddAsync(clientPhysical);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
