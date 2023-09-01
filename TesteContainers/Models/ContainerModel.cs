using System.ComponentModel.DataAnnotations;

namespace TesteContainers.Models
{
    public class ContainerModel
    {
             public int ID { get; set; }

        [Required(ErrorMessage = "Digite o cliente!")]   
        public string Cliente { get; set; }

        [Required(ErrorMessage = "Digite o numero do container!")]
        public string NumeroContainer { get; set; }

        [Required(ErrorMessage = "Selecione o tipo do container!")]
        public int Tipo { get; set; }

        [Required(ErrorMessage = "Selecione o status do container!")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Selecione a categoria do container!")]
        public string Categoria { get; set; }
    }
}
