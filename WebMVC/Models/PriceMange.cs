using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class PriceMange
    {
        [Key]
        public virtual int PriceMangeId { get; set; }
        public virtual int AgentInputId { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Value { get; set; }
        
    }
}