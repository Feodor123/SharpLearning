using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpLearning;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            LaminateNeuralNet net = new LaminateNeuralNet();
            net.AddLayer(2, rnd, -2, 2,  0, 0);
            net.AddLayer(3, rnd, -2, 2, -2, 2);
            net.AddLayer(1, rnd, -2, 2, -2, 2);
            net.FinaliseStructure();
            TrainingSet[] trainingSets = new TrainingSet[]
            {
                new TrainingSet(new double[]{0,0},new double[]{0}),
                new TrainingSet(new double[]{1,0},new double[]{1}),
                new TrainingSet(new double[]{0,1},new double[]{1}),
                new TrainingSet(new double[]{1,1},new double[]{0})
            };
            for (double i = 10;true;i *= 0.99)
            {
                int nn = rnd.Next(4);
                Console.WriteLine(net.Train(trainingSets[nn],i) + " :" + nn);
                foreach (var n in net.neirons)
                {
                    foreach (var inp in n.inputLinks)
                    {
                        Console.Write(inp.weight + " ");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
}
