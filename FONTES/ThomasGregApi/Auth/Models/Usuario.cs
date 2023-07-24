using Microsoft.AspNetCore.Identity;

namespace Auth.Models
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
    }
}
