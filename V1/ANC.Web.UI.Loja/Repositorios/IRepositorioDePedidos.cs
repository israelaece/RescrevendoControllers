using ANC.Web.UI.Loja.Models;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.Repositorios
{
    public interface IRepositorioDePedidos : IRepositorio<Pedido>
    {
        IEnumerable<Pedido> BuscarPor(Cliente cliente);
    }
}