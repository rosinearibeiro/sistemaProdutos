using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class Produto
    {
        //propriedades -> prop + 2x[tab]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
