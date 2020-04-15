using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALEXFW.Entity.UserAndRole
{

    [DisplayName("会员等级管理")]
    [DisplayColumn("Level", "Level", false)]
    //权限
    [EntityAuthentication(AllowAnonymous = false,
       RemoveRolesRequired = new object[] { AdminGroup.管理员 })]
    ////树型筛选
    //[Parent(typeof(Category), "Category")]
    public class Grade : EntityBase
    {
        [Distinct]
        [Display(Name = "会员等级编号", Order = 0)]
        [Required(ErrorMessage = "编号不能为空")]
        [Searchable]
        public virtual string Levelid { get; set; }

        [Distinct]
        [Display(Name = "会员等级", Order = 1)]
        [Required(ErrorMessage = "等级不能为空")]
        [Searchable]
        public virtual string Level { get; set; }


    }
}
