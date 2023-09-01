using System;
using System.ComponentModel.DataAnnotations;

namespace TesteContainers.Models
{
    public class MovimentacoesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione o tipo da movimentação!")]
        public string TipoMovs { get; set; }

        [Required(ErrorMessage = "Selecione a data de inicio!")]
        public DateTime dtInicio { get; set; }

        [Required(ErrorMessage = "Selecione a data do fim!")]
        public DateTime dtFim { get; set; }
    }
}
