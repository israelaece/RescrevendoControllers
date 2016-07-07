namespace ANC.Web.UI.Loja.Core.Dominio
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }

        public string Categoria { get; set; }

        public decimal Valor { get; set; }

        public int QuantidadeEmEstoque { get; set; }
    }
}