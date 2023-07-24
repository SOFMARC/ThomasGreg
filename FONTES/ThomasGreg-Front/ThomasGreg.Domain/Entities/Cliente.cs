using ThomasGreg.Domain.ValueObjects;

namespace ThomasGreg.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Logotipo { get; set; }

        public ICollection<Logradouro> Logradouros { get; set; } = new List<Logradouro>();
      
    }
}