using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVCTest.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Введите  ИНН")]
        [RegularExpression(@"^(\d{10}|\d{12})$", ErrorMessage ="Введите корректный ИНН")]
        public string INN { get; set; }
        [Required(ErrorMessage = "Введите  Имя")]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"^(Индивидуальный предприниматель|Юридическое лицо)$")]
        public string Type { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }

        [JsonIgnore]
        public ICollection<Founder> Founders { get; set; }
        public Customer() { Founders = new List<Founder>(); }

    }
}
