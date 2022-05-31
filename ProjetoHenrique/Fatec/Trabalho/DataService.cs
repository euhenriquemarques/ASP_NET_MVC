using ProjetoHenrique.Models;
using ProjetoHenrique.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ProjetoHenrique
{
    class DataService : IDataService
    {
        private readonly ApplicationContext _context;
     private readonly IViagemRepository viagemRepository;

        public DataService(ApplicationContext context, IViagemRepository viagemRepository)
        {
            _context = context;
            this.viagemRepository = viagemRepository;
        }

        public void InicializarBancoDeDados()
        {
            _context.Database.Migrate();
            List<Pacote> pacotes = getPacotesViagens();

            viagemRepository.SalvarPacotesViagens(pacotes);
        }


        private static List<Pacote> getPacotesViagens()
        {
            //buscando os dados do arquivo json
            var json = File.ReadAllText("viagens.json");
            var pacotes = JsonConvert.DeserializeObject<List<Pacote>>(json);
            return pacotes;
        }
    }

  
}
