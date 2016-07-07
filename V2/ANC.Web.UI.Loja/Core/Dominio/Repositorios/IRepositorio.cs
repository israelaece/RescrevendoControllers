using System;

namespace ANC.Web.UI.Loja.Core.Dominio.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Adicionar(T entidade);

        T BuscarPor(Guid id);
    }
}