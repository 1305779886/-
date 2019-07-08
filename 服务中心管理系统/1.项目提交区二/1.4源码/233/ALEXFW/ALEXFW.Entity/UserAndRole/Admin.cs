using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    //角色权限控制
    [EntityAuthentication(AllowAnonymous = false,
        AddRolesRequired = new object[] { AdminGroup.学生服务中心管理员 },//角色为队长的时候可以新增
        EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 },//角色为队长的时候可以修改
        RemoveRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]//角色为队长的时候可以删除
    [DisplayName("管理员")]
    [DisplayColumn("EmployeeCode", "CreateDate", true)]
    //[Parent(typeof(Dorm), "ParentDepartment")]
    [Parent(typeof(GroupTeam), "ParentDepartment")]
    public class Admin : System.Data.Entity.Entity
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
        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
        public virtual string Username { get; set; }//用户名

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码", Order = 2)]
        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 },//修改信息
            ViewRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]//查看信息
        public override byte[] Password //密码
        {
            get { return base.Password; }
            set { base.Password = value; }
        }

        [Display(Name = "是否锁定", Order = 20)]
        [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        public virtual bool IsLocked { get; set; } = false;

        [Display(Name = "维修队伍分组", Order = 5)]
        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 },
            ViewRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
        public virtual GroupTeam GroupTeam { get; set; }//维修队伍分组（来源其他表的实体）


        [Hide(IsHiddenOnCreate = true, IsHiddenOnEdit = true)]
        public virtual DateTime LastLoginDateTime { get; set; } = DateTime.Now; 

        [Required(ErrorMessage = "用户权限不能为空")]
        [Display(Name = "用户权限", Order = 20)]
        
        public virtual AdminGroup Group { get; set; }//用户角色
        

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