using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.MVC.Models
{
    public class Lead
    {
        public int ID { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(150, MinimumLength = 5)]
        [Required(ErrorMessage = "Nome obrigatório")]
        [Display(Name = "Nome*")]
        public string Name { get; set; }
        [EmailAddress]
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
        public DateTime? dataCriacao { get; set; }
    }
}
