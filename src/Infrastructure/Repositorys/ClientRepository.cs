using AspNetCoreMvc.Client.Domain.Interfaces.Repositorys;
using AspNetCoreMvc.Client.Domain.Models;
using AspNetCoreMvc.Client.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ICollection<Domain.Models.Client>> GetAll()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<ClientPhysical> GetByCpf(string cpf)
        {
            return await _context.ClientPhysical.Where(x => x.Cpf == cpf).FirstOrDefaultAsync();
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
