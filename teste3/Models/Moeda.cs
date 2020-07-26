using MyFinance.Util;
using System.Data;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace teste3.Models
{
    public class Moeda
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Abreviatura { get; set; }
        public double Cotacao { get; set; }
        public Moeda(){}
        public Moeda(int codigo, string descricao, string abreviatura, double cotacao)
        {
            Codigo = codigo;
            Descricao = descricao;
            Abreviatura = abreviatura;
            Cotacao = cotacao;
        }

        public int salvar(int codigo, string descricao, string abreviatura, double cotacao)
        {
            try
            {
                var sql = $"SELECT * FROM db_moedas where codigo = '{codigo}'";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                int retorno = int.Parse(dt.Rows[0]["codigo"].ToString());
                return retorno;
            }
            catch
            {
                new DAL().ExecutarComandoSQL("insert into db_moedas values ('" + codigo + "','" + descricao + "','" + abreviatura + "','" + cotacao + "')");
                return 0;
            }
        }

        public int Novo(int codigo)
        {    
            var sql = $" SELECT (max(codigo) + 1) as codigo FROM db_moedas;";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);    
            return int.Parse(dt.Rows[0]["codigo"].ToString());
        }
        public int Excluir(int codigo)
        {
            try
            {
                var sql = $"SELECT * FROM db_moedas where codigo = '{codigo}'";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                int retorno = int.Parse(dt.Rows[0]["codigo"].ToString());
                new DAL().ExecutarComandoSQL("Delete from db_moedas where codigo= " + codigo);
                return retorno;
            }
            catch
            {
                return 0;
            }
        }
    }
}
