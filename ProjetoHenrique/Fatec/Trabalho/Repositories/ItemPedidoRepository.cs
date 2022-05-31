using ProjetoHenrique.Models;

namespace ProjetoHenrique.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository

    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
