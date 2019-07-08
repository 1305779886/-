using ALEXFW.Entity.UserAndRole;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.Demos
{
   
    [DisplayName("维修人员信息")]
    public class Serviceman : EntityBase
    {
        [Required(ErrorMessage = "工号不能为空")]
        [Display(Name = "工号", Order = 0)]
        [Distinct]
        [Searchable]
        public virtual string servicemanID { get; set; } // 工号

        [Required(ErrorMessage = "姓名不能为空")]
        [Display(Name = "姓名", Order = 1)]
        [Searchable]
        public virtual string Username { get; set; }

        [Required(ErrorMessage = "电话不能为空")]
        [Display(Name = "电话", Order = 2)]
        public virtual string Tel { get; set; }

        [Display(Name = "结束时间", Order = 100)]
        public virtual string Hour { get; set; }
    }
}
