using ALEXFW.Entity.Demos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    [EntityAuthentication(AllowAnonymous = false,
        AddRolesRequired = new object[] { AdminGroup.店长 },
        RemoveRolesRequired = new object[] { AdminGroup.店长 },
        EditRolesRequired = new object[] { AdminGroup.店长 })]
    [DisplayName("会员")]
    [DisplayColumn("PersonName", "CreateDate", true)]
    [Parent(typeof(Department), "Department")]
    public class Member : UserBase
    {

        [Required(ErrorMessage = "用户名不能为空")]
        [Searchable]
        [Display(Name = "用户名", Order = 0)]
        public virtual string Username { get; set; }

        [Required]
        [Searchable]
        [Display(Name = "姓名", Order = 1)]
        public virtual string PersonName { get; set; }

        [Display(Name = "密码", Order = 2)]
        public override byte[] Password
        {
            get { return base.Password; }
            set { base.Password = value; }
        }

        [Display(Name = "会员等级", Order = 20)]

        public virtual Grade Grade { get; set; }

        [PropertyAuthentication(EditRolesRequired = new object[] { AdminGroup.管理员 },
    ViewRolesRequired = new object[] { AdminGroup.管理员 })]
        //[Searchable]
        [Display(Name = "店铺", Order = 4)]
        public virtual Department Department { get; set; }

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

        [Display(Name = "电话", Order = 3)]
        public virtual string Telephone { get; set; }

        [Display(Name = "地址", Order = 100)]
        public virtual string Address { get; set; }

        [Display(Name = "会员积分", Order = 60)]
        public virtual int Integral { get; set; } = 0;

        //[Display(Name = "会员卡号", Order = 40)]
        //public virtual MemberCard Card { get; set; }
        [Hide(IsHiddenOnView = false)]
        [Display(Name = "会员卡", Order = 10)]
        public virtual ICollection<MemberCard> MemberCards { get; set; }



        public string GetName()
        {
            if (string.IsNullOrEmpty(PersonName))
                return PersonName ?? Username;
            return PersonName;
        }



    }
}