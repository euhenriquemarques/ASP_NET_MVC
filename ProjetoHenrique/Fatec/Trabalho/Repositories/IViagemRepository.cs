using ProjetoHenrique.Models;
using System.Collections.Generic;

namespace ProjetoHenrique.Repositories
{
    public interface IViagemRepository
    {
        void SalvarPacotesViagens(List<Pacote> pacotes);
        IList<Viagem> GetViagens();
    }
}