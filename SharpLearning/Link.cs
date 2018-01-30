using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLearning
{
    public class Link//не несёт никакой полезной функциональной нагрузки, просто хранилище!
    {
        public double weight;
        public double weightChange = 0;//"реактивный ранец" для преодоления локальных минимумов (https://m.habrahabr.ru/post/313216/)
        public Neiron fromNeiron;
        public Neiron toNeiron;
        public Link(Neiron fromNeiron,Neiron toNeiron, double weight)
        {
            this.fromNeiron = fromNeiron;
            this.toNeiron = toNeiron;
            this.weight = weight;
        }
    }
}
