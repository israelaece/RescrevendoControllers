using ANC.Web.UI.Loja.Models;
using System.Collections.Generic;
using System.Linq;

namespace ANC.Web.UI.Loja.Repositorios
{
    public class RepositorioDePedidos : RepositorioEmMemoria<Pedido>, IRepositorioDePedidos
    {
        public IEnumerable<Pedido> BuscarPor(Cliente cliente)
        {
            return from p in itens where p.Cliente.Id == cliente.Id select p;
        }
    }
}