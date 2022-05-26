using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteCrud.Models;

namespace TesteCrud.Controllers
{
    public class ClientesController : Controller
    {
        private SocialSolutionContext db = new SocialSolutionContext();
        Cliente cliente = new Cliente();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Imovel);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IdImovel = new SelectList(db.Imoveis.Where(x => x.ImovelAtivo), "Id", "TipoNegocio");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nome,Email,Cpf,ClienteAtivo,IdImovel")] Cliente cliente)
        {
            Validar(cliente);

            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdImovel = new SelectList(db.Imoveis.Where(x => x.ImovelAtivo), "Id", "TipoNegocio", cliente.IdImovel);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdImovel = new SelectList(db.Imoveis, "Id", "TipoNegocio", cliente.IdImovel);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nome,Email,Cpf,ClienteAtivo,IdImovel")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdImovel = new SelectList(db.Imoveis, "Id", "TipoNegocio", cliente.IdImovel);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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

        public void Validar(Cliente cliente)
        {
            using (SocialSolutionContext db = new SocialSolutionContext())

            {
                if (db.Clientes.Any(x => x.Email == cliente.Email))
                    ModelState.AddModelError("Email", $"E-mail {cliente.Email} já cadastrado.");

                if (db.Clientes.Any(x => x.Cpf == cliente.Cpf))
                    ModelState.AddModelError("Cpf", $"CPF {cliente.Cpf} já Cadastrado!");

                if (db.Clientes.Any(x => x.IdImovel == cliente.IdImovel))
                    ModelState.AddModelError("IdImovel", $"Imovel já vinculado a um Cliente!");
            }
        }
    }
}
