namespace Day14.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";

    public const string PUZZLE_INPUT = @"481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
465,117 -> 465,120 -> 464,120 -> 464,123 -> 476,123 -> 476,120 -> 471,120 -> 471,117
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
501,15 -> 506,15
481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
474,73 -> 474,74 -> 486,74 -> 486,73
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
491,29 -> 495,29
491,17 -> 496,17
474,36 -> 474,38 -> 468,38 -> 468,41 -> 482,41 -> 482,38 -> 478,38 -> 478,36
454,107 -> 454,110 -> 450,110 -> 450,114 -> 467,114 -> 467,110 -> 459,110 -> 459,107
462,84 -> 462,87 -> 455,87 -> 455,91 -> 469,91 -> 469,87 -> 466,87 -> 466,84
462,84 -> 462,87 -> 455,87 -> 455,91 -> 469,91 -> 469,87 -> 466,87 -> 466,84
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
477,33 -> 482,33 -> 482,32
485,29 -> 489,29
481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
465,117 -> 465,120 -> 464,120 -> 464,123 -> 476,123 -> 476,120 -> 471,120 -> 471,117
462,84 -> 462,87 -> 455,87 -> 455,91 -> 469,91 -> 469,87 -> 466,87 -> 466,84
481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
474,36 -> 474,38 -> 468,38 -> 468,41 -> 482,41 -> 482,38 -> 478,38 -> 478,36
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
477,59 -> 477,60 -> 495,60
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
465,117 -> 465,120 -> 464,120 -> 464,123 -> 476,123 -> 476,120 -> 471,120 -> 471,117
465,117 -> 465,120 -> 464,120 -> 464,123 -> 476,123 -> 476,120 -> 471,120 -> 471,117
465,117 -> 465,120 -> 464,120 -> 464,123 -> 476,123 -> 476,120 -> 471,120 -> 471,117
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
477,140 -> 488,140
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
485,23 -> 489,23
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
497,65 -> 502,65
488,26 -> 492,26
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
479,29 -> 483,29
474,36 -> 474,38 -> 468,38 -> 468,41 -> 482,41 -> 482,38 -> 478,38 -> 478,36
454,107 -> 454,110 -> 450,110 -> 450,114 -> 467,114 -> 467,110 -> 459,110 -> 459,107
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
454,107 -> 454,110 -> 450,110 -> 450,114 -> 467,114 -> 467,110 -> 459,110 -> 459,107
474,36 -> 474,38 -> 468,38 -> 468,41 -> 482,41 -> 482,38 -> 478,38 -> 478,36
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
498,17 -> 503,17
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
474,36 -> 474,38 -> 468,38 -> 468,41 -> 482,41 -> 482,38 -> 478,38 -> 478,36
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
488,20 -> 492,20
494,67 -> 499,67
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
462,84 -> 462,87 -> 455,87 -> 455,91 -> 469,91 -> 469,87 -> 466,87 -> 466,84
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
454,107 -> 454,110 -> 450,110 -> 450,114 -> 467,114 -> 467,110 -> 459,110 -> 459,107
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
505,17 -> 510,17
487,67 -> 492,67
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
474,36 -> 474,38 -> 468,38 -> 468,41 -> 482,41 -> 482,38 -> 478,38 -> 478,36
490,65 -> 495,65
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
478,81 -> 483,81
501,67 -> 506,67
484,69 -> 489,69
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
454,107 -> 454,110 -> 450,110 -> 450,114 -> 467,114 -> 467,110 -> 459,110 -> 459,107
462,84 -> 462,87 -> 455,87 -> 455,91 -> 469,91 -> 469,87 -> 466,87 -> 466,84
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
497,29 -> 501,29
493,63 -> 498,63
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
494,26 -> 498,26
481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
477,59 -> 477,60 -> 495,60
470,77 -> 475,77
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
497,13 -> 502,13
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
505,69 -> 510,69
474,73 -> 474,74 -> 486,74 -> 486,73
474,73 -> 474,74 -> 486,74 -> 486,73
467,79 -> 472,79
482,26 -> 486,26
465,117 -> 465,120 -> 464,120 -> 464,123 -> 476,123 -> 476,120 -> 471,120 -> 471,117
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
465,117 -> 465,120 -> 464,120 -> 464,123 -> 476,123 -> 476,120 -> 471,120 -> 471,117
454,107 -> 454,110 -> 450,110 -> 450,114 -> 467,114 -> 467,110 -> 459,110 -> 459,107
491,69 -> 496,69
474,36 -> 474,38 -> 468,38 -> 468,41 -> 482,41 -> 482,38 -> 478,38 -> 478,36
498,69 -> 503,69
464,81 -> 469,81
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
462,84 -> 462,87 -> 455,87 -> 455,91 -> 469,91 -> 469,87 -> 466,87 -> 466,84
491,23 -> 495,23
471,81 -> 476,81
477,33 -> 482,33 -> 482,32
451,104 -> 451,103 -> 451,104 -> 453,104 -> 453,97 -> 453,104 -> 455,104 -> 455,100 -> 455,104
485,153 -> 485,145 -> 485,153 -> 487,153 -> 487,152 -> 487,153 -> 489,153 -> 489,143 -> 489,153 -> 491,153 -> 491,148 -> 491,153
462,84 -> 462,87 -> 455,87 -> 455,91 -> 469,91 -> 469,87 -> 466,87 -> 466,84
481,54 -> 481,47 -> 481,54 -> 483,54 -> 483,45 -> 483,54 -> 485,54 -> 485,52 -> 485,54
471,136 -> 471,130 -> 471,136 -> 473,136 -> 473,128 -> 473,136 -> 475,136 -> 475,132 -> 475,136 -> 477,136 -> 477,133 -> 477,136 -> 479,136 -> 479,133 -> 479,136 -> 481,136 -> 481,132 -> 481,136
454,107 -> 454,110 -> 450,110 -> 450,114 -> 467,114 -> 467,110 -> 459,110 -> 459,107
494,15 -> 499,15
474,79 -> 479,79";
}