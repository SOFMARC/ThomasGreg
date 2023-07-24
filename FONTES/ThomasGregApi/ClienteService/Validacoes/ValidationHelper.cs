using ClienteService.Models;
using System.Runtime.Intrinsics.X86;

namespace ClienteService.Validacoes
{
    public static class ValidationHelper
    {
        #region CLIENTE 
        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email não pode ser vazio ou em branco", nameof(email));
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                {
                    throw new ArgumentException("Formato de email inválido", nameof(email));
                }
            }
            catch
            {
                throw new ArgumentException("Formato de email inválido", nameof(email));
            }
        }

        public static void ValidateNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome não pode ser vazio ou em branco", nameof(nome));
            }

            if (nome.Length < 3 || nome.Length > 100)
            {
                throw new ArgumentException("Nome deve ter entre 3 e 100 caracteres", nameof(nome));
            }
        }

        public static void ValidateClienteId(int clienteId)
        {
            if (clienteId <= 0)
            {
                throw new ArgumentException("ID do cliente deve ser maior que zero", nameof(clienteId));
            }
        }


        #endregion

        #region LOGRADOURO
        public static void ValidateLogradouroNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome do logradouro não pode ser vazio ou em branco", nameof(nome));
            }

            if (nome.Length < 2 || nome.Length > 100)
            {
                throw new ArgumentException("Nome do logradouro deve ter entre 2 e 100 caracteres", nameof(nome));
            }
        }
        
        #endregion
    }
}
