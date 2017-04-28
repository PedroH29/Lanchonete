using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lanchonete.DAL;
using Lanchonete.Models;

namespace Lanchonete.Views
{
    public class LanchesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lanches
        public ActionResult Index()
        {
            var lanches = db.Lanches.Include(l => l.Categoria);
            return View(lanches.ToList());
        }

        // GET: Lanches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lanche lanche = db.Lanches.Find(id);
            if (lanche == null)
            {
                return HttpNotFound();
            }
            return View(lanche);
        }

        // GET: Lanches/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
            return View();
        }

        // POST: Lanches/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LancheID,Nome,Descricao,Preco,CategoriaID")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                db.Lanches.Add(lanche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", lanche.CategoriaID);
            return View(lanche);
        }

        // GET: Lanches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lanche lanche = db.Lanches.Find(id);
            if (lanche == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", lanche.CategoriaID);
            return View(lanche);
        }

        // POST: Lanches/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LancheID,Nome,Descricao,Preco,CategoriaID")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lanche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", lanche.CategoriaID);
            return View(lanche);
        }

        // GET: Lanches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lanche lanche = db.Lanches.Find(id);
            if (lanche == null)
            {
                return HttpNotFound();
            }
            return View(lanche);
        }

        // POST: Lanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lanche lanche = db.Lanches.Find(id);
            db.Lanches.Remove(lanche);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
