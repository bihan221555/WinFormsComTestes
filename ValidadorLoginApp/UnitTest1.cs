using Componentes;
using Xunit;

namespace TesteProjetoSenha
{
    public class ValidadorSenhaTestes
    {
        [Fact]
        public void TesteSenhaValida()
        {
            var validador = new ValidadorSenha();
            var resultado = validador.SenhaValida("Teste123!");
            Assert.True(resultado);
        }

        [Theory]
        [InlineData("abc", false)]           
        [InlineData("abcdefgh", false)]       
        [InlineData("Teste123", false)]       
        [InlineData("teste123!", false)]      
        [InlineData("TESTE123!", false)]      
        [InlineData("Teste!@", false)]        
        [InlineData("Teste123!", true)]       
        public void SenhaValida_DeveRetornarResultadoEsperado(string senha, bool esperado)
        {
            var validador = new ValidadorSenha();
            var resultado = validador.SenhaValida(senha);
            Assert.Equal(esperado, resultado);
        }
    }
}
