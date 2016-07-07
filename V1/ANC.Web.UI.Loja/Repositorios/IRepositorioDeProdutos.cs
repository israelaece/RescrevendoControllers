using ANC.Web.UI.Loja.Models;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.Repositorios
{
    public interface IRepositorioDeProdutos : IRepositorio<Produto>
    {
        IEnumerable<Produto> RecuperarProdutosDisponiveis();
    }
}