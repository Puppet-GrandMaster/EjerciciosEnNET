using System;
using Xunit;

namespace Palindromo.UnitTests
{
    public class Palindromo
    {
        private readonly string _aVerificar;

        public Palindromo(string aVerificar) => _aVerificar = aVerificar;

        public bool EsUn() => VerificarLetraPorLetra(_aVerificar.ToUpper());

        private bool VerificarLetraPorLetra(string palabra)
        {
            for (var index = 0; index < palabra.Length / 2; index++)
            {
                if (palabra[index] != palabra[palabra.Length - 1 - index])
                {
                    return false;
                }
            }

            return true;
        }

        public bool SinEspaciosEsUn() => VerificarLetraPorLetra(_aVerificar.Replace(" ", string.Empty).ToUpper());
    }

    public class PalindromoDebe
    {
        [Fact]
        public void RetornarFalse_CuandoNoEsUnPalindromo()
        {
            var sut = new Palindromo("esto no es un palindromo");
            Assert.False(sut.EsUn());
        }

        [Theory]
        [InlineData("neuquen")]
        [InlineData("Neuquen")]
        [InlineData("43334")]
        public void RetornarTrue_CuandoEsUnPalindromo(string palindromo)
        {
            var sut = new Palindromo(palindromo);
            Assert.True(sut.EsUn());
        }

        [Theory]
        [InlineData("Sometamos o Matemos")]
        [InlineData("Isaac no ronca asi")]
        public void RetornarTrue_CuandoEsUnPalindromoEliminandoEspacios(string palindromoConEspacios)
        {
            var sut = new Palindromo(palindromoConEspacios);
            Assert.True(sut.SinEspaciosEsUn());
        }

        [Theory]
        [InlineData("Sometamos o Matemos")]
        [InlineData("Isaac no ronca asi")]
        public void RetornarFalse_CuandoEsUnPalindromoConEspaciosSinEliminarlos(string palindromoConEspacios)
        {
            var sut = new Palindromo(palindromoConEspacios);
            Assert.False(sut.EsUn());
        }

    }
}
