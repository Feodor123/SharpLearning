using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public abstract class ActivationFunction
    {
        public abstract double Activate(double input);
        public abstract double Deactivate(double input);
    }
}
