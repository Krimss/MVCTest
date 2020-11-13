using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [RegularExpression(@"/^(\d{10}|\d{12})$/)",ErrorMessage ="Введите корректный ИНН")]
        public string INN { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }
        public ICollection<Founder> Founders { get; set; }
        public Customer() { Founders = new List<Founder>(); }

    }
}
