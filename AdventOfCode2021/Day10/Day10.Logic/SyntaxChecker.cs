﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10.Logic
{
    public class SyntaxChecker
    {
        private readonly string _code;
        private readonly List<string> _validLines;
        private readonly List<string> _invalidLines;

        public SyntaxChecker(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Invalid code");
            }

            _validLines = new List<string>();
            _invalidLines = new List<string>();
            _code = code;

            Parse();
        }

        private void Parse()
        {
            List<char> stack = new();

            foreach (var line in _code.Split("\n"))
            {
                var isInvalid = false;
                stack.Clear();

                foreach (var character in line)
                {
                    switch (character)
                    {
                        case '(':
                        case '{':
                        case '[':
                        case '<':
                            stack.Insert(0, character);
                            break;

                        case ')':
                            if (stack[0] != '(')
                            {
                                isInvalid = true;
                            }
                            stack.RemoveAt(0);
                            break;

                        case ']':
                            if (stack[0] != '[')
                            {
                                isInvalid = true;
                            }
                            stack.RemoveAt(0);
                            break;

                        case '}':
                            if (stack[0] != '{')
                            {
                                isInvalid = true;
                            }
                            stack.RemoveAt(0);
                            break;

                        case '>':
                            if (stack[0] != '<')
                            {
                                isInvalid = true;
                            }
                            stack.RemoveAt(0);
                            break;
                    }

                    if (isInvalid)
                    {
                        _invalidLines.Add(line);
                        break;
                    }
                }

                if (! isInvalid)
                {
                    _validLines.Add(line);
                }
            }
        }

        public List<string> GetSyntaxErrors() => _invalidLines;
    }
}
