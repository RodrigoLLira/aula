using aula.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aula.Controllers
{
    public class ProdutosController : Controller
    {

        public static List<Produto> lsProdutos = new List<Produto>();
        public IActionResult Index()
        {
            return View(lsProdutos);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Produto objeto)
        {
            lsProdutos.Add(objeto);
            return RedirectToAction("Index");
        }
    }
}
