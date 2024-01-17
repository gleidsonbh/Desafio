namespace Desafio.Application.Features.Clientes.Queries.GetClienteList
{
    public class ClienteListVm
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<ClienteTelefonesDto>? Telefones { get; set; }
    }
}
