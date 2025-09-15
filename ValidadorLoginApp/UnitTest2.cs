using Componentes;
using Xunit;

namespace TesteProjetoSenha
{
    public class ValidadorEmailTestes
    {
        [Fact]
        public void TesteEmailValido()
        {
            var validador = new ValidadorEmail();
            var resultado = validador.EmailValido("usuario@gmail.com");
            Assert.True(resultado);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("usuario", false)]
        [InlineData("usuario@", false)]
        [InlineData("@gmail.com", false)]
        [InlineData("usuario@yahoo.com", false)]
        [InlineData("usuario@gmail.com", true)]
        [InlineData("USER@GMAIL.COM", true)]
        [InlineData(" usuario@gmail.com ", false)]
        public void EmailValido_DeveRetornarResultadoEsperado(string email, bool esperado)
        {
            var validador = new ValidadorEmail();
            var resultado = validador.EmailValido(email);
            Assert.Equal(esperado, resultado);
        }
    }
}
