using System;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.Core.Dominio
{
    public class Pedido : Entidade
    {
        private readonly IList<Item> itens;

        public Pedido(Cliente cliente) : this()
        {
            this.Data = DateTime.Now;
            this.Cliente = cliente;
            this.itens = new List<Item>();
        }

        public DateTime Data { get; private set; }

        public Cliente Cliente { get; set; }

        public decimal Total { get; private set; }

        public Transportadora Transportadora { get; set; }

        public void AdicionarItem(Item item)
        {
            this.itens.Add(item);
            this.Total += item.Total;

            item.Produto.QuantidadeEmEstoque -= item.Quantidade;
        }

        public IEnumerable<Item> Itens
        {
            get
            {
                return this.itens;
            }
        }

        #region Transportadora - Não Relevante

        protected Pedido()
        {
            this.Transportadora = new Transportadora() { Nome = "UPS" };
        }

        #endregion
    }

    public class Item
    {
        public Item(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
            this.Total = produto.Valor * quantidade;
        }

        public Produto Produto { get; private set; }

        public int Quantidade { get; private set; }

        public decimal Total { get; private set; }
    }
}