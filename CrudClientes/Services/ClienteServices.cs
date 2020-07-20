using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Entity;
using CrudClientes.Models;
using CrudClientes.Data;

namespace CrudClientes.Services
{
    public class ClienteServices
    {
        
        private DataContext _db = new DataContext();


        public List<Cliente> Listar()
        {
            List<Cliente> clientesNaoExcluidos = _db.Clientes.Where(x => x.Excluido == false).ToList();
         
            return clientesNaoExcluidos;

        }

        public Cliente Editar(Cliente cliente)
        {

            _db.Entry(cliente).State = EntityState.Modified;
            _db.SaveChanges();

            return cliente;

        }

        public Cliente Filtrar(string nome, string documento)
        {
            Cliente clienteBuscado = new Cliente();

            if (documento == null || documento == "")
            {
                var nomeFiltrado = _db.Clientes.Where(x => x.Nome == nome).ToList();
                foreach (var clienteEncontrado in nomeFiltrado)
                {
                    clienteBuscado = clienteEncontrado;
                }      
               
            }
            else {
                var documentoFiltrado = _db.Clientes.Where(x => x.CpfCnpj == documento).ToList();
                foreach (var docEncontrado in documentoFiltrado)
                {
                    clienteBuscado = docEncontrado;
                }
            }
            return clienteBuscado;
        }
        public bool CriarCadastro(Cliente cliente)
        {
            cliente.DataCadastro = DateTime.Now;
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
            return true;
        }
        public bool SoftDelete(int id)
        {
            Cliente cliente = _db.Clientes.Find(id);
            cliente.Excluido = true;
            _db.SaveChanges();
            return true;
        }
    }
}