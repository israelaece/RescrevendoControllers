using ANC.Web.UI.Loja.Models;
using System;

namespace ANC.Web.UI.Loja.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Adicionar(T entidade);

        T BuscarPor(Guid id);
    }
}