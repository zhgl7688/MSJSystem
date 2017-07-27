using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    /// <summary>
    /// 厂家主导的品牌力
    /// </summary>
    public class BrandStrength
    {

    }
    public class BrandStrengthT
    {
        public string 阶段 { get; set; }
        public decimal B
        {
            get
            {
                return E / (E + F + G);
            }
        }
        public decimal C
        {
            get
            {
                return F / (E + F + G);
            }
        }
        public decimal D
        {
            get
            {
                return G / (E + F + G);
            }
        }
        public decimal E { get; set; }
        public decimal F { get; set; }
        public decimal G { get; set; }
        public decimal H { get; set; }
        public decimal I { get; set; }
        public decimal J { get; set; }
        public decimal K
        {
            get
            {
                return H / (H + I + J);
            }
        }
        public decimal L {
            get
            {
                return I/ (H + I + J);
            }
        }
        public decimal M {
            get
            {
                return J/ (H + I + J);
            }
        }
        public decimal N {
            get
            {
                return  (K + L + M)/3;
            }
        }


    }
}