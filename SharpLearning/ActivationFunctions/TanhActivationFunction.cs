using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class TanhActivationFunction : ActivationFunction
    {
        double k;
        public TanhActivationFunction(double k)
        {
            this.k = k;
        }
        public override double Activate(double input)
        {
            return Math.Tanh(k * input);
        }
        public override double Deactivate(double input)
        {
            return k / (Math.Cosh(k * input) * Math.Cosh(k * input));
        }
    }
}
