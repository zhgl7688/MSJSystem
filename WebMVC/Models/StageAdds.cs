﻿using System;
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
        [Required(ErrorMessage ="类型不能为空")]
        [DisplayName("类型")]
        public string StageType { get; set; }
        [Required(ErrorMessage = "阶段不能为空")]
        [DisplayName("阶段")]
        public string Stage { get; set; }
        [Required(ErrorMessage = "名称不能为空")]
        [DisplayName("名称")]
        public string retail { get; set; }
        public string retailPrice { get; set; } = "0.00";
    }
}
