using System;

namespace ANC.Web.UI.Loja.Models
{
    public class Transportadora
    {
        public string Nome { get; set; }

        public string Destino { get; set; }

        public DateTime DataDoDespacho { get; set; }

        public Rota Rota { get; set; }

        public DateTime? DataDaEntrega { get; set; }

        public string Status { get; set; }
    }

    public class Rota { }
}