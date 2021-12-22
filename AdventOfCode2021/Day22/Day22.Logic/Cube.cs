using System.Collections.Generic;
using System.Linq;

namespace Day22.Logic
{
    public class Cube
    {
        private readonly string _vertexes;

        public List<(int X, int Y, int Z)> Vertexes { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }

        public Cube(string vertexes)
        {
            _vertexes = vertexes;
            Vertexes = new List<(int X, int Y, int Z)>();

            Parse();
        }

        private void Parse()
        {
            var axis = _vertexes.Split(",").Select(p => p.Split("=")).Select(p => p[1]).Select(p => p.Split("..")).ToArray();

            foreach (var x in axis[0])
            {
                foreach (var y in axis[1])
                {
                    foreach (var z in axis[2])
                    {
                        Vertexes.Add((int.Parse(x), int.Parse(y), int.Parse(z)));
                    }
                }
            }

            Width = int.Parse(axis[0][1]) - int.Parse(axis[0][0]) + 1;
            Height = int.Parse(axis[1][1]) - int.Parse(axis[1][0]) + 1;
            Depth = int.Parse(axis[2][1]) - int.Parse(axis[2][0]) + 1;
        }

        public long GetArea() => Width * Height * Depth;
    }
}