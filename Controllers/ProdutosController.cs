using aula.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aula.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto db;
        public ProdutosController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: ProdutosController


        public IActionResult Index()
        {
            return View(db.PRODUTOS.ToList());
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produtos collection)
        {
            try
            {
                db.PRODUTOS.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }
   
        public ActionResult Edit(int id)
        {
            return View(db.PRODUTOS.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produtos collection)
        {
            try
            {
                db.PRODUTOS.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
                
            }
        }

        public ActionResult Delete(int id)
        {
            db.PRODUTOS.Remove(db.PRODUTOS.Where(a => a.Id == id).FirstOrDefault() );
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
