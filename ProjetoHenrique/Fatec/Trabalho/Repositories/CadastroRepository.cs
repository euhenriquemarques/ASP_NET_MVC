using ProjetoHenrique.Models;

namespace ProjetoHenrique.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository

    {
        public CadastroRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
