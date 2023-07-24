namespace ClienteService.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public List<LogradouroDTO> Logradouros { get; set; }
    }
}
