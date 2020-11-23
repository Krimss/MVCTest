using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MVCTest.Models
{
    public class Founder
    {
        [Key]
        public int FounderID { get; set; }
        [Required(ErrorMessage = "Введите  ИНН")]
        [RegularExpression(@"^(\d{10}|\d{12})$", ErrorMessage = "Введите корректный ИНН")]
        public string INN { get; set; }
        [Required(ErrorMessage = "Введите  Имя")]
        public string FIO { get; set; } 
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }
        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; }
        
        public Founder() { Customers = new List<Customer>(); }
    }
}
