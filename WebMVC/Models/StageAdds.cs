using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class StageAdd
    {
        [Key]
        [DisplayName("编号")]
        public int Id { get; set; }
        public string AgentName { get; set; }
        public string Stage { get; set; }
        public string retail { get; set; }
        public string retailPrice { get; set; }
    }
}
