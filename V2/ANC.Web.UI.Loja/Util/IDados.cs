using ANC.Web.UI.Loja.Models;
using System;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.Util
{
    public interface IDados
    {
        void Adicionar(ProdutoDisponivel produto);

        void Adicionar(PosicaoDoCliente pedido);

        void Adicionar(PedidoRealizado pedido);

        IEnumerable<PedidoRealizado> RecuperarPedidosRelizadosPor(Guid clienteId);

        IEnumerable<ProdutoDisponivel> RecuperarProdutosDisponiveis();

        ProdutoDisponivel RecuperarProdutoPor(Guid produtoId);

        PosicaoDoCliente RecuperarPosicaoDoCliente(Guid clienteId);
    }
}