using Xunit;
using AdventOfCode2020.Day19.Logic;

namespace AdventOfCode2020.Day19.UnitTests
{
    public class RulesMust
    {
        [Fact]
        public void Test1()
        {
            const string data = @"0: 1 2
1: ""a""
2: 1 3 | 3 1
3: ""b""";

            var rules = new Rules(data);
            Assert.Equal(4, rules.Count);
        }

        [Theory]
        [InlineData("aab")]
        [InlineData("aba")]
        public void Test2(string message)
        {
            const string data = @"0: 1 2
1: ""a""
2: 1 3 | 3 1
3: ""b""";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWithRule(0, message));
        }

        [Theory]
        [InlineData(4, "a")]
        [InlineData(5, "b")]
        [InlineData(2, "aa")]
        [InlineData(2, "bb")]
        [InlineData(3, "ab")]
        [InlineData(3, "ba")]
        [InlineData(1, "aaab")]
        [InlineData(1, "aaba")]
        [InlineData(1, "bbab")]
        [InlineData(1, "bbba")]
        [InlineData(1, "abaa")]
        [InlineData(1, "abbb")]
        [InlineData(1, "baaa")]
        [InlineData(1, "babb")]
        public void Test3(int ruleId, string message)
        {
            const string data = @"0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWithRule(ruleId, message));
        }

        [Theory]
        [InlineData("aaaabb")]
        [InlineData("aaabab")]
        [InlineData("abbabb")]
        [InlineData("abbbab")]
        [InlineData("aabaab")]
        [InlineData("aabbbb")]
        [InlineData("abaaab")]
        [InlineData("ababbb")]
        public void ReturnTrue_WhenVerifyingRule0WithValidData(string message)
        {
            const string data = @"0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWithRule(0, message));
        }

        [Fact]
        public void Test4()
        {
            const string data = @"0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""

ababbb
bababa
abbbab
aaabbb
aaaabbb";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(2, messages.ThatMatchRule(0, rules));
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            const string data = @"72: ""b""
45: 46 52 | 9 72
85: 9 52 | 9 72
82: 52 87 | 72 77
133: 52 30 | 72 56
118: 7 52 | 70 72
18: 52 113 | 72 52
119: 72 46 | 52 18
25: 19 72 | 103 52
32: 90 52 | 78 72
50: 113 113
71: 72 106 | 52 128
3: 103 72 | 18 52
41: 86 72 | 19 52
96: 86 72 | 108 52
33: 44 52 | 104 72
127: 52 36 | 72 50
51: 72 79 | 52 38
43: 72 50 | 52 106
14: 32 72 | 129 52
6: 2 72 | 33 52
108: 52 72 | 72 52
129: 6 52 | 82 72
34: 127 72 | 3 52
74: 128 52 | 9 72
80: 52 103 | 72 19
2: 134 72 | 13 52
54: 128 72 | 114 52
19: 72 72 | 113 52
0: 8 11
30: 132 72 | 39 52
60: 72 64 | 52 5
4: 18 52 | 114 72
57: 72 71 | 52 54
111: 52 27 | 72 102
76: 122 52 | 75 72
134: 86 52 | 9 72
49: 17 52 | 81 72
124: 103 72 | 86 52
123: 72 28 | 52 121
117: 18 52 | 86 72
26: 51 72 | 58 52
62: 85 52 | 44 72
55: 126 52 | 92 72
115: 72 13 | 52 67
109: 128 72 | 106 52
52: ""a""
93: 60 52 | 133 72
64: 67 72 | 84 52
102: 52 128 | 72 48
84: 86 52 | 46 72
77: 41 72 | 21 52
27: 52 9 | 72 108
95: 89 72 | 105 52
36: 52 72
110: 72 50 | 52 9
9: 72 72
120: 72 19 | 52 18
67: 52 48
112: 65 72 | 119 52
75: 62 52 | 123 72
23: 15 72 | 119 52
42: 131 52 | 61 72
94: 52 91 | 72 18
66: 52 128 | 72 103
10: 113 108
37: 52 18 | 72 50
98: 72 69 | 52 94
126: 115 52 | 29 72
79: 59 52 | 94 72
104: 19 72 | 36 52
125: 96 72 | 4 52
122: 52 73 | 72 112
130: 52 20 | 72 45
90: 72 40 | 52 88
132: 103 52
121: 91 52 | 46 72
7: 52 114 | 72 128
5: 52 66 | 72 41
97: 52 18 | 72 91
89: 72 109 | 52 116
53: 52 108 | 72 128
114: 52 113 | 72 72
16: 1 52 | 110 72
113: 72 | 52
31: 52 14 | 72 12
69: 52 103 | 72 48
128: 72 52
40: 72 3 | 52 83
101: 63 52 | 127 72
1: 72 91 | 52 114
58: 52 111 | 72 99
13: 19 72 | 9 52
35: 22 72 | 125 52
65: 72 114 | 52 91
12: 52 24 | 72 93
46: 72 72 | 52 52
20: 9 72
73: 72 37 | 52 43
15: 52 50 | 72 108
103: 52 52
106: 72 52 | 72 72
21: 36 72
28: 72 50 | 52 46
78: 72 16 | 52 23
70: 36 72 | 19 52
87: 72 107 | 52 47
116: 19 52 | 106 72
29: 72 68 | 52 65
8: 42
68: 9 52 | 128 72
99: 110 72 | 25 52
17: 52 118 | 72 130
11: 42 31
48: 52 52 | 72 52
83: 48 113
105: 52 100 | 72 80
61: 55 52 | 26 72
100: 48 52 | 108 72
56: 52 53 | 72 74
63: 52 106 | 72 9
44: 72 114 | 52 128
47: 52 50 | 72 36
107: 52 36 | 72 91
39: 114 72 | 86 52
86: 52 72 | 52 52
24: 52 95 | 72 35
81: 98 72 | 34 52
131: 49 52 | 76 72
92: 52 101 | 72 57
59: 52 114 | 72 50
38: 52 74 | 72 124
88: 97 72 | 10 52
22: 117 72 | 120 52
91: 72 72 | 52 72

bbabbaabaabaaaababbbbabaabbaabab
baaabaaabaaababbabababaabababaaa
aaabbbabaabbbbbbbbabaaba
aaababbbaaabaabbabbbbabbaaaabbbb
ababaabbaabbbaabbbabbababbabbbbbbaaabbbbaaaabbbabbbaaabbaaaabbaa
bbbbaabaababaaabbbaaaaabbbbabbabaaabaabaabbaaaba
bbaababbbbbbaabbbbbaaaabbbbbabaaaabbbabaabbbaaaa
aaaaaaaaaababaaaabaaababaabbbbaababaaaaaaaaabaaabbaabbbaaabaabababbbbaaabbbbbabb
bbbbabbbbbbbbbbababbabbabbbabbbaaabbbbbaabbbbbaa
bbabaaababbbaabababbabbbabaabbbbbaaabbaaaaabbbaaaaabaabbaabbabba
babbbabaaabbaaaabaaaaabbbabaaaaa
ababaabbaaabbabbbbbbbaaaaabaabaabaaaababbaaaaaaa
baaaababaaaaaaababaaabba
bbaabbbaaabababbbaaaaabbbbbbbaaaaabbaabaabaaabaabbbaabaaaaaababbababbbbb
bbababbbaaabbabababbbabaaabbaababbbaaabaaabbbabbabababab
babbabbabbbaabbbbaabaaabbabababbbbbbbbaa
abbaaaaaabbabbaabbabbabababbaabaabbbaaaa
ababaabbabbbbbabbabbbaaaabbbaabbabbbbabb
aaabbbbaabbbababaabaaaaa
babbbaaaabaaabaaabbabbabbabaabab
aaabbaabaabbabaaaaaaaabb
ababbbabaabbaabbabaababababbbbaa
babbabaaabbbababbbababaaaaaabbaaababaaab
bbaababbbabaaababbaaabab
aabababbbbaabbbbabaabaababababaaabababab
baaaaabbbbbaabbbbbababbbbbbabbab
baaaabaaabaabaaabbabaaaababaaaab
aabbbabababaaabababbaaaa
ababbbaaabababbaaabaaababbaaaabaabbbbbab
ababbbaaaabaaaababababba
aaabbbabaabbaababbbbabbbbbabbabaababbabb
aabbabaaaabbaababbabbabbaaabaabababaaabaaaaaabab
abaaabbbabbaaababaaababa
bbaaabbbbababbababaababb
aaabbabababaaabaabbabaab
bbabbaaaabbbaabbaaabbbbbbbbabaabbbbbabbbbabbaabaabbaababaaabaabb
babbabbabbbbababaaaaabaababbbabbaabaabbbabaaaabb
bbabbaababababbabaaababb
babaaabaaabababbaabababbabbababaabbaaabbbababaaaababbbbbaaaabbbbabbbbaaa
aaabaabaaabbbaabbbabbbbbbbababba
aabaababbbaaaababbabaaaa
aaaabaaabbabababbabbbaab
baaabaabbaaaababbbaabaaaaabbabaaabaaabaabbbbbabbbabaabababaabbaaabbaaababbabbbbb
aabaabbbababbbababaababaabbbaaaa
aabaabbaaaabaabaabaaaaaabababbaababaaabbabbbbabbbaaaaaaabababbabbbbbabaa
baaabbbaaaaaabbbbbaaaaabbabbaabaaaaabbba
baaabaaaabbbbaaaaabbaababbabbababaaaabbbbabbaaabaabbbaabbaaaabbb
baaabbbabaabbabaabbabaaabaaabbbaabbaaabbabaaabab
abbaaabbaaabbabbabaaabba
aaaaaaabbabbbabababbbaaaababaabbabbaaabaabbaabab
aabababaaabbaabbbbaabbbababbaaaa
aabbbabaaabaabbbbbbabaabababbbbb
bbbababbbabbbbbbbabaaabaaaabbabaaabbbbabbabababaaabaaaaa
abaabbaabbbabaabbabaaabbaaabbaaaaabbaaabbaaabbbbbabbaabb
abbbbbabaabaabababababbaaabababbaabbbababbaabaaa
aaabbaabaabaaaabbbbabbbbbabaababaaaaabab
aabbbaabbbbbababaabbbbbbaababbbb
bbababbbaabaaaabbaaaaabbbaababaabbaabaab
aabaababaabbbbbbbabbbbab
aaaaabaababbbabbabbbaabbbbabbaaa
baaaabababbbabbbbaaababbbbbababaaaaaaabb
baaaabaabaaabbaaabbbbbbaabaabbaabbbbbbabbbbbbbbbbabaabababbbbabbaababbbb
bababbabaaabaaaaaaababbbbbabbbaabaaabbbb
bbbbbbbabbabaaabaaaaaaabaabaaabaaaaaaaaababbaaabbaabbaaababaaabbabaaaaaa
abbaaababbbabaabbaaabbab
aabaabbbabaaaababaaabbbabaaaabbbbabbbababbbbabaaaaaababbaaabaabbbbbaabababbaabbb
abaaabaabbabaabbaabbaabaababaaaa
babbabaabaaaaababaaaabba
bbabbbbaaabbbabaaaaabbbb
abbabababbabbbbbaaabaaabaaaaabbaabbabbababbaabbaaabbbabbabbaabbbaabbabaaabaabbab
baabaaabbbbbaabbbaaababa
bbaaabbabbbbabbabbaabbaabaaaaabbabaabbba
babbbabaaabbbaaababababb
abaabbbbbbbbbababaaabbbabbababaaabaaaabababaaaab
bbbbbabbbabbbbbababbabaaabbbaabbbbabbbbbabbabababababaabaaabaaabbaaabaaaaaabbaaa
bababababbbbbbaaaabbbbaabbaaabaababbbbaaabbabbab
ababbaabababaababbbbbabbbbabbababaaabbbabaaaabbbaaaaaaba
abaabababbbbabbbbabbaaab
bbaaaaaaabbababaabbbababbabbbabbbaabaaaabbabbaba
abbbaabbabbabaabbbbbbbaabaaaaabbbbaaaabbbbbbabba
aabbbbbbaaabbaabaababbbababbabaaaaabbaaa
abaabbaaaabababbabbabbabbbaaaaab
babbbababbbbbbbababaaaaa
baabbbbbaabbbaabbabbababbbbbbbbb
bbaaabbbbbbabaabaaaaabaa
bbababaaabbabbabbabbbaaabbabbbab
bbbbabbababbababaababbaa
bbababaabbabaabaabbaabab
aabbbaabbbbaababbabababa
ababaaababbbbaaaabbbbaaaaaababbb
baaaababbbaabaaabbabbbabaababbabbaaaaaaabbaaaaaa
abbbababbaababbbbbaabbbbababbbaabaaababaabaababbbabbbbab
bbabaaabbaabbaaabbbaaabaaaaabbabbaaaabaaabbbbabbbaabbbbbabbabaababaaaaab
bbbbabbabbbbbbaaaaaabbbbabaabababbabbbbbbabaabbaaabbbbbbbbbbaaaa
baababaaaaabbbaaabaabbba
bbbbababbbabbaabbbabaaababbaaaababababaa
aaaaaaaaaaaaaababaaababbabbbabaa
aaabbabababbbaaabaabbbbbababbbbaaabbbabb
aabaaaabbbbbaaaaababbaabaaabbbbabbaaaaaabbababbbaababaaabaabbaabbabaaaaa
aaaabaaabbaabbaaaabbabba
bbbbaaabbaababaaababbabb
abbbbababbbbabbbbbbbababbaabbbbbaaabaabaabababbabaaabaaa
baabbabaabbbaababbabbaba
bbbbaabbbabbabaaaabaaaaababbaababaaabaabbbaaabaaaaababab
abbbbbbababbabbbbaababababbabbabababbbbb
aaabbbabbbbaaaaaabbbabaababababb
aabbaaabaaabaaabbbaaabaaaabbaaaaaaabababbbaabaab
babaababbaabaaaababaaaaa
aaabbbaaaabaabbbaaabbbbb
abaabaabbaabbabaaaabbbbaaabbbbabaabbbabb
baaababbabaaababaaababbababbbbba
aabbaaaabbabaabbbabaaabaaaaaaaabbbbaaaaa
bbbabbbbaabbbbaabbbaaaabbbbaaabb
abaaabababbabababbaabbbabaaabaaaaaaaaaabaabbbaaaaabbbbbbabbabbaaabaaaaaa
bbbbbbbabbabbaabbabbbaaabaabbaaa
bababbabbaabaabbaaabbbbabaabbbbaaabaaabb
bbbbbababaaaaabbabbbbbbabaaaabab
babbabaabbbbaaabaaabbbbaababaabbaabbaabb
ababaabbbbbaaababaabbaaaabbabbbbaaabbaaa
ababbaabbbbbbaaaaaabbbbb
babbabaababbabbabaabbbab
bbaabbaabbbbaabbabbbbbbaabbbaabaaaababbbbaaabbbbbaabbaaa
aabaabbbbabbbbbbabbabbaaabaabababbbbbabbbbaabaaa
abbbbbbaaabbbbaaabbabbbb
aaaaaaaaababbbabaaabbaabababbbba
baaabbaabaaaabaaabaabaaabbaabbbbaaaaaaababaababb
ababbbaababbbbabbabaaaaabababbba
aaaaabaaaaabbbababaaabbbabbbabba
bbbabbbaaaaaaaaaaaabbbbb
abbbbbbabbabbabbabababaa
baaaaabaaaaabaaabbaabbba
baaaabbbaababbbaaaaaaabb
bbbabaabbabbabbbabaabbbbaabbaababaaabaaababaabbb
bbbabbaabbbaabbbbbbabbbabbababababbabbbb
baabaabbbbbaabbaaaababab
bbabbaabbababbabbbabaabbbabbbbbaaaabbabaabbbbbbbababbaba
babbabbaabbaaabbbbabbbbabaaaaaaabbbaaaaa
abaabbaabbbabbbaabbabaaaaababaaaaaaaabbb
aababbabbbabbaabbabaaabbabbabaabbbbaaababbabbaaabbaaaababbbaaabbbaabaabaabababaa
abbabababbaaabbbbaababbaabaabbbbbbbbbbaa
bbbabbbabbabbbbabaaabaaababaaababbbaababbbbabababbabbbabaaabaaaaaabaabbb
baaaaaababbabaabbbabaabaabbbbbabaaababab
baabaabababbbbbabbbbaabaaaaabbbb
baabbabaababbbabbabbbbab
bbbbaabbbbbaaaabbbbbaaaa
bbbbaababaabaaababbbbbaa
bbbbbabbaaabaababbbaaaababaaabba
ababbbabbbbaaaababaaaabbbbaabbbaaaaaababababbbbababbbbbaababbbabaaaaaaababaabbababbbaaaa
aabaababbbbbababbaabbbab
baaaaababbbababbababaaab
baabaabbaaabbaaaabaabbbabbabbbbababbbbab
abbbbbbababbbabaaabababbbbaabbbabbbbababaabaaabb
bbabbabbabbabababaaaabba
abbabbbabbbbbababaaabaaa
bbbbbaabbabbbbaaabaaaaaabbbabbabaabbbabbabbabaaaabaababbbbbaaabb
baaabbbaaabaabaababaabab
baabaababaaaaabaabaabbaababbbbbabaaabbababbaabab
bbabbbbabaaaabaaaabababbabbabaab
babbaababaaaaaabbbaabaab
abaabbabaaabbbabaaaaabbbbbabababbbbaabbabbbabbbbabaaaaab
ababbbabaababababaabaaaa
abaaabaaababbbabbaababaabaabbaab
aaabbbbabbbaabbabbabaabbbaabbbaa
aaabbbaaaabaabaaabbbbbbb
abbbbabbababaabbbbaababbaabaabbbabbbbabbababbbab
baabaabbbbaaaababbabaabbbbabbaaaabbbaaaaaaababaaaabaabbbbbaaaaabbbbaaaaaaaaabbababbabbba
abbaababbbaaaaabbaabbaaa
babbbbabbbaababaaaaaaaaaabbbbaabbbababbbabbaaaaabababbaabaabbaaaaabaabbbaaaaaaaaababbbbbabbaabaa
abbbabababbabaaaababaaaaababbbbaabaabbbababbaabb
abbaaabaaabbabaaababbaab
bbaabbbabaabbbbbabbabbbaaabbaaaabbaaabbbabbaabbababbbbababbaabab
abaaabbbbbabaababbabaaaa
bbababbbbbbababbaaaaaaabbabaaabb
bbbaabbbaabbbbaaabbabbaabaabaabbbababaaa
babbbaaaaabaabbbabbbbbaa
abaabbaabaabbbbbabbbaabbaaabbaaa
abbbaabaababbbabaaaaaaaabbbabbbabbbaabab
aaaabbaabbabbaabbbaababaabbabbbbabaaabbaabbbbbbbaababbbbbbaabbabaabbbaaabbaabbba
abababbabbabbabbbbabbbab
bbbababbaaaabaaabaabbbba
bbbbaababbbbbbabbbbbabbaababaabaaababaab
bbaaaaaaaabbbaaabaaabaab
babbbbbbbbbbbaaabbaaabbaaabbabbaaaabbaaa
abaabbabaaabaababbbaaabb
abaababaaaaaaabbbababaabaaaababaabbabaabababbbba
aaabbabaabaababaababbbba
bbaaaaaababaaababababaaa
abbabaaabaabaaabbabbaaba
abbabababbabaabbabbabababbbaaaaa
aabaaabaababbbaaababaaab
bbabbbbaabaaabbbabbaaaab
bbbbababbbbaaababbbaaaba
bbbbbbababbbbbbaaaaaabab
bbababbbabaaabaabaabbaaaabbbabbabbbbbbaaabbabbbb
baababbbaaabbbaaaabaabbbaabaaabb
abaabbabbaaaabababbaabbb
bbbabaababbbbbbabaabaaabbabbbbbbbbbaabaabbabbbaaabbababb
babbabbbbbbbbabbbaaaababbbbbbbbababababa
baabababaabbaabbaabbabba
baabaababaaaaabbbabaabbbababbbaaabbaaaba
bbbbabbbbaabbbababbbaabaabaabaaaaaaaabaaabbaaaaa
bbabababbaabbabaabbabbaabaababaabaaaabba
abbbbbbaaaaabbaabbbbbaabaabbabbbaabababaaaababbbbabbbbbabaaabbab
bbbbaaabaaaabaaaaabbbaab
aabbaabbaaaaaaaaabbbbababaabababbabbabbbbbbbababaaabaabb
bbabababbabbabbbbaaaabaaaabbaababbbaaaaaabbbaaaa
bbabbabbaaabababbabbbbababaabbabbbbabbbababbaaab
abaaaaaabbbaabaaaabbbbabbababaab
aabababbbabbabbabbaabaaa
ababbbaaaaabbabaaaabbabbaaaaaabb
baaaababbbaaaababbbbbabbbbbaaabaabbabaaabbbbbabaaaaaaaababbbababaabbbbbbaabbbbaa
baabbbbbbbbbaabaabbababb
bababbababaabbbbababaaab
baababbbbabbaabbabbabbaabababbabaaaabbbaabaabaaa
aabaabababaaaabaabababbbbaaabaaaabaaabab
abbaaaaababbabbabaaaabbbbaaaabba
babbbaaabaaaaabbbabbbbab
ababbbabbaabbabaabbbabba
abaabbabaaaabaabbaaabbbbbbbabbaaaaabaabb
bbbaabbaaabbbaabbaabaabaababbaab
ababbbaabbbbbbbabaababaaabbabbabaababaaabbbaaababaabbaab
bbbbbbbabbaaaaaaaaabbbababbbbbbb
aabaaababbabbabaaaaabaaabbabbaabaabbbbbbababaaaa
baabaaabaaabbbabbababbabababbaba
abbbabbbababbabbbbbbaaaababbabbbaaaaaaaaabbaabbabbaaaaabbbabaaaabababbbaaabbabbb
baabaaabbabbababbbbaabbaaaabbaabbbbbabbbabbbaaabbbbabaaa
abaaabbbabaabaaaabbbbbabaaabbbbabababbbbbabbbbabaabaaaaa
aaaaaaaaabaaaababbbaaabababababa
bbbbaabbbababaaaaaaaaaab
aaabaaaabaaaababbabbbbbbaaaabbababbbabaa
babaaababbbbbbbaabbbbabb
baaabbaaaabbbbaabbbababa
baababbbaababbbabbbaabbbbbbbabaaaabbaaab
baaaabaabaabaabbbababbababbbaabbaaabbaabbaaaabba
baabaababbbaabbbabbabababaaaaaaa
bbbababbaabbababaaaaabbb
bbbabaaaaaaaaaaabbbaabbbbabaabbaabaaabbbabbaabbbbabbbbab
aaaaaaabbaababaaaaabaaaababbbaab
abababbaababbbabaabbbbaaaaaabaaaabbaaaba
baababbaaabaabbbbbbaabbabbbbaabbaabbabaabbabbbabaabbabba
abaaabbbbabbbaaabbbbaabaabaabababbaaabbbaabbbbabbababbbabaabbaaabaaabaaa
aabaaabaababbaabbbbbbbabbaaaaabbaaaabbba
aabbabaaabbbbabababbbbbbbaaabbbabaabbaaababbbbabbbbabaaa
abaabbbbbbbbabbbabbaaaaabbaaaaaaabbabbbbabababaa
ababaabbbbbbabaaabbaabba
bbbbababaababaaaaaaabbaabaabaaaa
abbbababbbbbaaababaaaabb
aabbbbbbaababbbaababbbabbaabbabaabaababaaaabaaab
aabaababaaabbbaabbaababababbbaaaabababaa
abaabaabbabbbababbaaaabaabaaabaabaabaabbabbababbaaabaaababaaabba
baaaaabbbbbaaaabbbbbbabb
abbbababbbbbbbbaabbaaaaababbbabbabababbaabaababb
aabbaababbabbaabbbbbaabaaaabbabbababbaba
ababbbaababbbbbabbbabaaa
abaaabbbabababbaabaaabbb
abababbabbabbababbbaabbaababbbaaaabbaaab
abbbbabbbaabaabbbaaaabbbbaaabbbbbbbabbbaababbababbbabbab
bbbbbaabbbaababbabbbaaaababbbabaaaababaaabaabbaa
ababbbaababababaaabaabbbabaaabbbbaabababbabbbbbaababbaaa
baababaabbbabbbbaaabaabb
babaabbbbbaabbbbbbabbabaabbbaaaaabbaabbabbbbaabaabbabbbbbbabbbaa
baabbabaaabbbababbaaaaba
abbbbbabbaaabbbabbaabbaaaabbbbaaaabbabbabaabbbba
aaaaaaabbaaabbbaaaaabbab
baabbbbbbaaabbbbaabbabaaaababbabbbaababaaabbbbbaabaaaaaabaabaabababbbaaa
aabbaaaaabbabaaaabbbbbaa
bbbabaabbbaaaaaaaabbbabaababaaab
babbabaaaaabbbababaaaaaa
baabbabaabaaabbbaabaaaaa
aabbaababbababbbbababaabaabbbbba
abbbbabaaabaaababbbbbaaaaaabaaab
bbbabaabbbbbabbaaababaaa
bbbbbabaabbaaabaaaabbbaaabbbbbbabaabbbaaabbbbbbbbaabbaaa
bbbbaaaabaabaabbbbabbabbbbbbbabaaaaabaaabbabbbbbbaabbbabaaabaabb
bbbbbaaabbbbabaabbabbbbbbaabaaabbabbbbbaabbbabbaabbbbbaa
aaabbbabbabbabbbbabaaaaaabbbbbaaaaababaaaaaaabbaabbabababababaaabbbababaabbaaaabbaaabaaababbaabb
abbaaaaaabbababaaababababaaaaabbaaabbaaa
aaaabaaaaabbabaaaaaabbaa
bbbbbbbabaababbbbbbbaaaabbbbbaab
ababaaaababbabbabbbababaabbaaabbabbbbbbbaabbababbbabbaba
bbbbbbbaaaaaababbaabbaaaaaababbbabaaabab
baabbbaaaaabbbbabbababbaaaaababaabbababaaaabbbbbbbbaaaababbbbbaababaaabb
bbbabbbaaabbbaabaaababbaaaabbaaa
baabaababbbbbaaabbbbabaaaabbabbaaaabaabb
abbbaabbabbabbabbbbaabbbbbabbbab
babbabaaabbabbbabaababaabbabaaba
baababbbbaaaabaaabbbaabbbbbaaaaa
bbaababbaaabbbbabbbabaaa
babababaaabbababbbbbabbbbbbababbabbbabbaaabbabbbabbaaaabbabbbabbaabbaaba
bbbbaaaabaaaaaaabbaaabaabaaaababaabaababbbbabababbabbbbaabbaaaabbbbaaababbbabbababaababb
babaaabbaabaaabbbabbbaabaaaabbbaaaaaabababababbabbababba
aaaabaaabbabaaabaabbbaaabbbbabaa
abbababaabaabbaabbbababbbbabbbbbaabbaaaaaaaabbabaaababbbbbabbbaa
aababbbababbabaabbbbabbaaabaaababbbbabababaaabaaaababaaaaabbaaab
ababbbaaaababbbaabbbbabaabaaabaabbbaabbaabbbbbaabbbaaaaabaabbabb
bbbabbaabaabababaabbababaababaaa
aaaaaaabbbbbbbabbabaabaa
abaabaaaaabbaaaabbbbaabaaabaabaabbbaabaa
aabbabaabaaabbaaaaaabbbb
abbabbaabaabababaabbbaabbbbbaababbbbabbbabbbaaab
abbaaabbabaaaabaaaaaabaaaababbbbbaabaaabaaabaabbbbabbabbbbbaaabababbabbabbbbbaaa
abaaabbbbabaaaaaabbaaababaaaaabaababbaababaabaaaabaaaaabbbaaaaab
aababababbbbbbbaabaabbabbbbbbaaaabbbaaaa
aabbaabaaabbaaaaaabaababaabbbbab
aabaaababbaaaaaabbababababaaaaabbababaab
baababaababbabbbabbaabaababbaabbaabaabbabbbbbaab
abaaabaaaaabbbaaabbababababbbabaaababaaa
aabaaababbbbbabbbaabbabb
aaabbabbaaabbbaabbbbbbababbababb
aabaaaabaabbbbaaaaaabaaabbaabbbaabbbbbbb
bbbbabaaaabbababbbabaaabbabaabba
baabaabaaabababababbabbbbbababaaaaababab
aabbbaaaaabbbbaaababbaaaababbbbaababaaaabbbabaab
abbaaabbbaabbbbabababbbabaabbbbaaabbabaabbaaaaba
aaaaaaabbbabaabbaabbbabaabbababaabbbbbbaabbbbaaaabababaaaaaabbbbaabbabba
abbbbabaabaabaabbbabbbbaabbbbabaabababbbbbaabbabbaabaaaa
abaabababbbbbabbbabaaaab
bababbabbbbabaaabbaaaabb
abbabaaabbbababbbbbaabbaaabbbbaababbaaba
bbbbaabaaabbbbbbabaabaaaaabaababbabbabbbabaaabab
babbabbbbbbabbaabbbabaabbbbbbbbb
babaabaaababbbbaabaabbbaababaaabbbabbbaaaaaaaaaabaababbbbaabbaaa
bbbbaabaabbabbaaabaabaaababababa
abbaababbbbabbabaabbbbbaababaaabaaabbbaaabaababbbbbaabaa
aabbaaaabbbbababaaaabbab
aabaababbabbbabaaabababaabaaabbaabaaaabb
bbabbabbbbaabbbbabaabaaaaaaaaaababaaabba
aaababbaabababaabababaaababaabaaabaaaabb
baaabbbabbaaaaabbaabbbab
bababaabbabbbababaaaababbabbaabbbbbaababbabbabbb
bbababaaabbbaabbaaabbbabaaabbbaabbbaaaaa
aabbbbaaabbbbbabaabaaababbaabbaaaabbbbbaabaaababbbbaabab
aaaaaaabaaaababbabababbaaababaabaabaaaaaabbaaaaaabaabbbaaaaabaaa
abaabbbbbbbabbaaaababbab
bbaaaaaaababaabbbaabaaabaababaaa
aabbbababaabababbabbbaab
abaabbbbbbaaaaaabbbbbbbabbbbabbbbabbaabb
aabbbbaabbababaabababbba
bababbabaaaabaaabaababaaaaaaaabb
bbbbaababbbabbaabbaabbaaabbbaabbbbabbaabaaaaaabb
bbbbabbabbbbaabaaaabaaaabaaaaabbaaabbbbaabaabbbaaabaaaaaabbaabbb
abbabaaabbaababbaabaaabbbbabbaabbbaabbbb
bbaaabbabbbbbababababaababaaaaaababaaaaaaabbbbab
aababbbaabbbbabaabbabaab
bbbaabbbaaaaabaabbaaaaab
bbabbabbbbaaabbbbbaaaaaababaabbaababbabbabaabbbabbaaaabb
aaabbabaaabaabbbbbaababbbaaaaaababbabaab
abbabbabbbaabbaabbaaabaa
abaabbabaaaabaaaaaaaabab
abbbbaabaabbabbbaabaaabbbaaaaaaa
abbabbaaaababbbabbabbababbaababaabbabaabbbbaaabb
aabaaaaabbbababbbaaababbabbbbababababaaabbabbbba
aaabbabababbbababbbaabbbbaabbbbaaababaaa
aabababbaaabaaaabbababaaaaaababb
abbaaaaaabababbaabaabaababbaaababaababbbaaaababbbabbaaabaabbabbaabbaabba
bbaaaabaaaabbaabbbaaaabaababbbbb
ababbbabbaababbbabaabaababbbababbbaabbaaabaababbabaaaaab
aabaaabaababaabaababaaaa
baabbbbbbaaaaabbbaabbbaa
abbabbabbabbabbbabbbbabaabbbabbb
ababbaabaabbababbbbababbbbbbabaabbabbbabbabbbbaa
bbbabaabbababbabbbabbbaa
aabaabbbaaabbababaabaaababababbbaabababbabaabbbabaaabaabbababbba
abaabaabababaababaabbabb
bbaabbbaaaabbbabaaababaa
bbbbabbbaabbaaaaabaaabba
baaaabbbbbbbaaabbaaaaabbabaabbabaabaabbbbaabbbabaababbaa
bbabaabbbaababbabbaabbaaaaabbbababaabbbaaaaabbab
babaaababbbabbbbabaabaaababaabbb
baaabbaabaaaabaaaaabaabaaaaabaaaaaabababababaaab
bbbbbabbbbaaaaaabaababbababbaaaaabbaabbb
abaaabbbabbbaabbbaaabaab
bbbabbaaaaabaabaaabababaaaabbbabbbbbabbbaababaab
bbbbabbbbaabbabbaabbbbbbabaaababbbbaaabaaaaabaabaabbaaab
baaaabbaaaaababbbbaaaaabbbbbbbaababbbabb
bbaabbbaababbaabbabbabababbbaababaabaaaa
bbbabbbbbaaaabbbabbbbbbaabaabbabbababaab
baababbbaabaabaabbaababaabaaabbbbbbababbbaaaabba
babbabababbbbbabababbbba
aabbbaaabbaaabbaabaaabab
bbbbbbbaabaaabaabbbbbabaabaababbabbabaab
bbaabbbbaaabbaababaaabbabababbbaaaabababbababaaaaabaaaab
babbbabaaabbabaaaabbbaabbabaabab
bbaaaabaaaaaaabbababbaaaababbbbbabaabaaababbabbbabbaaaaaaaaaababaaabbabbbbbbabaa
ababaabbaabbaaaabaaaaabbababbbba
baaaababbbbbaabbbaaabaaa
aababababbbaabbabbaabbbb
baababbaaaabbabbababbaba
babbabaabbbbbbbaaabbbabb
bbbbbbabbbbbbbabbbbbbabbabaaaabb
bbbaabbbbbbbbababababbbb
aabbaaaabbabbabbbbbaabaa
bbababababbbbaabaaabaababbbbaaabaaaabbab
ababbaabaabbbaababbbaababbabbabbaaabbababaabbaabababaaaaaabaaaaa
aabaababbabbbaaaabababbaaaaabbab
abbaaabbaabbaababbbabbbaababaaaa
aabaabaabbbbbabbaabbaabaaabaabaabaabaabbaaaabaaababbaabb
aabaaaabbbbbaaaabaaabbbbbbbbaaabababaaabababbaabbbaabaabaababbaabaaaabab
bbbabbabaaabaaaabababbaabaaabbbabbaabbba
bbaaaabababbbbaabaaabbaababbabbaaabbbababaaaabaaabbbbbbb
bbaabbaaaaaaabaaaaabbbbabbbbbabbbaabaabaaabbbabb
bbaabbbaabbaaaaaaaabaabababababbaabaaaaa
babbababbaabaababaababbabbbbbbabbbbbaabbbaabbbbbbabaabab
ababaabbaabbbaabaaaabbba
aaaabaaaabbabbbabbbbababbbaabbab
aaabaaaaaaabbabaaaaaabbb
bbbbabbaababbaabbbabbabbabaaaabbabaaabba
ababbaabbbabbbbbaaaabbba
abbbbabaaabbbaabbbbaaaabababaaaa
aaabaabaaabbbbbbaaabaababbabbabbbbbabbab
aaabaababaaaaaabbababbabbabaabbaabababbabaabaabaaaababbabbaabbaa
baaabbbabbabbaababbbaaab
aabbabababaabbabaaaaaaba
aabbbabaabbaaaaaaababbaa
bbbbbbabbaaaabaaabbabbabbaaaababbbababaa
aababababaaaaabbaaaaabaabbabbabbabbbabba
bbbbaaababbbbabaabbbaaaa
babababbbabababaabaabbabbbbbbbbbaaaabbaaaababababbabaaab
abaaabbbaabbbaabbbbaaaba
aabbaabbbabaaabaabbabaaabbbbbaba
bbbbaaabaaabaabaababbaabbbababbbabaaabbbabbaabaababaabababbbbabbbababbba
abaaabbbaabbaabbabbabbbabbbaaaaabaaabaabbbbbaabbaaabbbbaabababab
bbabbbbaaabbbabaababbbaaababaabb
aabababbbaabbabaaaaaabab
abaababaabbababaaabbaabbbbbaabbaaaaababa
aaabbbabaababbbabbbaaaabbabbbbaabaaabaaa";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(109, messages.ThatMatchRule(0, rules));
        }

        [Fact]
        public void Test5()
        {
            const string data = @"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1

abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaaaabbaaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
babaaabbbaaabaababbaabababaaab
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(3, messages.ThatMatchRule(0, rules));
        }

        [Theory]
        [InlineData("bbabbbbaabaabba")]
        [InlineData("babbbbaabbbbbabbbbbbaabaaabaaa")]
        [InlineData("aaabbbbbbaaaabaababaabababbabaaabbababababaaa")]
        [InlineData("bbbbbbbaaaabbbbaaabbabaaa")]
        [InlineData("bbbababbbbaaaaaaaabbababaaababaabab")]
        [InlineData("ababaaaaaabaaab")]
        [InlineData("ababaaaaabbbaba")]
        [InlineData("baabbaaaabbaaaababbaababb")]
        [InlineData("abbbbabbbbaaaababbbbbbaaaababb")]
        [InlineData("aaaaabbaabaaaaababaa")]
        [InlineData("aaaabbaabbaaaaaaabbbabbbaaabbaabaaa")]
        [InlineData("aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba")]
        public void Test51(string message)
        {
            const string data = @"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31 | 42 11 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42 | 42 8
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWithRule(0, message));
        }

        [Fact]
        public void Test6()
        {
            const string data = @"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31 | 42 11 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42 | 42 8
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1

abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaaaabbaaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
babaaabbbaaabaababbaabababaaab
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(12, messages.ThatMatchRule(0, rules));
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            const string data = @"72: ""b""
45: 46 52 | 9 72
85: 9 52 | 9 72
82: 52 87 | 72 77
133: 52 30 | 72 56
118: 7 52 | 70 72
18: 52 113 | 72 52
119: 72 46 | 52 18
25: 19 72 | 103 52
32: 90 52 | 78 72
50: 113 113
71: 72 106 | 52 128
3: 103 72 | 18 52
41: 86 72 | 19 52
96: 86 72 | 108 52
33: 44 52 | 104 72
127: 52 36 | 72 50
51: 72 79 | 52 38
43: 72 50 | 52 106
14: 32 72 | 129 52
6: 2 72 | 33 52
108: 52 72 | 72 52
129: 6 52 | 82 72
34: 127 72 | 3 52
74: 128 52 | 9 72
80: 52 103 | 72 19
2: 134 72 | 13 52
54: 128 72 | 114 52
19: 72 72 | 113 52
0: 8 11
30: 132 72 | 39 52
60: 72 64 | 52 5
4: 18 52 | 114 72
57: 72 71 | 52 54
111: 52 27 | 72 102
76: 122 52 | 75 72
134: 86 52 | 9 72
49: 17 52 | 81 72
124: 103 72 | 86 52
123: 72 28 | 52 121
117: 18 52 | 86 72
26: 51 72 | 58 52
62: 85 52 | 44 72
55: 126 52 | 92 72
115: 72 13 | 52 67
109: 128 72 | 106 52
52: ""a""
93: 60 52 | 133 72
64: 67 72 | 84 52
102: 52 128 | 72 48
84: 86 52 | 46 72
77: 41 72 | 21 52
27: 52 9 | 72 108
95: 89 72 | 105 52
36: 52 72
110: 72 50 | 52 9
9: 72 72
120: 72 19 | 52 18
67: 52 48
112: 65 72 | 119 52
75: 62 52 | 123 72
23: 15 72 | 119 52
42: 131 52 | 61 72
94: 52 91 | 72 18
66: 52 128 | 72 103
10: 113 108
37: 52 18 | 72 50
98: 72 69 | 52 94
126: 115 52 | 29 72
79: 59 52 | 94 72
104: 19 72 | 36 52
125: 96 72 | 4 52
122: 52 73 | 72 112
130: 52 20 | 72 45
90: 72 40 | 52 88
132: 103 52
121: 91 52 | 46 72
7: 52 114 | 72 128
5: 52 66 | 72 41
97: 52 18 | 72 91
89: 72 109 | 52 116
53: 52 108 | 72 128
114: 52 113 | 72 72
16: 1 52 | 110 72
113: 72 | 52
31: 52 14 | 72 12
69: 52 103 | 72 48
128: 72 52
40: 72 3 | 52 83
101: 63 52 | 127 72
1: 72 91 | 52 114
58: 52 111 | 72 99
13: 19 72 | 9 52
35: 22 72 | 125 52
65: 72 114 | 52 91
12: 52 24 | 72 93
46: 72 72 | 52 52
20: 9 72
73: 72 37 | 52 43
15: 52 50 | 72 108
103: 52 52
106: 72 52 | 72 72
21: 36 72
28: 72 50 | 52 46
78: 72 16 | 52 23
70: 36 72 | 19 52
87: 72 107 | 52 47
116: 19 52 | 106 72
29: 72 68 | 52 65
8: 42 | 42 8
68: 9 52 | 128 72
99: 110 72 | 25 52
17: 52 118 | 72 130
11: 42 31 | 42 11 31
48: 52 52 | 72 52
83: 48 113
105: 52 100 | 72 80
61: 55 52 | 26 72
100: 48 52 | 108 72
56: 52 53 | 72 74
63: 52 106 | 72 9
44: 72 114 | 52 128
47: 52 50 | 72 36
107: 52 36 | 72 91
39: 114 72 | 86 52
86: 52 72 | 52 52
24: 52 95 | 72 35
81: 98 72 | 34 52
131: 49 52 | 76 72
92: 52 101 | 72 57
59: 52 114 | 72 50
38: 52 74 | 72 124
88: 97 72 | 10 52
22: 117 72 | 120 52
91: 72 72 | 52 72

bbabbaabaabaaaababbbbabaabbaabab
baaabaaabaaababbabababaabababaaa
aaabbbabaabbbbbbbbabaaba
aaababbbaaabaabbabbbbabbaaaabbbb
ababaabbaabbbaabbbabbababbabbbbbbaaabbbbaaaabbbabbbaaabbaaaabbaa
bbbbaabaababaaabbbaaaaabbbbabbabaaabaabaabbaaaba
bbaababbbbbbaabbbbbaaaabbbbbabaaaabbbabaabbbaaaa
aaaaaaaaaababaaaabaaababaabbbbaababaaaaaaaaabaaabbaabbbaaabaabababbbbaaabbbbbabb
bbbbabbbbbbbbbbababbabbabbbabbbaaabbbbbaabbbbbaa
bbabaaababbbaabababbabbbabaabbbbbaaabbaaaaabbbaaaaabaabbaabbabba
babbbabaaabbaaaabaaaaabbbabaaaaa
ababaabbaaabbabbbbbbbaaaaabaabaabaaaababbaaaaaaa
baaaababaaaaaaababaaabba
bbaabbbaaabababbbaaaaabbbbbbbaaaaabbaabaabaaabaabbbaabaaaaaababbababbbbb
bbababbbaaabbabababbbabaaabbaababbbaaabaaabbbabbabababab
babbabbabbbaabbbbaabaaabbabababbbbbbbbaa
abbaaaaaabbabbaabbabbabababbaabaabbbaaaa
ababaabbabbbbbabbabbbaaaabbbaabbabbbbabb
aaabbbbaabbbababaabaaaaa
babbbaaaabaaabaaabbabbabbabaabab
aaabbaabaabbabaaaaaaaabb
ababbbabaabbaabbabaababababbbbaa
babbabaaabbbababbbababaaaaaabbaaababaaab
bbaababbbabaaababbaaabab
aabababbbbaabbbbabaabaababababaaabababab
baaaaabbbbbaabbbbbababbbbbbabbab
baaaabaaabaabaaabbabaaaababaaaab
aabbbabababaaabababbaaaa
ababbbaaabababbaaabaaababbaaaabaabbbbbab
ababbbaaaabaaaababababba
aaabbbabaabbaababbbbabbbbbabbabaababbabb
aabbabaaaabbaababbabbabbaaabaabababaaabaaaaaabab
abaaabbbabbaaababaaababa
bbaaabbbbababbababaababb
aaabbabababaaabaabbabaab
bbabbaaaabbbaabbaaabbbbbbbbabaabbbbbabbbbabbaabaabbaababaaabaabb
babbabbabbbbababaaaaabaababbbabbaabaabbbabaaaabb
bbabbaababababbabaaababb
babaaabaaabababbaabababbabbababaabbaaabbbababaaaababbbbbaaaabbbbabbbbaaa
aaabaabaaabbbaabbbabbbbbbbababba
aabaababbbaaaababbabaaaa
aaaabaaabbabababbabbbaab
baaabaabbaaaababbbaabaaaaabbabaaabaaabaabbbbbabbbabaabababaabbaaabbaaababbabbbbb
aabaabbbababbbababaababaabbbaaaa
aabaabbaaaabaabaabaaaaaabababbaababaaabbabbbbabbbaaaaaaabababbabbbbbabaa
baaabbbaaaaaabbbbbaaaaabbabbaabaaaaabbba
baaabaaaabbbbaaaaabbaababbabbababaaaabbbbabbaaabaabbbaabbaaaabbb
baaabbbabaabbabaabbabaaabaaabbbaabbaaabbabaaabab
abbaaabbaaabbabbabaaabba
aaaaaaabbabbbabababbbaaaababaabbabbaaabaabbaabab
aabababaaabbaabbbbaabbbababbaaaa
aabbbabaaabaabbbbbbabaabababbbbb
bbbababbbabbbbbbbabaaabaaaabbabaaabbbbabbabababaaabaaaaa
abaabbaabbbabaabbabaaabbaaabbaaaaabbaaabbaaabbbbbabbaabb
abbbbbabaabaabababababbaaabababbaabbbababbaabaaa
aaabbaabaabaaaabbbbabbbbbabaababaaaaabab
aabbbaabbbbbababaabbbbbbaababbbb
bbababbbaabaaaabbaaaaabbbaababaabbaabaab
aabaababaabbbbbbbabbbbab
aaaaabaababbbabbabbbaabbbbabbaaa
baaaabababbbabbbbaaababbbbbababaaaaaaabb
baaaabaabaaabbaaabbbbbbaabaabbaabbbbbbabbbbbbbbbbabaabababbbbabbaababbbb
bababbabaaabaaaaaaababbbbbabbbaabaaabbbb
bbbbbbbabbabaaabaaaaaaabaabaaabaaaaaaaaababbaaabbaabbaaababaaabbabaaaaaa
abbaaababbbabaabbaaabbab
aabaabbbabaaaababaaabbbabaaaabbbbabbbababbbbabaaaaaababbaaabaabbbbbaabababbaabbb
abaaabaabbabaabbaabbaabaababaaaa
babbabaabaaaaababaaaabba
bbabbbbaaabbbabaaaaabbbb
abbabababbabbbbbaaabaaabaaaaabbaabbabbababbaabbaaabbbabbabbaabbbaabbabaaabaabbab
baabaaabbbbbaabbbaaababa
bbaaabbabbbbabbabbaabbaabaaaaabbabaabbba
babbbabaaabbbaaababababb
abaabbbbbbbbbababaaabbbabbababaaabaaaabababaaaab
bbbbbabbbabbbbbababbabaaabbbaabbbbabbbbbabbabababababaabaaabaaabbaaabaaaaaabbaaa
bababababbbbbbaaaabbbbaabbaaabaababbbbaaabbabbab
ababbaabababaababbbbbabbbbabbababaaabbbabaaaabbbaaaaaaba
abaabababbbbabbbbabbaaab
bbaaaaaaabbababaabbbababbabbbabbbaabaaaabbabbaba
abbbaabbabbabaabbbbbbbaabaaaaabbbbaaaabbbbbbabba
aabbbbbbaaabbaabaababbbababbabaaaaabbaaa
abaabbaaaabababbabbabbabbbaaaaab
babbbababbbbbbbababaaaaa
baabbbbbaabbbaabbabbababbbbbbbbb
bbaaabbbbbbabaabaaaaabaa
bbababaaabbabbabbabbbaaabbabbbab
bbbbabbababbababaababbaa
bbababaabbabaabaabbaabab
aabbbaabbbbaababbabababa
ababaaababbbbaaaabbbbaaaaaababbb
baaaababbbaabaaabbabbbabaababbabbaaaaaaabbaaaaaa
abbbababbaababbbbbaabbbbababbbaabaaababaabaababbbabbbbab
bbabaaabbaabbaaabbbaaabaaaaabbabbaaaabaaabbbbabbbaabbbbbabbabaababaaaaab
bbbbabbabbbbbbaaaaaabbbbabaabababbabbbbbbabaabbaaabbbbbbbbbbaaaa
baababaaaaabbbaaabaabbba
bbbbababbbabbaabbbabaaababbaaaababababaa
aaaaaaaaaaaaaababaaababbabbbabaa
aaabbabababbbaaabaabbbbbababbbbaaabbbabb
aabaaaabbbbbaaaaababbaabaaabbbbabbaaaaaabbababbbaababaaabaabbaabbabaaaaa
aaaabaaabbaabbaaaabbabba
bbbbaaabbaababaaababbabb
abbbbababbbbabbbbbbbababbaabbbbbaaabaabaabababbabaaabaaa
baabbabaabbbaababbabbaba
bbbbaabbbabbabaaaabaaaaababbaababaaabaabbbaaabaaaaababab
abbbbbbababbabbbbaababababbabbabababbbbb
aaabbbabbbbaaaaaabbbabaababababb
aabbaaabaaabaaabbbaaabaaaabbaaaaaaabababbbaabaab
babaababbaabaaaababaaaaa
aaabbbaaaabaabbbaaabbbbb
abaabaabbaabbabaaaabbbbaaabbbbabaabbbabb
baaababbabaaababaaababbababbbbba
aabbaaaabbabaabbbabaaabaaaaaaaabbbbaaaaa
bbbabbbbaabbbbaabbbaaaabbbbaaabb
abaaabababbabababbaabbbabaaabaaaaaaaaaabaabbbaaaaabbbbbbabbabbaaabaaaaaa
bbbbbbbabbabbaabbabbbaaabaabbaaa
bababbabbaabaabbaaabbbbabaabbbbaaabaaabb
bbbbbababaaaaabbabbbbbbabaaaabab
babbabaabbbbaaabaaabbbbaababaabbaabbaabb
ababaabbbbbaaababaabbaaaabbabbbbaaabbaaa
ababbaabbbbbbaaaaaabbbbb
babbabaababbabbabaabbbab
bbaabbaabbbbaabbabbbbbbaabbbaabaaaababbbbaaabbbbbaabbaaa
aabaabbbbabbbbbbabbabbaaabaabababbbbbabbbbaabaaa
abbbbbbaaabbbbaaabbabbbb
aaaaaaaaababbbabaaabbaabababbbba
baaabbaabaaaabaaabaabaaabbaabbbbaaaaaaababaababb
ababbbaababbbbabbabaaaaabababbba
aaaaabaaaaabbbababaaabbbabbbabba
bbbabbbaaaaaaaaaaaabbbbb
abbbbbbabbabbabbabababaa
baaaaabaaaaabaaabbaabbba
baaaabbbaababbbaaaaaaabb
bbbabaabbabbabbbabaabbbbaabbaababaaabaaababaabbb
bbbabbaabbbaabbbbbbabbbabbababababbabbbb
baabaabbbbbaabbaaaababab
bbabbaabbababbabbbabaabbbabbbbbaaaabbabaabbbbbbbababbaba
babbabbaabbaaabbbbabbbbabaaaaaaabbbaaaaa
abaabbaabbbabbbaabbabaaaaababaaaaaaaabbb
aababbabbbabbaabbabaaabbabbabaabbbbaaababbabbaaabbaaaababbbaaabbbaabaabaabababaa
abbabababbaaabbbbaababbaabaabbbbbbbbbbaa
bbbabbbabbabbbbabaaabaaababaaababbbaababbbbabababbabbbabaaabaaaaaabaabbb
baaaaaababbabaabbbabaabaabbbbbabaaababab
baabaabababbbbbabbbbaabaaaaabbbb
baabbabaababbbabbabbbbab
bbbbaabbbbbaaaabbbbbaaaa
bbbbaababaabaaababbbbbaa
bbbbbabbaaabaababbbaaaababaaabba
ababbbabbbbaaaababaaaabbbbaabbbaaaaaababababbbbababbbbbaababbbabaaaaaaababaabbababbbaaaa
aabaababbbbbababbaabbbab
baaaaababbbababbababaaab
baabaabbaaabbaaaabaabbbabbabbbbababbbbab
abbbbbbababbbabaaabababbbbaabbbabbbbababaabaaabb
bbabbabbabbabababaaaabba
abbabbbabbbbbababaaabaaa
bbbbbaabbabbbbaaabaaaaaabbbabbabaabbbabbabbabaaaabaababbbbbaaabb
baaabbbaaabaabaababaabab
baabaababaaaaabaabaabbaababbbbbabaaabbababbaabab
bbabbbbabaaaabaaaabababbabbabaab
babbaababaaaaaabbbaabaab
abaabbabaaabbbabaaaaabbbbbabababbbbaabbabbbabbbbabaaaaab
ababbbabaababababaabaaaa
abaaabaaababbbabbaababaabaabbaab
aaabbbbabbbaabbabbabaabbbaabbbaa
aaabbbaaaabaabaaabbbbbbb
abbbbabbababaabbbbaababbaabaabbbabbbbabbababbbab
baabaabbbbaaaababbabaabbbbabbaaaabbbaaaaaaababaaaabaabbbbbaaaaabbbbaaaaaaaaabbababbabbba
abbaababbbaaaaabbaabbaaa
babbbbabbbaababaaaaaaaaaabbbbaabbbababbbabbaaaaabababbaabaabbaaaaabaabbbaaaaaaaaababbbbbabbaabaa
abbbabababbabaaaababaaaaababbbbaabaabbbababbaabb
abbaaabaaabbabaaababbaab
bbaabbbabaabbbbbabbabbbaaabbaaaabbaaabbbabbaabbababbbbababbaabab
abaaabbbbbabaababbabaaaa
bbababbbbbbababbaaaaaaabbabaaabb
bbbaabbbaabbbbaaabbabbaabaabaabbbababaaa
babbbaaaaabaabbbabbbbbaa
abaabbaabaabbbbbabbbaabbaaabbaaa
abbbaabaababbbabaaaaaaaabbbabbbabbbaabab
aaaabbaabbabbaabbbaababaabbabbbbabaaabbaabbbbbbbaababbbbbbaabbabaabbbaaabbaabbba
abababbabbabbabbbbabbbab
bbbababbaaaabaaabaabbbba
bbbbaababbbbbbabbbbbabbaababaabaaababaab
bbaaaaaaaabbbaaabaaabaab
babbbbbbbbbbbaaabbaaabbaaabbabbaaaabbaaa
abaabbabaaabaababbbaaabb
abaababaaaaaaabbbababaabaaaababaabbabaabababbbba
aaabbabaabaababaababbbba
bbaaaaaababaaababababaaa
abbabaaabaabaaabbabbaaba
abbabababbabaabbabbabababbbaaaaa
aabaaabaababbbaaababaaab
bbabbbbaabaaabbbabbaaaab
bbbbababbbbaaababbbaaaba
bbbbbbababbbbbbaaaaaabab
bbababbbabaaabaabaabbaaaabbbabbabbbbbbaaabbabbbb
baababbbaaabbbaaaabaabbbaabaaabb
abaabbabbaaaabababbaabbb
bbbabaababbbbbbabaabaaabbabbbbbbbbbaabaabbabbbaaabbababb
babbabbbbbbbbabbbaaaababbbbbbbbababababa
baabababaabbaabbaabbabba
baabaababaaaaabbbabaabbbababbbaaabbaaaba
bbbbabbbbaabbbababbbaabaabaabaaaaaaaabaaabbaaaaa
bbabababbaabbabaabbabbaabaababaabaaaabba
abbbbbbaaaaabbaabbbbbaabaabbabbbaabababaaaababbbbabbbbbabaaabbab
bbbbaaabaaaabaaaaabbbaab
aabbaabbaaaaaaaaabbbbababaabababbabbabbbbbbbababaaabaabb
bbabababbabbabbbbaaaabaaaabbaababbbaaaaaabbbaaaa
bbabbabbaaabababbabbbbababaabbabbbbabbbababbaaab
abaaaaaabbbaabaaaabbbbabbababaab
aabababbbabbabbabbaabaaa
ababbbaaaaabbabaaaabbabbaaaaaabb
baaaababbbaaaababbbbbabbbbbaaabaabbabaaabbbbbabaaaaaaaababbbababaabbbbbbaabbbbaa
baabbbbbbbbbaabaabbababb
bababbababaabbbbababaaab
baababbbbabbaabbabbabbaabababbabaaaabbbaabaabaaa
aabaabababaaaabaabababbbbaaabaaaabaaabab
abbaaaaababbabbabaaaabbbbaaaabba
babbbaaabaaaaabbbabbbbab
ababbbabbaabbabaabbbabba
abaabbabaaaabaabbaaabbbbbbbabbaaaaabaabb
bbbaabbaaabbbaabbaabaabaababbaab
ababbbaabbbbbbbabaababaaabbabbabaababaaabbbaaababaabbaab
bbbbbbbabbaaaaaaaaabbbababbbbbbb
aabaaababbabbabaaaaabaaabbabbaabaabbbbbbababaaaa
baabaaabaaabbbabbababbabababbaba
abbbabbbababbabbbbbbaaaababbabbbaaaaaaaaabbaabbabbaaaaabbbabaaaabababbbaaabbabbb
baabaaabbabbababbbbaabbaaaabbaabbbbbabbbabbbaaabbbbabaaa
abaaabbbabaabaaaabbbbbabaaabbbbabababbbbbabbbbabaabaaaaa
aaaaaaaaabaaaababbbaaabababababa
bbbbaabbbababaaaaaaaaaab
aaabaaaabaaaababbabbbbbbaaaabbababbbabaa
babaaababbbbbbbaabbbbabb
baaabbaaaabbbbaabbbababa
baababbbaababbbabbbaabbbbbbbabaaaabbaaab
baaaabaabaabaabbbababbababbbaabbaaabbaabbaaaabba
baabaababbbaabbbabbabababaaaaaaa
bbbababbaabbababaaaaabbb
bbbabaaaaaaaaaaabbbaabbbbabaabbaabaaabbbabbaabbbbabbbbab
aaaaaaabbaababaaaaabaaaababbbaab
abababbaababbbabaabbbbaaaaaabaaaabbaaaba
baababbaaabaabbbbbbaabbabbbbaabbaabbabaabbabbbabaabbabba
abaaabbbbabbbaaabbbbaabaabaabababbaaabbbaabbbbabbababbbabaabbaaabaaabaaa
aabaaabaababbaabbbbbbbabbaaaaabbaaaabbba
aabbabaaabbbbabababbbbbbbaaabbbabaabbaaababbbbabbbbabaaa
abaabbbbbbbbabbbabbaaaaabbaaaaaaabbabbbbabababaa
ababaabbbbbbabaaabbaabba
bbbbababaababaaaaaaabbaabaabaaaa
abbbababbbbbaaababaaaabb
aabbbbbbaababbbaababbbabbaabbabaabaababaaaabaaab
aabaababaaabbbaabbaababababbbaaaabababaa
abaabaabbabbbababbaaaabaabaaabaabaabaabbabbababbaaabaaababaaabba
baaaaabbbbbaaaabbbbbbabb
abbbababbbbbbbbaabbaaaaababbbabbabababbaabaababb
aabbaababbabbaabbbbbaabaaaabbabbababbaba
ababbbaababbbbbabbbabaaa
abaaabbbabababbaabaaabbb
abababbabbabbababbbaabbaababbbaaaabbaaab
abbbbabbbaabaabbbaaaabbbbaaabbbbbbbabbbaababbababbbabbab
bbbbbaabbbaababbabbbaaaababbbabaaaababaaabaabbaa
ababbbaababababaaabaabbbabaaabbbbaabababbabbbbbaababbaaa
baababaabbbabbbbaaabaabb
babaabbbbbaabbbbbbabbabaabbbaaaaabbaabbabbbbaabaabbabbbbbbabbbaa
baabbabaaabbbababbaaaaba
abbbbbabbaaabbbabbaabbaaaabbbbaaaabbabbabaabbbba
aaaaaaabbaaabbbaaaaabbab
baabbbbbbaaabbbbaabbabaaaababbabbbaababaaabbbbbaabaaaaaabaabaabababbbaaa
aabbaaaaabbabaaaabbbbbaa
bbbabaabbbaaaaaaaabbbabaababaaab
babbabaaaaabbbababaaaaaa
baabbabaabaaabbbaabaaaaa
aabbaababbababbbbababaabaabbbbba
abbbbabaaabaaababbbbbaaaaaabaaab
bbbabaabbbbbabbaaababaaa
bbbbbabaabbaaabaaaabbbaaabbbbbbabaabbbaaabbbbbbbbaabbaaa
bbbbaaaabaabaabbbbabbabbbbbbbabaaaaabaaabbabbbbbbaabbbabaaabaabb
bbbbbaaabbbbabaabbabbbbbbaabaaabbabbbbbaabbbabbaabbbbbaa
aaabbbabbabbabbbbabaaaaaabbbbbaaaaababaaaaaaabbaabbabababababaaabbbababaabbaaaabbaaabaaababbaabb
abbaaaaaabbababaaababababaaaaabbaaabbaaa
aaaabaaaaabbabaaaaaabbaa
bbbbbbbabaababbbbbbbaaaabbbbbaab
ababaaaababbabbabbbababaabbaaabbabbbbbbbaabbababbbabbaba
bbbbbbbaaaaaababbaabbaaaaaababbbabaaabab
baabbbaaaaabbbbabbababbaaaaababaabbababaaaabbbbbbbbaaaababbbbbaababaaabb
bbbabbbaaabbbaabaaababbaaaabbaaa
baabaababbbbbaaabbbbabaaaabbabbaaaabaabb
abbbaabbabbabbabbbbaabbbbbabbbab
babbabaaabbabbbabaababaabbabaaba
baababbbbaaaabaaabbbaabbbbbaaaaa
bbaababbaaabbbbabbbabaaa
babababaaabbababbbbbabbbbbbababbabbbabbaaabbabbbabbaaaabbabbbabbaabbaaba
bbbbaaaabaaaaaaabbaaabaabaaaababaabaababbbbabababbabbbbaabbaaaabbbbaaababbbabbababaababb
babaaabbaabaaabbbabbbaabaaaabbbaaaaaabababababbabbababba
aaaabaaabbabaaabaabbbaaabbbbabaa
abbababaabaabbaabbbababbbbabbbbbaabbaaaaaaaabbabaaababbbbbabbbaa
aababbbababbabaabbbbabbaaabaaababbbbabababaaabaaaababaaaaabbaaab
ababbbaaaababbbaabbbbabaabaaabaabbbaabbaabbbbbaabbbaaaaabaabbabb
bbbabbaabaabababaabbababaababaaa
aaaaaaabbbbbbbabbabaabaa
abaabaaaaabbaaaabbbbaabaaabaabaabbbaabaa
aabbabaabaaabbaaaaaabbbb
abbabbaabaabababaabbbaabbbbbaababbbbabbbabbbaaab
abbaaabbabaaaabaaaaaabaaaababbbbbaabaaabaaabaabbbbabbabbbbbaaabababbabbabbbbbaaa
abaaabbbbabaaaaaabbaaababaaaaabaababbaababaabaaaabaaaaabbbaaaaab
aababababbbbbbbaabaabbabbbbbbaaaabbbaaaa
aabbaabaaabbaaaaaabaababaabbbbab
aabaaababbaaaaaabbababababaaaaabbababaab
baababaababbabbbabbaabaababbaabbaabaabbabbbbbaab
abaaabaaaaabbbaaabbababababbbabaaababaaa
aabaaababbbbbabbbaabbabb
aaabbabbaaabbbaabbbbbbababbababb
aabaaaabaabbbbaaaaaabaaabbaabbbaabbbbbbb
bbbbabaaaabbababbbabaaabbabaabba
baabaabaaabababababbabbbbbababaaaaababab
aabbbaaaaabbbbaaababbaaaababbbbaababaaaabbbabaab
abbaaabbbaabbbbabababbbabaabbbbaaabbabaabbaaaaba
aaaaaaabbbabaabbaabbbabaabbababaabbbbbbaabbbbaaaabababaaaaaabbbbaabbabba
abbbbabaabaabaabbbabbbbaabbbbabaabababbbbbaabbabbaabaaaa
abaabababbbbbabbbabaaaab
bababbabbbbabaaabbaaaabb
abbabaaabbbababbbbbaabbaaabbbbaababbaaba
bbbbaabaaabbbbbbabaabaaaaabaababbabbabbbabaaabab
babbabbbbbbabbaabbbabaabbbbbbbbb
babaabaaababbbbaabaabbbaababaaabbbabbbaaaaaaaaaabaababbbbaabbaaa
bbbbaabaabbabbaaabaabaaababababa
abbaababbbbabbabaabbbbbaababaaabaaabbbaaabaababbbbbaabaa
aabbaaaabbbbababaaaabbab
aabaababbabbbabaaabababaabaaabbaabaaaabb
bbabbabbbbaabbbbabaabaaaaaaaaaababaaabba
aaababbaabababaabababaaababaabaaabaaaabb
baaabbbabbaaaaabbaabbbab
bababaabbabbbababaaaababbabbaabbbbbaababbabbabbb
bbababaaabbbaabbaaabbbabaaabbbaabbbaaaaa
aabbbbaaabbbbbabaabaaababbaabbaaaabbbbbaabaaababbbbaabab
aaaaaaabaaaababbabababbaaababaabaabaaaaaabbaaaaaabaabbbaaaaabaaa
abaabbbbbbbabbaaaababbab
bbaaaaaaababaabbbaabaaabaababaaa
aabbbababaabababbabbbaab
abaabbbbbbaaaaaabbbbbbbabbbbabbbbabbaabb
aabbbbaabbababaabababbba
bababbabaaaabaaabaababaaaaaaaabb
bbbbaababbbabbaabbaabbaaabbbaabbbbabbaabaaaaaabb
bbbbabbabbbbaabaaaabaaaabaaaaabbaaabbbbaabaabbbaaabaaaaaabbaabbb
abbabaaabbaababbaabaaabbbbabbaabbbaabbbb
bbaaabbabbbbbababababaababaaaaaababaaaaaaabbbbab
aababbbaabbbbabaabbabaab
bbbaabbbaaaaabaabbaaaaab
bbabbabbbbaaabbbbbaaaaaababaabbaababbabbabaabbbabbaaaabb
aaabbabaaabaabbbbbaababbbaaaaaababbabaab
abbabbabbbaabbaabbaaabaa
abaabbabaaaabaaaaaaaabab
abbbbaabaabbabbbaabaaabbbaaaaaaa
abbabbaaaababbbabbabbababbaababaabbabaabbbbaaabb
aabaaaaabbbababbbaaababbabbbbababababaaabbabbbba
aaabbabababbbababbbaabbbbaabbbbaaababaaa
aabababbaaabaaaabbababaaaaaababb
abbaaaaaabababbaabaabaababbaaababaababbbaaaababbbabbaaabaabbabbaabbaabba
bbaaaabaaaabbaabbbaaaabaababbbbb
ababbbabbaababbbabaabaababbbababbbaabbaaabaababbabaaaaab
aabaaabaababaabaababaaaa
baabbbbbbaaaaabbbaabbbaa
abbabbabbabbabbbabbbbabaabbbabbb
ababbaabaabbababbbbababbbbbbabaabbabbbabbabbbbaa
bbbabaabbababbabbbabbbaa
aabaabbbaaabbababaabaaababababbbaabababbabaabbbabaaabaabbababbba
abaabaabababaababaabbabb
bbaabbbaaaabbbabaaababaa
bbbbabbbaabbaaaaabaaabba
baaaabbbbbbbaaabbaaaaabbabaabbabaabaabbbbaabbbabaababbaa
bbabaabbbaababbabbaabbaaaaabbbababaabbbaaaaabbab
babaaababbbabbbbabaabaaababaabbb
baaabbaabaaaabaaaaabaabaaaaabaaaaaabababababaaab
bbbbbabbbbaaaaaabaababbababbaaaaabbaabbb
abaaabbbabbbaabbbaaabaab
bbbabbaaaaabaabaaabababaaaabbbabbbbbabbbaababaab
bbbbabbbbaabbabbaabbbbbbabaaababbbbaaabaaaaabaabaabbaaab
baaaabbaaaaababbbbaaaaabbbbbbbaababbbabb
bbaabbbaababbaabbabbabababbbaababaabaaaa
bbbabbbbbaaaabbbabbbbbbaabaabbabbababaab
baababbbaabaabaabbaababaabaaabbbbbbababbbaaaabba
babbabababbbbbabababbbba
aabbbaaabbaaabbaabaaabab
bbbbbbbaabaaabaabbbbbabaabaababbabbabaab
bbaabbbbaaabbaababaaabbabababbbaaaabababbababaaaaabaaaab
babbbabaaabbabaaaabbbaabbabaabab
bbaaaabaaaaaaabbababbaaaababbbbbabaabaaababbabbbabbaaaaaaaaaababaaabbabbbbbbabaa
ababaabbaabbaaaabaaaaabbababbbba
baaaababbbbbaabbbaaabaaa
aababababbbaabbabbaabbbb
baababbaaaabbabbababbaba
babbabaabbbbbbbaaabbbabb
bbbbbbabbbbbbbabbbbbbabbabaaaabb
bbbaabbbbbbbbababababbbb
aabbaaaabbabbabbbbbaabaa
bbababababbbbaabaaabaababbbbaaabaaaabbab
ababbaabaabbbaababbbaababbabbabbaaabbababaabbaabababaaaaaabaaaaa
aabaababbabbbaaaabababbaaaaabbab
abbaaabbaabbaababbbabbbaababaaaa
aabaabaabbbbbabbaabbaabaaabaabaabaabaabbaaaabaaababbaabb
aabaaaabbbbbaaaabaaabbbbbbbbaaabababaaabababbaabbbaabaabaababbaabaaaabab
bbbabbabaaabaaaabababbaabaaabbbabbaabbba
bbaaaabababbbbaabaaabbaababbabbaaabbbababaaaabaaabbbbbbb
bbaabbaaaaaaabaaaaabbbbabbbbbabbbaabaabaaabbbabb
bbaabbbaabbaaaaaaaabaabababababbaabaaaaa
babbababbaabaababaababbabbbbbbabbbbbaabbbaabbbbbbabaabab
ababaabbaabbbaabaaaabbba
aaaabaaaabbabbbabbbbababbbaabbab
aaabaaaaaaabbabaaaaaabbb
bbbbabbaababbaabbbabbabbabaaaabbabaaabba
ababbaabbbabbbbbaaaabbba
abbbbabaaabbbaabbbbaaaabababaaaa
aaabaabaaabbbbbbaaabaababbabbabbbbbabbab
aaabaababaaaaaabbababbabbabaabbaabababbabaabaabaaaababbabbaabbaa
baaabbbabbabbaababbbaaab
aabbabababaabbabaaaaaaba
aabbbabaabbaaaaaaababbaa
bbbbbbabbaaaabaaabbabbabbaaaababbbababaa
aababababaaaaabbaaaaabaabbabbabbabbbabba
bbbbaaababbbbabaabbbaaaa
babababbbabababaabaabbabbbbbbbbbaaaabbaaaababababbabaaab
abaaabbbaabbbaabbbbaaaba
aabbaabbbabaaabaabbabaaabbbbbaba
bbbbaaabaaabaabaababbaabbbababbbabaaabbbabbaabaababaabababbbbabbbababbba
abaaabbbaabbaabbabbabbbabbbaaaaabaaabaabbbbbaabbaaabbbbaabababab
bbabbbbaaabbbabaababbbaaababaabb
aabababbbaabbabaaaaaabab
abaababaabbababaaabbaabbbbbaabbaaaaababa
aaabbbabaababbbabbbaaaabbabbbbaabaaabaaa";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(301, messages.ThatMatchRule(0, rules));
        }
    }
}