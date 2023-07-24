using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClienteService.Models
{
    public class Logradouro
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public int ClienteId { get; set; }
    }

}
