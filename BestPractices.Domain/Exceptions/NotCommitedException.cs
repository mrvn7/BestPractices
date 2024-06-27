using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.Domain.Exceptions
{
    public class NotCommitedException : Exception
    {
        // Construtor que permite fornecer uma mensagem personalizada
        public NotCommitedException(string mensagem) : base(mensagem)
        {
        }

        // Construtor que usa uma mensagem padrão
        public NotCommitedException() : base("A persistencia de dados falhou")
        {
        }
    }
}
