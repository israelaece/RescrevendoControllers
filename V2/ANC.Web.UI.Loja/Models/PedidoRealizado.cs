using System;

namespace ANC.Web.UI.Loja.Models
{
    public class PedidoRealizado
    {
        public Guid ClienteId { get; set; }

        public string NomeDaTransportadora { get; set; }

        public Guid PedidoId { get; set; }

        public DateTime Data { get; set; }

        public decimal Total { get; set; }
    }
}