using System.Runtime.CompilerServices;

namespace AluguelQuadras.Domain
{
    public class Clube
    {
        public string? Cnpj { get; set; }
        public TimeSpan Abertura { get; set; }
        public TimeSpan Fechamento { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public Proprietario? Proprietario { get; set; }
    }
}
