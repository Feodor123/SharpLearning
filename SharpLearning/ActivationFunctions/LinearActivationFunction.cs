using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class LinearActivationFunction : ActivationFunction
    {
        double a;
        double b;
        public LinearActivationFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double Activate(double input)
        {
            return  a * input + b;
        }
        public override double Deactivate(double input)
        {
            return a;
        }
    }
}
