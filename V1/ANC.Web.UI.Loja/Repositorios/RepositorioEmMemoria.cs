using ANC.Web.UI.Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ANC.Web.UI.Loja.Repositorios
{
    public abstract class RepositorioEmMemoria<T> where T : Entidade
    {
        protected static readonly IList<T> itens = new List<T>();

        public void Adicionar(T entity)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            itens.Add(entity);
        }

        public T BuscarPor(Guid id)
        {
            return itens.SingleOrDefault(e => e.Id == id);
        }
    }
}