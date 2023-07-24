using ClienteService.Models;
using System.ComponentModel.DataAnnotations;

namespace ClienteService.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public ICollection<Logradouro> Logradouros { get; set; } = new List<Logradouro>();
    }
}
