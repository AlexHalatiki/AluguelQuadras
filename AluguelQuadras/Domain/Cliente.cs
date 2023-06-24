namespace AluguelQuadras.Domain
{
    public class Cliente
    {
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public List<Reserva>? Reservas { get; set; }
    }
}
