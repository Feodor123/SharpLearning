using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class ReluActivationFunction : ActivationFunction
    {
        double a;
        double b;
        public ReluActivationFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double Activate(double input)
        {
            return Math.Min(1,a * input + b);
        }
        public override double Deactivate(double input)
        {
            if (a * input + b < 1)
            {
                return a;
            }
            else
            {
                return 0;
            }
        }
    }
}
