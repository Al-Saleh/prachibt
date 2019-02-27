using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class PrimeModel
    {
        private PrimeContext primeContext { get; set; }

        public PrimeModel(PrimeContext _primeContext)
        {
            primeContext = _primeContext;
        }


        public int GetPrimeNumber(int Index)
        {
            var r = 0;
            var data = primeContext.Primes.Where(x => x.Index == Index).FirstOrDefault();

            if (data != null)
                return data.Value;

            var listData = new List<Prime>();

            var isPrime = true;
            for (int number = 1, countIndex = 0; ; number++)
            {
                isPrime = true;
                for (int number2 = 2; number2 < number; number2++)
                {

                    if (number % number2 == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    if(primeContext.Primes.Where(x=>x.Index == countIndex).Count() == 0)
                    {
                        primeContext.Primes.Add(new Prime { Index = countIndex, Value = number });
                        primeContext.SaveChanges();
                    }
                    listData.Add(new Prime { Index = countIndex, Value = number });
                    if (countIndex == Index)
                    {
                        r = number;
                        break;
                    }
                    countIndex++;
                }
            }
            
            
            return r;
        }
    }
}
