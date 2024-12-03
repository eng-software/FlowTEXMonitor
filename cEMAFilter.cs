using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowTEXMonitor
{
    public class cEMAFilter
    {
        SemaphoreSlim smphr = new SemaphoreSlim(1);
        static readonly int EMA_MAX_ORDER = 50;
        private int _Order = 1;
        private double[] outputs = new double[EMA_MAX_ORDER];

        public double Alpha { get; set; } = 0.5d;
        public int Order { get => _Order; set => setOrder(value); }
        public double FilteredValue 
        {
            get
            {
                smphr.Wait();
                double result = outputs[_Order - 1];
                smphr.Release();
                return result;
            }
        }

        void setOrder(int newOrder)
        {
            if (newOrder > EMA_MAX_ORDER)
            { newOrder = EMA_MAX_ORDER; }

            if (newOrder == 0)
            { newOrder = 1; }

            if(newOrder != _Order)
            {
                smphr.Wait();

                if(newOrder > _Order)
                {
                    for(int i = _Order; i < newOrder; i++)
                    {
                        outputs[i] = outputs[_Order - 1];
                    }
                }

                _Order = newOrder;
                smphr.Release();
            }
        }

        public double filter(double value)
        {
            smphr.Wait();
            double fvalue = value;

            //Executes EMA
            if (Order > EMA_MAX_ORDER)
            { Order = EMA_MAX_ORDER; }

            if (Order == 0)
            { Order = 1; }

            for (int i = 0; i < Order; i++)
            {
                outputs[i] = (Alpha * outputs[i]) + ((1 - Alpha) * fvalue);
                fvalue = outputs[i];
            }
            
            double filteredValue = outputs[Order - 1];
            smphr.Release();

            return filteredValue;
        }
    }
}
