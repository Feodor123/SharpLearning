using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class Neiron
    {
        public Neiron(ActivationFunction activationFunc,ref Neiron[] inputNeirons,double[] weights)
        {
            if (inputNeirons.Length != weights.Length)
            {
                throw new Exception();
            }
            activationFunktion = activationFunc;
            for (int i = 0;i < inputNeirons.Length; i++)
            {
                Link link = new Link(inputNeirons[i],this, weights[i]);
                inputLinks.Add(link);
                inputNeirons[i].outputLinks.Add(link);
            }
        }
        public Neiron(ActivationFunction activationFunc)
        {
            activationFunktion = activationFunc;
        }
        protected double sum = 0;
        protected bool valueUpdated = false;
        protected bool errorUpdated = false;
        protected double value = 0;
        public double Value
        {
            get
            {
                if (!valueUpdated)
                {
                    Activate();
                }
                return value;
            }
        }
        protected double error = 0;
        public double GetError()
        {
                if (!errorUpdated)
                {
                    UpdateErrors();
                }
                return error;
        }
        public ActivationFunction activationFunktion;
        public List<Link> inputLinks = new List<Link>();
        public List<Link> outputLinks = new List<Link>();
        public virtual void UpdateWeights(double trainingSpeed)//вносим поправки веса через жопу нейрона
        {
            foreach (var link in inputLinks)
            {
                link.weightChange = trainingSpeed * error * link.fromNeiron.value;
                link.weight += link.weightChange;
            }
        }
        public virtual void UpdateWeights(double trainingSpeed,double inertionSpeed)//вносим поправки веса через жопу нейрона, используем "инерцию"
        {
            foreach (var link in inputLinks)
            {
                link.weightChange = trainingSpeed * error * link.fromNeiron.value + inertionSpeed * link.weightChange;
                link.weight += link.weightChange;
            }
        }
        public virtual void ResetError()//обнуляем ошибку
        {
            error = 0;
            errorUpdated = false;
        }
        public virtual void ResetValue()
        {
            value = 0;
            valueUpdated = false;
        }
        public virtual void ResetSum()
        {
            sum = 0;
        }
        public virtual void UpdateErrors()//вычисляем ошибку через ошибки передних нейронов
        {
            if (!errorUpdated)
            {
                foreach (var link in outputLinks)
                {
                    error += link.toNeiron.GetError() * link.weight;
                }
                error *= activationFunktion.Deactivate(sum);//сложно, непонятно, но нужно
                errorUpdated = true;
            }
        }
        public virtual void Activate()//посылаем значение через перед нейрона
        {
            if (!valueUpdated)
            {
                sum += inputLinks.Select(_ => _.fromNeiron.value * _.weight).Sum();
                value = activationFunktion.Activate(sum);
                valueUpdated = true;
            }
        }
        public void AddConnections(Link[] inputLinks, Link[] outputLinks)
        {
            this.inputLinks.AddRange(inputLinks);
            this.outputLinks.AddRange(outputLinks);
        }
        public void SetValue(double d)//для входных нейронов
        {
            sum += d;
        }
        public void SetError(double d)//для выходных нейронов
        {
            error += d;
            errorUpdated = true;
        }
        public static double GenerateRandom(Random rnd,double min,double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
    }
}
