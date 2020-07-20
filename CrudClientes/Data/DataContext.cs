using CrudClientes.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace CrudClientes.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext:DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}