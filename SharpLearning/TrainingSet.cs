using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class TrainingSet
    {
        public double[] input;
        public double[] output;
        public double squareError;
        public double GetSquareError(double[] myOutput)
        {           
            if (output.Length != myOutput.Length)
            {
                throw new Exception();
            }
            squareError = 0;
            for(int i = 0;i < output.Length; i++)
            {
                squareError += (myOutput[i] - output[i]) * (myOutput[i] - output[i]);
            }
            squareError /= output.Length;
            return squareError;
        }
        public double GetSquareError(Neiron[] outputNeirons)
        {
            if (output.Length != outputNeirons.Length)
            {
                throw new Exception();
            }
            squareError = 0;
            for (int i = 0; i < output.Length; i++)
            {
                squareError += (outputNeirons[i].Value - output[i]) * (outputNeirons[i].Value - output[i]);
            }
            squareError /= output.Length;
            return squareError;
        }
        public TrainingSet(double[] input, double[] output)
        {
            this.input = input;
            this.output = output;
        }
    }
}
