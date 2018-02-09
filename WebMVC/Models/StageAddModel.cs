using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class StageAddModel
    {
        [Key]
        [DisplayName("编号")]
        public int Id { get; set; }
        [Required(ErrorMessage = "类型不能为空")]
        [DisplayName("类型")]
        public string StageType { get; set; }
        [Required(ErrorMessage = "阶段不能为空")]
        [DisplayName("阶段")]
        public string Stage { get; set; }
        [Required(ErrorMessage = "名称不能为空")]
        [DisplayName("名称")]
        public string retail { get; set; }
        public string retailPrice { get; set; } = "0.00";
        [Required(ErrorMessage ="供应商不能为空")]
        public string AgentBrandName { get; set; }
        public List<SelectListItem> AgentBrandNamelist { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> StageTypeList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> StageList { get; set; } = new List<SelectListItem>();
    }
}