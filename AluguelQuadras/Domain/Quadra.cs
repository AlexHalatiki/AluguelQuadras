namespace AluguelQuadras.Domain
{
    public class Quadra
    {
        public int Id { get; set; }
        public TimeSpan Duracao { get; set; }
        public List<Reserva>? Reservas { get; set; }
        public TipoQuadra Tipo { get; set; }

    }
}
