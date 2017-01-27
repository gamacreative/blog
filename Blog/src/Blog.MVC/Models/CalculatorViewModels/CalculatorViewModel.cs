using System.ComponentModel.DataAnnotations;

namespace Blog.MVC.Models.CalculatorViewModel
{
    public class CalculatorViewModel
    {
        public Lead Lead { get; set; }
        [Display(Name = "Vai querer pacote de assinatura de Internet + TV?")]
        public option Internet { get; set; }
        [Display(Name = "Vai almoçar fora ou cozinhar em casa?")]
        public option Lunch { get; set; }
        [Display(Name = "Vai jantar fora ou cozinhar em casa?")]
        public option Dinner { get; set; }
        [Display(Name = "Vai precisar de ajuda para a limpeza?")]
        public option Clean { get; set; }
        [Display(Name = "Vai morar sozinho?")]
        public option Living { get; set; }
        public double TotalValue { get; set; }
    }

    public enum option : int
    {
        [Display(Name = "Sim")]
        Yes,
        [Display(Name = "Não")]
        No
    }
}
