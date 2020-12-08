using System.Collections.Generic;
using Xunit;

namespace SistemaDeAparcamiento.Tests
{
    public class SistemaDeAparcamientoEspia : Logica.SistemaDeAparcamiento
    {
        public List<string> TextoEscritoEnConsola { get; } = new();
        public Queue<string> TextoAEntrarPorConsola { get; } = new();

        public SistemaDeAparcamientoEspia()
        {
            _escribirAConsola = s => TextoEscritoEnConsola.Add(s);
            _leerDeConsola = () => TextoAEntrarPorConsola.Dequeue();
        }
    }

    public class SistemaDeAparcamientoDebe
    {
        [Fact]
        public void RetornarFalse_CuandoSePreguntaSiDebeTerminarAlEmpezar()
        {
            var sut = new Logica.SistemaDeAparcamiento();
            Assert.False(sut.DebeTerminar());
        }

        [Fact]
        public void MostrarMenuCon7Opciones()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.MostrarMenu();

            Assert.Collection(sut.TextoEscritoEnConsola,
                t1 => Assert.Contains("1)", t1),
                t2 => Assert.Contains("2)", t2),
                t3 => Assert.Contains("3)", t3),
                t4 => Assert.Contains("4)", t4),
                t5 => Assert.Contains("5)", t5),
                t6 => Assert.Contains("6)", t6),
                t7 => Assert.Contains("7)", t7));
        }

        // Opcion 1
        [Fact]
        public void AvisarQueSeEstacionoCorrectamente_CuandoSeEstacionaEnLaPlayaIzquierda()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.TextoAEntrarPorConsola.Enqueue("1");

            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Collection(sut.TextoEscritoEnConsola,
                t1 => Assert.Contains("correctamente", t1),
                t2 => Assert.Contains("4 vehículo", t2));
        }

        [Fact]
        public void AvisarQueNoSeEstacionoCorrectamente_CuandoSeEstacionaEnLaPlayaIzquierdaLlena()
        {
            var sut = new SistemaDeAparcamientoEspia();

            sut.TextoAEntrarPorConsola.Enqueue("1");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("1");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("1");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("1");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("1");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Contains("no hay más lugar", sut.TextoEscritoEnConsola[9]);
        }

        // Opcion 2
        [Fact]
        public void AvisarQueSeEstacionoCorrectamente_CuandoSeEstacionaEnLaPlayaDerecha()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.TextoAEntrarPorConsola.Enqueue("2");

            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Collection(sut.TextoEscritoEnConsola,
                t1 => Assert.Contains("correctamente", t1),
                t2 => Assert.Contains("6 vehículo", t2));
        }

        [Fact]
        public void AvisarQueNoSeEstacionoCorrectamente_CuandoSeEstacionaEnLaPlayaDerechaLlena()
        {
            var sut = new SistemaDeAparcamientoEspia();

            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Contains("no hay más lugar", sut.TextoEscritoEnConsola[13]);
        }

        // Opcion 3
        [Fact]
        public void AvisarQueSeEstacionoCorrectamente_CuandoSeEstacionaEnLaPlayaCentral()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.TextoAEntrarPorConsola.Enqueue("3");

            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Collection(sut.TextoEscritoEnConsola,
                t1 => Assert.Contains("correctamente", t1),
                t2 => Assert.Contains("7 vehículo", t2));
        }

        [Fact]
        public void AvisarQueNoSeEstacionoCorrectamente_CuandoSeEstacionaEnLaPlayaCentralLlena()
        {
            var sut = new SistemaDeAparcamientoEspia();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("3");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Contains("no hay más lugar", sut.TextoEscritoEnConsola[15]);
        }

        // Opcion 4
        [Fact]
        public void AvisarQueNoHayAutosEstacionados_CuandoSeIntentaEgresarConElPlayonVacio()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.TextoAEntrarPorConsola.Enqueue("4");

            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Collection(sut.TextoEscritoEnConsola,
                t => Assert.StartsWith("No hay", t));
        }

        // Opcion 5
        [Fact]
        public void RetornarCero_CuandoSeVerificaCantidadDeAutosIngresadosSinNinguno()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.TextoAEntrarPorConsola.Enqueue("5");

            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Collection(sut.TextoEscritoEnConsola,
                t => Assert.Contains(" 0 vehículos", t));
        }

        [Fact]
        public void RetornarUno_CuandoSeVerificaCantidadDeAutosIngresadosConUnoSolo()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.TextoAEntrarPorConsola.Enqueue("2");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("4");
            sut.TextoAEntrarPorConsola.Enqueue("1");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            sut.TextoAEntrarPorConsola.Enqueue("5");
            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Contains(" 1 vehículo", sut.TextoEscritoEnConsola[6]);
        }

        // Opcion 7
        [Fact]
        public void MostrarMensajeDeDespedida_CuandoTerminaElPrograma()
        {
            var sut = new SistemaDeAparcamientoEspia();
            sut.TextoAEntrarPorConsola.Enqueue("7");

            sut.IngresarOpcion();
            sut.EjecutarOpcion();

            Assert.Collection(sut.TextoEscritoEnConsola,
                t => Assert.Contains("Gracias", t));
        }
    }
}