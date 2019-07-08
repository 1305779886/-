using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    /// <summary>
    ///     部门
    /// </summary>
    [DisplayName("宿舍信息")]
    [DisplayColumn("SortCode", "CreateDate", true)]
    [Parent(typeof(Dorm), "ParentDepartment")]
    public class Dorm : EntityBase
    {
        [Searchable]
        [Required(ErrorMessage = "宿舍号不能为空")]
        [Display(Name = "宿舍编号")]
        [Distinct(ErrorMessage = "宿舍号不能重复")]
        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
        public virtual string SortCode { get; set; }

     
        [Hide]
        [Display(Name = "宿舍学生")]
        public virtual ICollection<Students> Students { get; set; } //学生


        public override void OnCreateCompleted()
        {
            base.OnCreateCompleted();
            CreateDate = DateTime.Now;
        }
    }
}