using ANC.Web.UI.Loja.Core.Dominio;
using ANC.Web.UI.Loja.Core.Dominio.Repositorios;
using System;

namespace ANC.Web.UI.Loja.Core.Repositorios
{
    public class RepositorioDeProdutos : RepositorioEmMemoria<Produto>, IRepositorioDeProdutos
    {
        public RepositorioDeProdutos()
        {
            this.Adicionar(new Produto()
            {
                Id = Guid.Parse("FB9D5F26-702E-407A-B415-30D61EE73EA7"),
                Categoria = "CDs & DVDs",
                Nome = "Max Live 2008",
                QuantidadeEmEstoque = 3,
                Valor = 19.49M
            });

            this.Adicionar(new Produto()
            {
                Id = Guid.Parse("737BB964-8AE0-48BC-B5D7-BF4D1E9D7511"),
                Categoria = "CDs & DVDs",
                Nome = "Tutto Max",
                QuantidadeEmEstoque = 5,
                Valor = 14.28M
            });

            this.Adicionar(new Produto()
            {
                Id = Guid.Parse("748C00CE-0EEB-463B-9BC2-171DB5B0A3DB"),
                Categoria = "CDs & DVDs",
                Nome = "Terraferma",
                QuantidadeEmEstoque = 2,
                Valor = 11.98M
            });

            this.Adicionar(new Produto()
            {
                Id = Guid.Parse("3B3913C3-79D9-4574-93D7-5BF2446A73E9"),
                Categoria = "CDs & DVDs",
                Nome = "Hanno Ucciso L'Uomo Ragno",
                QuantidadeEmEstoque = 2,
                Valor = 17.90M
            });

            this.Adicionar(new Produto()
            {
                Id = Guid.Parse("77AE6257-3F8A-48FB-97B8-012E69B7EC8E"),
                Categoria = "CDs & DVDs",
                Nome = "Max 20",
                QuantidadeEmEstoque = 10,
                Valor = 12.99M
            });

            this.Adicionar(new Produto()
            {
                Id = Guid.Parse("B0F1677B-C476-4998-B111-DD06386032A9"),
                Categoria = "CDs & DVDs",
                Nome = "Astronave Max",
                QuantidadeEmEstoque = 239,
                Valor = 23.88M
            });
        }
    }
}