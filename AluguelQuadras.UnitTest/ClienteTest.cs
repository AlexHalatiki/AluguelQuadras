using AluguelQuadras.Domain;

namespace AluguelQuadras.UnitTest
{
    public class ClienteTest
    {
        private readonly Cliente _cliente;
        private readonly Quadra _quadra;

        public ClienteTest()
        {
            _cliente = new Cliente();
            _cliente.Cpf = "XXXXXXXXX-XX";
            _cliente.Reservas = new List<Reserva>();
            _quadra = PopulaQuadra();
        }

        private Quadra PopulaQuadra()
        {
            var quadra = new Quadra();
            var clube = new Clube();

            clube.Abertura = new TimeSpan(14, 0, 0);
            clube.Fechamento = new TimeSpan(23, 0, 0);

            quadra.Duracao = new TimeSpan(0, 60, 0);
            quadra.Clube = clube;
            quadra.Reservas = new List<Reserva>();

            return quadra;
        }

        [Fact]
        public void SolicitarReserva_ReturnTrue()
        {
            var resposta = _cliente.solicitarReserva(_quadra, DateTime.Today + _quadra.Clube.Abertura);

            Assert.True(resposta);
            Assert.Equal(_cliente?.Cpf, _cliente?.Reservas?.First()?.Cpf);
            Assert.Equal(_cliente?.Cpf, _quadra?.Reservas?.First()?.Cpf);
        }

        [Fact]
        public void SolicitarReserva_ReturnFalse()
        {
            var reserva = new Reserva() { Id = 0, Horario = DateTime.Today + _quadra.Clube.Abertura, Cpf = "YYYYYYYYY-YY"};
            _quadra?.Reservas?.Add(reserva);

            var resposta = _cliente.solicitarReserva(_quadra, DateTime.Today + _quadra.Clube.Abertura);

            Assert.False(resposta);
        }

        [Fact]
        public void CancelarReserva_ReturnTrue()
        {
            var reserva = new Reserva() { Id = 0, Horario = DateTime.Today + _quadra.Clube.Abertura, Cpf = _cliente.Cpf };
            _quadra?.Reservas?.Add(reserva);
            _cliente?.Reservas?.Add(reserva);

            var resposta = _cliente?.cancelarReserva(_quadra, DateTime.Today + _quadra.Clube.Abertura);

            Assert.True(resposta);
            Assert.Empty(_quadra?.Reservas);
            Assert.Empty(_cliente?.Reservas);
        }

        [Fact]
        public void CancelarReserva_ReturnFalse()
        {
            var reserva = new Reserva() { Id = 0, Horario = DateTime.Today + _quadra.Clube.Abertura, Cpf = "YYYYYYYYY-YY"};
            _quadra?.Reservas?.Add(reserva);
            _cliente?.Reservas?.Add(reserva);

            var resposta = _cliente?.cancelarReserva(_quadra, DateTime.Today + _quadra.Clube.Abertura);

            Assert.False(resposta);
        }
    }
}
