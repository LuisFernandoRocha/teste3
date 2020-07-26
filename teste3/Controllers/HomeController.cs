using Microsoft.AspNetCore.Mvc;
using teste3.Models;

namespace teste3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo(int Codigo)
        {
            Moeda objConta = new Moeda();
            int cod = objConta.Novo(Codigo);         
            return Json(new { sucesso = true, mensagem = cod });
        }

        public IActionResult Salvar(int codigo,string descricao,string abreviatura, double cotacao)
        {
            Moeda objConta = new Moeda();
            int cod = objConta.salvar(codigo,descricao,abreviatura,cotacao);

            if (cod == 0)
            {
                return Json(new { sucesso = true });
            }
            else
            {
                return Json(new { sucesso = false });
            }
        }

        public IActionResult Excluir(int codigo)
        {
            Moeda objConta = new Moeda();
             int cod = objConta.Excluir(codigo);
            if (cod==0)
            {
                return Json(new { sucesso = false });
            }
            else
            {
                return Json(new { sucesso = true });
            }
   
       }
    }
}
