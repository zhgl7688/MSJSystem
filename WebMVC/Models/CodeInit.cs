using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class CodeInit
    {
        [Key]
        public int CodeId { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }

        public string  Remark {get;set;}
        public int IsEnable { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}