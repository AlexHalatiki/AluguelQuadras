using AluguelQuadras.Domain;

namespace AluguelQuadras.UnitTest
{
    public class QuadraTest
    {
        private readonly Quadra _quadra;

        public QuadraTest()
        {
            _quadra = new Quadra();
            var clube = new Clube();

            clube.Abertura = new TimeSpan(14, 0, 0);
            clube.Fechamento = new TimeSpan(23, 0, 0);

            _quadra.Duracao = new TimeSpan(0, 60, 0);
            _quadra.Clube = clube;
            _quadra.Reservas = new List<Reserva>();
        }

        [Fact]
        public void HorariosDisponiveis_Ok()
        {
            var horario = DateTime.Today + new TimeSpan(15, 0, 0);

            var resposta = _quadra.horariosDisponiveis(DateTime.Now);

            Assert.Contains(horario, resposta);
        }

        [Fact]
        public void HorariosDisponiveis_NotOk()
        {
            var horario = DateTime.Today + new TimeSpan(15, 0, 0);
            var reserva = new Reserva() { Id = 0, Horario = horario, Cpf = "XXXXXXXXX-XX" };

            _quadra?.Reservas?.Add(reserva);

            var resposta = _quadra?.horariosDisponiveis(DateTime.Now);

            Assert.DoesNotContain(horario, resposta);
        }
    }
}
