using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuxiliaryLibrary
{
    public class RangeEventArgs : EventArgs
    {
        private double xMin;
        private double xMax;
        private double yMin;
        private double yMax;

        public RangeEventArgs(double xMin, double xMax, double yMin, double yMax)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
        }

        public double XMin
        {
            get { return xMin; }
        }

        public double XMax
        {
            get { return xMax; }
        }

        public double YMin
        {
            get { return yMin; }
        }

        public double YMax
        {
            get { return yMax; }
        }
    }
}
