using ProjetoHenrique.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ProjetoHenrique.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository

    {

        private readonly IHttpContextAccessor contextAccessor;
        public PedidoRepository(ApplicationContext context, IHttpContextAccessor contextAccessor) : base(context)
        {
            this.contextAccessor = contextAccessor;
        }

        public void AddItem(string codigo)
        {
            var viagem = _context.Set<Viagem>().Where(p => p.Codigo == codigo).SingleOrDefault();
            if(viagem == null)
            {
                throw new Exception("Viagem nao Encontrada");
            }

            var pedido = GetPedido();
            
            var ItemPedido =    _context.Set<ItemPedido>().Where( p => p.Viagem.Codigo ==
            codigo && p.Pedido.Id == viagem.Id).SingleOrDefault();

            if(ItemPedido == null)
            {
                _context.Set<ItemPedido>().Add(new ItemPedido(pedido, viagem, 1, viagem.Preco));
                _context.SaveChanges();
            }

        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet.Include(p => p.Itens)
                .ThenInclude(item => item.Viagem) //ele adiciona la lista dos carrinhos as viagens selecionadas
                .Where(p => p.Id == pedidoId)
                                                .SingleOrDefault();

            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                _context.SaveChanges();
                setViagemId(pedido.Id);
            }

            return pedido;


        }

        private int? GetPedidoId()
        {
          return  contextAccessor.HttpContext.Session.GetInt32("viagemId");

        }

        private void setViagemId(int viagemId)
        {
            contextAccessor.HttpContext.Session.SetInt32("viagemId", viagemId);
        }
    }
}
