using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudClientes.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string CpfCnpj { get; set; }
        public DateTime DataCadastro { get; set; }
        [Required]
        public string Telefone { get; set; }
        public bool Excluido { get; set; }

        //Construtor 
        public Cliente()
        {

        }
    }
}