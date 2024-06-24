namespace BestPractices.Application.Requests;

public class ClientRequest
{
    /// <summary>
    /// Nome
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Numero de telefone
    /// </summary>
    public int PhoneNumber { get; set; }
}