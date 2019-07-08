using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALEXFW.Entity.Demos
{
    [EntityAuthentication(AllowAnonymous = false,
       AddRolesRequired = new object[] { AdminGroup.学生服务中心队长 },
       EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 },
       RemoveRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]

    [DisplayName("失主信息")]
    [DisplayColumn("OwnerName")]
    [Parent(typeof(Owner), "ParentDepartment")]
    public  class Owner:EntityBase
    {
        [Required(ErrorMessage = "失主名字不能为空")]
        [Display(Name = "失主名字", Order = 1)]
        [Searchable]
        public virtual string OwnerName { get; set; }

        [Required(ErrorMessage = "失主联系方式不能为空")]
        [Searchable]
        [Display(Name ="失主联系方式",Order =2)]
        public virtual string Telephone { get; set; }

        [Required(ErrorMessage = "失主物品信息不能为空")]
        [Searchable]
        [Display(Name = "失主物品信息", Order = 3)]
        public virtual Lost Lost { get; set; }

        [Required(ErrorMessage = "失主领取时间不能为空")]
        [Searchable]
        [Display(Name = "失主领取时间", Order = 4)]
        public virtual DateTime NowDateTime { get; set; }

        [Required(ErrorMessage = "是否领取不得为空")]
        [Display(Name = "是否领取", Order = 5)]
        public virtual bool SQLChoose { get; set; }
    }
}
