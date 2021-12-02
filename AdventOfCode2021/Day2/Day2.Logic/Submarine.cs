﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Logic
{
    public class Submarine
    {
        private readonly List<(string, int)> _course;

        public int HorizontalPosition { get; }
        public int Depth { get; }

        public Submarine(string course)
        {
            if (! string.IsNullOrWhiteSpace(course))
            {
                _course = course.Split("\n")
                    .Select(l => l.Split(" "))
                    .Select(a => (a[0], int.Parse(a[1])))
                    .ToList();

                HorizontalPosition = _course.Sum(p => p.Item1 == "forward"? p.Item2 : 0);
                Depth = _course.Sum(p => p.Item1 == "down"? p.Item2 : p.Item1 == "up"? -p.Item2 : 0);
            }
        }
    }
}