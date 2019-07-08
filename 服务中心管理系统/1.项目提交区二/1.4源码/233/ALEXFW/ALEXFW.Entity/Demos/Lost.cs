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

    [DisplayName("失物招领")]
    [DisplayColumn("ItemsName")]
    [Parent(typeof(Lost), "ParentDepartment")]
    public class Lost : EntityBase
    {
        [Required(ErrorMessage = "物品名称不能为空")]
        [Searchable]
        [Display(Name = "物品名称", Order = 1)]
        public virtual string ItemsName { get; set; }

        [CustomDataType("SingleImage")]
        [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        [Required(ErrorMessage = "照片不能为空")]
        [Searchable]
        [Display(Name = "照片", Order = 1)]
        public virtual string image { get; set; }


        [Display(Name = "物品说明", Order = 7)]
        public virtual string Note { get; set; }


        [Searchable]
        [Display(Name = "地点", Order = 3)]
        public virtual string Place { get; set; }


        [Display(Name ="是否被领取",Order=4)]
        public virtual bool Choose { get; set; }
    }
}
