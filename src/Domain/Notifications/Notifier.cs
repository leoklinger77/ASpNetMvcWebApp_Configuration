using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvc.Client.Domain.Notifications
{
    public class Notifier
    {
        public string Erro { get; private set; }

        public Notifier(string erro)
        {
            Erro = erro;
        }
    }

    public interface INotifierService
    {
        void AddErro(string erro);
        IEnumerable<Notifier> GetAll();
        bool HasAny();
    }

    public class NotifierService : INotifierService
    {
        private List<Notifier> _notifiers = new List<Notifier>();

        public NotifierService()
        {
        }

        public void AddErro(string erro)
        {
            _notifiers.Add(new Notifier(erro));
        }

        public IEnumerable<Notifier> GetAll()
        {
            return _notifiers.ToList();
        }

        public bool HasAny()
        {
            return _notifiers.Any();
        }
    }

}
