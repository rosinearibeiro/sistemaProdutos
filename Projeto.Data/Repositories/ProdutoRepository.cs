using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities; //importando
using Projeto.Data.Contracts; //importando
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //atributo..
        private string connectionString;

        //construtor que irá receber da classe Startup.cs o caminho
        //da connectionstring do banco de dados
        public ProdutoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Produto obj)
        {
            string query = "insert into Produto(Nome, Preco, Quantidade, DataCadastro) "
                         + "values(@Nome, @Preco, @Quantidade, GETDATE())";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Produto obj)
        {
            string query = "update Produto set Nome = @Nome, Preco = @Preco, "
                         + "Quantidade = @Quantidade where IdProduto = @IdProduto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(int id)
        {
            string query = "delete from Produto where IdProduto = @IdProduto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { IdProduto = id });
            }
        }

        public List<Produto> ObterTodos()
        {
            string query = "select * from Produto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }

        public Produto ObterPorId(int id)
        {
            string query = "select * from Produto where IdProduto = @IdProduto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query, new { IdProduto = id }).SingleOrDefault();
            }
        }

        public List<Produto> ObterPorNome(string nome)
        {
            string query = "select * from Produto where Nome like @Nome";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query, new { Nome = "%"+nome+"%" }).ToList();
            }
        }
    }
}
