using ANC.Web.UI.Loja.Core.Consultas;
using ANC.Web.UI.Loja.Core.Consultas.DTOs;
using ANC.Web.UI.Loja.Core.Consultas.EmMemoria;
using System;

namespace ANC.Web.UI.Loja.App_Start
{
    public class DataConfig
    {
        public static void ConfigData(ConstrutorDeControllersComDependencias dependencias)
        {
            var dmf = new DataModelFacade();

            dmf.Adicionar(new ProdutoDisponivel()
            {
                Id = Guid.Parse("FB9D5F26-702E-407A-B415-30D61EE73EA7"),
                Categoria = "CDs & DVDs",
                Nome = "Max Live 2008",
                QuantidadeEmEstoque = 3,
                Valor = 19.49M,
                Imagem = "FB9D5F26-702E-407A-B415-30D61EE73EA7.jpg"
            });

            dmf.Adicionar(new ProdutoDisponivel()
            {
                Id = Guid.Parse("737BB964-8AE0-48BC-B5D7-BF4D1E9D7511"),
                Categoria = "CDs & DVDs",
                Nome = "Tutto Max",
                QuantidadeEmEstoque = 5,
                Valor = 14.28M,
                Imagem = "737BB964-8AE0-48BC-B5D7-BF4D1E9D7511.jpg"
            });

            dmf.Adicionar(new ProdutoDisponivel()
            {
                Id = Guid.Parse("748C00CE-0EEB-463B-9BC2-171DB5B0A3DB"),
                Categoria = "CDs & DVDs",
                Nome = "Terraferma",
                QuantidadeEmEstoque = 2,
                Valor = 11.98M,
                Imagem = "748C00CE-0EEB-463B-9BC2-171DB5B0A3DB.jpg"
            });

            dmf.Adicionar(new ProdutoDisponivel()
            {
                Id = Guid.Parse("3B3913C3-79D9-4574-93D7-5BF2446A73E9"),
                Categoria = "CDs & DVDs",
                Nome = "Hanno Ucciso L'Uomo Ragno",
                QuantidadeEmEstoque = 2,
                Valor = 17.90M,
                Imagem = "3B3913C3-79D9-4574-93D7-5BF2446A73E9.jpg"
            });

            dmf.Adicionar(new ProdutoDisponivel()
            {
                Id = Guid.Parse("77AE6257-3F8A-48FB-97B8-012E69B7EC8E"),
                Categoria = "CDs & DVDs",
                Nome = "Max 20",
                QuantidadeEmEstoque = 10,
                Valor = 12.99M,
                Imagem = "77AE6257-3F8A-48FB-97B8-012E69B7EC8E.jpg"
            });

            dmf.Adicionar(new ProdutoDisponivel()
            {
                Id = Guid.Parse("B0F1677B-C476-4998-B111-DD06386032A9"),
                Categoria = "CDs & DVDs",
                Nome = "Astronave Max",
                QuantidadeEmEstoque = 239,
                Valor = 23.88M,
                Imagem = "B0F1677B-C476-4998-B111-DD06386032A9.jpg"
            });

            dependencias.Add<IDataFacade>(dmf);
        }
    }
}