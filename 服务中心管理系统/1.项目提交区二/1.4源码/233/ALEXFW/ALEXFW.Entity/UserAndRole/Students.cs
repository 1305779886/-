using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    [EntityAuthentication(AllowAnonymous = false,
        AddRolesRequired = new object[] { AdminGroup.学生服务中心管理员 },
        RemoveRolesRequired = new object[] { AdminGroup.学生服务中心管理员 },
        EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
    [DisplayName("学生")]
    [DisplayColumn("PersonName", "CreateDate", true)]
    [Parent(typeof(Dorm), "ParentDepartment")]
    public class Students : System.Data.Entity.Entity
    {
        [Required(ErrorMessage = "学生用户名不能为空")]
        [Searchable]
        [Distinct(ErrorMessage = "学生用户名不能重复")]
        [Display(Name = "学生用户名", Order = 0)]
        public virtual string Username { get; set; }

        [Required(ErrorMessage = "学生姓名不能为空")]
        [Searchable]
        [Display(Name = "学生姓名", Order = 1)]
        public virtual string PersonName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码", Order = 2)]
        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 },
            ViewRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
        public override byte[] Password
        {
            get { return base.Password; }
            set { base.Password = value; }
        }
        
        [Searchable]
        [Display(Name = "宿舍号", Order = 4)]
        public virtual Dorm Dorm { get; set; }

        [Display(Name = "头像", Order = 105)]
        [CustomDataType("SingleImage")]
        [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        public virtual string Avatar { get; set; }

        [Display(Name = "是否禁用", Order = 5)]
        [CustomDataType(CustomDataType.Boolean)]
        public virtual bool IsEnabled { get; set; }

        [Display(Name = "上次登录时间", Order = 111)]
        [Column(TypeName = "datetime2")]
        [Hide]
        public virtual DateTime LastLoginDateTime { get; set; }

        public string GetName()
        {
            if (string.IsNullOrEmpty(PersonName))
                return PersonName ?? Username;
            return PersonName;
        }
    }
}