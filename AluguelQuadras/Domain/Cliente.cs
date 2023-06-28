namespace AluguelQuadras.Domain
{
    public class Cliente
    {
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public List<Reserva>? Reservas { get; set; }

        public bool solicitarReserva(Quadra quadra, DateTime horario)
        {
            var horariosDisponiveis = quadra.horariosDisponiveis(horario);

            if(!horariosDisponiveis.Contains(horario))
                return false;

            int idCliente = -1, idQuadra = -1;

            if(Reservas is not null)
                foreach(var reserva in Reservas)
                    if(reserva.Id > idCliente)
                        idCliente = reserva.Id;

            Reservas?.Add(new Reserva { Id = ++idCliente, Horario = horario, Cpf = Cpf});

            if (quadra.Reservas is not null)
                foreach (var reserva in quadra.Reservas)
                    if (reserva.Id > idQuadra)
                        idQuadra = reserva.Id;

            quadra.Reservas?.Add(new Reserva { Id = ++idQuadra, Horario = horario, Cpf = Cpf });

            return true;
        }

        public bool cancelarReserva(Quadra quadra, DateTime horario)
        {
            var reserva = quadra?.Reservas?.Where(x => x.Horario.CompareTo(horario) == 0 && x.Cpf.Equals(Cpf)).FirstOrDefault();

            if (reserva is null)
                return false;

            quadra?.Reservas?.Remove(reserva);
            Reservas?.Remove(reserva);

            return true;
        }
    }
}
