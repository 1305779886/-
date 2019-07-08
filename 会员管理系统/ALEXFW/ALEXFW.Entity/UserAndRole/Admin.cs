using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    [EntityAuthentication(AllowAnonymous = false,
        AddRolesRequired = new object[] { AdminGroup.店长 },
        EditRolesRequired = new object[] { AdminGroup.店长 },
        RemoveRolesRequired = new object[] { AdminGroup.店长 },
        ViewRolesRequired = new object[] { AdminGroup.店长 })]
    [DisplayName("管理人员")]
    [DisplayColumn("Username", "CreateDate", true)]
    [Parent(typeof(Department), "Department")]
    public class Admin : UserBase
    {

        [Required(ErrorMessage = "工号不能为空")]
        [Display(Name = "工号", Order = 0)]
        [Distinct(ErrorMessage = "工号不能重复")]
        [Searchable]
        public virtual string EmployeeCode { get; set; } // 工号

        [Required(ErrorMessage = "用户名不能为空")]
        [Distinct(ErrorMessage = "用户名不能重复")]
        [Display(Name = "用户名", Order = 1)]
        [Searchable]
        public virtual string Username { get; set; }

        [Display(Name = "密码", Order = 2)]
        [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        public override byte[] Password
        {
            get { return base.Password; }
            set { base.Password = value; }
        }

        [Display(Name = "是否锁定", Order = 40)]
        [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        public virtual bool IsLocked { get; set; } = false;//是否锁定，不能登录

        [Hide(IsHiddenOnCreate = true, IsHiddenOnEdit = true, IsHiddenOnView = false, IsHiddenOnDetail = false)]
        [Display(Name = "最近活动时间", Order = 100)]
        public virtual DateTime LastLoginDateTime { get; set; } = DateTime.Now; //上一次登录时间

        
        [Display(Name = "用户权限", Order = 5)]
        [Required(ErrorMessage = "用户权限不能为空")]
        [Searchable]
        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.管理员 },
            ViewRolesRequired = new object[] { AdminGroup.管理员 })]
        public virtual AdminGroup Group { get; set; }

        [Display(Name = "店铺", Order = 4)]
        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.管理员 },
            ViewRolesRequired = new object[] { AdminGroup.管理员 })]
        public virtual Department Department { get; set; }

        //此方法用于判断用户角色
        public override bool IsInRole(object role)
        {
            if (role is string)
            {
                AdminGroup value;
                if (!Enum.TryParse((string)role, out value))
                    return false;
                return Group.HasFlag(value);
            }
            if (role is AdminGroup)
                return Group.HasFlag((AdminGroup)role);
            return false;
        }
    }
}