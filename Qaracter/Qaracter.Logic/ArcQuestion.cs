﻿using System;
using System.Collections.Generic;

namespace Qarater.Logic
{
    public class ArcQuestion
    {
        public int R { get; }
        public int RAC { get; }
        public double ST { get; private set; }
        public double AC { get; private set; }
        private int RB { get; set; }

        public class Builder
        {
            private int _ratio;
            private int _rectangleBasePlusHeight;

            public Builder WithRatioOf(int value)
            {
                _ratio = value;
                return this;
            }

            public Builder WithRectanglePerimeterOf(int value)
            {
                _rectangleBasePlusHeight = value;
                return this;
            }

            public ArcQuestion Build() => new(_ratio, _rectangleBasePlusHeight);
        }

        private ArcQuestion(int r, int rac)
        {
            R = r;
            RAC = rac;

            CalculateQuarterOfCircle();
            CalculateRectangleBisector();
        }

        private void CalculateQuarterOfCircle() => ST = 0.5 * Math.PI * R;

        private void CalculateRectangleBisector() => AC = RB = R;
    }
}