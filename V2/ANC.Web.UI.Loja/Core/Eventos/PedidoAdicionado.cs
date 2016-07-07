using ANC.Web.UI.Loja.Core.Infraestrutura;
using System;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.Core.Eventos
{
    public class PedidoAdicionado : Event
    {
        public Guid ClienteId { get; set; }

        public Guid PedidoId { get; set; }

        public DateTime Data { get; set; }

        public string EmailDoCliente { get; set; }

        public decimal Total { get; set; }

        public string Transportadora { get; set; }

        public IDictionary<Guid, int> ProdutosComprados { get; set; }
    }
}