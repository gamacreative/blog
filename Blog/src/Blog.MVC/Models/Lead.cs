using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.Models
{
    public class Lead
    {
        public int ID { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(150, MinimumLength = 5)]
        [Required(ErrorMessage = "Nome obrigatório")]
        [Display(Name = "Nome*")]
        public string Name { get; set; }
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Estado obrigatório")]
        public string State { get; set; }
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Cidade obrigatória")]
        public string City { get; set; }
        public string IP { get; set; }
        public int DownloadCount { get; set; }
    }
}
