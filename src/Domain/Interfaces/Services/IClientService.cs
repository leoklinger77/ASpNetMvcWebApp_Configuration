using AspNetCoreMvc.Client.Domain.Models;
using System;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Client.Domain.Interfaces.Services
{
    public interface IClientService : IDisposable
    {
        Task NewClient(ClientPhysical clientPhysical);
    }
}
