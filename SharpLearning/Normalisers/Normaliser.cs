using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public abstract class Normaliser
    {
        protected double min;
        protected double max;
        public Normaliser(double min,double max)
        {
            this.min = min;
            this.max = max;
        }
        public abstract double Normalise(double d);
        public abstract double[] Normalise(double[] d);
        public abstract double Denormalise(double d);
        public abstract double[] Denormalise(double[] d);
    }
}
