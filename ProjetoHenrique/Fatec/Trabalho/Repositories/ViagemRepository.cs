using ProjetoHenrique.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoHenrique.Repositories
{
    public class ViagemRepository :BaseRepository<Viagem>,  IViagemRepository
    {
        public ViagemRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<Viagem> GetViagens()
        {
            return dbSet.ToList();
        }

        public void SalvarPacotesViagens(List<Pacote> pacotes)
        {
            foreach (var pacote in pacotes)
            {
                if (!dbSet.Where(p => p.Codigo == pacote.Codigo).Any())
                {
                    //adicionando para salvar no banco de dados
                  
                    dbSet.Add(new Viagem(pacote.Codigo, pacote.Nome, pacote.Preco));
                }
              
            }

            //salvando no banco as viagens carregasdas em memoria
            _context.SaveChanges();
        }
    }

    public  class Pacote
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

    }
}
