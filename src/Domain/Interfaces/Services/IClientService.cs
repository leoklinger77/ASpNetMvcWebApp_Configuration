using AspNetCoreMvc.Client.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Client.Domain.Interfaces.Services
{
    public interface IClientService : IDisposable
    {
        Task<ICollection<Models.Client>> ToList();
        Task NewClient(ClientPhysical clientPhysical);
    }
}
