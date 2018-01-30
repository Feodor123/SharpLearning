using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class SigmoidActivationFunction : ActivationFunction
    {
        double k;
        public SigmoidActivationFunction(double k)
        {
            this.k = k;
        }
        public override double Activate(double input)
        {
            return 1 / (1 + Math.Exp(-input * k));
        }
        public override double Deactivate(double input)
        {
            return (k * Math.Exp(-input * k)) / ((1 + Math.Exp(-input * k)) * (1 + Math.Exp(-input * k)));
        }
    }
}
