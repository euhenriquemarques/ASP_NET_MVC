using ProjetoHenrique.Models;
using ProjetoHenrique.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoHenrique.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IViagemRepository viagemRepository;
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IViagemRepository viagemRepository, IPedidoRepository pedidoRepository)
        {
            this.viagemRepository = viagemRepository;
            this.pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Carrossel  ()
        {

           
            return View(viagemRepository.GetViagens());
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.AddItem(codigo);
            }

            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido.Itens);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {

            var pedido = pedidoRepository.GetPedido();
            return View(pedido);
        }
    }
}
