using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class LaminateNeuralNet : NeuralNet
    {
        public List<Neiron[]> net = new List<Neiron[]>();
        public void AddLayer(int length,Random rnd,double minWeight,double maxWeight,double minBias,double maxBias)
        {
            net.Add(new Neiron[length]);
            for (int i = 0;i < length; i++)
            {
                Neiron neiron;
                if (net.Count == 1)
                {
                    neiron = new Neiron(new LinearActivationFunction(1,0));
                }
                else
                {
                    double[] d = new double[net[net.Count - 2].Length];
                    d = d.Select(_ => Neiron.GenerateRandom(rnd, minWeight, maxWeight)).ToArray();
                    Neiron[] n = net[net.Count - 2];
                    neiron = new BasicNeiron(new SigmoidActivationFunction(4),ref n, d ,Neiron.GenerateRandom(rnd, minBias, maxBias));
                }
                net.Last()[i] = neiron;
                neirons.Add(neiron);
            }
        }
        public void FinaliseStructure()
        {
            inputNeirons = net.First();
            outputNeirons = net.Last();
        }
    }
}