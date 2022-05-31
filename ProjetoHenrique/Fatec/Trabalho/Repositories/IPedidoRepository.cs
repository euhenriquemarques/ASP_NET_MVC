using ProjetoHenrique.Models;
using System.Collections.Generic;

namespace ProjetoHenrique.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
    }
}