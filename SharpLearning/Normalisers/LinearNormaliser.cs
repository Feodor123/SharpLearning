using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class LinearNormaliser : Normaliser
    {
        public double rangeDown;
        public double rangeUp;
        public LinearNormaliser(double min, double max,double rangeDown,double rangeUp) : base(min,max)
        {
            this.rangeDown = rangeDown;
            this.rangeUp = rangeUp;
        }
        public override double Normalise(double d)
        {
            if (d > max || d < min)
            {
                throw new Exception();//нефиг делать значения вне границ!
            }
            return rangeDown + (d - min) * (rangeUp - rangeDown) / (max - min);
        }
        public override double[] Normalise(double[] d)
        {
            for (int i = 0;i < d.Length; i++)
            {
                d[i] = Normalise(d[i]);
            }
            return d;
        }
        public override double Denormalise(double d)
        {
            if (d > rangeUp || d < rangeDown)
            {
                throw new Exception();//нефиг делать значения вне границ!
            }
            return min + (d - rangeDown) * (max - min) / (rangeUp - rangeDown);
        }
        public override double[] Denormalise(double[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = Denormalise(d[i]);
            }
            return d;
        }
    }
}
