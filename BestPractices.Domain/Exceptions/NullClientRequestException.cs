namespace BestPractices.Domain.Exceptions;

// Definição da classe de exceção personalizada
public class NullClientRequestException : Exception
{
    // Construtor que permite fornecer uma mensagem personalizada
    public NullClientRequestException(string mensagem) : base(mensagem)
    {
    }

    // Construtor que usa uma mensagem padrão
    public NullClientRequestException() : base("Pedido não encontrado.")
    {
    }
}