using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class BasicNeiron : Neiron
    {
        public double bias;
        public BasicNeiron(ActivationFunction activationFunc,ref Neiron[] inputNeirons, double[] weights,double bias) : base(activationFunc,ref inputNeirons, weights)
        {
            this.bias = bias;
        }
        public BasicNeiron(ActivationFunction activationFunc, double bias) : base(activationFunc)
        {
            this.bias = bias;
        }
        public override void Activate()
        {
            sum = inputLinks.Select(_ => _.fromNeiron.Value * _.weight).Sum() + bias;
            value = activationFunktion.Activate(sum);
            valueUpdated = true;
        }
        public override void UpdateWeights(double trainingSpeed)
        {
            base.UpdateWeights(trainingSpeed);
            bias += trainingSpeed * error;//bias без инерции, не знаю,может зря
        }
        public override void UpdateWeights(double trainingSpeed,double inertionSpeed)
        {
            base.UpdateWeights(trainingSpeed,inertionSpeed);
            bias += trainingSpeed * error;//bias без инерции, не знаю, может зря
        }
    }
}
