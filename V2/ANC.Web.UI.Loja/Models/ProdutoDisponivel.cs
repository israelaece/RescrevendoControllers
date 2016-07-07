using System;

namespace ANC.Web.UI.Loja.Models
{
    public class ProdutoDisponivel
    {
        public Guid Id { get; set; }

        public string Imagem { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public decimal Valor { get; set; }

        public int QuantidadeEmEstoque { get; set; }
    }
}