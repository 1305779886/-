using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    /// <summary>
    ///   店铺
    /// </summary>
    [EntityAuthentication(AllowAnonymous = false,
    AddRolesRequired = new object[] { AdminGroup.店长 },
    EditRolesRequired = new object[] { AdminGroup.店长 },
    RemoveRolesRequired = new object[] { AdminGroup.店长 },
    ViewRolesRequired = new object[] { AdminGroup.店长 })]


    [DisplayName("店铺")]
    [DisplayColumn("DepartmentName", "SortCode", false)]
    [Parent(typeof(Department), "ParentDepartment")]
    public class Department : EntityBase
    {
        [Required]
        [Display(Name = "店铺编号")]
        [Searchable]
        public virtual string SortCode { get; set; }

        [Required]
        [Display(Name = "店铺名称")]
        [Searchable]
        public virtual string DepartmentName { get; set; } //部门名称

        [Display(Name = "简介")]
        public virtual string DSCN { get; set; }    //店铺的简介

        [Display(Name = "地址")]
        public virtual string Adress { get; set; }    //店铺的简介

        [Display(Name = "电话")]
        public virtual string Tel { get; set; }    //店铺的简介

        [Display(Name = "营业时间")]
        public virtual string Times { get; set; }    //店铺的简介


        [Display(Name = "Logo")]
        [Hide(IsHiddenOnDetail = false)]
        public virtual string Logo { get; set; }


        [Hide]
        [Display(Name = "店铺人员")]
        public virtual ICollection<Admin> Admins { get; set; } //店铺人员

        public override void OnCreateCompleted()
        {
            base.OnCreateCompleted();
            CreateDate = DateTime.Now;
        }
    }
}
