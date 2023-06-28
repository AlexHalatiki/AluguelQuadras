namespace AluguelQuadras.Domain
{
    public class Quadra
    {
        public int Id { get; set; }
        public TimeSpan Duracao { get; set; }
        public List<Reserva>? Reservas { get; set; }
        public TipoQuadra Tipo { get; set; }
        public Clube? Clube { get; set; }

        public List<DateTime> horariosDisponiveis(DateTime data)
        {
            data = new DateTime(data.Year, data.Month, data.Day);

            var horariosDisponiveis = new List<DateTime>();
            var horariosPreenchidos = new List<DateTime>();

            foreach(var reserva in Reservas)
                horariosPreenchidos.Add(reserva.Horario);

            for(TimeSpan i = Clube.Abertura; i < Clube.Fechamento; i+=Duracao)
                if (!horariosPreenchidos.Contains(data + i))
                    horariosDisponiveis.Add(data + i);

            return horariosDisponiveis;
        }
    }
}
