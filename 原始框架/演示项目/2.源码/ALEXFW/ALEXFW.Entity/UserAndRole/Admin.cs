﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    [EntityAuthentication(AllowAnonymous = false,
        AddRolesRequired = new object[] { AdminGroup.管理员 },
        EditRolesRequired = new object[] { AdminGroup.管理员},
        RemoveRolesRequired = new object[] { AdminGroup.管理员 },
        ViewRolesRequired = new object[] { AdminGroup.管理员})]
    [DisplayName("管理员")]
    [DisplayColumn("Username", "CreateDate", true)]
    //生成树型导航
    [Parent(typeof(Department), "Department")]
    public class Admin : UserBase
    {
        [Display(Name = "工号", Order = 0)]
        [Searchable]
        public virtual string EmployeeCode { get; set; } // 工号

        [Required]
        [Display(Name = "用户名", Order = 1)]
        [Searchable]
        public virtual string Username { get; set; }

        [Display(Name = "密码", Order = 2)]
        public override byte[] Password
        {
            get { return base.Password; }
            set { base.Password = value; }
        }
        
        [Display(Name = "是否锁定", Order = 20)]
        public virtual bool IsLocked { get; set; } = false;//是否锁定，不能登录

        [Display(Name = "是否删除", Order = 30)]
        public virtual bool IsDeleted { get; set; } = false;//是否删除，不能登录，通常管理者用户不能删除，因为要保留工作日志

        [Hide(IsHiddenOnCreate = true, IsHiddenOnEdit = true)]
        public virtual DateTime LastLoginDateTime { get; set; } = DateTime.Now; //上一次登录时间

        [Required(ErrorMessage = "此项不能为空")]
        [Display(Name = "用户权限", Order = 20)]
        [Searchable]
        public virtual AdminGroup Group { get; set; }

        [Display(Name = "店铺", Order = 40)]
        public virtual  Department Department { get; set; }

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