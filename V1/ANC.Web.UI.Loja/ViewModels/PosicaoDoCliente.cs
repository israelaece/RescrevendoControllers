using System;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.ViewModels
{
    public class PosicaoDoCliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public int QuantidadeDePedidos { get; set; }

        public decimal TotalDosPedidos { get; set; }

        public DateTime? DataDoUltimoPedido { get; set; }
    }
}