using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class NeuralNet
    {
        public Neiron[] inputNeirons;//обычно тип BasicNeiron
        public List<Neiron> neirons = new List<Neiron>();
        public Neiron[] outputNeirons;
        public void ResetValues()
        {
            for (int i = 0;i < neirons.Count;i++)
            {
                neirons[i].ResetValue();
            }
        }
        public void ResetSums()
        {
            for (int i = 0; i < neirons.Count; i++)
            {
                neirons[i].ResetSum();
            }
        }
        public void ResetErrors()
        {
            for (int i = 0; i < neirons.Count; i++)
            {
                neirons[i].ResetError();
            }
        }
        public virtual void Calculate(TrainingSet trainingSet)
        {
            if (trainingSet.input.Length != inputNeirons.Length)
            {
                throw new Exception();
            }
            ResetValues();
            ResetSums();
            ResetErrors();
            for (int i = 0;i < inputNeirons.Length; i++)
            {
                inputNeirons[i].SetValue(trainingSet.input[i]);
            }
            foreach (var neiron in outputNeirons)
            {
                neiron.Activate();
            }
        }
        public virtual void UpdateErrors(TrainingSet trainingSet)
        {
            if (trainingSet.output.Length != outputNeirons.Length)
            {
                throw new Exception();
            }
            for (int i = 0; i < outputNeirons.Length; i++)
            {
                outputNeirons[i].SetError(trainingSet.output[i] - outputNeirons[i].Value);
            }
            foreach (var neiron in inputNeirons)
            {
                neiron.UpdateErrors();
            }
        }
        public virtual void UpdateWeights(double trainingSpeed)
        {
            foreach (var neiron in neirons)
            {
                neiron.UpdateWeights(trainingSpeed);
            }
        }
        public virtual void UpdateWeights(double trainingSpeed,double inertionSpeed)
        {
            foreach (var neiron in neirons)
            {
                neiron.UpdateWeights(trainingSpeed, inertionSpeed);
            }
        }
        public virtual double Train(TrainingSet trainingSet, double trainingSpeed)//возращает ошибку
        {
            Calculate(trainingSet);
            UpdateErrors(trainingSet);
            UpdateWeights(trainingSpeed);
            return trainingSet.GetSquareError(outputNeirons);
        }
        public virtual double Train(TrainingSet trainingSet, double trainingSpeed, double inertionSpeed)//возращает ошибку
        {
            Calculate(trainingSet);
            UpdateErrors(trainingSet);
            UpdateWeights(trainingSpeed, inertionSpeed);
            return trainingSet.GetSquareError(outputNeirons);
        }
        public void AddNeiron(Neiron neiron)
        {
            neirons.Add(neiron);
        }
    }
}
