﻿using System.Linq;
using System;
using System.Collections.Generic;

namespace Day3.Logic
{
    public class DiagnosticReport
    {
        private readonly List<string> _values;
        private int _gammaRate;
        private int _epsilonRate;
        private readonly int[] _amountOfOnes;

        public int PowerConsumption { get; private set; }
        public List<List<string>> FilteredValues { get; }
        public int OxygenRating { get; }
        public int Co2Rating { get; }
        public int LifeSupportRating { get; }

        public DiagnosticReport(string reportInput)
        {
            if (string.IsNullOrWhiteSpace(reportInput))
            {
                throw new ArgumentException("Invalid report");
            }

            _values = reportInput.Split("\n").ToList();
            _amountOfOnes = new int[_values[0].Length];

            ClassifyValues();
            CalculateGammaAndEpsilonRates();
            CalculatePowerConsumption();
        }

        private void ClassifyValues()
        {
            foreach (var value in _values)
            {
                var index = 0;

                foreach (var character in value)
                {
                    _amountOfOnes[index++] += character - '0';
                }
            }
        }

        private void CalculateGammaAndEpsilonRates()
        {
            foreach (var value in _amountOfOnes)
            {
                var bit = _values.Count > value * 2 ? 1 : 0;
                _gammaRate = (_gammaRate << 1) | (~bit & 1);
                _epsilonRate = (_epsilonRate << 1) | (bit & 1);
            }
        }

        private void CalculatePowerConsumption() =>
            PowerConsumption = _gammaRate * _epsilonRate;

        public DiagnosticReport(string reportInput, bool useSecond)
        {
            _values = reportInput.Split("\n").ToList();

            FilteredValues = new List<List<string>>();

            List<string> currentSet = _values;

            for (var index = 0; index < _values[0].Length; index++)
            {
                var zeroes = 0;
                var ones = 0;
                var teamZero = new List<string>();
                var teamOne = new List<string>();

                foreach (var value in currentSet)
                {
                    if (value[index] == '0')
                    {
                        zeroes++;
                        teamZero.Add(value);
                    }
                    else
                    {
                        ones++;
                        teamOne.Add(value);
                    }
                }

                if (zeroes > ones)
                {
                    currentSet = teamZero;
                    FilteredValues.Add(teamZero);
                }
                else if (zeroes < ones)
                {
                    currentSet = teamOne;
                    FilteredValues.Add(teamOne);
                }
                else
                {
                    currentSet = teamOne;
                    FilteredValues.Add(teamOne);
                }

                if (currentSet.Count == 1)
                {
                    OxygenRating = Convert.ToInt32(currentSet[0], 2);
                    break;
                }
            }

            currentSet = _values;

            for (var index = 0; index < _values[0].Length; index++)
            {
                var zeroes = 0;
                var ones = 0;
                var teamZero = new List<string>();
                var teamOne = new List<string>();

                foreach (var value in currentSet)
                {
                    if (value[index] == '0')
                    {
                        zeroes++;
                        teamZero.Add(value);
                    }
                    else
                    {
                        ones++;
                        teamOne.Add(value);
                    }
                }

                if (ones > zeroes)
                {
                    currentSet = teamZero;
                }
                else if (ones < zeroes)
                {
                    currentSet = teamOne;
                }
                else
                {
                    currentSet = teamZero;
                }

                if (currentSet.Count == 1)
                {
                    Co2Rating = Convert.ToInt32(currentSet[0], 2);
                    break;
                }
            }

            LifeSupportRating = OxygenRating * Co2Rating;
        }
    }
}