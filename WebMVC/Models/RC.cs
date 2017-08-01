using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class RC
    {

        public decimal M { get; set; }
        public decimal S { get; set; }
        public decimal J { get; set; }
        public decimal Average
        {
            get { return (M + S + J) / 3; }
        }
        public decimal Percent(int i)
        {
            if (Sum == 0) return 0;
            switch (i)
            {
                case 1: return M / (M + S + J);
                case 2: return S / (M + S + J);
                case 3: return J / (M + S + J);
            }
            return 0;
        }
        public decimal OutputCoefficient(int i)
        {
            decimal result = 0;
            switch (i)
            {
                case 1:result= Common.Cal.OutputCoefficient(M,S,J,Average);break;
                case 2:result= Common.Cal.OutputCoefficient(S,M,J,Average);break;
                case 3:result= Common.Cal.OutputCoefficient(J,M,S,Average);break;
            }
            return result;
             
        }
        public decimal Sum
        {
            get
            {
                return M + S + J;

            }

        }
    }
}