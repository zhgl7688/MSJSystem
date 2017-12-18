using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public partial class MJA
    {
 

        public List<decimal> M { get; set; } = new List<decimal>();


        public List<decimal> J { get; set; } = new List<decimal>();

        public List<decimal> Agent { get; set; } = new List<decimal>();

        public List<decimal> Average
        {
            get
            {
                List<decimal> av = new List<decimal>();
                for (int i = 0; i < M.Count; i++)
                {
                    av.Add((M[i] + J[i] + Agent[i]) / 3);
                }
                return av;
            }
        }
    }
}