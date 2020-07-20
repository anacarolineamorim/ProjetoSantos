using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CrudClientes.Data;
using CrudClientes.Models;
using CrudClientes.Services;
using Microsoft.Ajax.Utilities;

namespace CrudClientes.Controllers
{
    public class ClientesController : Controller
    {
        private DataContext db = new DataContext();

        public ClienteServices busService = new ClienteServices();
       
        public ActionResult Index()
        {
            
            return View(busService.Listar());
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

      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Tipo,CpfCnpj,DataCadastro,Telefone")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Nome == null || cliente.Tipo == null  || cliente.CpfCnpj == null || cliente.Telefone == null)
                {
                    return Content("Necessário preencher todos os campos");
                }
                else{
                    bool _criar = busService.CriarCadastro(cliente);
                    if (_criar == true)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Content("Não foi possivel cadastrar");
                    }

                }
                

                
            }

            return View(cliente);
        }

        public ActionResult Find(string nome, string documento)
        {
           var clienteFiltrado = busService.Filtrar(nome, documento);
            return View(clienteFiltrado);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Tipo,CpfCnpj,DataCadastro,Telefone")] Cliente cliente)
        {
           
            if (ModelState.IsValid)
            {
                busService.Editar(cliente);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
           
        }

       
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

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            bool deletar = busService.SoftDelete(id);
            if (deletar == true)
            {
                return RedirectToAction("Index");
            }
            return Content("Não foi possivel excluir");
            
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
